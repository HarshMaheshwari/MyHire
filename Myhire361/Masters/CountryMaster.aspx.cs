using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;
using System.Data;

public partial class Masters_CountryMaster : BaseClass
{
    AddressBAL addBAL;
    static int UserId;
    static DataTable dt;
    Hashtable hsTable;
    CheckExistance chkExistance;

    protected void Page_Load(object sender, EventArgs e)
    {
        UserId = Convert.ToInt32(Session["UserId"]);
        if (!IsPostBack)
        {
            BindCountry();
        }
    }

    private void BindCountry()
    {
        addBAL = new AddressBAL();
        dt = new DataTable();

        try
        {
            dt = addBAL.GetCountry();
            DataView dv = new DataView(dt);
            dv.RowFilter = "Status='" + ddlRecordStatus.SelectedValue + "'";
           if (ViewState["SortExpr"] != null)
                dv.Sort = (string)ViewState["SortExpr"] + " " + (string)ViewState["SortDir"];
            gdvCountry.DataSource = dv;
            gdvCountry.DataBind();
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


    protected void gdvCountry_Sorting(object sender, GridViewSortEventArgs e)
    {
        ViewState["SortExpr"] = e.SortExpression;
        if (ViewState["SortDir"] != null)
            e.SortDirection = (string)ViewState["SortDir"] == "ASC" ? SortDirection.Descending : SortDirection.Ascending;
        ViewState["SortDir"] = e.SortDirection == SortDirection.Ascending ? "ASC" : "DESC";
        BindCountry();
    }
    protected void gdvCountry_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        lblmsg.Text = "";
        gdvCountry.PageIndex = e.NewPageIndex;
        BindCountry();
    }

    protected void gdvCountry_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        lblmsg.Text = "";
        gdvCountry.EditIndex = -1;
        BindCountry();
    }

    protected void gdvCountry_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        addBAL = new AddressBAL();
        chkExistance = new CheckExistance();
        hsTable = new Hashtable();

        GridViewRow gvr = gdvCountry.Rows[e.RowIndex];
        try
        {
            addBAL.Cntry_Id = Convert.ToInt32(((Label)gvr.FindControl("lblEId")).Text);
            addBAL.ACode = (((TextBox)gvr.FindControl("txtECode")).Text);
            addBAL.Cntry_Name = (((TextBox)gvr.FindControl("txtECountry")).Text);

            hsTable.Add("Cntry_Code", addBAL.ACode);
            hsTable.Add("Cntry_Name", addBAL.Cntry_Name);

            if (!chkExistance.ExistanceForUpdate(dt, hsTable, "Cntry_Id", addBAL.Cntry_Id))
            {

                addBAL.LoggedBy = UserId;
                addBAL.UpdateCountry();
                gdvCountry.EditIndex = -1;

                BindCountry();
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
            addBAL = null;
            chkExistance = null;
            hsTable = null;
        }
    }

    protected void gdvCountry_RowEditing(object sender, GridViewEditEventArgs e)
    {
        lblmsg.Text = "";
        gdvCountry.EditIndex = e.NewEditIndex;
        BindCountry();
    }

    protected void btnInsert_Click(object sender, EventArgs e)
    {
        addBAL = new AddressBAL();
        chkExistance = new CheckExistance();
        hsTable = new Hashtable();

        try
        {
            addBAL.Cntry_Name = txtCountry.Text;
            addBAL.ACode = txtCode.Text;
            addBAL.LoggedBy = UserId;

            hsTable.Add("Cntry_Code", txtCode.Text);
            hsTable.Add("Cntry_Name", txtCountry.Text);

            if (!chkExistance.ExistanceForInsert(dt, hsTable))
            {
                addBAL.InsertCountry();
                ddlRecordStatus.SelectedValue = "1";
                txtCountry.Text = null;
                txtCode.Text = null;

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
            BindCountry();
        }
    }

    protected void gdvCountry_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if ((e.Row.RowState & DataControlRowState.Edit) > 0)
        {
            Label lbl = (Label)e.Row.FindControl("lblEStatus");
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

    protected void imgbtn_Activate_Click(object sender, EventArgs e)
    {
        lblmsg.Text = "";
        addBAL = new AddressBAL();
        ImageButton lnkbtn = sender as ImageButton;
        GridViewRow row = lnkbtn.NamingContainer as GridViewRow;
        int Id = Convert.ToInt32(gdvCountry.DataKeys[row.RowIndex].Value.ToString());
        int Status = Convert.ToInt32(((Label)gdvCountry.Rows[row.RowIndex].FindControl("lblStatus")).Text);
        addBAL.Cntry_Id = Id;
        addBAL.LoggedBy = UserId;
        if (Status == 1)
        {
            addBAL.AStatus = 0;
            addBAL.ChangeCountryStatus();
        }
        else
        {
            addBAL.AStatus = 1;
            addBAL.ChangeCountryStatus();
        }
        BindCountry();
    }

    protected void ddlRecordStatus_SelectedIndexChanged(object sender, EventArgs e)
    {
        lblmsg.Text = "";
        BindCountry();
    }
}