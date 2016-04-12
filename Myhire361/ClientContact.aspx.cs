using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class ClientContact : BaseClass
{
    ClientBAL clntBAL;
    int ClientId, UserId;

    protected void Page_Load(object sender, EventArgs e)
    {
        UserId = Convert.ToInt32(Session["UserId"]);
        ClientId = Convert.ToInt32(Request.QueryString["Id"]);

        if (!IsPostBack)
        {
            BindPerson();
            Panel1.Visible = false;
            Panel2.Visible = true;
            BindClientHeader();
        }
    }

    protected void BindClientHeader()
    {
        clntBAL = new ClientBAL();
        try
        {
            DataTable dt = new DataTable();
            clntBAL.ClientId = ClientId;
            dt = clntBAL.GetClientById();
            if (dt.Rows.Count>0)
            { 
            lblClientNm.Text = dt.Rows[0]["Client_Name"].ToString();
            lblAssignTo.Text = dt.Rows[0]["Usr_Name"].ToString();
            lblContactName.Text = dt.Rows[0]["Person_Name"].ToString();
            lblContactNo.Text = dt.Rows[0]["Person_Contact"].ToString();

            lblClientNm2.Text = dt.Rows[0]["Client_Name"].ToString();
            lblAssignTo2.Text = dt.Rows[0]["Usr_Name"].ToString();
            lblContactName2.Text = dt.Rows[0]["Person_Name"].ToString();
            lblContactNo2.Text = dt.Rows[0]["Person_Contact"].ToString();
            }
           
        }
        finally
        {
            clntBAL = null;
        }
    }
   

    protected void btnSave_Click(object sender, EventArgs e)
    {
        clntBAL = new ClientBAL();
        try
        {
            clntBAL.ClientId = ClientId;
            clntBAL.PersonName = txtName.Text;
            clntBAL.PersonContact = txtCntct.Text;
            clntBAL.PersonEmail = txtEmail.Text;
            clntBAL.PersonDob = txtDob.Text;
            clntBAL.PersonAnnvrsry = txtDoa.Text;
            clntBAL.IsAdmin = 0;
            clntBAL.LoggedBy = UserId;
            int result = clntBAL.InsertUpdateContactPerson();
            if (result > 1)
            {
                BindPerson();
                lblmsg.Text = "Record Saved successfully.";
                lblmsg.ForeColor = System.Drawing.Color.Green;
                Panel1.Visible = false;
                Panel2.Visible = true;

                txtName.Text = "";
                txtCntct.Text = "";
                txtEmail.Text = "";
                txtDob.Text = "";
                txtDoa.Text = "";
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
            clntBAL = null;
        }
    }

    private void BindPerson()
    {
        clntBAL = new ClientBAL();
        try
        {
            clntBAL.ClientId = ClientId;
            gdvContactPerson.DataSource = clntBAL.GetContactPersonByClient();
            gdvContactPerson.DataBind();
        }
        catch (Exception ex)
        {
            lblmsg.Text = ex.Message.ToString();
        }
        finally
        {
            clntBAL = null;
        }
    }

    protected void gdvContactPerson_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        lblmsg.Text = "";
        gdvContactPerson.PageIndex = e.NewPageIndex;
        BindPerson();
    }

    protected void gdvContactPerson_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        lblmsg.Text = "";
        gdvContactPerson.EditIndex = -1;
        BindPerson();
    }

    protected void gdvContactPerson_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        clntBAL = new ClientBAL();
        GridViewRow gvr = gdvContactPerson.Rows[e.RowIndex];
        try
        {
            clntBAL.ClientId = ClientId;
            clntBAL.PersonId = Convert.ToInt32(((Label)gvr.FindControl("lblEId")).Text);
            clntBAL.PersonName = (((TextBox)gvr.FindControl("txtEName")).Text);
            clntBAL.PersonContact = (((TextBox)gvr.FindControl("txtECtnct")).Text);
            clntBAL.PersonEmail = (((TextBox)gvr.FindControl("txtEEmail")).Text);
            clntBAL.PersonDob = (((TextBox)gvr.FindControl("txtEDob")).Text);
            clntBAL.PersonAnnvrsry = (((TextBox)gvr.FindControl("txtEDoa")).Text);
            clntBAL.LoggedBy = UserId;
            int result = clntBAL.InsertUpdateContactPerson();
            if (result > 0)
            {
                gdvContactPerson.EditIndex = -1;
                BindPerson();
                lblmsg.Text = "Record updated successfully.";
                lblmsg.ForeColor = System.Drawing.Color.Green;
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
            clntBAL = null;
        }
    }

    protected void gdvContactPerson_RowEditing(object sender, GridViewEditEventArgs e)
    {
        lblmsg.Text = "";
        gdvContactPerson.EditIndex = e.NewEditIndex;
        BindPerson();
    }

    protected void gdvContactPerson_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if ((e.Row.RowState & DataControlRowState.Edit) > 0)
        {
            Label lbl = (Label)e.Row.FindControl("lblEStatus");
            if (Convert.ToInt32(lbl.Text) == 1)
            {
               
                lbl.Text = "Active";
            }
            else
            {
               
                lbl.Text = "Inactive";
            }
        }
        else if (e.Row.RowType == DataControlRowType.DataRow)
        {
            ImageButton imgbtnActive = (ImageButton)e.Row.FindControl("imgbtnActivate");
            ImageButton imgbtnInActive = (ImageButton)e.Row.FindControl("imgbtnInActivate");

            Label lbl2 = (Label)e.Row.FindControl("lblStatus");
            if (Convert.ToInt32(lbl2.Text) == 1)
            {
                lbl2.Text = "Active";
                imgbtnInActive.Visible = false;
                imgbtnActive.Visible = true;

            }
            else
            {
                lbl2.Text = "Inactive";
                imgbtnInActive.Visible = true;
                imgbtnActive.Visible = false;
            }

        }
    }

    protected void imgbtn_Activate_Click(object sender, EventArgs e)
    {
        lblmsg.Text = "";
        clntBAL = new ClientBAL();
        ImageButton lnkbtn = sender as ImageButton;
        GridViewRow row = lnkbtn.NamingContainer as GridViewRow;
        int Id = Convert.ToInt32(gdvContactPerson.DataKeys[row.RowIndex].Value.ToString());
        string Status = ((Label)gdvContactPerson.Rows[row.RowIndex].FindControl("lblStatus")).Text;
        clntBAL.PersonId = Id;
        clntBAL.LoggedBy = UserId;
        clntBAL.ClientId = ClientId;
        if (Status == "Active")
        {
            clntBAL.Status = 0;
            clntBAL.ChangeContactPersonStatus();
        }
        else
        {
            clntBAL.Status = 1;
            clntBAL.ChangeContactPersonStatus();
        }
        BindPerson();
    }

    protected void btnNew_Click(object sender, EventArgs e)
    {
        Panel1.Visible = true;
        Panel2.Visible = false;
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Panel1.Visible = false;
        Panel2.Visible = true;
    }

    protected void lbBack_Click(object sender, EventArgs e)
    {
        Response.Redirect("ClientList.aspx");
    }
}