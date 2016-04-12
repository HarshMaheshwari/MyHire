using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

public partial class Recruitment_CandidateForm : BaseClass
{
    RecruitmentBAL RecBAL;
    AddressBAL addressbal;
    MasterBAL mstBal;
    int UserId,RequestId,CandidateId;
    public string filename;
    public string filename1;
    String fname, fpath;
    string fileExtention;

    protected void Page_Load(object sender, EventArgs e)
    {
        UserId = Convert.ToInt32(Session["UserId"]);
        RequestId = Convert.ToInt32(Session["Rid"]);
        if (!Page.IsPostBack) 
        {
            BindIndustry();
            BindLoaction();
        }
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        RecBAL = new RecruitmentBAL();
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
                    CandidateId = RecBAL.GetMaxCandidate();
                    path = path + +CandidateId + fileExtention;

                    fileUpload.SaveAs(path);
                    path = path.Substring(path.IndexOf("\\Resume"));
                    RecBAL.Resume_Path = path;
                }
                finally
                {
                }
            }
            RecBAL.Request_Id = RequestId;
            RecBAL.CandidateName = txtName.Text;
            RecBAL.Dob = txtDob.Text;
         
            RecBAL.MobileNo = txtMobile.Text;
            RecBAL.Address = txtAddress.Text;
            RecBAL.Email = txtEmail.Text;
            RecBAL.Previous_Employer = txtPreEmployer.Text;
            RecBAL.UG_Institute = txtUGInstitute.Text;
            RecBAL.PG_Institute = txtPGInstitute.Text;
            RecBAL.CurrentEmployer = txtEmployer.Text;
            RecBAL.CurrentDesignation = txtDesg.Text;
            RecBAL.AnnualSalary = txtSalary.Text;
            RecBAL.WorkExp = txtExperience.Text;
            RecBAL.UgCourse = txtUG.Text;
            RecBAL.PgCourse = txtPG.Text;
            RecBAL.PostPgCourse = txtPost.Text;
            RecBAL.CandidateSource = txtcandidateSource.Text;
           RecBAL.Status = Convert.ToInt32(ddlStatus.SelectedValue);
           // RecBAL.Industry = txtIndustry.Text;
           // RecBAL.CurrentLocation = txtCurrentLocation.Text;
            RecBAL.Industry = ddlIndustry.SelectedItem.Text;
            RecBAL.CurrentLocation = ddlLocation.SelectedItem.Text;
            RecBAL.LoggedBy = UserId;
            RecBAL.ConsultantId = UserId;
            RecBAL.Source = "Self";
            int Result = Convert.ToInt32(RecBAL.UploadCandidate());
            if (Result == 1)
            {
                lblmsg.Text = "Saved Successfully..!";
                Response.Redirect("CandidateList.aspx");
            }
        }
        catch (Exception ex)
        {
            lblmsg.Text = ex.ToString();
        }
        finally
        {
            RecBAL = null;
        }
    }


    protected void btnBack_Click(object sender, EventArgs e)
    {
        Response.Redirect("RRList.aspx");
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
}