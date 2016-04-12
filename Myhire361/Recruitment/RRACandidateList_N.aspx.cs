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
            BindAllRRCandidate();
        }
    }

    private void BindHeadrDetail()
    {
        try
        {
            dt = SearchRRCandidate();
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

    private void BindAllRRCandidate()
    {
        try
        {
            dt = SearchRRCandidate();
            DataView dv = new DataView(dt);
            dv.RowFilter = "Status='" + ddlRecordStatus.SelectedValue + "'";
            gdvRRCandidate.DataSource = dv;
            gdvRRCandidate.DataBind();
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
    protected void gdvRRCandidate_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        lblmsg.Text = "";
        gdvRRCandidate.PageIndex = e.NewPageIndex;
        BindAllRRCandidate();
    }
    protected void gdvRRCandidate_RowCommand(object sender, GridViewCommandEventArgs e)
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
            if (txtRefered.Text != "")
            {
                QueryArray[count, 0] = "Rc.Refered";
                QueryArray[count, 1] = txtRefered.Text;
                count = count + 1;
            }
            if (txtRefBy.Text != "")
            {
                QueryArray[count, 0] = "cnd.Candidate_Name";
                QueryArray[count, 1] = txtRefBy.Text;
                count = count + 1;
            }
            if (txtShowName.Text != "")
            {
                QueryArray[count, 0] = "Rc.ShowName";
                QueryArray[count, 1] = txtShowName.Text;
                count = count + 1;
            }

            gdvRRCandidate.DataSource = SearchRRCandidate();
            gdvRRCandidate.DataBind();
        }
        catch (Exception ex)
        {

        }
        finally
        {
            RecBAL = null;
        }
    }

    public DataTable SearchRRCandidate()
    {
        srch = new Search();
        StringBuilder sb = new StringBuilder();
        sb.Append("select Rc.RRCandidate_Id ,Rc.Request_Id  ,Rc.Candidate_Id  ,Rc.Consultant_Id ,Rc.Overall_Status  ,Rc.Status  ");
        sb.Append(" ,Rc.CreatedBy ,Rc.Refered   ,Rc.ReferedBy  ,Rc.ShowName,Rr.RRNumber,cl.Client_Name ,cnd.Candidate_Name as ReferdByNm,cnd2.Candidate_Name as CandidateName  from RRCandidateRelation as Rc ");
        sb.Append(" inner join RecruitmentRequest As Rr on Rc.Request_Id=Rr.Request_Id ");
        sb.Append(" inner join ClientDetail As Cl on Rr.Client_Id=cl.Client_Id ");
        sb.Append("  inner join CandidateDetail as cnd on cnd.Candidate_Id=Rc.Candidate_Id ");
        sb.Append(" inner join CandidateDetail as cnd2 on cnd2.Candidate_Id=Rc.Candidate_Id  ");
       sb.Append(" Where Rc.Request_Id=" + RequestId + " And Rc.Status= " + ddlRecordStatus.SelectedValue + "");
       for (int idx = 0; idx < count; idx++)
        {
            sb.Append(" and " + (QueryArray[idx, 0].ToString()) + " Like '%" + (QueryArray[idx, 1].ToString()) + "%'");
        }
       sb.Append("order by Rc.Refered desc");
        string query = sb.ToString();
        return srch.SearchRecord(query).Tables[0];
    }
    protected void ddlRecordStatus_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindAllRRCandidate();
    }
    protected void gdvRRCandidate_Sorting(object sender, GridViewSortEventArgs e)
    {
        ViewState["SortExpr"] = e.SortExpression;
        if (ViewState["SortDir"] != null)
            e.SortDirection = (string)ViewState["SortDir"] == "ASC" ? SortDirection.Descending : SortDirection.Ascending;
        ViewState["SortDir"] = e.SortDirection == SortDirection.Ascending ? "ASC" : "DESC";
        BindAllRRCandidate();
    }
}