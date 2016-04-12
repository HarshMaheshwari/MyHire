using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text;

public partial class SelectedForJD : BaseClass
{
    DashboardBAL dshBAL;
    RecruiterBAL recruit;
    RecruitmentBAL ReqBAL;
    RecruitmentBAL RecBAL;
    FollowUpBAL FollowBal;

    int UserId, URole, RequestId, RId;
   static int CountSentForApproval;
   static string ResumePath, FPath;
    
  
    protected void Page_Load(object sender, EventArgs e)
    {
        UserId = Convert.ToInt32(Session["UserId"]);
        URole = Convert.ToInt32(Session["UserRole"]);
        try
        {
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
          BindGetInterviewSelectedForJD();
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
    private void BindGetInterviewSelectedForJD()
    {
        recruit = new RecruiterBAL();
        DataTable dt = new DataTable();
            DataView dv=new DataView();
    
       recruit.ConsultantId = UserId;
       recruit.Request_Id = RId;


       
        try
        {


            dv.Table = recruit.GetInterviewSelectedForJD();
            gdvSelected.DataSource = dv;
            gdvSelected.DataBind();

            
        }
    
        finally
        {
            recruit = null;
        }
    }


    protected void BtnJD_Click1(object sender, EventArgs e)
    {
        Response.Redirect("~/Recruiter/RecruiterDashboard");

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
        Response.Redirect("~/Recruiter/SelectedCandidate");
    }
   

  

}
