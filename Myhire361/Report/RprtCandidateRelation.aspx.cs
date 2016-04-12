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

public partial class Report_RprtCandidateRelation : BaseClass
{
    FollowUpBAL flwupbal;
    LoginBAL loginbal;
    ClientBAL clientbal;
    ReportBAL RprtBAL;
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
            BindConsultant();
            BindClient();
           // BindCandidateStatus();
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
        DataView dv = new DataView();
        try
        {

            dv.Table = SearchforRRcCandidate();
            if (ViewState["SortExpr"] != null)
                dv.Sort = (string)ViewState["SortExpr"] + " " + (string)ViewState["SortDir"];
            //if (URole == 1)
            //{
            //    dv.Table  = SearchForDirector();
            //    if (ViewState["SortExpr"] != null)
            //        dv.Sort = (string)ViewState["SortExpr"] + " " + (string)ViewState["SortDir"];
            //}
            //else if (URole == 2)
            //{
            //    dv.Table  = SearchForManager();
            //    if (ViewState["SortExpr"] != null)
            //        dv.Sort = (string)ViewState["SortExpr"] + " " + (string)ViewState["SortDir"];
            //}
            //if (URole == 3)
            //{
            //    dv.Table  = SearchForConsultant();
            //    if (ViewState["SortExpr"] != null)
            //        dv.Sort = (string)ViewState["SortExpr"] + " " + (string)ViewState["SortDir"];
            //}
            gdvInterview.DataSource = dv;
            gdvInterview.DataBind();
        }
        catch (Exception ex)
        {


        }
        finally
        {
            RprtBAL = null;
        }
    }
    protected void gdvInterview_Sorting(object sender, GridViewSortEventArgs e)
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
    //private void BindCandidateStatus()
    //{

    //    flwupbal = new FollowUpBAL();
      
    //    try
    //    {
    //        //ListItem li = new ListItem("All", "0");
    //        //ddlCandidateStatus.Items.Clear();
    //        //ddlCandidateStatus.Items.Add(li);
    //        ddlCandidateStatus.DataSource = flwupbal.FillCandidateStatus();
    //        ddlCandidateStatus.DataTextField = "CandidateStatus";
    //        ddlCandidateStatus.DataValueField = "CandidateStatus_Id";
    //        ddlCandidateStatus.DataBind();
    //    }
    //    finally
    //    {
    //        flwupbal = null;
    //    }
    //}
    private void BindConsultant()
    {
        loginbal = new LoginBAL();
        
        try
        {
            ListItem li = new ListItem("All", "0");
            ddlConsultantName.Items.Clear();
            ddlConsultantName.Items.Add(li);
            ddlConsultantName.DataSource = loginbal.FillUser();
            ddlConsultantName.DataTextField = "USR_Name";
            ddlConsultantName.DataValueField = "USR_ID";
            ddlConsultantName.DataBind();
        }
        finally
        {
            clientbal = null;
        }
    }
    protected void gdvInterview_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gdvInterview.PageIndex = e.NewPageIndex;
        BindGrid();
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        //if (URole == 1)
        //{
        //    dt = SearchForDirector();
        //}
        //else if (URole == 2)
        //{
        //    dt = SearchForManager();
        //}
        //if (URole == 3)
        //{
        //    dt = SearchForConsultant();
        //}
        //gdvInterview.DataSource = dt;
        //gdvInterview.DataBind();
         dt= SearchforRRcCandidate();
        gdvInterview.DataSource = dt;
        gdvInterview.DataBind();
    }

    protected DataTable SearchforRRcCandidate()
    {
        Search srch = new Search();
        string query = "", subquery = "";
        query = "SELECT distinct(r.RRCandidate_Id),rr.RRNumber,ud.USR_Name as Consultant,cd.Client_Name as Client,cad.Candidate_Name ,r.OfferDate,r.OfferPrice,r.PlannedDOJ,r.ActualDOJ,r.Overall_Status as SelectedCandidate, " +
              //   " r.RRCandidate_Id,r.Request_Id,r.Candidate_Id,r.Consultant_Id,r.Status,    " +
             //   ",r.CreatedBy,r.CreationDate,r.UpdatedBy,r.UpdationDate,r.ReferedBy,r.ShowName,r.ReferStatus  " +
            //  " ,r.Refered ,rr.Job_Profile,ud.USR_ID " +
                " rr.Client_Id" +
                "  FROM RRCandidateRelation as r " +

                " left join RecruitmentRequest as rr on  r.Request_Id=rr.Request_Id " +
                " left join UserClientRelation as uc on r.Consultant_Id =uc.Consultant_Id " +
                " left join UserDetail as ud on uc.Consultant_Id=ud.USR_ID " +
                " left join ClientDetail as cd on rr.Client_Id=cd.Client_Id " +
                " inner join  CandidateDetail as cad on  r.Candidate_Id=cad.Candidate_Id  " +
                " where  r.status=1";
        if (ddlClientName.SelectedIndex > 0)
        {
            subquery = " and rr.Client_Id= " + Convert.ToInt32(ddlClientName.SelectedValue);
        }
        if (ddlConsultantName.SelectedIndex > 0)
        {
            subquery   += " and ud.USR_ID= " + Convert.ToInt32(ddlConsultantName.SelectedValue);
        }
        //if (ddlCandidateStatus.SelectedItem.Text != "")
        //{
        //    subquery = subquery + "and r.Overall_Status = '" + ddlCandidateStatus.SelectedItem.Text + "'";
        //}
        if (txtOfferfrom.Text.Trim() != "")
        {
            if (txtOfferTo.Text.Trim() != "")
            {
                subquery = subquery + " and r.OfferDate between Cast('" + txtOfferfrom.Text.Trim() + "' as date )  and  Cast('" + txtOfferTo.Text.Trim() + "' as date ) ";
            }
            else
            {
                subquery = subquery + " and r.OfferDate between Cast('" + txtOfferfrom.Text.Trim() + "' as date )  and  cast((dateadd(mi," + MyTimeSpan + ",getdate())) as date) ) ";
            }
        }

        if (txtPlanfrom.Text.Trim() != "")
        {
            if (txtPlanto.Text.Trim() != "")
            {
                subquery = subquery + " and r.PlannedDOJ between Cast('" + txtPlanfrom.Text.Trim() + "' as date )  and  Cast('" + txtPlanto.Text.Trim() + "' as date ) ";
            }
            else
            {
                subquery = subquery + " and r.PlannedDOJ between Cast('" + txtPlanfrom.Text.Trim() + "' as date )  and  cast((dateadd(mi," + MyTimeSpan + ",getdate())) as date) ) ";
            }
        }

        if (txtActualfrom.Text.Trim() != "")
        {
            if (txtActualTo.Text.Trim() != "")
            {
                subquery = subquery + " and r.ActualDOJ between Cast('" + txtActualfrom.Text.Trim() + "' as date )  and  Cast('" + txtActualTo.Text.Trim() + "' as date ) ";
            }
            else
            {
                subquery = subquery + " and r.ActualDOJ between Cast('" + txtActualfrom.Text.Trim() + "' as date )  and  cast((dateadd(mi," + MyTimeSpan + ",getdate())) as date) ) ";
            }
        }

        if (ddlCandidateStatus.SelectedItem.Text == "All")
        {
 
            subquery = subquery + " and r.Overall_Status in ('Shortlisted','Offered','Offer Accepted','Joined','Selected not Joined','Completed 3 Months','2nd Interview Selected','Left Before 3 Months','Offered Drop Out') ";
        }
        else
        {
            subquery = subquery + "and r.Overall_Status = '" + ddlCandidateStatus.SelectedItem.Text + "'";
        }
        //query = query + " and fw.Candidate_Status in ('Shortlisted','Offered','Offer Accepted','Joined','Selected not Joined','Completed 3 Months','2nd Interview Selected','Left Before 3 Months','Offered Drop Out') ";
        query = query + subquery;
            //+ " Order by r.CreationDate desc";


        return srch.SearchRecord(query).Tables[0];
    }
    #region ----not include
    //protected DataTable SearchForDirector()
    //{
    //    Search srch = new Search();
    //    string query = "", subquery = "";
    //    query = "Select cl.Client_Id,cl.Client_Name, rq.RRNumber,rq.Designation,cd.Candidate_Name,ud.USR_Name, fw.Candidate_Status, " +
    //    "fw.FollowUp_Date,Convert(varchar,fw.CreationDate,106)   as CreationDate  " +
    //    " FRom FollowUp as fw inner join RRCandidateRelation as rr on fw.RRCandidate_Id=rr.RRCandidate_Id " +
    //    " inner join CandidateDetail as cd on rr.Candidate_Id=cd.Candidate_Id " +
    //    " inner join RecruitmentRequest as rq on  rr.Request_Id=rq.Request_Id " +
    //    " inner join CLientDetail as cl on rq.Client_Id=cl.Client_Id " +
    //    " left join UserDetail as ud on rr.Consultant_Id=ud.USR_ID ";
    //    query = query + " Where fw.Candidate_Status in ('Shortlisted','Offered','Offer Accepted','Joined','Selected not Joined') and fw.status=1 ";
    //    if (ddlClientName.SelectedIndex > 0)
    //    {
    //        subquery = " and rq.Client_Id= " + Convert.ToInt32(ddlClientName.SelectedValue);
    //    }
    //    if (txtDesigantion.Text.Trim() != "")
    //    {
    //        subquery = subquery + "and rq.Designation like '%" + txtDesigantion.Text.Trim() + "%'";
    //    }
    //    if (txtfrom.Text.Trim() != "")
    //    {
    //        if (txtTo.Text.Trim() != "")
    //        {
    //            subquery = subquery + " and fw.CreationDate between Cast('" + txtfrom.Text.Trim() + "' as date )  and  Cast('" + txtTo.Text.Trim() + "' as date ) ";
    //        }
    //        else
    //        {
    //            subquery = subquery + " and fw.CreationDate between Cast('" + txtfrom.Text.Trim() + "' as date )  and  cast((dateadd(mi," + MyTimeSpan + ",getdate())) as date) ) ";
    //        }
    //    }
       
    //    query = query + subquery + " Order by fw.CreationDate desc";


    //    return srch.SearchRecord(query).Tables[0];
    //}


    //protected DataTable SearchForManager()
    //{
    //    Search srch = new Search();
    //    string query = "", subquery = "";

    //    query = "Select cl.Client_Id,cl.Client_Name, rq.RRNumber,rq.Designation,cd.Candidate_Name,ud.USR_Name, fw.Candidate_Status, " +
    //    "fw.FollowUp_Date,Convert(varchar,fw.CreationDate,106)   as CreationDate  " +
    //    " FRom FollowUp as fw inner join RRCandidateRelation as rr on fw.RRCandidate_Id=rr.RRCandidate_Id " +
    //    " inner join CandidateDetail as cd on rr.Candidate_Id=cd.Candidate_Id " +
    //    " inner join RecruitmentRequest as rq on  rr.Request_Id=rq.Request_Id " +
    //    " inner join CLientDetail as cl on rq.Client_Id=cl.Client_Id " +
    //    " left join UserDetail as ud on rr.Consultant_Id=ud.USR_ID " +
    //    " where (rr.Consultant_Id = " + UserId + " or ud.USR_Role=3) and fw.status=1 ";
    //    if (ddlClientName.SelectedIndex > 0)
    //    {
    //        subquery = " and rq.Client_Id= " + Convert.ToInt32(ddlClientName.SelectedValue);
    //    }
    //    if (txtDesigantion.Text.Trim() != "")
    //    {
    //        subquery = subquery + "and rq.Designation like '%" + txtDesigantion.Text.Trim() + "%'";
    //    }
    //    if (txtfrom.Text.Trim() != "")
    //    {
    //        if (txtTo.Text.Trim() != "")
    //        {
    //            subquery = subquery + " and fw.CreationDate between Cast('" + txtfrom.Text.Trim() + "' as date )  and  Cast('" + txtTo.Text.Trim() + "' as date ) ";
    //        }
    //        else
    //        {
    //            subquery = subquery + " and fw.CreationDate between Cast('" + txtfrom.Text.Trim() + "' as date )  and  cast((dateadd(mi," + MyTimeSpan + ",getdate())) as date) ) ";
    //        }
    //    }


    //    query = query + " and fw.Candidate_Status in ('Shortlisted','Offered','Offer Accepted','Joined','Selected not Joined') ";
    //    query = query + subquery + " Order by fw.CreationDate desc";


    //    return srch.SearchRecord(query).Tables[0];
    //}

    //protected DataTable SearchForConsultant()
    //{
    //    Search srch = new Search();
    //    string query = "", subquery = "";
    //    query = "Select cl.Client_Id,cl.Client_Name, rq.RRNumber,rq.Designation,cd.Candidate_Name,ud.USR_Name, fw.Candidate_Status, " +
    //    "fw.FollowUp_Date,Convert(varchar,fw.CreationDate,106)   as CreationDate  " +
    //    " FRom FollowUp as fw inner join RRCandidateRelation as rr on fw.RRCandidate_Id=rr.RRCandidate_Id " +
    //    " inner join CandidateDetail as cd on rr.Candidate_Id=cd.Candidate_Id " +
    //    " inner join RecruitmentRequest as rq on  rr.Request_Id=rq.Request_Id " +
    //    " inner join CLientDetail as cl on rq.Client_Id=cl.Client_Id " +
    //    " left join UserDetail as ud on rr.Consultant_Id=ud.USR_ID " +
    //    " where rr.Consultant_Id = " + UserId + " and fw.status=1";
    //    if (ddlClientName.SelectedIndex > 0)
    //    {
    //        subquery = " and rq.Client_Id= " + Convert.ToInt32(ddlClientName.SelectedValue);
    //    }
    //    if (txtDesigantion.Text.Trim() != "")
    //    {
    //        subquery = subquery + "and rq.Designation like '%" + txtDesigantion.Text.Trim() + "%'";
    //    }
    //    if (txtfrom.Text.Trim() != "")
    //    {
    //        if (txtTo.Text.Trim() != "")
    //        {
    //            subquery = subquery + " and fw.CreationDate between Cast('" + txtfrom.Text.Trim() + "' as date )  and  Cast('" + txtTo.Text.Trim() + "' as date ) ";
    //        }
    //        else
    //        {
    //            subquery = subquery + " and fw.CreationDate between Cast('" + txtfrom.Text.Trim() + "' as date )  and  cast((dateadd(mi," + MyTimeSpan + ",getdate())) as date) ) ";
    //        }
    //    }


    //    query = query + " and fw.Candidate_Status in ('Shortlisted','Offered','Offer Accepted','Joined','Selected not Joined') ";
    //    query = query + subquery + " Order by fw.CreationDate desc";


    //    return srch.SearchRecord(query).Tables[0];
    //}
    #endregion

    #region Using VerifyRenderingInServerForm
    protected void lbtnDownload_Click(object sender, EventArgs e)
    {
        try
        {
            string fileName = "SelectedCandidates";
            //dt = (DataTable)ViewState["dtV"];

            string attachment = "attachment; filename=" + fileName + ".xls";
            Response.ClearContent();
            Response.AddHeader("content-disposition", attachment);
            Response.ContentType = "application/vnd.xls"; // ms-excel
            DataGrid dg = new DataGrid();
            //dt.Columns.Remove("Request_Id");
            //dt.Columns.Remove("Candidate_Id");
            //dt.Columns.Remove("Consultant_Id");
            //dt.Columns.Remove("Status");
            //dt.Columns.Remove("CreatedBy");
            //dt.Columns.Remove("CreationDate");
            //dt.Columns.Remove("UpdatedBy");
            //dt.Columns.Remove("UpdationDate");
            //dt.Columns.Remove("ReferedBy");
            //dt.Columns.Remove("ShowName");
            //dt.Columns.Remove("ReferStatus");
            //dt.Columns.Remove("UpdationDate");
            //dt.Columns.Remove("Job_Profile");
            //dt.Columns.Remove("Client_Id");
            //dt.Columns.Remove("USR_ID");
        //    dt.AcceptChanges();
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

      protected void gdvInterview_RowDataBound(object sender, GridViewRowEventArgs e)
      {
           if (e.Row.RowType == DataControlRowType.DataRow)
          {
              e.Row.Attributes.Add("onclick", "MouseEvents(this, event)");
              e.Row.Attributes.Add("onclick", "MouseEvents(this, event)");
              e.Row.Attributes.Add("onclick", "javascript:ChangeRowColor('" + e.Row.ClientID + "')");
          }
         
      }
}