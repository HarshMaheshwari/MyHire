using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text;
using System.IO;

public partial class RFollowUpList : BaseClass
{
    RecruitmentBAL RecBAL;
    int RequestId, UserId;
    FollowUpBAL FollowBal;
    RecruiterBAL recruit;
    static DataTable dts = new DataTable();
   
    protected void Page_Load(object sender, EventArgs e)
    {
        UserId = Convert.ToInt32(Session["UserId"]);
        if (!IsPostBack)
        {
            BindGrid();
          

       
        }
    }



    protected void BindGrid()
    {

        recruit = new RecruiterBAL();
        DataTable dt = new DataTable();
        recruit.ConsultantId = UserId;

        dt = recruit.GetRFollowUpsList();
  
      //  dv1.Table = ConsultantSearch();
        //if (ViewState["SortExpr"] != null)
        //    dv1.Sort = (string)ViewState["SortExpr"] + " " + (string)ViewState["SortDir"];
        gdvCandidate.DataSource = dt;
        gdvCandidate.DataBind();
    }
    protected void gdvCandidate_Sorting(object sender, GridViewSortEventArgs e)
    {
        ViewState["SortExpr"] = e.SortExpression;
        if (ViewState["SortDir"] != null)
            e.SortDirection = (string)ViewState["SortDir"] == "ASC" ? SortDirection.Descending : SortDirection.Ascending;
        ViewState["SortDir"] = e.SortDirection == SortDirection.Ascending ? "ASC" : "DESC";


      
    }
    protected void gdvCandidate_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
     //   lblmsg.Text = "";
        gdvCandidate.PageIndex = e.NewPageIndex;

        BindGrid();      
         
        
    }
 


    protected void btnSearch_Click(object sender, EventArgs e)
    {


        BindGrid();
        
    }

 
    protected void lbtnDownload_Click(object sender, EventArgs e)
    {
       
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