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

public partial class Report_ConsultantPerformance : BaseClass
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
        DataTable dtusr = new DataTable();
        Tempdata();
        dtc = (DataTable)ViewState["dtc"];
      
        try
        {
            if (URole == 1)
            {
               
                dtusr = rprt.GetallUser();
                if (dtusr.Rows.Count > 0)
                {
                     for (int idx = 0; idx < dtusr.Rows.Count; idx++)
                    {

                         rprt.Usr_Id = Convert.ToInt32(dtusr.Rows[idx]["USR_ID"].ToString());
                         dt = rprt.GetConsultantPerformance();
                         if (dt.Rows[0]["FollowUp_By"].ToString() != "" && dt.Rows[0]["FollowUp_By"].ToString() != "16" && dt.Rows[0]["Status"].ToString() == "1")
                         {
                             DataRow newrow = dtc.NewRow();
                             newrow["UserId"] = dt.Rows[0]["UserId"].ToString();
                             newrow["LastMonth2"] = dt.Rows[0]["LastMonth2"].ToString();
                             newrow["LastMonth1"] = dt.Rows[0]["LastMonth1"].ToString();
                             newrow["LastMonth"] = dt.Rows[0]["LastMonth"].ToString();
                             newrow["UserName"] = dt.Rows[0]["UserName"].ToString();
                             newrow["CVToday"] = dt.Rows[0]["CVToday"].ToString();
                             newrow["CVMTD"] = dt.Rows[0]["CVMTD"].ToString();
                             newrow["InterviewDoneToday"] = dt.Rows[0]["InterviewDoneToday"].ToString();
                             newrow["InterviewDoneMTD"] = dt.Rows[0]["InterviewDoneMTD"].ToString();
                             newrow["InterviewTomorrow"] = dt.Rows[0]["InterviewTomorrow"].ToString();
                             dtc.Rows.Add(newrow);
                             ViewState["dtc"] = dtc;
                         }

                     }

                    dv = new DataView(dtc);
                    if (ViewState["SortExpr"] == null)
                    {
                        ViewState["SortExpr"] = gdvConsultantPer.Attributes["CurrentSortField"].ToString();
                        ViewState["SortDir"] = gdvConsultantPer.Attributes["CurrentSortDirection"].ToString();
                    }
                    dv.Sort = (string)ViewState["SortExpr"] + " " + (string)ViewState["SortDir"];
                     gdvConsultantPer.DataSource = dv;
                     gdvConsultantPer.DataBind();
                  }
               }
           
            else
            {
                rprt.Usr_Id = UserId;
                dv.Table = rprt.GetConsultantPerformance();
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

   

    protected void Tempdata()
    {

        dtc.Columns.Add("UserId");
        dtc.Columns.Add("LastMonth2");
        dtc.Columns.Add("LastMonth1");
        dtc.Columns.Add("LastMonth");
        dtc.Columns.Add("UserName");
        dtc.Columns.Add("CVToday");
        dtc.Columns.Add("CVMTD");
        dtc.Columns.Add("InterviewDoneToday");
        dtc.Columns.Add("InterviewDoneMTD");
        dtc.Columns.Add("InterviewTomorrow");
       ViewState["dtc"] = dtc;
    }
   
}