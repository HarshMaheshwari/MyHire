using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class TodayFollowUp : BaseClass
{
    DashboardBAL dshBAL;
    int UserId,URole;
    static int CountSentForApproval;
   
  
    protected void Page_Load(object sender, EventArgs e)
    {
        UserId = Convert.ToInt32(Request.QueryString["UserId"]);
        URole = Convert.ToInt32(Request.QueryString["URole"]); ;
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

  

    protected void gdvFolloup_Sorting(object sender, GridViewSortEventArgs e)
    {
        ViewState["SortExpr"] = e.SortExpression;
        if (ViewState["SortDir"] != null)
            e.SortDirection = (string)ViewState["SortDir"] == "ASC" ? SortDirection.Descending : SortDirection.Ascending;
        ViewState["SortDir"] = e.SortDirection == SortDirection.Ascending ? "ASC" : "DESC";
        

        BindTodayFollowUp();
    }


   
    #endregion

 
}