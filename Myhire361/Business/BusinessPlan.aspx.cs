using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text;
using System.IO;
using System.Configuration;


public partial class Business_BusinessPlan : BaseClass
{
    ReportBAL rptbal;
    BusinessPlanBAL Busbl;
    ClientBAL clientbal;
    int UserId, URole;
    int MyTimeSpan = 0;
    String CurMonth="";
    static DataTable dt;
    static Search srch;
    
    protected void Page_Load(object sender, EventArgs e)
    {
        UserId = Convert.ToInt32(Session["UserId"]);
        URole = Convert.ToInt32(Session["UserRole"]);
        MyTimeSpan = Convert.ToInt32(ConfigurationManager.AppSettings["TimeSpan"]);

        if (!IsPostBack)
        {
            //CurMonth = System.DateTime.Now.AddMinutes(MyTimeSpan).ToString("MMM");
           // ddlMonth.SelectedItem.Text = CurMonth;
            BindClient(ddlClientName);
            BindConsultant(ddlConsltants);
            BindGrid();

        }
    }
    private void BindGrid()
    {
      
         dt = new DataTable();
        try
        {

            dt = SearchBusinessPlan();
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

    private void BindConsultant(DropDownList ddlConsltants)
    {
        rptbal = new ReportBAL();
        try
        {
            ListItem li = new ListItem("All", "0");
            ddlConsltants.Items.Clear();
            ddlConsltants.Items.Add(li);
            ddlConsltants.DataSource = rptbal.GetCounsltatName();
            ddlConsltants.DataTextField = "USR_Name";
            ddlConsltants.DataValueField = "USR_ID";
            ddlConsltants.DataBind();
        }
        finally
        {
            clientbal = null;
        }
    }
    private void BindClient(DropDownList ddlClientName)
    {
        clientbal = new ClientBAL();
        try
        {
            ListItem li = new ListItem("All", "0");
            ddlClientName.Items.Clear();
            ddlClientName.Items.Add(li);
            ddlClientName.DataSource = clientbal.FillClient();
            ddlClientName.DataTextField = "Client_Name";
            ddlClientName.DataValueField = "Client_Id";
            ddlClientName.DataBind();
        }
        finally
        {
            clientbal = null;
        }
    }
   
    protected void gdvBusiness_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gdvBusiness.PageIndex = e.NewPageIndex;
        BindGrid();
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        BindGrid();
    }
    protected DataTable SearchBusinessPlan()
    {
         srch = new Search();
        string query = "", subquery = "";
        query = " select BusinessPlanId, b.Client_Id, BMonth, BYear, ConsultantNo, OffersNo, OfferValue, JoiningNo,usr.USR_Name, Billing, b.Status, cd.Client_Name  " +
                " FROM  BussinessPlan as b "+
                " inner join ClientDetail as cd on cd.Client_Id=b.Client_Id "+
                " inner join UserDetail as usr on cd.USR_ID=usr.USR_ID  "+
                 "    where b.status=1  ";

       
        if (ddlClientName.SelectedIndex > 0)
        {
            subquery = " and b.Client_Id= " + Convert.ToInt32(ddlClientName.SelectedValue);
        }
        if (ddlMonth.SelectedIndex > 0)
        {
            subquery = " and BMonth= " + ddlMonth.SelectedItem.Text;
        }
        if (ddlYear.SelectedIndex > 0)
        {
            subquery = " and BYear= " + ddlYear.SelectedItem.Text;
        }
      
        query = query + subquery + " Order by  cd.Client_Name desc";
        return srch.SearchRecord(query).Tables[0];
    }
  
    protected void gdvBusiness_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Attributes.Add("onclick", "MouseEvents(this, event)");
            e.Row.Attributes.Add("onclick", "MouseEvents(this, event)");
            e.Row.Attributes.Add("onclick", "javascript:ChangeRowColor('" + e.Row.ClientID + "')");


        }
        if ((e.Row.RowState & DataControlRowState.Edit) > 0)
        {

            Label lblEClientId = ((Label)e.Row.FindControl("lblEClientId"));
            DropDownList ddlEClientName = ((DropDownList)e.Row.FindControl("ddlEClientName"));
            BindClient(ddlEClientName);
            ddlEClientName.SelectedValue = lblEClientId.Text;
            Label lblEMonth = ((Label)e.Row.FindControl("lblEMonth"));
            DropDownList ddlEMonth = ((DropDownList)e.Row.FindControl("ddlEMonth"));
            ddlEMonth.SelectedItem.Text = lblEMonth.Text;
            Label lblEYear = ((Label)e.Row.FindControl("lblEYear"));
            DropDownList ddlEYear = ((DropDownList)e.Row.FindControl("ddlEYear"));
            ddlEYear.SelectedItem.Text = lblEYear.Text;

        }

    }
    protected void gdvBusiness_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        lblmsg.Text = "";
        gdvBusiness.EditIndex = -1;
        BindGrid();

    }
    protected void gdvBusiness_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        lblmsg.Text = "";
        GridViewRow gvr = gdvBusiness.Rows[e.RowIndex];
         Busbl=new BusinessPlanBAL();

        try
        {
            Busbl.BusinessPlanId = Convert.ToInt32(((Label)gvr.FindControl("lblEId")).Text);
            Busbl.ClientId = Convert.ToInt32((((DropDownList)gvr.FindControl("ddlEClientName")).SelectedValue.ToString()));
           Busbl.BMonth = ((DropDownList)gvr.FindControl("ddlEMonth")).SelectedItem.Text;
           Busbl.BYear = ((DropDownList)gvr.FindControl("ddlEYear")).SelectedItem.Text;
          if(((TextBox)gvr.FindControl("txtEConsultantNo")).Text!="")
          {
            Busbl.ConsultantNo = Convert.ToDouble(((TextBox)gvr.FindControl("txtEConsultantNo")).Text);
          }
          else
          {
              Busbl.ConsultantNo=0;
          }
          if (((TextBox)gvr.FindControl("txtEOffersNo")).Text != "")
          {
              Busbl.OffersNo = Convert.ToInt32(((TextBox)gvr.FindControl("txtEOffersNo")).Text);
          }
          else
          {
              Busbl.OffersNo = 0;
          }
          if (((TextBox)gvr.FindControl("txtEOfferValue")).Text != "")
          {
              Busbl.OfferValue = Convert.ToInt32(((TextBox)gvr.FindControl("txtEOfferValue")).Text);
          }
          else
          {
              Busbl.OfferValue = 0;
          }
          if (((TextBox)gvr.FindControl("txtEJoiningNo")).Text != "")
          {
              Busbl.JoiningNo = Convert.ToInt32(((TextBox)gvr.FindControl("txtEJoiningNo")).Text);
          }
          else
          {
              Busbl.JoiningNo = 0;
          }
          if (((TextBox)gvr.FindControl("txtEBilling")).Text != "")
          {
              Busbl.Billing = Convert.ToInt32(((TextBox)gvr.FindControl("txtEBilling")).Text);
          }
          else
          {
              Busbl.Billing = 0;
          }
           Busbl.LoggedBy = UserId;
           int Result= Busbl.IU_BussinessPlan();
           if (Result > 0)
            {
                lblmsg.Text = "Updated successfully.";
                lblmsg.ForeColor = System.Drawing.Color.Green;
                gdvBusiness.EditIndex = -1;
                BindGrid();
            }


        }
        catch (Exception ex)
        {

        }
        finally
        {
            Busbl = null;
        }
    }
    protected void gdvBusiness_RowEditing(object sender, GridViewEditEventArgs e)
    {
        lblmsg.Text = "";
        gdvBusiness.EditIndex = e.NewEditIndex;
        BindGrid();

    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        lblmsg.Text = "";
        Busbl=new BusinessPlanBAL();

        try
        {
            Busbl.ClientId=Convert.ToInt32(ddlClientName.SelectedValue);
            Busbl.BMonth = ddlMonth.SelectedItem.Text;
            Busbl.BYear = ddlYear.SelectedItem.Text;
            if (ddlConsltants.SelectedValue != "")
            {
                Busbl.ConsultantNo = Convert.ToDouble(ddlConsltants.SelectedValue);
            }
            else
            {
                Busbl.ConsultantNo = 0;
            }
            if (txtOffersNo.Text!="")
            { 
            Busbl.OffersNo = Convert.ToInt32(txtOffersNo.Text);
            }
            else { Busbl.OffersNo = 0; }
            if (txtOffersValue.Text != "")
            {
                Busbl.OfferValue = Convert.ToInt32(txtOffersValue.Text);
            }
            else { Busbl.OfferValue = 0; }
            if (txtJoiningNo.Text != "")
            {
                Busbl.JoiningNo = Convert.ToInt32(txtJoiningNo.Text);
            }
            else { Busbl.JoiningNo = 0; }
            if (txtBilling.Text != "")
            {
                Busbl.Billing = Convert.ToInt32(txtBilling.Text);
            }
            else { Busbl.Billing = 0; }
            Busbl.LoggedBy = UserId;
           int Result= Busbl.IU_BussinessPlan();
            if(Result==1)
            {
                lblmsg.Text = "Record saved successfully.";
                lblmsg.ForeColor = System.Drawing.Color.Green;
                ddlClientName.SelectedIndex = 0;
                ddlMonth.SelectedItem.Text = "Select";
                ddlYear.SelectedItem.Text = "Select";
                BindGrid();
            }
            else
            {
                lblmsg.Text = "Sorry! Record already exists.";
                lblmsg.ForeColor = System.Drawing.Color.Red;
            }
           
           
        }
        catch (Exception ex)
        {
           
        }
        finally
        {
            Busbl = null;
        }
    }
    
}