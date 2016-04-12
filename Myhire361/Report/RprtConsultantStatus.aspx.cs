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

public partial class Report_RprtConsultantStatus : BaseClass
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
            if (URole == 3 || URole == 8) //URole == 3
            {
                Consultant.Visible = false;
                ConsultantDropdown.Visible = false;
            }
            else
            {
                Consultant.Visible = true;
                ConsultantDropdown.Visible = true;
            }
        }
    }

    protected void BindGrid()
    {
        rprtbal = new ReportBAL();
        DataView dv = new DataView();
        try
        {
            if (URole == 1)
            {
                dv.Table  = SearchForDirector();
                if (ViewState["SortExpr"] != null)
                    dv.Sort = (string)ViewState["SortExpr"] + " " + (string)ViewState["SortDir"];
                gdvConsultant.DataSource = dv;
                gdvConsultant.DataBind();
            }
            else if (URole == 9)
            {
                dv.Table = SearchForDirector();
                if (ViewState["SortExpr"] != null)
                    dv.Sort = (string)ViewState["SortExpr"] + " " + (string)ViewState["SortDir"];
                gdvConsultant.DataSource = dv;
                gdvConsultant.DataBind();
            }
            else if (URole == 2)
            {
                dv.Table  = SearchForManager();
                if (ViewState["SortExpr"] != null)
                    dv.Sort = (string)ViewState["SortExpr"] + " " + (string)ViewState["SortDir"];
                gdvConsultant.DataSource = dv;
                gdvConsultant.DataBind();
            }
            else
            {
                dv.Table  = SearchForConsultant();
                if (ViewState["SortExpr"] != null)
                    dv.Sort = (string)ViewState["SortExpr"] + " " + (string)ViewState["SortDir"];
                gdvConsultant.DataSource = dv;
                gdvConsultant.DataBind();
            }
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
                Label TotalIdentified = (Label)e.Row.FindControl("lblTotalIdentified");
                Label Task = (Label)e.Row.FindControl("lblCallsTask");
                Label Identified = (Label)e.Row.FindControl("lblIdentified");
               
                Label NotInterested = (Label)e.Row.FindControl("lblSuitableNtInt");
                Label Intersted = (Label)e.Row.FindControl("lblSuitInterst");
                Label Pending = (Label)e.Row.FindControl("lblPending");
                Label Approve = (Label)e.Row.FindControl("lblApproved");
                Label Rejected = (Label)e.Row.FindControl("lblRejected");
                Label Shared = (Label)e.Row.FindControl("lblCVShared");
                Label RejectByClient = (Label)e.Row.FindControl("lblCVRejected");
                Label InterviewSch = (Label)e.Row.FindControl("lblInterScadule");
                Label InterviewDone = (Label)e.Row.FindControl("lblInterviewDone");
                Label Selected = (Label)e.Row.FindControl("lblSelected");
                Label InterviewRejected = (Label)e.Row.FindControl("lblIntRejected");
                Label Offered = (Label)e.Row.FindControl("lblOffered");
                Label ShortList = (Label)e.Row.FindControl("lblShortList");
                Label Joined = (Label)e.Row.FindControl("lblJoined");
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
                dt = rprtbal.GetCandidateStatusByConsultant();

                int Total = Convert.ToInt32(dt.Rows[0]["TotalIdentified"].ToString());
                TotalIdentified.Text = Total.ToString();

                int TotalTask = Convert.ToInt32(dt.Rows[0]["Task"].ToString());
                Task.Text = TotalTask.ToString();

                int TIdentified = (Total - TotalTask);
                if (TIdentified >= 0)
                {
                    Identified.Text = TIdentified.ToString();
                }
                else
                {
                    Identified.Text = "0";
                }

                NotInterested.Text = dt.Rows[0]["SuitNotInt"].ToString();
                Intersted.Text = dt.Rows[0]["SuitInt"].ToString();
                Pending.Text = dt.Rows[0]["Pending"].ToString();
                Approve.Text = dt.Rows[0]["Approve"].ToString();
                Rejected.Text = dt.Rows[0]["Reject"].ToString();
                Shared.Text = dt.Rows[0]["Shared"].ToString();
                RejectByClient.Text = dt.Rows[0]["RejectByClient"].ToString();
                InterviewSch.Text = dt.Rows[0]["InterviewSch"].ToString();
                InterviewDone.Text = dt.Rows[0]["InterviewDone"].ToString();
                Selected.Text = dt.Rows[0]["Selected"].ToString();
                InterviewRejected.Text = dt.Rows[0]["InterviewRejected"].ToString();
                Offered.Text = dt.Rows[0]["Offered"].ToString();
                Joined.Text = dt.Rows[0]["Joined"].ToString();
                ShortList.Text = dt.Rows[0]["ShortList"].ToString();
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

            if (URole == 1)
            {
                dt = SearchForDirector();
                gdvConsultant.DataSource = dt;
                gdvConsultant.DataBind();
            }
            else if (URole == 2 ||  URole == 7)
            {
                dt = SearchForManager();
                gdvConsultant.DataSource = dt;
                gdvConsultant.DataBind();
            }
            else
            {
                dt = SearchForConsultant();
                gdvConsultant.DataSource = dt;
                gdvConsultant.DataBind();
            }
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
        sb.Append("  Select ud.USR_ID,ud.USR_Name,Count(ur.Request_Id) as TotalRequest");
        sb.Append(" from UserDetail as ud  ");
        sb.Append(" left join UserClientRelation as ur on ud.USR_ID=ur.Consultant_Id ");
        if (Convert.ToInt32(ddlConsultant.SelectedValue) > 0)
        {
            sb.Append(" where ud.USR_ID ='" + (ddlConsultant.SelectedValue) + "'");
        }
        sb.Append(" Group by  ud.USR_ID,ud.USR_Name ");

        string query = sb.ToString();
        return srch.SearchRecord(query).Tables[0];
    }

    public DataTable SearchForManager()
    {
        srch = new Search();
        StringBuilder sb = new StringBuilder();
        sb.Append("  Select ud.USR_ID,ud.USR_Name,Count(ur.Request_Id) as TotalRequest");
        sb.Append(" from UserDetail as ud  ");
        sb.Append(" left join UserClientRelation as ur on ud.USR_ID=ur.Consultant_Id ");

        if (Convert.ToInt32(ddlConsultant.SelectedValue) > 0)
        {
            sb.Append(" where ud.USR_ID ='" + (ddlConsultant.SelectedValue) + "'");
        }
       
        sb.Append(" and (ud.Usr_Role=3 OR ud.Usr_Role=8)");
        sb.Append(" Group by  ud.USR_ID,ud.USR_Name ");

        string query = sb.ToString();
        return srch.SearchRecord(query).Tables[0];
    }

    public DataTable SearchForConsultant()
    {
        srch = new Search();
        StringBuilder sb = new StringBuilder();
        sb.Append("  Select ud.USR_ID,ud.USR_Name,Count(ur.Request_Id) as TotalRequest");
        sb.Append(" from UserDetail as ud  ");
        sb.Append(" left join UserClientRelation as ur on ud.USR_ID=ur.Consultant_Id ");

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
                string filename = "AttendanceSheet(" + DateTime.Now.AddMinutes(MyTimeSpan).ToString("dd-MMM-yyyy") + ").xls";
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