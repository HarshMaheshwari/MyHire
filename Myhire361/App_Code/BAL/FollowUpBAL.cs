using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FollowUpDALTableAdapters;
using System.Data;
using System.Configuration;

public class FollowUpBAL
{
    FollowUpTableAdapter FollowBAL;
    ApproverStatusMasterTableAdapter approveBAL;
    CandidateStatusMasterTableAdapter canBAL;
    RecruiterStatusMasterTableAdapter recBAL;



    //---------Follow Up--------------//
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
    public int BillStatusId;
    public string BillingDate;
    public double BillingAmount;
    public double ServiceTax;
    public int PaymentStatusId;
    public string PaymentDueDate;
    public double ReceviedAmount;
    public string ReceviedDate;
    private int _Consultant_Id;
    private int _CreatedBy;

    public int CreatedBy
    {
        get { return _CreatedBy; }
        set { _CreatedBy = value; }
    }
    public int Consultant_Id
    {
        get { return _Consultant_Id; }
        set { _Consultant_Id = value; }
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

    public int CreateFollowUp()
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
    public DataTable GetFollowUpHistory()
    {
        FollowBAL = new FollowUpTableAdapter();
        try
        {
            return FollowBAL.GetFollowUpHistory(_RRCandidateId);
        }
        finally
        {
            FollowBAL = null;
        }
    }
    public DataTable GetOldFollowupByIdForMail()
    {
        FollowBAL = new FollowUpTableAdapter();
        try
        {
            return FollowBAL.GetOldFollowupByIdForMail(_UserId);
        }
        finally
        {
            FollowBAL = null;
        }
    }
    public DataTable GetTodaysFollowUpForMail()
    {
        FollowBAL = new FollowUpTableAdapter();
        try
        {
            return FollowBAL.GetTodaysFollowUpForMail();
        }
        finally
        {
            FollowBAL = null;
        }
    }
    public DataTable GetFollowUpForManager()
    {
        FollowBAL = new FollowUpTableAdapter();
        try
        {
            return FollowBAL.GetFollowUpForManager(_UserId);
        }
        finally
        {
            FollowBAL = null;
        }
    }
    public DataTable GetFollowUpForDirector()
    {
        FollowBAL = new FollowUpTableAdapter();
        try
        {
            return FollowBAL.GetFollowUpForDirector();
        }
        finally
        {
            FollowBAL = null;
        }
    }

    public DataTable GetActiveFollowUpByRRCanId()
    {
        FollowBAL = new FollowUpTableAdapter();
        try
        {
            return FollowBAL.GetActiveFollowUpByRRCanId(_RRCandidateId);
        }
        finally
        {
            FollowBAL = null;
        }
    }
    public DataTable GetFollowUpHistoryView()
    {
        FollowBAL = new FollowUpTableAdapter();
        try
        {
            return FollowBAL.GetFollowUpHistoryView(_FollowUpId);
        }
        finally
        {
            FollowBAL = null;
        }
    }

    public DataTable GetOverall_StatusByRRCnd()
    {
        FollowBAL = new FollowUpTableAdapter();
        try
        {
            return FollowBAL.GetOverall_StatusByRRCnd(_RRCandidateId);
        }
        finally
        {
            FollowBAL = null;
        }
    }

    public DataTable GetRRCandDetailByRRCId()
    {
        FollowBAL = new FollowUpTableAdapter();
        try
        {
            return FollowBAL.GetRRCandDetailByRRCId(_RRCandidateId);
        }
        finally
        {
            FollowBAL = null;
        }
    }

    
    #endregion

    //_____________________ Fill Drop down for Followup Screen//
    #region
    public DataTable FillRecruiterStatus()
    {
        recBAL = new RecruiterStatusMasterTableAdapter();
        try
        {
            return recBAL.FillRecruiterStatus();
        }
        finally
        {
            recBAL = null;
        }
    }
    public DataTable FillApproverStatus()
    {
        approveBAL = new ApproverStatusMasterTableAdapter();
        try
        {
            return approveBAL.FillApproverStatus();
        }
        finally
        {
            approveBAL = null;
        }
    }
    public DataTable FillCandidateStatus()
    {
        canBAL = new CandidateStatusMasterTableAdapter();
        try
        {
            return canBAL.FillCandidateStatus();
        }
        finally
        {
            canBAL = null;
        }
    }

    public DataTable FillOverallStatus()
    {
        canBAL = new CandidateStatusMasterTableAdapter();
        try
        {
            return canBAL.FillOverallStatus();
        }
        finally
        {
            canBAL = null;
        }
    }
#endregion


    //  Region for Next and SaveNext Button
    #region---

    RRCandidateRelationTableAdapter rrcnd;
    public DataTable GetReqIdByRRCnd()
    {
        rrcnd = new RRCandidateRelationTableAdapter();
        try
        {
            return rrcnd.GetReqIdByRRCnd(_RRCandidateId);
        }
        finally
        {
            rrcnd = null;
        }
    }

    public DataTable GetRRCndsByRequestId()
    {
        rrcnd = new RRCandidateRelationTableAdapter();
        try
        {
            return rrcnd.GetRRCndsByRequestId(_RequestId, _RRCandidateId);
        }
        finally
        {
            rrcnd = null;
        }
    }

    public int UpdateRRReferEmailSentdate()
    {
        rrcnd = new RRCandidateRelationTableAdapter();
        try
        {
            return Convert.ToInt32(rrcnd.UpdateRRReferEmailSentdate(_RRCandidateId));
        }
        finally
        {
            rrcnd = null;
        }
    }
    #endregion

    #region  Create followUp for CandidateOfferd
    public int CreateFollowUpForCandOfferd()
    {
        FollowBAL = new FollowUpTableAdapter();
        try
        {
            return Convert.ToInt32(FollowBAL.CreateFollowUpForCandOfferd(_RRCandidateId, _RecruiterStatus,
                _SupervisorStatus, _CandidateStatus, _FollowRemarks, _FollowDate, _FollowTime, _FollowType, _FollowBy, _OfferedPrice, _PlannedDoj, _ActualDoj, _OfferDate, _LoggedBy));
        }
        finally
        {
            FollowBAL = null;
        }
    }


    public int UpdateRRCandidate()
    {
        rrcnd = new RRCandidateRelationTableAdapter();
        try
        {
            return Convert.ToInt32(rrcnd.UpdateRRCandidate(_RRCandidateId, BillStatusId, BillingDate, BillingAmount, ServiceTax, PaymentStatusId, PaymentDueDate, ReceviedAmount, _LoggedBy));
        }
        finally
        {
            rrcnd = null;
        }
    }
    public int UpdateRRCandidatetobilled()
    {
        rrcnd = new RRCandidateRelationTableAdapter();
        try
        {
            return Convert.ToInt32(rrcnd.UpdateRRCandidatetobilled(_RRCandidateId, BillStatusId, BillingDate, BillingAmount, ServiceTax, PaymentStatusId, PaymentDueDate, ReceviedAmount,ReceviedDate, _LoggedBy));
        }
        finally
        {
            rrcnd = null;
        }
    }
    public int UpdateRRCandidte()
    {
        rrcnd = new RRCandidateRelationTableAdapter();
        try
        {
            return Convert.ToInt32(rrcnd.UpdateRRCandidte(_RRCandidateId, _OfferDate, _OfferedPrice, _PlannedDoj, _ActualDoj, _LoggedBy));
        }
        finally
        {
            rrcnd = null;
        }
    }
    #endregion

    private int _Request_Id;

    public int Request_Id
    {
        get { return _Request_Id; }
        set { _Request_Id = value; }
    }
    public DataTable CandidateDetail()
    {
        FollowBAL = new FollowUpTableAdapter();
        try
        {
            return FollowBAL.CandidateDetail(_Request_Id, _CreatedBy);
        }
        finally
        {
            FollowBAL = null;
        }
    }





    private int _RRCandidate_Id;
    private string _Recruiter_Status;
    private string _Supervisor_Status;
    private string _Candidate_Status;
    private int _FollowUp_By;
    private DateTime _CreationDate;

    public DateTime CreationDate
    {
        get { return _CreationDate; }
        set { _CreationDate = value; }
    }
  public int RRCandidate_Id
  {
      get { return _RRCandidate_Id; }
      set { _RRCandidate_Id = value; }
  }
  public string Recruiter_Status
  {
      get { return _Recruiter_Status; }
      set { _Recruiter_Status = value; }
  }
  public string Supervisor_Status
  {
      get { return _Supervisor_Status; }
      set { _Supervisor_Status = value; }
  }
  public string Candidate_Status
  {
      get { return _Candidate_Status; }
      set { _Candidate_Status = value; }
  }
  public int FollowUp_By
  {
      get { return _FollowUp_By; }
      set { _FollowUp_By = value; }
  }
    public DataTable Ws_UpdateFollowUpDetail()
    {
        FollowBAL = new FollowUpTableAdapter();
        try
        {
            return FollowBAL.Ws_UpdateFollowUpDetail(_RRCandidate_Id,_Recruiter_Status, _Supervisor_Status, _Candidate_Status, _FollowRemarks, _FollowDate, _FollowTime, _FollowType, _FollowUp_By, _OfferedPrice, _PlannedDoj, _ActualDoj, CreatedBy);
            }
        finally
        {
            FollowBAL = null;
        }
    }


    public int Ws_UpdateFollowUpDetailss()
    {
        FollowBAL = new FollowUpTableAdapter();
        try
        {
            return Convert.ToInt32(FollowBAL.Ws_UpdateFollowUpDetailss(_RRCandidate_Id,_Recruiter_Status,_Supervisor_Status,_Candidate_Status,_FollowRemarks,_FollowDate,_FollowDate,_FollowType,_FollowUp_By,_OfferedPrice,_PlannedDoj,_ActualDoj,_OfferDate,_CreatedBy));
        }
        finally
        {
            FollowBAL = null;
        }
    }
}