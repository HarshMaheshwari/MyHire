using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using ReportDALTableAdapters;


public class ReportBAL
{

    

    //New Report
    RecruitmentReportTableAdapter recruitRprt;
    UserDetailTableAdapter usrdetail;
    ClientDetailTableAdapter clntdetail;

    //----RRCRprtMaster---//
    private int _Client_Id;
    private int _Usr_Id;
    private int _Consultant_Id;
    private int _Requset_id;
    private int _RRequest_Id;
    private string _FromDate;
    private string _ToDate;
  

    public int Client_Id
    {
        get { return _Client_Id; }
        set { _Client_Id = value; }
    }
    public int Usr_Id
    {
        get { return _Usr_Id; }
        set { _Usr_Id = value; }
    }
    public int Consultant_Id
    {
        get { return _Consultant_Id; }
        set { _Consultant_Id = value; }
    }
    public int Requset_id
    {
        get { return _Requset_id; }
        set { _Requset_id = value; }
    }
    public int RRequest_Id
    {
        get { return _RRequest_Id; }
        set { _RRequest_Id = value; }
    }
    public string FromDate
    {
        get { return _FromDate; }
        set { _FromDate = value; }
    }
    public string ToDate
    {
        get { return _ToDate; }
        set { _ToDate = value; }
    }
  
   
    //----Start Report---//
    public DataTable GetClientReport()
    {
        clntdetail = new ClientDetailTableAdapter();
        try
        {
            return clntdetail.GetClientReport();
        }
        finally
        {
            clntdetail = null;
        }
    }

    public DataTable GetClientReportForManager()
    {
        clntdetail = new ClientDetailTableAdapter();
        try
        {
            return clntdetail.GetClientReportForManager(_Usr_Id);
        }
        finally
        {
            clntdetail = null;
        }
    }

    public DataTable GetOfferedCandidate()
    {
        clntdetail = new ClientDetailTableAdapter();
        try
        {
            return clntdetail.GetOfferedCandidate();
        }
        finally
        {
            clntdetail = null;
        }
    }

    public DataTable GetRecruitmentReport()
    {
        recruitRprt = new RecruitmentReportTableAdapter();
        try
        {
            return recruitRprt.GetRecruitmentReport();
        }
        finally
        {
            recruitRprt = null;
        }
    }

    public DataTable GetRecruitmentReportForManager()
    {
        recruitRprt = new RecruitmentReportTableAdapter();
        try
        {
            return recruitRprt.GetRecruitmentReportForManager(_Usr_Id);
        }
        finally
        {
            recruitRprt = null;
        }
    }

    public DataTable GetConsultantReport()
    {
        usrdetail = new UserDetailTableAdapter();
        try
        {
            return usrdetail.GetConsultantReport();
        }
        finally
        {
            usrdetail = null;
        }
    }

    public DataTable GetConsultantWorksheet()
    {
        usrdetail = new UserDetailTableAdapter();
        try
        {
            return usrdetail.GetConsultantWorksheet(_Usr_Id, _FromDate, _ToDate);
        }
        finally
        {
            usrdetail = null;
        }
    }
    public DataTable GetDailyWorksheetForMail()
    {
        usrdetail = new UserDetailTableAdapter();
        try
        {
            return usrdetail.GetDailyWorksheetForMail(_Usr_Id);
        }
        finally
        {
            usrdetail = null;
        }
    }
    public DataTable GetDetailWorksheetForDailyMail()
    {
        usrdetail = new UserDetailTableAdapter();
        try
        {
            return usrdetail.GetDetailWorksheetForDailyMail(_Usr_Id);
        }
        finally
        {
            usrdetail = null;
        }
    }

    public DataTable GetWorksheetForQTDMail()
    {
        usrdetail = new UserDetailTableAdapter();
        try
        {
            return usrdetail.GetWorksheetForQTDMail(_Usr_Id);
        }
        finally
        {
            usrdetail = null;
        }
    }

    public DataTable GetDetailWorksheetForQTDMail()
    {
        usrdetail = new UserDetailTableAdapter();
        try
        {
            return usrdetail.GetDetailWorksheetForQTDMail(_Usr_Id);
        }
        finally
        {
            usrdetail = null;
        }
    }

    public DataTable GetDetailWorksheetForYTDMail()
    {
        usrdetail = new UserDetailTableAdapter();
        try
        {
            return usrdetail.GetDetailWorksheetForYTDMail(_Usr_Id);
        }
        finally
        {
            usrdetail = null;
        }
    }

