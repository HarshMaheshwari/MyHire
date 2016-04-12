using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;
using System.Text;

public partial class Recruitment_ViewPublishJob : BaseClass
{
    static DataTable dt = new DataTable();
    RecruitmentBAL recruitbal;
    ClientBAL clientbal;
    int UserId, Role, count, CountRq;
    static string[,] QueryArray = new string[3, 2];
    Search srch;

    protected void Page_Load(object sender, EventArgs e)
    {
        UserId = Convert.ToInt32(Session["UserId"]);
        Role = Convert.ToInt32(Session["UserRole"]);
        if (!IsPostBack)
        {
            if (Role == 3 || Role==8) //if (Role == 3)
            {
                btnNew.Visible = false;
            }
            BindClient();
            HttpCookie cookie = Request.Cookies["ClientName"];
            if (cookie != null)
            {
                ddlClientName.SelectedValue = cookie["CddlClientName"];
                txtDesigntn.Text = cookie["CtxtDesigntn"];
                ddlRequestStatus.SelectedValue = cookie["CddlRequestStatus"];
            }
            else
            {
                ddlClientName.SelectedIndex = 0;
                txtDesigntn.Text = "";
                ddlRequestStatus.SelectedIndex = 0;
            }

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

    protected void BindGrid()
    {

        try
        {
            count = 0; CountRq = 0;
            if (ddlClientName.SelectedIndex > 0)
            {
                QueryArray[count, 0] = "Rr.Client_Id";
                QueryArray[count, 1] = ddlClientName.SelectedValue.ToString();
                count = count + 1;
            }
            if (txtDesigntn.Text != "")
            {
                QueryArray[count, 0] = "Rr.Designation";
                QueryArray[count, 1] = txtDesigntn.Text;
                count = count + 1;
            }

            if (ddlRequestStatus.SelectedIndex > 0)
            {
                QueryArray[CountRq, 0] = "Rr.Request_Status";
                QueryArray[CountRq, 1] = ddlRequestStatus.SelectedValue.ToString();
                CountRq = CountRq + 1;
            }




            dt = SearchRequset();
            DataView dv = new DataView(dt);
            dv.RowFilter = "Status='" + ddlRecordStatus.SelectedValue + "'";
            if (ViewState["SortExpr"] != null)
                dv.Sort = (string)ViewState["SortExpr"] + " " + (string)ViewState["SortDir"];


            gdvRequest.DataSource = dv;
            gdvRequest.DataBind();

        }
        catch (Exception ex)
        {
        }
        finally
        {

        }
    }

    protected void gdvRequest_Sorting(object sender, GridViewSortEventArgs e)
    {
        ViewState["SortExpr"] = e.SortExpression;
        if (ViewState["SortDir"] != null)
            e.SortDirection = (string)ViewState["SortDir"] == "ASC" ? SortDirection.Descending : SortDirection.Ascending;
        ViewState["SortDir"] = e.SortDirection == SortDirection.Ascending ? "ASC" : "DESC";

        BindGrid();
    }
    protected void btnNew_Click(object sender, EventArgs e)
    {
        Response.Redirect("NewRRequest.aspx");
    }

    protected void gdvRequest_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {

        gdvRequest.PageIndex = e.NewPageIndex;

        BindGrid();
    }

    protected void gdvRequest_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
           
            ImageButton ImgPublish = (ImageButton)e.Row.FindControl("ImgPublish");
            if (Role == 1)
            {
                ImgPublish.Visible = true;
            }
            else
            {
                ImgPublish.Visible = false;
            }
        }
    }

    protected void gdvRequest_RowCommand(object sender, GridViewCommandEventArgs e)
    {
      if (e.CommandName == "Publish")
        {
            GridViewRow gvr = (GridViewRow)((Control)e.CommandSource).NamingContainer;
            int Id = Convert.ToInt32(((Label)gvr.FindControl("lblId")).Text);
            Session["Flag"] = "3";
            string url = "ViewPosToSupervisor.aspx?Id=" + Id;
            Response.Redirect(url);

        }
    }

