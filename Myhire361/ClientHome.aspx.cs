using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class ClientHome : BaseClass
{
    RecruitmentBAL recruitbal;
    ClientBAL ClientBal;
    int UserId, Role;
    string UsrEmail;
    static int ClientId;
    protected void Page_Load(object sender, EventArgs e)
    {
        UserId = Convert.ToInt32(Session["UserId"]);
        Role = Convert.ToInt32(Session["UserRole"]);
        UsrEmail = Session["UserEmail"].ToString();
        if (!IsPostBack)
        {
            GetClientContactDetail();
            BindGrid();
        }
    }
    protected void GetClientContactDetail()
    {
        ClientBal = new ClientBAL();
        DataTable dt = new DataTable();
        try
        {
            ClientBal.PersonEmail = UsrEmail;
            dt = ClientBal.GetClientContactByEmail();
            ClientId = Convert.ToInt32(dt.Rows[0]["Client_Id"].ToString());
        }
        finally
        {
            dt = null;
            ClientBal = null;
        }
    }
    protected void BindGrid()
    {
        recruitbal = new RecruitmentBAL();
        DataTable dt = new DataTable();
        try
        {
            recruitbal.Client_Id = ClientId;
            if (Role == 4)
            {
                dt = recruitbal.GetRequestByClientManager();
            }
            if (Role == 5)
            {
                recruitbal.Email = UsrEmail;
                dt = recruitbal.GetRequestByClientContact();
            }
            gdvRequest.DataSource = dt;
            gdvRequest.DataBind();
        }
        finally
        {
            dt = null;
            recruitbal = null;
        }
    }
    protected void gdvRequest_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gdvRequest.PageIndex = e.NewPageIndex;
        BindGrid();
    }

    protected void gdvRequest_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "View")
        {
            GridViewRow gvr = (GridViewRow)((Control)e.CommandSource).NamingContainer;
            int Id = Convert.ToInt32(((Label)gvr.FindControl("lblId")).Text);
            Session["Flag"] = "3";
            string url = "~/Recruitment/ViewRRequest.aspx?Id=" + Id;
            Response.Redirect(url);

        }
    }
}