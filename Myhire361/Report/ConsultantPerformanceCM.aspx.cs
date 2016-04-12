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

public partial class Report_ConsultantPerformanceCM : BaseClass
{
    DataTable dt = new DataTable();
    int UserId, URole;
    DataTable dtc = new DataTable();
    int MyTimeSpan = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        UserId = Convert.ToInt32(Session["UserId"]);
        URole = Convert.ToInt32(Session["UserRole"]);
        MyTimeSpan = Convert.ToInt32(ConfigurationManager.AppSettings["TimeSpan"]);
        if (!IsPostBack)
        {
            lblCurrentDate.Text = DateTime.Now.AddMinutes(MyTimeSpan).ToLongDateString();
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

                dv.Table = rprt.GetConsultantPerformanceCurrentMnth();
               if (ViewState["SortExpr"] != null)
                    dv.Sort = (string)ViewState["SortExpr"] + " " + (string)ViewState["SortDir"];
                gdvConsultantPer.DataSource = dv;
                gdvConsultantPer.DataBind();


            }
            else if (URole == 9)
            {

                dv.Table = rprt.GetConsultantPerformanceCurrentMnth();
                if (ViewState["SortExpr"] != null)
                    dv.Sort = (string)ViewState["SortExpr"] + " " + (string)ViewState["SortDir"];
                gdvConsultantPer.DataSource = dv;
                gdvConsultantPer.DataBind();


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


    protected void gdvConsultantPer_Sorting(object sender, GridViewSortEventArgs e)
    {
        ViewState["SortExpr"] = e.SortExpression;
        if (ViewState["SortDir"] != null)
            e.SortDirection = (string)ViewState["SortDir"] == "ASC" ? SortDirection.Descending : SortDirection.Ascending;
        ViewState["SortDir"] = e.SortDirection == SortDirection.Ascending ? "ASC" : "DESC";
        BindGrid();
    }
    protected void gdvConsultantPer_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gdvConsultantPer.PageIndex = e.NewPageIndex;
        BindGrid();

    }


}