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

public partial class Report_RprtInterview : BaseClass
{
    ClientBAL clientbal;
    ReportBAL RprtBAL;
    static int count;
    static string[,] QueryArray = new string[5, 4];
    Search srch;
    static DataTable dt = new DataTable();
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

    private void BindGrid()
    {
        RprtBAL = new ReportBAL();
        DataView dv = new DataView();
        try
        {
            if (URole == 1)
            {
                dv.Table  = SearchForDirector();
                if (ViewState["SortExpr"] != null)
                    dv.Sort = (string)ViewState["SortExpr"] + " " + (string)ViewState["SortDir"];
            }
            if (URole == 9)
            {
                dv.Table = SearchForDirector();
                if (ViewState["SortExpr"] != null)
                    dv.Sort = (string)ViewState["SortExpr"] + " " + (string)ViewState["SortDir"];
            }
            else if (URole == 2 ||  URole == 7)
            {
                dv.Table  = SearchForManager();
                if (ViewState["SortExpr"] != null)
                    dv.Sort = (string)ViewState["SortExpr"] + " " + (string)ViewState["SortDir"];
            }
            if (URole == 3 || URole == 8)
            {
                dv.Table  = SearchForConsultant();
                if (ViewState["SortExpr"] != null)
                    dv.Sort = (string)ViewState["SortExpr"] + " " + (string)ViewState["SortDir"];
            }
            gdvInterview.DataSource = dv;
            gdvInterview.DataBind();
        }
        catch (Exception ex)
        {


        }
        finally
        {
            RprtBAL = null;
        }
    }


    protected void gdvInterview_Sorting(object sender, GridViewSortEventArgs e)
    {
        ViewState["SortExpr"] = e.SortExpression;
        if (ViewState["SortDir"] != null)
            e.SortDirection = (string)ViewState["SortDir"] == "ASC" ? SortDirection.Descending : SortDirection.Ascending;
        ViewState["SortDir"] = e.SortDirection == SortDirection.Ascending ? "ASC" : "DESC";
        BindGrid();
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

    protected void gdvInterview_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gdvInterview.PageIndex = e.NewPageIndex;
        BindGrid();
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        RprtBAL = new ReportBAL();
        try
        {
            count = 0;
            if (Convert.ToInt32(ddlClientName.SelectedValue) != 0)
            {
                QueryArray[count, 0] = "cd.Client_Id";
                QueryArray[count, 1] = ddlClientName.SelectedValue.ToString();
                count = count + 1;
            }
            if (txtDesigantion.Text != "")
            {
                QueryArray[count, 0] = "rr.Designation";
                QueryArray[count, 1] = txtDesigantion.Text;
                count = count + 1;
            }

            if (URole == 1)
            {
                dt = SearchForDirector();
            }
            else if (URole == 9)
            {
                dt = SearchForDirector();
            }
            else if (URole == 2 ||  URole == 7)
            {
                dt = SearchForManager();
            }
            if (URole == 3 || URole == 8)
            {
                dt = SearchForConsultant();
            }
            gdvInterview.DataSource = dt;
            gdvInterview.DataBind();
        }
        catch (Exception ex)
        {

        }
        finally
        {
            RprtBAL = null;
        }
    }
    public DataTable SearchForDirector()
    {
        srch = new Search();
        StringBuilder sb = new StringBuilder();
        sb.Append(" Select distinct(fu.RRCandidate_Id),cd.Client_Id, cd.Client_Name, rr.Request_Id, rr.Designation, Cnd.Candidate_Name, ud.USR_Name,fu.FollowUp_Date, fu.Candidate_Status");
        sb.Append(" ,cast(fu.FollowUp_Date as date) FROM ClientDetail AS cd INNER JOIN RecruitmentRequest AS rr ON cd.Client_Id = rr.Client_Id INNER JOIN");
        sb.Append(" RRCandidateRelation AS rcr ON rr.Request_Id = rcr.Request_Id INNER JOIN CandidateDetail AS Cnd ON rcr.Candidate_Id = Cnd.Candidate_Id INNER JOIN");
        sb.Append(" UserDetail AS ud ON rcr.Consultant_Id = ud.USR_ID INNER JOIN FollowUp AS fu ON rcr.RRCandidate_Id = fu.RRCandidate_Id");
        sb.Append(" Where (fu.Candidate_Status IN ('Interview Scheduled', 'Interview To Be Resheduled', '2nd Interview To Be Resheduled','Interview Done')) ");
        if (txtfrom.Text != "")
        {
            if (txtTo.Text != "")
            {
                sb.Append(" and fu.FollowUp_Date between '" + txtfrom.Text + "' and '" + txtTo.Text + "' ");
            }
            else
            {
                sb.Append(" and fu.FollowUp_Date between' " + txtfrom.Text + "' and cast((dateadd(mi,"+MyTimeSpan+",getdate())) as date)' ");
            }
        }
        
        for (int idx = 0; idx < count; idx++)
        {
            sb.Append(" and " + (QueryArray[idx, 0].ToString()) + " Like '%" + (QueryArray[idx, 1].ToString()) + "%'");
        }

        sb.Append(" ORDER BY cast(fu.FollowUp_Date as date) desc");
        string query = sb.ToString();
        return srch.SearchRecord(query).Tables[0];
    }

