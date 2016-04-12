using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text;

public partial class UserList : BaseClass
{
    LoginBAL UserBAL;
    int UserId;
    Search srch;

    protected void Page_Load(object sender, EventArgs e)
    {
        UserId = Convert.ToInt32(Session["UserId"]);
        if (!IsPostBack)
        {
           
            BindRecordStatusTypes(ddlStatus);
            BindUserList();
            BindManager(ddlManager);
            BindRole(ddlRole);

        }
    }

    private void BindUserList()
    {
        UserBAL = new LoginBAL();
        DataView dv = new DataView();
        try
        {
           dv.Table = UserBAL.GetUserList();
           if (ViewState["SortExpr"] == null)
           {
               ViewState["SortExpr"] = gdvUser.Attributes["CurrentSortField"].ToString();
               ViewState["SortDir"] = gdvUser.Attributes["CurrentSortDirection"].ToString();
           }
                dv.Sort = (string)ViewState["SortExpr"] + " " + (string)ViewState["SortDir"];
            gdvUser.DataSource = dv;
            gdvUser.DataBind();
        }
        catch (Exception ex)
        {
            lblmsg.Text = "Sorry : " + ex.Message.ToString();
        }
        finally
        {
            UserBAL = null;
        }
    }

    protected void gdvUser_Sorting(object sender, GridViewSortEventArgs e)
    {
        ViewState["SortExpr"] = e.SortExpression;
        if (ViewState["SortDir"] != null)
            e.SortDirection = (string)ViewState["SortDir"] == "ASC" ? SortDirection.Descending : SortDirection.Ascending;
        ViewState["SortDir"] = e.SortDirection == SortDirection.Ascending ? "ASC" : "DESC";
       BindUserList();
    }

