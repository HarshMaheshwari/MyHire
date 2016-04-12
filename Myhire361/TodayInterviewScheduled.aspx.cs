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


            BindTodayInterviewSchedule();
        }
    }
    


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


}