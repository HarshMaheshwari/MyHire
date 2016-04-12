using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;
using System.Text;

public partial class Recruitment_TransferOfConsultants : BaseClass
{
  
    RecruitmentBAL recruitbal;
    ClientBAL clientbal;
    int UserId, Role, CountCl, CountCont, CountAss, CountReq;
    static string[,] QueryArray = new string[3, 2];
    Search srch;
    int result;
    TodayPositionBAL TodPos;
    DataTable dt;
    protected void Page_Load(object sender, EventArgs e)
    {
        UserId = Convert.ToInt32(Session["UserId"]);
        Role = Convert.ToInt32(Session["UserRole"]);
        if (!IsPostBack)
        {

            BindClient(ddlfromClient);
          
        }
    }
   private void BindClient(DropDownList ddlfromClient)
    {
        clientbal = new ClientBAL();
        try
        {
            ListItem li = new ListItem("All", "0");
            ddlfromClient.Items.Clear();
            ddlfromClient.Items.Add(li);
            if (Role == 1)
            {
                ddlfromClient.DataSource = clientbal.FillClient();
            }
            else if (Role == 9)
            {
                ddlfromClient.DataSource = clientbal.FillClient();
            }

            ddlfromClient.DataTextField = "Client_Name";
            ddlfromClient.DataValueField = "Client_Id";
            ddlfromClient.DataBind();
        }
        finally
        {
            clientbal = null;
        }
    }
   protected void BindRROfClient(DropDownList ddlfromClient,DropDownList ddlFromRRNo)
   {
       TodPos = new TodayPositionBAL();
       try
       {
           ListItem li = new ListItem("Select", "0");
           ddlFromRRNo.Items.Clear();
           ddlFromRRNo.Items.Add(li);
           int ClientId = Convert.ToInt32(ddlfromClient.SelectedValue);
           TodPos.ClientID = ClientId;
           ddlFromRRNo.DataSource = TodPos.GetRRNumberByClient();
           ddlFromRRNo.DataTextField = "RRNumber";
           ddlFromRRNo.DataValueField = "Request_Id";
           ddlFromRRNo.DataBind();
       }
       finally
       {
           TodPos = null;
       }
   }
   protected void ddlfromClient_SelectedIndexChanged(object sender, EventArgs e)
   {

       BindRROfClient(ddlfromClient, ddlFromRRNumber);
   }
   protected void ddlFromRRNumber_SelectedIndexChanged(object sender, EventArgs e)
   {

       BindConsultant(ddlFromRRNumber, ddlFromConsultant);
       BindToConsultant(ddlFromRRNumber, ddlToConsultant);
       btnSave.Visible = true;
   }
protected void BindConsultant(DropDownList ddlFromRRNumber, DropDownList ddlFromConsultant)
    {
        TodPos = new TodayPositionBAL();
        ListItem lic = new ListItem("Select", "0");
        try
        {
           
            ddlFromConsultant.Items.Clear();
            ddlFromConsultant.Items.Add(lic);
            TodPos.Request_Id= Convert.ToInt32(ddlFromRRNumber.SelectedValue);
            ddlFromConsultant.DataSource = TodPos.GetConsultantByRRNo();
            ddlFromConsultant.DataTextField = "USR_Name";
            ddlFromConsultant.DataValueField = "USR_ID";
            ddlFromConsultant.DataBind();
         }
        finally
        {
            TodPos = null;
            lic = null;
        }
    }
protected void BindToConsultant(DropDownList ddlFromRRNumber, DropDownList ddlToConsultant)
{
    TodPos = new TodayPositionBAL();
    ListItem lic = new ListItem("Select", "0");
    try
    {

        ddlToConsultant.Items.Clear();
        ddlToConsultant.Items.Add(lic);
        TodPos.Request_Id = Convert.ToInt32(ddlFromRRNumber.SelectedValue);
        ddlToConsultant.DataSource = TodPos.GetActiveConsultantByRRNo();
        ddlToConsultant.DataTextField = "USR_Name";
        ddlToConsultant.DataValueField = "USR_ID";
        ddlToConsultant.DataBind();
    }
    finally
    {
        TodPos = null;
        lic = null;
    }
}
    protected void BindGrid()
    {
         dt = new DataTable();
        try
        {
            dt = SearchGridData();
            DataView dv = new DataView(dt);

            dv.RowFilter = "Status='" + ddlRecordStatus.SelectedValue + "'";
            if (ViewState["SortExpr"] != null)
                dv.Sort = (string)ViewState["SortExpr"] + " " + (string)ViewState["SortDir"];

            gdvData.DataSource = dv;
            gdvData.DataBind();
            ViewState["dt"] = dt;

        }
        catch (Exception ex)
        {
        }
        finally
        {

        }
    }

    protected void ddlFromConsultant_SelectedIndexChanged(object sender, EventArgs e)
{

    BindGrid();
}
    
