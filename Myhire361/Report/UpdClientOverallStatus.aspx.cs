using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Report_UpdClientOverallStatus : BaseClass
{
    DailyWorkSummaryBAL dws;
    int UserId, URole;
 
    protected void Page_Load(object sender, EventArgs e)
    {
        
        UserId = Convert.ToInt32(Session["UserId"]);
        URole = Convert.ToInt32(Session["UserRole"]);
       if (!IsPostBack)
        {
           

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

            dws.CreatedBy = UserId;
            int result = dws.IU_ClientOverallWorkSummary();
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
