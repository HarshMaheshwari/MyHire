using System;
using System.Collections.Generic;
using System.Web;
using DashboardDALTableAdapters;
using System.Data;

public class DashboardBAL
{
    CandidateDetailTableAdapter Candidate;
    TodaysReportTableAdapter tdayRprt;
    FollowUpTableAdapter follow;
    FinancialReportTableAdapter finrep;
  
    private int _ConsultantId;

    public int ConsultantId
    {
        get { return _ConsultantId; }
        set { _ConsultantId = value; }
    }
    public int User_Role;

    //----------Candidate---------------//

    //public DataTable GetCandidateFollowDashboard()
    //{
    //    Candidate = new CandidateDetailTableAdapter();
    //    try
    //    {
    //        return Candidate.GetCandidateFollowDashboard(_ConsultantId);
    //    }
    //    finally
    //    {
    //        Candidate = null;
    //    }
    //}
  

    public int fin()
    {
        finrep = new FinancialReportTableAdapter();
        try
        {
            return Convert.ToInt32(finrep.fin());
        }
        finally
        {
            finrep = null;

        }
    }

    public DataTable getForFinanicalReport()
    {
        finrep = new FinancialReportTableAdapter();
        try
        {
            return finrep.getForFinancialReport();
        }
        finally
        {
            finrep = null;
        }

    }
    public DataTable TodaysInterview()
    {
        Candidate = new CandidateDetailTableAdapter();
        try
        {
            return Candidate.TodaysInterview(_ConsultantId);
        }
        finally
        {
            Candidate = null;
        }
    }


    public DataTable PendingApprovalDashboard()
    {
        Candidate = new CandidateDetailTableAdapter();
        try
        {
            return Candidate.PendingApprovalDashboard(_ConsultantId);
        }
        finally
        {
            Candidate = null;
        }
    }

    public DataTable SentPendingApprovalDashBoard()
    {
        Candidate = new CandidateDetailTableAdapter();
        try
        {
            return Candidate.SentPendingApprovalDashBoard(_ConsultantId);
        }
        finally
        {
            Candidate = null;
        }
    }

    public DataTable GetTodayReport()
    {
        tdayRprt = new TodaysReportTableAdapter();
        try
        {
            return tdayRprt.GetTodayReport(_ConsultantId);
        }
        finally
        {
            tdayRprt = null;
        }
    }

    public DataTable GetTestData()
    {
        Candidate = new CandidateDetailTableAdapter();
        try
        {
            return Candidate.GetTestData(_ConsultantId);
        }
        finally
        {
            Candidate = null;
        }
    }
    public DataTable StoredProcedure1forSpecific()
    {
        Candidate = new CandidateDetailTableAdapter();
        try
        {
            return Candidate.StoredProcedure1forSpecific(_ConsultantId,User_Role);
        }
        finally
        {
            Candidate = null;
        }
    }
    public DataTable ReferStatus()
    {
        Candidate = new CandidateDetailTableAdapter();
        try
        {
            return Candidate.ReferStatus(_ConsultantId);
        }
        finally
        {
            Candidate = null;
        }
    }
    public DataTable TodayPositionForSpecific()
    {
        Candidate = new CandidateDetailTableAdapter();
        try
        {
            return Candidate.TodayPositionForSpecific(_ConsultantId, User_Role);
        }
        finally
        {
            Candidate = null;
        }
    }
    public DataTable TodayFollowUpforDashboard()
    {
        Candidate = new CandidateDetailTableAdapter();
        try
        {
            return Candidate.TodayFollowUpforDashboard(_ConsultantId);
        }
        finally
        {
            Candidate = null;
        }
    }
    public DataTable TodayStatus()
    {
        follow = new FollowUpTableAdapter();
        try
        {
            return follow.TodayStatus(_ConsultantId);
        }
        finally
        {
            follow = null;
        }
    }
    public DataTable TodayStatusforSpecific()
    {
        follow = new FollowUpTableAdapter();
        try
        {
            return follow.TodayStatusforSpecific(_ConsultantId,User_Role);
        }
        finally
        {
            follow = null;
        }
    }
    public DataTable MonthlyStatus()
    {
        follow = new FollowUpTableAdapter();
        try
        {
            return follow.MonthlyStatus(_ConsultantId);
        }
        finally
        {
            follow = null;
        }
    }
    public DataTable MonthlyStatusforSpecific()
    {
        follow = new FollowUpTableAdapter();
        try
        {
            return follow.MonthlyStatusforSpecific(_ConsultantId,User_Role);
        }
        finally
        {
            follow = null;
        }
    }
    public DataTable TodayPosition()
    {
        Candidate = new CandidateDetailTableAdapter();
        try
        {
            return Candidate.TodayPosition(_ConsultantId);
        }
        finally
        {
            Candidate = null;
        }
    }
    public DataTable TodaysInterviewDashboardForTodayOnly()
    {
        Candidate = new CandidateDetailTableAdapter();
        try
        {
            return Candidate.TodaysInterviewDashboardForTodayOnly(_ConsultantId);
        }
        finally
        {
            Candidate = null;
        }
    }
    public DataTable TodaysInterviewDashboardForTodayOnlyforSpecific()
    {
        Candidate = new CandidateDetailTableAdapter();
        try
        {
            return Candidate.TodaysInterviewDashboardForTodayOnlyforSpecific(_ConsultantId, User_Role);
        }
        finally
        {
            Candidate = null;
        }
    }
   
}