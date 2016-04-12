using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Net.Mail;
using System.Data;


public partial class ScheduleJobs_CronSendMailToBrigade : System.Web.UI.Page
{
    RecruitmentBAL recbal;
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
        recbal = new RecruitmentBAL();
        try
        {
            DataTable dt = new DataTable();
            dt = recbal.TodayscandidateInserted();
            if (dt.Rows.Count == 0)
            {
                Response.Write("no more candidate" + dt.Rows.Count);
            } 
            
           for (int i = 0; i < dt.Rows.Count; i++)
           {
               // int Userid = Convert.ToInt32(dt.Rows[i]["sno"]);

               string Email = dt.Rows[i]["Email"].ToString();//
           
                DataTable dts = new DataTable();


               // jll.sno=Userid;

              //  jll.UpdateJLLEmailforDate4();           
                MailMessage msg = new MailMessage();
                SmtpClient smt = new SmtpClient();
                string MsgBody;

                msg.From = new MailAddress("noreply@indiahiring.net", "IndiaHiring");
               msg.To.Add(Email);
               // msg.To.Add("ISHAN3333@gmail.com");
                msg.IsBodyHtml = true;

              //  msg.Bcc.Add("nisha.mann21@gmail.com");
                //msg.Bcc.Add("");
                 msg.Subject = "Brigade Overview";
                MsgBody = "";

                MsgBody = MsgBody + "    <table id ='tb' width='700' height='760' border='0' cellpadding='0' cellspacing='0' style='background-color: #FFFFFF'  >";
                  MsgBody = MsgBody + "    <tr>";
                  MsgBody = MsgBody + "  <td align='Center' valign='Center' colspan='2' style='background-color: #0000FF; color: #FFFFFF;'>";
                  MsgBody = MsgBody + "    <h3 >  For a better quality of life, upgrade to Brigade</h3>";
               MsgBody = MsgBody + "       </td>";
               MsgBody = MsgBody + "   </a>";
           MsgBody = MsgBody + "   </tr>";
 MsgBody = MsgBody + " <tr>";
             MsgBody = MsgBody + "     <td width='20%'  align='left'>";
             MsgBody = MsgBody + "       <a href='http://www.brigadegroup.com/'>";
             MsgBody = MsgBody + "           <img src='http://myhire361.com/emailimages/6.png' width='362' height='261' border='0' alt=''></a>  &nbsp;&nbsp;&nbsp; &nbsp;";


             MsgBody = MsgBody + "  &nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp; &nbsp;     <a href='http://www.brigadegroup.com/'>";
 MsgBody = MsgBody + "         <img src='http://myhire361.com/emailimages/5.png' width='249' height='256' border='0' alt=''></a></td>";
           MsgBody = MsgBody + "       ";
         MsgBody = MsgBody + "     </tr>";

         MsgBody = MsgBody + "     <tr>";
         MsgBody = MsgBody + "       <td colspan='2' align='Center' style='color: #CC3300; font-size: large;'>";


         MsgBody = MsgBody + "                <hr /><br />";

             MsgBody = MsgBody + "      <h2> About Brigade</h2>";
     
                       
              MsgBody = MsgBody + "    </td>";
           MsgBody = MsgBody + "   </tr>";
           MsgBody = MsgBody + "   <tr>";
           MsgBody = MsgBody + "       <td colspan='2' align='Justify' > <p><font size='3.0'>Brigade Group was established in 1986, with property development as its main focus.<br />";
 MsgBody = MsgBody + " Today, Brigade Group is one of South India's leading property developers. We are headquartered in <br />";
 MsgBody = MsgBody + " Bangalore, with branch offices in several cities in South India, a representative office in Dubai and an <br />";
 MsgBody = MsgBody + " accredited agent in the USA. We have a uniquely diverse multi-domain portfolio that covers property <br />";
 MsgBody = MsgBody + " development, property management services, hospitality and education. Our projects extend across <br />";
 MsgBody = MsgBody + " several major cities in South India: Chennai, Chikmagalur, Hyderabad, Kochi, Mangalore and Mysore.     ";
         MsgBody = MsgBody + "             <br />";
         MsgBody = MsgBody + "             <br />    ";
         MsgBody = MsgBody + "      </font></p> ";

        MsgBody = MsgBody + "          </td>";
       MsgBody = MsgBody + "       </tr>";
          MsgBody = MsgBody + "    <tr>";
         MsgBody = MsgBody + "         <td  align='Center' valign='Center' colspan='2'>";
         MsgBody = MsgBody + "            <a href='http://www.brigadegroup.com/'>";
          MsgBody = MsgBody + "                <img src='http://myhire361.com/emailimages/4.png' width='800' height='300' border='0' alt=''></td>";
         MsgBody = MsgBody + "         </a>";
               
         MsgBody = MsgBody + "     </tr>";
        MsgBody = MsgBody + "      <tr>";
        MsgBody = MsgBody + "          <td colspan='2'>";
         MsgBody = MsgBody + "             <br />";
             MsgBody = MsgBody + "     <h2>    List of awards in 2014-15</h2>";

             MsgBody = MsgBody + "         <br/><p><font size='3.0'>";
             MsgBody = MsgBody + "         • Best Companies to Work For 2014";
             MsgBody = MsgBody + "         <br />";
             MsgBody = MsgBody + "         • Bangalore’s Hot 50 Brand’s";
                 MsgBody = MsgBody + "     <br />";
                MsgBody = MsgBody + "      • Ultra Luxury Apartment Project of the year ";
 MsgBody = MsgBody + " <br />";
               MsgBody = MsgBody + "       • Luxury Apartment Project Of The Year";
              MsgBody = MsgBody + "        <br />";
              MsgBody = MsgBody + "        •  Best Architectural Design – Commercial";
 MsgBody = MsgBody + " <br />";
              MsgBody = MsgBody + "        • Won 5 Awards at the 6th REALTY PLUS EXCELLENCE AWARDS 2014 for the following categories:";
              MsgBody = MsgBody + "        <br />";
              MsgBody = MsgBody + "        - World Trade Centre Bangalore @ Brigade Gateway ";
                 MsgBody = MsgBody + "     <br />";
                 MsgBody = MsgBody + "     – Commercial Property of the Year";
                 MsgBody = MsgBody + "     <br />";
 MsgBody = MsgBody + " - Brigade Group for Brigade Magnum-Developer of the Year – Commercial";
                MsgBody = MsgBody + "      <br />";
                MsgBody = MsgBody + "      - Brigade Lakefront for ‘WALK’–Innovative Marketing Concept of the Year";
                MsgBody = MsgBody + "      <br />";
               MsgBody = MsgBody + "       - Brigade Lakefront for’ WALK’–OOH Marketing campaign of the year ";
               MsgBody = MsgBody + "       <br />";
               MsgBody = MsgBody + "       - Brigade Lakefront for ‘WALK’–Print campaign of the year";
 MsgBody = MsgBody + "  <br /><hr /><br />";

      MsgBody = MsgBody + "      </font></p> ";
      MsgBody = MsgBody + "            </td>";
       MsgBody = MsgBody + "       </tr>";
       MsgBody = MsgBody + "       <tr>";
         MsgBody = MsgBody + "         <td align='center'><h2>A range of bench-mark setting commercial projects…</h2>";
       
         MsgBody = MsgBody + "         <img src='http://myhire361.com/emailimages/7.png'' width='603' height='562' border='0' alt=''> "; 
            
          MsgBody = MsgBody + "            <br /></td>";
      
 MsgBody = MsgBody + " &nbsp;</td>";
         MsgBody = MsgBody + "     </tr>";
         MsgBody = MsgBody + "     <tr>";
          MsgBody = MsgBody + "        <td valign='Left' colspan='2'> ";
        MsgBody = MsgBody + "         <br>";
          MsgBody = MsgBody + "            <br>";
           MsgBody = MsgBody + "           Monika Aggarwal<br>";
           MsgBody = MsgBody + "           Deputy Manager-Talent Acquisition<br>";
           MsgBody = MsgBody + "           9560596379/ <a href='monika.a@skopeconsultants.com'>monika.a@skopeconsultants.com</a><br>";
           MsgBody = MsgBody + "           <a href='www.skopeconsultants.com'>www.skopeconsultants.com</a><br>";
            MsgBody = MsgBody + "          SKOPE Business Ventures Pvt. Ltd.";
 MsgBody = MsgBody + " </td>";

         MsgBody = MsgBody + "     </tr>";

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

    

   

