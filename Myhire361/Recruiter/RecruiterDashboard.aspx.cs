using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text;

public partial class RecruiterDashboard : BaseClass
{
    DashboardBAL dshBAL;
    RecruiterBAL recruit;
    RecruitmentBAL ReqBAL;
    RecruitmentBAL RecBAL;
    FollowUpBAL FollowBal;

    int UserId, URole, RequestId;
   static int CountSentForApproval;
   static string ResumePath, FPath;
    
  
    protected void Page_Load(object sender, EventArgs e)
    {
        UserId = Convert.ToInt32(Session["UserId"]);
        URole = Convert.ToInt32(Session["UserRole"]);
        if (!IsPostBack)
        {
            PnlLink.Visible = false;
          BindGrid();
        }
    }

    protected void BindGrid()
    {
        recruit = new RecruiterBAL();
        DataTable dt=new DataTable();

        try
            
        {
            recruit.ConsultantId = UserId;
            gdvFolloup.DataSource = recruit.GetJDForRecruiter();
            gdvFolloup.DataBind();
        }
        finally
        {
            recruit = null;
        }

    }
    protected void BindGridCandidate()
    {
        recruit = new RecruiterBAL();
        DataTable dt = new DataTable();

        try
        {
            recruit.ConsultantId = UserId;
            gdvFolloup.DataSource = recruit.GetJDForRecruiter();
            gdvFolloup.DataBind();
        }
        finally
        {
            recruit = null;
        }

    }


    protected void BtnJD_Click(object sender, EventArgs e)
    {
        PnlLink.Visible = false;
        BindGrid();

   
    }

