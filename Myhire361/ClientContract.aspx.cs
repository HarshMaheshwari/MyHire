using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class ClientContract : BaseClass
{
    ClientBAL clntBAL;
    int ClientId, UserId;

    protected void Page_Load(object sender, EventArgs e)
    {
        UserId = Convert.ToInt32(Session["UserId"]);
        ClientId = Convert.ToInt32(Request.QueryString["Id"]);

        if (!IsPostBack)
        {
            BindContract();
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
            if (dt.Rows.Count > 0)
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
    private void BindContract()
    {
        clntBAL = new ClientBAL();
        try
        {
            clntBAL.ClientId = ClientId;
            gdvContracts.DataSource = clntBAL.GetContractByClient();
            gdvContracts.DataBind();
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

    protected void btnSave_Click(object sender, EventArgs e)
    {
        clntBAL = new ClientBAL();
        try
        {
            clntBAL.ClientId = ClientId;
            clntBAL.ContractCode = txtCode.Text;
            clntBAL.Description = txtDesc.Text;
            clntBAL.ClientType = Convert.ToInt32(ddlClientType.SelectedValue);
            clntBAL.StartDate = txtStartDate.Text;
            clntBAL.EndDate = txtEndDate.Text;
            clntBAL.Renwal = Convert.ToInt32(rbtnAlert.SelectedValue);
            clntBAL.LoggedBy = UserId;
            if (txtRatePer.Text != "")
            {
                clntBAL.RatePer = Convert.ToDouble(txtRatePer.Text);
            }
            else
            {
                clntBAL.RatePer = 0;
            }
            clntBAL.BillDate = Convert.ToInt32(ddlBillDate.SelectedValue);
            if (txtPayTerms.Text != "")
            {
                clntBAL.PaymentTearms = Convert.ToInt32(txtPayTerms.Text);
            }
            else
            {
                clntBAL.PaymentTearms = 0;

            }
            if (txtAlertBDay.Text != "")
            {
            clntBAL.AlertBeforeDays =Convert.ToInt32(txtAlertBDay.Text);
            }
            else
            {
                clntBAL.AlertBeforeDays = 0;
             }
            clntBAL.InsertClientContract();
            BindContract();
            lblmsg.Text = "Record Saved successfully.";
            lblmsg.ForeColor = System.Drawing.Color.Green;
            Panel1.Visible = false;
            Panel2.Visible = true;
        }
        catch (Exception ex)
        {
            lblmsg.Text = ex.Message.ToString();
        }
        finally
        {
            clntBAL = null;
            txtCode.Text = "";
            txtDesc.Text = "";
            ddlClientType.SelectedIndex = 0;
            ddlBillDate.SelectedIndex = 0;
            txtRatePer.Text = "";
            txtPayTerms.Text = "";
            txtAlertBDay.Text = "";
            txtStartDate.Text = "";
            txtEndDate.Text = "";
        }
    }

    protected void gdvContracts_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        lblmsg.Text = "";
        gdvContracts.PageIndex = e.NewPageIndex;
        BindContract();
    }

    protected void gdvContracts_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        lblmsg.Text = "";
        gdvContracts.EditIndex = -1;
        BindContract();
    }

    protected void gdvContracts_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        clntBAL = new ClientBAL();
        GridViewRow gvr = gdvContracts.Rows[e.RowIndex];
        try
        {
            clntBAL.ClientId = ClientId;
            clntBAL.ContractId = Convert.ToInt32(((Label)gvr.FindControl("lblEId")).Text);
            clntBAL.ContractCode = ((TextBox)gvr.FindControl("txtECode")).Text;
            clntBAL.Description = ((TextBox)gvr.FindControl("txtEDesc")).Text;
            clntBAL.ClientType =Convert.ToInt32(((DropDownList)gvr.FindControl("ddlEClientType")).SelectedValue);
            clntBAL.BillDate = Convert.ToInt32(((DropDownList)gvr.FindControl("ddlEBilldate")).SelectedValue);
            clntBAL.RatePer = Convert.ToDouble(((TextBox)gvr.FindControl("txtERatePer")).Text);
            clntBAL.PaymentTearms = Convert.ToInt32(((TextBox)gvr.FindControl("txtEPayTerms")).Text);
            clntBAL.AlertBeforeDays = Convert.ToInt32(((TextBox)gvr.FindControl("txtEAlertBD")).Text);

            clntBAL.StartDate = ((TextBox)gvr.FindControl("txtESDate")).Text;
            clntBAL.EndDate = ((TextBox)gvr.FindControl("txtEEDate")).Text; ;
            clntBAL.Renwal = Convert.ToInt32(((RadioButtonList)gvr.FindControl("rbtnEAlert")).SelectedValue);
            clntBAL.LoggedBy = UserId;
            clntBAL.UpdateContract();
            gdvContracts.EditIndex = -1;
            BindContract();
            lblmsg.Text = "Record updated successfully.";
            lblmsg.ForeColor = System.Drawing.Color.Green;
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

    protected void gdvContracts_RowEditing(object sender, GridViewEditEventArgs e)
    {
        lblmsg.Text = "";
        gdvContracts.EditIndex = e.NewEditIndex;
        BindContract();
    }

    protected void gdvContracts_RowDataBound(object sender, GridViewRowEventArgs e)
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
            Label lblRenwal = (Label)e.Row.FindControl("lblEAlert");
            RadioButtonList rbalert = (RadioButtonList)e.Row.FindControl("rbtnEAlert");
            rbalert.SelectedValue = lblRenwal.Text;

            Label lblClientTypeId = (Label)e.Row.FindControl("lblClientTypeId");
            DropDownList ddlEClientType=(DropDownList )e.Row.FindControl("ddlEClientType");
            if (lblClientTypeId.Text == "1")
            {
                ddlEClientType.SelectedValue = "1";
            }
            else
            {
                ddlEClientType.SelectedValue = "2";
            }
            Label lblBilldateId = (Label)e.Row.FindControl("lblBilldateId");
            DropDownList ddlEBilldate = (DropDownList)e.Row.FindControl("ddlEBilldate");
            if (lblBilldateId.Text == "1")
            {
                ddlEBilldate.SelectedValue = "1";
            }
            else
            {
                ddlEBilldate.SelectedValue = "2";
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
            Label lblAlert = (Label)e.Row.FindControl("lblAlert");
           
            if (lblAlert.Text == "1")
            {
                lblAlert.Text = "Yes";
            }
            else
            {
                lblAlert.Text = "No";
            }
        }
    }

    protected void imgbtn_Activate_Click(object sender, EventArgs e)
    {
        lblmsg.Text = "";
        clntBAL = new ClientBAL();
        ImageButton lnkbtn = sender as ImageButton;
        GridViewRow row = lnkbtn.NamingContainer as GridViewRow;
        int Id = Convert.ToInt32(gdvContracts.DataKeys[row.RowIndex].Value.ToString());
        string Status = ((Label)gdvContracts.Rows[row.RowIndex].FindControl("lblStatus")).Text;
        clntBAL.ContractId = Id;
        clntBAL.LoggedBy = UserId;
        clntBAL.ClientId = ClientId;
        if (Status == "Active")
        {
            clntBAL.Status = 0;
            clntBAL.ChangeContractStatus();
        }
        else
        {
            clntBAL.Status = 1;
            clntBAL.ChangeContractStatus();
        }
        BindContract();
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