using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Mail;
using System.Data;

public class SendMail
{

    MailMessage msg;
    SmtpClient smt;
    DataTable dt;
    string subject, mailBody;
    LoginBAL loginbal;
    EmailBAL Email;

    public void SendEmailWithoutTable(string CandidateName, string EmailAddress, string Triggerpoint, string ReffererName, string Position, string ConsultantDetails)
    {
        subject = "";
        mailBody = "";
        dt = new DataTable();
        try
        {

            dt = GetEmailTemplate(Triggerpoint);
            if (dt.Rows.Count > 0)
            {
                subject = dt.Rows[0]["EmailSubject"].ToString();
                mailBody = dt.Rows[0]["EmailBody"].ToString();


                mailBody.Replace("$CandidateName$", CandidateName);
                mailBody.Replace("$Refererr$", ReffererName);
                mailBody.Replace("$PositionName$", Position);
                mailBody.Replace("$ConsultantDetails$", ConsultantDetails);


                SendEmail(EmailAddress, subject, mailBody);

            }

        }
        catch (Exception ex)
        {
            throw;
        }
        finally
        {
        }
    }


    protected DataTable GetEmailTemplate(string TriggerPoint)
    {
        Email = new EmailBAL();
        try
        {
            Email.TriggerPoint = TriggerPoint;
            return Email.GetEmailTemplateByTrigger();
        }
        catch (Exception ex)
        {
            throw;
        }
        finally
        {
            Email = null;
        }
    }

    public void SendEmail(string EmailTo, string subject, string msgBody)
    {
        msg = new MailMessage();
        smt = new SmtpClient();
        try
        {
            msg.From = new MailAddress("query@indiahiring.org", "IndiaHiring");
            msg.To.Add(EmailTo);
            msg.Subject = subject;
            msg.Body = msgBody.Replace("\n", "<br>");
            msg.IsBodyHtml = true;
            smt.Host = "smtp.indiahiring.org";
            smt.Send(msg);
        }
        catch (Exception ex)
        {
            throw;
        }
        finally
        {
            msg = null;
            smt = null;
        }
    }


    public void CRForgotPassword(string Email, string Name, string Password)
    {
        subject = "";
        mailBody = "";
        try
        {
            subject = "India Hiring Password Recovery Email.";
            mailBody = "<b>Dear " + Name + " ,</b><br><br>";
            mailBody = mailBody + "Your India Hiring password is : " + Password + "<br>";
            mailBody = mailBody + "</br></br>";
            mailBody = mailBody + "Please login to India Hiring portal <br><br>";
            mailBody = mailBody + "<b>Url :</b> <a href='www.indiahiring.org'>www.indiahiring.org</a><br><br>";
            mailBody = mailBody + "<b><p>Thanks and Regards <p></b><br><br>";
            mailBody = mailBody + "<b>Team India Hiring</b><br>";
            SendEmail(Email, subject, mailBody);
        }
        catch (Exception ex)
        {
            throw;
        }
        finally
        {
        }
    }





    public void ForgotPassword(string Email, string Name, string Password)
    {
        subject = "";
        mailBody = "";
        try
        {
            subject = "RR-Tracker Password Recovery Email.";
            mailBody = "<b>Dear " + Name + " ,</b><br><br>";
            mailBody = mailBody + "Your RR-Tracker password is : " + Password + "<br>";
            mailBody = mailBody + "</br></br>";
            mailBody = mailBody + "Please login to RR-Tracker portal <br><br>";
            mailBody = mailBody + "<b>Url :</b> <a href='www.myhire361.com'>www.myhire361.com</a><br><br>";
            mailBody = mailBody + "<b><p>Thanks and Regards <p></b><br><br>";
            mailBody = mailBody + "<b>Team RR-Tracker</b><br>";
            string EmailCC = "";
            SendEmail(Email, EmailCC, subject, mailBody);
        }
        catch (Exception ex)
        {
            throw;
        }
        finally
        {
        }
    }

    public void NewRRCreation(string ClntMgrEmail, string AprvMgrEmail, string DirEmail, string ApprvMgrName, string ClntName, string Designation, string JobProfile)
    {
        subject = "";
        mailBody = "";
        try
        {
            subject = "New Recruitment Request Confirmation";
            mailBody = "<b>Dear " + ApprvMgrName + " ,</b><br><br>";
            mailBody = mailBody + "Your are assigned Approving Manager in a new RR <br>";
            mailBody = mailBody + "Client Name: "+ClntName+" <br>";
            mailBody = mailBody + "Designation: " + Designation + " <br>";
            mailBody = mailBody + "Job Profile: " + JobProfile + " <br>";
            mailBody = mailBody + "</br></br>";
            mailBody = mailBody + "Please login to RR-Tracker portal <br><br>";
            mailBody = mailBody + "<b>Url :</b> <a href='www.myhire361.com'>www.myhire361.com</a><br><br>";
            mailBody = mailBody + "<b><p>Thanks and Regards <p></b><br><br>";
            mailBody = mailBody + "<b>Team RR-Tracker</b><br>";
            string EmailCC = ClntMgrEmail + " ," + DirEmail;
            SendEmail(AprvMgrEmail, EmailCC, subject, mailBody);
        }
        catch (Exception ex)
        {
            throw;
        }
        finally
        {
        }
    }

