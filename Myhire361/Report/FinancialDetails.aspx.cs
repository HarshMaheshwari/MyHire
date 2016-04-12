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

public partial class Report_FinancialDetails : BaseClass
{
    DashboardBAL dshBAL;
    FollowUpBAL flwupbal;
    LoginBAL loginbal;
    ClientBAL clientbal;
    ReportBAL RprtBAL;
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
      
        DataView dv = new DataView();
        dshBAL = new DashboardBAL();
        try
        {

            dshBAL.ConsultantId = UserId;
            dv.Table = dshBAL.getForFinanicalReport();
            if (ViewState["SortExpr"] != null)
                dv.Sort = (string)ViewState["SortExpr"] + " " + (string)ViewState["SortDir"];
            gdvInterview.DataSource = dv;
            gdvInterview.DataBind();
        }
        catch (Exception ex)
        {

        }
        finally
        {
            dshBAL = null;
        }
    
        //RprtBAL = new ReportBAL();
        //DataView dv = new DataView();
        //try
        //{

        //    dv.Table = SearchforRRcCandidate();
        //    if (ViewState["SortExpr"] != null)
        //        dv.Sort = (string)ViewState["SortExpr"] + " " + (string)ViewState["SortDir"];
           
        //    gdvInterview.DataSource = dv;
        //    gdvInterview.DataBind();
        //}
        //catch (Exception ex)
        //{


