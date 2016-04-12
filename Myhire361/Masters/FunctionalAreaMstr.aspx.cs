using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Collections;

public partial class Masters_FunctionalAreaMstr : BaseClass
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
            BindFunctionalArea();
        }
    }

    private void BindFunctionalArea()
    {
        MstrBal = new MasterBAL();
        dt = new DataTable();

        try
        {
            dt = MstrBal.GetFunctionalArea();
            DataView dv = new DataView(dt);
            dv.RowFilter = "Status='" + ddlRecordStatus.SelectedValue + "'";
            if (ViewState["SortExpr"] != null)
                dv.Sort = (string)ViewState["SortExpr"] + " " + (string)ViewState["SortDir"];
            gdvFArea.DataSource = dv;
            gdvFArea.DataBind();
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


    protected void gdvFArea_Sorting(object sender, GridViewSortEventArgs e)
    {
        ViewState["SortExpr"] = e.SortExpression;
        if (ViewState["SortDir"] != null)
            e.SortDirection = (string)ViewState["SortDir"] == "ASC" ? SortDirection.Descending : SortDirection.Ascending;
        ViewState["SortDir"] = e.SortDirection == SortDirection.Ascending ? "ASC" : "DESC";
        BindFunctionalArea();
    }
    protected void gdvFArea_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        lblmsg.Text = "";
        gdvFArea.PageIndex = e.NewPageIndex;
        BindFunctionalArea();
    }

    protected void gdvFArea_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        lblmsg.Text = "";
        gdvFArea.EditIndex = -1;
        BindFunctionalArea();
    }

    protected void gdvFArea_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        MstrBal = new MasterBAL();
        chkExistance = new CheckExistance();
        hsTable = new Hashtable();
        WSR = new WS_References();

        GridViewRow gvr = gdvFArea.Rows[e.RowIndex];
        try
        {
           
            MstrBal.FunctAreaId  = Convert.ToInt32(((Label)gvr.FindControl("lblEId")).Text);
            MstrBal.Name = (((TextBox)gvr.FindControl("txtEName")).Text);
            MstrBal.Remarks = (((TextBox)gvr.FindControl("txtERemarks")).Text);
            hsTable.Add("FunctAreaName", MstrBal.Name);
          
            if (!chkExistance.ExistanceForUpdate(dt, hsTable, "FunctAreaId", MstrBal.FunctAreaId))
            {

                MstrBal.LoggedBy = UserId;
                MstrBal.IU_FunctionaAreaDetail();
                WSR.WS_IU_FunctionaAreaDetail(MstrBal.FunctAreaId, MstrBal.Name, MstrBal.Remarks, UserId);
                gdvFArea.EditIndex = -1;
               BindFunctionalArea();
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

    protected void gdvFArea_RowEditing(object sender, GridViewEditEventArgs e)
    {
        lblmsg.Text = "";
        gdvFArea.EditIndex = e.NewEditIndex;
        BindFunctionalArea();
    }

    protected void btnInsert_Click(object sender, EventArgs e)
    {
        MstrBal = new MasterBAL();
        chkExistance = new CheckExistance();
        hsTable = new Hashtable();
        WSR = new WS_References();
        try
        {
            MstrBal.Remarks=txtRemarks.Text;
            MstrBal.Name=txtName.Text;
            MstrBal.LoggedBy = UserId;

            hsTable.Add("FunctAreaName", txtName.Text);
          
            if (!chkExistance.ExistanceForInsert(dt, hsTable))
            {
                MstrBal.IU_FunctionaAreaDetail();
                WSR.WS_IU_FunctionaAreaDetail(0, MstrBal.Name, MstrBal.Remarks, UserId);
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
            BindFunctionalArea();
        }
    }

    protected void gdvFArea_RowDataBound(object sender, GridViewRowEventArgs e)
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
        int Id = Convert.ToInt32(gdvFArea.DataKeys[row.RowIndex].Value.ToString());
        int Status = Convert.ToInt32(((Label)gdvFArea.Rows[row.RowIndex].FindControl("lblStatus")).Text);
        MstrBal.FunctAreaId  = Id;
        MstrBal.LoggedBy = UserId;
        if (Status == 1)
        {
            MstrBal.AStatus = 0;
            MstrBal.ChangeFunAreaStatus();
        }
        else
        {
            MstrBal.AStatus = 1;
            MstrBal.ChangeFunAreaStatus();
        }
        BindFunctionalArea();
    }

    protected void ddlRecordStatus_SelectedIndexChanged(object sender, EventArgs e)
    {
        lblmsg.Text = "";
        BindFunctionalArea();
    }
}