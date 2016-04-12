using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
public partial class CanditateLogin : System.Web.UI.Page
{
    LoginBAL login;
    DataTable dt;
    int CRole, ReqId_Apply, ReqId_Refer;
//   ServiceReferencess Sr;
   // PositionBal PosBal;
    HRegisterBAL HRegBal;
    SendMail mail;
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            ReqId_Refer = Convert.ToInt32(Session["Request_IdReferAllJobs"].ToString());
        }
        catch (Exception ex)
        {
            ReqId_Refer = 0;
        }
        try
        {
            ReqId_Apply = Convert.ToInt32(Session["Request_IdApplyAllJobs"].ToString());
        }
        catch (Exception ex)
        {
            ReqId_Apply = 0;
        }

        //if (Request.Cookies["USR_Name"] != null && Request.Cookies["USR_Password"] != null)
        //{
        //    txtEmail.Text = Request.Cookies["USR_Name"].Value;
        //    txtPassword.Attributes["value"] = Request.Cookies["USR_Password"].Value;
        //}
    }

    protected void btnLogin_Click(object sender, ImageClickEventArgs e)
    {
        //if (cbKeepmeSignIn.Checked)
        //{
        //    Response.Cookies["USR_Name"].Expires = DateTime.Now.AddDays(30);
        //    Response.Cookies["USR_Password"].Expires = DateTime.Now.AddDays(30);
        //}
        //else
        //{
        //    Response.Cookies["USR_Name"].Expires = DateTime.Now.AddDays(-1);
        //    Response.Cookies["USR_Password"].Expires = DateTime.Now.AddDays(-1);
        //}
        //Response.Cookies["USR_Name"].Value = txtEmail.Text.Trim();
        //Response.Cookies["USR_Password"].Value = txtPassword.Text.Trim();

        login = new LoginBAL();
        dt = new DataTable();

        try
        {
            login.Email = txtEmail.Text;
            login.Pswrd = txtPassword.Text;
            dt = login.CValidateLogin();
            if (dt == null || dt.Rows.Count <= 0)
            {
                lblmsg.Text = "Invalid Username or Password.";
                lblmsg.Font.Size = 10;
            }
            else
            {
                MaintainSession(dt);
            }
        }
        catch (Exception ex)
        {
        }
        finally
        {
            login = null;
        }
    }

    private void MaintainSession(DataTable dt)
    {
        mail = new SendMail();
        try
        {
            Session["UserName"] = dt.Rows[0]["USR_Name"].ToString();
            Session["UserId"] = dt.Rows[0]["USR_ID"].ToString();
            Session["UserRole"] = "10";
            Session["UserEmail"] = dt.Rows[0]["USR_Email"].ToString();


            CRole = Convert.ToInt32(Session["UserRole"]);

            login.Usr_Id = Convert.ToInt32(dt.Rows[0]["USR_ID"].ToString());
            int Count = login.GetLoginCount();
            if (Count == 1)
            {
                mail.SendEmailWithoutTable(dt.Rows[0]["USR_Name"].ToString(), dt.Rows[0]["USR_Email"].ToString(), "Login", "", "", "");
            }



            if (CRole == 10)
            {
                if (ReqId_Refer > 0)
                {
                    if (Session["MyReferDetails"] != null)
                    {
                        InsertCandidate();
                    }
                    else
                    {
                        Response.Redirect("ReferJobs.aspx");
                    }
                }
                else if (ReqId_Apply > 0)
                {
                    ApplyJobs(ReqId_Apply, Convert.ToInt32(dt.Rows[0]["USR_ID"].ToString()));
                    Response.Redirect("Dashboard.aspx");
                }
                else
                {
                    Response.Redirect("Dashboard.aspx");
                }
            }

        }
        catch (Exception ex)
        {
        }
        finally
        {
            mail = null;
        }

    }

    public void ApplyJobs(int JobId, int CandidateId)
    {
        //Sr = new ServiceReferencess();
        //PosBal = new PositionBal();
        //try
        //{
        //    Sr.Candidate_Id = CandidateId;
        //    Sr.Request_Id = JobId;
        //    Sr.ReferStatus = "";
        //    Sr.Refere = "No";
        //    Sr.ReferedBy = 0;
        //    Sr.ShowName = "Yes";
        //    Sr.LoggedBy = 0;
        //    int Result = Sr.WS_IH_ApplyJob(Sr.Candidate_Id, Sr.Request_Id, Sr.ReferStatus, Sr.Refere, Sr.ReferedBy, Sr.ShowName, Sr.LoggedBy);
        //    if (Result > 0)
        //    {
        //        PosBal.RRCandidate_Id = Result;
        //        PosBal.Request_Id = JobId;
        //        PosBal.LoggedBy = 0;
        //        PosBal.CandidateId = CandidateId;
        //        PosBal.ReferStatus = "";
        //        PosBal.Refere = "No";
        //        PosBal.ShowName = "Yes";
        //        PosBal.ReferedBy = 0;
        //        PosBal.IH_ApplyJob();
        //    }
        //}
        //catch (Exception ex)
        //{
        //}
        //finally
        //{
        //    PosBal = null;
        //    Sr = null;
        //}
    }

    protected void lbtnForgotPassword_Click(object sender, EventArgs e)
    {
        login = new LoginBAL();
        SendMail mail = new SendMail();
        try
        {
            dt = new DataTable();
            login.Email = txtEmail.Text;
            dt = login.CForgotPassword();
            string UserName = dt.Rows[0]["Candidate_Name"].ToString();
            string UserEmail = dt.Rows[0]["Email"].ToString();
            string Password = dt.Rows[0]["CPassword"].ToString();
            mail.CRForgotPassword(UserEmail, UserName, Password);
            lblmsg.Text = "Password has been sent.";
        }
        catch (Exception ex)
        {

        }
        finally
        {
            txtEmail.Text = "";
            dt = null;
            mail = null;
        }
    }

    protected void lbtnCreateNew_Click(object sender, EventArgs e)
    {
        Response.Redirect("SignUpforCandidate.aspx");
    }

    protected void InsertCandidate()
    {
        HRegBal = new HRegisterBAL();
       // Sr = new ServiceReferencess();
        string ShowName = "No";
        dt = new DataTable();
        dt = (DataTable)Session["MyReferDetails"];

        try
        {
            for (int i = 0; i < dt.Rows.Count; i++)
            {

                HRegBal.CandidateName = dt.Rows[i]["Candidate_Name"].ToString();
                HRegBal.Email = dt.Rows[i]["Email"].ToString();
                HRegBal.MobileNo = dt.Rows[i]["Mobile_No"].ToString();
                HRegBal.CurrentLocation = dt.Rows[i]["Current_Location"].ToString();
                HRegBal.CurrentEmployer = dt.Rows[i]["Current_Employer"].ToString();
                HRegBal.Resume_Path = "";
                HRegBal.LinkedInProfile = "";
                HRegBal.RefrerrerId = Convert.ToInt32(Session["Candidate_Id"].ToString());
                int CandidateId = 0;
               // int CandidateId = Sr.WS_InsertCandidate_forRefer(HRegBal.CandidateName, "", "", HRegBal.MobileNo, "", HRegBal.Email, "",
               //     HRegBal.CurrentLocation, "", HRegBal.CurrentEmployer, "", "",
               //     "", "", "", HRegBal.Resume_Path, "", "", "", "", "", "", "", "", "", "", "", HRegBal.Resume_Path, HRegBal.RefrerrerId);

                ShowName = dt.Rows[i]["ShowName"].ToString();


                if (CandidateId > 0)
                {
                    HRegBal.CandidateId = CandidateId;
                    int result = HRegBal.InsertCandidate();
                    if (result > 0)
                    {
                        ReferJob(CandidateId, ShowName);
                    }
                }
            }

        }
        catch (Exception ex)
        {
            //lblmsg.Text = ex.Message.ToString();
        }
        finally
        {
            Session["Request_IdReferAllJobs"] = null;
        }
    }

    protected void ReferJob(int CandidateId, string ShowName)
    {
    //    Sr = new ServiceReferencess();
    //    PosBal = new PositionBal();
    //    try
    //    {
    //        Sr.Candidate_Id = CandidateId;
    //        Sr.Request_Id = Convert.ToInt32(Session["Request_IdReferAllJobs"].ToString());
    //        Sr.ReferStatus = "";
    //        Sr.ShowName = ShowName;
    //        Sr.Refere = "Yes";
    //        Sr.LoggedBy = 0;
    //        Sr.ReferedBy = Convert.ToInt32(Session["Candidate_Id"].ToString());
    //        int Result = Sr.WS_IH_ReferJob(Sr.Candidate_Id, Sr.Request_Id, Sr.ReferStatus, Sr.Refere, Sr.ReferedBy, Sr.ShowName, Sr.LoggedBy);
    //        if (Result > 0)
    //        {
    //            PosBal.RRCandidate_Id = Result;
    //            PosBal.CandidateId = CandidateId;
    //            PosBal.Request_Id = Convert.ToInt32(Session["Request_IdReferAllJobs"].ToString());
    //            PosBal.ReferStatus = "";
    //            PosBal.Refere = "Yes";
    //            PosBal.ReferedBy = Convert.ToInt32(Session["Candidate_Id"].ToString());
    //            PosBal.LoggedBy = Convert.ToInt32(Session["Candidate_Id"].ToString());
    //            PosBal.ShowName = ShowName;
    //            PosBal.IH_ReferJob();


    //            string msg = "";
    //            msg = "The candidates referred successfully.";
    //            ClientScript.RegisterStartupScript(GetType(), "alert", "alert('" + msg + "');", true);
    //            Response.Redirect("Dashboard.aspx");
    //        }
    //        else
    //        {

    //            string msg = "";
    //            msg = "Already Refered..!";
    //            ClientScript.RegisterStartupScript(GetType(), "alert", "alert('" + msg + "');", true);
    //        }
    //    }
    //    catch (Exception ex)
    //    {
    //    }
    //    finally
    //    {
    //        PosBal = null;
    //    }
    }
}