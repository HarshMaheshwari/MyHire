using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text;

public partial class Recruitment_CandidateList : BaseClass
{
    RecruitmentBAL RecBAL;
    SendMail mail;
    LoginBAL UsrBal;
     int RequestId, UserId,count;
     DataTable dt = new DataTable();
     string[,] QueryArray = new string[3, 2];
     Search srch;

    protected void Page_Load(object sender, EventArgs e)
    {
        UserId = Convert.ToInt32(Session["UserId"]);
     
        if (!IsPostBack)
        {
            try
            {
              
                Session["FlagA"] = null;
            }
            catch (Exception ex)
            {
            }
            BindCandidate();
        }
    }

    private void BindCandidate()
    {
        RequestId = Convert.ToInt32(Session["Rid"]);
        RecBAL = new RecruitmentBAL();
        try
        {
            dt = SearchCandidate();
            DataView dv = new DataView(dt);
            dv.RowFilter = "Status='" + ddlRecordStatus.SelectedValue + "'";
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

    protected void gdvCandidate_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        lblmsg.Text = "";
        gdvCandidate.PageIndex = e.NewPageIndex;
        BindCandidate();
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

        if (e.CommandName == "History")
        {
            GridViewRow gvr = (GridViewRow)((Control)e.CommandSource).NamingContainer;
            int RRCanId = Convert.ToInt32(((Label)gvr.FindControl("lblRRId")).Text);
            string url = "FollowUpHistory.aspx?Id=" + RRCanId;
            Response.Redirect(url);
        }
        else if (e.CommandName == "RRHistory")
        {
            GridViewRow gvr = (GridViewRow)((Control)e.CommandSource).NamingContainer;
            int Id = Convert.ToInt32(((Label)gvr.FindControl("lblId")).Text);
            string url = "../Candidate/CandidateHistory.aspx?Id=" + Id;
            Response.Redirect(url);
        }
        else if (e.CommandName == "Video")
        {
            GridViewRow gvr = (GridViewRow)((Control)e.CommandSource).NamingContainer;
            int Id = Convert.ToInt32(((Label)gvr.FindControl("lblId")).Text);
            int RRCandidateId = Convert.ToInt32(((Label)gvr.FindControl("lblRRId")).Text);
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
                        mail.SendVideoLink(CandidateName, CandidateEmail, ConsultantEmail, Id, RRCandidateId, "Mhr_" + Id + "_");
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
            int RRId = Convert.ToInt32(((Label)gvr.FindControl("lblRRId")).Text);
            string url = "~/Recruitment/CandidateVideoList.aspx?Id=" + Id + "&RRId=" + RRId;
            Response.Redirect(url);
        }
    }

    protected void lbBack_Click(object sender, EventArgs e)
    {
        Response.Redirect("MyPosition.aspx");
    }

    protected void btnExcel_Click(object sender, EventArgs e)
    {
       // // if (e.CommandName == "Upload")
       // //{
       // //    GridViewRow gvr = (GridViewRow)((Control)e.CommandSource).NamingContainer;
       // //    int Id = Convert.ToInt32(((Label)gvr.FindControl("lblId")).Text);
       // //    Session["Flag"] = "1";
       // //    string url = "UploadRRCandidate.aspx?Id=" + Id;
       // //    Response.Redirect(url);
       // GridViewRow gvr = (GridViewRow)((Control)e.CommandSource).NamingContainer;
       // int Id = Convert.ToInt32(((Label)gvr.FindControl("lblId")).Text);
       // string url = "UploadRRCandidate.aspx?Id=" + Id;
       // Response.Redirect(url);
       // Response.Redirect("~/Recruitment/UploadRRCandidate.aspx");
       //// }
    }

    protected void btnCVs_Click(object sender, EventArgs e)
    {
        Response.Redirect("../UploadCVs.aspx");
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
        RequestId = Convert.ToInt32(Session["Rid"]);
        srch = new Search();
        StringBuilder sb = new StringBuilder();
        sb.Append("Select Cd.Candidate_Name, Cd.Candidate_Id, Cd.Mobile_No, Cd.Email,Cd.WorkExp,Cr.Request_Id, Cr.RRCandidate_Id,Cd.Annual_Salary, Fu.Supervisor_Status,Cd.Current_Employer,Cd.Current_Designation, ");
        sb.Append(" Fu.Candidate_Status,Isnull(Fu.Recruiter_Status,'Identified') As Recruiter_Status, Fu.FollowUp_Date,Rr.RRNumber,cl.Client_Name,Cr.Consultant_Id,cr.status");
        sb.Append(" From CandidateDetail As Cd INNER JOIN RRCandidateRelation As Cr ON Cd.Candidate_Id = Cr.Candidate_Id");
        sb.Append(" inner join RecruitmentRequest As Rr on Cr.Request_Id=Rr.Request_Id");
        sb.Append(" inner join ClientDetail As Cl on Rr.Client_Id=cl.Client_Id");
        sb.Append(" Left JOIN FollowUp As Fu ON Cr.RRCandidate_Id = Fu.RRCandidate_Id and Fu.Status in (Null,1)");
        sb.Append(" Where Cr.Request_Id="+RequestId+" And Cr.Status= " + ddlRecordStatus.SelectedValue + " and Cr.Consultant_Id="+UserId);
        sb.Append(" and (Fu.Supervisor_Status<>'Pending Approval' or Fu.Supervisor_Status is null)");
        for (int idx = 0; idx < count; idx++)
        {
            sb.Append(" and " + (QueryArray[idx, 0].ToString()) + " Like '%" + (QueryArray[idx, 1].ToString()) + "%'");
        }
        sb.Append("order by Cr.CreationDate desc");
        string query = sb.ToString();
        return srch.SearchRecord(query).Tables[0];
    }
    protected void ddlRecordStatus_SelectedIndexChanged(object sender, EventArgs e)
    {
        txtCtc.Text = "";
        txtMobile.Text = "";
        txtName.Text = "";
        BindCandidate();
    }
}