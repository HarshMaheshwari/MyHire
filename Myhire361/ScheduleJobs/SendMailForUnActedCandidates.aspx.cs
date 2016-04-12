using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Net.Mail;
public partial class SendMailForUnActedCandidates : System.Web.UI.Page
{
    ReportBAL RprtBal;
    LoginBAL userbal;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            SendMailForRefNIdenfiedCD();
        }
    }

    private void SendMailForRefNIdenfiedCD()
    {
       
        userbal = new LoginBAL();
        try
        {
            DataTable dtd = new DataTable();
           
            DataTable dtCnsId = new DataTable();
            dtCnsId = userbal.GetConsultantIdForUnActed();
            dtd = userbal.GetDirectorForSendMail();
            MailMessage msg = new MailMessage();
            SmtpClient smt = new SmtpClient();
            string MsgBody;
            msg.From = new MailAddress("rrteam@myhire361.com", "myhire361");


            for (int Ci = 0; Ci < dtCnsId.Rows.Count; Ci++)
            {
                #region  sending Mail
                DataTable dts = new DataTable();
                int User_Id =Convert.ToInt32(dtCnsId.Rows[Ci]["ConsultantId"].ToString());
                userbal.Usr_Id = User_Id;

                DataTable dtCnsEmail = new DataTable();
                dtCnsEmail = userbal.GetConsultantInfoByConsId();
                string ConsultantEmail = dtCnsEmail.Rows[0]["ConsultantEmail"].ToString();
                string ConsultantNm = dtCnsEmail.Rows[0]["ConsultantNm"].ToString();
                msg.To.Add(ConsultantEmail);
                dts = userbal.GetReferdCandsForUnActed();

                #region  ApprovingMgr
                DataTable dtAp = new DataTable();
                dtAp = userbal.GetApprMgrForUnActed();
               for (int k = 0; k < dtAp.Rows.Count; k++)
                {
                    string RRAppMgrEmail = dtAp.Rows[k]["RRAppMgrEmail"].ToString();
                    msg.CC.Add(RRAppMgrEmail);
                }

                DataTable dtRep = new DataTable();
                dtRep = userbal.GetRepMgrForUnActed();
                string RRRepMgrEmail = dtRep.Rows[0]["ReportingMgrEmail"].ToString();
                msg.CC.Add(RRRepMgrEmail);
                #endregion  ApprovingMgr

                msg.Subject = "Candidates referred but not acted by consultant.";
                MsgBody = "";
                MsgBody = MsgBody + "Dear "+ConsultantNm+" , " + "<BR><BR>";
                MsgBody = MsgBody + " Please find below the list of candidates who referred but no action has been taken by consultant till 30 minutes.Please review these candidates and take appropriate action." + "<BR><BR>";
                MsgBody = MsgBody + "<table style='width: 600px;font-family: Vrinda;font-size: 13px;text-align: justify;border: thin solid #56150C;margin-left: 20px;margin-top: 20px; color: #56150C;cellspacinf:3;cellpadding:3;table-layout: auto; border-collapse: collapse; empty-cells: show;'>";
                MsgBody = MsgBody + "<tr style='color: #000000;'>";
                MsgBody = MsgBody + "<td style=' border: thin solid #56150C'>RR-No</td>";
                MsgBody = MsgBody + "<td style=' border: thin solid #56150C'>Candidate Name</td>";
                MsgBody = MsgBody + "<td style=' border: thin solid #56150C'>Candidate Email Id</td>";
                MsgBody = MsgBody + "</tr>";
                for (int j = 0; j < dts.Rows.Count; j++)
                {
                    try
                    {

                        string RRNo = dts.Rows[j]["RRNumber"].ToString().Trim();
                        string Candidate = dts.Rows[j]["Candidate_Name"].ToString().Trim();
                        string CEmail = dts.Rows[j]["Email"].ToString().Trim();
                        MsgBody = MsgBody + "<tr>";
                        MsgBody = MsgBody + "<td style=' border: thin solid #56150C'>" + RRNo + "</td>";
                        MsgBody = MsgBody + "<td style=' border: thin solid #56150C'>" + Candidate + "</td>";
                        MsgBody = MsgBody + "<td style=' border: thin solid #56150C'>" + CEmail + "</td>";
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
                    try
                    {
                        smt.Send(msg);
                    }
                    catch (Exception ex) { }  finally  { }
                }
                #endregion

            }

         
            
        }
        finally
        {
            userbal = null;
            
        }
    }
}