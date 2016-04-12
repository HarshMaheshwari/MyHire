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
using RecruitmentDALTableAdapters;
using PositionDALTableAdapters;

[WebService(Namespace = "http://rrdev.com/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
// [System.Web.Script.Services.ScriptService]
public class WS_Candidate : System.Web.Services.WebService {

    int Client_Id, Usr_Id, LoggedBy, Status, RRCandidate_Id;
    FollowUpBAL FollowBAL;
    public WS_Candidate () {

    }



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

    [WebMethod(Description = "View Candidate Detail)")]
    public string WS_CandidateDetail(int RRCandidate_Id, int UserId)
    {
        FollowBAL = new FollowUpBAL();
        try
        {
            FollowBAL.RRCandidateId = RRCandidate_Id;
            FollowBAL.CreatedBy = UserId;
            DataTable dt = new DataTable();
            dt = FollowBAL.CandidateDetail();
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

    #region  --------Candidate
 
    CandidateDetailTableAdapter Candidate;
    [WebMethod(Description = "Insert Candidate into MyHire)")]
  
 public int WS_InsertCandidate(String _CandidateName, String _Address, String _Telephone, String _MobileNo, String _Dob, String _Email, String _WorkExp,
              String _CurrentLocation, String _PrefferedLocation, String _CurrentEmployer, String _CurrentDesignation, String _AnnualSalary, String _UgCourse, String _PgCourse, String _PostPgCourse, String _Resume_Path,
             String _AltEmail, String _CandidateSource, String _PAN_Number, String _Passport_Number, String _Issue_Date, String _Issue_Location, String _AdharCard_Number, String _Industry, String _Key_Skills, String _Passwrd, String _RPreviousCompany, String _LinkedInProfile)
    {
        Candidate = new CandidateDetailTableAdapter();
        try
        {

            return Convert.ToInt32(Candidate.InsertCandidate(_CandidateName, _Address, _Telephone, _MobileNo, _Dob, _Email, _WorkExp,
               _CurrentLocation, _PrefferedLocation, _CurrentEmployer, _CurrentDesignation, _AnnualSalary, _UgCourse, _PgCourse, _PostPgCourse, _Resume_Path,
               _AltEmail, _CandidateSource, _PAN_Number, _Passport_Number, _Issue_Date, _Issue_Location, _AdharCard_Number, _Industry, 1, _Key_Skills, _Passwrd, _RPreviousCompany,_LinkedInProfile , 0));
        }

        finally
        {
            Candidate = null;
        }

    }

    #endregion

    #region  --------RR-Trackers Jobs

    RecruitmentRequestTableAdapter RR;
    [WebMethod(Description = "Get RR-Trackers Jobs from MyHire)")]

    public DataTable  WS_GetRRJobForIndiaHiring()
    {

        RR = new RecruitmentRequestTableAdapter();
        try
        {
            return RR.GetRRJobForIndiaHiring();

        }
        finally
        {
            RR = null;
        }

    }


    
    [WebMethod(Description = "Get RR-Trackers Jobs by Request_id from MyHire )")]

    public DataTable WS_GetRRJobsbyRequestId(int _Request_Id)
    {
        RR = new RecruitmentRequestTableAdapter();
        try
        {
            return RR.GetRRJobsbyRequestId(_Request_Id);

        }
        finally
        {
            RR = null;
        }

    }


    RRCandidateRelationTableAdapter Rcnd;
    [WebMethod(Description = "Apply jobs )")]
    //public int WS_IH_ApplyJob(int _CandidateId, int _Request_Id, string _ReferStatus, int Refered, int _LoggedBy)
    //{
    //    Rcnd = new RRCandidateRelationTableAdapter();
    //    try
    //    {

    //        return Convert.ToInt32(Rcnd.IH_ApplyJob(_CandidateId, _Request_Id, _ReferStatus, Refered, _LoggedBy));
    //    }

    //    finally
    //    {
    //        Candidate = null;
    //    }

    //}
    public int WS_IH_ApplyJob(int _CandidateId, int _Request_Id, string _ReferStatus, String _Refere, int _ReferedBy, String _ShowName, int _LoggedBy)
    {
        Rcnd = new RRCandidateRelationTableAdapter();
        try
        {

            return Convert.ToInt32(Rcnd.IH_ApplyJob(_CandidateId, _Request_Id,_ReferStatus, _Refere, _ReferedBy, _ShowName, _LoggedBy));
        }

        finally
        {
            Candidate = null;
        }

    }



    [WebMethod(Description = "Refer jobs )")]
    public int WS_IH_ReferJob(int _CandidateId, int _Request_Id, string _ReferStatus, String _Refere, int _ReferedBy, String _ShowName, int _LoggedBy)
    {
        Rcnd = new RRCandidateRelationTableAdapter();
        try
        {

            return Convert.ToInt32(Rcnd.IH_ReferJob(_CandidateId, _Request_Id,_ReferStatus, _Refere, _ReferedBy, _ShowName, 0));
        }

        finally
        {
            Candidate = null;
        }

    }

    #endregion

    #region  --------Candidate for Refer


    [WebMethod(Description = "Insert Candidate into MyHire for Refer)")]

    public int WS_InsertCandidate_forRefer(String _CandidateName, String _Address, String _Telephone, String _MobileNo, String _Dob, String _Email, String _WorkExp,
                 String _CurrentLocation, String _PrefferedLocation, String _CurrentEmployer, String _CurrentDesignation, String _AnnualSalary, String _UgCourse, String _PgCourse, String _PostPgCourse, String _Resume_Path,
                String _AltEmail, String _CandidateSource, String _PAN_Number, String _Passport_Number, String _Issue_Date, String _Issue_Location, String _AdharCard_Number, String _Industry, String _Key_Skills, String _Passwrd, String _RPreviousCompany, String _LinkedInProfile, int _Refered)
    {
        Rcnd = new RRCandidateRelationTableAdapter();
        try
        {

            return Convert.ToInt32(Rcnd.InsertCandidate_forRefer(_CandidateName, _Address, _Telephone, _MobileNo, _Dob, _Email, _WorkExp,
               _CurrentLocation, _PrefferedLocation, _CurrentEmployer, _CurrentDesignation, _AnnualSalary, _UgCourse, _PgCourse, _PostPgCourse, _Resume_Path,
               _AltEmail, _CandidateSource, _PAN_Number, _Passport_Number, _Issue_Date, _Issue_Location, _AdharCard_Number, _Industry, 1, _Key_Skills, _Passwrd, _RPreviousCompany, _LinkedInProfile, _Refered, 0));
        }

        finally
        {
            Rcnd = null;
        }

    }


   

    #endregion
      
  
}