    protected void gdvFolloup_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        DataTable dt1 = new DataTable();
        if (e.CommandName == "View")
        {
            recruit = new RecruiterBAL();
            DataTable dt = new DataTable();
            try
            {
                GridViewRow gvr = (GridViewRow)((Control)e.CommandSource).NamingContainer;
                string RId = ((Label)gvr.FindControl("lblId")).Text.Trim();
                Session["RId"] = RId;
                recruit.Request_Id = Convert.ToInt32(RId.ToString());

                //if (RId == null)
                //    PnlJd.Visible = false;
                


                //else
                //{
                //    PnlJd.Visible = true;
                //    PnlLink.Visible = true;
                //}
                PnlJd.Visible = true;
                PnlLink.Visible = true;
                PnlCandidate.Visible =false;
                dt = recruit.GetRequestByRecruiter();
                lblRRNumber.Text = dt.Rows[0]["RRNumber"].ToString();
                lblRid.Text = dt.Rows[0]["Request_Id"].ToString();
                txtJobProfile.Text = dt.Rows[0]["Job_Profile"].ToString();
                lblClient.Text = dt.Rows[0]["Client_Name"].ToString();
                lblManager.Text = dt.Rows[0]["USR_Name"].ToString();
                txtTotalPositions.Text = dt.Rows[0]["Total_Position"].ToString();
                lblRequestBy.Text = dt.Rows[0]["Person_Name"].ToString();
                txtReceiveDate.Text = dt.Rows[0]["Recieve_Date"].ToString();
                txtTargetClosureDate.Text = dt.Rows[0]["Closer_Date"].ToString();
                string Critical = dt.Rows[0]["Criticality"].ToString();
                if (Critical == "0")
                {
                    lblCricality.Text = "High";
                }
                else if (Critical == "1")
                {
                    lblCricality.Text = "Medium";
                }
                else
                {
                    lblCricality.Text = "Low";
                }
                txtDesignation.Text = dt.Rows[0]["Designation"].ToString();
                lblLocation.Text = dt.Rows[0]["City_Name"].ToString();
                txtMinSalary.Text = dt.Rows[0]["Min_Salary"].ToString();
                txtMaxSalary.Text = dt.Rows[0]["Max_Salary"].ToString();
                txtMinExperience.Text = dt.Rows[0]["Min_Experience"].ToString();
                txtMaxExperience.Text = dt.Rows[0]["Max_Experience"].ToString();
                txtMinQualification.Text = dt.Rows[0]["Min_Qualification"].ToString();
                txtPreferredIndus.Text = dt.Rows[0]["PIndustryName"].ToString();
                lblRequestStatus.Text = dt.Rows[0]["Request_Status"].ToString();
                lblSkills.Text = dt.Rows[0]["RSkills"].ToString();
                lblJobDesc.Text = dt.Rows[0]["JobDescription"].ToString();
                lblrr.Text = dt.Rows[0]["RRNumber"].ToString();
                lblHClientName.Text = dt.Rows[0]["Client_Name"].ToString();
                lblHjobprofile.Text = dt.Rows[0]["Job_Profile"].ToString();
                if (dt.Rows[0]["PositionType"].ToString() == "1")
                {
                    lblPositionType.Text = "IT";
                }
                if (dt.Rows[0]["PositionType"].ToString() == "2")
                {
                    lblPositionType.Text = "Non-IT";
                }
                FPath = dt.Rows[0]["JobFile_Path"].ToString();
                if (FPath == null || FPath == "")
                {
                    //Vjob.Visible = false;
                    // Vjob.Visible = true;
                }




            }

            finally
            {
                recruit = null;
            }
       }

           
            
        
    }
    protected void lbView_Click(object sender, EventArgs e)
    {
        ReqBAL = new RecruitmentBAL();
        FollowBal = new FollowUpBAL();
        string path = "";
        try
        {
            FPath = FPath.Replace("\\", "/");
            path = ".." + FPath;
            Response.Write("<SCRIPT language=javascript>window.open('" + path + "', 'CustomPopUp', " + "'width=1200, height=500, menubar=yes, resizable=yes');</SCRIPT>");
        }
        catch
        {
        }
        finally
        {
            ReqBAL = null;
        }
    }

    protected void lbnaddcandidate_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Recruitment/CandidateForm.aspx");
    }
    protected void lbnCandidates_Click(object sender, EventArgs e)
    {
      
        PnlJd.Visible = false;
        PnlCandidate.Visible = true;
        PnlCVShared.Visible = false;
        PnlFollowup.Visible = false;
        pnlInterviewpndg.Visible = false;
        PnlInterviewDone.Visible = false;
        pnlOffred.Visible = false;
        BindCandidate();
       
    }
    private void BindCandidate()
    {
        recruit = new RecruiterBAL();
        DataTable dt = new DataTable();
            DataView dv=new DataView();
    
       recruit.ConsultantId = UserId;
       recruit.Request_Id = Convert.ToInt32(lblRid.Text);


       
        try
        {

            dv.Table = recruit.GetCandidatesForJD();
            gdvCandidate.DataSource = dv;
            gdvCandidate.DataBind();
        }
    
        finally
        {
            recruit = null;
        }
    }
    protected void gdvCandidate_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "View12")
        {
            recruit = new RecruiterBAL();
            ReqBAL = new RecruitmentBAL();
            DataTable dt = new DataTable();
            try
            {
                GridViewRow gvr = (GridViewRow)((Control)e.CommandSource).NamingContainer;
                string CId = ((Label)gvr.FindControl("lblCId")).Text.Trim();
                ReqBAL.CandidateId = Convert.ToInt32(CId.ToString());
                dt = ReqBAL.GetCandidateById();
                lblName.Text = dt.Rows[0]["Candidate_Name"].ToString();
                lblAddress.Text = dt.Rows[0]["Address"].ToString();
                lblPhn.Text = dt.Rows[0]["Telephone_No"].ToString();
                lblMobile.Text = dt.Rows[0]["Mobile_No"].ToString();
                lblDob.Text = dt.Rows[0]["DOB"].ToString();
                lblEmail.Text = dt.Rows[0]["Email"].ToString();
                lblExperience.Text = dt.Rows[0]["WorkExp"].ToString();
                lblCurrentLocation.Text = dt.Rows[0]["Current_Location"].ToString();
                lblPreferred.Text = dt.Rows[0]["Preferred_Location"].ToString();
                lblEmployer.Text = dt.Rows[0]["Current_Employer"].ToString();
                lblDesg.Text = dt.Rows[0]["Current_Designation"].ToString();
                lblSalary.Text = dt.Rows[0]["Annual_Salary"].ToString();
                lblUG.Text = dt.Rows[0]["UG_Course"].ToString();
                lblPG.Text = dt.Rows[0]["PG_Course"].ToString();
                lblPost.Text = dt.Rows[0]["PostPG_Course"].ToString();
                lblAltEmail.Text = dt.Rows[0]["AltEmail"].ToString();
                lblcandidateSource.Text = dt.Rows[0]["CandidateSource"].ToString();
                lblPanCard.Text = dt.Rows[0]["PAN_Number"].ToString();
                lblPasportNo.Text = dt.Rows[0]["Passport_Number"].ToString();
                lblissueDate.Text = dt.Rows[0]["Issue_Date"].ToString();
                lblIssueLocation.Text = dt.Rows[0]["Issue_Location"].ToString();
                lblAdharCard.Text = dt.Rows[0]["AdharCard_Number"].ToString();
                lblIndustry.Text = dt.Rows[0]["Industry"].ToString();
            }
            finally
            {

            }
        }
        MPEView.Show();

    }

    protected void btnCandidate_Click(object sender, EventArgs e)
    {
    

        Response.Redirect("~/Recruiter/RCandidateList.aspx");   
      
                
       
    }
    protected void gdvFolloup_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
    {
        DataTable dts = new DataTable();
        DataView dv = new DataView(dts);

        try
        {
            GridViewRow gvr = gdvFolloup.Rows[e.NewSelectedIndex];
            string RId = ((Label)gvr.FindControl("lblId")).Text.Trim();
            //string url = "~/Recruiter/Candidates.aspx?Id=" + (RId);
            //Response.Redirect(url);
          
             
             
        }
        finally
        {

        }
        
    }
  
    protected void btnFollowUpRecruiter_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Recruiter/RFollowUpList.aspx");
    }
    protected void btnCVShared_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Recruiter/CVSharedWithClient.aspx");
    }
    protected void btnInterView_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Recruiter/InterViewDone.aspx");
    }
    protected void btnSelected_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Recruiter/SelectedCandidate.aspx");
    }

    private void GetCVSharedWithClientForJD()
    {
        recruit = new RecruiterBAL();
        DataTable dt = new DataTable();
        DataView dv = new DataView();

        recruit.ConsultantId = UserId;
        recruit.Request_Id = Convert.ToInt32(lblRid.Text);



        try
        {

            dv.Table = recruit.GetCVSharedWithClientForJD();
            gdvCVShared.DataSource = dv;
            gdvCVShared.DataBind();
            
        }

        finally
        {
            recruit = null;
        }
    }
    protected void lblCVShared_Click(object sender, EventArgs e)
    {
        PnlJd.Visible = false;
        PnlCandidate.Visible = false;
        PnlCVShared.Visible = true;
        PnlFollowup.Visible = false;
        PnlInterviewDone.Visible = false;
        pnlInterviewpndg.Visible = false;
        pnlOffred.Visible = false;
        GetCVSharedWithClientForJD();
    }
    private void GetFollowUpsForJD()
    {
        recruit = new RecruiterBAL();
        DataTable dt = new DataTable();
        DataView dv = new DataView();

        recruit.ConsultantId = UserId;
        recruit.Request_Id = Convert.ToInt32(lblRid.Text);



        try
        {

            dv.Table = recruit.GetFollowUpsForJD();
            gdvFollowup.DataSource = dv;
            gdvFollowup.DataBind();

        }

        finally
        {
            recruit = null;
        }
    }
    protected void lbnFollowUps_Click(object sender, EventArgs e)
    {
        PnlJd.Visible = false;
        PnlCandidate.Visible = false;
        PnlCVShared.Visible = false;
        PnlFollowup.Visible = true;
        pnlInterviewpndg.Visible =false;
        PnlInterviewDone.Visible = false;
        pnlOffred.Visible = false;
        GetFollowUpsForJD();

    }
    private void GetInterviewPendingForJD()
    {
        recruit = new RecruiterBAL();
        DataTable dt = new DataTable();
        DataView dv = new DataView();

        recruit.ConsultantId = UserId;
        recruit.Request_Id = Convert.ToInt32(lblRid.Text);

        try
        {

            dv.Table = recruit.GetInterviewPendingForJD();
            gdvInterviewPndng.DataSource = dv;
            gdvInterviewPndng.DataBind();

        }

        finally
        {
            recruit = null;
        }
    }
    protected void lbnInterviewPending_Click(object sender, EventArgs e)
    {
        PnlJd.Visible = false;
        PnlCandidate.Visible = false;
        PnlCVShared.Visible = false;
        PnlFollowup.Visible = false;
        pnlInterviewpndg.Visible = true;
        PnlInterviewDone.Visible = false;
        pnlOffred.Visible = false;
     
        GetInterviewPendingForJD();
    }
    private void GetInterviewDoneForJD()
    {
        recruit = new RecruiterBAL();
        DataTable dt = new DataTable();
        DataView dv = new DataView();

        recruit.ConsultantId = UserId;
        recruit.Request_Id = Convert.ToInt32(lblRid.Text);

        try
        {

            dv.Table = recruit.GetInterviewForJD();
            gdvInterviewDone.DataSource = dv;
            gdvInterviewDone.DataBind();
            

        }

        finally
        {
            recruit = null;
        }
    }
    protected void lbnInterviewDone_Click(object sender, EventArgs e)
    {
        PnlJd.Visible = false;
        PnlCandidate.Visible = false;
        PnlCVShared.Visible = false;
        PnlFollowup.Visible = false;
        pnlInterviewpndg.Visible = false;
        PnlInterviewDone.Visible = true;
        pnlOffred.Visible = false;
        GetInterviewDoneForJD();
    }
    private void GetOfferedForJD()
    {
        recruit = new RecruiterBAL();
        DataTable dt = new DataTable();
        DataView dv = new DataView();

        recruit.ConsultantId = UserId;
        recruit.Request_Id = Convert.ToInt32(lblRid.Text);

        try
        {

            dv.Table = recruit.GetOfferedForJD();
            gdvOffered.DataSource = dv;
            gdvOffered.DataBind();


        }

        finally
        {
            recruit = null;
        }
    }
    protected void lbnOffered_Click(object sender, EventArgs e)
    {
        PnlJd.Visible = false;
        PnlCandidate.Visible = false;
        PnlCVShared.Visible = false;
        PnlFollowup.Visible = false;
        pnlInterviewpndg.Visible = false;
        PnlInterviewDone.Visible = false;
        pnlOffred.Visible = true;
        GetOfferedForJD();
        

    }
}
