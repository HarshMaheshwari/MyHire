using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text;
using System.IO;
using System.Configuration;

public partial class HomeCopy : BaseClass
{
    DashboardBAL dshBAL;
    int UserId,URole;
    static int CountSentForApproval;
     static DataTable dt = new DataTable();
   
  
    protected void Page_Load(object sender, EventArgs e)
    {
        UserId = Convert.ToInt32(Session["UserId"]);
        URole = Convert.ToInt32(Session["UserRole"]);
        if (!IsPostBack)
        {
                BindMonthlyStatus();
        }
    }
    #region Using VerifyRenderingInServerForm
    protected void lbtnDownload_Click(object sender, EventArgs e)
    {
        try
        {
            string fileName = "MTD";
              DataView dv = new DataView();
             dshBAL = new DashboardBAL();
             dshBAL.User_Role = URole;
            dshBAL.ConsultantId = UserId;
           dt = dshBAL.MonthlyStatusforSpecific();
           //   dt = getcurrentdata();  
           dt.Columns.Remove("FollowUp_Id");


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
        {
            dshBAL = null;
        }
    }
    public override void VerifyRenderingInServerForm(Control control)
    {

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
            gdvMDT.DataSource = dv;
            gdvMDT.DataBind();
        }
        catch (Exception ex)
        {

        }
        finally
        {
            dshBAL = null;
        }
    }

 

    protected void gdvMDT_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            for (int i = 0; i < e.Row.Cells.Count; i++)
            {
                e.Row.Cells[i].Text = e.Row.Cells[i].Text.Replace(",", "<br/>");
            }
        }
    }

    protected void gdvMDT_RowCreated(object sender, GridViewRowEventArgs e)
    {

        e.Row.Cells[0].Visible = false;
        //e.Row.Cells[2].Visible = false;
        //e.Row.Cells[3].Visible = false;
    }



    protected void gdvMDT_Sorting(object sender, GridViewSortEventArgs e)
    {
        ViewState["SortExpr"] = e.SortExpression;
        if (ViewState["SortDir"] != null)
            e.SortDirection = (string)ViewState["SortDir"] == "ASC" ? SortDirection.Descending : SortDirection.Ascending;
        ViewState["SortDir"] = e.SortDirection == SortDirection.Ascending ? "ASC" : "DESC";
        BindMonthlyStatus();
    }
    #endregion

}