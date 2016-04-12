using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Configuration;

public partial class ScheduleJobs_CronUpdConstDailyStatus : System.Web.UI.Page
{
    DailyWorkSummaryBAL dws;
    int UserId, URole;
    int MyTimeSpan = 0;
    String Ddate;
    protected void Page_Load(object sender, EventArgs e)
    {
        Session["UserId"] = 16;
        UserId = Convert.ToInt32(Session["UserId"]);
        MyTimeSpan = Convert.ToInt32(ConfigurationManager.AppSettings["TimeSpan"]);
        if (!IsPostBack)
        {
            Ddate = DateTime.Now.AddMinutes(MyTimeSpan).ToString("dd-MMM-yyyy");
             SaveSummary();
        }
    }

    protected void SaveSummary()
    {
        dws = new DailyWorkSummaryBAL();

        try
        {
            dws.DDate = Ddate;
            dws.CreatedBy = UserId;
            int result = dws.IU_DailyWorkSummary();
            if (result == 1)
            {

               // Response.Write("Record Saved Successfully.");
            }

        }

        catch
        {
        }
    }
}