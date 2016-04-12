using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class HomeCopy : BaseClass
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
       
            if (URole == 1 || URole == 2 || URole == 7 || URole == 9)  // if (URole < 3)    
            {

                BindTodayFollowUp();
                BindSendForApproval();
                BindTodayInterviewSchedule();
                BindMonthlyStatus();
                BindTodayReport();
                BindPendingApproval();
                Admin.Visible = true;
            }
            else
            {
                Admin.Visible = false;
                gdvFolloup.PageSize = 10;
                gdvTodayPosition.PageIndex = 10;
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
            dshBAL.User_Role = URole;
       //     dv.Table  = dshBAL.GetCandidateFollowDashboard();
            dv.Table = dshBAL.StoredProcedure1forSpecific();
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

    //----Todays Interview Grid. Top Right--------*//
    #region
    private void BindTodayInterviewSchedule()
    {
        DataView dv = new DataView();
        dshBAL = new DashboardBAL();
        try
        {
          
                dshBAL.ConsultantId = UserId;
                dshBAL.User_Role = URole;

            dv.Table = dshBAL.TodaysInterviewDashboardForTodayOnlyforSpecific();
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

    //----Pending Approval Grid. Top Right--------*//

    #region
    private void BindPendingApproval()
    {
        DataView dv = new DataView();
        dshBAL = new DashboardBAL();
        try
        {
            
            dshBAL.ConsultantId = UserId;
            dshBAL.User_Role = URole;
            dv.Table = dshBAL.TodayStatusforSpecific();
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

    protected void gdvPending_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            for (int i = 0; i < e.Row.Cells.Count; i++)
            {
                e.Row.Cells[i].Text = e.Row.Cells[i].Text.Replace(",", "<br/>");
            }
        }
    }

    protected void gdvPending_RowCreated(object sender, GridViewRowEventArgs e)
    {

       e.Row.Cells[0].Visible = false;
        //e.Row.Cells[2].Visible = false;
        //e.Row.Cells[3].Visible = false;
    }


    //protected void gdvPending_RowCommand(object sender, GridViewCommandEventArgs e)
    //{
    ////    if (e.CommandName == "FollowUp")
    ////    {
    ////        GridViewRow gvr = (GridViewRow)((Control)e.CommandSource).NamingContainer;
    ////        int Id = Convert.ToInt32(((Label)gvr.FindControl("lblRRId")).Text);
    ////        string url = "~/Recruitment/MyPostionFollowup.aspx?Id=" + Id;
    ////        Session["FlagA"] = "0";
    ////        Response.Redirect(url);
    ////    }

    ////    if (e.CommandName == "View")
    ////    {
    ////        GridViewRow gvr = (GridViewRow)((Control)e.CommandSource).NamingContainer;
    ////        int Id = Convert.ToInt32(((Label)gvr.FindControl("lblId")).Text);
    ////        string url = "~/Recruitment/ViewCandidate.aspx?Id=" + Id;
    ////        Session["FlagA"] = "0";
    ////        Response.Redirect(url);
    ////    }
    ////}

    protected void gdvPending_Sorting(object sender, GridViewSortEventArgs e)
    {
        ViewState["SortExpr"] = e.SortExpression;
        if (ViewState["SortDir"] != null)
            e.SortDirection = (string)ViewState["SortDir"] == "ASC" ? SortDirection.Descending : SortDirection.Ascending;
        ViewState["SortDir"] = e.SortDirection == SortDirection.Ascending ? "ASC" : "DESC";
        BindPendingApproval();
    }
    #endregion


    //----Pending Approval Grid. Top Right--------*//

    #region
    private void BindSendForApproval()
    {
        DataView dv = new DataView();
        dshBAL = new DashboardBAL();
        try
        {
          
                dshBAL.ConsultantId = UserId;
                dshBAL.User_Role = URole;
            dv.Table = dshBAL.TodaysInterviewDashboardForTodayOnlyforSpecific();

            if (ViewState["SortExpr"] != null)
                dv.Sort = (string)ViewState["SortExpr"] + " " + (string)ViewState["SortDir"];
            gdvTodayPosition.DataSource = dv;
            gdvTodayPosition.DataBind();
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
    protected void gdvTodayPosition_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gdvTodayPosition.PageIndex = e.NewPageIndex;
        BindSendForApproval();
    }
    protected void gdvTodayPosition_RowCommand(object sender, GridViewCommandEventArgs e)
    {

    }
    protected void gdvTodayPosition_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            CountSentForApproval = CountSentForApproval + 1;
        }
    }

    protected void gdvTodayPosition_Sorting(object sender, GridViewSortEventArgs e)
    {
        ViewState["SortExpr"] = e.SortExpression;
        if (ViewState["SortDir"] != null)
            e.SortDirection = (string)ViewState["SortDir"] == "ASC" ? SortDirection.Descending : SortDirection.Ascending;
        ViewState["SortDir"] = e.SortDirection == SortDirection.Ascending ? "ASC" : "DESC";


        BindSendForApproval();
    }
    #endregion


    //-----------------MonthlyStatus--------*//
    #region
    private void BindMonthlyStatus()
    {
        DataView dv = new DataView();
        dshBAL = new DashboardBAL();
        try
        {
            dshBAL.User_Role = URole;
            dshBAL.ConsultantId = UserId;
            dv.Table = dshBAL.MonthlyStatusforSpecific();
            if (ViewState["SortExpr"] != null)
                dv.Sort = (string)ViewState["SortExpr"] + " " + (string)ViewState["SortDir"];
            gdvPendingMDT.DataSource = dv;
            gdvPendingMDT.DataBind();
        }
        catch (Exception ex)
        {

        }
        finally
        {
            dshBAL = null;
        }
    }

    protected void gdvPendingMDT_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gdvPendingMDT.PageIndex = e.NewPageIndex;
        BindMonthlyStatus();
    }

    protected void gdvPendingMDT_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            for (int i = 0; i < e.Row.Cells.Count; i++)
            {
                e.Row.Cells[i].Text = e.Row.Cells[i].Text.Replace(",", "<br/>");
            }
        }
    }

    protected void gdvPendingMDT_RowCreated(object sender, GridViewRowEventArgs e)
    {

        e.Row.Cells[0].Visible = false;
        //e.Row.Cells[2].Visible = false;
        //e.Row.Cells[3].Visible = false;
    }



    protected void gdvPendingMDT_Sorting(object sender, GridViewSortEventArgs e)
    {
        ViewState["SortExpr"] = e.SortExpression;
        if (ViewState["SortDir"] != null)
            e.SortDirection = (string)ViewState["SortDir"] == "ASC" ? SortDirection.Descending : SortDirection.Ascending;
        ViewState["SortDir"] = e.SortDirection == SortDirection.Ascending ? "ASC" : "DESC";
        BindMonthlyStatus();
    }
    #endregion

}