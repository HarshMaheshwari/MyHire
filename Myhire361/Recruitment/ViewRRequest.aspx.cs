using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Recruitment_ViweRRequest : BaseClass
{
    RecruitmentBAL ReqBAL;
   int RequestId, UserId;
  FollowUpBAL FollowBal;
  static string ResumePath,FPath;
 public string filename;
 public string filename1;
 String fname, fpath;

    

    protected void Page_Load(object sender, EventArgs e)
    {
        UserId = Convert.ToInt32(Session["UserId"]);
        RequestId = Convert.ToInt32(Request.QueryString["Id"]);
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
            if (FPath == null || FPath == "")
            {
                //Vjob.Visible = false;
               // Vjob.Visible = true;
            }
           
            

        }
        catch (Exception ex)
        {
            lblmsg.Text = ex.ToString();
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
}