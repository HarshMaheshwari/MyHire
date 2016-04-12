using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Net.Mail;
using System.Data;

public partial class ScheduleJobs_Crondefault : System.Web.UI.Page
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
                ////msg.To.Add("ISHAN3333@gmail.com");
                msg.IsBodyHtml = true;

                //msg.Bcc.Add("mayurionweb@gmail.com");
                ////msg.Bcc.Add("");
                msg.Subject = "MaxLife";
                MsgBody = "";

                MsgBody = MsgBody + "    <table  width='40%' style='background-color:white; '>";
                   
                MsgBody = MsgBody + "  <tr>";
                
                MsgBody = MsgBody + " <td colspan='2' align='left'>";
                    
                MsgBody = MsgBody + " <a target='_blank' href='http://www.maxlifeinsurance.com/'/><img alt='' style='text-align:center; height: 40px;' src='http://myhire361.com/emailimages/maxlife.png' />";
                  
                
                MsgBody = MsgBody + " </td>";
            
                MsgBody = MsgBody + " </tr>";
            MsgBody = MsgBody + "<tr>";
                MsgBody = MsgBody + "<td colspan='2' align='center'>";
                    MsgBody = MsgBody + "<a target='_blank' href='http://www.maxlifeinsurance.com/'/><img alt='' src='http://myhire361.com/emailimages/maxbanner.png' width='564px' /></td>";
            MsgBody = MsgBody + "</tr>";
             MsgBody = MsgBody + " <tr>";
                MsgBody = MsgBody + "<td colspan='2' align='left'>";

                    MsgBody = MsgBody + "</td>";

                   MsgBody = MsgBody + "</tr>";
            MsgBody = MsgBody + "<tr>";
                MsgBody = MsgBody + "<td align='center' style='color:black; font-family:Calibri;:bold; font-size:25px;' colspan='2'> About Us</td>";
            MsgBody = MsgBody + "</tr>";
            MsgBody = MsgBody + "<tr>";
                MsgBody = MsgBody + "<td colspan='2' style='text-align: justify;padding: 9px 18px;margin: 1em 0px;color: #606060;font-family: Helvetica;font-size: 15px;line-height: 150%;'><b style='color:rgb(37,37,37);font-family:sans-serif;font-size:14px;line-height:22.4px'>Max Life Insurance</b><span style='color:rgb(37,37,37);font-family:sans-serif;font-size:14px;line-height:22.4px'>, one of the life insurers, is a joint venture between&nbsp;</span><a href='https://en.wikipedia.org/w/index.php?title=Max_India&amp;action=edit&amp;redlink=1' style='text-decoration: none; color: rgb(165,88,88); font-family: sans-serif; font-size: 14px; line-height: 22.4px; background-image: none; background-repeat: initial' target='_blank' title='Max India (page does not exist)'>Max India</a>";
                    MsgBody = MsgBody + "<span style='color:rgb(37,37,37);font-family:sans-serif;font-size:14px;line-height:22.4px'>&nbsp;Ltd. and&nbsp;</span>";
                MsgBody = MsgBody + "<span style='text-decoration: none; color: rgb(11,0,128); font-family: sans-serif; font-size: 14px; line-height: 22.4px; background-image: none; background-repeat: initial' target='_blank' title='Mitsui Sumitomo Insurance'>Mitsui Sumitomo</span>";
                   MsgBody = MsgBody + " Insurance</a><span style='color:rgb(37,37,37);font-family:sans-serif;font-size:14px;line-height:22.4px'>&nbsp;Co. Ltd. Max India is an Indian multi-business corporate, while Mitsui Sumitomo Insurance is a member of MS&amp;AD Insurance Group, a general insurer. Max Life Insurance offers comprehensive life insurance and retirement&nbsp;</span><a href='https://en.wikipedia.org/wiki/Solution' style='text-decoration: none; color: rgb(11,0,128); font-family: sans-serif; font-size: 14px; line-height: 22.4px; background-image: none; background-repeat: initial' target='_blank' title='Solution'>solutions</a><span style='color:rgb(37,37,37);font-family:sans-serif;font-size:14px;line-height:22.4px'>&nbsp;for long-term savings and protection to thirty lakh customers. It has a country-wide diversified distribution model including the country&#39;s leading agent advisors, exclusive arrangement with Axis Bank and several other partners</span></td>";
            MsgBody = MsgBody + "</tr>";
            MsgBody = MsgBody + "<tr>";
                MsgBody = MsgBody + "<td>&nbsp;</td>";
                MsgBody = MsgBody + "<td class='auto-style1'>&nbsp;</td>";
           MsgBody = MsgBody + " </tr>";
            MsgBody = MsgBody + "<tr>";
               MsgBody = MsgBody + " <td colspan='2'style='color:black; font-family:Calibri;:bold; font-size:25px;' colspan='2' align='center'>";
                MsgBody = MsgBody + "    Awards";
                  MsgBody = MsgBody + "  </td>";
            MsgBody = MsgBody + "</tr>";
            MsgBody = MsgBody + "<tr>";
              MsgBody = MsgBody + "  <td colspan='2'style='text-align: justify;padding: 9px 18px;margin: 1em 0px;color: #606060;font-family: Helvetica;font-size: 15px;line-height: 150%;' align='left'>";
                   MsgBody = MsgBody + " 1. Won the <strong style='margin:0px;padding:0px'>Global Finance Best Life Insurance Company 2014</strong>, India.<br/>";
                   MsgBody = MsgBody + " 2. Won the trophy for <strong style='margin:0px;padding:0px'>Best Underwriting Initiative of the year</strong>&nbsp;in the&nbsp;<strong style='margin:0px;padding:0px'>Asia Banking, Financial Services &amp; Insurance Excellence Awards</strong><br/>";
                   MsgBody = MsgBody + " 3. <strong style='margin:0px;padding:0px'>Max Life i-genius</strong> won Silver  and Bronze '<strong style='margin:0px;padding:0px'>Abby</strong>&#39; award at <strong style='margin:0px;padding:0px'>Goafest 2014</strong><br/>";
                   MsgBody = MsgBody + " 4. <strong style='margin:0px;padding:0px'>Max Life Retirement PR campaign</strong> won '<strong style='margin:0px;padding:0px'>Excellence</strong>&#39; award at <strong style='margin:0px;padding:0px'>Sabre Asia</strong><br/>";
                   MsgBody = MsgBody + " 5. Recognised amongst <strong style='margin:0px;padding:0px'>India&#39;s Best Companies to Work For 2014</strong>...Ranked 58th from 82nd last year by GPTW<br/>";
                   MsgBody = MsgBody + " 6. Project CARS won <strong style='margin:0px;padding:0px'>QCI - D.L.Shah Commendation Award 2014</strong><br />";
                   MsgBody = MsgBody + " 7. Project Proactive Retention won&nbsp;<strong style='margin:0px;padding:0px'>Bronze Award</strong>&nbsp;at World Conference for Quality &amp; Improvement 2014 (WCQI) in Dallas, USA.<br />";
                  MsgBody = MsgBody + "  8. Recognized amongst the top 100 companies&nbsp;<strong style='margin:0px;padding:0px'>&#39;India&#39;s Best Companies to Work for 2013&#39;</strong>&nbsp;a survey by Great Place To Work<sup style='margin:0px;padding:0px'>®</sup>&nbsp;Institute.<br />";
                    MsgBody = MsgBody + "9. Selected as&nbsp;<strong style='margin:0px;padding:0px'>Superbrand of the Year 2013-14</strong></br>";
                    MsgBody = MsgBody + "</td>";
                  MsgBody = MsgBody + " </tr>";
           MsgBody = MsgBody + " <tr>";
              MsgBody = MsgBody + "  <td>&nbsp;</td>";
               MsgBody = MsgBody + " <td class='auto-style1'>&nbsp;</td>";
           MsgBody = MsgBody + " </tr>";
          MsgBody = MsgBody + " <tr>";
            MsgBody = MsgBody + "<td align='center'><strong><span style='font-size:18.0pt;font-family:&quot;Helvetica&quot;&quot;sans-serif&quot;color:#606060'>We are hiring</span></strong></td>";
            MsgBody = MsgBody + "<td rowspan='5'><img alt='' src='http://myhire361.com/emailimages/common.jpg'  /></td>";
        MsgBody = MsgBody + "</tr>";
        MsgBody = MsgBody + "<tr>";
          MsgBody = MsgBody + "  <td><span style=' margin-left:15px;font-size:11.5pt;font-family:&quot;Helvetica&quot;,&quot;sans-serif&quot;;color:black'>For career opportunities at </span>";
            
       MsgBody = MsgBody + " <br />";
           MsgBody = MsgBody + "     <span style='margin-left:15px;font-size:11.5pt;font-family:&quot;Helvetica&quot;,&quot;sans-serif&quot;;color:black'>MAXLIFE you can connect with</span>";
           MsgBody = MsgBody + "     <br />";
            MsgBody = MsgBody + "    <span style='margin-left:15px;font-size:11.5pt;font-family:&quot;Helvetica&quot;,&quot;sans-serif&quot;;color:black'>our hiring partners&nbsp;SKOPE </span>";
            MsgBody = MsgBody + "    <br />";
               
             MsgBody = MsgBody + "  <span style='margin-left:15px;font-size:11.5pt;font-family:&quot;Helvetica&quot;,&quot;sans-serif&quot;;color:black'> Consultants.";
             MsgBody = MsgBody + "   <br />";
             MsgBody = MsgBody + "  <span style='margin-left:15px;font-size:11.5pt;font-family:&quot;Helvetica&quot;,&quot;sans-serif&quot;;color:black'> Email_Id:mamta.d@skopeconsultants.com</span>";
            MsgBody = MsgBody + "</td>";
            
           
        MsgBody = MsgBody + "</tr>";
        MsgBody = MsgBody + "<tr>";
        MsgBody = MsgBody + "    <td>&nbsp;</td>";
           
        MsgBody = MsgBody + "</tr>";
        MsgBody = MsgBody + "<tr>";
           MsgBody = MsgBody + " <td>&nbsp;</td>";
            
        MsgBody = MsgBody + "</tr>";
        MsgBody = MsgBody + "<tr>";
            MsgBody = MsgBody + "<td colspan='2' align='center'><em><span style='font-size:8.5pt;line-height:125%;font-family:&quot;Helvetica&quot;,&quot;sans-serif&quot;;color:#606060'>Copyright © *|2015|* *|SKOPE Consultants|*, All rights reserved.</span></em><span style='font-size:8.5pt;line-height:125%;font-family:&quot;Helvetica&quot;,&quot;sans-serif&quot;;color:#606060'><br />";
                MsgBody = MsgBody + "</span></td>";
        MsgBody = MsgBody + "</tr>";
        MsgBody = MsgBody + "<tr>";
            MsgBody = MsgBody + "<td colspan='2' align='center'><span style='font-size:8.5pt;line-height:125%;font-family:&quot;Helvetica&quot;,&quot;sans-serif&quot;;color:#606060'><br />";
             MsgBody = MsgBody + "   </span></td>";
       MsgBody = MsgBody + " </tr>";
       
           
        MsgBody = MsgBody + "</table>";

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