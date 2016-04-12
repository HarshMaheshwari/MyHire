using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text;
using System.IO;


public partial class CVSharedWithClient : BaseClass
{
    int UserId, URole;
    RecruitmentBAL recruitbal;
    FollowUpBAL FollowBal;
    Search srch;
    ClientBAL clntBAL;
   static DataTable dt = new DataTable();
    protected void Page_Load(object sender, EventArgs e)
    {
        UserId = Convert.ToInt32(Session["UserId"]);
        URole = Convert.ToInt32(Session["UserRole"]);


        if (!IsPostBack)
        {
            BindClient();
         //   BindDropdowns();
            BindGrid();
        }
    }

    //public void BindDropdowns()
    //{

    //    ListItem li = new ListItem("Select", "0");
    //    FollowBal = new FollowUpBAL();
    //    try
    //    {
    //        ddlRecStatus.Items.Clear();
    //        ddlRecStatus.Items.Add(li);
    //        ddlRecStatus.DataSource = FollowBal.FillRecruiterStatus();
    //        ddlRecStatus.DataTextField = "RecruiterStatus";
    //        ddlRecStatus.DataValueField = "RecruiterStatus_Id";
    //        ddlRecStatus.DataBind();
    //    }
    //    finally
    //    {
    //    }
    //    try
    //    {
    //        ddlSupStatus.Items.Clear();
    //        ddlSupStatus.Items.Add(li);
    //        ddlSupStatus.DataSource = FollowBal.FillApproverStatus();
    //        ddlSupStatus.DataTextField = "ApproverStatus";
    //        ddlSupStatus.DataValueField = "ApproverStatus_Id";
    //        ddlSupStatus.DataBind();
    //    }
    //    finally
    //    {
    //    }
    //    try
    //    {
    //        ddlCandStatus.Items.Clear();
    //        ddlCandStatus.Items.Add(li);
    //        ddlCandStatus.DataSource = FollowBal.FillCandidateStatus();
    //        ddlCandStatus.DataTextField = "CandidateStatus";
    //        ddlCandStatus.DataValueField = "CandidateStatus_Id";
    //        ddlCandStatus.DataBind();
    //    }
    //    finally
    //    {
    //    }

      
    //}
    private void BindGrid()
    {
        recruitbal = new RecruitmentBAL();
        DataView dv = new DataView();
        try
        {
           dt = SearchCandidate();
           dv.Table = dt;

            if (ViewState["SortExpr"] != null)
                dv.Sort = (string)ViewState["SortExpr"] + " " + (string)ViewState["SortDir"];
            gdvCandidate.DataSource = dv;
            gdvCandidate.DataBind();
        }
        finally
        {
            recruitbal = null;
        }

    }

    protected void gdvCandidate_Sorting(object sender, GridViewSortEventArgs e)
    {
        ViewState["SortExpr"] = e.SortExpression;
        if (ViewState["SortDir"] != null)
            e.SortDirection = (string)ViewState["SortDir"] == "ASC" ? SortDirection.Descending : SortDirection.Ascending;
        ViewState["SortDir"] = e.SortDirection == SortDirection.Ascending ? "ASC" : "DESC";


        BindGrid();
    }
    protected void gdvRequest_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gdvCandidate.PageIndex = e.NewPageIndex;
        BindGrid();
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        recruitbal = new RecruitmentBAL();
        try
        {
            dt = SearchCandidate();
            gdvCandidate.DataSource = dt;
            gdvCandidate.DataBind();
        }
        catch (Exception ex)
        {

        }
        finally
        {
            recruitbal = null;
        }
    }

    public DataTable SearchCandidate()
    {
        srch = new Search();
        StringBuilder sb = new StringBuilder();
        sb.Append(" Select cd.Candidate_Id,cld.Client_Name ,rr.RRNumber,rr.Job_Profile,rr.Designation,cd.Candidate_Name,cd.Email,cd.Mobile_No,fu.Recruiter_Status, ");
        sb.Append(" fu.Supervisor_Status,fu.Candidate_Status ,us.Usr_Name as Approver,usr.Usr_Name as ConsultantName ");
        
        sb.Append("  ,fu.FollowUp_Date,coalesce(nullif(fu.Candidate_Status,''),nullif(fu.Supervisor_Status,''),nullif(fu.Recruiter_Status,'')) as OverAllStatus from RRCandidateRelation as rcr inner join CandidateDetail as cd on rcr.Candidate_Id=cd.Candidate_Id");
        sb.Append(" inner join RecruitmentRequest as rr on rcr.Request_Id=rr.Request_Id inner join ClientDetail as cld on rr.Client_Id=cld.Client_Id ");
        sb.Append(" inner join FollowUp as fu on rcr.RRCandidate_Id=fu.RRCandidate_Id");

        sb.Append("	left join UserDetail as us on us.USR_ID=fu.FollowUp_By  left join UserDetail as usr on usr.USR_ID=rcr.Consultant_Id  ");
       
        sb.Append(" where fu.Status=1 and rcr.Consultant_Id=" + UserId + " and fu.Candidate_Status= 'CV Shared With Client'");
        //if (ddlRecStatus.SelectedIndex > 0)
        //{
        //    sb.Append("and fu.Recruiter_Status = '" + ddlRecStatus.SelectedItem.Text + "'");
        //}
        //if (ddlSupStatus.SelectedIndex > 0)
        //{
        //    sb.Append("and fu.Supervisor_Status = '" + ddlSupStatus.SelectedItem.Text + "'");
        //}
        //if (ddlCandStatus.SelectedIndex > 0)
        //{
        //    sb.Append("and fu.Candidate_Status = '" + ddlCandStatus.SelectedItem.Text + "'");
        //}
        //if (ddlCandStatus.SelectedIndex > 0)
        //{
        //    sb.Append("and fu.Candidate_Status = '" + ddlCandStatus.SelectedItem.Text + "'");
        //}

        if (ddlClientName.SelectedIndex  > 0)
        {
            sb.Append("and cld.Client_Name = '" + ddlClientName.SelectedItem.Text + "'");
        }
        sb.Append(" order by Client_Name");
        string query = sb.ToString();
        return srch.SearchRecord(query).Tables[0];
    }

    private void BindClient()
    {
        clntBAL = new ClientBAL();
        try
        {
            ListItem li = new ListItem("All", "0");
            ddlClientName.Items.Clear();
            ddlClientName.Items.Add(li);
            ddlClientName.DataSource = clntBAL.FillClient();
            ddlClientName.DataTextField = "Client_Name";
            ddlClientName.DataValueField = "Client_Id";
            ddlClientName.DataBind();
        }
        finally
        {
            clntBAL = null;
        }
    }

    protected void lbtnDownload_Click(object sender, EventArgs e)
    {
        SaveinExcelFile();
    }

    void SaveinExcelFile()
    {
        recruitbal = new RecruitmentBAL();
        try
        {
            string fileName = "CandidateStatus";
            //dt = (DataTable)ViewState["dtV"];
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
        catch (Exception e)
        {
        }
    }

    protected void BtnJD_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Recruiter/RecruiterDashboard.aspx");

    }
    protected void btnCandidate_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Recruiter/RCandidateList.aspx");

    }
    protected void btnFollowUpRecruiter_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Recruiter/RFollowUpList.aspx");
    }
    protected void btnCVShared_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Recruiter/CVSharedWithClient.aspx");
    }
    protected void btnInterView_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Recruiter/InterViewDone.aspx");
    }
}