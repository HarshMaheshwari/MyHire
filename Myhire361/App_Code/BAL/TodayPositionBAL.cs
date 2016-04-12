using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using TodayPositionDALTableAdapters;


public class TodayPositionBAL
{

    UserClientRelationTableAdapter usrClRl;
    FollowUpTableAdapter foll;
    RecruitmentRequestTableAdapter Rr;
    #region
    private int _User_Id;
    private int _ClientID;
    private int _LoggedBy;
    private string _RelIdFul;
    private String _TodayPos;
    private int _ConsultantId;
    private int _Request_Id;

  
    private int _ToConsultantId;
    private string _RRCandidateStr;
    private string _CandidateIdStr;
    
     private int _ToClientID;
    private int _ToRequest_Id;
    public int ClientID
    {
        get { return _ClientID; }
        set { _ClientID = value; }
    }
    public int User_Id
    {
        get { return _User_Id; }
        set { _User_Id = value; }
    }
    public int LoggedBy
    {
        get { return _LoggedBy; }
        set { _LoggedBy = value; }
    }
    public string RelIdFul
    {
        get { return _RelIdFul; }
        set { _RelIdFul = value; }
    }
    public String TodayPos
    {
        get { return _TodayPos; }
        set { _TodayPos = value; }
    }
    public int ConsultantId
    {
        get { return _ConsultantId; }
        set { _ConsultantId = value; }
    }

     public int Request_Id
    {
        get { return _Request_Id; }
        set { _Request_Id = value; }
    }
    public int ToConsultantId
     {
         get { return _ToConsultantId; }
         set { _ToConsultantId = value; }
     }

   
     public string RRCandidateStr
     {
         get { return _RRCandidateStr; }
         set { _RRCandidateStr = value; }
     }
     public string CandidateIdStr
     {
         get { return _CandidateIdStr; }
         set { _CandidateIdStr = value; }
     }
     public int ToClientID
    {
        get { return _ToClientID; }
        set { _ToClientID = value; }
    }
     public int ToRequest_Id
    {
        get { return _ToRequest_Id; }
        set { _ToRequest_Id = value; }
    }
    
    #endregion

    public int Upd_TodayPosition()
    {
        usrClRl = new UserClientRelationTableAdapter();
        try
        {
            return Convert.ToInt32(usrClRl.Upd_TodayPosition(_RelIdFul, _TodayPos, _LoggedBy));
        }
        catch
        {
            throw;
        }
        finally
        {

        }
    }


    #region Transfer Of Consultants

    public DataTable GetRRNumberByClient()
    {
        foll = new FollowUpTableAdapter();
        try
        {
            return foll.GetRRNumberByClient(_ClientID);
        }
        catch
        {
            throw;
        }
        finally
        {
            foll = null;

        }
    }
    public DataTable GetRRnumberByfromClient()
    {
        foll = new FollowUpTableAdapter();
        try
        {
            return foll.GetRRnumberByfromClient(_ClientID);
        }
        catch
        {
            throw;
        }
        finally
        {
            foll = null;

        }
    }

    public DataTable GetConsultantByRRNo()
    {
         foll = new FollowUpTableAdapter();
        try
        {
            return foll.GetConsultantByRRNo(_Request_Id);
        }
        finally
        {
            foll = null;
        }
    }

    public DataTable GetActiveConsultantByRRNo()
    {
        foll = new FollowUpTableAdapter();
        try
        {
            return foll.GetActiveConsultantByRRNo(_Request_Id);
        }
        finally
        {
            foll = null;
        }
    }

    public DataTable GetConsultantByFromRRNo()
    {
        foll = new FollowUpTableAdapter();
        try
        {
            return foll.GetConsultantByFromRRNo(_Request_Id);
        }
        finally
        {
            foll = null;
        }
    }
    public int IU_TransferOfConsultant()
    {
        Rr = new RecruitmentRequestTableAdapter();
        try
        {
            return Convert.ToInt32(Rr.IU_TransferOfConsultant(_RRCandidateStr,_ClientID, _Request_Id, _ConsultantId,_ToConsultantId,_LoggedBy));
        }
        finally
        {
            Rr = null;
        }
    }

     public int IU_CopyOfCandidates()
    {
        Rr = new RecruitmentRequestTableAdapter();
        try
        {
            return Convert.ToInt32(Rr.IU_CopyOfCandidates(_CandidateIdStr, _ClientID, _Request_Id, _ConsultantId, _ToClientID, _ToRequest_Id, _ToConsultantId, _LoggedBy));
        }
        finally
        {
            Rr = null;
        }
    }

    
    
    

    #endregion

   

}