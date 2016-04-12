using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text;
using System.IO;

public partial class FollowUpList : BaseClass
{
    RecruitmentBAL RecBAL;
    int RequestId, UserId;
    FollowUpBAL FollowBal;
    static DataTable dts = new DataTable();
   
    protected void Page_Load(object sender, EventArgs e)
    {
        UserId = Convert.ToInt32(Session["UserId"]);
        if (!IsPostBack)
        {
            BindDropdowns();
            
            LoginBAL loginbal = new LoginBAL();
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
            ClientBAL clientbal = new ClientBAL();
            try
            {
                ListItem li = new ListItem("All", "0");
                ddlClientName.Items.Clear();
                ddlClientName.Items.Add(li);
                ddlClientName.DataSource = clientbal.FillClient();
                ddlClientName.DataTextField = "Client_Name";
                ddlClientName.DataValueField = "Client_Id";
                ddlClientName.DataBind();
              // ddlClientName.SelectedIndex = 1;
            }
            finally
            {
                clientbal = null;
            }
            BindCandidate();
        }
    }
    private void BindCandidate()
    {
        if (Convert.ToInt32(Session["UserRole"]) == 1)
        {
           DirectorSearch();
            lblCon.Visible = true;
            ddlCon.Visible = true;
        }
       
        //else if (Convert.ToInt32(Session["UserRole"]) == 2)
        else if ((Convert.ToInt32(Session["UserRole"]) == 2 || Convert.ToInt32(Session["UserRole"]) == 7))
        {
            ManagerSearch();
            
        }
       // else if (Convert.ToInt32(Session["UserRole"]) == 3)
        else if ((Convert.ToInt32(Session["UserRole"]) == 3 || Convert.ToInt32(Session["UserRole"]) == 8))
        {
            ConsultantSearch();
        }
        else if (Convert.ToInt32(Session["UserRole"]) == 9)   //Copy of Director Role for finance
        {
            DirectorSearch();
            lblCon.Visible = true;
            ddlCon.Visible = true;
        }

      
    }


    private void BindGrid(DataTable dts)
    {
        DataView dv = new DataView(dts);
        if (ViewState["SortExpr"] != null)
            dv.Sort = (string)ViewState["SortExpr"] + " " + (string)ViewState["SortDir"];
        gdvCandidate.DataSource = dv;
        gdvCandidate.DataBind();
    }
    protected void gdvCandidate_Sorting(object sender, GridViewSortEventArgs e)
    {
        ViewState["SortExpr"] = e.SortExpression;
        if (ViewState["SortDir"] != null)
            e.SortDirection = (string)ViewState["SortDir"] == "ASC" ? SortDirection.Descending : SortDirection.Ascending;
        ViewState["SortDir"] = e.SortDirection == SortDirection.Ascending ? "ASC" : "DESC";


        BindGrid(dts);
    }
    protected void gdvCandidate_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        lblmsg.Text = "";
        gdvCandidate.PageIndex = e.NewPageIndex;

