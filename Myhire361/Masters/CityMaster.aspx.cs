using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Collections;

public partial class Masters_CityMaster : BaseClass
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
            ddlState.Items.Clear();
            ddlState.Items.Add(li);
            ddlState.DataSource = addBAL.FillState();
            ddlState.DataTextField = "State_Name";
            ddlState.DataValueField = "State_Id";
            ddlState.DataBind();
            BindCity();
        }
    }

    private void BindCity()
    {
        addBAL = new AddressBAL();
        try
        {
            dt = new DataTable();
            dt = addBAL.GetCity();
            DataView dv = new DataView(dt);
            dv.RowFilter = "Status='" + ddlRecordStatus.SelectedValue + "'";
            if (ViewState["SortExpr"] != null)
                dv.Sort = (string)ViewState["SortExpr"] + " " + (string)ViewState["SortDir"];
            gdvCity.DataSource = dv;
            gdvCity.DataBind();
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


    protected void gdvCity_Sorting(object sender, GridViewSortEventArgs e)
    {
        ViewState["SortExpr"] = e.SortExpression;
        if (ViewState["SortDir"] != null)
            e.SortDirection = (string)ViewState["SortDir"] == "ASC" ? SortDirection.Descending : SortDirection.Ascending;
        ViewState["SortDir"] = e.SortDirection == SortDirection.Ascending ? "ASC" : "DESC";
        BindCity();
    }
    protected void gdvCity_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        lblmsg.Text = "";
        gdvCity.PageIndex = e.NewPageIndex;
        BindCity();
    }

    protected void gdvCity_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        lblmsg.Text = "";
        gdvCity.EditIndex = -1;
        BindCity();
    }

    protected void gdvCity_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        addBAL = new AddressBAL();
        try
        {
            if ((e.Row.RowState & DataControlRowState.Edit) > 0)
            {
                Label lblId = ((Label)e.Row.FindControl("lblEStateId"));
                int id = Convert.ToInt32(lblId.Text);
                DropDownList ddlEState = ((DropDownList)e.Row.FindControl("ddlEState"));
                ListItem li = new ListItem("Select", "0");
                ddlEState.Items.Clear();
                ddlEState.Items.Add(li);
                ddlEState.DataSource = addBAL.FillState();
                ddlEState.DataTextField = "State_Name";
                ddlEState.DataValueField = "State_Id";
                ddlEState.DataBind();
                ddlEState.SelectedValue = id.ToString();
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

    protected void gdvCity_RowEditing(object sender, GridViewEditEventArgs e)
    {
        lblmsg.Text = "";
        gdvCity.EditIndex = e.NewEditIndex;
        BindCity();
    }

    protected void gdvCity_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        lblmsg.Text = "";
        addBAL = new AddressBAL();
        GridViewRow gvr = gdvCity.Rows[e.RowIndex];
        WSR = new WS_References();
        chkExistance = new CheckExistance();
        hsTable = new Hashtable();

        try
        {
            addBAL.City_Id = Convert.ToInt32(((Label)gvr.FindControl("lblEId")).Text);
            addBAL.City_Name = (((TextBox)gvr.FindControl("txtECity")).Text);
            addBAL.ACode = (((TextBox)gvr.FindControl("txtECode")).Text);
            addBAL.State_Id = Convert.ToInt32(((DropDownList)gvr.FindControl("ddlEState")).SelectedValue);
            addBAL.LoggedBy = UserId;

            hsTable.Add("City_Code", addBAL.ACode);
            hsTable.Add("City_Name", addBAL.City_Name);

            if (!chkExistance.ExistanceForUpdate(dt, hsTable, "City_Id", addBAL.City_Id))
            {
                addBAL.UpdateCity();
                WSR.WS_UpdateState(addBAL.City_Name, addBAL.ACode,addBAL.State_Id, UserId,addBAL.City_Id);
                gdvCity.EditIndex = -1;
                lblmsg.Text = "Record Updated successfully.";
                lblmsg.ForeColor = System.Drawing.Color.Green;
                BindCity();
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

    protected void btnInsert_Click(object sender, EventArgs e)
    {
        lblmsg.Text = "";
        addBAL = new AddressBAL();
        chkExistance = new CheckExistance();
        hsTable = new Hashtable();
        WSR = new WS_References();
        try
        {
            addBAL.City_Name = txtCity.Text;
            addBAL.ACode = txtCode.Text;
            addBAL.State_Id = Convert.ToInt32(ddlState.SelectedValue);
            addBAL.LoggedBy = UserId;


            hsTable.Add("City_Code", addBAL.ACode);
            hsTable.Add("City_Name", addBAL.City_Name);

            if (!chkExistance.ExistanceForInsert(dt, hsTable))
            {

                addBAL.InsertCity();
                WSR.WS_InsertCity(addBAL.State_Id, addBAL.ACode, addBAL.City_Name, UserId);
                ddlState.SelectedIndex = 0;
                BindCity();
                txtCity.Text = "";
                txtCode.Text = "";
                ddlState.SelectedIndex = 0;
                ddlRecordStatus.SelectedValue = "1";
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

    protected void ddlRecordStatus_SelectedIndexChanged(object sender, EventArgs e)
    {
        lblmsg.Text = "";
        BindCity();
    }

    protected void imgbtn_Activate_Click(object sender, EventArgs e)
    {
        lblmsg.Text = "";
        addBAL = new AddressBAL();
        ImageButton lnkbtn = sender as ImageButton;
        GridViewRow row = lnkbtn.NamingContainer as GridViewRow;
        int Id = Convert.ToInt32(gdvCity.DataKeys[row.RowIndex].Value.ToString());
        int Status = Convert.ToInt32(((Label)gdvCity.Rows[row.RowIndex].FindControl("lblStatus")).Text);
        addBAL.City_Id = Id;
        addBAL.LoggedBy = UserId;
        if (Status == 1)
        {
            addBAL.AStatus = 0;
            addBAL.ChangeCityStatus();
        }
        else
        {
            addBAL.AStatus = 1;
            addBAL.ChangeCityStatus();
        }
        BindCity();
    }
}