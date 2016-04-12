using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Recruitment_FollowUpHistory : BaseClass
{
    FollowUpBAL followbal;
    int RRCandidateId;
    int followupid;

    protected void Page_Load(object sender, EventArgs e)
    {
        RRCandidateId = Convert.ToInt32(Request.QueryString["Id"]);
        if (!IsPostBack)
        {
            ViewState["PreviousPage"] = Request.UrlReferrer;
            BindGrid();
        }
    }

    protected void BindGrid()
    {
        followbal = new FollowUpBAL();
        try
        {
            followbal.RRCandidateId = RRCandidateId;
            gdvFollowup.DataSource = followbal.GetFollowUpHistory();
            gdvFollowup.DataBind();
        }
        catch{}
        finally
        {
            followbal =null;
        }
    }

    protected void BindFollowUp()
    {
         followbal = new FollowUpBAL();
         try
         {
             DataTable dt = new DataTable();
             followbal.FollowUpId = followupid;   
             dt = followbal.GetFollowUpHistoryView();
             lblType.Text = dt.Rows[0]["FollowUp_Type"].ToString();
             lblDate.Text = dt.Rows[0]["FollowUp_Date"].ToString();
             lblTime.Text = dt.Rows[0]["FollowUp_Time"].ToString();
             lblBy.Text = dt.Rows[0]["USR_Name"].ToString();
             lblRecStatus.Text = dt.Rows[0]["Recruiter_Status"].ToString();
             lblSupStatus.Text = dt.Rows[0]["Supervisor_Status"].ToString();
             lblCandStatus.Text = dt.Rows[0]["Candidate_Status"].ToString();
             lblRemark.Text = dt.Rows[0]["FollowUp_Remarks"].ToString();
         }
         catch { }
         finally
         {
             followbal = null;
         }
    }

    protected void gdvFollowup_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "View")
        {
            GridViewRow gvr = (GridViewRow)((Control)e.CommandSource).NamingContainer;
            followupid = Convert.ToInt32(((Label)gvr.FindControl("lblId")).Text);
            mpe.Show();
            BindFollowUp();
        }
    }

    protected void lbBack_Click(object sender, EventArgs e)
    {
        Response.Redirect(ViewState["PreviousPage"].ToString());  
    }
}