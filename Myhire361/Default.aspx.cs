using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class _Default : System.Web.UI.Page
{
    LoginBAL UsrBAL;
    DataTable dt;
    int UsrRole;
    LoginBAL LgnBal;
    protected void Page_Load(object sender, EventArgs e)
    {
       
    }

    protected void btnLogin_Click(object sender, EventArgs e)
    {
        LgnBal = new LoginBAL();
        UsrBAL = new LoginBAL();
        dt = new DataTable();
        try
        {
            UsrBAL.Email = txtUsrName.Text;
            UsrBAL.Pswrd = txtPsswrd.Text;
            dt = LgnBal.CValidateLogin();
            dt = UsrBAL.ValidateLogin();
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
            UsrBAL = null;
        }
    }
    protected void lbtnCreateNew_Click(object sender, EventArgs e)
    {
        Response.Redirect("SignUpforCandidate.aspx");
    }
    private void MaintainSession(DataTable dt)
    {
        

        Session["UserId"] = dt.Rows[0]["USR_ID"].ToString();
        Session["UserRole"] = dt.Rows[0]["USR_Role"].ToString();
        Session["UserName"] = dt.Rows[0]["USR_Name"].ToString();
        Session["UserEmail"] = dt.Rows[0]["USR_Email"].ToString();
        UsrRole = Convert.ToInt32(Session["UserRole"]);
        if (UsrRole == 4 || UsrRole == 5)
        {
            Response.Redirect("~/ClientHome.aspx");
        }
       
        else
        {
            Response.Redirect("~/Home.aspx");
        }
    }
   
    protected void ImgKnowldg_Click(object sender, ImageClickEventArgs e)
    {
       
    }

    protected void btlFSubmit_Click(object sender, EventArgs e)
    {
        UsrBAL = new LoginBAL();
        SendMail mail=new SendMail();
        try
        {
            dt = new DataTable();
            UsrBAL.Email = txtEmailID.Text;
            dt = UsrBAL.ForgotPassword();
            string UserName = dt.Rows[0]["USR_Name"].ToString();
            string UserEmail = dt.Rows[0]["USR_Email"].ToString();
            string Password = dt.Rows[0]["USR_Password"].ToString();
            mail.ForgotPassword(UserEmail, UserName, Password);
        }
        catch (Exception ex)
        {

        }
        finally
        {
            txtEmailID.Text = "";
            dt = null;
            mail = null;
        }
    }
    protected void imgbtnSignin_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("CanditateLogin.aspx");
    }
}