using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;
using System.Configuration;

public partial class Recruitment_FollowUp : BaseClass
{
    FollowUpBAL FollowBal;
    RecruitmentBAL RecBAL;
    LoginBAL Userbal;
    WS_References Sr;
    DataTable dt;
    int UserId, RRCandidateId, URole, RequestId;
    static string ResumePath, CandidateName, ClientName, FPath;
    public string filename;
    public string filename1;
    String fname, fpath;
    string fileExtention;
    static string SupStatus;
    int ApprovalManager;
    static int CandidateId;
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
               
                ViewState["PreviousPage"] = Request.UrlReferrer;
                RRCandidateId = Convert.ToInt32(Request.QueryString["Id"]);
                Session["RRCandId"] = RRCandidateId;
                ddlSupStatus.Enabled = false;
                GetRRDtlBYRRCnd();
              
            }
            catch (Exception ex)
            {
            }
            finally
            {
                if (URole == 3 || URole == 8)  //if (URole == 3)
                {

                    ddlRecStatus.Enabled = true;

                }
                else
                {

                    ddlRecStatus.Enabled = true;

                }

                BindConsultant();
                BindStatus();
                BindCandidate();
                BindClient();
                BindOldFollowUp();
                GetRRCandDetailByRRCId();
                if (ResumePath == "")
                {
                    trView.Visible = false;
                }
                else
                {
                    trUpload.Visible = false;
                }
            }

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
                    SupStatus = dt.Rows[0]["Supervisor_Status"].ToString();
                    txtRemarks.Text = dt.Rows[0]["FollowUp_Remarks"].ToString();


                    if (RecruitStatus != "")
                    {
                        ddlRecStatus.Items.FindByText(RecruitStatus).Selected = true;
                    }
                    if (SupStatus != "")
                    {
                        ddlSupStatus.Items.FindByText(SupStatus).Selected = true;
                        if (ddlSupStatus.SelectedItem.ToString() == "Pending Approval" && (URole == 3 || URole == 8))  //&& (URole == 3)
                        {

                            ddlRecStatus.Enabled = false;

                        }
                        else if (SupStatus != "")
                        {

                        }
                        else
                        {

                            ddlRecStatus.Enabled = false;
                        }

                    }
                    if (SupStatus == "Approved")
                    {
                        ddlCandStatus.Enabled = true;
                        ddlRecStatus.Enabled = false;
                    }
                    if (CandStatus != "")
                    {
                        ddlCandStatus.Items.FindByText(CandStatus).Selected = true;
                    }
                }
                catch (Exception ex)
                {
                }
                finally
                {

                }
            }
            else
            {
                ddlRecStatus.Items.FindByText("Identified").Selected = true;


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

private void GetRRCandDetailByRRCId()
{
    FollowBal = new FollowUpBAL();
    try
    {
        FollowBal.RRCandidateId = RRCandidateId;
        DataTable dt = new DataTable();
        dt = FollowBal.GetRRCandDetailByRRCId();
        txtOfferdPrice.Text = dt.Rows[0]["OfferPrice"].ToString();
        txtPlannedDOJ.Text = dt.Rows[0]["PlannedDOJ"].ToString();
        txtActualDoj.Text = dt.Rows[0]["ActualDoJ"].ToString();
        txtOfferedDate.Text = dt.Rows[0]["OfferDate"].ToString();

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
        ListItem li = new ListItem(" ", "0");
        FollowBal = new FollowUpBAL();
        try
        {
            ddlRecStatus.DataSource = FollowBal.FillRecruiterStatus();
            ddlRecStatus.DataTextField = "RecruiterStatus";
            ddlRecStatus.DataValueField = "RecruiterStatus_Id";
            ddlRecStatus.DataBind();
        }
        finally
        {
        }
        try
        {
            ddlSupStatus.Items.Clear();
            ddlSupStatus.Items.Add(li);
            ddlSupStatus.DataSource = FollowBal.FillApproverStatus();
            ddlSupStatus.DataTextField = "ApproverStatus";
            ddlSupStatus.DataValueField = "ApproverStatus_Id";
            ddlSupStatus.DataBind();
        }
        finally
        {
        }
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
            ApprovalManager = Convert.ToInt32(dt.Rows[0]["RRMngr_Id"]);
            lblMinSalary.Text = dt.Rows[0]["Min_Salary"].ToString();
            lblMaxSalary.Text = dt.Rows[0]["Max_Salary"].ToString();
            lblDesig.Text = dt.Rows[0]["Designation"].ToString();
            lblLocation.Text = dt.Rows[0]["City_Name"].ToString();
            lblRecieveDate.Text = dt.Rows[0]["Recieve_Date"].ToString();
            lblTargetDate.Text = dt.Rows[0]["Closer_Date"].ToString();
            FPath = dt.Rows[0]["JobFile_Path"].ToString();
            if (FPath == null || FPath == "")
            {
               
                Vjob.Visible = true;
            }
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
        SaveFollowUp();
    }

protected void SaveFollowUp()
{
    FollowBal = new FollowUpBAL();
    RecBAL = new RecruitmentBAL();
    String OverallSts = "";
    try
    {
        FollowBal.RRCandidateId = Convert.ToInt32(Session["RRCandId"]);
        FollowBal.RecruiterStatus = ddlRecStatus.SelectedItem.Text;

        if (ddlRecStatus.SelectedItem.ToString() == "Suitable/Interested" && ddlCandStatus.SelectedIndex == 0)
        {
            ddlSupStatus.Items.FindByText("Suitable/ Interested").Selected = true;
           // ddlSupStatus.Items.FindByText("Pending Approval").Selected = true;
            ddlSupStatus.Enabled = false;
            FollowBal.FollowDate = System.DateTime.Now.AddMinutes(MyTimeSpan).ToString("dd-MMM-yyyy");
            dt = new DataTable();
            RecBAL.RRCandidate_Id = Convert.ToInt32(Session["RRCandId"]);
            dt = RecBAL.GetRequestForFollowUp();
            ApprovalManager = Convert.ToInt32(dt.Rows[0]["RRMngr_Id"]);
            FollowBal.FollowBy = ApprovalManager;
        }
        else
        {
            FollowBal.FollowDate = txtFollowDate.Text;
            FollowBal.FollowBy = UserId;
        }
        if (ddlRecStatus.SelectedItem.ToString() == "Suitable/Not Interested")
        {
            FollowBal.SupervisorStatus = "";
        }
        else
        {
            FollowBal.SupervisorStatus = ddlSupStatus.SelectedItem.Text;
        }

        if (ddlCandStatus.SelectedIndex != 0)
        {
            FollowBal.CandidateStatus = ddlCandStatus.SelectedItem.Text;
        }
        FollowBal.FollowRemarks = txtRemarks.Text;

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

        try
        {

            DataTable dtover = new DataTable();
            dtover = FollowBal.GetOverall_StatusByRRCnd();
            if (dtover.Rows.Count > 0)
            {
                OverallSts = dtover.Rows[0]["Overall_Status"].ToString();
            }

            Sr = new WS_References();
            Sr.UpdateJobStatus(OverallSts, FollowBal.RRCandidateId);
        }
        catch (Exception ex)
        { }
        finally
        { }

        Response.Redirect("CandidateList.aspx");
       
    }
    finally
    {
        FollowBal = null;
        RecBAL = null;
    }
}
protected void lbtnHistory_Click(object sender, EventArgs e)
    {
        FollowBal = new FollowUpBAL();
        try
        {
            FollowBal.RRCandidateId = RRCandidateId;
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
                    trUpload.Visible = false;
                    trView.Visible = true;

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
protected void ddlRecStatus_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlRecStatus.SelectedItem.ToString() == "Suitable/Interested" || ddlRecStatus.SelectedValue.ToString() == "4")
        {
        
            ddlSupStatus.SelectedValue = (2).ToString();

           ddlCandStatus.SelectedValue = (1).ToString();
           
        }
        else
        {
            if (SupStatus == "" || SupStatus == null)
            {
                ddlSupStatus.SelectedIndex = 0;
            }
        }
    }
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
protected void lbView_Click(object sender, EventArgs e)
    {
        RecBAL = new RecruitmentBAL();
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
            RecBAL = null;
        }
    }
protected void ddlSupStatus_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlSupStatus.SelectedItem.ToString() == "Approved" )
        {
            ddlCandStatus.Items.FindByText("Share CV with Client").Selected = true;
        }
    }




    #region  ---Code For Next,savenext--
