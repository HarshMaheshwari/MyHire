using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using WS_MobileDALTableAdapters;
public class WS_MobileBAL
{
    FollowUpTableAdapter FollowBAL;

    #region
    private int _UserId;
    private int _FollowUpId;
    private int _RRCandidateId;
    private int _CandidateId;
    private string _RecruiterStatus;
    private string _SupervisorStatus;
    private string _CandidateStatus;
    private string _FollowBALStatus;
    private string _FollowRemarks;
    private string _FollowDate;
    private string _FollowTime;
    private string _FollowType;
    private int _FollowBy;
    private int _LoggedBy;
    private int _RequestId;

    private double _OfferedPrice;
    private string _PlannedDoj;
    private string _ActualDoj;
    private string _OfferDate;
    private int _USR_ID;

    public int USR_ID
    {
        get { return _USR_ID; }
        set { _USR_ID = value; }
    }


    public int UserId
    {
        get { return _UserId; }
        set { _UserId = value; }
    }
    public int FollowUpId
    {
        get { return _FollowUpId; }
        set { _FollowUpId = value; }
    }
    public int RRCandidateId
    {
        get { return _RRCandidateId; }
        set { _RRCandidateId = value; }
    }
    public int CandidateId
    {
        get { return _CandidateId; }
        set { _CandidateId = value; }
    }
    public string RecruiterStatus
    {
        get { return _RecruiterStatus; }
        set { _RecruiterStatus = value; }
    }
    public string SupervisorStatus
    {
        get { return _SupervisorStatus; }
        set { _SupervisorStatus = value; }
    }
    public string CandidateStatus
    {
        get { return _CandidateStatus; }
        set { _CandidateStatus = value; }
    }
    public string FollowBALStatus
    {
        get { return _FollowBALStatus; }
        set { _FollowBALStatus = value; }
    }
    public string FollowRemarks
    {
        get { return _FollowRemarks; }
        set { _FollowRemarks = value; }
    }
    public string FollowDate
    {
        get { return _FollowDate; }
        set { _FollowDate = value; }
    }
    public string FollowTime
    {
        get { return _FollowTime; }
        set { _FollowTime = value; }
    }
    public string FollowType
    {
        get { return _FollowType; }
        set { _FollowType = value; }
    }
    public int FollowBy
    {
        get { return _FollowBy; }
        set { _FollowBy = value; }
    }
    public int LoggedBy
    {
        get { return _LoggedBy; }
        set { _LoggedBy = value; }
    }

    public int RequestId
    {
        get { return _RequestId; }
        set { _RequestId = value; }
    }

    public double OfferedPrice
    {
        get { return _OfferedPrice; }
        set { _OfferedPrice = value; }
    }
    public string PlannedDoj
    {
        get { return _PlannedDoj; }
        set { _PlannedDoj = value; }
    }
    public String ActualDoj
    {
        get { return _ActualDoj; }
        set { _ActualDoj = value; }
    }
    public String OfferDate
    {
        get { return _OfferDate; }
        set { _OfferDate = value; }
    }

    //-------Methods--------------//


    public DataTable WS_GetMyInterview()
    {
        FollowBAL = new FollowUpTableAdapter();
        try
        {
            return FollowBAL.WS_GetMyInterview(_UserId, _USR_ID);
        }
        finally
        {
            FollowBAL = null;
        }
    }

    public DataTable WS_GetMyTodayPositions()
    {
        FollowBAL = new FollowUpTableAdapter();
        try
        {
            return FollowBAL.WS_GetMyTodayPositions(_UserId);
        }
        finally
        {
            FollowBAL = null;
        }
    }



    public DataTable WS_FollowUpForConsultant()
    {
        FollowBAL = new FollowUpTableAdapter();
        try
        {
            return FollowBAL.WSFollowUpForConsultant(_UserId);
        }
        finally
        {
            FollowBAL = null;
        }
    }
 
    #endregion

}