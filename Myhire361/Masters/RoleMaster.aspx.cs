using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Masters_RoleMaster : BaseClass
{
    LoginBAL roleBAL;
    int UserId;

    protected void Page_Load(object sender, EventArgs e)
    {
        UserId = Convert.ToInt32(Session["UserId"]);
        if (!IsPostBack)
        {
            BindRole();
        }
    }

    private void BindRole()
    {
        roleBAL = new LoginBAL();
        try
        {
            DataView dv = new DataView(roleBAL.GetRole());
            dv.RowFilter = "Status='" + ddlRecordStatus.SelectedValue + "'";
            gdvRole.DataSource = dv;
            gdvRole.DataBind();
        }
        catch (Exception ex)
        {
            lblmsg.Text = ex.Message.ToString();
        }
        finally
        {
            roleBAL = null;
        }
    }

    protected void gdvRole_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gdvRole.PageIndex = e.NewPageIndex;
        BindRole();
    }

    protected void gdvRole_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        gdvRole.EditIndex = -1;
        BindRole();
    }

    protected void gdvRole_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if ((e.Row.RowState & DataControlRowState.Edit) > 0)
        {
            Label lbl = (Label)e.Row.FindControl("lblEStatus");
        }
        else if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Label lbl = (Label)e.Row.FindControl("lblStatus");
            LinkButton btn = (LinkButton)e.Row.FindControl("lbActivate");
            if (Convert.ToInt32(lbl.Text) == 1)
            {
                btn.Text = "Inactive";
            }
            else
            {
                btn.Text = "Active";
            }
        }
    }

    protected void gdvRole_RowEditing(object sender, GridViewEditEventArgs e)
    {
        gdvRole.EditIndex = e.NewEditIndex;
        BindRole();
    }

    protected void gdvRole_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        roleBAL = new LoginBAL();
        GridViewRow gvr = gdvRole.Rows[e.RowIndex];
        try
        {
            roleBAL.Role_Id = Convert.ToInt32(((Label)gvr.FindControl("lblEId")).Text);
            roleBAL.Role = (((TextBox)gvr.FindControl("txtEName")).Text);
            roleBAL.RoleCode = (((TextBox)gvr.FindControl("txtECode")).Text);
            roleBAL.LoggedBy = UserId;
            int result = Convert.ToInt32(roleBAL.InsertUpdateRole());
            if (result == 1)
            {
                lblmsg.Text = "Updated Successfully";
                gdvRole.EditIndex = -1;
                BindRole();
            }
            else
            {
                lblmsg.Text = "Already Exists";
            }
        }
        catch (Exception ex)
        {
            lblmsg.Text = ex.Message.ToString();
        }
        finally
        {
            roleBAL = null;
            BindRole();
        }
    }

    protected void btnInsert_Click(object sender, EventArgs e)
    {
        roleBAL = new LoginBAL();
        try
        {
            roleBAL.Role = txtName.Text;
            roleBAL.RoleCode = txtCode.Text;
            roleBAL.LoggedBy = UserId;
            int result = Convert.ToInt32(roleBAL.InsertUpdateRole());
            if (result == 1)
            {
                lblmsg.Text = "Saved Successfully";
                BindRole();
                txtCode.Text = "";
                txtName.Text = "";
                ddlRecordStatus.SelectedValue = "1";
            }
            else
            {
                lblmsg.Text = "Already Exists";
            }
        }
        catch (Exception ex)
        {
            lblmsg.Text = ex.Message.ToString();
        }
        finally
        {
            roleBAL = null;
        }
    }

    protected void lbActivate_Click(object sender, EventArgs e)
    {
        roleBAL = new LoginBAL();
        LinkButton lnkbtn = sender as LinkButton;
        GridViewRow row = lnkbtn.NamingContainer as GridViewRow;
        int Id = Convert.ToInt32(gdvRole.DataKeys[row.RowIndex].Value.ToString());
        int Status = Convert.ToInt32(((Label)gdvRole.Rows[row.RowIndex].FindControl("lblStatus")).Text);
        roleBAL.Role_Id = Id;
        roleBAL.LoggedBy = UserId;
        if (Status == 1)
        {
            roleBAL.Status = 0;
            roleBAL.ChangeRoleStatus();
        }
        else
        {
            roleBAL.Status = 1;
            roleBAL.ChangeRoleStatus();
        }
        BindRole();
    }

    protected void ddlRecordStatus_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindRole();
    }
}