using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Net.Mail;
using System.Data;

public partial class ScheduleJobs_CronSendMailToMicrosoft : System.Web.UI.Page
{
    EmailforJLLBAL jll;
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

                string Email = dt.Rows[i]["emailId"].ToString();//

                DataTable dts = new DataTable();


                jll.sno = Userid;

                jll.UpdateJLLEmailforDate4();
                MailMessage msg = new MailMessage();
                SmtpClient smt = new SmtpClient();
                string MsgBody;

                msg.From = new MailAddress("noreply@indiahiring.net", "IndiaHiring");
                msg.To.Add(Email);
                //msg.To.Add("ISHAN3333@gmail.com");
                msg.IsBodyHtml = true;

                   //msg.Bcc.Add("mayurionweb@gmail.com");
                   //msg.Bcc.Add("");
                   msg.Subject = "This may be the most important mail you will read this month!";
                MsgBody = "";

                 MsgBody = MsgBody + "  <div style='background-color:#f2f2f2; padding:19px 48px; width:87%';>";
    
          MsgBody = MsgBody + "  <table  width='40%' style='background-color:white; '>";
             MsgBody = MsgBody + "   <tr>";
                 MsgBody = MsgBody + "   <td colspan='2' align='center'>";
                 MsgBody = MsgBody + " <a target='_blank' href='http://www.getaheadfast.com/ref/skope/'/>";
                 MsgBody = MsgBody + "       <img alt='' style='text-align:center; ' src='http://myhire361.com/emailimages/1.4.png' />";
               
