using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Net.Mail;
using System.Data;
using System.Text;
using System.IO;
using System.Configuration;

public partial class ScheduleJobs_CronSendMailToCandidates : System.Web.UI.Page
{
    RecruitmentBAL recbal;
EmailforJLLBAL   jll;
   
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
             
             BindRRNumber();
        }
    }

    protected void BindRRNumber()
    {
        recbal = new RecruitmentBAL();
        
        try
        {
            ListItem li = new ListItem("Select", "0");
            ddlFromRRNumber.Items.Clear();
            ddlFromRRNumber.Items.Add(li);
            ddlFromRRNumber.DataSource = recbal.getRRNumberforDDL();
            ddlFromRRNumber.DataTextField = "RRNumber";
            ddlFromRRNumber.DataValueField = "Request_Id";
            ddlFromRRNumber.DataBind();
        }
        finally
        {
            recbal = null;
        }
    }
    private void SendMailForRRRefferCandidates()
    {
        jll = new EmailforJLLBAL();
      
        try
        {
            DataTable dt = new DataTable();
            dt = SearchcandidateforRRNumber();
            if (dt.Rows.Count == 0)
            {
                Response.Write("no more candidate" + dt.Rows.Count);
            } 
            
           for (int i = 0; i < dt.Rows.Count; i++)
           {
               // int Userid = Convert.ToInt32(dt.Rows[i]["sno"]);

               string Email = dt.Rows[i]["Email"].ToString();//
           
                      
                MailMessage msg = new MailMessage();
                SmtpClient smt = new SmtpClient();
                string MsgBody;

                msg.From = new MailAddress("noreply@indiahiring.net", "IndiaHiring");
                msg.To.Add(Email);
                //msg.To.Add("ISHAN3333@gmail.com");
                //msg.To.Add("nisha.mann21@gmail.com");

                msg.IsBodyHtml = true;

              //   msg.Bcc.Add("nisha.mann21@gmail.com");
                //msg.Bcc.Add("");
                msg.Subject = txtSubject.Text;
                     //"JLL Breaks into the Fortune 500";
                MsgBody = txtText.Text;

      //          MsgBody = MsgBody + "    <table id ='tb' width='800' height='760' border='0' cellpadding='0' cellspacing='0' style='background-color: #FFFFFF'  >";
      //            MsgBody = MsgBody + "       <tr>";
      //          MsgBody = MsgBody + "  <td width='76%' height='140px' align='Center' valign='Center' colspan='3'>";
      //          MsgBody = MsgBody + "      <a href='https://www.jllresidential.co.in/'>";
      //          MsgBody = MsgBody + "          <img src='http://myhire361.com/emailimages/JLL.jpg' width='800' height='378' border='0' alt=''></td>";
      //         MsgBody = MsgBody + "   </a>";
      //     MsgBody = MsgBody + "   </tr>";

      //     MsgBody = MsgBody + "   <tr>";
      //      MsgBody = MsgBody + "      <td colspan='2' align='Center' style='font-style: italic; color: #CC3300; font-size: xx-large;'>";

      //       MsgBody = MsgBody + "         <br />";

      //       MsgBody = MsgBody + "         JLL Breaks into the Fortune 500	";
     
                       
      //      MsgBody = MsgBody + "      </td>";
      //     MsgBody = MsgBody + "   </tr>";
      //     MsgBody = MsgBody + "   <tr>";
      //     MsgBody = MsgBody + "       <td colspan='2' align='Center' style='font-style: italic; color: #333333;'>Joins the prestigious annual ranking of the top global firms";
      //     MsgBody = MsgBody + "       <br /><br /> </td>";
      //     MsgBody = MsgBody + "   </tr>";
      //     MsgBody = MsgBody + "   <tr>";
      //     MsgBody = MsgBody + "       <td colspan='2'></td>";
      //     MsgBody = MsgBody + "   </tr>";
      //     MsgBody = MsgBody + "   <tr>";
      //     MsgBody = MsgBody + "       <td>We are extremely delighted to convey that on the back of our<br />";
      //     MsgBody = MsgBody + "           robust growth, JLL has joined the exclusive league of Fortune ";
      // MsgBody = MsgBody + "   <br />";
      //     MsgBody = MsgBody + "           500 - the most prestigious annual list of top companies<br />";
      //      MsgBody = MsgBody + "          headquartered in America.<br />";
      //      MsgBody = MsgBody + "          <br />";
      //    MsgBody = MsgBody + "            In the face of our high standards and expectations from ";
      //MsgBody = MsgBody + "    <br />";
      //   MsgBody = MsgBody + "             discerning clients such as yourself, this prestigious ranking is<br />";
      //   MsgBody = MsgBody + "             extremely gratifying and one more example of our recognition ";
      // MsgBody = MsgBody + "   <br />";
      //  MsgBody = MsgBody + "              as best in our industry.<br />";
      //  MsgBody = MsgBody + "              <br />";
      //  MsgBody = MsgBody + "              As India's Largest & Leading Property Consulting Firm, this<br />";
      //  MsgBody = MsgBody + "              landmark also stands testimony to your trust and confidence in ";
      // MsgBody = MsgBody + "   <br />";
      //        MsgBody = MsgBody + "        our services.";
      // MsgBody = MsgBody + "   <br />";
      // MsgBody = MsgBody + "       We are indeed grateful for your support, which has been instrumental <br/>in us achieving this accolade";
      
      // MsgBody = MsgBody + "          and hope to continually offer you the<br/> best of top-line, award-winning real estate services.";
      //   MsgBody = MsgBody + "             <br />";
      //   MsgBody = MsgBody + "         </td>";
      //   MsgBody = MsgBody + "         <td>";
      //   MsgBody = MsgBody + "               <a href='https://www.jllresidential.co.in/'>";
      //   MsgBody = MsgBody + "                 <img src='http://myhire361.com/emailimages/Top500.jpg'  border='0' alt=''></td>";
                   
      //   MsgBody = MsgBody + "         </td>";
      //   MsgBody = MsgBody + "     </tr>";
        
           
        
      //     MsgBody = MsgBody + "   <tr>";
      //     MsgBody = MsgBody + "      <td valign='Left' colspan='2'>";
      //     MsgBody = MsgBody + "   <hr />";
      //         MsgBody = MsgBody + "  Warm Regards ";
      //      MsgBody = MsgBody + "     <br>";
      //      MsgBody = MsgBody + "          <br>";
      //      MsgBody = MsgBody + "          Monika Aggarwal<br>";
      //      MsgBody = MsgBody + "          Deputy Manager-Talent Acquisition<br>";
      //      MsgBody = MsgBody + "          9560596379/ <a href='monika.a@skopeconsultants.com'>monika.a@skopeconsultants.com</a><br>";
      //      MsgBody = MsgBody + "          <a href='www.skopeconsultants.com'>www.skopeconsultants.com</a><br>";
      //      MsgBody = MsgBody + "          SKOPE Business Ventures Pvt. Ltd.";
      //     MsgBody = MsgBody + "       </td>";

      //    MsgBody = MsgBody + "    </tr>";
             
      //          MsgBody = MsgBody + "</table>";

     
                msg.Body = MsgBody;
                msg.IsBodyHtml = true;
                smt.Host = "relay-hosting.secureserver.net";
                smt.Send(msg);

           }
        }
        catch(Exception ex)
        {

        }
        finally
        {
            jll = null;
           

        }
    }
    protected void ddlFromRRNumber_SelectedIndexChanged(object sender, EventArgs e)
    {
        txtSubject.Visible = true;
        txtText.Visible = true;
    }
    protected void btnsend_Click(object sender, EventArgs e)
    {
        SendMailForRRRefferCandidates();
    }

    protected DataTable SearchcandidateforRRNumber()
    {
        Search srch = new Search();
        string query = "", subquery = "";
        query = "   SELECT  top(1) Cr.RRCandidate_Id,Cd.Candidate_Name, Cd.Candidate_Id,Cd.Mobile_No , Cd.Email, " +
                "  Cr.Request_Id, Rr.ReferrerPts, " +
                "  cy.City_Name,Rr.PublishURL,Rr.Designation,Cr.ReferEmailSentdate,Cr.CreationDate " +
                " FROM CandidateDetail AS Cd INNER JOIN   " +
                "  RRCandidateRelation AS Cr ON Cd.Candidate_Id = Cr.Candidate_Id inner JOIN   " +
                "   RecruitmentRequest As Rr on Cr.Request_Id=Rr.Request_Id inner join  " +
                "   CityDetail AS cy ON Rr.Location_Id = cy.City_Id    ";
 
                     

        if (Convert.ToInt16(ddlFromRRNumber.SelectedValue) > 0)
        {
            subquery += "  Where     Cr.Request_Id= " + Convert.ToInt32(ddlFromRRNumber.SelectedValue);
        }

        //query = query + " and fw.Candidate_Status in ('Shortlisted','Offered','Offer Accepted','Joined','Selected not Joined') ";
        subquery = subquery + " Order by Cd.Candidate_Id  desc"; ;
        query = query + subquery;



        return srch.SearchRecord(query).Tables[0];
    }
    //#region Using VerifyRenderingInServerForm
    //protected void lbtnDownload_Click(object sender, EventArgs e)
    //{
    //    DataTable dt = new DataTable();
    //    try
    //    {
    //        string fileName = "CandidateListforEmail";
    //        dt = SearchcandidateforRRNumber();

    //        string attachment = "attachment; filename=" + fileName + ".xls";
    //        Response.ClearContent();
    //        Response.AddHeader("content-disposition", attachment);
    //        Response.ContentType = "application/vnd.xls"; // ms-excel
    //        DataGrid dg = new DataGrid();
    //        dg.DataSource = dt;
    //        dg.DataBind();
    //        StringWriter stw = new StringWriter();
    //        HtmlTextWriter htextw = new HtmlTextWriter(stw);
    //        dg.RenderControl(htextw);
    //        Response.Write(stw.ToString());
    //        Response.End();
    //    }
    //    catch (Exception ex)
    //    {
    //    }
    //    finally
    //    { }
    //}
    //public override void VerifyRenderingInServerForm(Control control)
    //{

    //}
    //#endregion
}

    

   

