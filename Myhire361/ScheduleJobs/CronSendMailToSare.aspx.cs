using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Net.Mail;
using System.Data;
public partial class ScheduleJobs_CronSendMailToSare : System.Web.UI.Page
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
                //  msg.To.Add("ISHAN3333@gmail.com");
                //msg.To.Add("ISHAN3333@gmail.com");
                msg.IsBodyHtml = true;

                  //msg.Bcc.Add("mayurionweb@gmail.com");
                //msg.Bcc.Add("");
                msg.Subject = "Sare Homes Overview";
                MsgBody = "";

                MsgBody = MsgBody + "    <table id='tb' width='50%'>";
                MsgBody = MsgBody + "       <tr>";
                MsgBody = MsgBody + "  <td width='50%'>";

                MsgBody = MsgBody + "          <img src='http://myhire361.com/emailimages/homes.jpg' ></td>";
                MsgBody = MsgBody +   "                 <img src='http://myhire361.com/emailimages/skope.png' </td>";
                MsgBody = MsgBody + "     </tr>";
        
                MsgBody = MsgBody + "   <tr >";

              MsgBody = MsgBody + " <td colspan='2'style='color:#222222 ; font-size:x-large;';> <strong><span style='font-family:&quot;Helvetica&quot;,&quot;sans-serif&quot;'>What is SARE Homes?</span></strong></td>";
            
          MsgBody = MsgBody + " </tr>";
         MsgBody = MsgBody + "<tr>";
         MsgBody = MsgBody + "<td  colspan='2' style='text-align: justify; margin-left:15px;font-size:11.5pt;line-height:150%;font-family:Helvetica,sans-serif;color:#606060'>1.SARE Homes (South Asian Real Estate), promoted by the DUET Group<br/>";
              MsgBody = MsgBody + "(UK), is an India-focussed 100% FDI Developer of Integrated Residential<br />";
                  MsgBody = MsgBody + " Townships. SARE Homes has a strategy to invest and develop Integrated<br />";
                  MsgBody = MsgBody + " Residential Townships on a Pan-India basis. SARE Homes currently has <br />";
                  MsgBody = MsgBody + "Projects at Gurgaon, Mumbai, Chennai, Ghaziabad, Indore and Amritsar.<br />";




                  MsgBody = MsgBody + "2.With proposed projects at NCR, Ahmedabad, Bangalore and Kolkata,<br/>";
                 MsgBody = MsgBody + "SARE Homes is actively seeking to expand its portfolio across India.<br/>";
             MsgBody = MsgBody + "3.SARE is known for providing quality constriction at convenient locations <br/>";
             MsgBody = MsgBody + "and ensuring on time delivery of projects.</td>";
            
         MsgBody = MsgBody + "</tr>";
         MsgBody = MsgBody + "<tr>";
             MsgBody = MsgBody + "<td rowspan='4'> <img alt='' src='http://myhire361.com/emailimages/sarepara1.jpg' width='300px' style='height: 279px' /></td>";

             MsgBody = MsgBody + "<td style='text-align: justify;margin-left:15px;font-style:normal; color:#222222 ; font-size:small'><strong><span style='font-family:&quot;Helvetica&quot;,&quot;sans-serif&quot;;color:dimgray'>Why should I join Real-Estate?</span></strong></td>";
         MsgBody = MsgBody + "</tr>";
         MsgBody = MsgBody + "<tr>";

         MsgBody = MsgBody + "<td style='text-align: justify; margin-left:15px;font-size:11.5pt;line-height:150%;font-family:Helvetica,sans-serif;color:#606060'>1.As you might be aware that<br/>";
                  MsgBody = MsgBody + "buying a house is the most <br />";
                      MsgBody = MsgBody + "important goal for an <br />";
                      MsgBody = MsgBody + "individual. We don't have <br />"; 
         MsgBody = MsgBody + "PUSH the product, there is <br />";
         MsgBody = MsgBody + "already a PULL for it.</td>";
                
                
                
                MsgBody = MsgBody + "</tr>";
         MsgBody = MsgBody + "<tr>";

         MsgBody = MsgBody + "<td style='text-align: justify; margin-left:15px;font-size:11.5pt;line-height:150%;font-family:Helvetica,sans-serif;color:#606060'>2.Also real estate gives you an<br/>";
              MsgBody = MsgBody + "opportunity to grow your <br />";
                 MsgBody = MsgBody + "professional network and help <br />";
                 MsgBody = MsgBody + "customers own a dream home <br />";
    MsgBody = MsgBody + "which is a very satisfying <br />";
    MsgBody = MsgBody + "feeling.</td>";
                
                
                
                
                
                MsgBody = MsgBody + "</tr>";
         MsgBody = MsgBody + "<tr>";

         MsgBody = MsgBody + "<td style='text-align: justify; margin-left:15px;font-size:11.5pt;line-height:150%;font-family:Helvetica,sans-serif;color:#606060'>3.In India, the housing demand<br/>";
         
                  MsgBody = MsgBody + "will be 50 million in next 15 <br />";
                 MsgBody = MsgBody + "years and the supply will  <br />";
                 MsgBody = MsgBody + "increase  to  30 million in the <br />";
                 MsgBody = MsgBody + "same period.</td>";
                
                
                
                MsgBody = MsgBody + "</tr>";
         MsgBody = MsgBody + "<tr>";
         MsgBody = MsgBody + "<td><strong><span style=' margin-left:5px;font-size:11.5pt;font-family:&quot;Helvetica&quot;,&quot;sans-serif&quot;;color:#606060'>Why Should I join SARE Homes?</span></strong></td>";
         MsgBody = MsgBody + "<td rowspan='4'><img alt='' src='http://myhire361.com/emailimages/sarepara2.jpg' width='249px' style='height: 279px' /></td>";
         MsgBody = MsgBody + "</tr>";
         MsgBody = MsgBody + "<tr>";
         MsgBody = MsgBody + "<td style='text-align: justify; margin-left:15px;font-size:11.5pt;line-height:150%;font-family:Helvetica,sans-serif;color:#606060'>1.SARE homes is a young yet<br/>";
            MsgBody = MsgBody + "established developer in real <br />";
                MsgBody = MsgBody + "estate sector. It is a <br />";
                MsgBody = MsgBody + "Professionally Driven <br />";
               MsgBody = MsgBody + "Organization that believes in <br />";
               MsgBody = MsgBody + "being Transparent, Credible & <br />";
               MsgBody = MsgBody + "Honest with its Customers and <br />";
               MsgBody = MsgBody + "Employees.</td>";
         MsgBody = MsgBody + "</tr>";
         MsgBody = MsgBody + "<tr>";
         MsgBody = MsgBody + "<td style=' text-align: justify;margin-left:15px;font-size:11.5pt;line-height:150%;font-family:Helvetica,sans-serif;color:#606060'>2.SARE ensures you are<br/>";
            
                MsgBody = MsgBody + "compensated for the impact <br />";
               MsgBody = MsgBody + "that you create and incentives <br />";
               MsgBody = MsgBody + "provide high reward to effort <br />";
               MsgBody = MsgBody + "ratio giving you a potential to <br />";
               MsgBody = MsgBody + "earn at least 30% of your fixed <br />";
              MsgBody = MsgBody + "salary as incentive without any <br />";
              MsgBody = MsgBody + "ceiling.</td>";



         MsgBody = MsgBody + "</tr>";
         MsgBody = MsgBody + "<tr>";
         MsgBody = MsgBody + "<td style='text-align: justify; margin-left:15px;font-size:11.5pt;line-height:150%;font-family:Helvetica,sans-serif;color:#606060'>3.SARE also offers benefit plans<br/>";
    
                   MsgBody = MsgBody + "like Medical & Accident <br />";
                MsgBody = MsgBody + "benefits, Employee Housing <br />";
                 MsgBody = MsgBody +"Discount etc. to ensure your <br />";
                MsgBody = MsgBody + "stay with them is highly <br />";
                MsgBody = MsgBody + "rewarding and satisfying.</td>";


         MsgBody = MsgBody + "</tr>";
         MsgBody = MsgBody + "<tr>";
             MsgBody = MsgBody + "<td colspan='2'>&nbsp;</td>";
            
         MsgBody = MsgBody + "</tr>";
         MsgBody = MsgBody + "<tr>";
             MsgBody = MsgBody + "<td><strong><span style='font-size:11.5pt;line-height:150%;font-family:&quot;Helvetica&quot;,&quot;sans-serif&quot;;color:#606060'>Growth@SARE</span></strong></td>";
        
  
           
           
        
  
           
             MsgBody = MsgBody + "<td  rowspan='1' ><img alt='' src='http://myhire361.com/emailimages/para3sare.gif'  /></td>";
  
           
         MsgBody = MsgBody + "</tr>";
         MsgBody = MsgBody + "<tr>";
         MsgBody = MsgBody + "<td><span style='text-align: justify;font-size:11.5pt;line-height:150%;font-family:Helvetica,sans-serif;color:#606060'>Young Org.&nbsp;that provides <br />";
                   
                MsgBody = MsgBody + "opportunity to ";
                 MsgBody = MsgBody + "earn &amp; grow";
                MsgBody = MsgBody + "Flat organization"; 
                MsgBody = MsgBody + "structure with ";
                MsgBody = MsgBody + "just two levels";
                MsgBody = MsgBody + "between You";
                MsgBody = MsgBody + "and the Sales";
                MsgBody = MsgBody + "Head</span></td>";

                MsgBody = MsgBody + "<td><strong><span style='text-align: justify;font-size:11.5pt;line-height:150%;font-family:&quot;Helvetica&quot;,&quot;sans-serif&quot;;color:#606060'>What is DUET GROUP?</span></strong><span style='font-size:11.5pt;line-height:150%;font-family:&quot;Helvetica&quot;,&quot;sans-serif&quot;;color:#606060'><br />";
                MsgBody = MsgBody + "DUET Group is a Global asset-and-real-estate management firm based out of London, with offices in New York, Boston, Dubai &amp; New Delhi. </span></td>";
                
           
            
        MsgBody = MsgBody + " </tr>";
        MsgBody = MsgBody + "    </Table >";
                 MsgBody = MsgBody + " <table width='85%' style='background-color:#f2f2f2'>";
         MsgBody = MsgBody + "<tr>";
             MsgBody = MsgBody + "<td colspan='2'>&nbsp;</td>";
         
         MsgBody = MsgBody + "</tr>";
         MsgBody = MsgBody + "<tr>";
         MsgBody = MsgBody + "<td><strong><span style='margin-left:15px;font-size:18.0pt;font-family:&quot;Helvetica&quot;,&quot;sans-serif&quot;;color:#606060'>We are hiring</span></strong></td>";
             MsgBody = MsgBody + "<td rowspan='7'><img alt='' src='http://myhire361.com/emailimages/common.jpg'  /></td>";
         MsgBody = MsgBody + "</tr>";
         MsgBody = MsgBody + "<tr>";
         MsgBody = MsgBody + "<td><span style='margin-left:15px;font-size:11.5pt;font-family:&quot;Helvetica&quot;,&quot;sans-serif&quot;;color:black'>For career opportunities at </span></td>";
            
         MsgBody = MsgBody + "</tr>";
         MsgBody = MsgBody + "<tr>";
         MsgBody = MsgBody + " <td><span style='margin-left:15px;font-size:11.5pt;font-family:&quot;Helvetica&quot;,&quot;sans-serif&quot;;color:black'>SAREHOMES you can connect with</span></td>";
            
         MsgBody = MsgBody + "</tr>";
         MsgBody = MsgBody + "<tr>";
         MsgBody = MsgBody + "<td><span style='margin-left:15px;font-size:11.5pt;font-family:&quot;Helvetica&quot;,&quot;sans-serif&quot;;color:black'>our hiring partners&nbsp;SKOPE </span></td>";
            
         MsgBody = MsgBody + "</tr>";
         MsgBody = MsgBody + "<tr>";
             MsgBody = MsgBody + "<td>";


             MsgBody = MsgBody + " <span style='margin-left:15px;font-size:11.5pt;font-family:&quot;Helvetica&quot;,&quot;sans-serif&quot;;color:black'>Consultants.</span></td>";
                    
             MsgBody = MsgBody + "</td>";
           
         MsgBody = MsgBody + "</tr>";
         MsgBody = MsgBody + "<tr>";
           
         MsgBody = MsgBody + "</tr>";
         MsgBody = MsgBody + "<tr>";
            
         MsgBody = MsgBody + "</tr>";
         MsgBody = MsgBody + "<tr>";
             MsgBody = MsgBody + "<td colspan='2' align='center'><em><span style='font-size:8.5pt;line-height:125%;font-family:&quot;Helvetica&quot;,&quot;sans-serif&quot;;color:#606060'>Copyright © *|2015|* *|SKOPE Consultants|*, All rights reserved.</span></em><span style='font-size:8.5pt;line-height:125%;font-family:&quot;Helvetica&quot;,&quot;sans-serif&quot;;color:#606060'><br />";
                 MsgBody = MsgBody + "</span></td>";
         MsgBody = MsgBody + "</tr>";
         MsgBody = MsgBody + "<tr>";
                 MsgBody = MsgBody +"</u></span></td>";
         MsgBody = MsgBody +"</tr>";
        MsgBody = MsgBody +"<tr>";
        MsgBody = MsgBody +"</tr>";
        MsgBody = MsgBody +"<tr>";
            MsgBody = MsgBody +"<td colspan='2'>&nbsp;</td>";
          
        MsgBody = MsgBody +"</tr>";
        MsgBody = MsgBody +"</table>";


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