using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Configuration;

public partial class Report_UpdConsMonthlyStatus: BaseClass
{
    DailyWorkSummaryBAL dws;
    int UserId, URole;
    int MyTimeSpan = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
       
        UserId = Convert.ToInt32(Session["UserId"]);
        URole = Convert.ToInt32(Session["UserRole"]);
        MyTimeSpan = Convert.ToInt32(ConfigurationManager.AppSettings["TimeSpan"]);
       
        if (!IsPostBack)
        {
            txtMonth.Text = DateTime.Now.AddMinutes(MyTimeSpan).ToString("MMM-yyyy");
          
         
        }
    }


    protected void btnSave_OnClick(object sender, EventArgs e)
    {
        SaveSummary();
    }

    protected void SaveSummary()
    {
        dws = new DailyWorkSummaryBAL();

        try
        {

            dws.MonthYear = txtMonth.Text;
            dws.CreatedBy = UserId;
            int result = dws.IU_MonthlyWorkSummary();
            if (result == 1)
            {

                lblmsg.Text = "Record Saved Successfully.";
                lblmsg.ForeColor = System.Drawing.Color.Green;
            }

        }

        catch
        {
        }
    }

}
