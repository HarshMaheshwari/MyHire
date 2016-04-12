using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Net.Mail;
using System.Data;

public partial class ScheduleJobs_CronSendMailToClubMahindra : System.Web.UI.Page
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

             string Email =  dt.Rows[i]["emailId"].ToString();

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
                msg.Subject = "Club Mahindra Overview";
                MsgBody = "";


                MsgBody = MsgBody + "<div style='background-color:#f2f2f2; padding:19px 48px; width:87%';>";

                MsgBody = MsgBody + "<table  width='40%' style='background-color:white; '>";
                MsgBody = MsgBody + " <tr>";
                MsgBody = MsgBody + "   <td colspan='2' align='left'>";
                MsgBody = MsgBody + "     <img alt='' style='text-align:left ; ' src='http://myhire361.com/emailimages/club-mahindra-new-logo.png' />";

                MsgBody = MsgBody + "  </td>";
                MsgBody = MsgBody + "   </tr>";
                MsgBody = MsgBody + "  <tr>";
                MsgBody = MsgBody + "    <td colspan='2' align='center' style='padding: 9px 18px;'>";
                MsgBody = MsgBody + "         <p class='MsoNormal' style='margin-bottom:0in;margin-bottom:.0001pt;line-height:125%;mso-outline-level:1'>";
                MsgBody = MsgBody + "<b><span style='font-size:22.5pt;line-height:125%;font-family:&quot;Helvetica&quot;,&quot;sans-serif&quot;;mso-fareast-font-family:&quot;Times New Roman&quot;;color:#606060;letter-spacing:-.75pt;mso-font-kerning:18.0pt'>Mahindra Holidays &amp; Resorts India Ltd.</span><span style='font-size:30.0pt;line-height:125%;font-family:&quot;Helvetica&quot;,&quot;sans-serif&quot;;mso-fareast-font-family:&quot;Times New Roman&quot;;color:#606060;letter-spacing:-.75pt;mso-font-kerning:18.0pt'><o:p></o:p></span></b></p><p class='MsoNormal'>";
                MsgBody = MsgBody + " <b><span style='font-size:13.5pt;line-height:125%';font-family:&quot;Helvetica&quot;,&quot;sans-serif&quot;;mso-fareast-font-family:&quot;Times New Roman&quot;color:#606060;letter-spacing:-.4pt'>Creating an elegant email is simple<o:p></o:p></span></b></p>";
                MsgBody = MsgBody + "          </td>";
                MsgBody = MsgBody + "   </tr>";
                MsgBody = MsgBody + "    <tr>";
                MsgBody = MsgBody + "      <td>&nbsp;</td>";
                MsgBody = MsgBody + "     <td class='auto-style1'>&nbsp;</td>";
                MsgBody = MsgBody + "   </tr>";
                MsgBody = MsgBody + "   <tr>";
                MsgBody = MsgBody + "       <td colspan='2' style='text-align: justify;padding: 9px 18px;margin: 1em 0px;color: #606060;font-family: Helvetica;font-size: 15px;line-height: 150%;'>";
                MsgBody = MsgBody + "     Mahindra Holidays &amp; Resorts India Limited was incorporated as a private limited company called &#39;Mahindra Holidays &amp; Resorts India Private Limited&#39;&nbsp;on September 20, 1996. The status of the Company was changed to a public limited company by a special resolution of the members passed at the annual general meeting held on January 29, 1998. The fresh certificate of incorporation consequent upon conversion was issued to the Company on April 17, 1998, by the Registrar of Companies, Tamil Nadu at Chennai.</td>";
                MsgBody = MsgBody + "  </tr>";
                MsgBody = MsgBody + "  <tr>";
                MsgBody = MsgBody + "   <td>&nbsp;</td>";
                MsgBody = MsgBody + " <td class='auto-style1'>&nbsp;</td>";
                MsgBody = MsgBody + " </tr>";
                MsgBody = MsgBody + "  <tr>";
                MsgBody = MsgBody + "    <td style='padding: 9px 18px;' width='262px'>";
                MsgBody = MsgBody + "       <img alt='' src='http://myhire361.com/emailimages/cm4.jpg' width='262px' /></td>";
                MsgBody = MsgBody + "   <td style='padding: 9px 18px;' width='262px'>";
                MsgBody = MsgBody + "      <img alt='' src='http://myhire361.com/emailimages/cm3.jpg' width='262px' /></td>";
                MsgBody = MsgBody + "   </tr>";
                MsgBody = MsgBody + "   <tr style='padding: 0px 9px;color: #606060;font-family: Helvetica;font-size: 15px;line-height: 150%;text-align: left;'>";
                MsgBody = MsgBody + "      <td style='padding: 9px 18px;'><strong>Mahindra Holidays to invest $500 crore in new properties</strong></td>";
                MsgBody = MsgBody + "    <td style='padding: 9px 18px;' ><strong>Digital sales, referrals drive growth for Mahindra Holidays</strong></td>";
                MsgBody = MsgBody + "   </tr>";
                MsgBody = MsgBody + "   <tr style='padding: 0px 9px;color: #606060;font-family: Helvetica;font-size: 15px;line-height: 150%;text-align: left;'>";
                MsgBody = MsgBody + "          <td style='font-size: 14px; padding: 9px 18px;' align='center'><a target='_blank' style=' font-weight: normal;letter-spacing: normal;line-height: 100%;text-align: center;text-decoration: none;color: #FFF;word-wrap: break-word;display: block;' href='http://www.thehindubusinessline.com/companies/mahindra-holidays-adds-resort-in-kanha/article6958479.ece'/><input id='Button2' style='background-color:#14B9B9;font-family: Arial;font-size: 16px;padding: 16px; border-radius:3px; border:1px solid #14B9B9; color:white;' type='button' value='Read More' /></td>";
                MsgBody = MsgBody + "   <td style='font-size: 14px; padding: 9px 18px;'align='center' class='auto-style1'><a  style='font-weight: normal;letter-spacing: normal;line-height: 100%;text-align: center;text-decoration: none;color: #FFF;word-wrap: break-word;display: block;' target='_blank' href='http://www.thehindu.com/business/Industry/digital-sales-referrals-drive-growth-for-mahindra-holidays/article7474625.ece'/><input id='Button3' style='background-color:#14B9B9;font-family: Arial;font-size: 16px;padding: 16px; border-radius:3px; border:1px solid #14B9B9; color:white;' type='button' value='Read More' /></td>";
                MsgBody = MsgBody + "  </tr>";
                MsgBody = MsgBody + "  <tr>";
                MsgBody = MsgBody + "     <td>&nbsp;</td>";
                MsgBody = MsgBody + "     <td class='auto-style1'>&nbsp;</td>";
                MsgBody = MsgBody + "    </tr>";
                MsgBody = MsgBody + "   <tr>";
                MsgBody = MsgBody + "    <td style='padding: 9px 18px;' >";
                MsgBody = MsgBody + "    <img alt='' src='http://myhire361.com/emailimages/cm2.png' width='262px' /></td>";
                MsgBody = MsgBody + "  <td style='padding: 9px 18px;' >";
                MsgBody = MsgBody + "     <img alt='' src='http://myhire361.com/emailimages/cm1.jpg' width='262px' /></td>";
                MsgBody = MsgBody + "  </tr>";
                MsgBody = MsgBody + "  <tr>";
                MsgBody = MsgBody + "   <td style='padding: 9px 18px;color: #606060;font-family: Helvetica;font-size: 15px;line-height: 150%;'>";

                MsgBody = MsgBody + "      <strong>Mahindra Holidays ups stakes to 88% in Holiday Club Resort Oy, Finland</strong></td>";
                MsgBody = MsgBody + "   <td style='padding: 9px 18px;color: #606060;font-family: Helvetica;font-size: 15px;line-height: 150%;' >";

                MsgBody = MsgBody + "     <strong>Club-M&nbsp;to hike stake in Europe&#39;s Holiday Club to 88% for $31M</strong></td>";
                MsgBody = MsgBody + "     </tr>";
                MsgBody = MsgBody + "   <tr>";
                MsgBody = MsgBody + "   <td style='font-size: 14px; padding: 9px 18px;' align='center'><a style=' font-weight: normal;letter-spacing: normal;line-height: 100%;text-align: center;text-decoration: none;color: #FFF;word-wrap: break-word;display: block;'target='_blank' href='http://www.financialexpress.com/article/travel/market-travel/mahindra-holidays-ups-stakes-to-88-per-cent-in-holiday-club-resort-oy-finland/100773/'/><input id='Button2' style='background-color:#14B9B9;font-family: Arial;font-size: 16px;padding: 16px; border-radius:3px; border:1px solid #14B9B9; color:white;' type='button' value='Read More' /></td><td style='font-size: 14px; padding: 9px 18px;'align='center' class='auto-style1'><a style='font-weight: normal;letter-spacing: normal;line-height: 100%;text-align: center;text-decoration: none;color: #FFF;word-wrap: break-word;display: block'; target='_blank' href='http://www.vccircle.com/news/consumer/2015/06/09/mahindra-holidays-hike-stake-europes-holiday-club-88-31m'/><input id='Button3' style='background-color:#14B9B9;font-family: Arial;font-size: 16px;padding: 16px; border-radius:3px; border:1px solid #14B9B9; color:white;' type='button' value='Read More' /></td>";
                MsgBody = MsgBody + "  </tr>";
                MsgBody = MsgBody + "  <tr>";
                MsgBody = MsgBody + "    <td colspan='2' style='padding: 9px 18px;'>";

                MsgBody = MsgBody + "   </tr>";
                MsgBody = MsgBody + "  <tr >";
                MsgBody = MsgBody + "   <td colspan='2' style='padding: 9px 18px;text-align: justify;margin: 1em 0px;color: #606060;font-family: Helvetica;font-size: 15px;line-height: 150%;'>";
                MsgBody = MsgBody + " Club Mahindra Holidays is the flagship service offering. As part of the growth strategy, It has also diversified the portfolio by introducing new vacation ownership offerings, Zest and Club Mahindra Fundays, Mahindra Homestays and travel and holiday related services through clubmahindra&nbsp;travel.</tr>";
                MsgBody = MsgBody + "     <tr>";
                MsgBody = MsgBody + "       <td>&nbsp;</td>";
                MsgBody = MsgBody + "     <td class='auto-style1'>&nbsp;</td>";
                MsgBody = MsgBody + "   </tr>";
                MsgBody = MsgBody + "    <tr>";
                MsgBody = MsgBody + "      <td colspan='2' style='font-size: 14px; padding: 9px 18px;' align='center'><a style='font-weight: normal;letter-spacing: normal;line-height: 100%;text-align: center;text-decoration: none;color: #FFF;word-wrap: break-word;display: block;' target='_blank' href='http://www.indeed.co.in/cmp/Club-Mahindra/reviews?fcountry=IN'/><input id='Button5' style='background-color:#E6143E;font-family: Arial;font-size: 16px;padding: 16px; border-radius:3px; border:1px solid #E6143E; color:white;' type='button' value='Employess Reviews' /></td>";
                MsgBody = MsgBody + "  </tr>";
                MsgBody = MsgBody + "   <tr>";
                MsgBody = MsgBody + "      <td></td>";
                MsgBody = MsgBody + "      <td class='auto-style1'></td>";
                MsgBody = MsgBody + "    </tr>";
                MsgBody = MsgBody + "<tr>";
                MsgBody = MsgBody + "    <td style='padding: 9px 18px;'><span style='color:#606060;font-family:helvetica;font-size:24px;line-height:22.5px'><strong style='line-height:20.7999992370605px'>We are hiring</strong></span></td>";
                MsgBody = MsgBody + "     <td style='padding: 9px 60px;' class='auto-style1' rowspan='2'>";
                MsgBody = MsgBody + "        <img alt='' src='http://myhire361.com/emailimages/common.jpg' / width='200px'  height='200px'> </td>";
                MsgBody = MsgBody + " </tr>";
                MsgBody = MsgBody + "  <tr>";
                MsgBody = MsgBody + "      <td style='padding: 9px 18px;'><span style=' color:#606060;font-family:helvetica;font-size:15px;line-height:20.7999992370605px'>For career opportunities at Club Mahindra&nbsp;you can connect with our hiring partners&nbsp;SKOPE Consultants.";
                MsgBody = MsgBody + "     Mob: 9560596375, 9560690177 EmailId:surabhi.s@skopeconsultants.com</span></td>";

                MsgBody = MsgBody + "   </tr>";
                MsgBody = MsgBody + "  <tr>";
                MsgBody = MsgBody + "    <td colspan='2' align='center' style='color: #606060;font-family: Helvetica;font-size: 11px;line-height: 125%;text-align: center;'>";
                MsgBody = MsgBody + " Copyright © 2015 SKOPE Consultants, All rights reserved.</td>";
                MsgBody = MsgBody + "     </tr>";
                MsgBody = MsgBody + "     <tr>";
                MsgBody = MsgBody + "         <td colspan='2'></td>";
                MsgBody = MsgBody + "     </tr>";
                MsgBody = MsgBody + "     <tr>";
                MsgBody = MsgBody + "        <td colspan='2' align='center'><span style='line-height:20.7999992370605px'><a href='http://www.skopeconsultants.com' target='_blank'>www.skopeconsultants.com</a></span></td>";
                MsgBody = MsgBody + " </tr>";

                MsgBody = MsgBody + " </table>";

                MsgBody = MsgBody + "</div>";



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