using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text;

public partial class Recruitment_AllCandidates : BaseClass
{
    RecruitmentBAL RecBAL;
    SendMail mail;
    LoginBAL UsrBal;
    static int RequestId, UserId;
     int count;
    string[,] QueryArray = new string[3, 2];
    Search srch;

    protected void Page_Load(object sender, EventArgs e)
    {
       
            try
            {
                UserId = Convert.ToInt32(Session["UserId"]);
                RequestId = Convert.ToInt32(Session["Rid"]);
            }
            catch (Exception ex)
            {
            }
            if (!IsPostBack)
            {
                BindCandidate();
            }
          
     
    }

    private void BindCandidate()
    {
        RecBAL = new RecruitmentBAL();
        try
        {
            DataView dv = new DataView();
            dv.Table = SearchCandidate();
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
            RecBAL = null;
        }
    }


    protected void gdvCandidate_Sorting(object sender, GridViewSortEventArgs e)
    {
        ViewState["SortExpr"] = e.SortExpression;
        if (ViewState["SortDir"] != null)
            e.SortDirection = (string)ViewState["SortDir"] == "ASC" ? SortDirection.Descending : SortDirection.Ascending;
        ViewState["SortDir"] = e.SortDirection == SortDirection.Ascending ? "ASC" : "DESC";


        BindCandidate();
    }
    protected void gdvCandidate_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        lblmsg.Text = "";
        gdvCandidate.PageIndex = e.NewPageIndex;
        BindCandidate();
    }

    protected void gdvCandidate_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "View")
        {
            GridViewRow gvr = (GridViewRow)((Control)e.CommandSource).NamingContainer;
            int Id = Convert.ToInt32(((Label)gvr.FindControl("lblId")).Text);
            string url = "ViewCandidate.aspx?Id=" + Id;
            Response.Redirect(url);
        }
        else if (e.CommandName == "Edit")
        {
            GridViewRow gvr = (GridViewRow)((Control)e.CommandSource).NamingContainer;
            int Id = Convert.ToInt32(((Label)gvr.FindControl("lblId")).Text);
            string url = "EditCandidate.aspx?Id=" + Id;
            Response.Redirect(url);
        }
        else if (e.CommandName == "History")
        {
            GridViewRow gvr = (GridViewRow)((Control)e.CommandSource).NamingContainer;
            int Id = Convert.ToInt32(((Label)gvr.FindControl("lblId")).Text);
            string url = "CandidateHistory.aspx?Id=" + Id;
            Response.Redirect(url);
        }
        else if (e.CommandName == "Video")
        {
            GridViewRow gvr = (GridViewRow)((Control)e.CommandSource).NamingContainer;
            int Id = Convert.ToInt32(((Label)gvr.FindControl("lblId")).Text);
            RecBAL = new RecruitmentBAL();
            UsrBal = new LoginBAL();
            mail = new SendMail();
            try
            {
                DataTable dt = new DataTable();
                RecBAL.CandidateId = Id;
                dt = RecBAL.GetCandidateById();
                if (dt.Rows.Count > 0)
                {
                    string CandidateEmail = dt.Rows[0]["Email"].ToString();
                    string CandidateName = dt.Rows[0]["Candidate_Name"].ToString();
                    DataTable dtu = new DataTable();
                    UsrBal.Usr_Id = UserId;
                    dtu = UsrBal.GetUserDetailById();
                    if (dtu.Rows.Count > 0)
                    {
                        string ConsultantEmail = dtu.Rows[0]["USR_Email"].ToString();
                        int RRCandidateId = 0;
                        mail.SendVideoLink(CandidateName, CandidateEmail, ConsultantEmail, Id, RRCandidateId, "shv_" + Id + "_");
                        Page.ClientScript.RegisterStartupScript(this.Page.GetType(), "Alert", "alert('Link has been Successfully sent to Candidate.');", true);
                    }
                }
            }
            catch
            {
            }
            finally
            {
                mail = null;
                UsrBal = null;
                RecBAL = null;
            }
        }
        else if (e.CommandName == "ViewVideo")
        {
            GridViewRow gvr = (GridViewRow)((Control)e.CommandSource).NamingContainer;
            int Id = Convert.ToInt32(((Label)gvr.FindControl("lblId")).Text);
            string url = "~/Recruitment/CandidateVideoList.aspx?Id=" + Id + "&RRId=0";
            Response.Redirect(url);
        }
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
       
         //gdvCandidate.DataSource = SearchCandidate();
         //gdvCandidate.DataBind();
        BindCandidate();
        
    }

    public DataTable SearchCandidate()
    {
        srch = new Search();
        StringBuilder sb = new StringBuilder();
        sb.Append("Select Top 70 Candidate_Id,Candidate_Name,Mobile_No,Email,WorkExp,Current_Employer,Current_Designation,Annual_Salary ,");
        sb.Append(" Previous_Employer,(Isnull(UG_Institute,PG_Institute)) as University ");
        sb.Append(" From CandidateDetail");
        sb.Append(" Where Status=1");
        //-------------------------------------------------------------------------------------------------------------
        if (txtExpFrom.Text != "" && txtExpTo.Text != "")
        {
            sb.Append(" and ( WorkExp like '" + txtExpFrom.Text + "%'  or  WorkExp like '" + txtExpTo.Text + "%')");
        }
        else if (txtExpFrom.Text != "" )
        {
            sb.Append(" and  WorkExp like '" + txtExpFrom.Text + "%' ");
        }
        else if (txtExpTo.Text != "")
        {
            sb.Append(" and  WorkExp like '" + txtExpTo.Text + "%' ");
        }
        //-------------------------------------------------------------------------------------------------------------------
        if (txtCTCFrom.Text != "" && txtCTCTo.Text != "")
        {
            sb.Append(" and ( Annual_Salary like '%" + txtCTCFrom.Text + "%'  or  Annual_Salary like '%" + txtCTCTo.Text + "%')");
        }
        else if (txtCTCFrom.Text != "" )
        {
            sb.Append(" and  Annual_Salary like '%" + txtCTCFrom.Text + "%'");
        }
        else if (txtCTCTo.Text != "")
        {
            sb.Append(" and  Annual_Salary like '%" + txtCTCTo.Text + "%'");
        }
       
        if (txtKeySkills.Text != "")
        {
            sb.Append(" and ( WorkExp like '%" + txtKeySkills.Text + "%'  or  Resume_Title like '%" + txtKeySkills.Text + "%' ");
            sb.Append(" or  Industry like '%" + txtKeySkills.Text + "%' or  Key_Skills like '%" + txtKeySkills.Text + "%' )");
        }
       
        if (txtLocation.Text != "")
        {
            sb.Append(" and  Current_Location like '%" + txtLocation.Text + "%'");
            
        }


        if (txtName.Text != "")
        {
            sb.Append(" and  Candidate_Name like '%" + txtName.Text + "%'");

        }
        if (txtMobile.Text != "")
        {
            sb.Append(" and  Mobile_No like '%" + txtMobile.Text + "%'");

        }
        if (txtEmailId.Text != "")
        {
            sb.Append(" and  Email like '%" + txtEmailId.Text + "%'");

        }




        string query = sb.ToString();
        return srch.SearchRecord(query).Tables[0];
    }

    protected void btnNew_Click(object sender, EventArgs e)
    {
        Response.Redirect("CandidateForm.aspx");
    }

    protected void btnAdd_Click(object sender, EventArgs e)
    {
        Response.Redirect("NewCandidate.aspx");

    }

}