using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Configuration;

public partial class Business_PlanAchievement : BaseClass
{
    BusinessPlanBAL Busbl;
    ClientBAL clientbal;
    int UserId, URole;
    int MyTimeSpan = 0;
    String CurMonth = "";
    DataTable dt;
    Search srch;

    protected void Page_Load(object sender, EventArgs e)
    {
        UserId = Convert.ToInt32(Session["UserId"]);
        URole = Convert.ToInt32(Session["UserRole"]);
        MyTimeSpan = Convert.ToInt32(ConfigurationManager.AppSettings["TimeSpan"]);

        if (!IsPostBack)
        {
            txtMonth.Text = DateTime.Now.AddMinutes(MyTimeSpan).ToString("MMM-yyyy");
            BindGrid();
        }
    }
    private void BindGrid()
    {

       DataTable  dt = new DataTable();
       Busbl = new BusinessPlanBAL();
        try
        {
            Busbl.MonthYear = txtMonth.Text;
            dt = Busbl.GetPlanAchievement();
            DataView dv = new DataView(dt);
            if (ViewState["SortExpr"] != null)
                dv.Sort = (string)ViewState["SortExpr"] + " " + (string)ViewState["SortDir"];

            gdvBusiness.DataSource = dv;
            gdvBusiness.DataBind();

        }
        catch (Exception ex)
        { }
        finally
        {

        }
    }


    protected void gdvBusiness_Sorting(object sender, GridViewSortEventArgs e)
    {
        ViewState["SortExpr"] = e.SortExpression;
        if (ViewState["SortDir"] != null)
            e.SortDirection = (string)ViewState["SortDir"] == "ASC" ? SortDirection.Descending : SortDirection.Ascending;
        ViewState["SortDir"] = e.SortDirection == SortDirection.Ascending ? "ASC" : "DESC";
        BindGrid();
    }
   
 protected void gdvBusiness_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gdvBusiness.PageIndex = e.NewPageIndex;
        BindGrid();
    }
    protected void btnSearch_OnClick(object sender, EventArgs e)
    {
        BindGrid();
    }
   protected void gdvBusiness_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Client")
        {
            GridViewRow gvr = (GridViewRow)((Control)e.CommandSource).NamingContainer;
            BindGridClient();
            MPEbtnPopupC.Show();
          
        }
        else if (e.CommandName == "Consultant")
        {
            GridViewRow gvr = (GridViewRow)((Control)e.CommandSource).NamingContainer;
            BindGridConsultant();
            MpePopupCns.Show();
          
        }
       
       
    }

   #region   Clientwise achievement
   private void BindGridClient()
    {

       DataTable  dt = new DataTable();
       Busbl = new BusinessPlanBAL();
        try
        {
            Busbl.MonthYear = txtMonth.Text;
            dt = Busbl.GetPlanAchievementByClient();
            DataView dv = new DataView(dt);
            if (ViewState["SortExpr"] != null)
                dv.Sort = (string)ViewState["SortExpr"] + " " + (string)ViewState["SortDir"];

            gdvBusiness2.DataSource = dv;
            gdvBusiness2.DataBind();

        }
        catch (Exception ex)
        { }
        finally
        {

        }
    }

     protected void gdvBusiness2_Sorting(object sender, GridViewSortEventArgs e)
     {
         ViewState["SortExpr"] = e.SortExpression;
         if (ViewState["SortDir"] != null)
             e.SortDirection = (string)ViewState["SortDir"] == "ASC" ? SortDirection.Descending : SortDirection.Ascending;
         ViewState["SortDir"] = e.SortDirection == SortDirection.Ascending ? "ASC" : "DESC";
         BindGridClient();
         MPEbtnPopupC.Show();
     }

     protected void gdvBusiness2_PageIndexChanging(object sender, GridViewPageEventArgs e)
     {
         gdvBusiness2.PageIndex = e.NewPageIndex;
         BindGridClient();
         MPEbtnPopupC.Show();
     }
   #endregion

     #region   Consultantwise achievement
   private void BindGridConsultant()
     {

         DataTable dt = new DataTable();
         Busbl = new BusinessPlanBAL();
         try
         {
             Busbl.MonthYear = txtMonth.Text;
             dt = Busbl.GetPlanAchievementByConsultant();
             DataView dv = new DataView(dt);
             if (ViewState["SortExpr"] != null)
                 dv.Sort = (string)ViewState["SortExpr"] + " " + (string)ViewState["SortDir"];

             gdvBusiness3.DataSource = dv;
             gdvBusiness3.DataBind();

         }
         catch (Exception ex)
         { }
         finally
         {

         }
     }
  protected void gdvBusiness3_Sorting(object sender, GridViewSortEventArgs e)
     {
         ViewState["SortExpr"] = e.SortExpression;
         if (ViewState["SortDir"] != null)
             e.SortDirection = (string)ViewState["SortDir"] == "ASC" ? SortDirection.Descending : SortDirection.Ascending;
         ViewState["SortDir"] = e.SortDirection == SortDirection.Ascending ? "ASC" : "DESC";
         BindGridConsultant();
         MpePopupCns.Show();
     }
 protected void gdvBusiness3_PageIndexChanging(object sender, GridViewPageEventArgs e)
     {
         gdvBusiness3.PageIndex = e.NewPageIndex;
         BindGridConsultant();
         MpePopupCns.Show();
     }
     #endregion
}