using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text;
using System.IO;
using System.Configuration;

public partial class Report_CandidateOffered : BaseClass
{
    ClientBAL clientbal;
    ReportBAL RprtBAL;
    FollowUpBAL FollowBal;
    static int count;
    static string[,] QueryArray = new string[5, 4];
    Search srch;
    static DataTable dt = new DataTable();
    int UserId, URole;
    int MyTimeSpan = 0;



    protected void Page_Load(object sender, EventArgs e)
    {
        UserId = Convert.ToInt32(Session["UserId"]);
        URole = Convert.ToInt32(Session["UserRole"]);
        MyTimeSpan = Convert.ToInt32(ConfigurationManager.AppSettings["TimeSpan"]);

        if (!IsPostBack)
        {
            BindClient();
            BindConsultant();
            //BindCandidateStatus(ddlCandStatus);
            RprtBAL = new ReportBAL();
            try
            {

                BindGrid();
            }
            catch (Exception ex)
            {


            }
            finally
            {
                RprtBAL = null;
            }
        }
    }
    private void BindGrid()
    {
        RprtBAL = new ReportBAL();
        string MyText = "";
        DataTable dt = new DataTable();
        try
        {
            if(ddlCandStatus.SelectedIndex==0)
            {
                MyText= "Offered','Offer Accepted','Offered Drop Out";
            }
            else
            {
                MyText = ddlCandStatus.SelectedItem.Text;
            }


            dt = SearchCandidateOfferd(MyText);
            DataView dv = new DataView(dt);
                if (ViewState["SortExpr"] != null)
                    dv.Sort = (string)ViewState["SortExpr"] + " " + (string)ViewState["SortDir"];
          
            gdvCanOfferd.DataSource = dv;
            gdvCanOfferd.DataBind();
        }
        catch (Exception ex)
        {


        }
        finally
        {
            RprtBAL = null;
        }
    }


    protected void gdvCanOfferd_Sorting(object sender, GridViewSortEventArgs e)
    {
        ViewState["SortExpr"] = e.SortExpression;
        if (ViewState["SortDir"] != null)
            e.SortDirection = (string)ViewState["SortDir"] == "ASC" ? SortDirection.Descending : SortDirection.Ascending;
        ViewState["SortDir"] = e.SortDirection == SortDirection.Ascending ? "ASC" : "DESC";
        BindGrid();
    }
    private void BindClient()
    {
        clientbal = new ClientBAL();
        try
        {
            ListItem li = new ListItem("All", "0");
            ddlClientName.Items.Clear();
            ddlClientName.Items.Add(li);
            ddlClientName.DataSource = clientbal.FillClient();
            ddlClientName.DataTextField = "Client_Name";
            ddlClientName.DataValueField = "Client_Id";
            ddlClientName.DataBind();
        }
        finally
        {
            clientbal = null;
        }
    }
 protected void BindConsultant()
    {
        LoginBAL loginbal = new LoginBAL();
        try
        {
            ListItem li = new ListItem("Select", "0");
            ddlConsultant.Items.Clear();
            ddlConsultant.Items.Add(li);
            if (URole == 1)
            {
                ddlConsultant.DataSource = loginbal.FillUser();
            }
            else if (URole == 9)
            {
                ddlConsultant.DataSource = loginbal.FillUser();
            }
            else if (URole == 3 || URole==8)
            {
                loginbal.Usr_Id = UserId;
                ddlConsultant.DataSource = loginbal.FillUserByUserId();
            }
            ddlConsultant.DataTextField = "USR_Name";
            ddlConsultant.DataValueField = "USR_ID";
            ddlConsultant.DataBind();
        }
        finally
        {
            loginbal = null;
        }
    }
 //protected void BindCandidateStatus(DropDownList ddlCandStatus)
 //{
 //    FollowBal = new FollowUpBAL();
 //    ListItem liC = new ListItem("Select", "0");
 //    try
 //    {
 //        ddlCandStatus.Items.Clear();
 //        ddlCandStatus.Items.Add(liC);
 //        ddlCandStatus.DataSource = FollowBal.FillCandidateStatus();
 //        ddlCandStatus.DataTextField = "CandidateStatus";
 //        ddlCandStatus.DataValueField = "CandidateStatus_Id";
 //        ddlCandStatus.DataBind();
 //    }
 //    finally
 //    {
 //        liC = null;
 //        FollowBal = null;
 //    }

