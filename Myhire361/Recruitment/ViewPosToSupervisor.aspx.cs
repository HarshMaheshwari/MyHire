using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;


public partial class Recruitment_ViewPosToSupervisor : BaseClass
{
    RecruitmentBAL ReqBAL;
    int RequestId, UserId,UsrRole;
    FollowUpBAL FollowBal;
    WS_References Sr;
    static string ResumePath, FPath;
    public string filename;
    public string filename1;
    String fname, fpath;
  protected void Page_Load(object sender, EventArgs e)
    {
        UserId = Convert.ToInt32(Session["UserId"]);
        RequestId = Convert.ToInt32(Request.QueryString["Id"]);
        UsrRole = Convert.ToInt32(Session["UserRole"]);
        if (!IsPostBack)
        {
          BindRequest();
        }
    }

    private void BindRequest()
    {
        ReqBAL = new RecruitmentBAL();
        try
        {
            DataTable dt = new DataTable();
            ReqBAL.Request_Id = RequestId;
            dt = ReqBAL.GetRequestById();
            lblRRNumber.Text = dt.Rows[0]["RRNumber"].ToString();
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
            if (dt.Rows[0]["PositionType"].ToString() == "1")
            {
                lblPositionType.Text = "IT";
            }
            if (dt.Rows[0]["PositionType"].ToString() == "2")
            {
                lblPositionType.Text = "Non-IT";
            }
            FPath = dt.Rows[0]["JobFile_Path"].ToString();
           txtReferrerPts.Text  = dt.Rows[0]["ReferrerPts"].ToString();
            if (FPath == null || FPath == "")
            {
                //Vjob.Visible = false;
              
            }

        }
        catch (Exception ex)
        {
           
        }
        finally
        {
            ReqBAL = null;

        }
    }

