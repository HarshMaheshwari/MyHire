using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;
using System.Data;

public partial class Masters_StateMaster : BaseClass
{
    AddressBAL addBAL;
    int UserId;
    static DataTable dt;
    Hashtable hsTable;
    CheckExistance chkExistance;
    WS_References WSR;

    protected void Page_Load(object sender, EventArgs e)
    {
        addBAL = new AddressBAL();
        UserId = Convert.ToInt32(Session["UserId"]);

        if (!IsPostBack)
        {
            ListItem li = new ListItem("Select", "0");
            ddlCounrty.Items.Clear();
            ddlCounrty.Items.Add(li);
            ddlCounrty.DataSource = addBAL.FillCountry();
            ddlCounrty.DataTextField = "Cntry_Name";
            ddlCounrty.DataValueField = "Cntry_Id";
            ddlCounrty.DataBind();
            BindState();
        }
    }

    private void BindState()
    {
        addBAL = new AddressBAL();
        try
        {
            dt = new DataTable();
            dt = addBAL.GetState();
            DataView dv = new DataView(dt);
            dv.RowFilter = "Status='" + ddlRecordStatus.SelectedValue + "'";
            if (ViewState["SortExpr"] != null)
                dv.Sort = (string)ViewState["SortExpr"] + " " + (string)ViewState["SortDir"];
            gdvState.DataSource = dv;
            gdvState.DataBind();
        }
        catch (Exception ex)
        {
            lblmsg.Text = ex.Message.ToString();
        }
        finally
        {
            addBAL = null;
        }
    }


    protected void gdvState_Sorting(object sender, GridViewSortEventArgs e)
    {
        ViewState["SortExpr"] = e.SortExpression;
        if (ViewState["SortDir"] != null)
            e.SortDirection = (string)ViewState["SortDir"] == "ASC" ? SortDirection.Descending : SortDirection.Ascending;
        ViewState["SortDir"] = e.SortDirection == SortDirection.Ascending ? "ASC" : "DESC";
        BindState();
    }
    protected void imgbtn_Activate_Click(object sender, EventArgs e)
    {
        lblmsg.Text = "";
        addBAL = new AddressBAL();
        ImageButton lnkbtn = sender as ImageButton;
        GridViewRow row = lnkbtn.NamingContainer as GridViewRow;
        int Id = Convert.ToInt32(gdvState.DataKeys[row.RowIndex].Value.ToString());
        int Status = Convert.ToInt32(((Label)gdvState.Rows[row.RowIndex].FindControl("lblStatus")).Text);
        addBAL.State_Id = Id;
        addBAL.LoggedBy = UserId;
        if (Status == 1)
        {
            addBAL.AStatus = 0;
            addBAL.ChangeStateStatus();
        }
        else
        {
            addBAL.AStatus = 1;
            addBAL.ChangeStateStatus();
        }
        BindState();
    }

    protected void btnInsert_Click(object sender, EventArgs e)
    {
        lblmsg.Text = "";
        addBAL = new AddressBAL();
        chkExistance = new CheckExistance();
        hsTable = new Hashtable();
        WSR = new WS_References();
        try
        {
            addBAL.State_Name = txtState.Text;
            addBAL.ACode = txtCode.Text;
            addBAL.Cntry_Id = Convert.ToInt32(ddlCounrty.SelectedValue);
            addBAL.LoggedBy = UserId;

            hsTable.Add("State_Code", txtCode.Text);
            hsTable.Add("State_Name", txtState.Text);

            if (!chkExistance.ExistanceForInsert(dt, hsTable))
            {

                addBAL.InsertState();
                WSR.WS_InsertState(addBAL.Cntry_Id, addBAL.ACode, addBAL.State_Name, UserId);
                ddlRecordStatus.SelectedValue = "1";
                txtState.Text = null;
                txtCode.Text = null;
                ddlCounrty.SelectedIndex = 0;

                BindState();

                lblmsg.Text = "Record saved successfully.";
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
            addBAL = null;
            chkExistance = null;
            hsTable = null;
        }
    }

    protected void gdvState_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        lblmsg.Text = "";
        gdvState.PageIndex = e.NewPageIndex;
        BindState();
    }

    protected void gdvState_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        lblmsg.Text = "";
        gdvState.EditIndex = -1;
        BindState();
    }

    protected void gdvState_RowEditing(object sender, GridViewEditEventArgs e)
    {
        lblmsg.Text = "";
        gdvState.EditIndex = e.NewEditIndex;
        BindState();
    }

    protected void gdvState_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        lblmsg.Text = "";
        addBAL = new AddressBAL();
        GridViewRow gvr = gdvState.Rows[e.RowIndex];

        chkExistance = new CheckExistance();
        hsTable = new Hashtable();
        WSR = new WS_References();
        try
        {
            addBAL.State_Id = Convert.ToInt32(((Label)gvr.FindControl("lblEId")).Text);
            addBAL.State_Name = (((TextBox)gvr.FindControl("txtEState")).Text);
            addBAL.ACode = (((TextBox)gvr.FindControl("txtECode")).Text);
            addBAL.Cntry_Id = Convert.ToInt32(((DropDownList)gvr.FindControl("ddlECntryName")).SelectedValue);
            addBAL.LoggedBy = UserId;

            hsTable.Add("State_Code", addBAL.ACode);
            hsTable.Add("State_Name", addBAL.State_Name);

            if (!chkExistance.ExistanceForUpdate(dt, hsTable, "State_Id", addBAL.State_Id))
            {

                addBAL.UpdateState();
                WSR.WS_UpdateState(addBAL.State_Name, addBAL.ACode, addBAL.Cntry_Id, UserId, addBAL.State_Id);
                gdvState.EditIndex = -1;
                BindState();

                lblmsg.Text = "Record updated successfully.";
                lblmsg.ForeColor = System.Drawing.Color.Green;
            }
            else
            {
                lblmsg.Text = "Sorry! Record already exists.";
                lblmsg.ForeColor = System.Drawing.Color.Red;
            }

        }
        finally
        {
            addBAL = null;
            chkExistance = null;
            hsTable = null;
        }
    }

    protected void gdvState_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if ((e.Row.RowState & DataControlRowState.Edit) > 0)
            {
                addBAL = new AddressBAL();
                Label lblId = ((Label)e.Row.FindControl("lblECountryId"));
                int id = Convert.ToInt32(lblId.Text);
                DropDownList ddlECntryName = ((DropDownList)e.Row.FindControl("ddlECntryName"));
                ListItem li = new ListItem("Select", "0");
                ddlECntryName.Items.Clear();
                ddlECntryName.Items.Add(li);
                ddlECntryName.DataSource = addBAL.FillCountry();
                ddlECntryName.DataTextField = "Cntry_Name";
                ddlECntryName.DataValueField = "Cntry_Id";
                ddlECntryName.DataBind();
                ddlECntryName.SelectedValue = id.ToString();
            }

            else if (e.Row.RowType == DataControlRowType.DataRow)
            {
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
                Label lbl = (Label)e.Row.FindControl("lblStatus");

            }
        }
        catch (Exception ex)
        {
            lblmsg.Text = ex.Message.ToString();
        }
        finally
        {
            addBAL = null;
        }

    }

    protected void ddlRecordStatus_SelectedIndexChanged(object sender, EventArgs e)
    {
        lblmsg.Text = "";
        BindState();
    }
}