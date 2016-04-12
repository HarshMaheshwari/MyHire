using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Recruitment_ViewCandidate : BaseClass
{
    RecruitmentBAL recruitbal;
    int CandidateId;
    protected void Page_Load(object sender, EventArgs e)
    {
        CandidateId = Convert.ToInt32(Request.QueryString["Id"]);
        if (!IsPostBack)
        {
            BindCandidate();
        }
    }
    protected void BindCandidate()
    {
        recruitbal = new RecruitmentBAL();
        try
        {
            DataTable dt = new DataTable();
            recruitbal.CandidateId = CandidateId;
            dt = recruitbal.GetCandidateById();
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
        catch { }
        finally
        {
            recruitbal = null;
        }
    }
    protected void btnBack_Click(object sender, EventArgs e)
    {

        Response.Redirect("AllCandidates.aspx");
       
    }
    
}