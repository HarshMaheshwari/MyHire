﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Data;
public partial class Report_RprtCompanyt : BaseClass
{
     DataTable dt = new DataTable();
     int UserId,URole;
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
                dv.Table  = rprt.GetClientReport();
                if (ViewState["SortExpr"] != null)
                    dv.Sort = (string)ViewState["SortExpr"] + " " + (string)ViewState["SortDir"];
                gdvClient.DataSource = dv;
                gdvClient.DataBind();
            }
            else if (URole == 9)
            {
                dv.Table = rprt.GetClientReport();
                if (ViewState["SortExpr"] != null)
                    dv.Sort = (string)ViewState["SortExpr"] + " " + (string)ViewState["SortDir"];
                gdvClient.DataSource = dv;
                gdvClient.DataBind();
            }
            else if (URole == 2 ||  URole == 7)
            {
                rprt.Usr_Id = UserId;
                dv.Table  = rprt.GetClientReportForManager();
                if (ViewState["SortExpr"] != null)
                    dv.Sort = (string)ViewState["SortExpr"] + " " + (string)ViewState["SortDir"];
                gdvClient.DataSource = dv;
                gdvClient.DataBind();
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
    protected void gdvClient_Sorting(object sender, GridViewSortEventArgs e)
    {
        ViewState["SortExpr"] = e.SortExpression;
        if (ViewState["SortDir"] != null)
            e.SortDirection = (string)ViewState["SortDir"] == "ASC" ? SortDirection.Descending : SortDirection.Ascending;
        ViewState["SortDir"] = e.SortDirection == SortDirection.Ascending ? "ASC" : "DESC";
      BindGrid();
    }
    protected void gdvClient_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gdvClient.PageIndex = e.NewPageIndex;
        BindGrid();

    }
    #region Using VerifyRenderingInServerForm
    protected void lbtnDownload_Click(object sender, EventArgs e)
    {
        try
        {
            string fileName = "ClientList";
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