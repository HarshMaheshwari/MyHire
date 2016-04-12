using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

public class WS_References
{ 
   
    #region  --------RR-JobRequest with publish
    AddressBAL AddBal;
     MasterBAL mstrBal;
     ClientBAL clntBal;
     RecruitmentBAL rectbal;

    public int WS_InsertUpdateRRRequest_IHUP(int _Request_Id, String _RRNumber, String _Job_Profile, int _Client_Id, int _Total_Position, int _Request_By, String _Recieve_Date, String _Closer_Date, int _RprtingMngrId, int _Criticality, String _Designation,
                 int _Location_Id, Double _Min_Salary, Double _Max_Salary, Double _Min_Experience, Double _Max_Experience, String _Min_Qualification, String _RSkills, String _Request_Status, String _JobFile_Path, int _PositionType, String _JobDescription, int _PublishStatus, Double _ReferrerPts, int _FuntionalAreaId, int _PIndustryId, int _IndustryId,
        String _Functional_Area, String _Preferred_Industry,DateTime _PublishDate, String _Industry,  int _LoggedBy)
    {
        var srvc = new RRdev_WS_Candidate.WS_CandidateSoapClient();
       
        try
        {
            string URL = srvc.WS_InsertUpdateRRRequest_IHUP(_Request_Id, _RRNumber, _Job_Profile, _Client_Id, _Total_Position, _Request_By, _Recieve_Date, _Closer_Date, _RprtingMngrId, _Criticality, _Designation,
                   _Location_Id, _Min_Salary, _Max_Salary, _Min_Experience, _Max_Experience, _Min_Qualification, _RSkills, _Request_Status, _JobFile_Path, _PositionType, _JobDescription, _PublishStatus
                   , _ReferrerPts, _FuntionalAreaId, _PIndustryId, _IndustryId, _Functional_Area, _Preferred_Industry, _PublishDate, _Industry, _LoggedBy);

            if (URL != "")
            {
                RecruitmentBAL rectbal = new RecruitmentBAL();
                rectbal.PublishURL = URL;
                rectbal.Request_Id = _Request_Id;
                rectbal.UpdatePublishURL();
                return 1;
            }
            else
            {
                return 0;
            }

        }

        finally
        {
            srvc = null;
        }

    }

    #endregion


    #region  --For RRJobs DoNotPublish

    public int WS_H_RRDoNotPublish(int _Request_Id, int _LoggedBy)
    {
        var srvc = new RRdev_WS_Candidate.WS_CandidateSoapClient();
        try
        {

            return Convert.ToInt32(srvc.WS_H_RRDoNotPublish(_Request_Id, _LoggedBy));
        }

        finally
        {
            srvc = null;
        }

    }


    #endregion

    #region   ---update overallStats

    public void UpdateJobStatus(String OverallSts, int RRCandidateId)
    {
        var srvc = new RRdev_WS_Candidate.WS_CandidateSoapClient();
        try
        {
            srvc.UpdateJobStatus(OverallSts, RRCandidateId);
        }
        finally { srvc = null; }
    }
    #endregion

    #region   ---Insert PointsCreditHistory
    public void InsertPointsCreditHistory(int CandidateId, int RRCandidateId, Double PointsCredit, DateTime CreditDate, int LoggedBy)
    {
        var srvc = new RRdev_WS_Candidate.WS_CandidateSoapClient();
        try
        {
            srvc.InsertPointsCreditHistory(CandidateId, RRCandidateId, PointsCredit, CreditDate, LoggedBy);
        }
        finally { srvc = null; }
    }


    #endregion

    #region -----Insert Update Master data
 
    public string WS_InsertState(int _Cntry_Id, string _ACode, string _State_Name, int _LoggedBy)
    {
        var srvc = new RRdev_WS_Candidate.WS_CandidateSoapClient();
        try
        {
            return srvc.WS_InsertState(_Cntry_Id, _ACode, _State_Name, _LoggedBy);
        }

        finally
        {
            srvc = null;
        }

       

    }
  
    public string WS_UpdateState(string _State_Name, string _ACode, int _Cntry_Id, int _LoggedBy, int _State_Id)
    {

        var srvc = new RRdev_WS_Candidate.WS_CandidateSoapClient();
        try
        {
            return srvc.WS_UpdateState(_State_Name, _ACode, _Cntry_Id, _LoggedBy, _State_Id);
        }

        finally
        {
            srvc = null;
        }

    }

    public string WS_InsertCity(int _State_Id, string _ACode, string _City_Name, int _LoggedBy)
    {
        var srvc = new RRdev_WS_Candidate.WS_CandidateSoapClient();
        try
        {
            return srvc.WS_InsertCity(_State_Id,_ACode, _City_Name, _LoggedBy);
        }

        finally
        {
            srvc = null;
        }

    }

    public string WS_UpdateCity(string _City_Name, string _ACode, int _State_Id, int _LoggedBy, int _City_Id)
    {
        var srvc = new RRdev_WS_Candidate.WS_CandidateSoapClient();
        try
        {
            return srvc.WS_UpdateCity(_City_Name, _ACode, _State_Id, _LoggedBy, _City_Id);
        }

        finally
        {
            srvc = null;
        }

    }



    public string WS_IU_FunctionaAreaDetail(int _FunctAreaId, string _Name, string _Remarks, int _LoggedBy)
    {
        var srvc = new RRdev_WS_Candidate.WS_CandidateSoapClient();
        try
        {
            return srvc.WS_IU_FunctionaAreaDetail(_FunctAreaId, _Name, _Remarks, _LoggedBy);
        }

        finally
        {
            srvc = null;
        }
    }


    public string WS_IU_IndustryMaster(int _IndustryId, string _Name, string _Remarks, int _LoggedBy)
    {
        var srvc = new RRdev_WS_Candidate.WS_CandidateSoapClient();
        try
        {
            return srvc.WS_IU_IndustryMaster(_IndustryId, _Name, _Remarks, _LoggedBy);
        }

        finally
        {
            srvc = null;
        }
    }


    public string WS_InsertUpdateClient(int _ClientId, string _Name, string _Code, int _CityId, string _Website, int _SmsAlert, int _EmailAlert, int _UserId, string _ClientSource, int _LoggedBy)
    {

        var srvc = new RRdev_WS_Candidate.WS_CandidateSoapClient();
        try
        {
            return srvc.WS_InsertUpdateClient(_ClientId,_Name,_Code,_CityId, _Website,_SmsAlert, _EmailAlert,_UserId,_ClientSource, _LoggedBy);
        }

        finally
        {
            srvc = null;
        }
    }



    public string WS_InsertUpdateContactPerson(int _PersonId, int _ClientId, string _PersonName, string _PersonContact, string _PersonEmail, string _PersonDob, string _PersonAnnvrsry, int _IsAdmin, int _LoggedBy)
    {
        var srvc = new RRdev_WS_Candidate.WS_CandidateSoapClient();
        try
        {
            return srvc.WS_InsertUpdateContactPerson(_PersonId, _ClientId, _PersonName, _PersonContact, _PersonEmail, _PersonDob, _PersonAnnvrsry, _IsAdmin, _LoggedBy);
        }

        finally
        {
            srvc = null;
        }
    }
    #endregion


}