protected void GetRRDtlBYRRCnd()
{
    FollowBal = new FollowUpBAL();
    
    FollowBal.RRCandidateId = RRCandidateId;
    dt=FollowBal.GetReqIdByRRCnd();
    if (dt.Rows.Count > 0)
    {
         RequestId = Convert.ToInt32(dt.Rows[0]["Request_Id"].ToString());
         ViewState["RequestId"] = RequestId;
    }
     
}

  protected void btnNext_Click(object sender, EventArgs e)
 {
     lblmsg.Text = "";
     FunForNext();
     btnPrevious.Enabled = true;
   
  }
  protected void FunForNext()
  {

      int idx2;
      try
      {
          FollowBal = new FollowUpBAL();
          FollowBal.RequestId = Convert.ToInt32(ViewState["RequestId"]);
          FollowBal.RRCandidateId = Convert.ToInt32(Session["RRCandId"]);
          dt = FollowBal.GetRRCndsByRequestId();
          if (Convert.ToInt32(ViewState["idx"]) != 0)
          {
               idx2 = Convert.ToInt32(ViewState["idx"]);
          }
          else
          {
              idx2 = 0;
          }
          if (idx2 < dt.Rows.Count - 1)
          {
              idx2++;
              ViewState["idx"]= idx2;
              int NextRRCandidat_Id = Convert.ToInt32(dt.Rows[idx2]["RRCandidate_Id"].ToString());
             // if (Convert.ToInt32(Session["RRCandId"]) < Convert.ToInt32(dt.Rows[idx2]["RRCandidate_Id"].ToString()))
              if (NextRRCandidat_Id>0)
              {
                  RRCandidateId = NextRRCandidat_Id;
                  ddlRecStatus.ClearSelection();
                  ddlCandStatus.ClearSelection();
                  ddlSupStatus.ClearSelection();
                  BindConsultant();
                  BindStatus();
                  BindCandidate();
                  BindClient();
                  BindOldFollowUp();
              }

          }
          else
          {
              lblmsg.Text = "No more candidate found for this Job Request";
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
    protected void btnSaveNext_Click(object sender, EventArgs e)
  {
      SaveFollowUp();
      FunForNext();
  }

    protected void lbBack_Click(object sender, EventArgs e)
    {
      Response.Redirect("FollowUpList.aspx");
       
    }

    protected void btnPrevious_Click(object sender, EventArgs e)
  {
      lblmsg.Text = "";
      FunForPrevious();
  }

    protected void FunForPrevious()
    {
        int idx2;
        try
        {
            FollowBal = new FollowUpBAL();
            FollowBal.RequestId = Convert.ToInt32(ViewState["RequestId"]);
            FollowBal.RRCandidateId = Convert.ToInt32(Session["RRCandId"]);
            dt = FollowBal.GetRRCndsByRequestId();
            if (Convert.ToInt32(ViewState["idx"]) != 0)
            {
                idx2 = Convert.ToInt32(ViewState["idx"]);
            }
            else
            {
                idx2 = 0;
            }
            if (idx2 < dt.Rows.Count)
            {
                idx2--;
                ViewState["idx"] = idx2;
                if (idx2 >= 0)
                {
                    int NextRRCandidat_Id = Convert.ToInt32(dt.Rows[idx2]["RRCandidate_Id"].ToString());
                    if (NextRRCandidat_Id > 0)
                    {
                        RRCandidateId = NextRRCandidat_Id;
                        ddlRecStatus.ClearSelection();
                        ddlCandStatus.ClearSelection();
                        ddlSupStatus.ClearSelection();
                        BindConsultant();
                        BindStatus();
                        BindCandidate();
                        BindClient();
                        BindOldFollowUp();
                    }

                }
                else
                {
                    lblmsg.Text = "No more candidate found for this Job Request";
                }
            }
            else
            {
                lblmsg.Text = "No more candidate found for this Job Request";
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
    #endregion




}