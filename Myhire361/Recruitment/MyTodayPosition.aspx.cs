using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text;
public partial class Recruitment_MyTodayPosition : BaseClass
{
    DataTable dt;
    RecruitmentBAL recruitbal;
    ReportBAL rprt;
    int UserId, Role;
    Search srch;
    ClientBAL clntBAL;
    DataTable dtc = new DataTable();
    TodayPositionBAL ToPos;

    protected void Page_Load(object sender, EventArgs e)
    {
        UserId = Convert.ToInt32(Session["UserId"]);
        Role = Convert.ToInt32(Session["UserRole"]);
        if (!IsPostBack)
        {
            BindClient();
            BindGrid();
            try
            {
                Session["Rid"] = null;
                Session["Flag"] = null;
            }
            catch (Exception ex)
            {
            }
        }
    }



    protected void BindGrid()
    {
        ToPos = new TodayPositionBAL();

        try
        {
            DataView dv = new DataView();
           
                dv.Table = SearchMyTodayPosition(UserId, Role);
         
            if (ViewState["SortExpr"] == null)
            {
                ViewState["SortExpr"] = gdvRequest.Attributes["CurrentSortField"].ToString();
                ViewState["SortDir"] = gdvRequest.Attributes["CurrentSortDirection"].ToString();
            }
            dv.Sort = (string)ViewState["SortExpr"] + " " + (string)ViewState["SortDir"];
            gdvRequest.DataSource = dv;
            gdvRequest.DataBind();
        }
        catch (Exception ex)
        {
        }
        finally
        {
            dt = null;
            ToPos = null;
        }
    }

    protected void gdvRequest_Sorting(object sender, GridViewSortEventArgs e)
    {
        ViewState["SortExpr"] = e.SortExpression;
        if (ViewState["SortDir"] != null)
            e.SortDirection = (string)ViewState["SortDir"] == "ASC" ? SortDirection.Descending : SortDirection.Ascending;
        ViewState["SortDir"] = e.SortDirection == SortDirection.Ascending ? "ASC" : "DESC";
        BindGrid();
    }

