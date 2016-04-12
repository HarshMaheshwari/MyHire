using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net.Mail;
using System.Data;

public partial class SendMailForOldFollowup : System.Web.UI.Page
{
    FollowUpBAL followup;
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
        followup = new FollowUpBAL();
        userbal = new LoginBAL();
        try
        {
            DataTable dt = new DataTable();
            dt = userbal.GetUserList();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                int Userid = Convert.ToInt32(dt.Rows[i]["USR_ID"]);
                string name = dt.Rows[i]["USR_Name"].ToString();
                string Email = dt.Rows[i]["USR_Email"].ToString();

                DataTable dts = new DataTable();
                followup.UserId = Userid;
                dts = followup.GetOldFollowupByIdForMail();
                MailMessage msg = new MailMessage();
                SmtpClient smt = new SmtpClient();
                string MsgBody;

                msg.From = new MailAddress("rrteam@myhire361.com", "myhire361");
                msg.To.Add(Email);
            
              //  msg.CC.Add("aseem.g@skopeconsultants.com");
            
                msg.Subject = "Candidate Followups Overdue till Yesterday.";


                MsgBody = "";
                MsgBody = MsgBody + "Dear " + name + " , " + "<BR><BR>";
                MsgBody = MsgBody + " Please find below the list of candidates follow up overdue till Yesterday.Please review these followups and take appropriate action." + "<BR><BR>";


                MsgBody = MsgBody + "<table style='width: 600px;font-family: Vrinda;font-size: 13px;text-align: justify;border: thin solid #56150C;margin-left: 20px;margin-top: 20px; color: #56150C;cellspacinf:3;cellpadding:3;table-layout: auto; border-collapse: collapse; empty-cells: show;'>";

                MsgBody = MsgBody + "<tr style='color: #000000;'>";
                MsgBody = MsgBody + "<td style=' border: thin solid #56150C'>Client Name</td>";
                MsgBody = MsgBody + "<td style=' border: thin solid #56150C'>RR-No</td>";
                MsgBody = MsgBody + "<td style=' border: thin solid #56150C'>Candidate Name</td>";
                MsgBody = MsgBody + "<td style=' border: thin solid #56150C'>FollowUp Date</td>";
                MsgBody = MsgBody + "<td style=' border: thin solid #56150C'>Recruiter Status</td>";
                MsgBody = MsgBody + "<td style=' border: thin solid #56150C'>Approver Status</td>";
                MsgBody = MsgBody + "<td style=' border: thin solid #56150C'>Candidate Status</td>";
                MsgBody = MsgBody + "</tr>";
                for (int j = 0; j < dts.Rows.Count; j++)
                {
                    try
                    {
                        string ClientName = dts.Rows[j]["Client_Name"].ToString().Trim();
                        string RRNo = dts.Rows[j]["RRNumber"].ToString().Trim();
                        string Candidate = dts.Rows[j]["Candidate_Name"].ToString().Trim();
                        string FollowupDate = dts.Rows[j]["FollowUp_Date"].ToString().Trim();
                        string RecruiterStatus = dts.Rows[j]["Recruiter_Status"].ToString().Trim();
                        string ApproverStatus = dts.Rows[j]["Supervisor_Status"].ToString().Trim();
                        string CandidateStatus = dts.Rows[j]["Candidate_Status"].ToString().Trim();

                        MsgBody = MsgBody + "<tr>";
                        MsgBody = MsgBody + "<td style=' border: thin solid #56150C'>" + ClientName + "</td>";
                        MsgBody = MsgBody + "<td style=' border: thin solid #56150C'>" + RRNo + "</td>";
                        MsgBody = MsgBody + "<td style=' border: thin solid #56150C'>" + Candidate + "</td>";
                        MsgBody = MsgBody + "<td style=' border: thin solid #56150C'>" + FollowupDate + "</td>";
                        MsgBody = MsgBody + "<td style=' border: thin solid #56150C'>" + RecruiterStatus + "</td>";
                        MsgBody = MsgBody + "<td style=' border: thin solid #56150C'>" + ApproverStatus + "</td>";
                        MsgBody = MsgBody + "<td style=' border: thin solid #56150C'>" + CandidateStatus + "</td>";
                        MsgBody = MsgBody + "</tr>";
                    }
                    finally
                    {

                    }
                }
                if (dts.Rows.Count > 0)
                {
                    MsgBody = MsgBody + "</table>";
                    msg.Body = MsgBody;
                    msg.IsBodyHtml = true;
                    smt.Host = "relay-hosting.secureserver.net";
                    smt.Send(msg);
                }
            }
        }
        finally
        {
            userbal = null;
            followup = null;
        }
    }
}