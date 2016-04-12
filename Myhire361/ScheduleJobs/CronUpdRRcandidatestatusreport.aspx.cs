using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Configuration;
public partial class ScheduleJobs_CronUpdRRcandidatestatusreport : System.Web.UI.Page
{
    CronJobBAL cjob;
    DashboardBAL dashbal;
    DailyWorkSummaryBAL dws;
    int UserId, URole;
    int MyTimeSpan = 0;
    String Mdate;
    protected void Page_Load(object sender, EventArgs e)
    {
        Session["UserId"] = 16;
        UserId = Convert.ToInt32(Session["UserId"]);
        MyTimeSpan = Convert.ToInt32(ConfigurationManager.AppSettings["TimeSpan"]);

        if (!IsPostBack)
        {
            Mdate = DateTime.Now.AddMinutes(MyTimeSpan).ToString("MMM-yyyy");
             SaveSummary();

        }
    }

    protected void SaveSummary()
    {
        cjob = new CronJobBAL();
      
        try
        {


            int result = cjob.InsertRRCandidateStatusReport();
            if (result == 1)
            {

                lblmsg.Text = "Record Saved Successfully.";
                lblmsg.ForeColor = System.Drawing.Color.Green;
            }

        }

        catch(Exception ex)
        {
            lblmsg.Text = ex.ToString();
        }
    }
}