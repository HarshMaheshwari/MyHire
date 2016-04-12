using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class TodayStatus : BaseClass
{
    DashboardBAL dshBAL;
    int UserId,URole;
   
    protected void Page_Load(object sender, EventArgs e)
    {
        UserId = Convert.ToInt32(Request.QueryString["UserId"]); 
        URole = Convert.ToInt32(Request.QueryString["URole"]); ;
       
        if (!IsPostBack)
        {

            BindTodayStatus();
                         
        }
    }
    





    #region  ------Today Status---------
    private void BindTodayStatus()
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
            gdvToday.DataSource = dv;
            gdvToday.DataBind();
        }
        catch (Exception ex)
        {

        }
        finally
        {
            dshBAL = null;
        }
    }

  

    protected void gdvToday_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            for (int i = 0; i < e.Row.Cells.Count; i++)
            {
                e.Row.Cells[i].Text = e.Row.Cells[i].Text.Replace(",", "<br/>");
            }
        }
    }

    protected void gdvToday_RowCreated(object sender, GridViewRowEventArgs e)
    {

       e.Row.Cells[0].Visible = false;
        //e.Row.Cells[2].Visible = false;
        //e.Row.Cells[3].Visible = false;
    }




    protected void gdvToday_Sorting(object sender, GridViewSortEventArgs e)
    {
        ViewState["SortExpr"] = e.SortExpression;
        if (ViewState["SortDir"] != null)
            e.SortDirection = (string)ViewState["SortDir"] == "ASC" ? SortDirection.Descending : SortDirection.Ascending;
        ViewState["SortDir"] = e.SortDirection == SortDirection.Ascending ? "ASC" : "DESC";
        BindTodayStatus();
    }
    #endregion




}