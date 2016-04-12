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

public partial class Reports : BaseClass
{
    DashboardBAL dshBAL;
    int UserId,URole;
    static int CountSentForApproval;
     static DataTable dt = new DataTable();
      int MyTimeSpan = 0;
   
  
    protected void Page_Load(object sender, EventArgs e)
    {
        UserId = Convert.ToInt32(Session["UserId"]);
        URole = Convert.ToInt32(Session["UserRole"]);
         MyTimeSpan = Convert.ToInt32(ConfigurationManager.AppSettings["TimeSpan"]);

        if (!IsPostBack)
        {
          //  SearchforRRCandidate();   
        }
    }
    #region ------ RR Candidate Table Data-------
    protected DataTable SearchforRRCandidate()
    {
        Search srch = new Search();
        string query = "", subquery = "";
        query = "Select * from RRCandidateRelation ";
              
                  
        
        if (txtfrom.Text.Trim() != "")
        {
            if (txtTo.Text.Trim() != "")
            {
                subquery = subquery + "where   cast(CreationDate as date) between Cast('" + txtfrom.Text.Trim() + "' as date )  and  Cast('" + txtTo.Text.Trim() + "' as date ) ";
            }
            else
            {
                subquery = subquery + " and cast(CreationDate as date) between Cast('" + txtfrom.Text.Trim() + "' as date )  and  cast((dateadd(mi," + MyTimeSpan + ",getdate())) as date) ) ";
            }
        }
        query = query + subquery ;


        return srch.SearchRecord(query).Tables[0];
    }

       protected void lbtnDownloadRRCandidate_Click(object sender, ImageClickEventArgs e)
       {
           try
           {
               string fileName = "RRCandidate Table";
               DataView dv = new DataView();
               dshBAL = new DashboardBAL();
               dt = SearchforRRCandidate();
               //   dt = getcurrentdata();  
               //  dt.Columns.Remove("FollowUp_Id");


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
           {
               
           }
       }
    #endregion






   #region----FollowupTable----
       protected DataTable SearchforFollowUp()
       {
           Search srch = new Search();
           string query = "", subquery = "";
           query = " select * from followup ";



           if (txtfrom.Text.Trim() != "")
           {
               if (txtTo.Text.Trim() != "")
               {
                   subquery = subquery + "where   cast(CreationDate as date) between Cast('" + txtfrom.Text.Trim() + "' as date )  and  Cast('" + txtTo.Text.Trim() + "' as date ) ";
               }
               else
               {
                   subquery = subquery + " and cast(CreationDate as date) between Cast('" + txtfrom.Text.Trim() + "' as date )  and  cast((dateadd(mi," + MyTimeSpan + ",getdate())) as date) ) ";
               }
           }
           query = query + subquery;


           return srch.SearchRecord(query).Tables[0];
       }


       protected void lbtnDownloadFollowUp_Click(object sender, ImageClickEventArgs e)
       {
           try
           {
               string fileName = "FollowUp Table";
               DataView dv = new DataView();
               dshBAL = new DashboardBAL();
               dt = SearchforFollowUp();
               //   dt = getcurrentdata();  
               //  dt.Columns.Remove("FollowUp_Id");


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
           {

           }
       }
   #endregion

       #region----RecruitmentRequest----
       protected DataTable SearchforRecruitmentRequest()
       {
           Search srch = new Search();
           string query = "", subquery = "";
           query = "Select * from RecruitmentRequest ";



           if (txtfrom.Text.Trim() != "")
           {
               if (txtTo.Text.Trim() != "")
               {
                   subquery = subquery + "where   cast(CreationDate as date) between Cast('" + txtfrom.Text.Trim() + "' as date )  and  Cast('" + txtTo.Text.Trim() + "' as date ) ";
               }
               else
               {
                   subquery = subquery + " and cast(CreationDate as date) between Cast('" + txtfrom.Text.Trim() + "' as date )  and  cast((dateadd(mi," + MyTimeSpan + ",getdate())) as date) ) ";
               }
           }
           query = query + subquery;


           return srch.SearchRecord(query).Tables[0];
       }


    protected void lbtnDownloadRecuritment_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            string fileName = "RecruitmentRequest";
            DataView dv = new DataView();
            dshBAL = new DashboardBAL();
            dt = SearchforRecruitmentRequest();
            //   dt = getcurrentdata();  
            //  dt.Columns.Remove("FollowUp_Id");


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
        {

        }
    }
       #endregion

    #region----Consultant----
    protected DataTable SearchforConsultants()
    {
        Search srch = new Search();
        string query = "", subquery = "";
        query = " select * from UserDetail ";



        if (txtfrom.Text.Trim() != "")
        {
            if (txtTo.Text.Trim() != "")
            {
                subquery = subquery + "where   cast(CreationDate as date) between Cast('" + txtfrom.Text.Trim() + "' as date )  and  Cast('" + txtTo.Text.Trim() + "' as date ) ";
            }
            else
            {
                subquery = subquery + " and cast(CreationDate as date) between Cast('" + txtfrom.Text.Trim() + "' as date )  and  cast((dateadd(mi," + MyTimeSpan + ",getdate())) as date) ) ";
            }
        }
        query = query + subquery;


        return srch.SearchRecord(query).Tables[0];
    }

    protected void lbtnDownloadConsultant_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            string fileName = "Consultants Table";
            DataView dv = new DataView();
            dshBAL = new DashboardBAL();
            dt = SearchforConsultants();
            //   dt = getcurrentdata();  
            //  dt.Columns.Remove("FollowUp_Id");


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
        {

        }

    }
    #endregion


