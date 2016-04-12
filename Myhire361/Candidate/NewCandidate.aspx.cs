using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Candidate_NewCandidate : BaseClass
{
    RecruitmentBAL recruitbal;
    AddressBAL addressbal;
    MasterBAL mstBal;
    int CandidateId;
    protected void Page_Load(object sender, EventArgs e)
    {
       
        if (!IsPostBack)
        {
            BindIndustry();
            BindLoaction();

        }
    }
    private void BindLoaction()
    {
        addressbal = new AddressBAL();
        try
        {
            ListItem li = new ListItem("Select", "0");
            ddlLocation.Items.Clear();
            ddlLocation.Items.Add(li);
            ddlLocation.DataSource = addressbal.FillCity();
            ddlLocation.DataTextField = "City_Name";
            ddlLocation.DataValueField = "City_Id";
            ddlLocation.DataBind();
        }
        finally
        {
            addressbal = null;
        }
    }
    private void BindIndustry()
    {
        mstBal = new MasterBAL();
        try
        {
            ListItem li = new ListItem("Select", "0");
            ddlIndustry.Items.Clear();
            ddlIndustry.Items.Add(li);
            ddlIndustry.DataSource = mstBal.FillIndustry();
            ddlIndustry.DataTextField = "IndustryName";
            ddlIndustry.DataValueField = "IndustryId";
            ddlIndustry.DataBind();
        }
        finally
        {
            mstBal = null;
        }
    }
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        recruitbal = new RecruitmentBAL();
        try
        {
            
            recruitbal.CandidateName = txtName.Text;
            recruitbal.Address = txtAddress.Text;
            recruitbal.Telephone = txtPhn.Text;
            recruitbal.MobileNo = txtMobile.Text;
            recruitbal.Dob = txtDob.Text;
            recruitbal.Email = txtEmail.Text;
            recruitbal.WorkExp = txtExperience.Text;
            recruitbal.PrefferedLocation = txtPreferred.Text;
            recruitbal.CurrentEmployer = txtEmployer.Text;
            recruitbal.CurrentDesignation = txtDesg.Text;
            recruitbal.AnnualSalary = txtSalary.Text;
            recruitbal.UgCourse = txtUG.Text;
            recruitbal.PgCourse = txtPG.Text;
            recruitbal.PostPgCourse = txtPost.Text;
            recruitbal.AltEmail = txtAltEmail.Text;
            recruitbal.CandidateSource = txtcandidateSource.Text;
            recruitbal.PAN_Number = txtPanCard.Text;
            recruitbal.Passport_Number = txtPasportNo.Text;
            recruitbal.Issue_Date = txtissueDate.Text;
            recruitbal.Issue_Location = txtIssueLocation.Text;
            recruitbal.AdharCard_Number = txtAdharCard.Text;
            //recruitbal.Industry = txtIndustry.Text;
            //recruitbal.CurrentLocation = txtCurrentLocation.Text;
            recruitbal.Industry = ddlIndustry.SelectedItem.Text;
            recruitbal.CurrentLocation = ddlLocation.SelectedItem.Text;
            recruitbal.Key_Skills = txtKey_Skills.Text.Trim();
            recruitbal.Status = 1;
            int result = recruitbal.InsertCandidate ();
            if (result == 1)
            {
                lblmsg.Text = "Saved Successfully..!";
                Response.Redirect("~/Candidate/AllCandidates.aspx");
            }
        }
        finally
        {
            recruitbal = null;
        }
    }


    protected void btnBack_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Candidate/AllCandidates.aspx");
    }



}