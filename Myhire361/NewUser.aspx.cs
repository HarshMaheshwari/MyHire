using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class NewUser : BaseClass
{
    LoginBAL UserBAL;
    int UsrId;

    protected void Page_Load(object sender, EventArgs e)
    {
        UsrId = Convert.ToInt32(Session["UsrId"]);
        if (!IsPostBack)
        {
            BindManager();
            BindRole();
        }
    }

    private void BindManager()
    {
        UserBAL = new LoginBAL();
        try
        {
            ListItem li = new ListItem("Select","0");
            ddlManager.Items.Clear();
            ddlManager.Items.Add(li);
            ddlManager.DataSource = UserBAL.FillUser();
            ddlManager.DataTextField = "USR_Name";
            ddlManager.DataValueField = "USR_ID";
            ddlManager.DataBind();
        }
        finally
        {
            UserBAL = null;
        }
    }

    private void BindRole()
    {
        UserBAL = new LoginBAL();
        try
        {
            ListItem lis = new ListItem("Select", "0");
            ddlRole.Items.Clear();
            ddlRole.Items.Add(lis);
            ddlRole.DataSource = UserBAL.FillRole();
            ddlRole.DataTextField = "Role_Name";
            ddlRole.DataValueField = "Role_Id";
            ddlRole.DataBind();
        }
        finally
        {
            UserBAL = null;
        }
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        UserBAL = new LoginBAL();
        try
        {
            UserBAL.Name = txtName.Text;
            UserBAL.Email = txtEmail.Text;
            UserBAL.Pswrd = txtPssswrd.Text;
            UserBAL.Role_Id = Convert.ToInt32(ddlRole.SelectedValue);
            UserBAL.ReportingMgrId = Convert.ToInt32(ddlManager.SelectedValue);
            UserBAL.LoggedBy = UsrId;
            int Result = UserBAL.InsertUpdateUser();
            if (Result > 0)
            {
                lblmsg.Text = "Record Saved successfully.";
                lblmsg.ForeColor = System.Drawing.Color.Green;
                Response.Redirect("~/UserList.aspx");
            }
            else
            {
                lblmsg.Text = "Sorry! Record already exists.";
                lblmsg.ForeColor = System.Drawing.Color.Red;
            }
        }
        catch (Exception ex)
        {
            lblmsg.Text = ex.Message.ToString();
        }
        finally
        {
            UserBAL = null;
        }
    }

    protected void btnCncl_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/UserList.aspx");
    }
}