        //}
        //finally
        //{
        //    RprtBAL = null;
        //}
    }
    protected void gdvInterview_Sorting(object sender, GridViewSortEventArgs e)
    {
        ViewState["SortExpr"] = e.SortExpression;
        if (ViewState["SortDir"] != null)
            e.SortDirection = (string)ViewState["SortDir"] == "ASC" ? SortDirection.Descending : SortDirection.Ascending;
        ViewState["SortDir"] = e.SortDirection == SortDirection.Ascending ? "ASC" : "DESC";
        BindGrid();
    }
   
   
   
    protected void gdvInterview_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gdvInterview.PageIndex = e.NewPageIndex;
        BindGrid();
    }
    //protected void btnSearch_Click(object sender, EventArgs e)
    //{
      
    //    dt = SearchforRRcCandidate();
    //    gdvInterview.DataSource = dt;
    //    gdvInterview.DataBind();
    //}

    //protected DataTable SearchforRRcCandidate()
    //{
    //    Search srch = new Search();
    //    string query = "", subquery = "";
    //    query = "Select * from ( " +
    //            "Select * from ( " +
    //            "Select Count(Cr.RRCandidate_Id) as NoOfOffers,sum(Cr.OfferPrice) as offerPrice, right(Cr.OfferDate,8) as OfferDate  " +
    //                "		from RRCandidateRelation as Cr  " +
    //                    "	Where Cr.status=1 and Cr.OfferDate is not NULL   " +
    //                    "	group by  " +
    //                    "	right(Cr.OfferDate,8)  " +
    //                    "	) as t Where t.OfferDate!='') as tt " +
    //            "left join( " +


    //            "Select * from ( " +
    //            "Select Count(Cr.RRCandidate_Id) as NoOfJoinings,sum(Cr.OfferPrice) as JoiningValue, right(Cr.ActualDOJ,8) as ActualDOJ  " +
    //            "	,	Count(right(Cr.PlannedDOJ,8)) as PlannedDOJNo		from RRCandidateRelation as Cr " +
    //            "			Where Cr.status=1 and Cr.ActualDOJ is not NULL " +
    //            "			group by  " +
    //            "			right(Cr.ActualDOJ,8)  " +
    //            "			) as t Where t.ActualDOJ!='') as ta on tt.OfferDate=ta.ActualDOJ " +
    //            "left join( " +
    //            "Select * from ( " +
    //            "Select Count(Cr.RRCandidate_Id) as NoOfOffers, " +
    //            "sum(Cr.BillingAmount) as BillingAmount, " +
    //            "Sum(Cr.ReceviedAmount) as RecevingAmount, " +
    //            "right(Cr.BillingDate,8) as BillingDate ,Count(right(Cr.BillingDate,8)) as NoOfbilling  " +

    //                        "from RRCandidateRelation as Cr " +
    //                    "	Where Cr.status=1 and Cr.BillingDate is not NULL  " +
    //                    "	group by  " +
    //                    "	right(Cr.BillingDate,8)  " +
    //                    "	) as t Where t.BillingDate!='') as tc on tc.BillingDate=ta.ActualDOJ ";

    //    #region
    //    // query = "Select * from " +
    //   // " ( " +
    //   // "Select Count(Distinct(Cr.RRCandidate_Id)) as NoOfOffers,Cr.Consultant_Id,sum(Cr.OfferPrice) as offerPrice, Cr.Status,Cr.ActualDOJ," +
    //   //" ((cast(datepart(month,cast(Cr.OfferDate as date)) as varchar)) +'-'+ cast(datepart(Year,cast(Cr.OfferDate as date)) as varchar(10))) as OfferDate  " +
    //   // " from RRCandidateRelation as Cr " +
      
    //   //             //--where Cr.Consultant_Id=26 --and Cr.OfferPrice!=null
    //   // " group by Cr.Consultant_Id, cr.Status,Cr.ActualDOJ,OfferDate) as y " +

    //   // " inner join " +

    //   // " (Select  " +
    //   // " Count(Crr.RRCandidate_Id) as NoOfOfferpeirce,Crr.Consultant_Id,Sum(Crr.OfferPrice) as JoinedValue ," +
    //   //    " ((cast(datepart(month,cast(Crr.OfferDate as date)) as varchar)) +'-'+ cast(datepart(Year,cast(Crr.OfferDate as date)) as varchar(10))) as OfferDate  " +
    //   // " from RRCandidateRelation as Crr " +
    //   //             //--where Cr.Consultant_Id=26 --and Cr.OfferPrice!=null
    //   // " group by Crr.Consultant_Id,OfferDate ) as t " +
    //   // "  on y.Consultant_Id=t.Consultant_Id " +
    //   // "  inner join " +
    //   //  " ( " +

    //   // "  Select " +
    //   // " Count(Crb.RRCandidate_Id) as NoOfBILLAmount,Crb.Consultant_Id,Sum(Crb.BillingAmount) as BillingAmount,Sum(Crb.ReceviedAmount) as RecevingAmount, " +
    //   //  " ((cast(datepart(month,cast(Crb.OfferDate as date)) as varchar)) +'-'+ cast(datepart(Year,cast(Crb.OfferDate as date)) as varchar(10))) as OfferDate  " +
    //   // " from RRCandidateRelation as Crb " +
    //   //             //--where Cr.Consultant_Id=26 --and Cr.OfferPrice!=null
    //   // " group by Crb.Consultant_Id ,OfferDate) as z " +
    //   // "  on y.Consultant_Id= z.Consultant_Id " +
    //    //  " where y.Status=1 ";
    //    #endregion



    //    if (txtFrom.Text.Trim() != "")
    //    {
    //        if (txtTo.Text.Trim() != "")
    //        {
    //            subquery = subquery + " and (right(tt.OfferDate,8)  ) between right('" + txtFrom.Text.Trim() + "' ,8 )  and  right('" + txtTo.Text.Trim() + "' ,8 ) ";
    //        }
    //        else
    //        {
    //            subquery = subquery + " and (right(tt.OfferDate,8)) between right('" + txtFrom.Text.Trim() + "' ,8 )  or   right('" + txtTo.Text.Trim() + "' ,8 )";
    //            //cast((dateadd(mi," + MyTimeSpan + ",getdate())) as date) ) ";
    //        }
    //    }

             
    //    query = query + subquery;
        
    //    return srch.SearchRecord(query).Tables[0];
    //}
 
    #region Using VerifyRenderingInServerForm
    //protected void lbtnDownload_Click(object sender, EventArgs e)
    //{
    //    try
    //    {
    //        string fileName = "SelectedCandidates";
    //        //dt = (DataTable)ViewState["dtV"];

    //        string attachment = "attachment; filename=" + fileName + ".xls";
    //        Response.ClearContent();
    //        Response.AddHeader("content-disposition", attachment);
    //        Response.ContentType = "application/vnd.xls"; // ms-excel
    //        DataGrid dg = new DataGrid();
    //        //dt.Columns.Remove("Request_Id");
    //        //dt.Columns.Remove("Candidate_Id");
    //        //dt.Columns.Remove("Consultant_Id");
    //        //dt.Columns.Remove("Status");
    //        //dt.Columns.Remove("CreatedBy");
    //        //dt.Columns.Remove("CreationDate");
    //        //dt.Columns.Remove("UpdatedBy");
    //        //dt.Columns.Remove("UpdationDate");
    //        //dt.Columns.Remove("ReferedBy");
    //        //dt.Columns.Remove("ShowName");
    //        //dt.Columns.Remove("ReferStatus");
    //        //dt.Columns.Remove("UpdationDate");
    //        //dt.Columns.Remove("Job_Profile");
    //        //dt.Columns.Remove("Client_Id");
    //        //dt.Columns.Remove("USR_ID");
    //        //    dt.AcceptChanges();
    //        dg.DataSource = dt;

    //        dg.DataBind();
    //        StringWriter stw = new StringWriter();
    //        HtmlTextWriter htextw = new HtmlTextWriter(stw);
    //        dg.RenderControl(htextw);
    //        Response.Write(stw.ToString());
    //        Response.End();
    //    }
    //    catch (Exception ex)
    //    {
    //    }
    //    finally
    //    { }
    //}
    //public override void VerifyRenderingInServerForm(Control control)
    //{

    //}
    #endregion

    protected void gdvInterview_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Attributes.Add("onclick", "MouseEvents(this, event)");
            e.Row.Attributes.Add("onclick", "MouseEvents(this, event)");
            e.Row.Attributes.Add("onclick", "javascript:ChangeRowColor('" + e.Row.ClientID + "')");
        }

    }
}