using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Net.Mail;
using System.Data;


public partial class ScheduleJobs_CronSendMailToJLLLast : System.Web.UI.Page
{
EmailforJLLBAL   jll;
   
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
             SendMailForRRRefferCandidates();
        }
    }
    private void SendMailForRRRefferCandidates()
    {
        jll = new EmailforJLLBAL();
      
        try
        {
            DataTable dt = new DataTable();
            dt = jll.JLLEmail4();
            if (dt.Rows.Count == 0)
            {
                Response.Write("no more candidate" + dt.Rows.Count);
            } 
            
           for (int i = 0; i < dt.Rows.Count; i++)
           {
                int Userid = Convert.ToInt32(dt.Rows[i]["sno"]);
         
                //string Email =  dt.Rows[i]["emailId"].ToString();//
           
                DataTable dts = new DataTable();


                jll.sno=Userid;

                jll.UpdateJLLEmailforDate4();           
                MailMessage msg = new MailMessage();
                SmtpClient smt = new SmtpClient();
                string MsgBody;

                msg.From = new MailAddress("noreply@indiahiring.net", "IndiaHiring");
                //msg.To.Add(Email);
               msg.To.Add("mayurionweb@gmail.com");
                msg.IsBodyHtml = true;

              //   msg.Bcc.Add("nisha.mann21@gmail.com");
                //msg.Bcc.Add("");
                 msg.Subject = "JLL Breaks into the Fortune 500";
                MsgBody = "";

                MsgBody = MsgBody + "    <table id ='tb' width='800' height='760' border='0' cellpadding='0' cellspacing='0' style='background-color: #FFFFFF'  >";
                  MsgBody = MsgBody + "       <tr>";
                MsgBody = MsgBody + "  <td width='76%' height='140px' align='Center' valign='Center' colspan='3'>";
                MsgBody = MsgBody + "      <a href='https://www.jllresidential.co.in/'>";
                MsgBody = MsgBody + "          <img src='http://myhire361.com/emailimages/JLL.jpg' width='800' height='378' border='0' alt=''></td>";
               MsgBody = MsgBody + "   </a>";
           MsgBody = MsgBody + "   </tr>";

           MsgBody = MsgBody + "   <tr>";
            MsgBody = MsgBody + "      <td colspan='2' align='Center' style='font-style: italic; color: #CC3300; font-size: xx-large;'>";

             MsgBody = MsgBody + "         <br />";

             MsgBody = MsgBody + "         JLL Breaks into the Fortune 500	";
     
                       
            MsgBody = MsgBody + "      </td>";
           MsgBody = MsgBody + "   </tr>";
           MsgBody = MsgBody + "   <tr>";
           MsgBody = MsgBody + "       <td colspan='2' align='Center' style='font-style: italic; color: #333333;'>Joins the prestigious annual ranking of the top global firms";
           MsgBody = MsgBody + "       <br /><br /> </td>";
           MsgBody = MsgBody + "   </tr>";
           MsgBody = MsgBody + "   <tr>";
           MsgBody = MsgBody + "       <td colspan='2'></td>";
           MsgBody = MsgBody + "   </tr>";
           MsgBody = MsgBody + "   <tr>";
           MsgBody = MsgBody + "       <td>We are extremely delighted to convey that on the back of our<br />";
           MsgBody = MsgBody + "           robust growth, JLL has joined the exclusive league of Fortune ";
       MsgBody = MsgBody + "   <br />";
           MsgBody = MsgBody + "           500 - the most prestigious annual list of top companies<br />";
            MsgBody = MsgBody + "          headquartered in America.<br />";
            MsgBody = MsgBody + "          <br />";
          MsgBody = MsgBody + "            In the face of our high standards and expectations from ";
      MsgBody = MsgBody + "    <br />";
         MsgBody = MsgBody + "             discerning clients such as yourself, this prestigious ranking is<br />";
         MsgBody = MsgBody + "             extremely gratifying and one more example of our recognition ";
       MsgBody = MsgBody + "   <br />";
        MsgBody = MsgBody + "              as best in our industry.<br />";
        MsgBody = MsgBody + "              <br />";
        MsgBody = MsgBody + "              As India's Largest & Leading Property Consulting Firm, this<br />";
        MsgBody = MsgBody + "              landmark also stands testimony to your trust and confidence in ";
       MsgBody = MsgBody + "   <br />";
              MsgBody = MsgBody + "        our services.";
       MsgBody = MsgBody + "   <br />";
       MsgBody = MsgBody + "       We are indeed grateful for your support, which has been instrumental <br/>in us achieving this accolade";
      
       MsgBody = MsgBody + "          and hope to continually offer you the<br/> best of top-line, award-winning real estate services.";
         MsgBody = MsgBody + "             <br />";
         MsgBody = MsgBody + "         </td>";
         MsgBody = MsgBody + "         <td>";
         MsgBody = MsgBody + "               <a href='https://www.jllresidential.co.in/'>";
         MsgBody = MsgBody + "                 <img src='http://myhire361.com/emailimages/Top500.jpg'  border='0' alt=''></td>";
                   
         MsgBody = MsgBody + "         </td>";
         MsgBody = MsgBody + "     </tr>";
        
           
        
           MsgBody = MsgBody + "   <tr>";
           MsgBody = MsgBody + "      <td valign='Left' colspan='2'>";
           MsgBody = MsgBody + "   <hr />";
               MsgBody = MsgBody + "  Warm Regards ";
            MsgBody = MsgBody + "     <br>";
            MsgBody = MsgBody + "          <br>";
            MsgBody = MsgBody + "          Monika Aggarwal<br>";
            MsgBody = MsgBody + "          Deputy Manager-Talent Acquisition<br>";
            MsgBody = MsgBody + "          9560596379/ <a href='monika.a@skopeconsultants.com'>monika.a@skopeconsultants.com</a><br>";
            MsgBody = MsgBody + "          <a href='www.skopeconsultants.com'>www.skopeconsultants.com</a><br>";
            MsgBody = MsgBody + "          SKOPE Business Ventures Pvt. Ltd.";
           MsgBody = MsgBody + "       </td>";

          MsgBody = MsgBody + "    </tr>";
             
                MsgBody = MsgBody + "</table>";

     
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
}

    

   

