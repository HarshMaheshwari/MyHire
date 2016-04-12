using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ChangePassword : BaseClass
{
    LoginBAL logBAL;
     int  UserId;

    protected void Page_Load(object sender, EventArgs e)
    {
        UserId = Convert.ToInt32(Session["UserId"]);
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        logBAL = new LoginBAL();
        try
        {
            logBAL.Usr_Id = UserId;
            logBAL.CurrentPassword = txtCurrentPassword.Text;
            logBAL.Pswrd = txtCPswrd.Text;
            int result = logBAL.ChangePassword();
            if (result == 0)
            {
                lblMsg.Text = "Current Password is not valid";
                lblMsg.ForeColor = System.Drawing.Color.Red;
            }
            else if (result == 1)
            {
                lblMsg.Text = "Password Changed Successfully";
                lblMsg.ForeColor = System.Drawing.Color.Green;
            }
        }
        catch (Exception ex)
        {

        }
        finally
        {
            logBAL = null;
        }
    }
}