 //}
    protected void gdvCanOfferd_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gdvCanOfferd.PageIndex = e.NewPageIndex;
        BindGrid();
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        BindGrid();
    }
    protected DataTable SearchCandidateOfferd(string MyText)
    {
        Search srch = new Search();
        string query = "", subquery = "";
        query = "Select Distinct(rr.RRCandidate_Id),rq.Client_Id,cl.Client_Name, rq.RRNumber,rq.Designation,cd.Candidate_Name,ud.USR_Name as Consultant,rr.Consultant_Id  " +
                ",Convert(varchar,rr.CreationDate,106)   as CreationDate ,rr.Overall_Status    " +
                ",rr.OfferPrice,rr.PlannedDOJ,rr.ActualDoJ,rr.OfferDate ,rq.Job_Profile " +
                "FRom RRCandidateRelation as rr   " +

                "inner join CandidateDetail as cd on rr.Candidate_Id=cd.Candidate_Id    " +
                "inner join RecruitmentRequest as rq on  rr.Request_Id=rq.Request_Id  " +
                "left join UserClientRelation as uc on rr.Consultant_Id =uc.Consultant_Id     " +
                "inner join CLientDetail as cl on rq.Client_Id=cl.Client_Id   " +
                "left join UserDetail as ud on uc.Consultant_Id=ud.USR_ID  " +
                "Where  rr.status=1 ";


        if (ddlClientName.SelectedIndex > 0)
        {
            subquery = " and rq.Client_Id= " + Convert.ToInt32(ddlClientName.SelectedValue);
        }
        if (ddlConsultant.SelectedIndex > 0)
        {
            subquery += " and rr.Consultant_Id = " + Convert.ToInt32(ddlConsultant.SelectedValue);
        }

        if (txtOfferedDate.Text.Trim() != "")
        {
            subquery = subquery + " and Cast(rr.OfferDate as date)=Cast('" + txtOfferedDate.Text.Trim() + "' as date ) ";
        }
        if (txtActualDoj.Text.Trim() != "")
        {
            subquery = subquery + " and Cast(rr.ActualDoJ as date)=Cast('" + txtActualDoj.Text.Trim() + "' as date ) ";
        }
        if (txtPlannedDate.Text.Trim() != "")
        {
            subquery = subquery + " and Cast(rr.PlannedDOJ as date)=Cast('" + txtPlannedDate.Text.Trim() + "' as date ) ";
        }




        subquery = subquery + " and rr.Overall_Status in ('" + MyText + "')";





            query = query + subquery;
        //+ " Order by rr.CreationDate desc";


        return srch.SearchRecord(query).Tables[0];
    }
  #region Using VerifyRenderingInServerForm
    protected void lbtnDownload_Click(object sender, EventArgs e)
    {
        try
        {
            string MyText = "";
            MyText = "Offered','Offer Accepted','Offered Drop Out";
            string fileName = "CandidatesOfferd";
            dt = SearchCandidateOfferd(MyText);

            string attachment = "attachment; filename=" + fileName + ".xls";
            Response.ClearContent();
            Response.AddHeader("content-disposition", attachment);
            Response.ContentType = "application/vnd.xls"; // ms-excel
            DataGrid dg = new DataGrid();
            dg.DataSource = dt;
            dg.DataBind();
            StringWriter stw = new StringWriter();
            HtmlTextWriter htextw = new HtmlTextWriter(stw);
            dg.RenderControl(htextw);
            Response.Write(stw.ToString());
            Response.End();
        }
        catch (Exception ex)
        {
        }
        finally
        { }
    }
    public override void VerifyRenderingInServerForm(Control control)
    {

    }
    #endregion
  protected void gdvCanOfferd_RowDataBound(object sender, GridViewRowEventArgs e)
    {
     
        if ((e.Row.RowState & DataControlRowState.Edit) > 0)
        {
            //TextBox txtEOfferedDate = ((TextBox)e.Row.FindControl("txtEOfferedDate"));
            //txtEOfferedDate.Text = DateTime.Now.AddMinutes(MyTimeSpan).ToString("dd-MMM-yyyy");
            //TextBox txtEActualDoJ = ((TextBox)e.Row.FindControl("txtEActualDoJ"));
            //txtEActualDoJ.Text = DateTime.Now.AddMinutes(MyTimeSpan).ToString("dd-MMM-yyyy");
            //TextBox txtEPlannedDOJ = ((TextBox)e.Row.FindControl("txtEPlannedDOJ"));
            //txtEPlannedDOJ.Text = DateTime.Now.AddMinutes(MyTimeSpan).ToString("dd-MMM-yyyy");
        }

    }
 protected void gdvCanOfferd_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        lblmsg.Text = "";
        gdvCanOfferd.EditIndex = -1;
        BindGrid();
       
    }
 protected void gdvCanOfferd_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {

        GridViewRow gvr = gdvCanOfferd.Rows[e.RowIndex];
        FollowBal = new FollowUpBAL();
      
        try
        {
            FollowBal.RRCandidateId = Convert.ToInt32(((Label)gvr.FindControl("lblERRCandidate_Id")).Text);
            if (((TextBox)gvr.FindControl("txtEOfferdPrice")).Text != "")
            {
                FollowBal.OfferedPrice = Convert.ToDouble(((TextBox)gvr.FindControl("txtEOfferdPrice")).Text);
            }
            else
            {
                FollowBal.OfferedPrice = 0;
            }

      
            FollowBal.OfferDate = ((TextBox)gvr.FindControl("txtEOfferedDate")).Text;
            FollowBal.ActualDoj = ((TextBox)gvr.FindControl("txtEActualDoJ")).Text;
            FollowBal.PlannedDoj = ((TextBox)gvr.FindControl("txtEPlannedDOJ")).Text;
         
            FollowBal.LoggedBy = UserId;
            FollowBal.UpdateRRCandidte();
     
            lblmsg.Text = "Updated successfully.";
            lblmsg.ForeColor = System.Drawing.Color.Green;
            gdvCanOfferd.EditIndex = -1;
            BindGrid();
           


        }
        catch (Exception ex)
        {
            lblmsg.Text = ex.ToString();
        }
        finally
        {
            FollowBal = null;
        }
    }
  protected void gdvCanOfferd_RowEditing(object sender, GridViewEditEventArgs e)
    {
        lblmsg.Text = "";
        gdvCanOfferd.EditIndex = e.NewEditIndex;
        BindGrid();

    }
}