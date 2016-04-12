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

public partial class Candidate_UploadCandidate : BaseClass
{
    RecruitmentBAL RecBAL;
    static int RequestId;
    int UserId;
    string[,] QueryArray = new string[3, 2];
    Search srch;
    int MyTimeSpan = 0;
   

    protected void Page_Load(object sender, EventArgs e)
    {

        try
        {
            UserId = Convert.ToInt32(Session["UserId"]);
            RequestId = Convert.ToInt32(Session["Rid"]);
            MyTimeSpan = Convert.ToInt32(ConfigurationManager.AppSettings["TimeSpan"]);
        }
        catch (Exception ex)
        {
        }
        if (!IsPostBack)
        {
            BindCandidate();
            BindSource();
        }


    }

    private void BindSource()
    {
        RecBAL = new RecruitmentBAL ();
        try
        {
            ListItem li = new ListItem("All", "All");
            ddlSource.Items.Clear();
            ddlSource.Items.Add(li);
            ddlSource.DataSource = RecBAL.GetSourceforDDL();
            ddlSource.DataTextField = "Source";
            ddlSource.DataValueField = "Source";
            ddlSource.DataBind();
        }
        finally
        {
            RecBAL = null;
        }
    }

    private void BindCandidate()
    {
        RecBAL = new RecruitmentBAL();
        try
        {
            DataView dv = new DataView();
            dv.Table = SearchCandidate();
            if (ViewState["SortExpr"] != null)
                dv.Sort = (string)ViewState["SortExpr"] + " " + (string)ViewState["SortDir"];
            gdvCandidate.DataSource = dv;
            gdvCandidate.DataBind();

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


    protected void gdvCandidate_Sorting(object sender, GridViewSortEventArgs e)
    {
        ViewState["SortExpr"] = e.SortExpression;
        if (ViewState["SortDir"] != null)
            e.SortDirection = (string)ViewState["SortDir"] == "ASC" ? SortDirection.Descending : SortDirection.Ascending;
        ViewState["SortDir"] = e.SortDirection == SortDirection.Ascending ? "ASC" : "DESC";


        BindCandidate();
    }
    //protected void gdvCandidate_PageIndexChanging(object sender, GridViewPageEventArgs e)
    //{
    //    lblmsg.Text = "";
    //    gdvCandidate.PageIndex = e.NewPageIndex;
    //    BindCandidate();
    //}

  
  
    protected void btnSearch_Click(object sender, EventArgs e)
    {

        BindCandidate();

    }
   
    public DataTable SearchCandidate()
    {
        srch = new Search();
        StringBuilder sb = new StringBuilder();
        sb.Append("  Select Top 300 cd.Candidate_Id,cd.Candidate_Name,cd.Mobile_No,cd.Email,cd.WorkExp,cd.Current_Employer,cd.Current_Designation,cd.Annual_Salary , ");
        sb.Append(" cd.Previous_Employer,(Isnull(cd.UG_Institute,PG_Institute)) as University ,cd.Resume_Title,cd.Resume_Path,cd.Source,cd.LinkedInProfile  ");
        sb.Append(" ,cd.Resumer_Id,Replace(Convert(varchar(20),Cast(cd.CreationDate as DATE), 106),' ','-') as CreationDate ");
        sb.Append(" From CandidateDetail  as cd ");
        sb.Append(" Where cd.Status=1 and (cd.Resume_Path='' OR cd.Resume_path is Null )  and Cast(cd.CreationDate as DATE)>=Cast(DATEADD(dd, -90, DateADD(Minute,750,GETDATE())) as DATE) ");
        //-------------------------------------------------------------------------------------------------------------
        if (txtName.Text != "")
        {
            sb.Append(" and  cd.Candidate_Name like '%" + txtName.Text + "%'");

        }
        if (txtMobile.Text != "")
        {
            sb.Append(" and  cd.Mobile_No like '%" + txtMobile.Text + "%'");

        }
       
        if (ddlSource.SelectedIndex >0)
        {
            sb.Append(" and  cd.Source = '" + ddlSource.SelectedItem.Text + "'");

        }
       

        sb.Append(" order by cd.CreationDate Asc ");
        string query = sb.ToString();
        return srch.SearchRecord(query).Tables[0];
    }

    protected void btnNew_Click(object sender, EventArgs e)
    {
        Response.Redirect("CandidateForm.aspx");
    }

    protected void btnAdd_Click(object sender, EventArgs e)
    {
        Response.Redirect("NewCandidate.aspx");

    }
    protected void btnUpload_Click(object sender, EventArgs e)
    {
        int CandidateId = 0;

        try
        {
            RecBAL = new RecruitmentBAL();
            RecBAL.LoggedBy  = UserId;

            foreach (GridViewRow gdvr in gdvCandidate.Rows)
            {
                CandidateId = Convert.ToInt32(((Label)gdvr.FindControl("lblId")).Text);
                RecBAL.CandidateId = CandidateId;
              
                FileUpload fblk = (FileUpload)gdvr.FindControl("flUploadUrl");
                if (fblk.PostedFile.FileName != "")
                {
                   
                    string filename = Path.GetFileName(fblk.PostedFile.FileName);
                    string Extension = Path.GetExtension(filename);
                    Extension = Extension.ToLower();
                    if (Extension == ".doc" || Extension == ".docx")
                    {
                      
                        fblk.SaveAs(Server.MapPath("~/Resume/" + CandidateId  + Extension));
                        String ResumePath = "~/Resume/" + CandidateId + Extension;
                        RecBAL.Resume_Path = ResumePath;
                        try
                        {

                            RecBAL.UpdateCandidateUrlNSorce();
                        }
                        catch (Exception ex)
                        {
                            
                        }

                    }
                    else
                    {
                        lblmsg.Text = "Only Word files are Accepted";
                    }
                }
            }
           
        }
           
        catch (Exception ex)
        {
            lblmsg.Text = ex + "";
        }
        finally
        {
            RecBAL = null;
            BindCandidate();
        }
    }


}