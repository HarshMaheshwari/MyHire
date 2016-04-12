using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Report_TodayReport : BaseClass
{
    DashboardBAL dashbal;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindLoginUser();
            BindUserTask();
        }
    }

    private void BindUserTask()
    {
        LoginBAL login = new LoginBAL();
        DataView dv = new DataView();
        try
        {
            dv.Table  = login.GetUserList();
            if (ViewState["SortExpr"] != null)
                dv.Sort = (string)ViewState["SortExpr"] + " " + (string)ViewState["SortDir"];
            gdvReport.DataSource = dv;
            gdvReport.DataBind();
        }
        finally
        {
            login = null;
        }
    }

    protected void gdvReport_Sorting(object sender, GridViewSortEventArgs e)
    {
        ViewState["SortExpr"] = e.SortExpression;
        if (ViewState["SortDir"] != null)
            e.SortDirection = (string)ViewState["SortDir"] == "ASC" ? SortDirection.Descending : SortDirection.Ascending;
        ViewState["SortDir"] = e.SortDirection == SortDirection.Ascending ? "ASC" : "DESC";


        BindUserTask();
    }

    private void BindLoginUser()
    {
        LoginBAL login = new LoginBAL();
        DataView dv = new DataView();
        try
        {
            dv.Table = login.GetLoginUser();
            if (ViewState["SortExpr"] != null)
                dv.Sort = (string)ViewState["SortExpr"] + " " + (string)ViewState["SortDir"];
            gdvLoginUser.DataSource = dv;
            gdvLoginUser.DataBind();
        }
        finally
        {
            login = null;
        }
    }
    protected void gdvLoginUser_Sorting(object sender, GridViewSortEventArgs e)
    {
        ViewState["SortExpr"] = e.SortExpression;
        if (ViewState["SortDir"] != null)
            e.SortDirection = (string)ViewState["SortDir"] == "ASC" ? SortDirection.Descending : SortDirection.Ascending;
        ViewState["SortDir"] = e.SortDirection == SortDirection.Ascending ? "ASC" : "DESC";


        BindLoginUser();
    }
    protected void btnRefresh_Click(object sender, EventArgs e)
    {
        BindLoginUser();
    }
    protected void gdvReport_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        dashbal = new DashboardBAL();
        try
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Label Identified = (Label)e.Row.FindControl("lblIdentified");
                Label TotalTask = (Label)e.Row.FindControl("lblTask");
                Label id = (Label)e.Row.FindControl("lblId");
                dashbal.ConsultantId = Convert.ToInt32(id.Text);

                DataTable dt = new DataTable();
                dt = dashbal.GetTodayReport();
                Identified.Text = dt.Rows[0]["TotalCandidate"].ToString();
                TotalTask.Text = dt.Rows[0]["NoOfFollwUp"].ToString();
            }
        }
        catch
        {
        }
        finally
        {
            dashbal = null;
        }
    }
}