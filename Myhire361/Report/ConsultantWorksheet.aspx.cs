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

public partial class Report_ConsultantWorksheet : BaseClass
{
    ReportBAL rprtbal;
    LoginBAL loginbal;
    Search srch;
    int UserId, URole;
    static DataTable dt = new DataTable();
    int MyTimeSpan = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        UserId = Convert.ToInt32(Session["UserId"]);
        URole = Convert.ToInt32(Session["UserRole"]);
        MyTimeSpan = Convert.ToInt32(ConfigurationManager.AppSettings["TimeSpan"]);
        if (!IsPostBack)
        {
            BindUser();
            BindGrid();
        }
    }
    protected void BindGrid()
    {
        rprtbal = new ReportBAL();
        DataView dv = new DataView();
        try
        {
            dv.Table  = SearchForDirector();
            if (ViewState["SortExpr"] != null)
                dv.Sort = (string)ViewState["SortExpr"] + " " + (string)ViewState["SortDir"];
            gdvConsultant.DataSource = dv;
            gdvConsultant.DataBind();
        }
        catch (Exception e)
        {
        }
        finally
        {
            rprtbal = null;
        }
    }

    protected void gdvConsultant_Sorting(object sender, GridViewSortEventArgs e)
    {
        ViewState["SortExpr"] = e.SortExpression;
        if (ViewState["SortDir"] != null)
            e.SortDirection = (string)ViewState["SortDir"] == "ASC" ? SortDirection.Descending : SortDirection.Ascending;
        ViewState["SortDir"] = e.SortDirection == SortDirection.Ascending ? "ASC" : "DESC";
        BindGrid();
    }
    private void BindUser()
    {
        loginbal = new LoginBAL();
        try
        {
            ListItem li = new ListItem("All", "0");
            ddlConsultant.Items.Clear();
            ddlConsultant.Items.Add(li);
            ddlConsultant.DataSource = loginbal.FillUser();
            ddlConsultant.DataTextField = "USR_Name";
            ddlConsultant.DataValueField = "USR_ID";
            ddlConsultant.DataBind();
        }
        finally
        {
            loginbal = null;
        }
    }
    protected void gdvConsultant_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        rprtbal = new ReportBAL();
        try
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Label id = (Label)e.Row.FindControl("lblId");
                Label DayWorked = (Label)e.Row.FindControl("lblWorked");
                Label Contacted = (Label)e.Row.FindControl("lblContacted");

                Label LinedUp = (Label)e.Row.FindControl("lblInterScadule");
                Label Interviewed = (Label)e.Row.FindControl("lblInterviewDone");
                Label ShortList = (Label)e.Row.FindControl("lblShortList");
                Label Hired = (Label)e.Row.FindControl("lblOffered");
                Label Joined = (Label)e.Row.FindControl("lblJoined");
                Label Shared = (Label)e.Row.FindControl("lblCVShared");

                Label CallsDay = (Label)e.Row.FindControl("lblCalls");
                Label LineUpDay = (Label)e.Row.FindControl("lblLineUp");
                Label InterviewedDayDay = (Label)e.Row.FindControl("lblInterviewed");
                //Label ShortlistedDay = (Label)e.Row.FindControl("lblShort");
                //Label HiredDay = (Label)e.Row.FindControl("lblHired");
                //Label JoinedDay = (Label)e.Row.FindControl("lblJoin");

                Label CallsToLine = (Label)e.Row.FindControl("lblCallstoLine");
                Label LineToInterview = (Label)e.Row.FindControl("lblLineToInterview");
                Label InterviewToShort = (Label)e.Row.FindControl("lblInterviewToShort");
                Label InterToHired = (Label)e.Row.FindControl("lblInterToHired");
                Label HiredToJoined = (Label)e.Row.FindControl("lblHiredToJoined");
               
      
                rprtbal.Usr_Id = Convert.ToInt32(id.Text);
                DataTable dt = new DataTable();
                if ((txtFrom.Text) == "")
                {

                }
                else
                {
                    rprtbal.FromDate = txtFrom.Text;
                }
                if ((txtTo.Text) == "")
                {

                }
                else
                {
                    rprtbal.ToDate = txtTo.Text;
                }
                dt = rprtbal.GetConsultantWorksheet();



                DayWorked.Text = dt.Rows[0]["WorkingDays"].ToString();
                Contacted.Text = dt.Rows[0]["Contacted"].ToString();
                LinedUp.Text = dt.Rows[0]["InterviewSch"].ToString();
                Interviewed.Text = dt.Rows[0]["InterviewDone"].ToString();
                ShortList.Text = dt.Rows[0]["ShortList"].ToString();
                Hired.Text = dt.Rows[0]["Offered"].ToString();
                Joined.Text = dt.Rows[0]["Joined"].ToString();
                Shared.Text = dt.Rows[0]["Shared"].ToString();

                Double callRation= Convert.ToDouble(dt.Rows[0]["CallRatio"].ToString());
                CallsDay.Text = callRation.ToString("0.00");

                Double LinedRatio = Convert.ToDouble(dt.Rows[0]["LinedRatio"].ToString());
                LineUpDay.Text = LinedRatio.ToString("0.00");

                Double InterviewedRatio = Convert.ToDouble(dt.Rows[0]["InterviewedRatio"].ToString());
                InterviewedDayDay.Text = InterviewedRatio.ToString("0.00");

                CallsToLine.Text = dt.Rows[0]["CallsToLineUp"].ToString() + "%";
                LineToInterview.Text = dt.Rows[0]["LineUptoInterview"].ToString() + "%";
                InterviewToShort.Text = dt.Rows[0]["InterviewToShortlist"].ToString() + "%";
                InterToHired.Text = dt.Rows[0]["InterviewedToHired"].ToString() + "%";
                HiredToJoined.Text = dt.Rows[0]["HiredtoJoined"].ToString() + "%";


                
            }
        }
        catch (Exception)
        {
        }
        finally
        {
            rprtbal = null;
        }
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        rprtbal = new ReportBAL();
        try
        {
            dt = SearchForDirector();
            gdvConsultant.DataSource = dt;
            gdvConsultant.DataBind();
        }
        catch (Exception ex)
        {

        }
        finally
        {
            rprtbal = null;
        }
    }
    public DataTable SearchForDirector()
    {
        srch = new Search();
        StringBuilder sb = new StringBuilder();
        sb.Append("  Select ud.USR_ID,ud.USR_Name");
        sb.Append(" from UserDetail as ud  ");
        sb.Append(" inner join  FollowUp as fu on fu.createdby=ud.USR_ID");
        if (Convert.ToInt32(ddlConsultant.SelectedValue) > 0)
        {
            sb.Append(" where ud.USR_ID ='" + (ddlConsultant.SelectedValue) + "'");
        }
        sb.Append(" Group by  ud.USR_ID,ud.USR_Name ");

        string query = sb.ToString();
        return srch.SearchRecord(query).Tables[0];
    }

    #region Using VerifyRenderingInServerForm
    protected void lbtnDownload_Click(object sender, EventArgs e)
    {
        try
        {
            if (gdvConsultant.Rows.Count > 0)
            {
                string filename = "WorkSheet(" + DateTime.Now.AddMinutes(MyTimeSpan).ToString("dd-MMM-yyyy") + ").xls";
                string attachment = "attachment; filename=" + filename;
                Response.ClearContent();
                Response.AddHeader("content-disposition", attachment);
                Response.ContentType = "application/ms-excel";
                StringWriter stw = new StringWriter();
                HtmlTextWriter htextw = new HtmlTextWriter(stw);
                gdvConsultant.RenderControl(htextw);
                Response.Write(stw.ToString());
                Response.End();
            }
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