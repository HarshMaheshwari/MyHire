using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Configuration;
public partial class Report_UpdConstDailyStatus : BaseClass
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
            txtDDate.Text = DateTime.Now.AddMinutes(MyTimeSpan).ToString("dd-MMM-yyyy");
          
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
            dws.DDate = txtDDate.Text;
            dws.CreatedBy = UserId;
            int result = dws.IU_DailyWorkSummary();
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