                 MsgBody = MsgBody + "   </td>";
              MsgBody = MsgBody + "  </tr>";
              MsgBody = MsgBody + "  <tr>";
                MsgBody = MsgBody + "    <td colspan='2' align='center' style='padding: 9px 18px;'>";
                MsgBody = MsgBody + "      <h3 style='text-align:center;display:block;margin:0;padding:0;font-family:Helvetica;font-size:18px;font-style:normal;font-weight:bold;line-height:125%;letter-spacing:-.5px;color:#606060!important;'><span style='font-size:18px;'> ARE YOU AN AMBITIOUS YOUNG PROFESSIONAL?";
                    MsgBody = MsgBody + "        DO YOU WANT A BETTER JOB FASTER?</span></h3>";
                MsgBody = MsgBody + "    </td>";
             MsgBody = MsgBody + "   </tr>";
              MsgBody = MsgBody + "  <tr>";
               MsgBody = MsgBody + "     <td>&nbsp;</td>";
                MsgBody = MsgBody + "    <td class='auto-style1'>&nbsp;</td>";
             MsgBody = MsgBody + "   </tr>";
            MsgBody = MsgBody + "    <tr>";
              MsgBody = MsgBody + "      <td colspan='2' style='text-align: justify;padding: 9px 18px;margin: 1em 0px;color: #606060;font-family: Helvetica;font-size: 15px;line-height: 150%;'>";
                  MsgBody = MsgBody + "  Competition for good jobs is very stiff and candidates are trying to be as prepared as ";
                 MsgBody = MsgBody + "       possible. Unfortunately that &#39;preparation&#39; normally means talking to some seniors, or ";
                  MsgBody = MsgBody + "      colleagues at work or maybe watching some random YouTube videos on the subject of ";
                   MsgBody = MsgBody + "     interviewing. None of which works very well. You end up with poor information, &nbsp;or ";
                   MsgBody = MsgBody + "     worse wrong information that sabotages your efforts. You apply blindly to all job ";
                    MsgBody = MsgBody + "    boards for all kinds of jobs and send out 100s of resumes, and then wait for your ";
                    MsgBody = MsgBody + "    phone to ring from a recruiter or a company - which almost never happens. Why?</td>";
             MsgBody = MsgBody + "   </tr>";
             MsgBody = MsgBody + "   <tr>";
                MsgBody = MsgBody + "    <td>&nbsp;</td>";
                MsgBody = MsgBody + "    <td class='auto-style1'>&nbsp;</td>";
              MsgBody = MsgBody + "  </tr>";
             MsgBody = MsgBody + "   <tr>";
                MsgBody = MsgBody + "    <td colspan='2' align='center'>";
                MsgBody = MsgBody + "        <a target='_blank' href='http://www.getaheadfast.com/ref/skope/'/> <img alt='' src='http://myhire361.com/emailimages/Untitled-3.jpg' width='564px' /></td>";
             MsgBody = MsgBody + "   </tr>";
            MsgBody = MsgBody + "    <tr>";
             MsgBody = MsgBody + "       <td>&nbsp;</td>";
               MsgBody = MsgBody + "     <td class='auto-style1'>&nbsp;</td>";
             MsgBody = MsgBody + "   </tr>";
            MsgBody = MsgBody + "    <tr>";
            MsgBody = MsgBody + "        <td style='padding: 9px 18px;' width='262px'>";
            MsgBody = MsgBody + "         <a target='_blank' href='http://www.getaheadfast.com/ref/skope/'/> <img alt='' src='http://myhire361.com/emailimages/2.1.jpg' width='262px' /></td>";
               MsgBody = MsgBody + "     <td style='padding: 9px 18px;' width='262px'>";
               MsgBody = MsgBody + "      <a target='_blank' href='http://www.getaheadfast.com/ref/skope/'/><img alt='' src='http://myhire361.com/emailimages/Microsoft11.jpg' width='262px' /></td>";
            MsgBody = MsgBody + "    </tr>";
            MsgBody = MsgBody + "    <tr style='padding: 0px 9px;color: #606060;font-family: Helvetica;font-size: 15px;line-height: 150%;text-align: left;'>";
              MsgBody = MsgBody + "   <td style='padding: 9px 18px;'>What if you are not from an IIT or an IIM?</td>";
             MsgBody = MsgBody + "    <td style='padding: 9px 18px;padding: 9px 18px;' class='auto-style1'>How long should your resume be?</td>";
           MsgBody = MsgBody + "  </tr>";
          MsgBody = MsgBody + "   <tr style='padding: 0px 9px;color: #606060;font-family: Helvetica;font-size: 15px;line-height: 150%;text-align: left;'>";
            MsgBody = MsgBody + "     <td style='font-size: 14px; padding: 9px 18px;'>Raj Raghavan - Amazon India, Director &<br />";
 MsgBody = MsgBody + "Country HR Leader</td>";
        MsgBody = MsgBody + "         <td style='font-size: 14px; padding: 9px 18px;' class='auto-style1'>Rohit Thakur - Microsoft India, Head of ";
            MsgBody = MsgBody + "         <br />";
                MsgBody = MsgBody + "     HR</td>";
          MsgBody = MsgBody + "   </tr>";
          MsgBody = MsgBody + "   <tr>";
            MsgBody = MsgBody + "     <td>&nbsp;</td>";
             MsgBody = MsgBody + "    <td class='auto-style1'>&nbsp;</td>";
           MsgBody = MsgBody + "  </tr>";
           MsgBody = MsgBody + "  <tr>";
             MsgBody = MsgBody + "    <td colspan='2' style='padding: 9px 18px;'>";
             MsgBody = MsgBody + "       <a target='_blank' href='http://www.getaheadfast.com/ref/skope/'/><img alt='' width='564px' src='http://myhire361.com/emailimages/s3.jpg' /></td>";
            MsgBody = MsgBody + " </tr>";
           MsgBody = MsgBody + "  <tr>";
             MsgBody = MsgBody + "    <td>&nbsp;</td>";
             MsgBody = MsgBody + "    <td class='auto-style1'>&nbsp;</td>";
            MsgBody = MsgBody + " </tr>";
           MsgBody = MsgBody + "  <tr>";
              MsgBody = MsgBody + "   <td colspan='2' align='center' class='auto-style1'><span style='color:#ffa500'><span style='font-size:18px'><strong>SAVE HOURS OF TIME BY GETTING THE RIGHT ADVICE FROM";
                MsgBody = MsgBody + "     <br />";
                MsgBody = MsgBody + "     THE VERY BEGINNING.</strong></span></span></td>";
            MsgBody = MsgBody + " </tr>";
            MsgBody = MsgBody + " <tr>";
            MsgBody = MsgBody + "     <td>&nbsp;</td>";
            MsgBody = MsgBody + "     <td class='auto-style1'>&nbsp;</td>";
           MsgBody = MsgBody + "  </tr>";
           MsgBody = MsgBody + "  <tr >";
            MsgBody = MsgBody + "     <td colspan='2' style='padding: 9px 18px;text-align: justify;margin: 1em 0px;color: #606060;font-family: Helvetica;font-size: 15px;line-height: 150%;'>";
           MsgBody = MsgBody + "      Take any hundred people at the start of their working careers and follow them for";
            MsgBody = MsgBody + "         forty years until they reach retirement age, and here’s what you’ll find, according to";
                    MsgBody = MsgBody + "     the Social Security Administration of the United States: only 1 will be wealthy; 4 will";
                  MsgBody = MsgBody + "       be financially secure; 5 will continue working, not because they want to but because";
                  MsgBody = MsgBody + "       they have to; 36 will be dead; and 54 will be dead broke — dependent on their";
                  MsgBody = MsgBody + "       meager pension checks, relatives, friends, even charity for a minimum standard of living.";
          MsgBody = MsgBody + "       </tr>";
             MsgBody = MsgBody + "    <tr>";
               MsgBody = MsgBody + "      <td>&nbsp;</td>";
                MsgBody = MsgBody + "     <td class='auto-style1'>&nbsp;</td>";
            MsgBody = MsgBody + "     </tr>";
            MsgBody = MsgBody + "     <tr>";
                MsgBody = MsgBody + "     <td colspan='2' style='padding: 9px 18px;text-align: justify;margin: 1em 0px;color: #606060;font-family: Helvetica;font-size: 15px;line-height: 150%;'>";
               MsgBody = MsgBody + "      That’s 5 percent successful, 95 percent unsuccessful. Where do you want to be?</td>";
            MsgBody = MsgBody + "     </tr>";
             MsgBody = MsgBody + " <tr>";
           MsgBody = MsgBody + "       <td>&nbsp;</td>";
            MsgBody = MsgBody + "      <td class='auto-style1'>&nbsp;</td>";
           MsgBody = MsgBody + "   </tr>";
           MsgBody = MsgBody + "   <tr>";
              MsgBody = MsgBody + "    <td colspan='2' align='center'><span style='font-size:15px;text-align: center;margin: 1em 0px;color: #606060;font-family: Helvetica;font-size: 15px;line-height: 150%;'>";
    MsgBody = MsgBody + "  <em>PS: Want better jobs faster? Find out what HR Directors of Unilever, Pepsi,<br />";
            MsgBody = MsgBody + "          Microsoft, American Express, Amazon and GE look for when they hire candidates.</em></span></td>";
          MsgBody = MsgBody + "    </tr>";
         MsgBody = MsgBody + "     <tr>";
            MsgBody = MsgBody + "      <td colspan='2' align='center' ></td>";
           MsgBody = MsgBody + "   </tr>";
           MsgBody = MsgBody + "   <tr>";
             MsgBody = MsgBody + "     <td colspan='2' align='center'>";

