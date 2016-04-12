using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class ForgotPassword : System.Web.UI.Page
{
    string Email;
    
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnForgot_Click(object sender, EventArgs e)
    {
        Email = txtEMail.Text;
    }
}