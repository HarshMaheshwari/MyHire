using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using DailyWorkSummaryDALTableAdapters;
/// <summary>
/// Summary description for DailyWorkSummaryBAL
/// </summary>
public class DailyWorkSummaryBAL
{
    DailyWorkSummaryTableAdapter dws;
    MonthlyWorkSummaryTableAdapter Mws;
    ClientMonthlyWorkSummaryTableAdapter CMs;
    ClientOverallWorkSummaryTableAdapter COver;
    MonthlyWorkSummaryPerformanceTableAdapter MwPer;
    ClientMonthlyWorkSumPerformanceTableAdapter CMPer;

    #region  Properties
    private int _DailyWSId;
    private string _DDate;
    private string _MMonth;
    private string _MYear;
    private string _MonthYear;
    private int _UserId;
    private int _RequestedId;

    private string _CandidateStatus;


    private int _CondidateId;


    private int _CreatedBy;


    public int DailyWSId
    {
        get { return _DailyWSId; }
        set { _DailyWSId = value; }
    }
    public string DDate
    {
        get { return _DDate; }
        set { _DDate = value; }
    }
     public string MMonth
    {
        get { return _MMonth; }
        set { _MMonth = value; }
    }
     public string MYear
    {
        get { return _MYear; }
        set { _MYear = value; }
    }
     public string MonthYear
    {
        get { return _MonthYear; }
        set { _MonthYear = value; }
    }

    
    public int UserId
    {
        get { return _UserId; }
        set { _UserId = value; }
    }
    public int RequestedId
    {
        get { return _RequestedId; }
        set { _RequestedId = value; }
    }
    public string CandidateStatus
    {
        get { return _CandidateStatus; }
        set { _CandidateStatus = value; }
    }
    public int CondidateId
    {
        get { return _CondidateId; }
        set { _CondidateId = value; }
    }
    public int CreatedBy
    {
        get { return _CreatedBy; }
        set { _CreatedBy = value; }
    }
    #endregion
    #region  DailySummary

    public int IU_DailyWorkSummary()
    {
        dws = new DailyWorkSummaryTableAdapter();
        try
        {
            return Convert.ToInt32(dws.IU_DailyWorkSummary(_DDate, _CreatedBy));
        }
        finally
        {
            dws = null;

        }
    }
    public DataTable GetInsertDailySumry()
    {
        dws = new DailyWorkSummaryTableAdapter();

        try
        {
            return dws.GetInsertDailySumry();



        }
        finally { }
    }

    public DataTable GetDailyWorkSummary()
    {
        dws = new DailyWorkSummaryTableAdapter();

        try
        {
            return dws.GetDailyWorkSummary(_DDate);



        }
        finally { }
    }

    public DataTable GetCandidateStatus()
    {
        dws = new DailyWorkSummaryTableAdapter();

        try
        {
            return dws.GetCandidateStatus(_DDate);



        }
        finally { }
    }


    #endregion  DailySummary

    #region   Monthly Summary
    public int IU_MonthlyWorkSummary()
    {
        Mws = new MonthlyWorkSummaryTableAdapter();
        try
        {
            return Convert.ToInt32(Mws.IU_MonthlyWorkSummary(_MonthYear, _CreatedBy));
        }
        finally
        {
            Mws = null;

        }
    }


    public DataTable GetCandidateStatusForMWS()
    {
        Mws = new MonthlyWorkSummaryTableAdapter();

        try
        {
            return Mws.GetCandidateStatusForMWS(_MMonth, _MYear);
        }
        finally { }
    }

    #endregion



    #region   Client Monthly Work Summary
    public int IU_ClientMonthlyWorkSummary()
    {
        CMs = new ClientMonthlyWorkSummaryTableAdapter();
        try
        {
            return Convert.ToInt32(CMs.IU_ClientMonthlyWorkSummary(_MonthYear, _CreatedBy));
        }
        finally
        {
            CMs = null;

        }
    }


    public DataTable GetOverallStatusforCMWS()
    {
        CMs = new ClientMonthlyWorkSummaryTableAdapter();

        try
        {
            return CMs.GetOverallStatusforCMWS(_MMonth, _MYear);
        }
        finally { }
    }

    #endregion

    #region  Client Overall Work  Summary
    public int IU_ClientOverallWorkSummary()
    {
        COver = new ClientOverallWorkSummaryTableAdapter();
        try
        {
            return Convert.ToInt32(COver.IU_ClientOverallWorkSummary(_CreatedBy));
        }
        finally
        {
            COver = null;

        }
    }


    public DataTable GetOverallStatusforCOWS()
    {
        COver = new ClientOverallWorkSummaryTableAdapter();

        try
        {
            return COver.GetOverallStatusforCOWS();
        }
        finally { }
    }

    #endregion

    #region   Monthly Summary For Performance
    public int IU_MonthlyWorkSummaryPerformance()
    {
        MwPer = new MonthlyWorkSummaryPerformanceTableAdapter();
        try
        {
            return Convert.ToInt32(MwPer.IU_MonthlyWorkSummaryPerformance(_MonthYear, _CreatedBy));
        }
        finally
        {
            MwPer = null;

        }
    }


    public DataTable GetCandidateStatusForMWPer()
    {
        MwPer = new MonthlyWorkSummaryPerformanceTableAdapter();

        try
        {
            return MwPer.GetCandidateStatusForMWPer(_MMonth, _MYear);
        }
        finally { }
    }

    #endregion


    #region   Client Monthly Work Summary For Performance
    public int IU_ClientMonthlyWorkSumPerformance()
    {
        CMPer = new ClientMonthlyWorkSumPerformanceTableAdapter();
        try
        {
            return Convert.ToInt32(CMPer.IU_ClientMonthlyWorkSumPerformance(_MonthYear, _CreatedBy));
        }
        finally
        {
            CMPer = null;

        }
    }


    public DataTable GetCandidateStatusForClientMnthPer()
    {
        CMPer = new ClientMonthlyWorkSumPerformanceTableAdapter();

        try
        {
            return CMPer.GetCandidateStatusForClientMnthPer(_MMonth, _MYear);
        }
        finally { }
    }

    #endregion

}























