using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;
using System.Text;

public partial class Recruitment_CopyOfCandidates : BaseClass
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

            BindFromClient(ddlfromClient);
            BindToClient(ddlToClient);

        }
    }
    private void BindToClient(DropDownList ddlToClient)
    {
        clientbal = new ClientBAL();
        try
        {
            ListItem li = new ListItem("All", "0");
            ddlToClient.Items.Clear();
            ddlToClient.Items.Add(li);
            if (Role == 1)
            {
                ddlToClient.DataSource = clientbal.FillClient();
            }
            else if (Role == 9)
            {
                ddlToClient.DataSource = clientbal.FillClient();
            }

            ddlToClient.DataTextField = "Client_Name";
            ddlToClient.DataValueField = "Client_Id";
            ddlToClient.DataBind();
        }
        finally
        {
            clientbal = null;
        }
    }

    private void BindFromClient(DropDownList ddlfromClient)
    {
        clientbal = new ClientBAL();
        try
        {
            ListItem li = new ListItem("All", "0");
            ddlfromClient.Items.Clear();
            ddlfromClient.Items.Add(li);
            if (Role == 1)
            {
                ddlfromClient.DataSource = clientbal.FillFromClient();
            }
            else if (Role == 9)
            {
                ddlfromClient.DataSource = clientbal.FillFromClient();
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
    protected void BindRROfToClient(DropDownList ddlfromClient, DropDownList ddlFromRRNo)
    {
        TodPos = new TodayPositionBAL();
        try
        {
            ListItem li = new ListItem("Select", "0");
            ddlToRRNumber.Items.Clear();
            ddlToRRNumber.Items.Add(li);
            int ClientId = Convert.ToInt32(ddlToClient.SelectedValue);
            TodPos.ClientID = ClientId;
            ddlToRRNumber.DataSource = TodPos.GetRRNumberByClient();
            ddlToRRNumber.DataTextField = "RRNumber";
            ddlToRRNumber.DataValueField = "Request_Id";
            ddlToRRNumber.DataBind();
        }
        finally
        {
            TodPos = null;
        }
    }
    protected void BindRROfFromClient(DropDownList ddlfromClient, DropDownList ddlFromRRNo)
    {
        TodPos = new TodayPositionBAL();
        try
        {
            ListItem li = new ListItem("Select", "0");
            ddlFromRRNo.Items.Clear();
            ddlFromRRNo.Items.Add(li);
            int ClientId = Convert.ToInt32(ddlfromClient.SelectedValue);
            TodPos.ClientID = ClientId;
            ddlFromRRNo.DataSource = TodPos.GetRRnumberByfromClient();
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

        BindRROfFromClient(ddlfromClient, ddlFromRRNumber);
    }
 protected void ddlFromRRNumber_SelectedIndexChanged(object sender, EventArgs e)
    {

        BindConsultant(ddlFromRRNumber, ddlFromConsultant);
       
    }

 protected void BindToConsultant(DropDownList ddlToRRNumber, DropDownList ddlToConsultant)
 {
     TodPos = new TodayPositionBAL();
     ListItem lic = new ListItem("Select", "0");
     try
     {

         ddlToConsultant.Items.Clear();
         ddlToConsultant.Items.Add(lic);
         TodPos.Request_Id = Convert.ToInt32(ddlToRRNumber.SelectedValue);
         ddlToConsultant.DataSource = TodPos.GetConsultantByRRNo();
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
 protected void BindConsultant(DropDownList ddlFromRRNumber, DropDownList ddlFromConsultant)
    {
        TodPos = new TodayPositionBAL();
        ListItem lic = new ListItem("Select", "0");
        try
        {

            ddlFromConsultant.Items.Clear();
            ddlFromConsultant.Items.Add(lic);
            TodPos.Request_Id = Convert.ToInt32(ddlFromRRNumber.SelectedValue);
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
 protected void ddlToClient_SelectedIndexChanged(object sender, EventArgs e)
 {

     BindRROfToClient(ddlToClient, ddlToRRNumber);
 }

 protected void ddlToRRNumber_SelectedIndexChanged(object sender, EventArgs e)
 {
     BindToConsultant(ddlToRRNumber, ddlToConsultant);
     btnSave.Visible = true;
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

        if (ddlToClient.SelectedIndex > 0)
        {
            sb.Append(" and Rr.Client_Id = '" + ddlToClient.SelectedValue + "'");
        }
        if (ddlToRRNumber.SelectedIndex > 0)
        {
            sb.Append(" and Rr.Request_Id = '" + ddlToRRNumber.SelectedValue + "'");
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
        if (ViewState["dt"] != null)
        {
            dt = (DataTable)ViewState["dt"];
        }
        DataView dv = new DataView(dt);
        dv.RowFilter = "Status='" + ddlRecordStatus.SelectedValue + "'";
        gdvData.DataSource = dv;
        gdvData.DataBind();

    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        TodPos = new TodayPositionBAL();
        string StrCandId;
        StrCandId = "";

        try
        {

            TodPos.LoggedBy = UserId;
            for (int idx = 0; idx < gdvData.Rows.Count; idx++)
            {
                CheckBox ChkTRansfer = ((CheckBox)(gdvData.Rows[idx].FindControl("ChkTRansfer")));
                if (ChkTRansfer.Checked == true)
                {
                    StrCandId = StrCandId + ((Label)(gdvData.Rows[idx].FindControl("lblCandidate_Id"))).Text + ",";
                }
            }
            try
            {
                StrCandId = StrCandId.Substring(0, StrCandId.Length - 1);

            }
            catch (Exception ex12) { }
          TodPos.CandidateIdStr = StrCandId;
            TodPos.ClientID = Convert.ToInt32(ddlfromClient.SelectedValue);
            TodPos.Request_Id = Convert.ToInt32(ddlFromRRNumber.SelectedValue);
            TodPos.ConsultantId = Convert.ToInt32(ddlFromConsultant.SelectedValue);
            TodPos.ToClientID = Convert.ToInt32(ddlToClient.SelectedValue);
            TodPos.ToRequest_Id = Convert.ToInt32(ddlToRRNumber.SelectedValue);
            TodPos.ToConsultantId = Convert.ToInt32(ddlToConsultant.SelectedValue);
            result = TodPos.IU_CopyOfCandidates();
            if (result > 0)
            {
                lblmsg.Text = "Candidates Coppied Successfully !.";
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