        if (Convert.ToInt32(Session["UserRole"]) == 1)
        {
            DirectorSearch();
        }
        else if (Convert.ToInt32(Session["UserRole"]) == 9)
        {
            DirectorSearch();
        }
        else if ((Convert.ToInt32(Session["UserRole"]) == 2 || Convert.ToInt32(Session["UserRole"]) == 7))
        {
            ManagerSearch();
        }
        else if ((Convert.ToInt32(Session["UserRole"]) == 3 || Convert.ToInt32(Session["UserRole"]) == 8))
        {
            ConsultantSearch();
        }
    }
    protected void gdvCandidate_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "FollowUp")
        {
            GridViewRow gvr = (GridViewRow)((Control)e.CommandSource).NamingContainer;
            int IdRR = Convert.ToInt32(((Label)gvr.FindControl("lblRRId")).Text);
           // int IdRR = Convert.ToInt32(((Label)gvr.FindControl("lblRRId")).Text);
            string url = "FollowUp.aspx?Id=" + IdRR;
            Session["FlagA"] = null;
            Session["FlagA"] = "1";
            Response.Redirect(url);
        }
        if (e.CommandName == "View")
        {
            GridViewRow gvr = (GridViewRow)((Control)e.CommandSource).NamingContainer;
            int Id = Convert.ToInt32(((Label)gvr.FindControl("lblId")).Text);

            string url = "ViewCandidate.aspx?Id=" + Id;

            Session["FlagA"] = "1";
            Response.Redirect(url);
        }
        if (e.CommandName == "History")
        {
            GridViewRow gvr = (GridViewRow)((Control)e.CommandSource).NamingContainer;
            int RRCanId = Convert.ToInt32(((Label)gvr.FindControl("lblRRId")).Text);
            string url = "FollowUpHistory.aspx?Id=" + RRCanId;
            Response.Redirect(url);
        }
        if (e.CommandName == "Candidate")
        {
            GridViewRow gvr = (GridViewRow)((Control)e.CommandSource).NamingContainer;
            int Id = Convert.ToInt32(((Label)gvr.FindControl("lblId")).Text);
            string url = "CandidateAdditionalInformation.aspx?Id=" + Id;
            Response.Redirect(url);
        }
    }


    protected void btnSearch_Click(object sender, EventArgs e)
    {
        if (Convert.ToInt32(Session["UserRole"]) == 1)
        {
            DirectorSearch();
        }
        else if (Convert.ToInt32(Session["UserRole"]) == 9)
        {
            DirectorSearch();
        }
        else if ((Convert.ToInt32(Session["UserRole"]) == 2 || Convert.ToInt32(Session["UserRole"]) == 7))
        {
            ManagerSearch();
        }
        else if ((Convert.ToInt32(Session["UserRole"]) == 3 || Convert.ToInt32(Session["UserRole"]) == 8))
        {
            ConsultantSearch();
        }
    }

    public void ConsultantSearch()
    {

        string query = "";
        string Subquery = "";
        Search srch = new Search();
        try
        {
            query = "SELECT Cd.Candidate_Name, Cd.Candidate_Id, Cd.Mobile_No, Cd.Email, Cd.WorkExp,Cr.Request_Id, Cr.RRCandidate_Id, Cd.Current_Employer,Cd.Current_Designation , " +
               " Cd.Annual_Salary, Fu.Supervisor_Status, Fu.Candidate_Status, cl.Client_Name,Cr.Consultant_Id,ud.USR_Name,Fu.FollowUp_Remarks," +
               " Isnull(Fu.Recruiter_Status,'Identified') As Recruiter_Status, Fu.FollowUp_Date,Rr.RRNumber" +
               " FROM CandidateDetail AS Cd INNER JOIN RRCandidateRelation AS Cr ON Cd.Candidate_Id = Cr.Candidate_Id " +
               " inner join RecruitmentRequest As Rr on Cr.Request_Id=Rr.Request_Id inner join ClientDetail As Cl on Rr.Client_Id=cl.Client_Id " +
               " Left JOIN FollowUp As Fu ON Cr.RRCandidate_Id = Fu.RRCandidate_Id and Fu.Status in (Null,1)" +
               " Left Join UserDetail as ud on fu.FollowUp_By=ud.USR_ID" +
               "  Where Cr.Status=1 and   Fu.Status=1 and Rr.Status=1  and cr.Consultant_ID=" + UserId + "  and  (Fu.Supervisor_Status<>'Pending Approval'  or Fu.Supervisor_Status is null )" +
               "    and (Rr.Request_Status='Open' OR Rr.Request_Status='Partialy Closed')  ";
           
            if (ddlClientName.SelectedIndex > 0)
            {
                Subquery = " and Rr.Client_Id=" + Convert.ToInt32(ddlClientName.SelectedValue);
            }
            if (txtDate.Text != "")
            {
                Subquery = Subquery + " and Cast(fu.FollowUp_Date as datetime)='" + txtDate.Text + "'";
            }


            if (ddlRecStatus.SelectedIndex > 0)
            {

                Subquery = Subquery + " and  Recruiter_Status='" + ddlRecStatus.SelectedItem.Text + "'";
            }
            if (ddlSupStatus.SelectedIndex > 0)
            {

                Subquery = Subquery + " and  Fu.Supervisor_Status='" + ddlSupStatus.SelectedItem.Text + "'";
            }

            if (ddlCandStatus.SelectedIndex > 0)
            {

                Subquery = Subquery + " and  Fu.Candidate_Status='" + ddlCandStatus.SelectedItem.Text + "'";
            }

            query = query + Subquery + " Order by Cast(FollowUp_Date as date) asc";
            dts = srch.SearchRecord(query).Tables[0];
            BindGrid(dts);

        }
        catch (Exception ex)
        {

        }
        finally
        {
            srch = null;
        }

    }

    public void ManagerSearch()
    {

        string query = "";
        string Subquery = "";
        Search srch = new Search();
        try
        {
            query = "SELECT Cd.Candidate_Name, Cd.Candidate_Id, Cd.Mobile_No, Cd.Email, Cd.WorkExp,Cr.Request_Id, Cr.RRCandidate_Id,Cd.Current_Employer,Cd.Current_Designation ,  " +
              " Cd.Annual_Salary, Fu.Supervisor_Status, Fu.Candidate_Status, cl.Client_Name,Cr.Consultant_Id,ud.USR_Name,Fu.FollowUp_Remarks," +
              " Isnull(Fu.Recruiter_Status,'Identified') As Recruiter_Status, Fu.FollowUp_Date,Rr.RRNumber" +
              " FROM CandidateDetail AS Cd INNER JOIN RRCandidateRelation AS Cr ON Cd.Candidate_Id = Cr.Candidate_Id " +
              " inner join RecruitmentRequest As Rr on Cr.Request_Id=Rr.Request_Id inner join ClientDetail As Cl on Rr.Client_Id=cl.Client_Id " +
              " Left JOIN FollowUp As Fu ON Cr.RRCandidate_Id = Fu.RRCandidate_Id and Fu.Status in (Null,1)" +
              " Left Join UserDetail as ud on fu.FollowUp_By=ud.USR_ID" +
              "  Where  Cr.Status=1 and Fu.Status=1  and Rr.Status=1 and cr.Consultant_ID=" + UserId + "  and  (Fu.Supervisor_Status<>'Pending Approval'  or Fu.Supervisor_Status is null )" +
              " and (Rr.Request_Status='Open' OR Rr.Request_Status='Partialy Closed') ";
           

            if (ddlClientName.SelectedIndex > 0)
            {
                Subquery = " and Rr.Client_Id=" + Convert.ToInt32(ddlClientName.SelectedValue);
            }
           
            if (txtDate.Text != "")
            {
                Subquery = Subquery + " and Cast(FollowUp_Date as datetime)='" + txtDate.Text + "'";
            }



            if (ddlRecStatus.SelectedIndex > 0)
            {

                Subquery = Subquery + " and  Recruiter_Status='" + ddlRecStatus.SelectedItem.Text + "'";
            }
            if (ddlSupStatus.SelectedIndex > 0)
            {

                Subquery = Subquery + " and  Fu.Supervisor_Status='" + ddlSupStatus.SelectedItem.Text + "'";
            }

            if (ddlCandStatus.SelectedIndex > 0)
            {

                Subquery = Subquery + " and  Fu.Candidate_Status='" + ddlCandStatus.SelectedItem.Text + "'";
            }


            query = query + Subquery + " Order by Cast(FollowUp_Date as datetime) asc";
            dts = srch.SearchRecord(query).Tables[0];
            BindGrid(dts);

        }
        catch (Exception ex)
        {

        }
        finally
        {
            srch = null;
        }

    }

    public void DirectorSearch()
    {
        
        string query = "";
        string Subquery = "";
        Search srch = new Search();
        try
        {
            query = "SELECT Fu.FollowUp_Id, Cd.Candidate_Name, Cd.Candidate_Id, Cd.Mobile_No, Cd.Email, Cd.WorkExp,Cr.Request_Id, Cr.RRCandidate_Id, Cd.Current_Employer,Cd.Current_Designation ," +
                " Cd.Annual_Salary, Fu.Supervisor_Status, Fu.Candidate_Status,ud.USR_Name, Fu.FollowUp_Date,Fu.FollowUp_Remarks, " +
                " Isnull(Fu.Recruiter_Status,'Identified') As Recruiter_Status, Rr.RRNumber,cl.Client_Name " +
                " FROM CandidateDetail AS Cd INNER JOIN RRCandidateRelation AS Cr ON Cd.Candidate_Id = Cr.Candidate_Id " +
                " inner join RecruitmentRequest As Rr on Cr.Request_Id=Rr.Request_Id" +
                " inner join ClientDetail As Cl on Rr.Client_Id=cl.Client_Id " +
                " Left JOIN FollowUp As Fu ON Cr.RRCandidate_Id = Fu.RRCandidate_Id and Fu.Status in (Null,1)" +
                " Left Join UserDetail as ud on fu.FollowUp_By=ud.USR_ID" +
                " Where   Fu.Status=1 and Cr.Status=1 and Rr.Status=1  and  (Fu.Supervisor_Status<>'Pending Approval'  or Fu.Supervisor_Status is null) " +
                " and (Rr.Request_Status='Open' OR Rr.Request_Status='Partialy Closed') ";

            if (ddlClientName.SelectedIndex > 0)
            {
                Subquery = " and Rr.Client_Id=" + Convert.ToInt32(ddlClientName.SelectedValue);
            }
            if (ddlConsultant.SelectedIndex > 0)
            {

                Subquery = Subquery + " and  fu.FollowUp_By=" + Convert.ToInt32(ddlConsultant.SelectedValue);
            }
            if (txtDate.Text != "")
            {
                Subquery = Subquery + " and Cast(FollowUp_Date as datetime)='" + txtDate.Text + "'";
            }

            if (ddlRecStatus.SelectedIndex > 0)
            {

                Subquery = Subquery + " and  Recruiter_Status='" + ddlRecStatus.SelectedItem.Text +"'" ;
            }
            if (ddlSupStatus.SelectedIndex > 0)
            {

                Subquery = Subquery + " and  Fu.Supervisor_Status='" + ddlSupStatus.SelectedItem.Text +"'";
            }

            if (ddlCandStatus.SelectedIndex > 0)
            {

                Subquery = Subquery + " and  Fu.Candidate_Status='" + ddlCandStatus.SelectedItem.Text +"'";
            }

            query = query + Subquery + " Order by Cast(FollowUp_Date as datetime) asc";
            dts = srch.SearchRecord(query).Tables[0];
            BindGrid(dts);

        }
        catch (Exception ex)
        {

        }
        finally
        {
            srch = null;
        }
        
    }

    public void BindDropdowns()
    {

        ListItem li = new ListItem("Select", "0");
        FollowBal = new FollowUpBAL();
        try
        {
            ddlRecStatus.Items.Clear();
            ddlRecStatus.Items.Add(li);
            ddlRecStatus.DataSource = FollowBal.FillRecruiterStatus();
            ddlRecStatus.DataTextField = "RecruiterStatus";
            ddlRecStatus.DataValueField = "RecruiterStatus_Id";
            ddlRecStatus.DataBind();
        }
        finally
        {
        }
        try
        {
            ddlSupStatus.Items.Clear();
            ddlSupStatus.Items.Add(li);
            ddlSupStatus.DataSource = FollowBal.FillApproverStatus();
            ddlSupStatus.DataTextField = "ApproverStatus";
            ddlSupStatus.DataValueField = "ApproverStatus_Id";
            ddlSupStatus.DataBind();
        }
        finally
        {
        }
        try
        {
            ddlCandStatus.Items.Clear();
            ddlCandStatus.Items.Add(li);
            ddlCandStatus.DataSource = FollowBal.FillCandidateStatus();
            ddlCandStatus.DataTextField = "CandidateStatus";
            ddlCandStatus.DataValueField = "CandidateStatus_Id";
            ddlCandStatus.DataBind();
        }
        finally
        {
        }
    }

    protected void lbtnDownload_Click(object sender, EventArgs e)
    {
        SaveinExcelFile();
    }

    void SaveinExcelFile()
    {
        RecBAL = new RecruitmentBAL();
        try
        {
            string fileName = "FollowUpList";
            string attachment = "attachment; filename=" + fileName + ".xls";
            Response.ClearContent();
            Response.AddHeader("content-disposition", attachment);
            Response.ContentType = "application/vnd.xls"; // ms-excel
            DataGrid dg = new DataGrid();
            dg.DataSource = dts;
            dg.DataBind();
            StringWriter stw = new StringWriter();
            HtmlTextWriter htextw = new HtmlTextWriter(stw);
            dg.RenderControl(htextw);
            Response.Write(stw.ToString());
            Response.End();
        }
        catch (Exception e)
        {
        }
    }
}