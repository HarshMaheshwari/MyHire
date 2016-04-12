using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text;
public partial class Report_Celebration : System.Web.UI.Page
{
    Search srch;
    int USR_ID, USR_Role, ClientId;
    string Username;
    LoginBAL lginbal;
    ClientBAL clnt;
    protected void Page_Load(object sender, EventArgs e)
    {
        USR_ID = Convert.ToInt32(Session["UserId"]);
        //   UserId = Convert.ToInt32(Session["UserId"]);
        if (!IsPostBack)
        {
            BindGrid();
        }
    }
    private void BindGrid()
    {
        DataView dv = new DataView();

        try
        {
            dv.Table = Report();
            if (ViewState["SortExpr"] != null)
                dv.Sort = (string)ViewState["SortExpr"] + " " + (string)ViewState["SortDir"];
            GdvClientcelebration.DataSource = dv;
            GdvClientcelebration.DataBind();
        }
        catch (Exception ex)
        {
        }
        finally
        {
        }
    }
    public DataTable Report()
    {
        srch = new Search();
        StringBuilder sb = new StringBuilder();
        sb.Append("select distinct c.Client_Id,cc.Contact_PersonId,c.Client_Name,cc.CreationDate,(cc.Person_Dob)  AS DOB ,cc.Person_Name,cc.Person_Dob,cc.Person_Anniversary,cc.Person_Email  ");
        sb.Append(" from ClientDetail  as c  inner join ClientContactPerson as cc on c.Client_Id=cc.Client_Id  ");
     //   sb.Append(" where  c.Client_Id=cc.Client_Id  ");
  
        if (txtStartDate.Text != "")
        {
            sb.Append(" and CAST( cc.Person_Dob as date )>= cast('" + txtStartDate.Text + "'as date)");
        }
        if (txtEndDate.Text != "")
        {
            sb.Append(" and CAST( cc.Person_Dob as date )<= cast('" + txtEndDate.Text + "'as date)");
        }

        sb.Append("  order by c.Client_Name asc ");

        string query = sb.ToString();
        return srch.SearchRecord(query).Tables[0];
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        BindGrid();
    }
    protected void GdvClientcelebration_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GdvClientcelebration.PageIndex = e.NewPageIndex;
        BindGrid();
    }
    protected void GdvClientcelebration_RowEditing(object sender, GridViewEditEventArgs e)
    {
       // lblmsg.Text = "";
        GdvClientcelebration.EditIndex = e.NewEditIndex;
        BindGrid();
    }
    protected void GdvClientcelebration_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        clnt = new ClientBAL();
        GridViewRow gvr = GdvClientcelebration.Rows[e.RowIndex];
        try
        {
            clnt.ClientId = Convert.ToInt32(((Label)gvr.FindControl("lblEId")).Text.Trim());
            clnt.PersonId = Convert.ToInt32(((Label)gvr.FindControl("lblEClntCntPrsnId")).Text.Trim());
            clnt.PersonDob = ((TextBox)gvr.FindControl("txtEDOBP")).Text;
            clnt.PersonAnnvrsry = ((TextBox)gvr.FindControl("txtEPerson_Anniversary")).Text;
            //clnt.UserId = UserId;
            clnt.InsertUpdateContactPerson();
            GdvClientcelebration.EditIndex = -1;
            BindGrid();
        }
        finally
        {
            clnt = null;
        }
    }
    protected void GdvClientcelebration_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
       // lblm.Text = "";
        GdvClientcelebration.EditIndex = -1;
        BindGrid();
    }
    protected void GdvClientcelebration_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        clnt = new ClientBAL();
        try
        {
            if ((e.Row.RowState & DataControlRowState.Edit) > 0)
            {
                TextBox PersonDob = ((TextBox)e.Row.FindControl("txtDOBP"));
                TextBox PersonAnnvrsry = ((TextBox)e.Row.FindControl("txtPerson_Anniversary"));
               
            }
        }
        catch (Exception ex)
        {

        }
        finally
        {
            clnt = null;
        }

    }
    protected void GdvClientcelebration_Sorting(object sender, GridViewSortEventArgs e)
    {
        ViewState["SortExpr"] = e.SortExpression;
        if (ViewState["SortDir"] != null)
            e.SortDirection = (string)ViewState["SortDir"] == "ASC" ? SortDirection.Descending : SortDirection.Ascending;
        ViewState["SortDir"] = e.SortDirection == SortDirection.Ascending ? "ASC" : "DESC";
        BindGrid();
    }
    protected void lbdownload_Click(object sender, EventArgs e)
    {
        DataTable dt = new DataTable();
        try
        {
            dt = Report();
            // dt.Columns.Remove("Course_Id");
            string filename = "ClientCelebs.xls";
            System.IO.StringWriter tw = new System.IO.StringWriter();
            System.Web.UI.HtmlTextWriter hw = new System.Web.UI.HtmlTextWriter(tw);
            DataGrid dgGrid = new DataGrid();

            dgGrid.DataSource = dt;
            dgGrid.DataBind();
            dgGrid.RenderControl(hw);
            Response.ContentType = "application/vnd.ms-excel";
            Response.AppendHeader("Content-Disposition", "attachment; filename=" + filename + "");
            this.EnableViewState = false;
            Response.Write(tw.ToString());
            Response.End();
        }
        catch (Exception ex)
        {
        }
        finally
        {
            dt = null;
        }

    }
}