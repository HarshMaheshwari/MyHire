using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class RecMgmt_RRConsultant : BaseClass
{
    LoginBAL loginbal;
     DataTable dt;
     int RequestId, UserId;

    protected void Page_Load(object sender, EventArgs e)
    {
        UserId = Convert.ToInt32(Session["UserId"]);
        RequestId = Convert.ToInt32(Request.QueryString["Id"]);
        if (!IsPostBack)
        {
           
            try
            {
               
                BindGrid();
                BindConsultant();
            }
            catch (Exception ex) { }
          
        }
    }

    protected void BindGrid()
    {
        loginbal = new LoginBAL();

        try
        {
            dt = new DataTable();
            loginbal.Request_Id = RequestId;
            dt = loginbal.GetUserClientRelation();
            DataView dv = new DataView(dt);
            dv.RowFilter = "Status='" + ddlRecordStatus.SelectedValue + "'";
            gdvConsultant.DataSource = dv;
            gdvConsultant.DataBind();
        }
        catch (Exception ex) { }
        finally
        {
            dt = null;
            loginbal = null;
        }
    }

    protected void BindConsultant()
    {
        loginbal = new LoginBAL();
        try
        {
            ListItem li = new ListItem("Select", "0");
            ddlConsultant.Items.Clear();
            ddlConsultant.Items.Add(li);
            ddlConsultant.DataSource = loginbal.FillUser();
            ddlConsultant.DataTextField = "USR_Name";
            ddlConsultant.DataValueField = "USR_ID";
            ddlConsultant.DataBind();
        }
        finally
        {
            loginbal = null;
        }
    }

    protected void ddlRecordStatus_SelectedIndexChanged(object sender, EventArgs e)
    {
        lblmsg.Text = "";
        BindGrid();
    }

    protected void gdvConsultan_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gdvConsultant.PageIndex = e.NewPageIndex;
        BindGrid();
    }

    protected void gdvConsultan_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Label lbl = (Label)e.Row.FindControl("lblStatus");
            if (Convert.ToInt32(lbl.Text) == 1)
            {
                lbl.Text = "Active";
            }
            else
            {
                lbl.Text = "Inactive";
            }
            ImageButton imgbtnActive = (ImageButton)e.Row.FindControl("imgbtnActivate");
            ImageButton imgbtnInActive = (ImageButton)e.Row.FindControl("imgbtnInActivate");
            if (ddlRecordStatus.SelectedIndex == 0)
            {
                imgbtnInActive.Visible = false;
                imgbtnActive.Visible = true;
            }
            else
            {
                imgbtnInActive.Visible = true;
                imgbtnActive.Visible = false;
            }
        }
    }

    protected void lbtndelete_Click(object sender, EventArgs e)
    {
        try
        {
            LinkButton lnkbtn = sender as LinkButton;
            Label lbResume = new Label();
            GridViewRow row = lnkbtn.NamingContainer as GridViewRow;
            string Id = ((Label)(gdvConsultant.Rows[row.RowIndex].FindControl("Id"))).Text.ToString();

        }
        catch (Exception ex) { }
    }

    protected void btnsave_Click(object sender, EventArgs e)
    {
        loginbal = new LoginBAL();
        SendMail mail = new SendMail();
        try
        {
            loginbal.Request_Id = RequestId;
            loginbal.Usr_Id = Convert.ToInt32(ddlConsultant.SelectedValue);
            loginbal.Assign_Date = txtDate.Text;
            loginbal.LoggedBy = UserId;
          
            int Result=Convert.ToInt32(loginbal.InsertUpdateConsultantAssign());
            if (Result > 0)
            {
                dt = new DataTable();
                dt = loginbal.GetConsultantEmail();
                
                string ClientEmail = dt.Rows[0]["ClientEmail"].ToString();
                string DirectorEmail = "aseemgupta@skopeindia.com";
                string ApprovingEmail = dt.Rows[0]["ApprovingEmail"].ToString();
                string ConsultantEmail = dt.Rows[0]["ConsultantEmail"].ToString();
                string Consultant = dt.Rows[0]["Consultant"].ToString();
                string ClientName = dt.Rows[0]["Client_Name"].ToString();
                string RRNo = dt.Rows[0]["RRNumber"].ToString();
                string Designation = dt.Rows[0]["Designation"].ToString();
                string Profile = dt.Rows[0]["Job_Profile"].ToString();
              //  mail.ConsultantAssign(ClientEmail, ApprovingEmail, DirectorEmail, ConsultantEmail, Consultant, ClientName, RRNo, Designation, Profile);
                lblmsg.Text = "Record Saved successfully.";
                BindGrid();
                ddlConsultant.SelectedIndex = 0;
                txtDate.Text = null;
            }
            else
            {
                lblmsg.Text = "Sorry! Record already exists.";
                lblmsg.ForeColor = System.Drawing.Color.Red;
            }

        }
        catch { }
        finally
        {
            dt = null;
            mail = null;
            loginbal = null;

        }
    }

    protected void imgbtn_Activate_Click(object sender, EventArgs e)
    {
        lblmsg.Text = "";
        loginbal = new LoginBAL();
        ImageButton lnkbtn = sender as ImageButton;
        GridViewRow row = lnkbtn.NamingContainer as GridViewRow;
        int Id = Convert.ToInt32(gdvConsultant.DataKeys[row.RowIndex].Value.ToString());
        string Status = ((Label)gdvConsultant.Rows[row.RowIndex].FindControl("lblStatus")).Text;
        loginbal.Relation_Id = Id;
        loginbal.LoggedBy = UserId;
        if (Status == "Active")
        {
            loginbal.Status = 0;
            loginbal.ChangeuserClientrelationStatus();
        }
        else
        {
            loginbal.Status = 1;
            loginbal.ChangeuserClientrelationStatus();
        }
        BindGrid();
    }

    protected void lbBack_Click(object sender, EventArgs e)
    {
        Response.Redirect("RRList.aspx");
    }
}