    public void NewClient(string ClntMgrEmail, string DirEmail, string ClntMgrName, string ClntName)
    {
        subject = "";
        mailBody = "";
        try
        {
            subject = "New Client Added";
            mailBody = "<b>Dear " + ClntMgrName + " ,</b><br><br>";
            mailBody = mailBody + "Your are Assigned Client Manager For New Client: " + ClntName + "<br>";
            mailBody = mailBody + "</br></br>";
            mailBody = mailBody + "Please login to RR-Tracker portal <br><br>";
            mailBody = mailBody + "<b>Url :</b> <a href='www.myhire361.com'>www.myhire361.com</a><br><br>";
            mailBody = mailBody + "<b><p>Thanks and Regards <p></b><br><br>";
            mailBody = mailBody + "<b>Team RR-Tracker</b><br>";
            SendEmail(ClntMgrEmail, DirEmail, subject, mailBody);
        }
        catch (Exception ex)
        {
            throw;
        }
        finally
        {
        }
    }

    public void ConsultantAssign(string ClntMgrEmail, string AprvMgrEmail, string DirEmail, string CslntEmail, string CslntName, string ClntName, string RRNo, string Designation, string JobProfile)
    {
        loginbal = new LoginBAL();
        subject = "";
        mailBody = "";
        DataTable dtdir = new DataTable();
        dtdir = loginbal.GetDirectorForSendMail();
       

        try
        {
            subject = "Assigned New Reqruitment Request";
            mailBody = "<b>Dear " + CslntName + " ,</b><br><br>";
            mailBody = mailBody + "A new RR: "+RRNo+" is assigned to you <br>";
            mailBody = mailBody + "Client Name: " + ClntName + " <br>";
            mailBody = mailBody + "Designatio: " + Designation + " <br>";
            mailBody = mailBody + "Job Profile: " + JobProfile + " <br>";
            mailBody = mailBody + "</br></br>";
            mailBody = mailBody + "Please login to RR-Tracker portal <br><br>";
            mailBody = mailBody + "<b>Url :</b> <a href='www.myhire361.com'>www.myhire361.com</a><br><br>";
            mailBody = mailBody + "<b><p>Thanks and Regards <p></b><br><br>";
            mailBody = mailBody + "<b>Team RR-Tracker</b><br>";
        
            string EmailCC = ClntMgrEmail + " ," + AprvMgrEmail;
            for (int d = 0; d < dtdir.Rows.Count; d++)
            {
                 string DirectorEmail;
                 DirectorEmail = dtdir.Rows[d]["USR_Email"].ToString();
                 EmailCC = DirectorEmail + "," + EmailCC;
            }
          
           
            SendEmail(CslntEmail, EmailCC, subject, mailBody);
        }
        catch (Exception ex)
        {
            throw;
        }
        finally
        {
        }
    }

    public void SendVideoLink(string CandidateName, string CandidateEmail, string ConsultantEmail, int CandidateId, int RRCandidateId, string VideoName)
    {
        subject = "";
        mailBody = "";
        try
        {
            subject = "Video Interview Link";
            mailBody = "<b>Dear " + CandidateName + " ,</b><br><br>";
            mailBody = mailBody + "Please Click on below link for upload your video resume. <br>";
            mailBody = mailBody + "</br></br>";
            mailBody = mailBody + "<b>Url :</b> <a href='myhire361.com/Recruitment/NewCandidateVideo.aspx?CId=" + CandidateId + "&RRId=" + RRCandidateId + "&videoname=" + VideoName + "'>Click here to record Video.</a><br><br>";
            mailBody = mailBody + "<b><p>Thanks and Regards <p></b><br><br>";
            mailBody = mailBody + "<b>Team RR-Tracker</b><br>";
            SendEmail(CandidateEmail, ConsultantEmail, subject, mailBody);
        }
        catch (Exception ex)
        {
            throw;
        }
        finally
        {
        }
    }

    public void SendVideoLinkToClient(string CandidateName, string ClientEmail, string VideoName)
    {
        subject = "";
        mailBody = "";
        string EmailCC = "";
        try
        {
            subject = "Video Interview Link";
            mailBody = "<b>Dear,</b><br><br>";
            mailBody = mailBody + "Please Click on below link for Play video resume of <b>" + CandidateName + " </b><br>";
            mailBody = mailBody + "</br></br>";
            mailBody = mailBody + "<b>Url :</b> <a href='myhire361.com/Recruitment/PlayCandidateVideo.aspx?videoname=" + VideoName + "'>Click here to Play Video.</a><br><br>";
            mailBody = mailBody + "<b><p>Thanks and Regards <p></b><br><br>";
            mailBody = mailBody + "<b>Team RR-Tracker</b><br>";
            SendEmail(ClientEmail, EmailCC, subject, mailBody);
        }
        catch (Exception ex)
        {
            throw;
        }
        finally
        {
        }
    }
    
    public void SendEmail(string EmailTo, string EmailCC, string subject, string msgBody)
    {
        msg = new MailMessage();
        smt = new SmtpClient();
        try
        {
            msg.From = new MailAddress("rrteam@myhire361.com");
            msg.To.Add(EmailTo);
            if (EmailCC != "")
            {
                msg.CC.Add(EmailCC);
            }
            msg.Subject = subject;
            msg.Body = msgBody.Replace("\n", "<br>");
            msg.IsBodyHtml = true;
            smt.Host = "relay-hosting.secureserver.net";
            smt.Send(msg);
        }
        catch(Exception ex)
        {
            throw;
        }
        finally
        {
            msg = null;
            smt = null;
        }
    } 

}