    public DataTable GetConsultantReportForManager()
    {
        usrdetail = new UserDetailTableAdapter();
        try
        {
            return usrdetail.GetConsultantReportForManager(_Usr_Id);
        }
        finally
        {
            usrdetail = null;
        }
    }
    public DataTable GetConsultantReportForConsultant()
    {
        usrdetail = new UserDetailTableAdapter();
        try
        {
            return usrdetail.GetConsultantReportForConsultant(_Usr_Id);
        }
        finally
        {
            usrdetail = null;
        }
    }

    public DataTable GetClientStatusReport()
    {
        clntdetail = new ClientDetailTableAdapter();
        try
        {
            return clntdetail.GetClientStatusReport();
        }
        finally
        {
            clntdetail = null;
        }
    }

    public DataTable GetClientStatusReportForManager()
    {
        clntdetail = new ClientDetailTableAdapter();
        try
        {
            return clntdetail.GetClientStatusReportForManager(_Usr_Id);
        }
        finally
        {
            clntdetail = null;
        }
    }

    public DataTable GetCandidateStatusByClient()
    {
        clntdetail = new ClientDetailTableAdapter();
        try
        {
            return clntdetail.GetCandidateStatusByClient(_Client_Id,_FromDate,_ToDate);
        }
        finally
        {
            clntdetail = null;
        }
    }

    public DataTable GetPositionStatusReport()
    {
        clntdetail = new ClientDetailTableAdapter();
        try
        {
            return clntdetail.GetPositionStatusReport();
        }
        finally
        {
            clntdetail = null;
        }
    }

    public DataTable GetPositionStatusReportForManager()
    {
        clntdetail = new ClientDetailTableAdapter();
        try
        {
            return clntdetail.GetPositionStatusReportForManager(_Usr_Id);
        }
        finally
        {
            clntdetail = null;
        }
    }

    public DataTable GetCandidateStatusByPosition()
    {
        clntdetail = new ClientDetailTableAdapter();
        try
        {
            return clntdetail.GetCandidateStatusByPosition(_Client_Id, _Requset_id, _FromDate, _ToDate);
        }
        finally
        {
            clntdetail = null;
        }
    }

    public DataTable GetConsultantStatusReport()
    {
        usrdetail = new UserDetailTableAdapter();
        try
        {
            return usrdetail.GetConsultantStatusReport();
        }
        finally
        {
            usrdetail = null;
        }
    }

    public DataTable GetCandidateStatusByConsultant()
    {
        usrdetail = new UserDetailTableAdapter();
        try
        {
            return usrdetail.GetCandidateStatusByConsultant(_Usr_Id,_FromDate,_ToDate);
        }
        finally
        {
            usrdetail = null;
        }
    }


    public DataTable GetConsultantPerformance()
    {
        usrdetail = new UserDetailTableAdapter();
        try
        {
            return usrdetail.GetConsultantPerformance(_Usr_Id);
        }
        finally
        {
            usrdetail = null;
        }
    }

  
    public DataTable GetallUser()
    {
        usrdetail = new UserDetailTableAdapter();
        try
        {
            return usrdetail.GetallUser();
        }
        finally
        {
            usrdetail = null;
        }
    }

    public DataTable GetConsultantPerformanceOverAll()
    {
        usrdetail = new UserDetailTableAdapter();
        try
        {
            return usrdetail.GetConsultantPerformanceOverAll ();
        }
        finally
        {
            usrdetail = null;
        }
    }

    public DataTable GetConsultantPerformanceCurrentMnth()
    {
        usrdetail = new UserDetailTableAdapter();
        try
        {
            return usrdetail.GetConsultantPerformanceCurrentMnth ();
        }
        finally
        {
            usrdetail = null;
        }
    }

    private int _USR_ID;

    public int USR_ID
    {
        get { return _USR_ID; }
        set { _USR_ID = value; }
    }

    private int _USR_Role;

public int USR_Role
{
  get { return _USR_Role; }
  set { _USR_Role = value; }
}

   

 

    public DataTable GetCounsltatName()
    {
        usrdetail = new UserDetailTableAdapter();
        try
        {
            return usrdetail.GetCounsltatName();
        }
         finally
        {
            usrdetail = null;
        }
    }


}