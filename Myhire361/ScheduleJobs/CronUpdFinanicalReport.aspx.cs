using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Configuration;
public partial class ScheduleJobs_CronUpdFinanicalReport : System.Web.UI.Page
{
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
        dws = new DailyWorkSummaryBAL();
        dashbal = new DashboardBAL();
        try
        {


            int result = dashbal.fin();
            if (result == 1)
            {

                //lblmsg.Text = "Record Saved Successfully.";
                //lblmsg.ForeColor = System.Drawing.Color.Green;
            }

        }

        catch
        {
        }
    }
}