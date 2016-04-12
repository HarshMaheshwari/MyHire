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

public partial class Report_PositionstoBeBilled : BaseClass
{
    MasterBAL mstr;
    ClientBAL clientbal;
    ReportBAL RprtBAL;
    FollowUpBAL FollowBal;
    static int count;
    static string[,] QueryArray = new string[5, 4];
    Search srch;
    static DataTable dt = new DataTable();
    int UserId, URole;
    int MyTimeSpan = 0;



    protected void Page_Load(object sender, EventArgs e)
    {
        UserId = Convert.ToInt32(Session["UserId"]);
        URole = Convert.ToInt32(Session["UserRole"]);
        MyTimeSpan = Convert.ToInt32(ConfigurationManager.AppSettings["TimeSpan"]);

        if (!IsPostBack)
        {
            BindClient();
            BindConsultant();
        //    BindPaymentStatus(ddlPaymentStatus);
          //  BindBillingStatus(ddl);
            RprtBAL = new ReportBAL();
            try
            {

                BindGrid();
            }
            catch (Exception ex)
            {


            }
            finally
            {
                RprtBAL = null;
            }
        }
    }
    private void BindGrid()
    {
        RprtBAL = new ReportBAL();
       
        DataTable dt = new DataTable();
        try
        {

          //  dt = SearchCandidateOfferd();
            dt = getcurrentdata();
            DataView dv = new DataView(dt);
                if (ViewState["SortExpr"] != null)
                    dv.Sort = (string)ViewState["SortExpr"] + " " + (string)ViewState["SortDir"];
          
            gdvCanOfferd.DataSource = dv;
            gdvCanOfferd.DataBind();
        }
        catch (Exception ex)
        {


        }
        finally
        {
            RprtBAL = null;
        }
    }

    protected DataTable getcurrentdata()
    { 
    
         DataTable dt = new DataTable();
         dt = SearchPostionToBeFilled();
          return dt;
     
    }
    protected void gdvCanOfferd_Sorting(object sender, GridViewSortEventArgs e)
    {
        ViewState["SortExpr"] = e.SortExpression;
        if (ViewState["SortDir"] != null)
            e.SortDirection = (string)ViewState["SortDir"] == "ASC" ? SortDirection.Descending : SortDirection.Ascending;
        ViewState["SortDir"] = e.SortDirection == SortDirection.Ascending ? "ASC" : "DESC";
        BindGrid();
    }
    private void BindClient()
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
  
