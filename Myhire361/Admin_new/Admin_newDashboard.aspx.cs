using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;
using System.Text;
using System.Data.SqlClient;

public partial class admin_new_Admin_newDashboard : System.Web.UI.Page
{
    int URole, UserId;

    protected void Page_Load(object sender, EventArgs e)
    {
        pnlClient.Visible = true;
        pnlJD.Visible = false;
        pnlTeam.Visible = false;
        pnlCandidate.Visible = false;
        pnlCV.Visible = false;
        pnlInterview.Visible = false;
        pnlSelected.Visible = false;
        pnlJoined.Visible = false;
   

        UserId = Convert.ToInt32(Session["UserId"]);
        URole = Convert.ToInt32(Session["UserRole"]);
        if (!IsPostBack)
        {
            //BindClient();
            BindClientList();
            //if (URole > 1 || URole != 1015)
            //{
            //    btnNew.Visible = false;

            //}
            //else
            //{
            //    btnNew.Visible = true;
            //}


        }
    }

    private void BindClientList()
    {
        DataView dv = new DataView();
        var clntBAL = new ClientBAL();
        try
        {
            if (URole == 1 || URole == 1015)
            {


                dv.Table = clntBAL.GetClient();
                if (ViewState["SortExpr"] != null)
                    dv.Sort = (string)ViewState["SortExpr"] + " " + (string)ViewState["SortDir"];
                gdvClientList.DataSource = dv;
                gdvClientList.DataBind();
            }
            else
            {
                clntBAL.UserId = UserId;

                dv.Table = clntBAL.GetClientByUserId();
                if (ViewState["SortExpr"] != null)
                    dv.Sort = (string)ViewState["SortExpr"] + " " + (string)ViewState["SortDir"];
                gdvClientList.DataSource = dv;

                gdvClientList.DataBind();
            }
        }
        catch (Exception ex)
        {

        }
        finally
        {
            clntBAL = null;
        }
    }



    protected void btnClient_Click(object sender, EventArgs e)
    {
        pnlClient.Visible = true;
       



    }
    protected void btnJD_Click(object sender, EventArgs e)
    {

    }
    protected void btnTeam_Click(object sender, EventArgs e)
    {

    }

    protected void btnCandidate_Click(object sender, EventArgs e)
    {

    }
    protected void btnCV_Click(object sender, EventArgs e)
    {

    }
    protected void btnInterView_Click(object sender, EventArgs e)
    {

    }

    protected void btnSelected_Click(object sender, EventArgs e)
    {

    }

    protected void btnJoined_Click(object sender, EventArgs e)
    {

    }
  

    protected void gdvClientList_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        GridView2.DataSource = e.Row;
        GridView2.DataBind();
    }
}