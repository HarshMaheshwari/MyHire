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

public partial class Report_RprtClientStatus : BaseClass
{
    ReportBAL RprtBAL;
    ClientBAL clientbal;
    Search srch;
     DataTable dt = new DataTable();
     int UserId, URole;
     int MyTimeSpan = 0;

     protected void Page_Load(object sender, EventArgs e)
    {
        UserId = Convert.ToInt32(Session["UserId"]);
        URole = Convert.ToInt32(Session["UserRole"]);
        MyTimeSpan = Convert.ToInt32(ConfigurationManager.AppSettings["TimeSpan"]);
        if (!IsPostBack)
        {
            BindClient();
            BindGrid();
            
        }
    }
    private void BindClient()
    {
        clientbal = new ClientBAL();
        try
        {
            ListItem li = new ListItem("All", "0");
            ddlClientName.Items.Clear();
            ddlClientName.Items.Add(li);
            ddlClientName.DataSource = clientbal.FillClient();
            ddlClientName.DataTextField = "Client_Name";
            ddlClientName.DataValueField = "Client_Id";
            ddlClientName.DataBind();
        }
        finally
        {
            clientbal = null;
        }
    }
    protected void BindGrid()
    {
        RprtBAL = new ReportBAL();
        DataView dv = new DataView();
        try
        {
            if (URole == 1)
            {
                dv.Table  = RprtBAL.GetClientStatusReport();
                if (ViewState["SortExpr"] != null)
                    dv.Sort = (string)ViewState["SortExpr"] + " " + (string)ViewState["SortDir"];
                gdvCompany.DataSource = dv;
                gdvCompany.DataBind();
            }
            else if (URole == 9)
            {
                dv.Table = RprtBAL.GetClientStatusReport();
                if (ViewState["SortExpr"] != null)
                    dv.Sort = (string)ViewState["SortExpr"] + " " + (string)ViewState["SortDir"];
                gdvCompany.DataSource = dv;
                gdvCompany.DataBind();
            }
            else if (URole == 2 ||  URole == 7)
            {
                RprtBAL.Usr_Id = UserId;
                dv.Table  = RprtBAL.GetClientStatusReportForManager();
                if (ViewState["SortExpr"] != null)
                    dv.Sort = (string)ViewState["SortExpr"] + " " + (string)ViewState["SortDir"];
                gdvCompany.DataSource = dv;
                gdvCompany.DataBind();
            }
        }
        catch (Exception e)
        {
        }
        finally
        {
            RprtBAL = null;
        }
    }


    protected void gdvCompany_Sorting(object sender, GridViewSortEventArgs e)
    {
        ViewState["SortExpr"] = e.SortExpression;
        if (ViewState["SortDir"] != null)
            e.SortDirection = (string)ViewState["SortDir"] == "ASC" ? SortDirection.Descending : SortDirection.Ascending;
        ViewState["SortDir"] = e.SortDirection == SortDirection.Ascending ? "ASC" : "DESC";
        BindGrid();
    }
    protected void gdvCompany_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        RprtBAL = new ReportBAL();
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
                Label Joined = (Label)e.Row.FindControl("lblJoined");
                Label ShortList = (Label)e.Row.FindControl("lblShortList");
                RprtBAL.Client_Id = Convert.ToInt32(id.Text);
                dt = new DataTable();
                if ((txtFrom.Text) == "")
                {

                }
                else
                {
                    RprtBAL.FromDate =txtFrom.Text;
                }
                if ((txtTo.Text) == "")
                {

                }
                else
                {
                    RprtBAL.ToDate = txtTo.Text;
                }
                dt = RprtBAL.GetCandidateStatusByClient();
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
                ShortList.Text = dt.Rows[0]["ShortList"].ToString();
                Joined.Text = dt.Rows[0]["Joined"].ToString();
            }
        }
        catch (Exception )
        {
        }
        finally
        {
            RprtBAL = null;
        }
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        RprtBAL = new ReportBAL();
        try
        {
            dt = SearchCandidate();
            gdvCompany.DataSource = dt;
            gdvCompany.DataBind();
        }
        catch (Exception ex)
        {

        }
        finally
        {
            RprtBAL = null;
        }
    }
    public DataTable SearchCandidate()
    {
        srch = new Search();
        StringBuilder sb = new StringBuilder();
        sb.Append("  Select COunt(rr.Request_Id)as TotalRequest,cd.Client_Id, cd.Client_Name,ud.USR_Name");
        sb.Append(" From ClientDetail as cd inner join UserDetail as ud on cd.USR_ID=ud.USR_ID  ");
        sb.Append(" left join RecruitmentRequest as rr on cd.Client_Id=rr.Client_Id ");
        sb.Append(" Where cd.USR_Id>0 ");
        if (URole == 2 ||  URole == 7)
        {
            sb.Append(" and cd.USR_Id = " + UserId + "");
        }
        if (Convert.ToInt32(ddlClientName.SelectedValue) > 0)
        {
            sb.Append(" and cd.Client_Id =" + (ddlClientName.SelectedValue) + "");
        }
       
        sb.Append(" Group by cd.Client_Name,ud.USR_Name	 ,cd.Client_Id	");
        string query = sb.ToString();
        return srch.SearchRecord(query).Tables[0];
    }

    #region Using VerifyRenderingInServerForm
    protected void lbtnDownload_Click(object sender, EventArgs e)
    {
        try
        {
            if (gdvCompany.Rows.Count > 0)
            {
                string filename = "AttendanceSheet(" + DateTime.Now.AddMinutes(MyTimeSpan).ToString("dd-MMM-yyyy") + ").xls";
                string attachment = "attachment; filename=" + filename;
                Response.ClearContent();
                Response.AddHeader("content-disposition", attachment);
                Response.ContentType = "application/ms-excel";
                StringWriter stw = new StringWriter();
                HtmlTextWriter htextw = new HtmlTextWriter(stw);
                gdvCompany.RenderControl(htextw);
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