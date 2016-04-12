using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class ViewClient : BaseClass
{
    ClientBAL clientbal;
    int ClientId;

    protected void Page_Load(object sender, EventArgs e)
    {
        ClientId = Convert.ToInt32(Request.QueryString["Id"]);
        if (!IsPostBack)
        {
            BindClient();
        }
    }

    private void BindClient()
    {
        clientbal = new ClientBAL();
        try
        {
            DataTable dt = new DataTable();
            clientbal.ClientId = ClientId;
            dt = clientbal.GetClientById();
            lblCode.Text = dt.Rows[0]["Client_Code"].ToString();
            lblClient.Text = dt.Rows[0]["Client_Name"].ToString();
            lblcntct.Text = dt.Rows[0]["Person_Name"].ToString();
            lblEmail.Text = dt.Rows[0]["Person_Email"].ToString();
            lblDob.Text = dt.Rows[0]["Person_Dob"].ToString();
            lblPhn.Text = dt.Rows[0]["Person_Contact"].ToString();
            lblConsultant.Text = dt.Rows[0]["Usr_Name"].ToString();
            lblDoa.Text = dt.Rows[0]["Person_Anniversary"].ToString();
            lblWebsite.Text = dt.Rows[0]["Client_Website"].ToString();
            lblLocation.Text = dt.Rows[0]["City_Name"].ToString();
            string EmailAlert = dt.Rows[0]["Email_Alert"].ToString();
            if (EmailAlert == "1")
            {
                lblEmailAlert.Text = "Yes";
            }
            else
            {
                lblEmailAlert.Text = "No";
            }
            string SmsAlert=dt.Rows[0]["SMS_Alert"].ToString();
            if (SmsAlert == "1")
            {
                lblSMS.Text = "Yes";
            }
            else
            {
                lblSMS.Text = "No";
            }
            lblClientSource.Text = dt.Rows[0]["ClientSource"].ToString();
            
        }
        finally
        {
            clientbal = null;
        }
    }

    protected void btnBack_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/ClientList.aspx");
    }
}