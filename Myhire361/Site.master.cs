using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Site : System.Web.UI.MasterPage
{
    MasterBAL MstrBal;
    int CandidateId, UserRole;
    int Islogin = 0;
   // CandidateDetailsBAL CandidateDetails;
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (Session["USR_Email"] == null || Session["USR_Email"].ToString() == "")
            {
                Islogin = 0;
            }
            else
            {
                Islogin = 1;
            }
        }
        catch (Exception ex) { }

        if (Session["USR_ID"] != null || Session["USR_Name"] != null)
        {
           // UserRole = Convert.ToInt32(Session["CRole"]);
            CandidateId = Convert.ToInt32(Session["USR_ID"].ToString());
            if (Session["USR_Role"].ToString() == "10")
            {
                SignIn.Visible = false;
                MyAccount.Visible = true;
            }
            else
            {
                
                SignIn.Visible = true;
                MyAccount.Visible = false;
            }
        }
        else
        {
            SignIn.Visible = true;
            MyAccount.Visible = false;
        }
        if (!IsPostBack)
        {
            BindFunctioanlArea();
            BindIndustry();
            //GetCandidateReferrIndustry();
        }
    }

    protected void lbAlerts_Click(object sender, EventArgs e)
    {
    //    try
    //    {
    //        if(Islogin==0)
    //        {

    //        }
    //        else
    //        {

    //        }
    //    }
      Session["HomeLocation"] = "Alert".ToLower();
       Response.Redirect("~/AllJobs.aspx");
    }

    protected void lbNCR_Click(object sender, EventArgs e)
    {
        Session["HomeLocation"] = "Delhi".ToLower();
        Response.Redirect("~/AllJobs.aspx");
    }
    protected void lbMumbai_Click(object sender, EventArgs e)
    {
        Session["HomeLocation"] = "Mumbai".ToLower();
        Response.Redirect("~/AllJobs.aspx");
    }
    protected void lbBanglore_Click(object sender, EventArgs e)
    {
        Session["HomeLocation"] = "Banglore".ToLower();
        Response.Redirect("~/AllJobs.aspx");
    }
    protected void lbChennia_Click(object sender, EventArgs e)
    {
        Session["HomeLocation"] = "Chennia".ToLower();
        Response.Redirect("~/AllJobs.aspx");
    }
    protected void lbHyderabad_Click(object sender, EventArgs e)
    {
        Session["HomeLocation"] = "Hyderabad".ToLower();
        Response.Redirect("~/AllJobs.aspx");
    }
    protected void lbSales_Click(object sender, EventArgs e)
    {
        Session["HomeArea"] = "Sales".ToLower();
        Response.Redirect("~/AllJobs.aspx");
    }
    protected void lbResourse_Click(object sender, EventArgs e)
    {
        Session["HomeArea"] = "Human resources".ToLower();
        Response.Redirect("~/AllJobs.aspx");
    }
    protected void lbOperational_Click(object sender, EventArgs e)
    {
        Session["HomeArea"] = "Operations".ToLower();
        Response.Redirect("~/AllJobs.aspx");
    }
    protected void lbIT_Click(object sender, EventArgs e)
    {
        Session["HomeArea"] = "Information technology".ToLower();
        Response.Redirect("~/AllJobs.aspx");
    }
    protected void lbMarketing_Click(object sender, EventArgs e)
    {
        Session["HomeArea"] = "Marketing".ToLower();
        Response.Redirect("~/AllJobs.aspx");
    }

    private void BindFunctioanlArea()
    {
        MstrBal = new MasterBAL();
        try
        {
            ListItem li = new ListItem("Select", "0");
            ddlFunctionalArea.Items.Clear();
            ddlFunctionalArea.Items.Add(li);
            ddlFunctionalArea.DataSource = MstrBal.FillFunctionalArea();
            ddlFunctionalArea.DataTextField = "FunctAreaName";
            ddlFunctionalArea.DataValueField = "FunctAreaId";
            ddlFunctionalArea.DataBind();
        }
        finally
        {
            MstrBal = null;
        }
    }

    private void BindIndustry()
    {
        MstrBal = new MasterBAL();
        try
        {
            ListItem li = new ListItem("Select", "0");
            ddlIndustry.Items.Clear();
            ddlIndustry.Items.Add(li);
            //ddlIndustry.DataSource = MstrBal.GetIndusrtyForTree();
            ddlIndustry.DataTextField = "IndustryName";
            ddlIndustry.DataValueField = "IndustryId";
            ddlIndustry.DataBind();
        }
        finally
        {
            MstrBal = null;
        }
    }

    private void GetCandidateReferrIndustry()
    {
        MstrBal = new MasterBAL();
        try
        {
            //MstrBal.Candidate_Id = CandidateId;
            //gdvReffer.DataSource = MstrBal.GetMyPrefenceDetails();
            //gdvReffer.DataBind();
        }
        finally
        {
            //CandidateDetails = null;
        }
    }
  
}
