using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Recruitment_MyWorkList : BaseClass
{
    RecruitmentBAL RecBAL;
     int UserId, URole;
    protected void Page_Load(object sender, EventArgs e)
    {
        UserId = Convert.ToInt32(Session["UserId"]);
        URole = Convert.ToInt32(Session["UserRole"]);
        if (!IsPostBack)
        {
            try
            {
              
                BindCandidate();
            }
            catch (Exception ex)
            {

            }

        }
    }
    private void BindCandidate()
    {
        RecBAL = new RecruitmentBAL();
        DataView dv = new DataView();
        try
        {

            if ((Convert.ToInt32(Session["UserRole"]) == 3 || Convert.ToInt32(Session["UserRole"]) == 8))
            {
               
                RecBAL.ConsultantId = UserId;
                dv.Table  = RecBAL.GetWorkListForConsultant();

                if (ViewState["SortExpr"] != null)
                    dv.Sort = (string)ViewState["SortExpr"] + " " + (string)ViewState["SortDir"];
                gdvMyWorkList.DataSource = dv;
                gdvMyWorkList.DataBind();
            }
            else
            {
                
                RecBAL.ConsultantId = UserId;
                dv.Table = RecBAL.GetWorkListForManager();
                if (ViewState["SortExpr"] != null)
                dv.Sort = (string)ViewState["SortExpr"] + " " + (string)ViewState["SortDir"];
                gdvMyWorkList.DataSource = dv;
                gdvMyWorkList.DataBind();
            }


        }
        catch (Exception ex)
        {
            lblmsg.Text = ex.Message.ToString();
        }
        finally
        {
            RecBAL = null;
        }
    }

    protected void gdvMyWorkList_Sorting(object sender, GridViewSortEventArgs e)
    {
        ViewState["SortExpr"] = e.SortExpression;
        if (ViewState["SortDir"] != null)
            e.SortDirection = (string)ViewState["SortDir"] == "ASC" ? SortDirection.Descending : SortDirection.Ascending;
        ViewState["SortDir"] = e.SortDirection == SortDirection.Ascending ? "ASC" : "DESC";
        BindCandidate();
    }
    protected void gdvMyWorkList_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        lblmsg.Text = "";
        gdvMyWorkList.PageIndex = e.NewPageIndex;
        BindCandidate();
    }
    protected void gdvMyWorkList_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "FollowUp")
        {
            GridViewRow gvr = (GridViewRow)((Control)e.CommandSource).NamingContainer;
            int Id = Convert.ToInt32(((Label)gvr.FindControl("lblRRId")).Text);
            int ConsltID = Convert.ToInt32(((Label)gvr.FindControl("lblConsultantId")).Text);
            Session["RRConsltntId"] = ConsltID;
            if ((Convert.ToInt32(Session["UserRole"]) == 3 || Convert.ToInt32(Session["UserRole"]) == 8))
            {
                string url = "Followup.aspx?Id=" + Id;
                Response.Redirect(url);
            }
            else
            {
                string url = "MyPostionFollowup.aspx?Id=" + Id;
                Response.Redirect(url);
            }


        }
        if (e.CommandName == "View")
        {
            GridViewRow gvr = (GridViewRow)((Control)e.CommandSource).NamingContainer;
            int Id = Convert.ToInt32(((Label)gvr.FindControl("lblId")).Text);
            string url = "ViewCandidate.aspx?Id=" + Id;
            Session["FlagA"] = "1";
            Response.Redirect(url);
        }
        if (e.CommandName == "History")
        {
            GridViewRow gvr = (GridViewRow)((Control)e.CommandSource).NamingContainer;
            int RRCanId = Convert.ToInt32(((Label)gvr.FindControl("lblRRId")).Text);
            string url = "FollowUpHistory.aspx?Id=" + RRCanId;
            Response.Redirect(url);
        }
    }
}