using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text;
using System.Configuration;


public partial class Recruitment_CreditReferralPoint :BaseClass 
{
    RecruitmentBAL recruitbal;
    FollowUpBAL FollowBal;
    WS_References Sr;
    ClientBAL clntBAL;
    int UserId, Role;
    Search srch;
    DataTable dt = new DataTable();
    int MyTimeSpan = 0;
   
    protected void Page_Load(object sender, EventArgs e)
    {
        UserId = Convert.ToInt32(Session["UserId"]);
        Role = Convert.ToInt32(Session["UserRole"]);
        MyTimeSpan = Convert.ToInt32(ConfigurationManager.AppSettings["TimeSpan"]);
        if (!IsPostBack)
        {
            BindDropdowns();
            BindGrid();
            this.BindGrid();
            gdvCreditPoint.Columns[10].Visible = false;

           
        }
    }

    public void BindDropdowns()
    {
        clntBAL = new ClientBAL();
        ListItem li = new ListItem("All", "0");
        try
        {
           
            ddlClientName.Items.Clear();
            ddlClientName.Items.Add(li);
            ddlClientName.DataSource = clntBAL.FillClient();
            ddlClientName.DataTextField = "Client_Name";
            ddlClientName.DataValueField = "Client_Id";
            ddlClientName.DataBind();
        }
        finally
        {
            clntBAL = null;
        }

       
        FollowBal = new FollowUpBAL();
       try
        {
            ddlCandStatus.Items.Clear();
            ddlCandStatus.Items.Add(li);
            ddlCandStatus.DataSource = FollowBal.FillCandidateStatus();
            ddlCandStatus.DataTextField = "CandidateStatus";
            ddlCandStatus.DataValueField = "CandidateStatus_Id";
            ddlCandStatus.DataBind();
        }
        finally
        {
        }
    }

    private void BindGrid()
    {
        recruitbal = new RecruitmentBAL();
        DataView dv = new DataView();
        try
        {
            dt = SearchCreditPoint();
            dv.Table = dt;

            if (ViewState["SortExpr"] != null)
                dv.Sort = (string)ViewState["SortExpr"] + " " + (string)ViewState["SortDir"];
            gdvCreditPoint.DataSource = dv;
            gdvCreditPoint.DataBind();
           
        }
        finally
        {
            recruitbal = null;
        }

    }

    protected void gdvCreditPoint_Sorting(object sender, GridViewSortEventArgs e)
    {
        ViewState["SortExpr"] = e.SortExpression;
        if (ViewState["SortDir"] != null)
            e.SortDirection = (string)ViewState["SortDir"] == "ASC" ? SortDirection.Descending : SortDirection.Ascending;
        ViewState["SortDir"] = e.SortDirection == SortDirection.Ascending ? "ASC" : "DESC";
        BindGrid();
        this.BindGrid();
        gdvCreditPoint.Columns[10].Visible = false;
    }