    public DataTable SearchForManager()
    {
        srch = new Search();
        StringBuilder sb = new StringBuilder();
        sb.Append(" Select distinct(fu.RRCandidate_Id),cd.Client_Id, cd.Client_Name, rr.Request_Id, rr.Designation, Cnd.Candidate_Name, ud.USR_Name,fu.FollowUp_Date, fu.Candidate_Status");
        sb.Append(" FROM ClientDetail AS cd INNER JOIN RecruitmentRequest AS rr ON cd.Client_Id = rr.Client_Id INNER JOIN");
        sb.Append(" RRCandidateRelation AS rcr ON rr.Request_Id = rcr.Request_Id INNER JOIN CandidateDetail AS Cnd ON rcr.Candidate_Id = Cnd.Candidate_Id INNER JOIN");
        sb.Append(" UserDetail AS ud ON rcr.Consultant_Id = ud.USR_ID INNER JOIN FollowUp AS fu ON rcr.RRCandidate_Id = fu.RRCandidate_Id");
        sb.Append(" Where (fu.Candidate_Status IN ('Interview Scheduled', 'Interview To Be Resheduled', '2nd Interview To Be Resheduled','Interview Done')) ");
        sb.Append(" and (rcr.Consultant_Id = " + UserId + " or (ud.USR_Role=3 or ud.USR_Role=8)) ");
        if (txtfrom.Text != "")
        {
            if (txtTo.Text != "")
            {
                sb.Append(" and fu.FollowUp_Date between '" + txtfrom.Text + "' and '" + txtTo.Text + "' ");
            }
            else
            {
                sb.Append(" and fu.FollowUp_Date between' " + txtfrom.Text + "' and cast((dateadd(mi," + MyTimeSpan + ",getdate())) as date)' ");
            }
        }

        for (int idx = 0; idx < count; idx++)
        {
            sb.Append(" and " + (QueryArray[idx, 0].ToString()) + " Like '%" + (QueryArray[idx, 1].ToString()) + "%'");
        }

        sb.Append(" ORDER BY cast(fu.FollowUp_Date as date) desc");
        string query = sb.ToString();
        return srch.SearchRecord(query).Tables[0];
    }

    public DataTable SearchForConsultant()
    {
        srch = new Search();
        StringBuilder sb = new StringBuilder();
        sb.Append(" Select distinct(fu.RRCandidate_Id),cd.Client_Id, cd.Client_Name, rr.Request_Id, rr.Designation, Cnd.Candidate_Name, ud.USR_Name,fu.FollowUp_Date, fu.Candidate_Status");
        sb.Append(" FROM ClientDetail AS cd INNER JOIN RecruitmentRequest AS rr ON cd.Client_Id = rr.Client_Id INNER JOIN");
        sb.Append(" RRCandidateRelation AS rcr ON rr.Request_Id = rcr.Request_Id INNER JOIN CandidateDetail AS Cnd ON rcr.Candidate_Id = Cnd.Candidate_Id INNER JOIN");
        sb.Append(" UserDetail AS ud ON rcr.Consultant_Id = ud.USR_ID INNER JOIN FollowUp AS fu ON rcr.RRCandidate_Id = fu.RRCandidate_Id");
        sb.Append(" Where (fu.Candidate_Status IN ('Interview Scheduled', 'Interview To Be Resheduled', '2nd Interview To Be Resheduled','Interview Done')) ");
        sb.Append(" and (rcr.Consultant_Id = " + UserId + ")");
        if (txtfrom.Text != "")
        {
            if (txtTo.Text != "")
            {
                sb.Append(" and fu.FollowUp_Date between '" + txtfrom.Text + "' and '" + txtTo.Text + "' ");
            }
            else
            {
                sb.Append(" and fu.FollowUp_Date between' " + txtfrom.Text + "' and cast((dateadd(mi," + MyTimeSpan + ",getdate())) as date)' ");
            }
        }

        for (int idx = 0; idx < count; idx++)
        {
            sb.Append(" and " + (QueryArray[idx, 0].ToString()) + " Like '%" + (QueryArray[idx, 1].ToString()) + "%'");
        }

        sb.Append(" ORDER BY cd.Client_Name");
        string query = sb.ToString();
        return srch.SearchRecord(query).Tables[0];
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