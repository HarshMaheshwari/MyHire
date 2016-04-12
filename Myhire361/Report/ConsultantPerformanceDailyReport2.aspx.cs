using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text;
public partial class Report_ConsultantPerformanceDailyReport2 : System.Web.UI.Page
{
    Search srch;
    int USR_ID, USR_Role, RRCandStatusReportId;
    string Username;
    LoginBAL lginbal;
    FollowUpBAL FollowBal;
    protected void Page_Load(object sender, EventArgs e)
    {
        USR_ID = Convert.ToInt32(Session["UserId"]);
        //   UserId = Convert.ToInt32(Session["UserId"]);
        if (!IsPostBack)
        {
            BindGrid();
            BindConsultant();
            BindCandidateStatus();
        }
    }
    private void BindGrid()
    {
        DataView dv = new DataView();

        try
        {
            dv.Table = Report();
            if (ViewState["SortExpr"] != null)
                dv.Sort = (string)ViewState["SortExpr"] + " " + (string)ViewState["SortDir"];
            GdvConsultantreport.DataSource = dv;
            GdvConsultantreport .DataBind();
        }
        catch (Exception ex)
        {
        }
        finally
        {
        }
    }

    protected void BindConsultant()
    {
        LoginBAL loginbal = new LoginBAL();
        try
        {
            ListItem li = new ListItem("All", "0");
            ddlConsultant.Items.Clear();
            ddlConsultant.Items.Add(li);
            loginbal.Usr_Id = USR_ID;
            ddlConsultant.DataSource = loginbal.GetConsultantNameDDL();
            ddlConsultant.DataTextField = "USR_Name";
            ddlConsultant.DataValueField = "USR_ID";
            ddlConsultant.DataBind();
        }
        finally
        {
            loginbal = null;
        }
    }
    protected void BindCandidateStatus()
    {
        FollowBal = new FollowUpBAL();
        try
        {
            ListItem li = new ListItem("All", "0");
            ddlCandidateStatus.Items.Clear();
            ddlCandidateStatus.Items.Add(li);
            ddlCandidateStatus.DataSource = FollowBal.FillCandidateStatus();
            ddlCandidateStatus.DataTextField = "CandidateStatus";
            ddlCandidateStatus.DataValueField = "CandidateStatus_Id";
            ddlCandidateStatus.DataBind();
        }
        finally
        {
            FollowBal = null;
        }
    }
   


    public DataTable Report()
    {
        srch = new Search();
        StringBuilder sb = new StringBuilder();
        sb.Append("select Distinct rrcst.Candidate_Id,rrcst.StatusDate,(rrcst.CreationDateNew) as Date ,rrcst.Candidate_Name,rrcst.Candidate_Status,(usr.USR_Name) as Consultant ,(rr.Job_Profile) as Role ,(c.Client_Name) as Client,rr.RRNumber   ");
        sb.Append(" from RRCandidateStatusReport as rrcst ");
        sb.Append(" inner   join RecruitmentRequest as rr on rr.Request_Id=rrcst.Request_Id ");
        sb.Append(" inner join ClientDetail as c on rr.Client_Id = c.Client_Id ");
        sb.Append(" inner join UserDetail as usr on rrcst.CreatedBy=usr.USR_ID  ");

        if (ddlConsultant.SelectedIndex > 0)
        {
            sb.Append("and usr.USR_Name = '" + ddlConsultant.SelectedItem.Text + "'");
            //sb.Append("and Client_Id=  + Convert.ToInt32(ddlConsultant.SelectedValue) ");
            //subquery = " and Client_Id= " + Convert.ToInt32(ddlConsultant.SelectedValue);
        }
        if (ddlCandidateStatus.SelectedIndex > 0)
        {
            sb.Append("and rrcst.Candidate_Status = '" + ddlCandidateStatus.SelectedItem.Text + "'");
        }
        if (txtStartDate.Text != "")
        {
            sb.Append(" and  rrcst.CreationDateNew >= cast('" + txtStartDate.Text + "'as date)");
        }
        if (txtEndDate.Text != "")
        {
            sb.Append(" and CAST( rrcst.CreationDateNew as date )<= cast('" + txtEndDate.Text + "'as date)");
        }

        sb.Append("  order by rrcst.CreationDateNew desc ");

        string query = sb.ToString();
        return srch.SearchRecord(query).Tables[0];
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        BindGrid();
    }
    protected void GdvConsultantreport_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GdvConsultantreport.PageIndex = e.NewPageIndex;
        BindGrid();
    }
    protected void GdvConsultantreport_Sorting(object sender, GridViewSortEventArgs e)
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
            dt = Report();
            // dt.Columns.Remove("Course_Id");
            string filename = "ConsultantPerformance.xls";
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