             MsgBody = MsgBody + "   <a target='_blank' href='http://www.getaheadfast.com/ref/skope/'/><input id='Button1' style='background-color:#FFA200;font-family: Arial;font-size: 16px;padding: 16px; border-radius:5px; border:1px solid #ffa200; color:white;' type='button' value='Click Here To Join Now' /> ";
                        MsgBody = MsgBody + "      </td>";
                     MsgBody = MsgBody + "   </tr>";
          MsgBody = MsgBody + "    <tr>";
           MsgBody = MsgBody + "       <td colspan='2' align='center'>&nbsp;</td>";
           MsgBody = MsgBody + "   </tr>";
           MsgBody = MsgBody + "   <tr>";
              MsgBody = MsgBody + "    <td colspan='2' align='center' style='padding: 9px 18px;color: #606060;font-family: Helvetica;font-size: 11px;line-height: 125%;text-align: center;'>";
    MsgBody = MsgBody + "  <em>Copyright © 2015, SKOPE Business Ventures Pvt. Ltd, All rights reserved.</em></td>";
       MsgBody = MsgBody + "       </tr>";
           
       MsgBody = MsgBody + "   </table>";
    
    MsgBody = MsgBody + "  </div>";

                msg.Body = MsgBody;
                msg.IsBodyHtml = true;
                smt.Host = "relay-hosting.secureserver.net";
                smt.Send(msg);

            }
        }
        catch (Exception ex)
        {

        }
        finally
        {
            jll = null;


        }
    }
}