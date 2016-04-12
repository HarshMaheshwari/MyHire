using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text;
public partial class Report_LoginDetails : System.Web.UI.Page
{
    Search srch;
    int USR_ID, USR_Role;
    string Username;
    LoginBAL lginbal;
    protected void Page_Load(object sender, EventArgs e)
    {
        USR_ID = Convert.ToInt32(Session["UserId"]);
        //   UserId = Convert.ToInt32(Session["UserId"]);
        if (!IsPostBack)
        {
            BindGrid();
            //LoginDetail();
        }
    }
    private void BindGrid()
    
    {
        DataView dv = new DataView();

        try
        {
            dv.Table = LoginDetail();
            if (ViewState["SortExpr"] != null)
                dv.Sort = (string)ViewState["SortExpr"] + " " + (string)ViewState["SortDir"];
            GdvLoginDetail.DataSource = dv;
            GdvLoginDetail.DataBind();
        }
        catch (Exception ex)
        {
        }
        finally
        {
        }
    }
    public DataTable LoginDetail()
    {
        srch = new Search();
        StringBuilder sb = new StringBuilder();
        sb.Append("select usr.USR_Name,t.USR_ID, t.logindate,t1.logoutDate,t.logindate,'( '+ convert(varchar, t.logindate, 106)+' )' as Date, ");
        sb.Append("'( '+Convert(varchar,t.LoginTime,108)+' )' as LginTime,");
        sb.Append(" Replace((rtrim(ltrim(Convert(varchar,(t.LoginTime),106)))),'','-') as LogInDate,");
        sb.Append(" '( '+Convert(varchar,t1.logOutTime,108)+' )' as LgOutTime");
        sb.Append(" from (( select USR_ID,min(LoginTime) as loginTime, ");
        sb.Append(" cast(loginTime as date) as logindate from LoginHistory ");
        sb.Append(" group by USR_ID,cast(loginTime as date )) as t ");
        sb.Append(" left join ( select USR_ID,max(LogoutTime) as logOutTime ,");
        sb.Append(" cast(logOutTime as date) as logoutDate from LoginHistory ");
        sb.Append(" group by USR_ID,cast(logOutTime as date )) as t1 ");
        sb.Append(" on t.USR_ID = t1.USR_ID and t.logindate = t1.logoutDate ");
        sb.Append(" inner join UserDetail as usr on t.USR_ID=usr.USR_ID )" );
        sb.Append(" where 1=1 ");
        if (txtStartDate.Text != "")
        {
            sb.Append(" and  CAST(t.LoginTime as date) >= cast('" + txtStartDate.Text + "' as date) ");
        }
        if (txtEndDate.Text != "")
        {
            sb.Append(" and CAST(t.LoginTime as date) <= cast('" + txtEndDate.Text + "' as date )");
        }
        sb.Append(" order by t.LoginTime desc ");
       

        string query = sb.ToString();
        return srch.SearchRecord(query).Tables[0];
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        BindGrid();
    }
    //protected void GdvLoginDetail_PageIndexChanging(object sender, GridViewPageEventArgs e)
    //{
    //    GdvLoginDetail.PageIndex = e.NewPageIndex;
    //    BindGrid();
    //}
    protected void GdvLoginDetail_Sorting(object sender, GridViewSortEventArgs e)
    {
        ViewState["SortExpr"] = e.SortExpression;
        if (ViewState["SortDir"] != null)
            e.SortDirection = (string)ViewState["SortDir"] == "ASC" ? SortDirection.Descending : SortDirection.Ascending;
        ViewState["SortDir"] = e.SortDirection == SortDirection.Ascending ? "ASC" : "DESC";
        BindGrid();
    }


    protected void lbdownload_Click(object sender, EventArgs e)
    {
        DataTable dt = new DataTable();
        try
        {
            dt = LoginDetail();
            // dt.Columns.Remove("Course_Id");
            string filename = "AttendanceReport.xls";
            System.IO.StringWriter tw = new System.IO.StringWriter();
            System.Web.UI.HtmlTextWriter hw = new System.Web.UI.HtmlTextWriter(tw);
            DataGrid dgGrid = new DataGrid();

            dgGrid.DataSource = dt;
            dgGrid.DataBind();
            dgGrid.RenderControl(hw);
            Response.ContentType = "application/vnd.ms-excel";
            Response.AppendHeader("Content-Disposition", "attachment; filename=" + filename + "");
            this.EnableViewState = false;
            Response.Write(tw.ToString());
            Response.End();
        }
        catch (Exception ex)
        {
        }
        finally
        {
            dt = null;
        }

    }
}