using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;
using System.IO;

public class SendSMS
{

    public void SendSMSToUser(string SmsTo, string SmsText, string SenderId="")
    {
        string strUrl = "http://enterprise.smsgupshup.com/GatewayAPI/rest?method=SendMessage&send_to=91" + SmsTo + "&msg=" + SmsText + "&msg_type=TEXT&userid=2000131529&auth_scheme=plain&password=9899703291&v=1.1&format=text&mask=SARALT";

      try
        {
            
            WebRequest request = HttpWebRequest.Create(strUrl);
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Stream s = (Stream)response.GetResponseStream();
            StreamReader readStream = new StreamReader(s);
            string dataString = readStream.ReadToEnd();
            response.Close();
            s.Close();
            readStream.Close();
        }
        finally
        {
            //http://enterprise.smsgupshup.com/GatewayAPI/rest?method=SendMessage&send_to=&msg=Dear 123, Thanks for downloading HOW customer application. Please use OTP 123 to activate the application.&msg_type=TEXT&userid=2000131529&auth_scheme=plain&password=9899703291&v=1.1&format=text
        }
    }
}