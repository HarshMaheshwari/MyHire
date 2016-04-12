using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Recruitment_CandidateVideoList : BaseClass
{
    VideoBAL Video;
    RecruitmentBAL RecruitBal;
    SendMail mail;
    int CandidateId, RRCandidateId;
    static string CandiadteName, videoname;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (ViewState["PreviousPage"] != Request.UrlReferrer)
            {
                ViewState["PreviousPage"] = Request.UrlReferrer;
            }
            CandidateId = Convert.ToInt32(Request.QueryString["Id"].ToString());
            RRCandidateId = Convert.ToInt32(Request.QueryString["RRId"].ToString());
            BindGrid();
            BindData();
        }
    }
    protected void BindGrid()
    {
        Video = new VideoBAL();
        try
        {
            Video.Candidate_Id = CandidateId;
            gdvCandidate.DataSource = Video.GetVideoByCandidateId();
            gdvCandidate.DataBind();
        }
        finally
        {
            Video = null;
        }
    }

    protected void BindData()
    {
        RecruitBal = new RecruitmentBAL();
        DataTable dt = new DataTable();
        try
        {
            if (RRCandidateId == 0)
            {
                RecruitBal.CandidateId = CandidateId;
                dt = RecruitBal.GetCandidateById();
                lblCandidate.Text = dt.Rows[0]["Candidate_Name"].ToString();
                tdRRNo.Visible = false;
                tdClient.Visible = false;
                tdDesg.Visible = false;
            }
            else
            {
                RecruitBal.RRCandidate_Id = RRCandidateId;
                dt = RecruitBal.GetCandidateDetailForLabel();
                lblRRnumber.Text = dt.Rows[0]["RRNumber"].ToString();
                lblClient.Text = dt.Rows[0]["Client_Name"].ToString();
                lblDesignation.Text = dt.Rows[0]["Designation"].ToString();
                lblCandidate.Text = dt.Rows[0]["Candidate_Name"].ToString();
                tdRRNo.Visible = true;
                tdClient.Visible = true;
                tdDesg.Visible = true;
            }
        }
        finally
        {
            dt = null;
            RecruitBal = null;
        }
    }
    protected void gdvCandidate_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gdvCandidate.PageIndex = e.NewPageIndex;
        BindGrid();
    }
    protected void gdvCandidate_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "ViewVideo")
        {
            GridViewRow gvr = (GridViewRow)((Control)e.CommandSource).NamingContainer;
            videoname = (((Label)gvr.FindControl("lblVideo")).Text);
            string url = "PlayCandidateVideo.aspx?videoname=" + videoname;
            Response.Redirect(url);
        }
        else if (e.CommandName == "Video")
        {
            GridViewRow gvr = (GridViewRow)((Control)e.CommandSource).NamingContainer;
            int Id = Convert.ToInt32(((Label)gvr.FindControl("lblId")).Text);
            CandiadteName = (((Label)gvr.FindControl("lblCandidate")).Text);
            videoname = (((Label)gvr.FindControl("lblVideo")).Text);
            mpe.Show();
        }
    }
    protected void btnSend_Click(object sender, EventArgs e)
    {
        mail = new SendMail();
        mail.SendVideoLinkToClient(CandiadteName, txtEmail.Text, videoname);
        mpe.Hide();
        Page.ClientScript.RegisterStartupScript(this.Page.GetType(), "Alert", "alert('Link has been Successfully sent to Client.');", true);
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        if (ViewState["PreviousPage"] != null)
        {
            Response.Redirect(ViewState["PreviousPage"].ToString());
        }
    }
}