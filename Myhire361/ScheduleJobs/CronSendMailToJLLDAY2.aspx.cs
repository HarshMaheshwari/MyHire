using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Net.Mail;
using System.Data;


public partial class ScheduleJobs_CronSendMailToJLLDAY2 : System.Web.UI.Page
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
            dt = jll.JLLEmail3();
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

                jll.UpdateJLLEmailForDate3();           
            MailMessage msg = new MailMessage();
            SmtpClient smt = new SmtpClient();
            string MsgBody;

            msg.From = new MailAddress("noreply@indiahiring.net", "IndiaHiring");
      msg.To.Add(Email);
      //   msg.To.Add("ISHAN3333@gmail.com ");
            msg.IsBodyHtml = true;

           // msg.Bcc.Add("ISHAN3333@gmail.com");
          // msg.Bcc.Add("nisha.mann21@gmail.com");
            msg.Subject = "JLL Awards & Recognitions";
            MsgBody = "";

            MsgBody = MsgBody + "    <table id ='tb' width='800' height='760' border='0' cellpadding='0' cellspacing='0' style='background-color: #FFFFFF'  >";
            MsgBody = MsgBody + "  <tr>";
            MsgBody = MsgBody + "   <td width='76%' height='140px' align='Center' valign='Center' colspan='3' >";
            MsgBody = MsgBody + " 	<a href='http://www.joneslanglasalle.co.in/india/en-gb/'>";
            MsgBody = MsgBody + "	<img src='http://myhire361.com/emailimages/JLL.jpg' width='800' height='378'  border='0' alt=''></td></a>";
            
            MsgBody = MsgBody + "      </tr>";
            MsgBody = MsgBody + "  <tr>";
            MsgBody = MsgBody + "   <td width='5%' height='0%'></td><td width='90%' >";
            MsgBody = MsgBody + "  <table id='Table_01'   border='0'  bgcolor='#FFFFFF'>";
            MsgBody = MsgBody + "      <tr>";

            MsgBody = MsgBody + "    <td  align='Center'>";
            MsgBody = MsgBody + "   <h1>About JLL </h1>";
            MsgBody = MsgBody + "      </td>";
            MsgBody = MsgBody + "      </tr>";
            MsgBody = MsgBody + "      <tr>";

            MsgBody = MsgBody + "    <td colspan='11' align='justify'>";
            MsgBody = MsgBody + "  <p><font size='3'>";

            MsgBody = MsgBody + "   JLL (NYSE: JLL) is a professional services and investment management firm offering specialized real ";
            MsgBody = MsgBody + "   estate services to clients seeking increased value by owning, occupying and investing in real estate.  ";

            MsgBody = MsgBody + "   With annual fee revenue of $4.7 billion and gross revenue of $5.4 billion, JLL has more than 230  ";

            MsgBody = MsgBody + "   corporate offices, operates in 80 countries and has a global workforce of approximately 58,000.  On  ";

            MsgBody = MsgBody + "   behalf of its clients, the firm provides management and real estate outsourcing services for a  ";

            MsgBody = MsgBody + "   property portfolio of 3.4 billion square feet, or 316 million square meters, and completed $118  ";

            MsgBody = MsgBody + "   billion in sales, acquisitions and finance transactions in 2014. Its investment management business,  ";

            MsgBody = MsgBody + "   LaSalle Investment Management, has $53.6 billion of real estate assets under management. JLL is  ";

            MsgBody = MsgBody + "   the brand name, and a registered trademark, of JLL Incorporated.<br><br> JLL has over 50 years of experience  ";

            MsgBody = MsgBody + "   in Asia Pacific, with over 29,000 employees operating in 81 offices in 16 countries across the region.  ";

            MsgBody = MsgBody + "   The firm was named ‘Best Property Consultancy’ in seven Asia Pacific countries at the International  ";

            MsgBody = MsgBody + "   Property Awards Asia Pacific 2014, and won nine Asia Pacific awards in the Euromoney Real Estate  ";

            MsgBody = MsgBody + "   Awards 2013.";
            MsgBody = MsgBody + "      </font></p> ";

            MsgBody = MsgBody + "      </td>";

            MsgBody = MsgBody + "      </tr>";
            MsgBody = MsgBody + "      <tr>";
            MsgBody = MsgBody + "      <td>";
            MsgBody = MsgBody + "      <HR>";
            MsgBody = MsgBody + "      </td>";

            MsgBody = MsgBody + "      </tr>";
            MsgBody = MsgBody + "      <tr>";

            MsgBody = MsgBody + "    <td  align='Center' font size='3'>";

            MsgBody = MsgBody + "  <h1>  Awards & Recognitions</h1> ";
            MsgBody = MsgBody + "      </td>";
            MsgBody = MsgBody + "      </tr>";
            MsgBody = MsgBody + "      <tr>";

            MsgBody = MsgBody + "    <td  align='left' font size='3'>";
            MsgBody = MsgBody + " • INTERNATIONAL PROPERTY AWARDS ASIA PACIFIC (2014-2015, 2012-2013)<font color='Red'> Best Property Consultancy India (5 star)</font><br> ";
            MsgBody = MsgBody + "  • EUROMONEY AWARDS (2014) <font color='Red'> Advisors and Consultants - Overall & Agency/Letting </font><br> ";
            MsgBody = MsgBody + "   • CMO AISA AWARDS (2014) <font color='Red'> Most Admired Shopping Mall Management Company of the Year </font><br> ";
            MsgBody = MsgBody + " • REAL ESTATE AWARDS (2015, 2012) <font color='Red'> Employer of the Year in Real Estate  </font><br> ";
            MsgBody = MsgBody + "  • AISA RETAIL CONGRESS (2015, 2014, 2013) <font color='Red'> International Property Consultants of the Year - Commercial/Retail </font><br> ";
            MsgBody = MsgBody + "  • FACILITY MANAGEMENT AWARDS (2014) <font color='Red'> FM Service Provider of the Year </font><br> ";
            MsgBody = MsgBody + "      </td>";
               MsgBody = MsgBody + "      </tr>";
               MsgBody = MsgBody + "      <tr>";
               MsgBody = MsgBody + "      <td valign='center'>";
               MsgBody = MsgBody + "     		Follow us on: <a href='https://www.linkedin.com/company/jll'>";
               MsgBody = MsgBody + "     			<img src='http://myhire361.com/emailimages/in.png' width='30' height='30' border='0' alt=''></a> 		";
               MsgBody = MsgBody + "      </td>";

               MsgBody = MsgBody + "      </tr>";
            MsgBody = MsgBody + "     </table>";
            MsgBody = MsgBody + "   </td><td width='5%'></td></tr>";
             
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
            //userbal = null;
            //followup = null;
        }
    }



}
    

   

