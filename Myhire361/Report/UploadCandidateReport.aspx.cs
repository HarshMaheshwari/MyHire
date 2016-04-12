using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text;

public partial class Report_UploadCandidateReport : BaseClass
{
    int UserId, URole;
    Search srch;
    static DataTable dt = new DataTable();
    DataView dv = new DataView();
    protected void Page_Load(object sender, EventArgs e)
    {
        UserId = Convert.ToInt32(Session["UserId"]);
        URole = Convert.ToInt32(Session["UserRole"]);
        if (!IsPostBack)
        {
            
            BindGrid();
        }
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        dt = SearchForDirector();
        gdvUpload.DataSource = dt;
        gdvUpload.DataBind();
    }


    protected void BindGrid()
    {
        dv.Table = SearchForDirector();
        if (ViewState["SortExpr"] != null)
            dv.Sort = (string)ViewState["SortExpr"] + " " + (string)ViewState["SortDir"];
        gdvUpload.DataSource = dv;
        gdvUpload.DataBind();

    }

    protected void gdvUpload_Sorting(object sender, GridViewSortEventArgs e)
    {
        ViewState["SortExpr"] = e.SortExpression;
        if (ViewState["SortDir"] != null)
            e.SortDirection = (string)ViewState["SortDir"] == "ASC" ? SortDirection.Descending : SortDirection.Ascending;
        ViewState["SortDir"] = e.SortDirection == SortDirection.Ascending ? "ASC" : "DESC";
         BindGrid();
    }

    public DataTable SearchForDirector()
    {
        srch = new Search();
        StringBuilder sb = new StringBuilder();
        sb.Append(" Select * from ( select * from (Select COUNT(distinct(rcr.RRCandidate_Id)) as total,Source,datename(MONTH,rcr.CreationDate) +'-'+");
        sb.Append(" datename(YEAR,rcr.CreationDate) as MonthYear,'Week1' as week from CandidateDetail as cd right join RRCandidateRelation as rcr on rcr.Candidate_Id=cd.Candidate_Id  where datename(day,rcr.CreationDate)>=1 and datename(day,rcr.CreationDate)<=7");
        sb.Append(" group by Source,datename(MONTH,rcr.CreationDate) +'-'+datename(YEAR,rcr.CreationDate) union all ");
        sb.Append(" Select COUNT(distinct(rcr.RRCandidate_Id)) as total,Source,datename(MONTH,rcr.CreationDate) +'-'+ datename(YEAR,rcr.CreationDate) as MonthYear,'Week2' as week");
        sb.Append(" from CandidateDetail as cd right join RRCandidateRelation as rcr on rcr.Candidate_Id=cd.Candidate_Id  where datename(day,rcr.CreationDate)>=8 and datename(day,rcr.CreationDate)<=14 ");
        sb.Append(" group by Source,datename(MONTH,rcr.CreationDate) +'-'+datename(YEAR,rcr.CreationDate) union all Select COUNT(distinct(rcr.RRCandidate_Id)) as total,Source,");
        sb.Append(" datename(MONTH,rcr.CreationDate) +'-'+ datename(YEAR,rcr.CreationDate) as MonthYear,'Week3' as week from CandidateDetail as cd right join RRCandidateRelation as rcr on rcr.Candidate_Id=cd.Candidate_Id ");
        sb.Append(" where datename(day,rcr.CreationDate)>=15 and datename(day,rcr.CreationDate)<=21 group by Source,datename(MONTH,rcr.CreationDate) +'-'+ datename(YEAR,rcr.CreationDate)");
        sb.Append(" union all Select COUNT(distinct(rcr.RRCandidate_Id)) as total,Source,datename(MONTH,rcr.CreationDate) +'-'+ datename(YEAR,rcr.CreationDate) as MonthYear,'Week4' as week");
        sb.Append(" from CandidateDetail as cd right join RRCandidateRelation as rcr on rcr.Candidate_Id=cd.Candidate_Id  where datename(day,rcr.CreationDate)>=22 and datename(day,rcr.CreationDate)<=28 group by Source,datename(MONTH,rcr.CreationDate) +'-'+ ");
        sb.Append(" datename(YEAR,rcr.CreationDate) union all Select COUNT(distinct(rcr.RRCandidate_Id)) as total,Source,datename(MONTH,rcr.CreationDate) +'-'+ datename(YEAR,rcr.CreationDate) as MonthYear,'Week5' as week");
        sb.Append(" from CandidateDetail as cd right join RRCandidateRelation as rcr on rcr.Candidate_Id=cd.Candidate_Id  where datename(day,rcr.CreationDate)>=29 and datename(day,rcr.CreationDate)<=31 group by Source,datename(MONTH,rcr.CreationDate) +'-'+");
        sb.Append(" datename(YEAR,rcr.CreationDate) ) as t  ");
        if (ddlSource.SelectedIndex > 0)
        {
            sb.Append(" where t.Source= '" + ddlSource.SelectedItem + "')");
            sb.Append(" as y pivot ( max (y.total) for y.week in ([Week1],[Week2],[Week3],[Week4],[Week5])) as Total");
        }
        else
        {
            sb.Append(" ) as y pivot ( max (y.total) for y.week in ([Week1],[Week2],[Week3],[Week4],[Week5])) as Total");
        }

        string query = sb.ToString();
        return srch.SearchRecord(query).Tables[0];
    }
}