using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Data;

public partial class Report_RprtConsultant : BaseClass
{
    static DataTable dt = new DataTable();
    int UserId, URole;
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
        ReportBAL rprt = new ReportBAL();
        DataView dv = new DataView();
        try
        {
            if (URole == 1)
            {
                dv.Table  = rprt.GetConsultantReport();
                if (ViewState["SortExpr"] != null)
                    dv.Sort = (string)ViewState["SortExpr"] + " " + (string)ViewState["SortDir"];
                gdvUser.DataSource = dv;
                gdvUser.DataBind();
            }
            else if (URole == 9)
            {
                dv.Table = rprt.GetConsultantReport();
                if (ViewState["SortExpr"] != null)
                    dv.Sort = (string)ViewState["SortExpr"] + " " + (string)ViewState["SortDir"];
                gdvUser.DataSource = dv;
                gdvUser.DataBind();
            }
            else if (URole == 2 ||  URole == 7)
            {
                rprt.Usr_Id = UserId;
                dv.Table  = rprt.GetConsultantReportForManager();
                if (ViewState["SortExpr"] != null)
                    dv.Sort = (string)ViewState["SortExpr"] + " " + (string)ViewState["SortDir"];
                gdvUser.DataSource = dv;
                gdvUser.DataBind();
            }
            else
            {
                rprt.Usr_Id = UserId;
                dv.Table = rprt.GetConsultantReportForConsultant();
                if (ViewState["SortExpr"] != null)
                    dv.Sort = (string)ViewState["SortExpr"] + " " + (string)ViewState["SortDir"];
                gdvUser.DataSource = dv;
                gdvUser.DataBind();
            }
        }
        catch (Exception)
        {

        }
        finally
        {
            rprt = null;
        }
    }
    protected void gdvUser_Sorting(object sender, GridViewSortEventArgs e)
    {
        ViewState["SortExpr"] = e.SortExpression;
        if (ViewState["SortDir"] != null)
            e.SortDirection = (string)ViewState["SortDir"] == "ASC" ? SortDirection.Descending : SortDirection.Ascending;
        ViewState["SortDir"] = e.SortDirection == SortDirection.Ascending ? "ASC" : "DESC";
        BindGrid();
    }
    protected void gdvUser_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gdvUser.PageIndex = e.NewPageIndex;
        BindGrid();
    }
    #region Using VerifyRenderingInServerForm
    protected void lbtnDownload_Click(object sender, EventArgs e)
    {
        try
        {
            string fileName = "ConsultantList";
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
        catch (Exception ex)
        {
        }
        finally
        { }
    }
      public override void VerifyRenderingInServerForm(Control control)
    {

    }
    #endregion
}