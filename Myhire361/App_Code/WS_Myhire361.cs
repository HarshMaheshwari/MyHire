using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Net;
using System.Net.Mail;
using System.Web.Services;
using System.Security.Cryptography;
using System.Web.Script.Services;
using System.Data.SqlClient;
using System.Data;
using FollowUpDALTableAdapters;

[WebService(Namespace = "http://www.myhire361.com/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
// [System.Web.Script.Services.ScriptService]
public class WS_Myhire361 : System.Web.Services.WebService {
    LoginBAL UsrBAL;
    WS_MobileBAL WSBal;
    FollowUpBAL followup;
    FollowUpTableAdapter FollowBAL;
    DataTable dt = new DataTable();
    FollowUpBAL folowbal;

    public string GetDatatableToJson(DataTable dt)
    {
        System.Web.Script.Serialization.JavaScriptSerializer serializer = new System.Web.Script.Serialization.JavaScriptSerializer();
        serializer.MaxJsonLength = Int32.MaxValue;
        List<Dictionary<string, object>> rows = new List<Dictionary<string, object>>();
        Dictionary<string, object> row = null;
        foreach (DataRow dr in dt.Rows)
        {
            row = new Dictionary<string, object>();
            foreach (DataColumn col in dt.Columns)
            {
                row.Add(col.ColumnName.Trim(), dr[col]);
            }
            rows.Add(row);
        }
        return serializer.Serialize(rows);
    }
    public string base64Encode(string data)
    {
        try
        {
            byte[] encData_byte = new byte[data.Length];
            encData_byte = System.Text.Encoding.UTF8.GetBytes(data);
            string encodedData = Convert.ToBase64String(encData_byte);
            return encodedData;
        }
        catch (Exception e)
        {
            throw new Exception("Error in base64Encode" + e.Message);
        }
    }
    #region  -----Myhire361_Candidate Detail
    [WebMethod(Description = "View Candidate Detail)")]
    public string WS_CandidateDetail(int UserId, int Request_Id)
    {
        followup = new FollowUpBAL();
        try
        {
            followup.CreatedBy = UserId;
            followup.Request_Id = Request_Id;
        
            DataTable dt = new DataTable();
            dt = followup.CandidateDetail();
            if (dt.Rows.Count > 0)
            {
                return GetDatatableToJson(dt);
            }
            else
            {
                string str = "Invalid UserID.";
                return str;
            }
        }
        finally
        {
            FollowBAL = null;
        }
    }

    #endregion
    public string base64Decode(string data)
    {
        try
        {
            System.Text.UTF8Encoding encoder = new System.Text.UTF8Encoding();
            System.Text.Decoder utf8Decode = encoder.GetDecoder();

            byte[] todecode_byte = Convert.FromBase64String(data);
            int charCount = utf8Decode.GetCharCount(todecode_byte, 0, todecode_byte.Length);
            char[] decoded_char = new char[charCount];
            utf8Decode.GetChars(todecode_byte, 0, todecode_byte.Length, decoded_char, 0);
            string result = new String(decoded_char);
            return result;
        }
        catch (Exception e)
        {
            throw new Exception("Error in base64Decode" + e.Message);
        }
    }
    #region  -----Myhire361_Activate
    [WebMethod(Description = "Myhire361_Activate")]
    public string Myhire361_Activate(string EmailId, string Passwrd)
    {
        UsrBAL = new LoginBAL();
        try
        {
            UsrBAL.Email = EmailId;
            UsrBAL.Pswrd = Passwrd;
            DataTable dt = new DataTable();
            dt = UsrBAL.ValidateLogin();
            if (dt.Rows.Count > 0)
            {
                return GetDatatableToJson(dt);

            }
            else
            {
                string str = "Invalid Username or Password.";
                return str;

            }


            
        }
        finally
        {
            UsrBAL = null;
        }
    }
    #endregion
    #region  -----Myhire361_MyInterview
    [WebMethod(Description = "Myhire361_MyInterview")]
    public string WS_GetMyInterview(int  UserId)
    {
        WSBal = new WS_MobileBAL();
        try
        {
            WSBal.UserId = UserId;

            return GetDatatableToJson(WSBal.WS_GetMyInterview());
        }
        finally
        {
            WSBal = null;
        }
    }
    #endregion
    #region  -----Myhire361_TodayInterview
    [WebMethod(Description = "Myhire361_TodayInterview")]
    public string WS_GetTodayInterview(int UserId)
    {
        followup = new FollowUpBAL();
      //  WSBal = new WS_MobileBAL();
        try
        {
            followup.UserId = UserId;

            return GetDatatableToJson(followup.GetTodaysFollowUpForMail());
        }
        finally
        {
            followup = null;
        }
    }

    #endregion

    #region  -----Myhire361_MyTodayPositions
    [WebMethod(Description = "Myhire361_MyTodayPositions")]
    public string WS_GetMyTodayPositions(int UserId)
    {
        WSBal = new WS_MobileBAL();
        try
        {
            WSBal.UserId = UserId;

            return GetDatatableToJson(WSBal.WS_GetMyTodayPositions());
        }
        finally
        {
            WSBal = null;
        }
    }

    #endregion



    #region  -----Myhire361_MyFollowups
    [WebMethod(Description = "Myhire361_MyFollowups")]
    public string WS_GetMyMyFollowups(int UserId)
    {
        WSBal = new WS_MobileBAL();
        try
        {
            WSBal.UserId = UserId;

            return GetDatatableToJson(WSBal.WS_FollowUpForConsultant());
        }
        finally
        {
            WSBal = null;
        }
    }

    #endregion

    #region  --------insert my interview in MyHire361


    [WebMethod(Description = "insert my interview)")]

    public int WS_insertMyInterview(Int32 _RRCandidateId, String _RecruiterStatus, String _SupervisorStatus, String _CandidateStatus, String _FollowRemarks, String _FollowDate, String _FollowTime,
                 String _FollowType, int _FollowBy, float _OfferedPrice, String _PlannedDoj, String _ActualDoj, String _OfferDate, int _LoggedBy)
    {
       FollowBAL = new FollowUpTableAdapter();
        try
        {

            return Convert.ToInt32(FollowBAL.CreateFollowUp(_RRCandidateId, _RecruiterStatus,
                _SupervisorStatus, _CandidateStatus, _FollowRemarks, _FollowDate, _FollowTime, _FollowType, _FollowBy, _OfferedPrice, _PlannedDoj, _ActualDoj, _OfferDate, _LoggedBy));
        }

        finally
        {
            FollowBAL = null;
        }

    }




    #endregion

    #region  --------Update my CandidateDetail in MyHire361


    [WebMethod(Description = "UPDATE CandidateDetail)")]

    public int Ws_UpdateFollowUpDetailss(Int32 _RRCandidateId, String _RecruiterStatus, String _SupervisorStatus, String _CandidateStatus, String _FollowRemarks, String _FollowDate, String _FollowTime,
                 String _FollowType, int _FollowBy, float _OfferedPrice, String _PlannedDoj, String _ActualDoj, String _OfferDate, int _LoggedBy)
    {
        FollowBAL = new FollowUpTableAdapter();
        try
        {

            return Convert.ToInt32(FollowBAL.Ws_UpdateFollowUpDetailss(_RRCandidateId, _RecruiterStatus,
                _SupervisorStatus, _CandidateStatus, _FollowRemarks, _FollowDate, _FollowTime, _FollowType, _FollowBy, _OfferedPrice, _PlannedDoj, _ActualDoj, _OfferDate, _LoggedBy));
        }

        finally
        {
            FollowBAL = null;
        }

    }




    #endregion
    #region  -----Myhire361_ForgetPassword
    [WebMethod(Description = "Myhire361_ForgetPassword")]
    public string WS_ForgetPassword(string EmailId)
    {
        UsrBAL = new LoginBAL();
        try
        {
            UsrBAL.Email = EmailId;
            
            DataTable dt = new DataTable();
            dt = UsrBAL.WS_ForgetPassword();
            if (dt.Rows.Count > 0)
            {
                return GetDatatableToJson(dt);

            }
            else
            {
                string str = "Invalid Username or Password.";
                return str;

            }



        }
        finally
        {
            UsrBAL = null;
        }
    }
    #endregion
}
