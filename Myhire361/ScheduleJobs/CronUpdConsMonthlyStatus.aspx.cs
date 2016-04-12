using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Configuration;
public partial class ScheduleJobs_CronUpdConsMonthlyStatus : System.Web.UI.Page
{
    DailyWorkSummaryBAL dws;
    int UserId;
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

        try
        {

            dws.MonthYear = Mdate;
            dws.CreatedBy = UserId;
            int result = dws.IU_MonthlyWorkSummary();
            if (result == 1)
            {

               
            }

        }

        catch
        {
        }
    }
}