    #region----ClientDetails----
    protected DataTable SearchforClientDetail()
    {
        Search srch = new Search();
        string query = "", subquery = "";
        query = " select * from ClientDetail ";



        if (txtfrom.Text.Trim() != "")
        {
            if (txtTo.Text.Trim() != "")
            {
                subquery = subquery + "where   cast(CreationDate as date) between Cast('" + txtfrom.Text.Trim() + "' as date )  and  Cast('" + txtTo.Text.Trim() + "' as date ) ";
            }
            else
            {
                subquery = subquery + " and cast(CreationDate as date) between Cast('" + txtfrom.Text.Trim() + "' as date )  and  cast((dateadd(mi," + MyTimeSpan + ",getdate())) as date) ) ";
            }
        }
        query = query + subquery;


        return srch.SearchRecord(query).Tables[0];
    }

    protected void lbtnDownloadClient_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            string fileName = "ClientDetail Table";
            DataView dv = new DataView();
            dshBAL = new DashboardBAL();
            dt = SearchforClientDetail();
         
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
        {

        }

    }
    #endregion

    #region----CityDetails----
    protected DataTable SearchforCityDetail()
    {
        Search srch = new Search();
        string query = "", subquery = "";
        query = " select * from CityDetail ";



        if (txtfrom.Text.Trim() != "")
        {
            if (txtTo.Text.Trim() != "")
            {
                subquery = subquery + "where   cast(CreationDate as date) between Cast('" + txtfrom.Text.Trim() + "' as date )  and  Cast('" + txtTo.Text.Trim() + "' as date ) ";
            }
            else
            {
                subquery = subquery + " and cast(CreationDate as date) between Cast('" + txtfrom.Text.Trim() + "' as date )  and  cast((dateadd(mi," + MyTimeSpan + ",getdate())) as date) ) ";
            }
        }
        query = query + subquery;


        return srch.SearchRecord(query).Tables[0];
    }

    protected void lbtnDownloadLocation_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            string fileName = "CityDetail Table";
            DataView dv = new DataView();
            dshBAL = new DashboardBAL();
            dt = SearchforCityDetail();
            //   dt = getcurrentdata();  
            //  dt.Columns.Remove("FollowUp_Id");


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
        {

        }
    }

#endregion

    #region----Canddidate details----
    protected DataTable SearchforCandidate()
    {
        Search srch = new Search();
        string query = "", subquery = "";
        query = " select * from CandidateDetail ";



        if (txtfrom.Text.Trim() != "")
        {
            if (txtTo.Text.Trim() != "")
            {
                subquery = subquery + "where   cast(CreationDate as date) between Cast('" + txtfrom.Text.Trim() + "' as date )  and  Cast('" + txtTo.Text.Trim() + "' as date ) ";
            }
            else
            {
                subquery = subquery + " and cast(CreationDate as date) between Cast('" + txtfrom.Text.Trim() + "' as date )  and  cast((dateadd(mi," + MyTimeSpan + ",getdate())) as date) ) ";
            }
        }
        query = query + subquery;


        return srch.SearchRecord(query).Tables[0];
    }

    protected void lbtnDownloadCandidate_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            string fileName = "CandidateDetail Table";
            DataView dv = new DataView();
            dshBAL = new DashboardBAL();
            dt = SearchforCandidate();
           
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
        {

        }

    }
    #endregion
    #region Using VerifyRenderingInServerForm
     public override void VerifyRenderingInServerForm(Control control)
    {

    }
    #endregion
}