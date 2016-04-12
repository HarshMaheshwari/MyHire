using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Net.Mail;

public partial class SendMailForDailyReport : System.Web.UI.Page
{
    ReportBAL RprtBal;
    LoginBAL userbal;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            SendMailForOld();
        }
    }

    private void SendMailForOld()
    {
        RprtBal = new ReportBAL();
        userbal = new LoginBAL();
        int TotalTodayContacted = 0;
        int TotalMTDContacted = 0;
        int TotalTodayLinedUp = 0;
        int TotalMTDLinedUp = 0;
        int TotalTodayInterviewed = 0;
        int TotalMTDInterviewed = 0;
        int TotalTodayShortlist = 0;
        int TotalMTDShortlist= 0;
        int TotalTodayHired = 0;
        int TotalMTDHired= 0;
        int TotalTodayJoined = 0;
        int TotalMTDJoined = 0;
        int TotalTodayShared = 0;
        int TotalMTDShared = 0; 
        try
        {
            MailMessage msg = new MailMessage();
            SmtpClient smt = new SmtpClient();
            string MsgBody;
            DataTable dtu = new DataTable();
            DataTable dtdir = new DataTable();
            dtu = userbal.GetUserForWorksheet();
            dtdir = userbal.GetDirectorForSendMail();

            msg.From = new MailAddress("rrteam@myhire361.com", "myhire361");
           
            for (int d = 0; d < dtdir.Rows.Count; d++)
            {
               string DirEmail = dtdir.Rows[d]["USR_Email"].ToString();
                msg.To.Add(DirEmail);
            }
              for (int i = 0; i < dtu.Rows.Count; i++)
                {
                    string email = dtu.Rows[i]["USR_Email"].ToString();
                    msg.CC.Add(email);
                }
          
         //   msg.Bcc.Add("hrteam@myhro360.com");
              msg.Bcc.Add("rrteam@myhire361.com");
            msg.Subject = "Daily Work Report";
            MsgBody = "";
            MsgBody = MsgBody + "Dear All," +"<BR><BR>";
            MsgBody = MsgBody + "Please find below the yesterday’s work list of all the consultants:" + "<BR><BR>";


            MsgBody = MsgBody + "<table style='width: 800px;font-family: Vrinda;font-size: 13px;text-align: justify;border: thin solid #56150C;margin-left: 20px;margin-top: 20px; color: #56150C;cellspacinf:3;cellpadding:3;table-layout: auto; border-collapse: collapse; empty-cells: show;'>";

            MsgBody = MsgBody + "<tr style='color: #000000;'>";
            MsgBody = MsgBody + "<td style=' border: thin solid #56150C;font-size: 13px;font-weight: bold' align='center' width='100px'>Consultant</td>";
            MsgBody = MsgBody + "<td style=' border: thin solid #56150C;font-size: 13px;font-weight: bold' align='center' width='100px' colspan='2'>Contacted</td>";
            MsgBody = MsgBody + "<td style=' border: thin solid #56150C;font-size: 13px;font-weight: bold' align='center' width='100px' colspan='2'>Lined Up</td>";
            MsgBody = MsgBody + "<td style=' border: thin solid #56150C;font-size: 13px;font-weight: bold' align='center' width='100px' colspan='2'>Interviewed</td>";
            MsgBody = MsgBody + "<td style=' border: thin solid #56150C;font-size: 13px;font-weight: bold' align='center' width='100px' colspan='2'>Shortlisted</td>";
            MsgBody = MsgBody + "<td style=' border: thin solid #56150C;font-size: 13px;font-weight: bold' align='center' width='100px' colspan='2'>Hired</td>";
            MsgBody = MsgBody + "<td style=' border: thin solid #56150C;font-size: 13px;font-weight: bold' align='center' width='100px' colspan='2'>Joined</td>";
            MsgBody = MsgBody + "<td style=' border: thin solid #56150C;font-size: 13px;font-weight: bold' align='center' width='100px' colspan='2'>CV Shared</td>";
            MsgBody = MsgBody + "</tr>";

            MsgBody = MsgBody + "<tr style='color: #000000;'>";
            MsgBody = MsgBody + "<td style=' border: thin solid #56150C;font-size: 13px;font-weight: bold' align='center'></td>";
            MsgBody = MsgBody + "<td style=' border: thin solid #56150C;font-size: 13px;font-weight: bold' align='center' width='50px'>Today</td><td width='50px' style=' border: thin solid #56150C;font-size: 13px;font-weight: bold' align='center'>Mtd</td>";
            MsgBody = MsgBody + "<td style=' border: thin solid #56150C;font-size: 13px;font-weight: bold' align='center' width='50px'>Today</td><td width='50px' style=' border: thin solid #56150C;font-size: 13px;font-weight: bold' align='center'>Mtd</td>";
            MsgBody = MsgBody + "<td style=' border: thin solid #56150C;font-size: 13px;font-weight: bold' align='center' width='50px'>Today</td><td width='50px' style=' border: thin solid #56150C;font-size: 13px;font-weight: bold' align='center'>Mtd</td>";
            MsgBody = MsgBody + "<td style=' border: thin solid #56150C;font-size: 13px;font-weight: bold' align='center' width='50px'>Today</td><td width='50px' style=' border: thin solid #56150C;font-size: 13px;font-weight: bold' align='center'>Mtd</td>";
            MsgBody = MsgBody + "<td style=' border: thin solid #56150C;font-size: 13px;font-weight: bold' align='center' width='50px'>Today</td><td width='50px' style=' border: thin solid #56150C;font-size: 13px;font-weight: bold' align='center'>Mtd</td>";
            MsgBody = MsgBody + "<td style=' border: thin solid #56150C;font-size: 13px;font-weight: bold' align='center' width='50px'>Today</td><td width='50px' style=' border: thin solid #56150C;font-size: 13px;font-weight: bold' align='center'>Mtd</td>";
            MsgBody = MsgBody + "<td style=' border: thin solid #56150C;font-size: 13px;font-weight: bold' align='center' width='50px'>Today</td><td width='50px' style=' border: thin solid #56150C;font-size: 13px;font-weight: bold' align='center'>Mtd</td>";
            MsgBody = MsgBody + "</tr>";


            DataTable dt = new DataTable();
            dt = userbal.GetUserForWorksheet();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                int Userid = Convert.ToInt32(dt.Rows[i]["USR_ID"]);
                string name = dt.Rows[i]["USR_Name"].ToString();

                DataTable dts = new DataTable();
                RprtBal.Usr_Id = Userid;
                dts = RprtBal.GetDailyWorksheetForMail();


                string Contacted = dts.Rows[0]["Contacted"].ToString().Trim();
                string LinedUp = dts.Rows[0]["InterviewSch"].ToString().Trim();
                string Interviewed = dts.Rows[0]["InterviewDone"].ToString().Trim();
                string Shortlisted = dts.Rows[0]["ShortList"].ToString().Trim();
                string Hired = dts.Rows[0]["Offered"].ToString().Trim();
                string Joined = dts.Rows[0]["Joined"].ToString().Trim();
                string Shared = dts.Rows[0]["Shared"].ToString().Trim();

                string MTDContacted = dts.Rows[0]["MTDContacted"].ToString().Trim();
                string MTDLinedUp = dts.Rows[0]["MTDInterviewSch"].ToString().Trim();
                string MTDInterviewed = dts.Rows[0]["MTDInterviewDone"].ToString().Trim();
                string MTDShortlisted = dts.Rows[0]["MTDSelected"].ToString().Trim();
                string MTDHired = dts.Rows[0]["MTDOffered"].ToString().Trim();
                string MTDJoined = dts.Rows[0]["MTDJoined"].ToString().Trim();
                string MTDShared = dts.Rows[0]["MTDShared"].ToString().Trim();

                MsgBody = MsgBody + "<tr>";
                MsgBody = MsgBody + "<td style=' border: thin solid #56150C' align='center'>" + name + "</td>";
                MsgBody = MsgBody + "<td style=' border: thin solid #56150C' align='center' width='50px'>" + Contacted + "</td><td width='50px' style=' border: thin solid #56150C' align='center'>" + MTDContacted + "</td>";
                MsgBody = MsgBody + "<td style=' border: thin solid #56150C' align='center' width='50px'>" + LinedUp + "</td><td width='50px' style=' border: thin solid #56150C' align='center'>" + MTDLinedUp + "</td>";
                MsgBody = MsgBody + "<td style=' border: thin solid #56150C' align='center' width='50px'>" + Interviewed + "</td><td width='50px' style=' border: thin solid #56150C' align='center'>" + MTDInterviewed + "</td>";
                MsgBody = MsgBody + "<td style=' border: thin solid #56150C' align='center' width='50px'>" + Shortlisted + "</td><td width='50px' style=' border: thin solid #56150C' align='center'>" + MTDShortlisted + "</td>";
                MsgBody = MsgBody + "<td style=' border: thin solid #56150C' align='center' width='50px'>" + Hired + "</td><td width='50px' style=' border: thin solid #56150C' align='center'>" + MTDHired + "</td>";
                MsgBody = MsgBody + "<td style=' border: thin solid #56150C' align='center' width='50px'>" + Joined + "</td><td width='50px' style=' border: thin solid #56150C' align='center'>" + MTDJoined + "</td>";
                MsgBody = MsgBody + "<td style=' border: thin solid #56150C' align='center' width='50px'>" + Shared + "</td><td width='50px' style=' border: thin solid #56150C' align='center'>" + MTDShared + "</td>";
                MsgBody = MsgBody + "</tr>";

                TotalTodayContacted = TotalTodayContacted + Convert.ToInt32(Contacted);
                TotalMTDContacted = TotalMTDContacted + Convert.ToInt32(MTDContacted);
                TotalTodayLinedUp = TotalTodayLinedUp + Convert.ToInt32(LinedUp);
                TotalMTDLinedUp = TotalMTDLinedUp + Convert.ToInt32(MTDLinedUp);
                TotalTodayInterviewed = TotalTodayInterviewed + Convert.ToInt32(Interviewed);
                TotalMTDInterviewed = TotalMTDInterviewed + Convert.ToInt32(MTDInterviewed);
                TotalTodayShortlist = TotalTodayShortlist + Convert.ToInt32(Shortlisted);
                TotalMTDShortlist = TotalMTDShortlist + Convert.ToInt32(MTDShortlisted);
                TotalTodayHired = TotalTodayHired + Convert.ToInt32(Hired);
                TotalMTDHired = TotalMTDHired + Convert.ToInt32(MTDHired);
                TotalTodayJoined = TotalTodayJoined + Convert.ToInt32(Joined);
                TotalMTDJoined = TotalMTDJoined + Convert.ToInt32(MTDJoined);
                TotalTodayShared = TotalTodayShared + Convert.ToInt32(Shared);
                TotalMTDShared = TotalMTDShared + Convert.ToInt32(MTDShared);
            }
            MsgBody = MsgBody + "<tr>";
            MsgBody = MsgBody + "<td style=' border: thin solid #56150C;font-size: 13px;font-weight: bold' align='center'>Total</td>";
            MsgBody = MsgBody + "<td style=' border: thin solid #56150C;font-size: 13px;font-weight: bold' align='center' width='50px'>" + TotalTodayContacted + "</td><td width='50px' style=' border: thin solid #56150C;font-size: 13px;font-weight: bold' align='center'>" + TotalMTDContacted + "</td>";
            MsgBody = MsgBody + "<td style=' border: thin solid #56150C;font-size: 13px;font-weight: bold' align='center' width='50px'>" + TotalTodayLinedUp + "</td><td width='50px' style=' border: thin solid #56150C;font-size: 13px;font-weight: bold' align='center'>" + TotalMTDLinedUp + "</td>";
            MsgBody = MsgBody + "<td style=' border: thin solid #56150C;font-size: 13px;font-weight: bold' align='center' width='50px'>" + TotalTodayInterviewed + "</td><td width='50px' style=' border: thin solid #56150C;font-size: 13px;font-weight: bold' align='center'>" + TotalMTDInterviewed + "</td>";
            MsgBody = MsgBody + "<td style=' border: thin solid #56150C;font-size: 13px;font-weight: bold' align='center' width='50px'>" + TotalTodayShortlist + "</td><td width='50px' style=' border: thin solid #56150C;font-size: 13px;font-weight: bold' align='center'>" + TotalMTDShortlist + "</td>";
            MsgBody = MsgBody + "<td style=' border: thin solid #56150C;font-size: 13px;font-weight: bold' align='center' width='50px'>" + TotalTodayHired + "</td><td width='50px' style=' border: thin solid #56150C;font-size: 13px;font-weight: bold' align='center'>" + TotalMTDHired + "</td>";
            MsgBody = MsgBody + "<td style=' border: thin solid #56150C;font-size: 13px;font-weight: bold' align='center' width='50px'>" + TotalTodayJoined + "</td><td width='50px' style=' border: thin solid #56150C;font-size: 13px;font-weight: bold' align='center'>" + TotalMTDJoined + "</td>";
            MsgBody = MsgBody + "<td style=' border: thin solid #56150C;font-size: 13px;font-weight: bold' align='center' width='50px'>" + TotalTodayShared + "</td><td width='50px' style=' border: thin solid #56150C;font-size: 13px;font-weight: bold' align='center'>" + TotalMTDShared + "</td>";
            MsgBody = MsgBody + "</tr>";

            MsgBody = MsgBody + "</table>";

            //-----New TAble----------//

            MsgBody = MsgBody + "<table style='width: 1000px;font-family: Vrinda;font-size: 13px;text-align: justify;border: thin solid #56150C;margin-left: 20px;margin-top: 20px; color: #56150C;cellspacinf:3;cellpadding:3;table-layout: auto; border-collapse: collapse; empty-cells: show;'>";

            MsgBody = MsgBody + "<tr style='color: #000000;'>";
            MsgBody = MsgBody + "<td style=' border: thin solid #56150C;font-size: 13px;font-weight: bold' align='center' >Consultant</td>";
            MsgBody = MsgBody + "<td style=' border: thin solid #56150C;font-size: 13px;font-weight: bold' align='center'  >Day Worked</td>";
            MsgBody = MsgBody + "<td style=' border: thin solid #56150C;font-size: 13px;font-weight: bold' align='center'  >Calls/Day</td>";
            MsgBody = MsgBody + "<td style=' border: thin solid #56150C;font-size: 13px;font-weight: bold' align='center' >Lined Up/Day</td>";
            MsgBody = MsgBody + "<td style=' border: thin solid #56150C;font-size: 13px;font-weight: bold' align='center' >Interviewed/Day</td>";
            MsgBody = MsgBody + "<td style=' border: thin solid #56150C;font-size: 13px;font-weight: bold' align='center' >Shortlisted/Day</td>";
            MsgBody = MsgBody + "<td style=' border: thin solid #56150C;font-size: 13px;font-weight: bold' align='center' width='100px' >Calls to Line Up Ratio</td>";
            MsgBody = MsgBody + "<td style=' border: thin solid #56150C;font-size: 13px;font-weight: bold' align='center' >Line Up to Interview Ratio</td>";
            MsgBody = MsgBody + "<td style=' border: thin solid #56150C;font-size: 13px;font-weight: bold' align='center'  >Interview to Shortlisted Ratio</td>";
            MsgBody = MsgBody + "<td style=' border: thin solid #56150C;font-size: 13px;font-weight: bold' align='center' >Interviewed to Hired Ratio</td>";
            MsgBody = MsgBody + "<td style=' border: thin solid #56150C;font-size: 13px;font-weight: bold' align='center' >Hired to Joined Ratio</td>";
            MsgBody = MsgBody + "</tr>";



           
            dt = userbal.GetUserForWorksheet();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                int Userid = Convert.ToInt32(dt.Rows[i]["USR_ID"]);
                string name = dt.Rows[i]["USR_Name"].ToString();

                DataTable dts = new DataTable();
                RprtBal.Usr_Id = Userid;
                dts = RprtBal.GetDetailWorksheetForDailyMail();
                string DayWorked = dts.Rows[0]["MTDWorkingDays"].ToString().Trim();
                string CallsDay = dts.Rows[0]["MTDCallRatio"].ToString().Trim();
                string LineupDay = dts.Rows[0]["MTDLinedRatio"].ToString().Trim();
                string IntrviewDay = dts.Rows[0]["MTDInterviewedRatio"].ToString().Trim();
                string ShortlistDay = dts.Rows[0]["MTDShorlistedRatio"].ToString().Trim();
                
                string CallsToLineup = dts.Rows[0]["MTDCallsToLineUp"].ToString().Trim();
                string LineupTOInterview = dts.Rows[0]["MTDLineUptoInterview"].ToString().Trim();
                string interviewToShortlist = dts.Rows[0]["MTDInterviewToShortlist"].ToString().Trim();
                string interviewtoHire = dts.Rows[0]["MTDInterviewedToHired"].ToString().Trim();
                string HiretoJoin = dts.Rows[0]["MTDHiredtoJoined"].ToString().Trim();

                MsgBody = MsgBody + "<tr>";
                MsgBody = MsgBody + "<td style=' border: thin solid #56150C' align='center'>" + name + "</td>";
                MsgBody = MsgBody + "<td style=' border: thin solid #56150C' align='center' >" + DayWorked + "</td>";
                MsgBody = MsgBody + "<td style=' border: thin solid #56150C' align='center'>" + CallsDay + "</td>";
                MsgBody = MsgBody + "<td style=' border: thin solid #56150C' align='center'>" + LineupDay + "</td>";
                MsgBody = MsgBody + "<td style=' border: thin solid #56150C' align='center'>" + IntrviewDay + "</td>";
                MsgBody = MsgBody + "<td style=' border: thin solid #56150C' align='center'>" + ShortlistDay + "</td>";
               

                MsgBody = MsgBody + "<td style=' border: thin solid #56150C' align='center'>" + CallsToLineup + "%</td>";
                MsgBody = MsgBody + "<td style=' border: thin solid #56150C' align='center'>" + LineupTOInterview + "%</td>";
                MsgBody = MsgBody + "<td style=' border: thin solid #56150C' align='center'>" + interviewToShortlist + "%</td>";
                MsgBody = MsgBody + "<td style=' border: thin solid #56150C' align='center'>" + interviewtoHire + "%</td>";
                MsgBody = MsgBody + "<td style=' border: thin solid #56150C' align='center'>" + HiretoJoin + "%</td>";
                MsgBody = MsgBody + "</tr>";
            }
            MsgBody = MsgBody + "</table>";

            msg.Body = MsgBody;
            msg.IsBodyHtml = true;
            smt.Host = "relay-hosting.secureserver.net";
            smt.Send(msg);

        }
        finally
        {
            userbal = null;
            RprtBal = null;
        }
    }
}