    protected void btncncl_Click(object sender, EventArgs e)
    {
        if (Session["Flag"].ToString() == "0")
        {
            Response.Redirect("MyPosition.aspx");
        }
        else if (Session["Flag"].ToString() == "3")
        {
            Response.Redirect("ViewPublishJob.aspx");
        }
        else if (Session["Flag"].ToString() == "1")
        {
            Response.Redirect("RRList.aspx");
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

    protected void btnPublish_Click(object sender, EventArgs e)
    {
        try
        {
            Sr = new WS_References();
            ReqBAL = new RecruitmentBAL();
            DataTable dt = new DataTable();
            ReqBAL.Request_Id = RequestId;
            ReqBAL.LoggedBy = UserId;
            dt = ReqBAL.GetRequestById();
            ReqBAL.RRNumber  = dt.Rows[0]["RRNumber"].ToString();
            ReqBAL.Job_Profile = dt.Rows[0]["Job_Profile"].ToString();
            ReqBAL.Client_Id =Convert.ToInt32( dt.Rows[0]["Client_Id"].ToString());
            ReqBAL.RprtingMngrId = Convert.ToInt32(dt.Rows[0]["RRMngr_Id"].ToString());
            ReqBAL.Total_Position =Convert.ToInt32( dt.Rows[0]["Total_Position"].ToString());
            ReqBAL.Request_By = Convert.ToInt32(dt.Rows[0]["Request_By"].ToString());
            ReqBAL.Recieve_Date = dt.Rows[0]["Recieve_Date"].ToString();
            ReqBAL.Closer_Date = dt.Rows[0]["Closer_Date"].ToString();
            ReqBAL.Criticality = Convert.ToInt32( dt.Rows[0]["Criticality"].ToString());
            ReqBAL.Designation = dt.Rows[0]["Designation"].ToString();
            ReqBAL.Location_Id = Convert.ToInt32(dt.Rows[0]["Location_Id"].ToString());
            if(dt.Rows[0]["Min_Salary"].ToString()!="")
            {
                ReqBAL.Min_Salary = Convert.ToDouble(dt.Rows[0]["Min_Salary"].ToString());
            }
            else
            {
            }
           ReqBAL.Max_Salary = Convert.ToDouble( dt.Rows[0]["Max_Salary"].ToString());
           ReqBAL.Min_Experience = Convert.ToDouble(dt.Rows[0]["Min_Experience"].ToString());
           ReqBAL.Max_Experience = Convert.ToDouble(dt.Rows[0]["Max_Experience"].ToString());
           ReqBAL.Min_Qualification = dt.Rows[0]["Min_Qualification"].ToString();
           ReqBAL.PIndustryId = Convert.ToInt32(dt.Rows[0]["PIndustryId"].ToString());
           ReqBAL.Request_Status = dt.Rows[0]["Request_Status"].ToString();
           ReqBAL.RSkills= dt.Rows[0]["RSkills"].ToString();
           ReqBAL.PositionType = Convert.ToInt32(dt.Rows[0]["PositionType"].ToString());
           ReqBAL.JobDescription = dt.Rows[0]["JobDescription"].ToString();
           ReqBAL.FuntionalAreaId =Convert.ToInt32( dt.Rows[0]["FuntionalAreaId"].ToString());
           ReqBAL.ReferrerPts=Convert.ToDouble(txtReferrerPts.Text.Trim());
           if (dt.Rows[0]["JobFile_Path"].ToString() != "")
           {
               ReqBAL.JobFile_Path = dt.Rows[0]["JobFile_Path"].ToString();
           }
           else
           {
               ReqBAL.JobFile_Path = "";
           }
           ReqBAL.IndustryId =Convert.ToInt32( dt.Rows[0]["IndustryId"].ToString());

           ReqBAL.FuntionalArea = dt.Rows[0]["FunctAreaName"].ToString();
           ReqBAL.Preferred_Industry  = dt.Rows[0]["PIndustryName"].ToString();
           ReqBAL.Industry = dt.Rows[0]["IndustryName"].ToString();
           DateTime PublishDate =Convert.ToDateTime( dt.Rows[0]["CreationDate"].ToString());
          if (UsrRole == 1)
            {
                   ReqBAL.PublishStatus = 1;
                   ReqBAL.UpdateRRJobs_RefPoint(); 
                    Sr.WS_InsertUpdateRRRequest_IHUP(ReqBAL.Request_Id, ReqBAL.RRNumber, ReqBAL.Job_Profile, ReqBAL.Client_Id,
                    ReqBAL.Total_Position, ReqBAL.Request_By, ReqBAL.Recieve_Date, ReqBAL.Closer_Date, ReqBAL.RprtingMngrId,
                    ReqBAL.Criticality, ReqBAL.Designation, ReqBAL.Location_Id, ReqBAL.Min_Salary, ReqBAL.Max_Salary, ReqBAL.Min_Experience,
                    ReqBAL.Max_Experience, ReqBAL.Min_Qualification,
                    ReqBAL.RSkills, ReqBAL.Request_Status, ReqBAL.JobFile_Path, ReqBAL.PositionType,
                    ReqBAL.JobDescription, 0, ReqBAL.ReferrerPts, ReqBAL.FuntionalAreaId, ReqBAL.PIndustryId, ReqBAL.IndustryId,
                    ReqBAL.FuntionalArea, ReqBAL.Preferred_Industry,PublishDate, ReqBAL.Industry, ReqBAL.LoggedBy);
                    lblmsg.Text = "Sucessfully Published.!!";
                    lblmsg.ForeColor = System.Drawing.Color.Green;
                    Response.Redirect("ViewPublishJob.aspx");
                
            }
          else if (UsrRole == 9)
          {
              ReqBAL.PublishStatus = 1;
              ReqBAL.UpdateRRJobs_RefPoint();
              Sr.WS_InsertUpdateRRRequest_IHUP(ReqBAL.Request_Id, ReqBAL.RRNumber, ReqBAL.Job_Profile, ReqBAL.Client_Id,
              ReqBAL.Total_Position, ReqBAL.Request_By, ReqBAL.Recieve_Date, ReqBAL.Closer_Date, ReqBAL.RprtingMngrId,
              ReqBAL.Criticality, ReqBAL.Designation, ReqBAL.Location_Id, ReqBAL.Min_Salary, ReqBAL.Max_Salary, ReqBAL.Min_Experience,
              ReqBAL.Max_Experience, ReqBAL.Min_Qualification,
              ReqBAL.RSkills, ReqBAL.Request_Status, ReqBAL.JobFile_Path, ReqBAL.PositionType,
              ReqBAL.JobDescription, 0, ReqBAL.ReferrerPts, ReqBAL.FuntionalAreaId, ReqBAL.PIndustryId, ReqBAL.IndustryId,
              ReqBAL.FuntionalArea, ReqBAL.Preferred_Industry, PublishDate, ReqBAL.Industry, ReqBAL.LoggedBy);
              lblmsg.Text = "Sucessfully Published.!!";
              lblmsg.ForeColor = System.Drawing.Color.Green;
              Response.Redirect("ViewPublishJob.aspx");

          }


        }
        catch (Exception ex)
        {
        }
        finally
        {
            ReqBAL = null;
        }
         
       
    }
    protected void btnDNPublish_Click(object sender, EventArgs e)
    {
          try
          {
              Sr = new WS_References();
            ReqBAL = new RecruitmentBAL();
            DataTable dt = new DataTable();
            ReqBAL.Request_Id = RequestId;
            ReqBAL.LoggedBy = UserId;
            ReqBAL.ReferrerPts = Convert.ToDouble(txtReferrerPts.Text.Trim());
            ReqBAL.PublishStatus = 0;
            if (UsrRole == 1)
            {
               
                ReqBAL.UpdateRRJobs_RefPoint(); 
                Sr.WS_H_RRDoNotPublish(ReqBAL.Request_Id, ReqBAL.LoggedBy);
                lblmsg.Text = "Sucessfully Un Published.!!";
                lblmsg.ForeColor = System.Drawing.Color.Green;
                Response.Redirect("ViewPublishJob.aspx");
             }
            else if (UsrRole == 9)
            {

                ReqBAL.UpdateRRJobs_RefPoint();
                Sr.WS_H_RRDoNotPublish(ReqBAL.Request_Id, ReqBAL.LoggedBy);
                lblmsg.Text = "Sucessfully Un Published.!!";
                lblmsg.ForeColor = System.Drawing.Color.Green;
                Response.Redirect("ViewPublishJob.aspx");
            }

           
          }
          catch (Exception ex)
          {
          }
          finally
          {
              ReqBAL = null;
          }
         
      
    }
    protected void btnView_Click(object sender, EventArgs e)
    {
         BindViewData();
         MPEView.Show();
       
    }

    private void BindViewData()
    {
        ReqBAL = new RecruitmentBAL();
        try
        {
            DataTable dt = new DataTable();
            ReqBAL.Request_Id = RequestId;
            dt = ReqBAL.RRForPublishByReqId();
            if (dt.Rows.Count > 0)
            {
                lblDesignation.Text = dt.Rows[0]["Designation"].ToString();
                lblExperience.Text = dt.Rows[0]["Experience"].ToString();
                lblLoc.Text = dt.Rows[0]["City_Name"].ToString();
                if (txtReferrerPts.Text != "")
                {
                    //lblrefPoints.Text = dt.Rows[0]["ReferrerPts"].ToString();
                    lblrefPoints.Text = txtReferrerPts.Text;
                }
                else
                {
                    lblrefPoints.Text = "0";
                }

                lblIndust.Text = dt.Rows[0]["IndustryName"].ToString();
                lblPackagefm.Text = dt.Rows[0]["Pacakagefrom"].ToString();
                lblPackageto.Text = dt.Rows[0]["PackageTo"].ToString();
                lblOpening.Text = dt.Rows[0]["Total_Position"].ToString();
                lblJobdecs.Text = dt.Rows[0]["JobDescription"].ToString();
                lblSalaryfm.Text = dt.Rows[0]["Salaryfrm"].ToString();
                lblSalaryto.Text = dt.Rows[0]["SalaryTo"].ToString();
                lblIndustry.Text = dt.Rows[0]["IndustryName"].ToString();
                lblFunArea.Text = dt.Rows[0]["FunctAreaName"].ToString();
                lblRole.Text = dt.Rows[0]["Job_Profile"].ToString();
                lblKeySkill.Text = dt.Rows[0]["RSkills"].ToString();

            }
           
        }
        catch (Exception ex)
        {
          
        }
        finally
        {
            ReqBAL = null;

        }
    }

    
   
}