    protected void gdvCreditPoint_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gdvCreditPoint.PageIndex = e.NewPageIndex;
        BindGrid();
        this.BindGrid();
        gdvCreditPoint.Columns[10].Visible = false;
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        recruitbal = new RecruitmentBAL();
        try
        {
            dt = SearchCreditPoint();
            gdvCreditPoint.DataSource = dt;
            gdvCreditPoint.DataBind();
        }
        catch (Exception ex)
        {

        }
        finally
        {
            recruitbal = null;
        }
    }

    public DataTable SearchCreditPoint()
    {
        srch = new Search();

        string Qry = @"Select cld.Client_Name,rr.RRNumber,cd.Candidate_Name,cd.Email,
                        cd.Mobile_No,rcr.Candidate_Id,cdr.Candidate_Name as ReferedByName,
                        rcr.ReferedBy,rcr.Overall_Status,isnull(rr.ReferrerPts,0) as TotalReferrerPts,
                        ISNULL(chr.TotalCreditPoint ,'0')  as TotalCreditPoint,
                        IsNull(chr.BalancePoint,isnull(rr.ReferrerPts,0)) as BalancePoint,
                        rcr.Request_Id,rcr.RRCandidate_Id
                        from RRCandidateRelation as rcr
                        inner join RecruitmentRequest as rr on rcr.Request_Id=rr.Request_Id  
                        inner join ClientDetail as cld on rr.Client_Id=cld.Client_Id 
                        inner join CandidateDetail as cd on cd.Candidate_Id=rcr.Candidate_Id 
                        inner join CandidateDetail as cdr on rcr.ReferedBy=cdr.Candidate_Id  
                        left join RefCreditHdr as chr on  rcr.RRCandidate_Id =chr.RRCandidateId and rcr.Request_Id=chr.Request_Id
                        where rcr.Refered='Yes'";
        

        if (ddlCandStatus.SelectedIndex > 0)
        {
            Qry = Qry + " and rcr.Overall_Status = '" + ddlCandStatus.SelectedItem.Text + "'";
        }

        if (ddlClientName.SelectedIndex > 0)
        {
            Qry = Qry + " and cld.Client_Name = '" + ddlClientName.SelectedItem.Text + "'";
        }

        Qry = Qry + " order by Client_Name,rr.RRNumber";

        return srch.SearchRecord(Qry).Tables[0];
    }
    protected void gdvCreditPoint_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        lblmsg.Text = "";
        gdvCreditPoint.EditIndex = -1;
        BindGrid();
        this.BindGrid();
        gdvCreditPoint.Columns[10].Visible = false;
    }

    protected void gdvCreditPoint_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {

        GridViewRow gvr = gdvCreditPoint.Rows[e.RowIndex];
        recruitbal = new RecruitmentBAL();
        DataTable dttotal=new DataTable();
        Sr = new WS_References();
        int result;
       
       
        try
        {
            recruitbal.CandidateId = Convert.ToInt32(((Label)gvr.FindControl("lblReferedBy")).Text);
            recruitbal.RRCandidate_Id = Convert.ToInt32(((Label)gvr.FindControl("lblERRCandidate_Id")).Text);
            recruitbal.Request_Id = Convert.ToInt32(((Label)gvr.FindControl("lblERequest_Id")).Text);
            recruitbal.ReferrerPts = Convert.ToDouble(((Label)gvr.FindControl("lblETotalReferrerPts")).Text);
            recruitbal.LoggedBy = UserId;
            result = Convert.ToInt32(recruitbal.IU_RefCreditHdr());
            

            if (result > 0)
            {
                recruitbal.RefCreditHdrId = result;
                recruitbal.Credit=Convert.ToDouble(((TextBox)gvr.FindControl("txtCreditPoint")).Text);
                recruitbal.Candidatestatus=((Label)gvr.FindControl("lblOverallStatus")).Text;

                dttotal = recruitbal.IU_RefCreditDtl();
                DateTime Creationdate = Convert.ToDateTime(dttotal.Rows[0]["CreationDate"].ToString());
                dttotal.Clear();
                dttotal = recruitbal.GetTotalCreditfrmDtl();
                recruitbal.TotalCreditPoint = Convert.ToDouble(dttotal.Rows[0]["TotalCreditPoint"].ToString());
                recruitbal.UpdateRefCreditHdr();
               
                Sr.InsertPointsCreditHistory(recruitbal.CandidateId, recruitbal.RRCandidate_Id, recruitbal.Credit, Creationdate, UserId);
                gdvCreditPoint.EditIndex = -1;
                BindGrid();
                lblmsg.Text = "Point Credited successfully.";
                lblmsg.ForeColor = System.Drawing.Color.Green;

                this.BindGrid();
                gdvCreditPoint.Columns[10].Visible = false;
                  

            }

          
        }
        catch (Exception ex)
        {
           
        }
        finally
        {
            recruitbal = null;
        }
    }
    protected void gdvCreditPoint_RowEditing(object sender, GridViewEditEventArgs e)
    {
        lblmsg.Text = "";
        this.BindGrid();
        gdvCreditPoint.Columns[10].Visible = true;
        gdvCreditPoint.EditIndex = e.NewEditIndex;
        BindGrid();
       
    }

   
}