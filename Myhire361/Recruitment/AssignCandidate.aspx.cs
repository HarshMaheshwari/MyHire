using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text;

public partial class Recruitment_AssignCandidate : BaseClass
{
    RecruitmentBAL RecBAL;
    int RequestId, UserId, count;
    DataTable dt = new DataTable();
    static DataTable dta = new DataTable(); 
    string[,] QueryArray = new string[8, 7];
    Search srch;
    protected void Page_Load(object sender, EventArgs e)
    {
       
        UserId = Convert.ToInt32(Session["UserId"]);
        RequestId = Convert.ToInt32(Request.QueryString["Id"]);
        if (!IsPostBack)
        {
            BindCandidate();
            BindRRNumber();
        }
    }
    private void BindCandidate()
    {
        dta = SearchCandidate();
        gdvCandidate.DataSource = dta; 
        gdvCandidate.DataBind();
    }
    protected void BindRRNumber()
    {
        RecBAL = new RecruitmentBAL();
        try
        {
            DataTable dt = new DataTable();
            RecBAL.Request_Id = RequestId;
            dt = RecBAL.GetRequestById();
            lblRRNumber.Text = dt.Rows[0]["RRNumber"].ToString();
            lblClient.Text = dt.Rows[0]["Client_Name"].ToString();
            lblDesignation.Text = dt.Rows[0]["Designation"].ToString();
        }
        finally
        {
            RecBAL = null;
        }
    }
    protected void gdvCandidate_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gdvCandidate.PageIndex = e.NewPageIndex;
        gdvCandidate.DataSource = dta;
        gdvCandidate.DataBind();
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        RecBAL = new RecruitmentBAL();
        try
        {
            count = 0;


            if (txtDesg.Text != "")
            {
                QueryArray[count, 0] = "cd.Current_Designation";
                QueryArray[count, 1] = txtDesg.Text;
                count = count + 1;
            }
            if (txtIndustry.Text != "")
            {
                QueryArray[count, 0] = "cd.Industry";
                QueryArray[count, 1] = txtIndustry.Text;
                count = count + 1;
            }
            if (txtCtc.Text != "")
            {
                QueryArray[count, 0] = "cd.Annual_Salary";
                QueryArray[count, 1] = txtCtc.Text;
                count = count + 1;
            }
            if (txtExp.Text != "")
            {
                QueryArray[count, 0] = "cd.WorkExp";
                QueryArray[count, 1] = txtExp.Text;
                count = count + 1;
            }
            if (txtLocation.Text != "")
            {
                QueryArray[count, 0] = "cd.Current_Location";
                QueryArray[count, 1] = txtLocation.Text;
                count = count + 1;
            } if (txtEmp.Text != "")
            {
                QueryArray[count, 0] = "cd.Current_Employer";
                QueryArray[count, 1] = txtEmp.Text;
                count = count + 1;
            }
            dta = SearchCandidate();
            gdvCandidate.DataSource = dta; 
            gdvCandidate.DataBind();
        }
        catch (Exception ex)
        {

        }
        finally
        {
            RecBAL = null;
        }
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        RecBAL = new RecruitmentBAL();
        try
        {
           
            RecBAL.Request_Id = RequestId;
            for (int idx = 0; idx < gdvCandidate.Rows.Count; idx++)
            {
                CheckBox chk = ((CheckBox)gdvCandidate.Rows[idx].FindControl("chkRow"));

                if (chk.Checked == true)
                {
                    Label CandidateId = ((Label)gdvCandidate.Rows[idx].FindControl("lblId"));
                    RecBAL.CandidateId = Convert.ToInt32(CandidateId.Text);
                    RecBAL.ConsultantId = UserId;
                    RecBAL.LoggedBy = UserId;
                    RecBAL.InsertRRCandidate();

                }
            }
        }
        finally
        {
            RecBAL = null;

        }
        Response.Redirect("MyPosition.aspx");
    }
    public DataTable SearchCandidate()
    {
        srch = new Search();
        StringBuilder sb = new StringBuilder();
        sb.Append("SELECT DISTINCT(cd.Candidate_Id), cd.Candidate_Name, cd.Mobile_No, cd.Email, cd.WorkExp, cd.Current_Location,cd.Current_Employer, cd.Current_Designation,");
        sb.Append("  cd.Annual_Salary,cd.Industry FROM CandidateDetail AS cd LEFT JOIN RRCandidateRelation AS rcr ON cd.Candidate_Id = rcr.Candidate_Id");
        sb.Append(" Where cd.Candidate_Id not in (select Candidate_Id from  RRCandidateRelation where Request_Id=" + RequestId + ")");
        for (int idx = 0; idx < count; idx++)
        {
            sb.Append(" and " + (QueryArray[idx, 0].ToString()) + " Like '%" + (QueryArray[idx, 1].ToString()) + "%'");
        }
        sb.Append(" order by cd.Candidate_Name");
        string query = sb.ToString();
        return srch.SearchRecord(query).Tables[0];
    }
}