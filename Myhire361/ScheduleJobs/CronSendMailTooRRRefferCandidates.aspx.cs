using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Net.Mail;

public partial class ScheduleJobs_CronSendMailTooRRRefferCandidates : System.Web.UI.Page
{
    RecruitmentBAL recbal;
    LoginBAL userbal;
    FollowUpBAL followup;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
             SendMailForRRRefferCandidates();
        }
    }
    private void SendMailForRRRefferCandidates()
    {
        recbal = new RecruitmentBAL();
        followup = new FollowUpBAL();
      //  userbal = new LoginBAL();
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
                int Userid = Convert.ToInt32(dt.Rows[i]["RRCandidate_Id"]);
            string name =  dt.Rows[i]["Candidate_Name"].ToString();
            string Email = dt.Rows[i]["Email"].ToString();// "nisha.mann21@gmail.com";//
            String Job_Profile = dt.Rows[i]["Designation"].ToString();
            String Location =  dt.Rows[i]["City_Name"].ToString();
            string Rewardpoints = dt.Rows[i]["ReferrerPts"].ToString();
            string publishlink =  dt.Rows[i]["PublishURL"].ToString();
            DataTable dts = new DataTable();




            followup.RRCandidateId = Userid;
            followup.UpdateRRReferEmailSentdate();
            MailMessage msg = new MailMessage();
            SmtpClient smt = new SmtpClient();
            string MsgBody;

            msg.From = new MailAddress("noreply@indiahiring.net", "IndiaHiring");
        msg.To.Add(Email);
        //   msg.To.Add("ISHAN3333@gmail.com ");
            msg.IsBodyHtml = true;

            //msg.Bcc.Add("manish.g@skopeconsultants.com");
          
            msg.Subject = "Refer your friends and get rewarded";
            MsgBody = "";

            MsgBody = MsgBody + "    <table id ='tb' width='793' height='760' border='0' cellpadding='0' cellspacing='0' style='background-color: #F6F6F6'  >";
            MsgBody = MsgBody + "  <tr>";
            MsgBody = MsgBody + "   <td width='12%'></td><td width='76%' height='140px' align='Center' valign='Center' >";
     
            MsgBody = MsgBody + "	<a href='http://www.indiahiring.org' >";
            MsgBody = MsgBody + "	<img src='http://myhire361.com/emailimages/IndiaHiring.gif' width='300' height='91'  border='0' alt=''></a></td>";
            MsgBody = MsgBody + "   <td width='12%'></td>";
            MsgBody = MsgBody + "      </tr>";
            MsgBody = MsgBody + "  <tr>";
            MsgBody = MsgBody + "   <td width='12%'></td><td width='76%' >";
            MsgBody = MsgBody + "  <table id='Table_01'   border='0' cellpadding='4' cellspacing='5'  bgcolor='#FFFFFF'>";

            MsgBody = MsgBody + "      <tr>";

            MsgBody = MsgBody + "    <td colspan='11' align='Center'>";
            MsgBody = MsgBody + "   <h1>Welcome to IndiaHiring </h1><BR>";
               
            MsgBody = MsgBody + "   </td>";
            MsgBody = MsgBody + "  </tr>";



            MsgBody = MsgBody + "   <tr>";
            MsgBody = MsgBody + " <td colspan='11' font size='3'>";
            MsgBody = MsgBody + " Dear " + name + ", <BR>";
            MsgBody = MsgBody + "  SKOPE Business Ventures brings to you IndiaHiring. It is an online  platform that allows you to refer jobs to your friends, colleagues &  peers through wide range of jobs pan-India. In case your referred  candidate is selected by the employer you will earn reward points.<BR><BR>";
            MsgBody = MsgBody + "     </td>";
            MsgBody = MsgBody + "     </tr>";
            MsgBody = MsgBody + "     <tr>";
            MsgBody = MsgBody + "     <td colspan='11' font size='3'>";
            MsgBody = MsgBody + "      <h2>Jobs you can refer for:</h2><BR>";
            MsgBody = MsgBody + "   <a href=" + publishlink + " > " + Job_Profile + "<BR></a>";
            MsgBody = MsgBody + "      " + Location + "<BR>";
            MsgBody = MsgBody + "     Reward Points " + Rewardpoints + "<BR>";
            MsgBody = MsgBody + "     </td>";
            MsgBody = MsgBody + "     </tr>";
            MsgBody = MsgBody + "      <tr>";
            MsgBody = MsgBody + "    <td colspan:7 width='417'  colspan='6' font size='3'>";

            MsgBody = MsgBody + " <h2>More than 250 Jobs worth Referral Value of <br>";
            MsgBody = MsgBody + "  Rs.17 Lacs on India Hiring! Refer Now! </h2><br>";

            MsgBody = MsgBody + "    </td>";
            MsgBody = MsgBody + "    </tr>";
            MsgBody = MsgBody + "      <tr>";
            MsgBody = MsgBody + "    <td colspan:7 width='417'  colspan='6' align ='center' font size='3'>";
            MsgBody = MsgBody + "    We have some enticing jobs opportunities for you to apply or  refer your friends! Just visit IndiaHiring, apply yourself or fill  the reference details. And you can earn huge reward points for  each job referred!<BR><BR>";
            MsgBody = MsgBody + " <br><h2>1 Lac Reward points have been claimed in last 1 week .<br> Have you claimed yours yet? <br>";
            MsgBody = MsgBody + "    </td>";
            MsgBody = MsgBody + "    </tr>";
            MsgBody = MsgBody + "     </table>";
            MsgBody = MsgBody + "   </td><td width='12%'></td></tr>";
            MsgBody = MsgBody + "     <tr>";
            MsgBody = MsgBody + " <td width='12%'></td>";
            MsgBody = MsgBody + "    <td width='76%' align='Center' CELLSPACING='2'>";
            MsgBody = MsgBody + " 	<a href='https://plus.google.com/+IndiahiringOrg_Discover/posts'>";
            MsgBody = MsgBody + " 	<img src='http://myhire361.com/emailimages/gp.png' width='30' height='30' border='0' alt=''></a> 		";

            MsgBody = MsgBody + " 		<a href='http://www.facebook.com/indiahiring'>";
            MsgBody = MsgBody + " 		<img src='http://myhire361.com/emailimages/fb.png' width='30' height='30' border='0' alt=''></a> 	  ";

           
            MsgBody = MsgBody + " 		<a href='https://twitter.com/IndiaHiring'>";
            MsgBody = MsgBody + "		<img src='http://myhire361.com/emailimages/twitter.png' width='30' height='30' border='0' alt=''></a> 		";

          
            MsgBody = MsgBody + "     		<a href='https://www.linkedin.com/company/india-hiring'>";
            MsgBody = MsgBody + "     			<img src='http://myhire361.com/emailimages/in.png' width='30' height='30' border='0' alt=''></a> 		";

       
            MsgBody = MsgBody + "   	<a href='https://www.youtube.com/channel/UCoeuTfdnWiZe4p72xwX2H-A'>";
            MsgBody = MsgBody + "		<img src='http://myhire361.com/emailimages/ytube.png' width='30' height='30' border='0' alt=''></a> 	";

            MsgBody = MsgBody + "     <td width='12%'>                	&nbsp;</td>";

            MsgBody = MsgBody + "     </tr>";
            MsgBody = MsgBody + "  	<tr>";
            MsgBody = MsgBody + "     <td width='12%'>                	&nbsp;</td>";
            MsgBody = MsgBody + "	<td CELLSPACING=2>";
            MsgBody = MsgBody + "			IndiaHiring.org Powered By<br>Skope Business Ventures Pvt Ltd";
               // <br>Plot 225, Udyog Vihar - 4,Gurgaon</td>";
            MsgBody = MsgBody + "     <td width='12%'>                	&nbsp;</td>";
            MsgBody = MsgBody + "	</tr>";
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
            recbal = null;
            //userbal = null;
            //followup = null;
        }
    }



}
    

   

