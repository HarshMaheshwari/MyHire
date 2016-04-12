using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
public partial class CandidtateProfile : BaseClass
{
    
    HRegisterBAL HRegBal;
    protected void Page_Load(object sender, EventArgs e)
    {
       
    }

    protected void Submit(object sender, EventArgs e)
    {
        /*
         HRegBal = new HRegisterBAL();
      
        try

        {
            HRegBal.F_Name = txtFName.Text;
            HRegBal.L_Name = txtLName.Text;
            HRegBal.MobileNo = txtMobile.Text;
            HRegBal.Current_Industry = ddlCindustry.SelectedValue;
            HRegBal.Current_Company = ddlCcompany.SelectedValue;
            HRegBal.Previ_Company = ddlPCompany.SelectedValue;
            HRegBal.Current_Designation =txtCrntDegnition.Text;
            HRegBal.Functional_Area = ddlFarea.SelectedValue;
         //   HRegBal.Key_Skills =Convert.ToString(SelectedItem);
            HRegBal.Total_WorkExp = ddlTWrkExper.SelectedValue;
            HRegBal.Annual_Salaray = "";
            HRegBal.Current_Location = "";
            HRegBal.Preferred_Location = "";
            HRegBal.NoticePeriod = "";
            HRegBal.Bachloar_Degree = "";
            HRegBal.Bachloar_instuite = "";

            HRegBal.YearOf_BPassing = "";
            HRegBal.PostGrad_institute = "";
            HRegBal.YearOf_PgPassing = "";
            HRegBal.Doctoral_institute = "";
            HRegBal.YearOf_DPassing = "";
           // HRegBal.Ressume_Path = txtPassword.Text;
            HRegBal.Key_Skills = "";

          //  HRegBal.CandidateId = CandidateId;
            int result = HRegBal.InsertCandidate();
            if (result > 0)
            {
               
                Response.Redirect("Dashboard.aspx");
            }
            else
            {
                lblmsg.Text = "Already registered.please login..!";
                lblmsg.ForeColor = System.Drawing.Color.Red;
            }
        }
        catch (Exception ex)
        {
        }
        finally
        {
            HRegBal = null;
        }*/

    }
        //string message = "";
        //foreach (ListItem item in lstFruits.Items)
        //{
        //    if (item.Selected)
        //    {
        //        message += item.Text + " " + item.Value + "\\n";
        //    }
        //}
        //ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "alert('" + message + "');", true);
   // }
  // }



    //protected void imgbtnAdpCompny_Click(object sender, ImageClickEventArgs e)
    //{
    //    txtAddPcompany.Visible = true;
    
    //}
       
}