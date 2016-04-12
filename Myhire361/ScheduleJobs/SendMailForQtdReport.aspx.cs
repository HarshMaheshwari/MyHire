using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net.Mail;
using System.Data;

public partial class SendMailForQtdReport : System.Web.UI.Page
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
        int TotalYTDContacted = 0;
        int TotalQTDContacted = 0;
        int TotalYTDLinedUp = 0;
        int TotalQTDLinedUp = 0;
        int TotalYTDInterviewed = 0;
        int TotalQTDInterviewed = 0;
        int TotalYTDShortlist = 0;
        int TotalQTDShortlist = 0;
        int TotalYTDHired = 0;
        int TotalQTDHired = 0;
        int TotalYTDJoined = 0;
        int TotalQTDJoined = 0;
        int TotalYTDShared = 0;
        int TotalQTDShared = 0;
        try
        {
            MailMessage msg = new MailMessage();
            SmtpClient smt = new SmtpClient();
            string MsgBody;

            msg.From = new MailAddress("rrteam@myhire361.com", "myhire361");
           
            msg.To.Add("aseemgupta@skopeindia.com");
            msg.CC.Add("neha.arora@innovensys.org");
            msg.Subject = "Daily Work Report ";


            MsgBody = "";
            MsgBody = MsgBody + "Dear All," + "<BR><BR>";
            MsgBody = MsgBody + "Please find below the work list of all the consultants:" + "<BR><BR>";


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
            MsgBody = MsgBody + "<td style=' border: thin solid #56150C;font-size: 13px;font-weight: bold' align='center' width='50px'>QTD</td><td width='50px' style=' border: thin solid #56150C;font-size: 13px;font-weight: bold' align='center'>YTD</td>";
            MsgBody = MsgBody + "<td style=' border: thin solid #56150C;font-size: 13px;font-weight: bold' align='center' width='50px'>QTD</td><td width='50px' style=' border: thin solid #56150C;font-size: 13px;font-weight: bold' align='center'>YTD</td>";
            MsgBody = MsgBody + "<td style=' border: thin solid #56150C;font-size: 13px;font-weight: bold' align='center' width='50px'>QTD</td><td width='50px' style=' border: thin solid #56150C;font-size: 13px;font-weight: bold' align='center'>YTD</td>";
            MsgBody = MsgBody + "<td style=' border: thin solid #56150C;font-size: 13px;font-weight: bold' align='center' width='50px'>QTD</td><td width='50px' style=' border: thin solid #56150C;font-size: 13px;font-weight: bold' align='center'>YTD</td>";
            MsgBody = MsgBody + "<td style=' border: thin solid #56150C;font-size: 13px;font-weight: bold' align='center' width='50px'>QTD</td><td width='50px' style=' border: thin solid #56150C;font-size: 13px;font-weight: bold' align='center'>YTD</td>";
            MsgBody = MsgBody + "<td style=' border: thin solid #56150C;font-size: 13px;font-weight: bold' align='center' width='50px'>QTD</td><td width='50px' style=' border: thin solid #56150C;font-size: 13px;font-weight: bold' align='center'>YTD</td>";
            MsgBody = MsgBody + "<td style=' border: thin solid #56150C;font-size: 13px;font-weight: bold' align='center' width='50px'>QTD</td><td width='50px' style=' border: thin solid #56150C;font-size: 13px;font-weight: bold' align='center'>YTD</td>";
            MsgBody = MsgBody + "</tr>";


            DataTable dt = new DataTable();
            dt = userbal.GetUserForWorksheet();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                int Userid = Convert.ToInt32(dt.Rows[i]["USR_ID"]);
                string name = dt.Rows[i]["USR_Name"].ToString();

                DataTable dts = new DataTable();
                RprtBal.Usr_Id = Userid;
                dts = RprtBal.GetWorksheetForQTDMail();


                string YTDContacted = dts.Rows[0]["YTDContacted"].ToString().Trim();
                string YTDLinedUp = dts.Rows[0]["YTDInterviewSch"].ToString().Trim();
                string YTDInterviewed = dts.Rows[0]["YTDInterviewDone"].ToString().Trim();
                string YTDShortlisted = dts.Rows[0]["YTDShortList"].ToString().Trim();
                string YTDHired = dts.Rows[0]["YTDOffered"].ToString().Trim();
                string YTDJoined = dts.Rows[0]["YTDJoined"].ToString().Trim();
                string YTDShared = dts.Rows[0]["YTDShared"].ToString().Trim();

                string QTDContacted = dts.Rows[0]["QTDContacted"].ToString().Trim();
                string QTDLinedUp = dts.Rows[0]["QTDInterviewSch"].ToString().Trim();
                string QTDInterviewed = dts.Rows[0]["QTDInterviewDone"].ToString().Trim();
                string QTDShortlisted = dts.Rows[0]["QTDSelected"].ToString().Trim();
                string QTDHired = dts.Rows[0]["QTDOffered"].ToString().Trim();
                string QTDJoined = dts.Rows[0]["QTDJoined"].ToString().Trim();
                string QTDShared = dts.Rows[0]["QTDShared"].ToString().Trim();

                MsgBody = MsgBody + "<tr>";
                MsgBody = MsgBody + "<td style=' border: thin solid #56150C' align='center'>" + name + "</td>";
                MsgBody = MsgBody + "<td style=' border: thin solid #56150C' align='center' width='50px'>" + QTDContacted + "</td><td width='50px' style=' border: thin solid #56150C' align='center'>" + YTDContacted + "</td>";
                MsgBody = MsgBody + "<td style=' border: thin solid #56150C' align='center' width='50px'>" + QTDLinedUp + "</td><td width='50px' style=' border: thin solid #56150C' align='center'>" + YTDLinedUp + "</td>";
                MsgBody = MsgBody + "<td style=' border: thin solid #56150C' align='center' width='50px'>" + QTDInterviewed + "</td><td width='50px' style=' border: thin solid #56150C' align='center'>" + YTDInterviewed + "</td>";
                MsgBody = MsgBody + "<td style=' border: thin solid #56150C' align='center' width='50px'>" + QTDShortlisted + "</td><td width='50px' style=' border: thin solid #56150C' align='center'>" + YTDShortlisted + "</td>";
                MsgBody = MsgBody + "<td style=' border: thin solid #56150C' align='center' width='50px'>" + QTDHired + "</td><td width='50px' style=' border: thin solid #56150C' align='center'>" + YTDHired + "</td>";
                MsgBody = MsgBody + "<td style=' border: thin solid #56150C' align='center' width='50px'>" + QTDJoined + "</td><td width='50px' style=' border: thin solid #56150C' align='center'>" + YTDJoined + "</td>";
                MsgBody = MsgBody + "<td style=' border: thin solid #56150C' align='center' width='50px'>" + QTDShared + "</td><td width='50px' style=' border: thin solid #56150C' align='center'>" + YTDShared + "</td>";
                MsgBody = MsgBody + "</tr>";

                TotalYTDContacted = TotalYTDContacted + Convert.ToInt32(YTDContacted);
                TotalQTDContacted = TotalQTDContacted + Convert.ToInt32(QTDContacted);
                TotalYTDLinedUp = TotalYTDLinedUp + Convert.ToInt32(YTDLinedUp);
                TotalQTDLinedUp = TotalQTDLinedUp + Convert.ToInt32(QTDLinedUp);
                TotalYTDInterviewed = TotalYTDInterviewed + Convert.ToInt32(YTDInterviewed);
                TotalQTDInterviewed = TotalQTDInterviewed + Convert.ToInt32(QTDInterviewed);
                TotalYTDShortlist = TotalYTDShortlist + Convert.ToInt32(YTDShortlisted);
                TotalQTDShortlist = TotalQTDShortlist + Convert.ToInt32(QTDShortlisted);
                TotalYTDHired = TotalYTDHired + Convert.ToInt32(YTDHired);
                TotalQTDHired = TotalQTDHired + Convert.ToInt32(QTDHired);
                TotalYTDJoined = TotalYTDJoined + Convert.ToInt32(YTDJoined);
                TotalQTDJoined = TotalQTDJoined + Convert.ToInt32(QTDJoined);
                TotalYTDShared = TotalYTDShared + Convert.ToInt32(YTDShared);
                TotalQTDShared = TotalQTDShared + Convert.ToInt32(QTDShared);
            }
            MsgBody = MsgBody + "<tr>";
            MsgBody = MsgBody + "<td style=' border: thin solid #56150C;font-size: 13px;font-weight: bold' align='center'>Total</td>";
            MsgBody = MsgBody + "<td style=' border: thin solid #56150C;font-size: 13px;font-weight: bold' align='center' width='50px'>" + TotalQTDContacted + "</td><td width='50px' style=' border: thin solid #56150C;font-size: 13px;font-weight: bold' align='center'>" + TotalYTDContacted + "</td>";
            MsgBody = MsgBody + "<td style=' border: thin solid #56150C;font-size: 13px;font-weight: bold' align='center' width='50px'>" + TotalQTDLinedUp + "</td><td width='50px' style=' border: thin solid #56150C;font-size: 13px;font-weight: bold' align='center'>" + TotalYTDLinedUp + "</td>";
            MsgBody = MsgBody + "<td style=' border: thin solid #56150C;font-size: 13px;font-weight: bold' align='center' width='50px'>" + TotalQTDInterviewed + "</td><td width='50px' style=' border: thin solid #56150C;font-size: 13px;font-weight: bold' align='center'>" + TotalYTDInterviewed + "</td>";
            MsgBody = MsgBody + "<td style=' border: thin solid #56150C;font-size: 13px;font-weight: bold' align='center' width='50px'>" + TotalQTDShortlist + "</td><td width='50px' style=' border: thin solid #56150C;font-size: 13px;font-weight: bold' align='center'>" + TotalYTDShortlist + "</td>";
            MsgBody = MsgBody + "<td style=' border: thin solid #56150C;font-size: 13px;font-weight: bold' align='center' width='50px'>" + TotalQTDHired + "</td><td width='50px' style=' border: thin solid #56150C;font-size: 13px;font-weight: bold' align='center'>" + TotalYTDHired + "</td>";
            MsgBody = MsgBody + "<td style=' border: thin solid #56150C;font-size: 13px;font-weight: bold' align='center' width='50px'>" + TotalQTDJoined + "</td><td width='50px' style=' border: thin solid #56150C;font-size: 13px;font-weight: bold' align='center'>" + TotalYTDJoined + "</td>";
            MsgBody = MsgBody + "<td style=' border: thin solid #56150C;font-size: 13px;font-weight: bold' align='center' width='50px'>" + TotalQTDShared + "</td><td width='50px' style=' border: thin solid #56150C;font-size: 13px;font-weight: bold' align='center'>" + TotalYTDShared + "</td>";
            MsgBody = MsgBody + "</tr>";

            MsgBody = MsgBody + "</table>";

            //-----New TAble----------//

            MsgBody = MsgBody + "<table style='width: 1000px;font-family: Vrinda;font-size: 13px;text-align: justify;border: thin solid #56150C;margin-left: 20px;margin-top: 20px; color: #56150C;cellspacinf:3;cellpadding:3;table-layout: auto; border-collapse: collapse; empty-cells: show;'>";

            MsgBody = MsgBody + "<tr style='color: #000000;'>";
            MsgBody = MsgBody + "<td style=' border: thin solid #56150C;font-size: 13px;font-weight: bold' align='center' >Consultant</td>";
            MsgBody = MsgBody + "<td style=' border: thin solid #56150C;font-size: 13px;font-weight: bold' align='center'  >QTD Day Worked</td>";
            MsgBody = MsgBody + "<td style=' border: thin solid #56150C;font-size: 13px;font-weight: bold' align='center'  >QTD Calls/Day</td>";
            MsgBody = MsgBody + "<td style=' border: thin solid #56150C;font-size: 13px;font-weight: bold' align='center' >QTD Lined Up/Day</td>";
            MsgBody = MsgBody + "<td style=' border: thin solid #56150C;font-size: 13px;font-weight: bold' align='center' >QTD Interviewed/Day</td>";
            MsgBody = MsgBody + "<td style=' border: thin solid #56150C;font-size: 13px;font-weight: bold' align='center' >QTD Shortlisted/Day</td>";
            MsgBody = MsgBody + "<td style=' border: thin solid #56150C;font-size: 13px;font-weight: bold' align='center' width='100px' >QTD Calls to Line Up Ratio</td>";
            MsgBody = MsgBody + "<td style=' border: thin solid #56150C;font-size: 13px;font-weight: bold' align='center' >QTD Line Up to Interview Ratio</td>";
            MsgBody = MsgBody + "<td style=' border: thin solid #56150C;font-size: 13px;font-weight: bold' align='center'  >QTD Interview to Shortlisted Ratio</td>";
            MsgBody = MsgBody + "<td style=' border: thin solid #56150C;font-size: 13px;font-weight: bold' align='center' >QTD Interviewed to Hired Ratio</td>";
            MsgBody = MsgBody + "<td style=' border: thin solid #56150C;font-size: 13px;font-weight: bold' align='center' >QTD Hired to Joined Ratio</td>";
            MsgBody = MsgBody + "</tr>";




            dt = userbal.GetUserForWorksheet();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                int Userid = Convert.ToInt32(dt.Rows[i]["USR_ID"]);
                string name = dt.Rows[i]["USR_Name"].ToString();

                DataTable dts = new DataTable();
                RprtBal.Usr_Id = Userid;
                dts = RprtBal.GetDetailWorksheetForQTDMail();



                string QTDDayWorked = dts.Rows[0]["QTDWorkingDays"].ToString().Trim();
                string QTDCallsDay = dts.Rows[0]["QTDCallRatio"].ToString().Trim();
                string QTDLineupDay = dts.Rows[0]["QTDLinedRatio"].ToString().Trim();
                string QTDIntrviewDay = dts.Rows[0]["QTDInterviewedRatio"].ToString().Trim();
                string QTDShortlistDay = dts.Rows[0]["QTDShorlistedRatio"].ToString().Trim();

                string QTDCallsToLineup = dts.Rows[0]["QTDCallsToLineUp"].ToString().Trim();
                string QTDLineupTOInterview = dts.Rows[0]["QTDLineUptoInterview"].ToString().Trim();
                string QTDinterviewToShortlist = dts.Rows[0]["QTDInterviewToShortlist"].ToString().Trim();
                string QTDinterviewtoHire = dts.Rows[0]["QTDInterviewedToHired"].ToString().Trim();
                string QTDHiretoJoin = dts.Rows[0]["QTDHiredtoJoined"].ToString().Trim();

                MsgBody = MsgBody + "<tr>";
                MsgBody = MsgBody + "<td style=' border: thin solid #56150C' align='center'>" + name + "</td>";
                MsgBody = MsgBody + "<td style=' border: thin solid #56150C' align='center' >" + QTDDayWorked + "</td>";
                MsgBody = MsgBody + "<td style=' border: thin solid #56150C' align='center'>" + QTDCallsDay + "</td>";
                MsgBody = MsgBody + "<td style=' border: thin solid #56150C' align='center'>" + QTDLineupDay + "</td>";
                MsgBody = MsgBody + "<td style=' border: thin solid #56150C' align='center'>" + QTDIntrviewDay + "</td>";
                MsgBody = MsgBody + "<td style=' border: thin solid #56150C' align='center'>" + QTDShortlistDay + "</td>";


                MsgBody = MsgBody + "<td style=' border: thin solid #56150C' align='center'>" + QTDCallsToLineup + "%</td>";
                MsgBody = MsgBody + "<td style=' border: thin solid #56150C' align='center'>" + QTDLineupTOInterview + "%</td>";
                MsgBody = MsgBody + "<td style=' border: thin solid #56150C' align='center'>" + QTDinterviewToShortlist + "%</td>";
                MsgBody = MsgBody + "<td style=' border: thin solid #56150C' align='center'>" + QTDinterviewtoHire + "%</td>";
                MsgBody = MsgBody + "<td style=' border: thin solid #56150C' align='center'>" + QTDHiretoJoin + "%</td>";
                MsgBody = MsgBody + "</tr>";
            }
            MsgBody = MsgBody + "</table>";

            //-----New TAble----------//

            MsgBody = MsgBody + "<table style='width: 1000px;font-family: Vrinda;font-size: 13px;text-align: justify;border: thin solid #56150C;margin-left: 20px;margin-top: 20px; color: #56150C;cellspacinf:3;cellpadding:3;table-layout: auto; border-collapse: collapse; empty-cells: show;'>";

            MsgBody = MsgBody + "<tr style='color: #000000;'>";
            MsgBody = MsgBody + "<td style=' border: thin solid #56150C;font-size: 13px;font-weight: bold' align='center'>Consultant</td>";
            MsgBody = MsgBody + "<td style=' border: thin solid #56150C;font-size: 13px;font-weight: bold' align='center'>YTD Day Worked</td>";
            MsgBody = MsgBody + "<td style=' border: thin solid #56150C;font-size: 13px;font-weight: bold' align='center'>YTD Calls/Day</td>";
            MsgBody = MsgBody + "<td style=' border: thin solid #56150C;font-size: 13px;font-weight: bold' align='center'>YTD Lined Up/Day</td>";
            MsgBody = MsgBody + "<td style=' border: thin solid #56150C;font-size: 13px;font-weight: bold' align='center'>YTD Interviewed/Day</td>";
            MsgBody = MsgBody + "<td style=' border: thin solid #56150C;font-size: 13px;font-weight: bold' align='center'>YTD Shortlisted/Day</td>";
            MsgBody = MsgBody + "<td style=' border: thin solid #56150C;font-size: 13px;font-weight: bold' align='center' width='100px'>YTD Calls to Line Up Ratio</td>";
            MsgBody = MsgBody + "<td style=' border: thin solid #56150C;font-size: 13px;font-weight: bold' align='center'>YTD Line Up to Interview Ratio</td>";
            MsgBody = MsgBody + "<td style=' border: thin solid #56150C;font-size: 13px;font-weight: bold' align='center'>YTD Interview to Shortlisted Ratio</td>";
            MsgBody = MsgBody + "<td style=' border: thin solid #56150C;font-size: 13px;font-weight: bold' align='center'>YTD Interviewed to Hired Ratio</td>";
            MsgBody = MsgBody + "<td style=' border: thin solid #56150C;font-size: 13px;font-weight: bold' align='center'>YTD Hired to Joined Ratio</td>";
            MsgBody = MsgBody + "</tr>";




            dt = userbal.GetUserForWorksheet();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                int Userid = Convert.ToInt32(dt.Rows[i]["USR_ID"]);
                string name = dt.Rows[i]["USR_Name"].ToString();

                DataTable dts = new DataTable();
                RprtBal.Usr_Id = Userid;
                dts = RprtBal.GetDetailWorksheetForYTDMail();



                string YTDDayWorked = dts.Rows[0]["YTDWorkingDays"].ToString().Trim();
                string YTDCallsDay = dts.Rows[0]["YTDCallRatio"].ToString().Trim();
                string YTDLineupDay = dts.Rows[0]["YTDLinedRatio"].ToString().Trim();
                string YTDIntrviewDay = dts.Rows[0]["YTDInterviewedRatio"].ToString().Trim();
                string YTDShortlistDay = dts.Rows[0]["YTDShorlistedRatio"].ToString().Trim();

                string YTDCallsToLineup = dts.Rows[0]["YTDCallsToLineUp"].ToString().Trim();
                string YTDLineupTOInterview = dts.Rows[0]["YTDLineUptoInterview"].ToString().Trim();
                string YTDinterviewToShortlist = dts.Rows[0]["YTDInterviewToShortlist"].ToString().Trim();
                string YTDinterviewtoHire = dts.Rows[0]["YTDInterviewedToHired"].ToString().Trim();
                string YTDHiretoJoin = dts.Rows[0]["YTDHiredtoJoined"].ToString().Trim();

                MsgBody = MsgBody + "<tr>";
                MsgBody = MsgBody + "<td style=' border: thin solid #56150C' align='center'>" + name + "</td>";
                MsgBody = MsgBody + "<td style=' border: thin solid #56150C' align='center' >" + YTDDayWorked + "</td>";
                MsgBody = MsgBody + "<td style=' border: thin solid #56150C' align='center'>" + YTDCallsDay + "</td>";
                MsgBody = MsgBody + "<td style=' border: thin solid #56150C' align='center'>" + YTDLineupDay + "</td>";
                MsgBody = MsgBody + "<td style=' border: thin solid #56150C' align='center'>" + YTDIntrviewDay + "</td>";
                MsgBody = MsgBody + "<td style=' border: thin solid #56150C' align='center'>" + YTDShortlistDay + "</td>";


                MsgBody = MsgBody + "<td style=' border: thin solid #56150C' align='center'>" + YTDCallsToLineup + "%</td>";
                MsgBody = MsgBody + "<td style=' border: thin solid #56150C' align='center'>" + YTDLineupTOInterview + "%</td>";
                MsgBody = MsgBody + "<td style=' border: thin solid #56150C' align='center'>" + YTDinterviewToShortlist + "%</td>";
                MsgBody = MsgBody + "<td style=' border: thin solid #56150C' align='center'>" + YTDinterviewtoHire + "%</td>";
                MsgBody = MsgBody + "<td style=' border: thin solid #56150C' align='center'>" + YTDHiretoJoin + "%</td>";
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