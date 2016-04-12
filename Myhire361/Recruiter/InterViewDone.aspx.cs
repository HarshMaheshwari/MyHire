using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text;
using System.IO;


public partial class InterViewDone : BaseClass
{
    int UserId, URole;
    RecruitmentBAL recruitbal;
    FollowUpBAL FollowBal;
    Search srch;
    ClientBAL clntBAL;
    RecruiterBAL recruit;
   static DataTable dt = new DataTable();
    protected void Page_Load(object sender, EventArgs e)
    {
        UserId = Convert.ToInt32(Session["UserId"]);
        URole = Convert.ToInt32(Session["UserRole"]);


        if (!IsPostBack)
        {
        
            BindGrid();
        }
    }

   
    private void BindGrid()
    {
        recruit = new RecruiterBAL();
        recruitbal = new RecruitmentBAL();
        DataView dv = new DataView();


        
        try
        {
            recruit.ConsultantId = UserId;
         //  dt = SearchCandidate();
            dv.Table = recruit.GetInterviewList();

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
    protected void btnintervdone_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Recruiter/InterViewDone.aspx");
    }
    protected void Button5_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Recruiter/SelectedCandidate.aspx");
    }
}