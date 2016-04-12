using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class ClientAddress : BaseClass 
{
    AddressBAL addBAL;
    ClientBAL ClntBAL;
     int ClientId, UserId;

    protected void Page_Load(object sender, EventArgs e)
    {
        UserId = Convert.ToInt32(Session["UserId"]);
        ClientId = Convert.ToInt32(Request.QueryString["Id"]);

        if (!IsPostBack)
        {
           
            Panel1.Visible = false;
            Panel2.Visible = true;
            BindCountry(ddlCountry);
            BindClientAddress();
            BindClientHeader();
        }
    }

    protected void BindClientHeader()
    {
        ClntBAL = new ClientBAL();
        try
        {
            DataTable dt = new DataTable();
            ClntBAL.ClientId = ClientId;
            dt = ClntBAL.GetClientById();
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
            ClntBAL = null;
        }
    }
    private void BindClientAddress()
    {
        ClntBAL = new ClientBAL();
        try
        {
            ClntBAL.ClientId = ClientId;
            gdvAddress.DataSource = ClntBAL.GetAddressByClient();
            gdvAddress.DataBind();
        }
        catch (Exception ex)
        {
            lblmsg.Text = "Sorry : " + ex.Message.ToString();
        }
        finally
        {
            ClntBAL = null;
        }
    }

    private void BindCountry(DropDownList ddl)
    {
        try
        {
            addBAL = new AddressBAL();
            ListItem li = new ListItem("Select", "0");
            ddl.Items.Clear();
            ddl.Items.Add(li);
            ddl.DataSource = addBAL.FillCountry();
            ddl.DataTextField = "Cntry_Name";
            ddl.DataValueField = "Cntry_Id";
            ddl.DataBind();
        }
        catch (Exception ex)
        {
            lblmsg.Text = "Error Code : " + ex.Message.ToString();
        }
        finally
        {
            addBAL = null;
        }
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        ClntBAL = new ClientBAL();
        try
        {
            ClntBAL.ClientId = ClientId;
            ClntBAL.AddressType = ddlAddress.SelectedItem.Text;
            ClntBAL.Address = txtAddress.Text;
            ClntBAL.CntryId = Convert.ToInt32(ddlCountry.SelectedValue);
            ClntBAL.StateId = Convert.ToInt32(ddlState.SelectedValue);
            ClntBAL.CityId = Convert.ToInt32(ddlCity.SelectedValue);
            ClntBAL.Pincode = txtPincode.Text;
            ClntBAL.LoggedBy = UserId;
            ClntBAL.InsertClientAddress();
            BindClientAddress();
            Panel1.Visible = false;
            Panel2.Visible = true;
        }
        catch (Exception ex)
        {
        }
        finally
        {
            ClntBAL = null;
            ddlAddress.SelectedIndex = 0;
            txtAddress.Text = "";
            ddlCountry.SelectedIndex = 0;
            ddlState.SelectedIndex = 0;
            ddlCity.SelectedIndex = 0;
            txtPincode.Text = "";
        }
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Panel1.Visible = false;
        Panel2.Visible = true;
    }

    protected void btnNew_Click(object sender, EventArgs e)
    {
        Panel1.Visible = true;
        Panel2.Visible = false;
    }

    protected void ddlCountry_SelectedIndexChanged(object sender, EventArgs e)
    {
        addBAL = new AddressBAL();
        try
        {
            ListItem li = new ListItem("Select", "0");
            ddlState.Items.Clear();
            ddlState.Items.Add(li);
            addBAL.Cntry_Id = Convert.ToInt32(ddlCountry.SelectedValue);
            ddlState.DataSource = addBAL.GetStateById();
            ddlState.DataTextField = "State_Name";
            ddlState.DataValueField = "State_Id";
            ddlState.DataBind();
        }
        catch (Exception ex)
        {
            lblmsg.Text = "Error Code : " + ex.Message.ToString();
        }
        finally
        {
            addBAL = null;
        }
    }

    protected void ddlState_SelectedIndexChanged(object sender, EventArgs e)
    {
        addBAL = new AddressBAL();
        try
        {
            ListItem li = new ListItem("Select", "0");
            ddlCity.Items.Clear();
            ddlCity.Items.Add(li);
            addBAL.State_Id = Convert.ToInt32(ddlState.SelectedValue);
            ddlCity.DataSource = addBAL.GetCityById();
            ddlCity.DataTextField = "City_Name";
            ddlCity.DataValueField = "City_Id";
            ddlCity.DataBind();
        }
        catch (Exception ex)
        {
            lblmsg.Text = "Error Code : " + ex.Message.ToString();
        }
        finally
        {
            addBAL = null;
        }
    }

    protected void gdvAddress_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        lblmsg.Text = "";
        gdvAddress.PageIndex = e.NewPageIndex;
        BindClientAddress();
    }

    protected void gdvAddress_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        lblmsg.Text = "";
        gdvAddress.EditIndex = -1;
        BindClientAddress();
    }

    protected void gdvAddress_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        lblmsg.Text = "";
        ClntBAL = new ClientBAL();
        GridViewRow gvr = gdvAddress.Rows[e.RowIndex];
        try
        {
            ClntBAL.ClientId = ClientId;
            ClntBAL.AddressId = Convert.ToInt32(((Label)gvr.FindControl("lblEId")).Text);
            ClntBAL.AddressType = ((DropDownList)gvr.FindControl("ddlEAddress")).SelectedItem.Text;
            ClntBAL.Address = ((TextBox)gvr.FindControl("txtAddress")).Text;
            ClntBAL.CntryId = Convert.ToInt32(((DropDownList)gvr.FindControl("ddlECountry")).SelectedValue);
            ClntBAL.StateId = Convert.ToInt32(((DropDownList)gvr.FindControl("ddlEState")).SelectedValue);
            ClntBAL.CityId = Convert.ToInt32(((DropDownList)gvr.FindControl("ddlECity")).SelectedValue);
            ClntBAL.Pincode = ((TextBox)gvr.FindControl("txtEPincode")).Text;
            ClntBAL.LoggedBy = UserId;
            ClntBAL.UpdateClientAddress();
            gdvAddress.EditIndex = -1;
            BindClientAddress();
        }
        catch (Exception ex)
        {
            lblmsg.Text = ex.Message.ToString();
        }
        finally
        {
            ClntBAL = null;
        }
    }

    protected void gdvAddress_RowEditing(object sender, GridViewEditEventArgs e)
    {
        lblmsg.Text = "";
        gdvAddress.EditIndex = e.NewEditIndex;
        BindClientAddress();
    }

    protected void gdvAddress_RowDataBound(object sender, GridViewRowEventArgs e)
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
            //---Country----//
            Label lblId = ((Label)e.Row.FindControl("lblECountryId"));
            DropDownList ddlECntryName = ((DropDownList)e.Row.FindControl("ddlECountry"));
            BindCountry(ddlECntryName);
            ddlECntryName.SelectedValue = lblId.Text;
            //-----State----//
            Label lblStateId = ((Label)e.Row.FindControl("lblEStateId"));
            DropDownList ddlEState = ((DropDownList)e.Row.FindControl("ddlEState"));
          
            addBAL = new AddressBAL();
            ddlEState.DataSource = addBAL.FillState();
            ddlEState.DataTextField = "State_Name";
            ddlEState.DataValueField = "State_Id";
            ddlEState.DataBind();
            ddlEState.SelectedValue = lblStateId.Text;
            //-----City-----//
            Label lblCityId = ((Label)e.Row.FindControl("lblECityId"));
            DropDownList ddlECity = ((DropDownList)e.Row.FindControl("ddlECity"));
           
            ddlECity.DataSource = addBAL.FillCity();
            ddlECity.DataTextField = "City_Name";
            ddlECity.DataValueField = "City_Id";
            ddlECity.DataBind();
            ddlECity.SelectedValue = lblCityId.Text;

            //---------Address Type-----//
            Label lblAddType = ((Label)e.Row.FindControl("lblEType"));
            DropDownList ddlAddType = ((DropDownList)e.Row.FindControl("ddlEAddress"));
            ddlAddType.Items.FindByText(lblAddType.Text).Selected = true;
            
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
        ClntBAL = new ClientBAL();
        ImageButton lnkbtn = sender as ImageButton;
        GridViewRow row = lnkbtn.NamingContainer as GridViewRow;
        int Id = Convert.ToInt32(gdvAddress.DataKeys[row.RowIndex].Value.ToString());
        string Status = ((Label)gdvAddress.Rows[row.RowIndex].FindControl("lblStatus")).Text;
        ClntBAL.AddressId = Id;
        ClntBAL.ClientId = ClientId;
        ClntBAL.LoggedBy = UserId;
        if (Status == "Active")
        {
            ClntBAL.Status = 0;
            ClntBAL.ChangeAddressStatus();
        }
        else
        {
            ClntBAL.Status = 1;
            ClntBAL.ChangeAddressStatus();
        }
        BindClientAddress();
    }

    protected void ddlECountry_SelectedIndexChanged(object sender, EventArgs e)
    {
        addBAL = new AddressBAL();
        try
        {
            DropDownList ddlEC = sender as DropDownList;
            GridViewRow row = ddlEC.NamingContainer as GridViewRow;
            DropDownList ddlstate = ((DropDownList)gdvAddress.Rows[row.RowIndex].FindControl("ddlEState"));
            addBAL.Cntry_Id = Convert.ToInt32(ddlEC.SelectedValue);
            ListItem li = new ListItem("Select", "0");
            ddlstate.Items.Clear();
            ddlstate.Items.Add(li);
            ddlstate.DataSource = addBAL.GetStateById();
            ddlstate.DataTextField = "State_Name";
            ddlstate.DataValueField = "State_Id";
            ddlstate.DataBind();
        }
        finally
        {
            addBAL = null;
        }
    }

    protected void ddlEState_SelectedIndexChanged(object sender, EventArgs e)
    {
        addBAL = new AddressBAL();
        try
        {
            DropDownList ddlES = sender as DropDownList;
            GridViewRow row = ddlES.NamingContainer as GridViewRow;

            DropDownList ddlECity = ((DropDownList)gdvAddress.Rows[row.RowIndex].FindControl("ddlECity"));
            addBAL.State_Id = Convert.ToInt32(ddlES.SelectedValue);
            ListItem li = new ListItem("Select", "0");
            ddlECity.Items.Clear();
            ddlECity.Items.Add(li);
            ddlECity.DataSource = addBAL.GetCityById();
            ddlECity.DataTextField = "City_Name";
            ddlECity.DataValueField = "City_Id";
            ddlECity.DataBind();

        }
        finally
        {
            addBAL = null;
        }
    }

    protected void lbBack_Click(object sender, EventArgs e)
    {
        Response.Redirect("ClientList.aspx");
    }
}