    protected void gdvData_Sorting(object sender, GridViewSortEventArgs e)
    {
        ViewState["SortExpr"] = e.SortExpression;
        if (ViewState["SortDir"] != null)
            e.SortDirection = (string)ViewState["SortDir"] == "ASC" ? SortDirection.Descending : SortDirection.Ascending;
        ViewState["SortDir"] = e.SortDirection == SortDirection.Ascending ? "ASC" : "DESC";

        BindGrid();
    }
    protected void gdvData_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gdvData.PageIndex = e.NewPageIndex;
        BindGrid();


    }
    protected void gdvData_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {


            //Label lblChkIsTodayPos = (Label)e.Row.Cells[0].FindControl("lblChkIsTodayPos");
            //CheckBox ChkIsTodayPos = (CheckBox)e.Row.Cells[0].FindControl("ChkIsTodayPos");

            //if (lblChkIsTodayPos.Text == "1")
            //{
            //    ChkIsTodayPos.Checked = true;
            //    e.Row.BackColor = System.Drawing.Color.PaleTurquoise;

            //}
            //else
            //{
            //    ChkIsTodayPos.Checked = false;
            //}

        }


    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {

        BindGrid();
    }

    public DataTable SearchGridData()
    {
        srch = new Search();
        StringBuilder sb = new StringBuilder();
        sb.Append(" select Rr.Request_Id, Rr.RRNumber, Rr.Job_Profile as Role, Rr.Client_Id, Rr.Request_By,Cr.Consultant_Id,Cr.Candidate_Id,Cr.RRCandidate_Id  ");
        sb.Append(" ,Cd.Candidate_Name,Cd.Mobile_No,ud.USR_Name as Consultants,cl.Client_Name,Cr.Status from RecruitmentRequest as Rr  ");
        sb.Append("  left join RRCandidateRelation as Cr on Rr.Request_Id=Cr.Request_Id ");
        sb.Append("  left join CandidateDetail as Cd on Cd.Candidate_Id=Cr.Candidate_Id ");
        sb.Append("  left join ClientDetail as cl on Rr.Client_Id=cl.Client_Id ");
        sb.Append("  left join UserDetail as ud on Cr.Consultant_Id=ud.USR_ID ");
        sb.Append("  where Rr.Request_Id>0 and Rr.Status=1 and Cr.Status=1   ");

         if (ddlfromClient.SelectedIndex > 0)
       {
           sb.Append(" and Rr.Client_Id = '" + ddlfromClient.SelectedValue + "'");
       }
        if (ddlFromRRNumber.SelectedIndex > 0)
       {
           sb.Append(" and Rr.Request_Id = '" + ddlFromRRNumber.SelectedValue + "'");
       }
        if (ddlFromConsultant.SelectedIndex > 0)
        {
            sb.Append(" and Cr.Consultant_Id = '" + ddlFromConsultant.SelectedValue + "'");
        }
        if (ddlToConsultant.SelectedIndex > 0)
        {
            sb.Append(" and Cr.Consultant_Id = '" + ddlToConsultant.SelectedValue + "'");
        }
        sb.Append(" order by Cd.Candidate_Name Asc ");
        string query = sb.ToString();
        return srch.SearchRecord(query).Tables[0];
    }
    protected void ddlRecordStatus_SelectedIndexChanged(object sender, EventArgs e)
    {
         dt = new DataTable();
         if (ViewState["dt"]!=null)
         { 
         dt =(DataTable)ViewState["dt"];
         }
        DataView dv = new DataView(dt);
        dv.RowFilter = "Status='" + ddlRecordStatus.SelectedValue + "'";
        gdvData.DataSource = dv;
        gdvData.DataBind();

    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        TodPos = new TodayPositionBAL();
        String StrFulRRId;
        StrFulRRId = "";
       // strchkTransfer = "";

        try
        {

            TodPos.LoggedBy = UserId;
            for (int idx = 0; idx < gdvData.Rows.Count; idx++)
            {
                CheckBox ChkTRansfer = ((CheckBox)(gdvData.Rows[idx].FindControl("ChkTRansfer")));
               if (ChkTRansfer.Checked == true)
                {
                   // strchkTransfer = strchkTransfer + 1 + ",";
                    StrFulRRId = StrFulRRId + ((Label)(gdvData.Rows[idx].FindControl("lblRRCandidate_Id"))).Text + ",";

                }
                

            }
            try
            {
                StrFulRRId = StrFulRRId.Substring(0, StrFulRRId.Length - 1);
               // strchkTransfer = strchkTransfer.Substring(0, strchkTransfer.Length - 1);
            }
            catch (Exception ex12) { }
            TodPos.RRCandidateStr = StrFulRRId;
           // TodPos.TransferStr = strchkTransfer;
            TodPos.ClientID = Convert.ToInt32(ddlfromClient.SelectedValue);
            TodPos.Request_Id = Convert.ToInt32(ddlFromRRNumber.SelectedValue);
            TodPos.ConsultantId = Convert.ToInt32(ddlFromConsultant.SelectedValue);
            TodPos.ToConsultantId = Convert.ToInt32(ddlToConsultant.SelectedValue);
            result = TodPos.IU_TransferOfConsultant();
            if (result > 0)
            {
                lblmsg.Text = "Candidates Transferred Successfully !.";
                lblmsg.ForeColor = System.Drawing.Color.Green;
                BindGrid();

            }

        }
        catch (Exception ex)
        {
            
        }
        finally
        {
            TodPos = null;
        }

    }
   
}