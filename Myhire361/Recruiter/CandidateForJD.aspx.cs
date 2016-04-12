using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Data;
using System.Text;
using System.IO;
using System.Configuration;

public partial class CandidateForJD : BaseClass
{
    DashboardBAL dshBAL;
    RecruiterBAL recruit;
    RecruitmentBAL ReqBAL;
    RecruitmentBAL RecBAL;
    FollowUpBAL FollowBal;
   
    WS_References Sr;
    DataTable dt;
    LoginBAL Userbal;


    int UserId, URole, RequestId, RId, RRCandidateId;
   static int CountSentForApproval;

   static string ResumePath, CandidateName, ClientName, FPath;
   public string filename;
   public string filename1;
   string fname, fpath;
   string fileExtention;
 
   static int CandidateId;
   int MyTimeSpan = 0;
    
  
    protected void Page_Load(object sender, EventArgs e)
    {
        UserId = Convert.ToInt32(Session["UserId"]);
        URole = Convert.ToInt32(Session["UserRole"]);
        try
        {

            ViewState["PreviousPage"] = Request.UrlReferrer;
            RId = Convert.ToInt32(Session["RId"]);
        }
        catch (Exception ex)
        {
            RId = 0;
        }
        if (!IsPostBack)
        {
          PnlLink.Visible = true;
          BindGrid();
          bindJD();
          BindCandidate();
        }
    }
    protected void bindJD()
    {
        recruit = new RecruiterBAL();
        DataTable dt = new DataTable();

        try
        {
            recruit.Request_Id = RId;
            dt = recruit.GetRequestByRecruiter();
            lblrr.Text = dt.Rows[0]["RRNumber"].ToString();
            lblHClientName.Text = dt.Rows[0]["Client_Name"].ToString();
            lblHjobprofile.Text = dt.Rows[0]["Job_Profile"].ToString();
               
        }
        finally
        {
            recruit = null;
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
                PnlCandidate.Visible = false;
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
    private void BindCandidate()
    {
        recruit = new RecruiterBAL();
        DataTable dt = new DataTable();
            DataView dv=new DataView();
    
       recruit.ConsultantId = UserId;
       recruit.Request_Id = RId;


       
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
            FollowBal = new FollowUpBAL();
            DataTable dt = new DataTable();
            
            try
            {

                GridViewRow gvr = (GridViewRow)((Control)e.CommandSource).NamingContainer;
                string CId = ((Label)gvr.FindControl("lblCId")).Text.Trim();
                string lblRRCId = ((Label)gvr.FindControl("lblRRCId")).Text.Trim();
                Session["lblRRCId"] = lblRRCId;
                Session["CId"] = CId;
                ReqBAL.CandidateId = Convert.ToInt32(CId.ToString());


                ReqBAL.RRCandidate_Id = Convert.ToInt32(lblRRCId.ToString());
                dt = ReqBAL.GetCandidateForFollowUp();
                CId = dt.Rows[0]["Candidate_Id"].ToString();
                lblName.Text = dt.Rows[0]["Candidate_Name"].ToString();
                lblCid.Text = dt.Rows[0]["Candidate_Id"].ToString();
                lblResumeTittle.Text = dt.Rows[0]["Resume_Title"].ToString();
                string Qualificcatn = dt.Rows[0]["UG_Course"].ToString() + "/" + dt.Rows[0]["PG_Course"].ToString() + "/" + dt.Rows[0]["PostPG_Course"].ToString();

                lblQualification.Text = Qualificcatn;
                lblCTC.Text = dt.Rows[0]["Annual_Salary"].ToString();
                lblCDesignation.Text = dt.Rows[0]["Current_Designation"].ToString();
                lblCLocation.Text = dt.Rows[0]["Current_Location"].ToString();
                lblContact.Text = dt.Rows[0]["Mobile_No"].ToString();
                lblEmailId.Text = dt.Rows[0]["Email"].ToString();
                lblLastActiveDate.Text = dt.Rows[0]["LastActivationDate"].ToString();
                lblCompny.Text = dt.Rows[0]["Current_Employer"].ToString();
                lblExperience.Text = dt.Rows[0]["WorkExp"].ToString();
                string ResumerID = dt.Rows[0]["Resumer_Id"].ToString();
                lblPortalResume.Text = "<a href=" + ResumerID + " target='_blank' >" + "Portal Resume" + "</a>";

                ResumePath = dt.Rows[0]["Resume_Path"].ToString();
                PnlCandidate.Visible = false;
                pnlHistory.Visible = true;




                recruit.RRCandidate_Id = Convert.ToInt32(Session["lblRRCId"]);

                gdvFollowuphis.DataSource = recruit.GetFollowUpHistoryForRecruiter();
                gdvFollowuphis.DataBind();
                BindCandidateStatus();


             
            }
            finally
            {

            }
        }
       

    }
    private void BindCandidateStatus()
    {
        ListItem li = new ListItem(" ", "0");
        FollowBal = new FollowUpBAL();
       
      
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
    //protected void btnSave_Click(object sender, EventArgs e)
    //{
    //    SaveFollowUp();
    //}
    protected void lbtnResume_Click(object sender, EventArgs e)
    {
        RecBAL = new RecruitmentBAL();
        FollowBal = new FollowUpBAL();
        string path = "";
        try
        {
            ResumePath = ResumePath.Replace("\\", "/");
            path = ".." + ResumePath;
            Response.Write("<SCRIPT language=javascript>window.open('" + path + "', 'CustomPopUp', " + "'width=1200, height=500, menubar=yes, resizable=yes');</SCRIPT>");
        }
        catch
        {
        }
        finally
        {
            RecBAL = null;
        }
    }
    protected void btnUpload_Click(object sender, EventArgs e)
    {
        RecBAL = new RecruitmentBAL();
        FollowBal = new FollowUpBAL();
        try
        {
            if (fileUpload.HasFile)
            {

                fname = fileUpload.FileName;
                fpath = Server.MapPath("Resume");
                fileExtention = System.IO.Path.GetExtension(fname);
                fpath = fpath + "\\" + fileUpload.FileName;

                string path = "..\\Resume\\";



                path = Server.MapPath(path);

                try
                {
                    if (!Directory.Exists(path))
                    {
                        Directory.CreateDirectory(path);
                    }

                    path = path + +CandidateId + fileExtention;

                    fileUpload.SaveAs(path);
                    RecBAL.CandidateId = CandidateId;
                    path = path.Substring(path.IndexOf("\\Resume"));
                    RecBAL.Resume_Path = path;
                    RecBAL.LoggedBy = UserId;
                    RecBAL.UpdateCandidateResume();
                    BindCandidate();
                  

                }
                catch (Exception ex)
                {

                }

            }
            else
            {

            }
        }
        finally
        {
            RecBAL = null;
        }
    }

    protected void BtnJD_Click1(object sender, EventArgs e)
    {
        Response.Redirect("~/Recruiter/RecruiterDashboard.aspx");

    }
    protected void btnCandidate_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Recruiter/RCandidateList.aspx");
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
    protected void gdvFollowuphis_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gdvFollowuphis.PageIndex = e.NewPageIndex;
      
       
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        recruit = new RecruiterBAL();
        ReqBAL = new RecruitmentBAL();
        try
        {

            recruit.RRCandidate_Id = Convert.ToInt32(Session["lblRRCId"]);
            recruit.FollowUp_Type = ddlFolowType.SelectedValue;
            recruit.FollowUp_Date = txtFollowDate.Text;
            recruit.FollowUp_Remarks = txtRemarks.Text;
            recruit.Candidate_Status = ddlCandStatus.SelectedItem.Text;
            recruit.CreatedBy = UserId;
           int result= Convert.ToInt32(recruit.FollowUpHistoryForRecruiter());
            if (result == 1)
            {
                lblmsg.Text = "Saved Successfully";
                txtRemarks.Text = null;
                txtFollowDate.Text = null;
                DataTable dt1 = new DataTable();
                recruit.RRCandidate_Id = Convert.ToInt32(Session["lblRRCId"]);

                gdvFollowuphis.DataSource = recruit.GetFollowUpHistoryForRecruiter();
                gdvFollowuphis.DataBind();
                
                 

            }
            else
            {
                lblmsg.Text = "Already Exists";
            }



        }
        finally
        {
            recruit = null;
        }
    }
    protected void gdvCandidate_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gdvCandidate.PageIndex = e.NewPageIndex;
        BindCandidate();
                
    }
}
