using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;
using System.Text;


public partial class Recruitment_UpdTodayPosition : BaseClass
{
    static DataTable dt = new DataTable();
    RecruitmentBAL recruitbal;
    ClientBAL clientbal;
    int UserId, Role, CountCl,CountCont,CountAss, CountReq;
    static string[,] QueryArray = new string[3, 2];
    Search srch;
    int result;
    TodayPositionBAL TodPos;
   
    
    protected void Page_Load(object sender, EventArgs e)
    {
        UserId = Convert.ToInt32(Session["UserId"]);
        Role = Convert.ToInt32(Session["UserRole"]);
        if (!IsPostBack)
        {
          
            BindClient();
            BindConsultant();
            BindGrid();

            try
            {
                Session["Rid"] = null;
                Session["Flag"] = null;
            }
            catch (Exception ex)
            {
            }
        }
    }

    private void BindClient()
    {
        clientbal = new ClientBAL();
        try
        {
            ListItem li = new ListItem("All", "0");
            ddlClientName.Items.Clear();
            ddlClientName.Items.Add(li);
            if (Role == 1)
            {
                ddlClientName.DataSource = clientbal.FillClient();
            }
            else if (Role == 9)
            {
                ddlClientName.DataSource = clientbal.FillClient();
            }
            else
            {
                clientbal.UserId = UserId;
                ddlClientName.DataSource = clientbal.FillClientByUserId();
            }
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
             if (Role == 1)
            {
                 ddlConsultant.DataSource = loginbal.FillUser();
            }
             else if (Role == 9)
             {
                 ddlConsultant.DataSource = loginbal.FillUser();
             }
             else if (Role == 3 || Role == 8)     //(Role == 3)
            {
                loginbal.Usr_Id = UserId;
                ddlConsultant.DataSource = loginbal.FillUserByUserId();
            }
             ddlConsultant.DataTextField = "USR_Name";
            ddlConsultant.DataValueField = "USR_ID";
            ddlConsultant.DataBind();


            
        }
        finally
        {
            loginbal = null;
        }
    }
 protected void BindGrid()
    {

        try
        {
            dt = SearchGridData();
            DataView dv = new DataView(dt);
            
            dv.RowFilter = "Status='" + ddlRecordStatus.SelectedValue + "'";
            if (ViewState["SortExpr"] != null)
                dv.Sort = (string)ViewState["SortExpr"] + " " + (string)ViewState["SortDir"];

            gdvData.DataSource = dv;
            gdvData.DataBind();

        }
        catch (Exception ex)
        {
        }
        finally
        {

        }
    }
 protected void gdvData_Sorting(object sender, GridViewSortEventArgs e)
    {
        ViewState["SortExpr"] = e.SortExpression;
        if (ViewState["SortDir"] != null)
            e.SortDirection = (string)ViewState["SortDir"] == "ASC" ? SortDirection.Descending : SortDirection.Ascending;
        ViewState["SortDir"] = e.SortDirection == SortDirection.Ascending ? "ASC" : "DESC";

        BindGrid();
    }
 protected void gdvData_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gdvData.PageIndex = e.NewPageIndex;
        BindGrid();
       
      
    }
 protected void gdvData_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {


            Label lblChkIsTodayPos = (Label)e.Row.Cells[0].FindControl("lblChkIsTodayPos");
            CheckBox ChkIsTodayPos = (CheckBox)e.Row.Cells[0].FindControl("ChkIsTodayPos");

            if (lblChkIsTodayPos.Text == "1")
            {
                ChkIsTodayPos.Checked = true;
                e.Row.BackColor = System.Drawing.Color.PaleTurquoise;

            }
            else
            {
                ChkIsTodayPos.Checked = false;
            }

        }

       
    }
 protected void btnSearch_Click(object sender, EventArgs e)
    {

        BindGrid();
    }

 public DataTable SearchGridData()
 {
     srch = new Search();
     StringBuilder sb = new StringBuilder();
     sb.Append(" select ur.Relation_Id, ur.Request_Id, ur.Consultant_Id, ur.Assign_Date, ur.Status,Rr.RRNumber,cd.Client_Id,Rr.Job_Profile as Role,cy.City_Name  ,Rr.Request_Status,Cd.Client_Name,ud.USR_Name as Consultants  ");
     sb.Append(" ,ur.TodayPosition, case when ur.TodayPosition=1 then 'Yes' when ur.TodayPosition=0 then 'No' end as TodayPositiontxt from UserClientRelation as ur ");
     sb.Append("  inner join RecruitmentRequest as Rr on ur.Request_Id=Rr.Request_Id INNER JOIN CityDetail AS cy ON Rr.Location_Id = cy.City_Id  ");
     sb.Append("  inner join ClientDetail as cd on cd.Client_Id=Rr.Client_Id ");
     sb.Append(" inner join UserDetail as ud on Ur.Consultant_Id=ud.USR_ID ");
     sb.Append("  where Rr.Request_Id>0 and ur.Status=1 and ud.status=1 and  (Rr.Status=1)  and cd.Status=1  ");
    //if (UserId > 0 && Role == 3)
     if (UserId > 0 && (Role == 3 || Role == 8))
     {
         sb.Append(" and Cr.Consultant_Id='" + UserId + "'");
     }

     if (UserId > 0 && (Role == 2 || Role==7))
     {
         sb.Append(" and (cd.USR_ID = " + UserId + " or Rr.CreatedBy = " + UserId + ") ");
     }

     if (ddlClientName.SelectedIndex > 0)
     {
         sb.Append(" and Cd.Client_Id = '" + ddlClientName.SelectedValue + "'");
     }
     if (ddlConsultant.SelectedIndex > 0)
     {
         sb.Append(" and ur.Consultant_Id = '" + ddlConsultant.SelectedValue + "'");
     }
     if (txtAssigndt.Text != "")
     {
         sb.Append(" and ur.Assign_Date like  '%" + txtAssigndt.Text + "%'");
     }
     if (ddlRequestStatus.SelectedIndex > 0)
     {
         sb.Append(" and Rr.Request_Status = '" + ddlRequestStatus.SelectedItem.Text + "'");
     }
     sb.Append(" order by ur.TodayPosition Desc,ud.USR_Name Asc,Cd.Client_Name Asc ");
     string query = sb.ToString();
     return srch.SearchRecord(query).Tables[0];
 }

 
 protected void ddlRecordStatus_SelectedIndexChanged(object sender, EventArgs e)
    {
        DataView dv = new DataView(dt);
        dv.RowFilter = "Status='" + ddlRecordStatus.SelectedValue + "'";
        gdvData.DataSource = dv;
        gdvData.DataBind();

    }
 protected void btnSave_Click(object sender, EventArgs e)
    {
        TodPos = new TodayPositionBAL();
        String StrFulRelId, strchkTodayPos;
        StrFulRelId = "";
        strchkTodayPos = "";
      
        try
        {

            TodPos.LoggedBy = UserId;
            for (int idx = 0; idx < gdvData.Rows.Count; idx++)
            {
                
                    CheckBox ChkIsTodayPos = ((CheckBox)(gdvData.Rows[idx].FindControl("ChkIsTodayPos")));

                    if (ChkIsTodayPos.Checked == true)
                    { 
                        strchkTodayPos=strchkTodayPos+1+",";
                      
                    }
                    else
                    {
                        strchkTodayPos = strchkTodayPos + 0 + ",";
                       
                    }
                    StrFulRelId = StrFulRelId + ((Label)(gdvData.Rows[idx].FindControl("lblRelation_Id"))).Text + ",";
                
            }
            try
            {
                StrFulRelId = StrFulRelId.Substring(0, StrFulRelId.Length - 1);
                strchkTodayPos = strchkTodayPos.Substring(0, strchkTodayPos.Length - 1);
            }
            catch (Exception ex12) { }
            TodPos.RelIdFul = StrFulRelId;
            TodPos.TodayPos = strchkTodayPos;
            result = TodPos.Upd_TodayPosition();

            if (result > 0)
            {
                lblmsg.Text = "Today Position Updated  Successfully !.";
                lblmsg.ForeColor = System.Drawing.Color.Green;
                BindGrid();

            }
           
        }
        catch (Exception ex)
        {
            lblmsg.Text = ex.Message.ToString();
        }
        finally
        {
            TodPos = null;
        }

    }
}