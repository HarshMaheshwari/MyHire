using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;
using System.Configuration;


public partial class Recruitment_MyPostionFollowup : BaseClass
{
    FollowUpBAL FollowBal;
    RecruitmentBAL RecBAL;
    LoginBAL Userbal;
    DataTable dt;
    int UserId, RRCandidateId, CandidateId, URole,ConsultantId;
    static string ResumePath, CandidateName, ClientName, FPath;
    public string filename;
    public string filename1;
    String fname, fpath;
    String spath;
    string fileExtention;
    int MyTimeSpan = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        UserId = Convert.ToInt32(Session["UserId"]);
        URole = Convert.ToInt32(Session["UserRole"]);
        MyTimeSpan = Convert.ToInt32(ConfigurationManager.AppSettings["TimeSpan"]);
        if (!Page.IsPostBack)
        {
            try
            {
               
                RRCandidateId = Convert.ToInt32(Request.QueryString["Id"]);
                Session["RRCandId"] = RRCandidateId;

            }
            catch (Exception ex)
            {
            }

            BindConsultant();
            BindStatus();
            BindCandidate();
            BindClient();
            BindOldFollowUp();
            
        }
    }

    private void BindOldFollowUp()
    {
        FollowBal = new FollowUpBAL();
        try
        {
            FollowBal.RRCandidateId = RRCandidateId;
            DataTable dt = new DataTable();
            dt = FollowBal.GetActiveFollowUpByRRCanId();
            if (dt.Rows.Count > 0)
            {
                try
                {
                    string RecruitStatus = dt.Rows[0]["Recruiter_Status"].ToString();
                    string CandStatus = dt.Rows[0]["Candidate_Status"].ToString();
                    string SupStatus = dt.Rows[0]["Supervisor_Status"].ToString();
                    txtRemarks.Text = dt.Rows[0]["FollowUp_Remarks"].ToString();
                    if (RecruitStatus != "")
                    {
                        lblRecStatus.Text = RecruitStatus;
                    }
                    if (SupStatus != "")
                    {
                        ddlSupStatus.Items.FindByText(SupStatus).Selected = true;
                        if (ddlSupStatus.SelectedItem.ToString() == "Pending Approval")
                        {
                            ddlSupStatus.Enabled = true;
                        }
                        else
                        {
                            ddlSupStatus.Items.FindByText("Pending Approval").Selected = true;
                        }
                    }
                    if (CandStatus != "")
                    {
                        lblCanStatus.Text = CandStatus;
                    }
                }
                catch (Exception ex)
                {
                }
                finally
                {

                }
            }
           
        }
        catch (Exception ex)
        {

        }
        finally
        {
            FollowBal = null;
        }

    }

    private void BindStatus()
    {
        FollowBal = new FollowUpBAL();
       
        try
        {
            ddlSupStatus.DataSource = FollowBal.FillApproverStatus();
            ddlSupStatus.DataTextField = "ApproverStatus";
            ddlSupStatus.DataValueField = "ApproverStatus_Id";
            ddlSupStatus.DataBind();
        }
        finally
        {
        }
       
    }

    private void BindConsultant()
    {
        Userbal = new LoginBAL();
        try
        {
            ListItem lis = new ListItem("Select", "0");
            ddlFollowBy.Items.Clear();
            ddlFollowBy.Items.Add(lis);
            ddlFollowBy.DataSource = Userbal.FillUser();
            ddlFollowBy.DataTextField = "USR_Name";
            ddlFollowBy.DataValueField = "USR_ID";
            ddlFollowBy.DataBind();
            try
            {
                txtFollowDate.Text = DateTime.Now.AddMinutes(MyTimeSpan).ToString("dd-MMM-yyyy");
                ddlFollowBy.SelectedValue = UserId.ToString();
            }
            finally
            {

            }
        }
        finally
        {
            Userbal = null;
        }
    }

    private void BindClient()
    {
        RecBAL = new RecruitmentBAL();
        try
        {
            dt = new DataTable();
            RecBAL.RRCandidate_Id = RRCandidateId;
            dt = RecBAL.GetRequestForFollowUp();
            ClientName = dt.Rows[0]["Client_Name"].ToString();
            lblClient.Text = ClientName;
            lblRrNo.Text = dt.Rows[0]["RRNumber"].ToString();
            lblMinSalary.Text = dt.Rows[0]["Min_Salary"].ToString();
            lblMaxSalary.Text = dt.Rows[0]["Max_Salary"].ToString();
            lblDesig.Text = dt.Rows[0]["Designation"].ToString();
            lblLocation.Text = dt.Rows[0]["City_Name"].ToString();
            lblRecieveDate.Text = dt.Rows[0]["Recieve_Date"].ToString();
            lblTargetDate.Text = dt.Rows[0]["Closer_Date"].ToString();
            FPath = dt.Rows[0]["JobFile_Path"].ToString();
        }
        catch (Exception ex)
        {
        }
        finally
        {
            RecBAL = null;
            dt = null;
        }
    }

    private void BindCandidate()
    {
        RecBAL = new RecruitmentBAL();
        try
        {
            dt = new DataTable();
            RecBAL.RRCandidate_Id = RRCandidateId;
            dt = RecBAL.GetCandidateForFollowUp();
            CandidateId = Convert.ToInt32(dt.Rows[0]["Candidate_Id"].ToString());
            CandidateName = dt.Rows[0]["Candidate_Name"].ToString();
            lblName.Text = CandidateName;
            lblCTC.Text = dt.Rows[0]["Annual_Salary"].ToString();
            lblResumeTittle.Text = dt.Rows[0]["Resume_Title"].ToString();
            string Qualificcatn = dt.Rows[0]["UG_Course"].ToString() + "/" + dt.Rows[0]["PG_Course"].ToString() + "/" + dt.Rows[0]["PostPG_Course"].ToString();

            lblQualification.Text = Qualificcatn;
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
        }
        catch (Exception ex)
        {
        }
        finally
        {
            RecBAL = null;
            dt = null;
        }
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        FollowBal = new FollowUpBAL();
        try
        {
            FollowBal.RRCandidateId = Convert.ToInt32(Session["RRCandId"]); 
            FollowBal.RecruiterStatus = lblRecStatus.Text;
            string SupStatus = ddlSupStatus.SelectedItem.Text;
            if (SupStatus == "Approved")
            {
                FollowBal.FollowBy = Convert.ToInt32(Session["RRConsltntId"]); 
            }
            else
            {
                FollowBal.FollowBy = Convert.ToInt32(ddlFollowBy.SelectedValue);
            }
            FollowBal.SupervisorStatus = ddlSupStatus.SelectedItem.Text;
            FollowBal.CandidateStatus = lblCanStatus.Text;
           
            FollowBal.FollowRemarks = txtRemarks.Text;
            FollowBal.FollowDate = txtFollowDate.Text;
            FollowBal.FollowTime = ddlHH.SelectedValue.ToString() + ":" + ddlMM.SelectedValue.ToString() + " " + ddlAMPM.SelectedValue.ToString();
            FollowBal.FollowType = ddlFolowType.SelectedItem.Text;
         
            FollowBal.LoggedBy = UserId;


            if (txtOfferdPrice.Text != "")
            {
                FollowBal.OfferedPrice = Convert.ToDouble(txtOfferdPrice.Text);
            }
            else
            {
                FollowBal.OfferedPrice = 0;
            }
            FollowBal.PlannedDoj = txtPlannedDOJ.Text; ;
            FollowBal.ActualDoj = txtActualDoj.Text;
            FollowBal.OfferDate = txtOfferedDate.Text;
            int Result = Convert.ToInt32(FollowBal.CreateFollowUp());
            if (Result > 0)
            {
                lblmsg.Text = "FollowUp Saved Successfully.";
                lblmsg.ForeColor = System.Drawing.Color.Green;
                Response.Redirect("MyWorkList.aspx");
             

            }
        }
        catch (Exception ex)
        {
        }
        finally
        {
            FollowBal = null;
        }
    }
    protected void lbtnHistory_Click(object sender, EventArgs e)
    {
        FollowBal = new FollowUpBAL();
        try
        {
            FollowBal.CandidateId = CandidateId;
            gdvFollowup.DataSource = FollowBal.GetFollowUpHistory();
            gdvFollowup.DataBind();
        }
        catch { }
        finally
        {
            FollowBal = null;
        }
        mpe.Show();
    }

    protected void lbView_Click(object sender, EventArgs e)
    {
        RecBAL = new RecruitmentBAL();
        FollowBal = new FollowUpBAL();
        try
        {
            if (FPath.IndexOf("Files") != -1)
            {
                FPath = FPath.Substring(FPath.IndexOf("Files"));
                FPath = Server.MapPath(FPath);
                Response.AddHeader("Content-Disposition", "attachment;filename=\"" + ClientName + "\"");
                Response.TransmitFile(FPath);
                Response.End();
            }
        }
        catch
        {
        }
        finally
        {
            RecBAL = null;
        }
    }
    protected void lbtnResume_Click(object sender, EventArgs e)
    {
        RecBAL = new RecruitmentBAL();
        FollowBal = new FollowUpBAL();
        try
        {
            if (ResumePath.IndexOf("Resume") != -1)
            {
                ResumePath = ResumePath.Substring(ResumePath.IndexOf("Resume"));
                ResumePath = Server.MapPath(ResumePath);
                ResumePath = ResumePath.Replace("\\Recruitment\\Resume", "\\Resume");
                Response.AddHeader("Content-Disposition", "attachment;filename=\"" + CandidateName + "\"");
                Response.TransmitFile(ResumePath);
                Response.End();
            }
        }
        catch
        {
        }
        finally
        {
            RecBAL = null;
        }
    }
    protected void ddlSupStatus_SelectedIndexChanged(object sender, EventArgs e)
    {

        if (ddlSupStatus.SelectedItem.ToString() == "Approved" || ddlSupStatus.SelectedValue.ToString() == "2")
        {
            lblCanStatus.Text = "Share CV with Client";
        }
    }
}