 protected void BindConsultant()
    {
        LoginBAL loginbal = new LoginBAL();
        try
        {
            ListItem li = new ListItem("Select", "0");
            ddlConsultant.Items.Clear();
            ddlConsultant.Items.Add(li);
            //if (URole == 1)
            //{
            //    ddlConsultant.DataSource = loginbal.FillUser();
            //}
            //else if (URole == 9)
            //{
            //    ddlConsultant.DataSource = loginbal.FillUser();
            //}
            //else if (URole == 3 || URole==8)
            //{
            //    loginbal.Usr_Id = UserId;
            //    ddlConsultant.DataSource = loginbal.FillUserByUserId();
            //}
            ddlConsultant.DataSource = loginbal.FillUser();
            ddlConsultant.DataTextField = "USR_Name";
            ddlConsultant.DataValueField = "USR_ID";
            ddlConsultant.DataBind();
        }
        finally
        {
            loginbal = null;
        }
    }
 protected void BindPaymentStatus(DropDownList ddl)
 {
     mstr = new MasterBAL();

     ListItem liC = new ListItem("Select", "0");
     try
     {
         ddl.Items.Clear();
         ddl.Items.Add(liC);
         ddl.DataSource = mstr.getPaymentStatusforDDL();
         ddl.DataTextField = "PaymentStatus";
         ddl.DataValueField = "PaymentStatusId";
         ddl.DataBind();
     }
     finally
     {
        // liC = null;
         mstr = null;
     }

 }
 protected void BindBillingStatus(DropDownList ddl)
 {
     mstr = new MasterBAL();

     ListItem liC = new ListItem("Select", "0");
     try
     {
         ddl.Items.Clear();
         ddl.Items.Add(liC);
         ddl.DataSource = mstr.GetBillingStatusforDDL();
         ddl.DataTextField = "BillStatus";
         ddl.DataValueField = "BillStatusId";
         ddl.DataBind();
     }
     finally
     {
         // liC = null;
         mstr = null;
     }

 }
    protected void gdvCanOfferd_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gdvCanOfferd.PageIndex = e.NewPageIndex;
        BindGrid();
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        dt = SearchPostionToBeFilled();
        gdvCanOfferd.DataSource = dt;
        gdvCanOfferd.DataBind();
    }
    protected DataTable SearchPostionToBeFilled()
    {
        Search srch = new Search();
        string query = "", subquery = "";
        query = "SELECT r.RRCandidate_Id,rr.RRNumber,ud.USR_Name as Consultant,rr.Job_Profile ,cd.Client_Name as Client,r.Overall_Status, rr.Client_Id ," +
                "r.BillStatusId,BillingDate,r.BillingAmount,r.ServiceTax,r.PaymentStatusId,r.PaymentDueDate,r.ReceviedAmount,	" +
                "ps.PaymentStatus,bs.BillStatus,cad.Candidate_Name,ActualDOJ," +
               "  PaymentDueDate  " +
                "FROM RRCandidateRelation as r " +
                "left join RecruitmentRequest as rr on  r.Request_Id=rr.Request_Id  " +
              
                "left join UserDetail as ud on r.Consultant_Id=ud.USR_ID " +
                "left join ClientDetail as cd on rr.Client_Id=cd.Client_Id " +
                "left join BillingStatus as bs on r.BillStatusId =bs.BillStatusId " +
                "left join  PaymentStatus as ps on r.PaymentStatusId=ps.PaymentStatusId " +
                   "inner join  CandidateDetail as cad on  r.Candidate_Id=cad.Candidate_Id  " +
                "where  r.status=1 and r.BillStatusId=1 ";

        if (ddlClientName.SelectedIndex > 0)
        {
            subquery = " and rr.Client_Id= " + Convert.ToInt32(ddlClientName.SelectedValue);
        }

        if (ddlConsultant.SelectedIndex > 0)
        {
            subquery += " and ud.USR_ID= " + Convert.ToInt32(ddlConsultant.SelectedValue);
        }
     

        if (txtfromBillingDate.Text.Trim() != "")
        {
            if (txtToBillingDate.Text.Trim() != "")
            {
                subquery = subquery + " and r.BillingDate between Cast('" + txtfromBillingDate.Text.Trim() + "' as date )  and  Cast('" + txtToBillingDate.Text.Trim() + "' as date ) ";
            }
            else
            {
                subquery = subquery + " and r.BillingDate between Cast('" + txtfromBillingDate.Text.Trim() + "' as date )  and  cast((dateadd(mi," + MyTimeSpan + ",getdate())) as date) ) ";
            }
        }

        //if (Convert.ToInt16(ddlPaymentStatus.SelectedValue) == 1)
        //{
        //    subquery += " and r.PaymentStatusId= " + Convert.ToInt32(ddlPaymentStatus.SelectedValue);
        //}
        //else if (Convert.ToInt16(ddlPaymentStatus.SelectedValue) != 1)
        //{
        //    subquery += " and r.PaymentStatusId= " + Convert.ToInt32(ddlPaymentStatus.SelectedValue);
        //}
        //query = query + " and fw.Candidate_Status in ('Shortlisted','Offered','Offer Accepted','Joined','Selected not Joined') ";
        query = query + subquery;
            //+ " Order by r.CreationDate desc";


        return srch.SearchRecord(query).Tables[0];
    }
  #region Using VerifyRenderingInServerForm
    protected void lbtnDownload_Click(object sender, EventArgs e)
    {
        try
        {
            string fileName = "PositionToBeBilled";
            dt = getcurrentdata();

            string attachment = "attachment; filename=" + fileName + ".xls";
            Response.ClearContent();
            Response.AddHeader("content-disposition", attachment);
            Response.ContentType = "application/vnd.xls"; // ms-excel
            DataGrid dg = new DataGrid();
            dg.DataSource = dt;
            dg.DataBind();
            StringWriter stw = new StringWriter();
            HtmlTextWriter htextw = new HtmlTextWriter(stw);
            dg.RenderControl(htextw);
            Response.Write(stw.ToString());
            Response.End();
        }
        catch (Exception ex)
        {
        }
        finally
        { }
    }
    public override void VerifyRenderingInServerForm(Control control)
    {

    }
    #endregion
  protected void gdvCanOfferd_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if ((e.Row.RowState & DataControlRowState.Edit) > 0)
        {


            //Label lblEPaymentStatusId = ((Label)e.Row.FindControl("lblEPaymentStatusId"));
            //DropDownList ddlEPaymentStatus = ((DropDownList)e.Row.FindControl("ddlEPaymentStatus"));
            //BindPaymentStatus(ddlEPaymentStatus);
            //ddlEPaymentStatus.SelectedValue = lblEPaymentStatusId.Text;

            Label lblEBillStatusId = ((Label)e.Row.FindControl("lblEBillStatusId"));
            DropDownList ddlEBillStatus = ((DropDownList)e.Row.FindControl("ddlEBillStatus"));
            BindBillingStatus(ddlEBillStatus);
            ddlEBillStatus.SelectedValue = lblEBillStatusId.Text;

            //TextBox txtEBillingDate = ((TextBox)e.Row.FindControl("txtEBillingDate"));
            //txtEBillingDate.Text = DateTime.Now.AddMinutes(MyTimeSpan).ToString("dd-MMM-yyyy");
        }

    }
 protected void gdvCanOfferd_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        lblmsg.Text = "";
        gdvCanOfferd.EditIndex = -1;
        BindGrid();
       
    }
 protected void gdvCanOfferd_RowUpdating(object sender, GridViewUpdateEventArgs e)
 {

        GridViewRow gvr = gdvCanOfferd.Rows[e.RowIndex];
        FollowBal = new FollowUpBAL();

        try
        {
            FollowBal.RRCandidateId = Convert.ToInt32(((Label)gvr.FindControl("lblEId")).Text);
       //    FollowBal.PaymentStatusId = Convert.ToInt32(((DropDownList)gvr.FindControl("ddlEPaymentStatus")).SelectedValue);
            FollowBal.BillStatusId = Convert.ToInt32(((DropDownList)gvr.FindControl("ddlEBillStatus")).SelectedValue);
            try
            {
            if (((TextBox)gvr.FindControl("txtEBillingAmount")).Text != "")
            {
                FollowBal.BillingAmount = Convert.ToDouble(((TextBox)gvr.FindControl("txtEBillingAmount")).Text);
            }
            else
            {
                FollowBal.BillingAmount = 0;
            }
             
           
            if (((TextBox)gvr.FindControl("txtEServiceTax")).Text != "")
            {
                FollowBal.ServiceTax = Convert.ToDouble(((TextBox)gvr.FindControl("txtEServiceTax")).Text);
            }
            else
            {
                FollowBal.ServiceTax = 0;
            }
            }
            catch (Exception ex)
            {
                lblmsg.Text = ex.ToString();
            }
            FollowBal.BillingDate = ((TextBox)gvr.FindControl("txtEBillingDate")).Text;
            FollowBal.PaymentDueDate = ((TextBox)gvr.FindControl("txtEPaymentDueDate")).Text;
            FollowBal.LoggedBy = UserId;
            FollowBal.UpdateRRCandidate();
            lblmsg.Text = "Updated successfully.";
            lblmsg.ForeColor = System.Drawing.Color.Green;
            gdvCanOfferd.EditIndex = -1;
            BindGrid();



        }
        catch (Exception ex)
        {
            lblmsg.Text = ex.ToString();
        }
        finally
        {
            FollowBal = null;
        }
    }
  protected void gdvCanOfferd_RowEditing(object sender, GridViewEditEventArgs e)
    {
        lblmsg.Text = "";
        gdvCanOfferd.EditIndex = e.NewEditIndex;
        BindGrid();

    }
}