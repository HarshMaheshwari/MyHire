using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class TodayPosition : BaseClass
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
         

              BindTodayPosition();
          
        }
    }
    




    #region
    private void BindTodayPosition()
    {
        DataView dv = new DataView();
        dshBAL = new DashboardBAL();
        try
        {
          
                dshBAL.ConsultantId = UserId;
                dshBAL.User_Role = URole;
                dv.Table = dshBAL.TodayPositionForSpecific();

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
 

    protected void gdvTodayPosition_Sorting(object sender, GridViewSortEventArgs e)
    {
        ViewState["SortExpr"] = e.SortExpression;
        if (ViewState["SortDir"] != null)
            e.SortDirection = (string)ViewState["SortDir"] == "ASC" ? SortDirection.Descending : SortDirection.Ascending;
        ViewState["SortDir"] = e.SortDirection == SortDirection.Ascending ? "ASC" : "DESC";


        BindTodayPosition();
    }
    #endregion




}