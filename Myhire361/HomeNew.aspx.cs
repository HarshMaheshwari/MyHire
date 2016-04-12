using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class HomeNew : BaseClass
{
    DashboardBAL dshBAL;
    int UserId,URole;
    static int CountSentForApproval;
   
  
    protected void Page_Load(object sender, EventArgs e)
    {
        UserId = Convert.ToInt32(Session["UserId"]);
        URole = Convert.ToInt32(Session["UserRole"]);
        if (!IsPostBack)
        {
            try
            {
               Session["FlagA"] = null;
            }
            catch (Exception ex)
            {
            }
            BindTodayFollowUp();           
            BindSendForApproval();
            BindTodayInterviewSchedule();
           
            BindTodayReport();

            if (URole == 1 || URole == 2 || URole == 7 || URole == 9)  // if (URole < 3)    
            {
               
                BindPendingApproval();
                Admin.Visible = true;
            }
            else
            {
                Admin.Visible = false;
                gdvFolloup.PageSize = 10;
                gdvAppSending.PageIndex = 10;
            }
        }
    }
    

    private void BindTodayReport()
    {
        dshBAL = new DashboardBAL();
        try
        {
            dshBAL.ConsultantId = UserId;
            DataTable dt = new DataTable();
            dt = dshBAL.GetTodayReport();
            lblTtlRR.Text = dt.Rows[0]["NoOfRR"].ToString();
            lblTdayIdentfied.Text = dt.Rows[0]["TotalCandidate"].ToString();
            lblTodayFollowUp.Text = dt.Rows[0]["NoOfFollwUp"].ToString();
        }
        catch (Exception ex)
        {

        }
        finally
        {
            dshBAL = null;
        }
    }

    //----Follow-Up Grid. Top Left--------//
    #region
    private void BindTodayFollowUp()
    {
        DataView dv = new DataView();

        dshBAL = new DashboardBAL();
        try
        {
            dshBAL.ConsultantId = UserId;
       //     dv.Table  = dshBAL.GetCandidateFollowDashboard();
            dv.Table = dshBAL.GetTestData();
            if (ViewState["SortExpr"] != null)
                dv.Sort = (string)ViewState["SortExpr"] + " " + (string)ViewState["SortDir"];
            gdvFolloup.DataSource = dv;
            gdvFolloup.DataBind();

           
        }
        catch (Exception ex)
        {

        }
        finally
        {
            dshBAL = null;
        }
    }

    protected void gdvFolloup_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "FollowUp")
        {
            GridViewRow gvr = (GridViewRow)((Control)e.CommandSource).NamingContainer;
            int Id = Convert.ToInt32(((Label)gvr.FindControl("lblRRId")).Text);
            string url = "~/Recruitment/FollowUp.aspx?Id=" + Id;
            Session["FlagA"] = null;
            Session["FlagA"] = "2";
            Response.Redirect(url);
        }

        if (e.CommandName == "View")
        {
            GridViewRow gvr = (GridViewRow)((Control)e.CommandSource).NamingContainer;
            int Id = Convert.ToInt32(((Label)gvr.FindControl("lblId")).Text);
            string url = "~/Recruitment/ViewCandidate.aspx?Id=" + Id;
            Session["FlagA"] = null;
            Session["FlagA"] = "2";
            Response.Redirect(url);
        }
    }

    protected void gdvFolloup_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gdvFolloup.PageIndex = e.NewPageIndex;
        BindTodayFollowUp();
    }

    protected void gdvFolloup_Sorting(object sender, GridViewSortEventArgs e)
    {
        ViewState["SortExpr"] = e.SortExpression;
        if (ViewState["SortDir"] != null)
            e.SortDirection = (string)ViewState["SortDir"] == "ASC" ? SortDirection.Descending : SortDirection.Ascending;
        ViewState["SortDir"] = e.SortDirection == SortDirection.Ascending ? "ASC" : "DESC";
        

        BindTodayFollowUp();
    }


   
    #endregion

    //----Todays Interview Grid. Top Right--------//
    #region
    private void BindTodayInterviewSchedule()
    {
        DataView dv = new DataView();
        dshBAL = new DashboardBAL();
        try
        {
            if (URole == 1)
            {
                dshBAL.ConsultantId = 0;
            }
            else
            {
                dshBAL.ConsultantId = UserId;
            }
            
            dv.Table = dshBAL.TodaysInterview();
            if (ViewState["SortExpr"] != null)
                dv.Sort = (string)ViewState["SortExpr"] + " " + (string)ViewState["SortDir"];
            gdvInterview.DataSource = dv;
            gdvInterview.DataBind();
        }
        catch (Exception ex)
        {

        }
        finally
        {
            dshBAL = null;
        }
    }

    protected void gdvInterview_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gdvInterview.PageIndex = e.NewPageIndex;
        BindTodayInterviewSchedule();
    }

    protected void gdvInterview_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        
        if (e.CommandName == "View")
        {
            GridViewRow gvr = (GridViewRow)((Control)e.CommandSource).NamingContainer;
            int Id = Convert.ToInt32(((Label)gvr.FindControl("lblId")).Text);
            string url = "~/Recruitment/ViewCandidate.aspx?Id=" + Id;
            Session["FlagA"] = "0";
            Response.Redirect(url);
        }
    }

    protected void gdvInterview_Sorting(object sender, GridViewSortEventArgs e)
    {
        ViewState["SortExpr"] = e.SortExpression;
        if (ViewState["SortDir"] != null)
            e.SortDirection = (string)ViewState["SortDir"] == "ASC" ? SortDirection.Descending : SortDirection.Ascending;
        ViewState["SortDir"] = e.SortDirection == SortDirection.Ascending ? "ASC" : "DESC";
        BindTodayInterviewSchedule();
    }
    #endregion

    //----Pending Approval Grid. Top Right--------//

    #region
    private void BindPendingApproval()
    {
        DataView dv = new DataView();
        dshBAL = new DashboardBAL();
        try
        {
            
            dshBAL.ConsultantId = UserId;
            dv.Table = dshBAL.PendingApprovalDashboard();
            if (ViewState["SortExpr"] != null)
                dv.Sort = (string)ViewState["SortExpr"] + " " + (string)ViewState["SortDir"];
            gdvPending.DataSource = dv;
            gdvPending.DataBind();
        }
        catch (Exception ex)
        {

        }
        finally
        {
            dshBAL = null;
        }
    }

    protected void gdvPending_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gdvPending.PageIndex = e.NewPageIndex;
        BindPendingApproval();
    }

    protected void gdvPending_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "FollowUp")
        {
            GridViewRow gvr = (GridViewRow)((Control)e.CommandSource).NamingContainer;
            int Id = Convert.ToInt32(((Label)gvr.FindControl("lblRRId")).Text);
            string url = "~/Recruitment/MyPostionFollowup.aspx?Id=" + Id;
            Session["FlagA"] = "0";
            Response.Redirect(url);
        }

        if (e.CommandName == "View")
        {
            GridViewRow gvr = (GridViewRow)((Control)e.CommandSource).NamingContainer;
            int Id = Convert.ToInt32(((Label)gvr.FindControl("lblId")).Text);
            string url = "~/Recruitment/ViewCandidate.aspx?Id=" + Id;
            Session["FlagA"] = "0";
            Response.Redirect(url);
        }
    }

    protected void gdvPending_Sorting(object sender, GridViewSortEventArgs e)
    {
        ViewState["SortExpr"] = e.SortExpression;
        if (ViewState["SortDir"] != null)
            e.SortDirection = (string)ViewState["SortDir"] == "ASC" ? SortDirection.Descending : SortDirection.Ascending;
        ViewState["SortDir"] = e.SortDirection == SortDirection.Ascending ? "ASC" : "DESC";
        BindPendingApproval();
    }
    #endregion


    //----Pending Approval Grid. Top Right--------//

    #region
    private void BindSendForApproval()
    {
        DataView dv = new DataView();
        dshBAL = new DashboardBAL();
        try
        {
            if (URole == 1)
            {
                dshBAL.ConsultantId = 0;
            }
            else
            {
                dshBAL.ConsultantId = UserId;
            }
            dv.Table = dshBAL.SentPendingApprovalDashBoard();

            if (ViewState["SortExpr"] != null)
                dv.Sort = (string)ViewState["SortExpr"] + " " + (string)ViewState["SortDir"];
            gdvAppSending.DataSource = dv;
            gdvAppSending.DataBind();
           // lblSentPending.Text = "No. of Candidate :" + "<b>" + CountSentForApproval + "</b>";
        }
        catch (Exception ex)
        {

        }
        finally
        {
            dshBAL = null;
        }
    }
    protected void gdvAppSending_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gdvAppSending.PageIndex = e.NewPageIndex;
        BindSendForApproval();
    }
    protected void gdvAppSending_RowCommand(object sender, GridViewCommandEventArgs e)
    {

    }
    protected void gdvAppSending_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            CountSentForApproval = CountSentForApproval + 1;
        }
    }

    protected void gdvAppSending_Sorting(object sender, GridViewSortEventArgs e)
    {
        ViewState["SortExpr"] = e.SortExpression;
        if (ViewState["SortDir"] != null)
            e.SortDirection = (string)ViewState["SortDir"] == "ASC" ? SortDirection.Descending : SortDirection.Ascending;
        ViewState["SortDir"] = e.SortDirection == SortDirection.Ascending ? "ASC" : "DESC";


        BindSendForApproval();
    }
    #endregion

   
}