    protected void gdvUser_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gdvUser.PageIndex = e.NewPageIndex;
        BindUserList();
    }

    protected void gdvUser_RowDataBound(object sender, GridViewRowEventArgs e)
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
            Label lblRoleId = ((Label)e.Row.FindControl("lblERole"));
            Label lblMgrId = ((Label)e.Row.FindControl("lblEManagerId"));
            DropDownList ddlERole = ((DropDownList)e.Row.FindControl("ddlERole"));
            DropDownList ddlEManager = ((DropDownList)e.Row.FindControl("ddlEManager"));
            BindManager(ddlEManager);
            BindRole(ddlERole);
            ddlEManager.SelectedValue = lblMgrId.Text;
            ddlERole.SelectedValue = lblRoleId.Text;
        }

        else if (e.Row.RowType == DataControlRowType.DataRow)
        {
            ImageButton imgbtnActive = (ImageButton)e.Row.FindControl("imgbtnActivate");
            ImageButton imgbtnInActive = (ImageButton)e.Row.FindControl("imgbtnInActivate");
            Label lbl = (Label)e.Row.FindControl("lblStatus");
            if (Convert.ToInt32(lbl.Text) == 1)
            {
                lbl.Text = "Active";
                imgbtnInActive.Visible = false;
                imgbtnActive.Visible = true;
            }
            else
            {
                lbl.Text = "Inactive";
                imgbtnInActive.Visible = true;
                imgbtnActive.Visible = false;
            }
        }
    }

    protected void btnNew_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/NewUser.aspx");
    }

    private void BindManager(DropDownList ddl)
    {
        UserBAL = new LoginBAL();
        try
        {
            ListItem li = new ListItem("Select Reporting Manager", "0");
            ddl.Items.Clear();
            ddl.Items.Add(li);
            ddl.DataSource = UserBAL.FillUser();
            ddl.DataTextField = "USR_Name";
            ddl.DataValueField = "USR_ID";
            ddl.DataBind();
        }
        finally
        {
            UserBAL = null;
        }
    }

    private void BindRole(DropDownList ddl)
    {
        UserBAL = new LoginBAL();
        try
        {
            ListItem lis = new ListItem("Select Role","0");
            ddl.Items.Clear();
            ddl.Items.Add(lis);
            ddl.DataSource = UserBAL.FillRole();
            ddl.DataTextField = "Role_Name";
            ddl.DataValueField = "Role_Id";
            ddl.DataBind();
        }
        finally
        {
            UserBAL = null;
        }
    }

    protected void imgbtn_Activate_Click(object sender, EventArgs e)
    {
        UserBAL = new LoginBAL();
        ImageButton imgbtn = sender as ImageButton;
        GridViewRow row = imgbtn.NamingContainer as GridViewRow;
        int Id = Convert.ToInt32(gdvUser.DataKeys[row.RowIndex].Value.ToString());
        string Status =((Label)gdvUser.Rows[row.RowIndex].FindControl("lblStatus")).Text;
        UserBAL.Usr_Id = Id;
        UserBAL.LoggedBy = UserId;
        if (Status == "Active")
        {
            UserBAL.Status = 0;
            UserBAL.ChangeUserStatus();
        }
        else
        {
            UserBAL.Status = 1;
            UserBAL.ChangeUserStatus();
        }
        BindUserList();
    }

    protected void gdvUser_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        lblmsg.Text = "";
        gdvUser.EditIndex = -1;
        BindUserList();
    }

    protected void gdvUser_RowEditing(object sender, GridViewEditEventArgs e)
    {
        lblmsg.Text = "";
        gdvUser.EditIndex = e.NewEditIndex;
        BindUserList();
    }

    protected void gdvUser_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        UserBAL = new LoginBAL();
        GridViewRow gvr = gdvUser.Rows[e.RowIndex];
        try
        {
            UserBAL.Usr_Id = Convert.ToInt32(((Label)gvr.FindControl("lblEId")).Text);
            UserBAL.Name = (((TextBox)gvr.FindControl("txtEName")).Text);
            UserBAL.Email = (((TextBox)gvr.FindControl("txtEEmail")).Text);
            UserBAL.USR_Mobile = (((TextBox)gvr.FindControl("txtEUSR_Mobile")).Text);
            UserBAL.Role_Id = Convert.ToInt32(((DropDownList)gvr.FindControl("ddlERole")).SelectedValue);
            UserBAL.ReportingMgrId = Convert.ToInt32(((DropDownList)gvr.FindControl("ddlEManager")).SelectedValue);
            UserBAL.LoggedBy = UserId;
            int Result = UserBAL.InsertUpdateUser();
            if (Result > 0)
            {
                gdvUser.EditIndex = -1;
                BindUserList();
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
            UserBAL = null;
        }



    }

    protected void ddlStatus_SelectedIndexChanged(object sender, EventArgs e)
    {
        lblmsg.Text  = "";
       // BindUserList ();
    }
    public void BindRecordStatusTypes(DropDownList ddl)
    {
        ListItem list = new ListItem("Select Status", "1000");
        ddl.Items.Clear();
        ddl.Items.Add(list);
        ddl.Items.Add(new ListItem("Active", "1"));
        ddl.Items.Add(new ListItem("Inactive", "0"));
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        UserBAL = new LoginBAL ();
        DataView dv = new DataView();
        try
        {
            dv.Table = SearchUser();
            if (ViewState["SortExpr"] != null)
                dv.Sort = (string)ViewState["SortExpr"] + " " + (string)ViewState["SortDir"];
            gdvUser.DataSource  = dv;
            gdvUser.DataBind();
        }
        catch (Exception ex)
        {

        }
        finally
        {
            UserBAL  = null;
        }
    }
    public DataTable SearchUser()
    {
        srch = new Search();
        StringBuilder sb = new StringBuilder();
        sb.Append("   SELECT        Ud.USR_ID, Ud.USR_Name, Ud.USR_Password, Ud.USR_Email, Ud.ReportingMgr_Id, , Ud.USR_Mobile, ");
        sb.Append(" Uda.USR_Name AS ReportingMgr, Ud.USR_Role, Ur.Role_Name, Ur.Role_Code, Ud.Status ");
        sb.Append("  FROM        dbo.UserDetail AS Ud  ");
        sb.Append(" INNER JOIN dbo.UserDetail AS Uda ON Ud.ReportingMgr_Id = Uda.USR_ID  ");
        sb.Append(" INNER JOIN dbo.UserRole AS Ur ON Ud.USR_Role = Ur.Role_Id ");
      
        if (txtUserNam.Text != "")
        {
            sb.Append("and Ud.USR_Name like '%" + txtUserNam.Text + "%'");
        }
        if (txtEmailId.Text != "")
        {
            sb.Append("and Ud.USR_Email like '%" + txtEmailId.Text + "%'");
        }

        if (ddlRole.SelectedIndex > 0)
        {
            sb.Append(" and Ud.USR_Role = '" + ddlRole.SelectedValue  + "'");
        }
        if (ddlManager.SelectedIndex > 0)
        {
            sb.Append(" and Ud.ReportingMgr_Id = '" + ddlManager.SelectedValue  + "'");
        }
        if (ddlStatus.SelectedIndex > 0)
        {
            sb.Append(" and Ud.Status = '" + ddlStatus.SelectedValue + "'");
        }

        sb.Append(" order by Ud.USR_Name ");
        string query = sb.ToString();
        return srch.SearchRecord(query).Tables[0];
    }
}