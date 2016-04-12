using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text;

public partial class Recruitment_RRACandidateList : BaseClass
{

    RecruitmentBAL RecBAL;
    DataTable dt = new DataTable();
    int RequestId, UserId, count;
    static string[,] QueryArray = new string[3, 2];
    Search srch;

    protected void Page_Load(object sender, EventArgs e)
    {
        UserId = Convert.ToInt32(Session["UserId"]);
        RequestId = Convert.ToInt32(Session["Rid"]);
        if (!IsPostBack)
        {
            ViewState["PreviousPage"] = Request.UrlReferrer;
            BindHeadrDetail();
            BindAllCandidate();
        }
    }

    private void BindHeadrDetail()
    {
        try
        {
            dt = SearchCandidate();
            if (dt.Rows.Count > 0)
            {
                txtClientname.Text = dt.Rows[0]["Client_Name"].ToString();
                txtRRNo.Text = dt.Rows[0]["RRNumber"].ToString();
            }

        }
        catch (Exception ex)
        {
            lblmsg.Text = ex.Message.ToString();
        }
        finally
        {
        }
    }
    private void BindAllCandidate()
    {
        try
        {
            dt = SearchCandidate();
            DataView dv = new DataView(dt);
            dv.RowFilter = "Status='" + ddlRecordStatus.SelectedValue + "'";
            if (ViewState["SortExpr"] != null)
                dv.Sort = (string)ViewState["SortExpr"] + " " + (string)ViewState["SortDir"];

            gdvCandidate.DataSource = dv;
            gdvCandidate.DataBind();
        }
        catch (Exception ex)
        {
            lblmsg.Text = ex.Message.ToString();
        }
        finally
        {
        }
    }
    protected void lbBack_Click(object sender, EventArgs e)
    {
        if (ViewState["PreviousPage"] != null)	
        {
            Response.Redirect(ViewState["PreviousPage"].ToString());  
        }
    }
    protected void gdvCandidate_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        lblmsg.Text = "";
        gdvCandidate.PageIndex = e.NewPageIndex;
        BindAllCandidate();
    }
    protected void gdvCandidate_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "FollowUp")
        {
            GridViewRow gvr = (GridViewRow)((Control)e.CommandSource).NamingContainer;
            int IdRR = Convert.ToInt32(((Label)gvr.FindControl("lblRRId")).Text);
            int ConsltID = Convert.ToInt32(((Label)gvr.FindControl("lblConsultantId")).Text);
            string url = "FollowUp.aspx?Id=" + IdRR;
            Session["RRConsltntId"] = ConsltID;
            Session["FlagA"] = null;
            Session["FlagA"] = "1";
            Response.Redirect(url);
        }
        else if (e.CommandName == "History")
        {
            GridViewRow gvr = (GridViewRow)((Control)e.CommandSource).NamingContainer;
            int RRCanId = Convert.ToInt32(((Label)gvr.FindControl("lblRRId")).Text);
            string url = "FollowUpHistory.aspx?Id=" + RRCanId;
            Response.Redirect(url);
        }
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        RecBAL = new RecruitmentBAL();
        try
        {
            count = 0;
            if (txtName.Text != "")
            {
                QueryArray[count, 0] = "Cd.Candidate_Name";
                QueryArray[count, 1] = txtName.Text;
                count = count + 1;
            }
            if (txtMobile.Text != "")
            {
                QueryArray[count, 0] = "Cd.Mobile_No";
                QueryArray[count, 1] = txtMobile.Text;
                count = count + 1;
            }
            if (txtCtc.Text != "")
            {
                QueryArray[count, 0] = "Cd.Annual_Salary";
                QueryArray[count, 1] = txtCtc.Text;
                count = count + 1;
            }

            gdvCandidate.DataSource = SearchCandidate();
            gdvCandidate.DataBind();
        }
        catch (Exception ex)
        {

        }
        finally
        {
            RecBAL = null;
        }
    }

    public DataTable SearchCandidate()
    {
        srch = new Search();
        StringBuilder sb = new StringBuilder();
        sb.Append("Select  Cd.Candidate_Name, Cd.Candidate_Id, Cd.Mobile_No, Cd.Email, Cd.WorkExp,Cr.Request_Id, Cr.RRCandidate_Id,Cd.Annual_Salary,");
        sb.Append("  Rr.RRNumber,cl.Client_Name,Cr.Consultant_Id,cr.status");
        sb.Append(" ,Cr.Refered   ,Cr.ReferedBy  ,Cr.ShowName,cnd.Candidate_Name as ReferdByNm,Cr.Overall_Status ");
        sb.Append(" From CandidateDetail As Cd INNER JOIN RRCandidateRelation As Cr ON Cd.Candidate_Id = Cr.Candidate_Id");
        sb.Append(" inner join RecruitmentRequest As Rr on Cr.Request_Id=Rr.Request_Id");
        sb.Append(" inner join ClientDetail As Cl on Rr.Client_Id=cl.Client_Id");
        sb.Append(" left join CandidateDetail as cnd on cnd.Candidate_Id=Cr.ReferedBy   ");
        //  sb.Append(" Left JOIN FollowUp As Fu ON Cr.RRCandidate_Id = Fu.RRCandidate_Id ");   Fu.FollowUp_Date,Fu.Supervisor_Status,Fu.Candidate_Status,Isnull(Fu.Recruiter_Status,'Identified') As Recruiter_Status,
        sb.Append(" Where Cr.Request_Id=" + RequestId + " And Cr.Status= " + ddlRecordStatus.SelectedValue + "");

        for (int idx = 0; idx < count; idx++)   
        {
            sb.Append(" and " + (QueryArray[idx, 0].ToString()) + " Like '%" + (QueryArray[idx, 1].ToString()) + "%'");
        }
        sb.Append("order by Cr.Refered desc");
        string query = sb.ToString();
        return srch.SearchRecord(query).Tables[0];
    }
    protected void ddlRecordStatus_SelectedIndexChanged(object sender, EventArgs e)
    {
        txtCtc.Text = "";
        txtMobile.Text = "";
        txtName.Text = "";
        BindAllCandidate();
    }
   protected void gdvCandidate_Sorting(object sender, GridViewSortEventArgs e)
    {
        ViewState["SortExpr"] = e.SortExpression;
        if (ViewState["SortDir"] != null)
            e.SortDirection = (string)ViewState["SortDir"] == "ASC" ? SortDirection.Descending : SortDirection.Ascending;
        ViewState["SortDir"] = e.SortDirection == SortDirection.Ascending ? "ASC" : "DESC";
        BindAllCandidate();
    }
}