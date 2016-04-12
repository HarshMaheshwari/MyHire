using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
public partial class SignUpforCandidate : System.Web.UI.Page
{
    HRegisterBAL HRegBal;
    //ServiceReferencess Sr;
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnSignUp_Click(object sender, ImageClickEventArgs e)
    {
        /*HRegBal = new HRegisterBAL();
        Sr = new ServiceReferencess();
        try
        {
            HRegBal.CandidateName = txtFullName.Text;
            HRegBal.Address = "";
            HRegBal.Telephone = "";
            HRegBal.MobileNo = txtMobileNo.Text;
            HRegBal.Dob = "";
            HRegBal.Email = txtEmail.Text;
            HRegBal.WorkExp = "";
            HRegBal.CurrentLocation = "";
            HRegBal.PrefferedLocation = "";
            HRegBal.CurrentEmployer = "";
            HRegBal.CurrentDesignation = "";
            HRegBal.AnnualSalary = "";
            HRegBal.UgCourse = "";
            HRegBal.PgCourse = "";
            HRegBal.PostPgCourse = "";
            HRegBal.AltEmail = "";
            HRegBal.CandidateSource = "";
            HRegBal.PAN_Number = "";
            HRegBal.Passport_Number = "";
            HRegBal.Issue_Date = "";
            HRegBal.Issue_Location = "";
            HRegBal.AdharCard_Number = "";
            HRegBal.Industry = "";
            HRegBal.Passwrd = txtPassword.Text;
            HRegBal.Key_Skills = "";

            int CandidateId = Sr.WS_InsertCandidate(txtFullName.Text, "", "", txtMobileNo.Text, "", txtEmail.Text, "", "", "", "", "", ""
            , "", "", "", "", "", "", "", "", "", "", "", "", "", txtPassword.Text, "", "");

            HRegBal.CandidateId = CandidateId;
            int result = HRegBal.InsertCandidate();
            if (result > 0)
            {
               


                Session["UserName"] = txtFullName.Text;
                Session["UserId"] = CandidateId;
                Session["UserRole"] = "10";
                Session["UserEmail"] = txtEmail.Text;
                Response.Redirect("Dashboard.aspx");
            }
            else
            {
                lblmsg.Text = "Already registered.please login..!";
                lblmsg.ForeColor = System.Drawing.Color.Red;
            }
        }
        catch (Exception ex)
        {
        }
        finally
        {
            HRegBal = null;
        }*/

    }
}