    protected void imgbtn_Activate_Click(object sender, EventArgs e)
    {
        recruitbal = new RecruitmentBAL();
        ImageButton imgbtn = sender as ImageButton;
        GridViewRow row = imgbtn.NamingContainer as GridViewRow;
        int Id = Convert.ToInt32(gdvRequest.DataKeys[row.RowIndex].Value.ToString());
        string Status = (((Label)gdvRequest.Rows[row.RowIndex].FindControl("lblStatus")).Text);
        recruitbal.Request_Id = Id;
        recruitbal.LoggedBy = UserId;
        if (Status == "Active")
        {
            recruitbal.Status = 0;
            recruitbal.ChangeRequestStatus();
        }
        else
        {
            recruitbal.Status = 1;
            recruitbal.ChangeRequestStatus();
        }


        BindGrid();
    }

    void SaveinExcelFile()
    {
        recruitbal = new RecruitmentBAL();
        try
        {
            string fileName = "RecruitmentRequest";
            //dt = (DataTable)ViewState["dtV"];
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
        catch (Exception e)
        {
        }
    }

    protected void lbtnDownload_Click(object sender, EventArgs e)
    {
        SaveinExcelFile();
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
       HttpCookie cookie = Request.Cookies["ClientName"];
        if (cookie == null)
        {
            cookie = new HttpCookie("ClientName");
        }
        cookie["CddlClientName"] = ddlClientName.SelectedValue.ToString();
        cookie["CtxtDesigntn"] = txtDesigntn.Text;
        cookie["CddlRequestStatus"] = ddlRequestStatus.SelectedValue.ToString();
        cookie.Expires = DateTime.Now.AddMinutes(5);
        Response.Cookies.Add(cookie);


        BindGrid();
    }

    public DataTable SearchRequset()
    {
        srch = new Search();
        StringBuilder sb = new StringBuilder();
        sb.Append(" Select Rr.Request_Id,Rr.RRNumber,Rr.Job_Profile,Rr.Client_Id,Cd.Client_Name,Rr.Total_Position,Rr.Recieve_Date,Rr.Closer_Date, Rr.Criticality,");
        sb.Append(" Rr.Designation,Rr.Min_Salary, Rr.Max_Salary, Rr.Min_Experience,Rr.Max_Experience, Rr.Min_Qualification, Rr.Preferred_Industry, Rr.Request_Status,");
        sb.Append(" Rr.JobFile_Path, Rr.Status,  Rr.Request_By, Ccp.Person_Name, cy.City_Name , case when Rr.PublishStatus=1 then 'Yes' else 'No' end as PublishStatus ");
        sb.Append(" From RecruitmentRequest AS Rr INNER JOIN ClientDetail AS Cd ON Rr.Client_Id = Cd.Client_Id INNER JOIN");
        sb.Append(" ClientContactPerson AS Ccp ON Rr.Request_By = Ccp.Contact_PersonId INNER JOIN");
        sb.Append(" CityDetail AS cy ON Rr.Location_Id = cy.City_Id");
        sb.Append(" where Rr.Request_Id>0");
        if (Role == 2 || Role==6 || Role==7)  //if (Role == 2)
        {
            sb.Append(" and (Cd.USR_ID = " + UserId + " or Rr.CreatedBy = " + UserId + ") ");
        }

        for (int idx = 0; idx < count; idx++)
        {
            sb.Append(" and " + (QueryArray[idx, 0].ToString()) + " Like '%" + (QueryArray[idx, 1].ToString()) + "%'");
        }

        for (int idx = 0; idx < CountRq; idx++)
        {
            sb.Append(" and " + (QueryArray[idx, 0].ToString()) + " = '" + (QueryArray[idx, 1].ToString()) + "' ");
        }



        sb.Append(" Order By Rr.CreationDate DESC, Cd.Client_Name DESC");
        string query = sb.ToString();
        return srch.SearchRecord(query).Tables[0];
    }

    protected void ddlRecordStatus_SelectedIndexChanged(object sender, EventArgs e)
    {
        DataView dv = new DataView(dt);
        dv.RowFilter = "Status='" + ddlRecordStatus.SelectedValue + "'";
        gdvRequest.DataSource = dv;
        gdvRequest.DataBind();
    }
}