    protected void gdvRequest_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gdvRequest.PageIndex = e.NewPageIndex;
        BindGrid();
    }

    protected void gdvRequest_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Edit")
        {
            GridViewRow gvr = (GridViewRow)((Control)e.CommandSource).NamingContainer;
            int Id = Convert.ToInt32(((Label)gvr.FindControl("lblId")).Text);
            string url = "NewRRequest.aspx?Id=" + Id;
            Response.Redirect(url);
        }
        else if (e.CommandName == "New")
        {
            GridViewRow gvr = (GridViewRow)((Control)e.CommandSource).NamingContainer;
            int RId = Convert.ToInt32(((Label)gvr.FindControl("lblId")).Text);
            Session["Rid"] = RId;
            string url = "CandidateForm.aspx";
            Response.Redirect(url);
        }
        else if (e.CommandName == "View")
        {
            GridViewRow gvr = (GridViewRow)((Control)e.CommandSource).NamingContainer;
            int Id = Convert.ToInt32(((Label)gvr.FindControl("lblId")).Text);
            Session["Flag"] = "1";
            string url = "ViewRRequest.aspx?Id=" + Id;
            Response.Redirect(url);

        }
        else if (e.CommandName == "Consultant")
        {
            GridViewRow gvr = (GridViewRow)((Control)e.CommandSource).NamingContainer;
            int Id = Convert.ToInt32(((Label)gvr.FindControl("lblId")).Text);
            string url = "RRConsultant.aspx?Id=" + Id;
            Response.Redirect(url);
        }
        else if (e.CommandName == "Upload")
        {
            GridViewRow gvr = (GridViewRow)((Control)e.CommandSource).NamingContainer;
            int Id = Convert.ToInt32(((Label)gvr.FindControl("lblId")).Text);
            Session["Flag"] = "1";
            string url = "UploadRRCandidate.aspx?Id=" + Id;
            Response.Redirect(url);
        }
        else if (e.CommandName == "Candidate")
        {
            GridViewRow gvr = (GridViewRow)((Control)e.CommandSource).NamingContainer;
            string Id = ((Label)gvr.FindControl("lblId")).Text;
            Session["Rid"] = Id;
            Session["BackF"] = "2";
            Response.Redirect("CandidateList.aspx");
        }
        else if (e.CommandName == "Assign")
        {
            GridViewRow gvr = (GridViewRow)((Control)e.CommandSource).NamingContainer;
            int Id = Convert.ToInt32(((Label)gvr.FindControl("lblId")).Text);
            string url = "AssignCandidate.aspx?Id=" + Id;
            Response.Redirect(url);
        }
    }

    protected void gdvRequest_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Label lbl = (Label)e.Row.FindControl("lblStatus");
            if (Convert.ToInt32(lbl.Text) == 1)
            {
                lbl.Text = "Active";
            }
            else
            {
                lbl.Text = "Inactive";
            }
        }
    }

    private void BindClient()
    {
        clntBAL = new ClientBAL();
        try
        {
            ListItem li = new ListItem("All", "0");
            ddlClientName.Items.Clear();
            ddlClientName.Items.Add(li);
            ddlClientName.DataSource = clntBAL.FillClient();
            ddlClientName.DataTextField = "Client_Name";
            ddlClientName.DataValueField = "Client_Id";
            ddlClientName.DataBind();
        }
        finally
        {
            clntBAL = null;
        }
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        recruitbal = new RecruitmentBAL();
        DataView dv = new DataView();
        try
        {
           dv.Table = SearchMyTodayPosition(UserId, Role);
            if (ViewState["SortExpr"] != null)
                dv.Sort = (string)ViewState["SortExpr"] + " " + (string)ViewState["SortDir"];
            gdvRequest.DataSource = dv;
            gdvRequest.DataBind();
        }
        catch (Exception ex)
        {

        }
        finally
        {
            recruitbal = null;
        }
    }

    public DataTable SearchMyTodayPosition(int UserId, int Role)
    {
        srch = new Search();
        StringBuilder sb = new StringBuilder();
        sb.Append("   SELECT        Rr.Request_Id, Rr.RRNumber, Rr.Job_Profile, Rr.Client_Id, Cd.Client_Name, Rr.Total_Position, Rr.Recieve_Date, Rr.Closer_Date, Rr.Criticality, Rr.Designation,   ");
        sb.Append(" Rr.Min_Salary, Rr.Max_Salary, Rr.Min_Experience, Rr.Max_Experience, Rr.Min_Qualification, Rr.Preferred_Industry, Rr.Request_Status, Rr.JobFile_Path, Rr.Status,  ");
        sb.Append("  Rr.Request_By, Ccp.Person_Name, cy.City_Name  ,Count(cnd.Candidate_Id) as Identified   FROM  RecruitmentRequest AS Rr   ");
        sb.Append(" INNER JOIN CityDetail AS cy ON Rr.Location_Id = cy.City_Id   ");
        sb.Append(" LEFT OUTER JOIN ClientDetail AS Cd ON Rr.Client_Id = Cd.Client_Id ");
        sb.Append(" LEFT OUTER JOIN ClientContactPerson AS Ccp ON Rr.Request_By = Ccp.Contact_PersonId  ");
        sb.Append(" left JOIN UserClientRelation AS Cr ON Rr.Request_Id = Cr.Request_Id   ");
        sb.Append(" left outer join CandidateDetail as cnd on Ccp.Contact_PersonId=cnd.CreatedBy   ");
        sb.Append(" WHERE  (Cr.Status = 1) AND (Rr.Status=1)  ");
        sb.Append(" AND (Rr.Request_Status='Open' OR Rr.Request_Status='Partialy Closed' OR Rr.Request_Status='Submitted') and Cr.TodayPosition=1 ");
      
         sb.Append(" and Cr.Consultant_Id='" + UserId + "'");
       
        if (ddlClientName.SelectedIndex > 0)
        {
            sb.Append(" and Cd.Client_Name = '" + ddlClientName.SelectedItem.Text + "'");
        }
        if (txtRRNumber.Text != "")
        {
            sb.Append("and Rr.RRNumber like '%" + txtRRNumber.Text + "%'");
        }
        if (txtDesignation.Text != "")
        {
            sb.Append("and Rr.Designation like '%" + txtDesignation.Text + "%'");
        }

        if (txtPosition.Text != "")
        {
            sb.Append("and Rr.Total_Position like '%" + txtPosition.Text + "%'");
        }
        if (txtLocation.Text != "")
        {
            sb.Append("and cy.City_Name like '%" + txtLocation.Text + "%'");
        }

        if (ddlRequestStatus.SelectedIndex > 0)
        {
            sb.Append(" and Rr.Request_Status = '" + ddlRequestStatus.SelectedValue + "'");
        }

        sb.Append(" group by Rr.Request_Id, Rr.RRNumber, Rr.Job_Profile, Rr.Client_Id, Cd.Client_Name, Rr.Total_Position, Rr.Recieve_Date, Rr.Closer_Date, Rr.Criticality, Rr.Designation,  ");

        sb.Append(" Rr.Min_Salary, Rr.Max_Salary, Rr.Min_Experience, Rr.Max_Experience, Rr.Min_Qualification,   ");
        sb.Append(" Rr.Preferred_Industry, Rr.Request_Status, Rr.JobFile_Path, Rr.Status, Rr.Request_By, Ccp.Person_Name, cy.City_Name  ");
        string query = sb.ToString();
        return srch.SearchRecord(query).Tables[0];
    }

   
    protected void AddColumn()
    {

        dtc.Columns.Add("Identified");
        ViewState["dtc"] = dtc;
    }
}