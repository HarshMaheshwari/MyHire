using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Candidate_CandidateHistory : BaseClass
{
    RecruitmentBAL RecrtBal;
    int CandidateId;
    protected void Page_Load(object sender, EventArgs e)
    {
        CandidateId = Convert.ToInt32(Request.QueryString["Id"]);
        if (!IsPostBack)
        {
            ViewState["PreviousPage"] = Request.UrlReferrer;
            BindGrid();
        }
    }
    protected void BindGrid()
    {
        RecrtBal = new RecruitmentBAL();
        try
        {
            RecrtBal.CandidateId = CandidateId;
            gdvHisrory.DataSource = RecrtBal.GetCandidateRRHistory();
            gdvHisrory.DataBind();
        }
        finally
        {
            RecrtBal = null;
        }
    }
    protected void gdvHisrory_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "History")
        {
            GridViewRow gvr = (GridViewRow)((Control)e.CommandSource).NamingContainer;
            int RRCanId = Convert.ToInt32(((Label)gvr.FindControl("lblRRId")).Text);
            string url = "../Recruitment/FollowUpHistory.aspx?Id=" + RRCanId;
            Response.Redirect(url);
        }
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        if (ViewState["PreviousPage"] != null)
        {
            Response.Redirect(ViewState["PreviousPage"].ToString());
        }
    }
}