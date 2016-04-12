﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;

public partial class Candidate_EditCandidate : BaseClass
{
    RecruitmentBAL recruitbal;
    AddressBAL addressbal;
    MasterBAL mstBal;
    int CandidateId;

      public string filename;
    public string filename1;
    String fname, fpath;
    string fileExtention;
      RecruitmentBAL RecBAL;

    protected void Page_Load(object sender, EventArgs e)
    {
        CandidateId = Convert.ToInt32(Request.QueryString["Id"]);
        if (!IsPostBack)
        {
            BindIndustry();
            BindLoaction();
            BindCandidate();
           
            
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
    protected void BindCandidate()
    {
        recruitbal = new RecruitmentBAL();
        try
        {
            DataTable dt = new DataTable();
            recruitbal.CandidateId = CandidateId;
            dt = recruitbal.GetCandidateById();
            txtName.Text = dt.Rows[0]["Candidate_Name"].ToString();
            txtAddress.Text = dt.Rows[0]["Address"].ToString();
            txtPhn.Text = dt.Rows[0]["Telephone_No"].ToString();
            txtMobile.Text = dt.Rows[0]["Mobile_No"].ToString();
            txtDob.Text = dt.Rows[0]["DOB"].ToString();
            txtEmail.Text = dt.Rows[0]["Email"].ToString();
            txtExperience.Text = dt.Rows[0]["WorkExp"].ToString();
          
            txtPreferred.Text = dt.Rows[0]["Preferred_Location"].ToString();
            txtEmployer.Text = dt.Rows[0]["Current_Employer"].ToString();
            txtDesg.Text = dt.Rows[0]["Current_Designation"].ToString();
            txtSalary.Text = dt.Rows[0]["Annual_Salary"].ToString();
            txtUG.Text = dt.Rows[0]["UG_Course"].ToString();
            txtPG.Text = dt.Rows[0]["PG_Course"].ToString();
            txtPost.Text = dt.Rows[0]["PostPG_Course"].ToString();
           txtResumeTitle.Text  = dt.Rows[0]["Resume_Title"].ToString();
            txtLastActivationDate.Text  = dt.Rows[0]["LastActivationDate"].ToString();
       
           txtFunctionalArea.Text  = dt.Rows[0]["Functional_Area"].ToString();
           txtSpecializationArea.Text  = dt.Rows[0]["Specialization_Area"].ToString();
           txtKey_Skills.Text  = dt.Rows[0]["Key_Skills"].ToString();
           txtPreviousEmployer.Text  = dt.Rows[0]["Previous_Employer"].ToString();
           txtEmpLevel.Text = dt.Rows[0]["Emp_Level"].ToString();
           txtSpecialEducation1.Text = dt.Rows[0]["Specialization_Education1"].ToString();
          txtSpecialEducation2.Text  = dt.Rows[0]["Specialization_Education2"].ToString();
          txtUGInstitute.Text = dt.Rows[0]["UG_Institute"].ToString();
          txtPGInstitute.Text  = dt.Rows[0]["PG_Institute"].ToString();
          ddlGender.SelectedValue  = dt.Rows[0]["Gender"].ToString();
          txtAge.Text  = dt.Rows[0]["Age"].ToString();
          txtSource.Text  = dt.Rows[0]["Source"].ToString();

          txtPanCard.Text = dt.Rows[0]["PAN_Number"].ToString();
          txtPasportNo.Text = dt.Rows[0]["Passport_Number"].ToString();
          txtissueDate.Text = dt.Rows[0]["Issue_Date"].ToString();
          txtIssueLocation.Text = dt.Rows[0]["Issue_Location"].ToString();
          txtAdharCard.Text = dt.Rows[0]["AdharCard_Number"].ToString();
          //txtCurrentLocation.Text = dt.Rows[0]["Current_Location"].ToString();
          //txtIndustry.Text = dt.Rows[0]["Industry"].ToString();

            try
            {
          if (dt.Rows[0]["Current_Location"].ToString() != "")
          {
              ddlLocation.Items.FindByText(dt.Rows[0]["Current_Location"].ToString()).Selected = true;
          }
          else
          {
              ddlLocation.SelectedIndex = 0;
          }
              }
            catch (Exception ex)
            {
            }
            finally { }
            
            try{
              
         if (dt.Rows[0]["Industry"].ToString() != "")
        {
          ddlIndustry.Items.FindByText(dt.Rows[0]["Industry"].ToString()).Selected = true;
        }
        else
        {
            ddlIndustry.SelectedIndex = 0;
        }
            }
            catch (Exception ex)
            {
            }
            finally { }
         
          txtcandidateSource.Text = dt.Rows[0]["CandidateSource"].ToString();
          txtAltEmail.Text = dt.Rows[0]["AltEmail"].ToString();
        }
        finally
        {
            recruitbal = null;
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
          // recruitbal.Industry = txtIndustry.Text;
          //  recruitbal.CurrentLocation = txtCurrentLocation.Text;
            recruitbal.Industry = ddlIndustry.SelectedItem.Text;
            recruitbal.CurrentLocation = ddlLocation.SelectedItem.Text;
            recruitbal.ResumeTitle = txtResumeTitle.Text.Trim();
            recruitbal.LastActivationDate = txtLastActivationDate.Text.Trim();
          
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
                        path = path.Substring(path.IndexOf("\\Resume"));
                        recruitbal.Resume_Path = path;
                    }
                    finally
                    {
                    }
                }
            
        

            recruitbal.Functional_Area = txtFunctionalArea.Text.Trim();
            recruitbal.Specialization_Area = txtSpecializationArea.Text.Trim();
            recruitbal.Key_Skills = txtKey_Skills.Text.Trim();
            recruitbal.Previous_Employer = txtPreviousEmployer.Text.Trim();
            recruitbal.Emp_Level = txtEmpLevel.Text.Trim();
            recruitbal.Specialization_Education1 = txtSpecialEducation1.Text.Trim();
            recruitbal.Specialization_Education2 = txtSpecialEducation2.Text.Trim();
           recruitbal.UG_Institute = txtUGInstitute.Text.Trim();
            recruitbal.PG_Institute = txtPGInstitute.Text.Trim();
            recruitbal.Gender = ddlGender.SelectedValue.ToString() ;
            recruitbal.Age = txtAge.Text.Trim();
            recruitbal.Source = txtSource.Text.Trim();



            recruitbal.CandidateId = CandidateId;
            int result = recruitbal.UpdateCandidate();
            if (result==1)
            {
                lblmsg.Text = "Updated Successfully..!";
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