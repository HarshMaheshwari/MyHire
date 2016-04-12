using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Collections;
public partial class Masters_IndustryMstr : BaseClass
{
    MasterBAL MstrBal;
    static int UserId;
    static DataTable dt;
    Hashtable hsTable;
    CheckExistance chkExistance;
    WS_References WSR;
    protected void Page_Load(object sender, EventArgs e)
    {
        UserId = Convert.ToInt32(Session["UserId"]);
        if (!IsPostBack)
        {
            BindIndustry();
        }
    }

    private void BindIndustry()
    {
        MstrBal = new MasterBAL();
        dt = new DataTable();

        try
        {
            dt = MstrBal.GetIndustry();
            DataView dv = new DataView(dt);
            dv.RowFilter = "Status='" + ddlRecordStatus.SelectedValue + "'";
            if (ViewState["SortExpr"] != null)
                dv.Sort = (string)ViewState["SortExpr"] + " " + (string)ViewState["SortDir"];
            gdvIndustry.DataSource = dv;
            gdvIndustry.DataBind();
        }
        catch (Exception ex)
        {
            lblmsg.Text = ex.Message.ToString();
        }
        finally
        {
            MstrBal = null;
        }
    }


    protected void gdvIndustry_Sorting(object sender, GridViewSortEventArgs e)
    {
        ViewState["SortExpr"] = e.SortExpression;
        if (ViewState["SortDir"] != null)
            e.SortDirection = (string)ViewState["SortDir"] == "ASC" ? SortDirection.Descending : SortDirection.Ascending;
        ViewState["SortDir"] = e.SortDirection == SortDirection.Ascending ? "ASC" : "DESC";
        BindIndustry();
    }
    protected void gdvIndustry_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        lblmsg.Text = "";
        gdvIndustry.PageIndex = e.NewPageIndex;
        BindIndustry();
    }

    protected void gdvIndustry_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        lblmsg.Text = "";
        gdvIndustry.EditIndex = -1;
        BindIndustry();
    }

    protected void gdvIndustry_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        MstrBal = new MasterBAL();
        chkExistance = new CheckExistance();
        hsTable = new Hashtable();
         WSR = new WS_References();

        GridViewRow gvr = gdvIndustry.Rows[e.RowIndex];
        try
        {

            MstrBal.IndustryId = Convert.ToInt32(((Label)gvr.FindControl("lblEId")).Text);
            MstrBal.Name = (((TextBox)gvr.FindControl("txtEName")).Text);
            MstrBal.Remarks = (((TextBox)gvr.FindControl("txtERemarks")).Text);
            hsTable.Add("IndustryName", MstrBal.Name);

            if (!chkExistance.ExistanceForUpdate(dt, hsTable, "IndustryId", MstrBal.IndustryId))
            {

                MstrBal.LoggedBy = UserId;
                MstrBal.IU_IndustryMaster();
                WSR.WS_IU_IndustryMaster(MstrBal.IndustryId, MstrBal.Name, MstrBal.Remarks, UserId);
                gdvIndustry.EditIndex = -1;
                BindIndustry();
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
            MstrBal = null;
            chkExistance = null;
            hsTable = null;
        }
    }

    protected void gdvIndustry_RowEditing(object sender, GridViewEditEventArgs e)
    {
        lblmsg.Text = "";
        gdvIndustry.EditIndex = e.NewEditIndex;
        BindIndustry();
    }

    protected void btnInsert_Click(object sender, EventArgs e)
    {
        MstrBal = new MasterBAL();
        chkExistance = new CheckExistance();
        hsTable = new Hashtable();
        WSR = new WS_References();
        try
        {
            MstrBal.Remarks = txtRemarks.Text;
            MstrBal.Name = txtName.Text;
            MstrBal.LoggedBy = UserId;

            hsTable.Add("IndustryName", txtName.Text);

            if (!chkExistance.ExistanceForInsert(dt, hsTable))
            {
                MstrBal.IU_IndustryMaster();
                WSR.WS_IU_IndustryMaster(0, MstrBal.Name, MstrBal.Remarks, UserId);
                ddlRecordStatus.SelectedValue = "1";
                txtRemarks.Text = null;
                txtName.Text = null;

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
            MstrBal = null;
            chkExistance = null;
            hsTable = null;
            BindIndustry();
        }
    }

    protected void gdvIndustry_RowDataBound(object sender, GridViewRowEventArgs e)
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
        MstrBal = new MasterBAL();
        ImageButton lnkbtn = sender as ImageButton;
        GridViewRow row = lnkbtn.NamingContainer as GridViewRow;
        int Id = Convert.ToInt32(gdvIndustry.DataKeys[row.RowIndex].Value.ToString());
        int Status = Convert.ToInt32(((Label)gdvIndustry.Rows[row.RowIndex].FindControl("lblStatus")).Text);
        MstrBal.IndustryId = Id;
        MstrBal.LoggedBy = UserId;
        if (Status == 1)
        {
            MstrBal.AStatus = 0;
            MstrBal.ChangeIndustryStatus();
        }
        else
        {
            MstrBal.AStatus = 1;
            MstrBal.ChangeIndustryStatus();
        }
        BindIndustry();
    }

    protected void ddlRecordStatus_SelectedIndexChanged(object sender, EventArgs e)
    {
        lblmsg.Text = "";
        BindIndustry();
    }
}