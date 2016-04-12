using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Net.Mail;

public partial class ScheduleJobs_CronSendSMSTodayInterview : System.Web.UI.Page
{
    LoginBAL userbal;
    FollowUpBAL followup;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            SendSMSTodayInterview();
            SendMailForTodayFollowUp();
             
        }
    }



    protected void SendSMSTodayInterview()
    {
        userbal = new LoginBAL();
        DataTable dt = new DataTable();

        try
        {
            dt = userbal.GetTodayConstultant();
            for (int idx = 0; idx <= dt.Rows.Count; idx++)
            {
                userbal.Usr_Id = Convert.ToInt32(dt.Rows[idx]["ConsultantId"].ToString());
                DataTable dtCons = new DataTable();
                DataTable dtCd = new DataTable();
                dtCons = userbal.GetTodayConsuntantDetail();
                dtCd = userbal.GetTodayCandByConsultant();
                string ConsultantNm = "";
                string SmsTo = "";
                if (dtCons.Rows.Count > 0)
                {
                    ConsultantNm = dtCons.Rows[0]["Usr_Name"].ToString();
                    SmsTo = dtCons.Rows[0]["USR_Mobile"].ToString();
                }
                string strTotal, strCount; int Count;
                strTotal = "";
                Count = 1;
                String SmsText = "";

                for (int idy = 0; idy < dtCd.Rows.Count; idy++)
                {
                    int dtCount = dtCd.Rows.Count;
                    if (dtCount <= 5 && dtCount == 1)
                    {
                        strCount = Count + ". ";
                        Count = Count + 1;
                        strTotal = strTotal + strCount + dtCd.Rows[idy]["Client_Name"].ToString() + "," + dtCd.Rows[idy]["Candidate_Name"].ToString() + "," + dtCd.Rows[idy]["Mobile_No"].ToString() + "";
                        SmsText = "Dear " + ConsultantNm + ", Today Interviews: " + strTotal;
                    }
                    else if (dtCount <= 5 && dtCount == 2)
                    {
                        strCount = Count + ". ";
                        Count = Count + 1;
                        strTotal = strTotal + strCount + dtCd.Rows[idy]["Client_Name"].ToString() + "," + dtCd.Rows[idy]["Candidate_Name"].ToString() + "," + dtCd.Rows[idy]["Mobile_No"].ToString() + "";
                        SmsText = "Dear " + ConsultantNm + ", Today Interviews: " + strTotal;

                    }
                    else if (dtCount <= 5 && dtCount == 3)
                    {
                        strCount = Count + ". ";
                        Count = Count + 1;
                        strTotal = strTotal + strCount + dtCd.Rows[idy]["Client_Name"].ToString() + "," + dtCd.Rows[idy]["Candidate_Name"].ToString() + "," + dtCd.Rows[idy]["Mobile_No"].ToString() + " ";
                        SmsText = "Dear " + ConsultantNm + ", Today Interviews: " + strTotal;

                    }
                    else if (dtCount <= 5 && dtCount == 4)
                    {
                        strCount = Count + ". ";
                        Count = Count + 1;
                        strTotal = strTotal + strCount + dtCd.Rows[idy]["Client_Name"].ToString() + "," + dtCd.Rows[idy]["Candidate_Name"].ToString() + "," + dtCd.Rows[idy]["Mobile_No"].ToString() + " ";
                        SmsText = "Dear " + ConsultantNm + ", Today Interviews: " + strTotal;

                    }
                    else if (dtCount <= 5 && dtCount == 5)
                    {
                        strCount = Count + ". ";
                        Count = Count + 1;
                        strTotal = strTotal + strCount + dtCd.Rows[idy]["Client_Name"].ToString() + "," + dtCd.Rows[idy]["Candidate_Name"].ToString() + "," + dtCd.Rows[idy]["Mobile_No"].ToString() + " ";
                        SmsText = "Dear " + ConsultantNm + ", Today Interviews: " + strTotal;

                    }
                    else if (dtCount <= 6 && dtCount == 6)
                    {
                        strCount = Count + ". ";
                        Count = Count + 1;
                        strTotal = strTotal + strCount + dtCd.Rows[idy]["Client_Name"].ToString() + "," + dtCd.Rows[idy]["Candidate_Name"].ToString() + "," + dtCd.Rows[idy]["Mobile_No"].ToString() + " ";
                        SmsText = "Dear " + ConsultantNm + ", Today Interviews: " + strTotal;

                    }



                }
                String SenderId = "";
                SendSMS sms = new SendSMS();
                sms.SendSMSToUser(SmsTo, SmsText, SenderId);


            }



        }
        catch (Exception ex)
        { }
        finally { }
    }
    private void SendMailForTodayFollowUp()
    {
        followup = new FollowUpBAL();
        userbal = new LoginBAL();
        SmtpClient smt = new SmtpClient();
        string MsgBody="";
        DataTable dts = new DataTable();
        DataTable dt = new DataTable();
        try
        {
            dts = followup.GetTodaysFollowUpForMail();
            if (dts.Rows.Count > 0)
            {

               


                MsgBody = "";
                MsgBody = MsgBody + "Team, " + "<BR><BR>";
                MsgBody = MsgBody + " Please find below the list of  Today candidates follow up. Please review these followups and take appropriate action." + "<BR><BR>";


                MsgBody = MsgBody + "<table style='width: 600px;font-family: Vrinda;font-size: 13px;text-align: justify;border: thin solid #56150C;margin-left: 20px;margin-top: 20px; color: #56150C;cellspacinf:3;cellpadding:3;table-layout: auto; border-collapse: collapse; empty-cells: show;'>";

                MsgBody = MsgBody + "<tr style='color: #000000;'>";
                MsgBody = MsgBody + "<td style=' border: thin solid #56150C'>Client Name</td>";
                MsgBody = MsgBody + "<td style=' border: thin solid #56150C'>Consultant Name</td>";
                MsgBody = MsgBody + "<td style=' border: thin solid #56150C'> Mobile No</td>";
                MsgBody = MsgBody + "<td style=' border: thin solid #56150C'>RR-No</td>";
                MsgBody = MsgBody + "<td style=' border: thin solid #56150C'>Role</td>";
                MsgBody = MsgBody + "<td style=' border: thin solid #56150C'>Candidate Name</td>";
                MsgBody = MsgBody + "<td style=' border: thin solid #56150C'>Mobile No</td>";
                MsgBody = MsgBody + "</tr>";
                for (int j = 0; j < dts.Rows.Count; j++)
                {
                    try
                    {
                        string ClientName = dts.Rows[j]["Client_Name"].ToString().Trim();
                        string ConsultantName = dts.Rows[j]["ConsultantName"].ToString().Trim();
                        string ConsultantMobileNo = dts.Rows[j]["ConsultantMobileNo"].ToString().Trim();
                        string RRNumber = dts.Rows[j]["RRNumber"].ToString().Trim();
                        string Job_Profile = dts.Rows[j]["Job_Profile"].ToString().Trim();
                        string Candidate_Name = dts.Rows[j]["Candidate_Name"].ToString().Trim();
                        string Mobile_No = dts.Rows[j]["Mobile_No"].ToString().Trim();

                        MsgBody = MsgBody + "<tr>";
                        MsgBody = MsgBody + "<td style=' border: thin solid #56150C'>" + ClientName + "</td>";
                        MsgBody = MsgBody + "<td style=' border: thin solid #56150C'>" + ConsultantName + "</td>";
                        MsgBody = MsgBody + "<td style=' border: thin solid #56150C'>" + ConsultantMobileNo + "</td>";
                        MsgBody = MsgBody + "<td style=' border: thin solid #56150C'>" + RRNumber + "</td>";
                        MsgBody = MsgBody + "<td style=' border: thin solid #56150C'>" + Job_Profile + "</td>";
                        MsgBody = MsgBody + "<td style=' border: thin solid #56150C'>" + Candidate_Name + "</td>";
                        MsgBody = MsgBody + "<td style=' border: thin solid #56150C'>" + Mobile_No + "</td>";
                        MsgBody = MsgBody + "</tr>";
                    }
                    finally
                    {

                    }
                }

                MsgBody = MsgBody + "</table>";
            }


            dt = userbal.getuserlistformail();
            string Email = "";
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                 Email = Email + dt.Rows[i]["USR_Email"].ToString() + ",";
            }
            try
            {
                Email = Email.Remove(Email.Length - 1);
            }
            catch(Exception ex)
            {
                Email = "";
            }

            if (MsgBody != "")
            {

                MailMessage msg = new MailMessage();
                msg.From = new MailAddress("rrteam@myhire361.com", "myhire361");
                msg.To.Add(Email);
                msg.Body = MsgBody;//.Replace("@ConsultantName", name);
                msg.IsBodyHtml = true;
                smt.Host = "relay-hosting.secureserver.net";
                msg.Subject = "Today's Interview Scheduled Candidate List";
                smt.Send(msg);
            }
            else
            {

            }
        }
        finally
        {
            userbal = null;
            followup = null;
        }
    }
}
    

   

