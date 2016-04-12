using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text;
using System.Configuration;
using System.IO;

public partial class Report_ClientResumeTracker : BaseClass
{
    TodayPositionBAL toPos;
    ClientBAL clientbal;
    Search srch;
    int UserId, Role;
    int MyTimeSpan = 0;
    DataTable dt;
    protected void Page_Load(object sender, EventArgs e)
    {
        UserId = Convert.ToInt32(Session["UserId"]);
        Role = Convert.ToInt32(Session["UserRole"]);
       
        if (!IsPostBack)
        {
            BindClient();
            BindConsultant();
           // BindGrid();
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
    protected void BindConsultant()
    {
        LoginBAL loginbal = new LoginBAL();
        try
        {
            ListItem li = new ListItem("Select", "0");
            ddlConsultant.Items.Clear();
            ddlConsultant.Items.Add(li);
            if (Role == 1)
            {
                ddlConsultant.DataSource = loginbal.FillUser();
            }
            else if (Role == 9)
            {
                ddlConsultant.DataSource = loginbal.FillUser();
            }
            else if (Role == 2)
            {
                ddlConsultant.DataSource = loginbal.FillUser();
            }
            else if (Role == 3 || Role == 8)   
            {
                loginbal.Usr_Id = UserId;
                ddlConsultant.DataSource = loginbal.FillUserByUserId();
            }
            ddlConsultant.DataTextField = "USR_Name";
            ddlConsultant.DataValueField = "USR_ID";
            ddlConsultant.DataBind();



        }
        finally
        {
            loginbal = null;
        }
    }
    protected void btnSearch_OnClick(object sender, EventArgs e)
    {
        BindGrid();
    }

    protected void BindGrid()
    {
        toPos = new TodayPositionBAL();

        try
        {
            dt = getResultInDt();
            DataView dv = new DataView(dt);
            if (ViewState["SortExpr"] != null)
                dv.Sort = (string)ViewState["SortExpr"] + " " + (string)ViewState["SortDir"];
            gdvDWS.DataSource = dv;
            gdvDWS.DataBind();

        }
        catch (Exception e)
        {
        }
        finally
        {
            toPos = null;
        }
    }
    protected DataTable getResultInDt()
    {
        dt = new DataTable();
        toPos = new TodayPositionBAL();
        dt = SearchGridData();
        return dt;
    }
    protected void gdvDWS_Sorting(object sender, GridViewSortEventArgs e)
    {
        ViewState["SortExpr"] = e.SortExpression;
        if (ViewState["SortDir"] != null)
            e.SortDirection = (string)ViewState["SortDir"] == "ASC" ? SortDirection.Descending : SortDirection.Ascending;
        ViewState["SortDir"] = e.SortDirection == SortDirection.Ascending ? "ASC" : "DESC";
        BindGrid();
    }


    protected void gdvDWS_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gdvDWS.PageIndex = e.NewPageIndex;
        BindGrid();
  }
    public DataTable SearchGridData()
    {
        srch = new Search();
        StringBuilder sb = new StringBuilder();

        sb.Append("   select  cd.Candidate_Id,(select Replace(Convert(nvarchar(30),cast(GetDate() as date),106),' ','-')) as Date,cd.Source,cd.Candidate_Name as [Candidate Name],cd.Mobile_No as [Cell No] ");
                    sb.Append(" ,Rr.Client_Id,Cl.Client_Name,Ud.Usr_Name as Consultant,Cr.Consultant_Id ");
                    sb.Append(" ,cd.Email as [Email Id],cd.DOB ,cd.Key_Skills as [Primary Skill] ");
                    sb.Append(" ,cd.WorkExp as [Total Experience],cd.Annual_Salary as [Current Salary],cd.Current_Employer as [Current Company] ");
                    sb.Append(" ,cd.Current_Location as [Current Location], cd.Preferred_Location as [Preffered Location], cd.Current_Employer as [Last Organisation Name],  ");
                    sb.Append(" cd.Current_Designation as [Last Desigination], ");
                    sb.Append(" cd.Resumer_Id, cd.Address, cd.Test, cd.Resume_Title, cd.PostPG_Course as [Highest Education], cd.UG_Institute as [Insitute Name], ");
                    sb.Append(" cd.Industry as Industry ");
                    sb.Append("   from RRCandidateRelation as Cr ");
                    sb.Append(" inner join CandidateDEtail as cd on Cr.Candidate_Id=cd.Candidate_Id ");
                    sb.Append(" inner join RecruitMentRequest as Rr on Cr.Request_Id=Rr.Request_Id ");
                    sb.Append(" inner join UserDetail as ud on Cr.Consultant_Id=ud.Usr_Id ");
                    sb.Append(" inner join ClientDetail as cl on Rr.Client_Id=cl.Client_Id ");
                   sb.Append("  where Cr.Overall_Status='Share CV with Client' and Cr.Status=1   ");
       if (ddlClientName.SelectedIndex > 0)
        {
            sb.Append(" and Rr.Client_Id = " + ddlClientName.SelectedValue + "");
        }
        if (ddlConsultant.SelectedIndex > 0)
        {
            sb.Append(" and Cr.Consultant_Id = " + ddlConsultant.SelectedValue + "");
        }

        sb.Append(" order by cd.Candidate_Name Asc ");
        string query = sb.ToString();
        return srch.SearchRecord(query).Tables[0];
    }
   

    protected void lbtnDownload_Click(object sender, EventArgs e)
    {
        try
        {

            try
            {

                dt = getResultInDt();
                dt.Columns.Remove("Client_Id");
                dt.Columns.Remove("Consultant_Id");
                dt.Columns.Remove("Resumer_Id");
                dt.Columns.Remove("Address");
                dt.Columns.Remove("Test");
                dt.Columns.Remove("Resume_Title");

            }
            catch (Exception ex) { }
            finally { }

            string filename = "ClientCandidateShare(" + DateTime.Now.AddMinutes(MyTimeSpan).ToString("dd-MMM-yyyy") + ").xls";
            string attachment = "attachment; filename=" + filename;
            Response.ClearContent();
            Response.AddHeader("content-disposition", attachment);
            Response.ContentType = "application/ms-excel";
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


}
