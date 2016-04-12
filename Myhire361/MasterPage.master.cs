using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class MasterPage : System.Web.UI.MasterPage
{
    int UserRole;
    LoginBAL login;
    int LoginID, Usr_Id, USR_ID;
    string Username;

    protected void Page_Load(object sender, EventArgs e)
    {
        login = new LoginBAL();

        if (Session["UserName"] != "")
        {
           // Session["USR_Role"] = "10";
           // USR_ID = Convert.ToInt32(Session["UserId"]);
              UserRole = Convert.ToInt32(Session["UserRole"]);
              Username = (Session["UserName"]).ToString();
              lblUser.Text = "Welcome : " + Username;
              GetMenu(UserRole);

        }
       
        else
        {
            Response.Redirect("~/Default.aspx");
        }
    }

    private void GetMenu(int UserRole)
    {
        switch (UserRole)
        {
            case 1:
                Admn.Visible = true;
                break;
            case 2:
                Mngr.Visible = true;
                break;
            case 3:
                Consltnt.Visible = true;
                break;
            case 4:
                ClientManager.Visible = true;
                break;
            case 7:
                Mngr.Visible = true;
                break;
            case 8:
                Consltnt.Visible = true;
                break;

            case 9:
                Finance.Visible = true;
                break;
            case 6:
                leadMgr.Visible = true;
                break;
            case 10:
                Student.Visible = true;
                break;
           case 13:
                Recruiter.Visible = true;
                break;
           

        }
    }



    protected void lbChangePassword_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/ChangePassword.aspx");
    }

    protected void lbLogout_Click(object sender, EventArgs e)
    {
        try
        {
            login = new LoginBAL();
            login.Usr_Id = Convert.ToInt32(Session["UserId"]);
            login.UpdateLogOutTime();
        }
        finally
        {
            login = null;
            Session.Abandon();
            Session.Clear();
            Response.Redirect("~/Default.aspx");
        }

    }

    //protected void lbtnCandidateLogin_Click(object sender, EventArgs e)
    //{
    //    Response.Redirect("CLogin.aspx?Id=" + "lbtnCandidateLogin");
    //}
    //protected void lbtnReferrerLogin_Click(object sender, EventArgs e)
    //{
    //    Response.Redirect("CLogin.aspx?Id=" + "lbtnReferrerLogin");
    //}
}
