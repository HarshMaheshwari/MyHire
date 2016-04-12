using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RecruitmentDALTableAdapters;
using System.Data;
using System.Configuration;

public class RecruitmentBAL
{
    RecruitmentRequestTableAdapter recruit;
    CandidateDetailTableAdapter Candidate;
    VideoQuestionTableAdapter video;

    DataTable dt;
    private int _RRCandidate_Id;
    private int _LoggedBy;
    private int _ConsultantId;
    private int _Status;

    private int _Que_Id;
    private string _Que_Type;
    private string _Que_Site;

    public string Que_Site
    {
        get { return _Que_Site; }
        set { _Que_Site = value; }
    }
    public string Que_Type
    {
        get { return _Que_Type; }
        set { _Que_Type = value; }
    }
    public int Que_Id
    {
        get { return _Que_Id; }
        set { _Que_Id = value; }
    }
   
    public int RRCandidate_Id
    {
        get { return _RRCandidate_Id; }
        set { _RRCandidate_Id = value; }
    }
    public int LoggedBy
    {
        get { return _LoggedBy; }
        set { _LoggedBy = value; }
    }
    public int ConsultantId
    {
        get { return _ConsultantId; }
        set { _ConsultantId = value; }
    }
    public int Status
    {
        get { return _Status; }
        set { _Status = value; }
    }

    //-------Recruitment------//
    #region
    private int _Request_Id;
    private string _RRNumber;
    private string _Job_Profile;
    private int _Client_Id;
    private int _Total_Position;
    private int _Request_By;
    private string _Recieve_Date;
    private string _Closer_Date;
    private int _Criticality;
    private int _RprtingMngrId;
    private string _Designation;
    private string _RSkills;
    private int _Location_Id;
    private double _Min_Salary;
    private double _Max_Salary;
    private double _Min_Experience;
    private double _Max_Experience;
    private string _Min_Qualification;
    private string _Preferred_Industry;
    private string _Request_Status;
    private string _JobFile_Path;

    private int _PositionType;
    private String _JobDescription;
    private String _PublishURL;
    public string PublishURL
    {
        get { return _PublishURL; }
        set { _PublishURL = value; }
    }
    public int Request_Id
    {
        get { return _Request_Id; }
        set { _Request_Id = value; }
    }
    public string RRNumber
    {
        get { return _RRNumber; }
        set { _RRNumber = value; }
    }
    public string Job_Profile
    {
        get { return _Job_Profile; }
        set { _Job_Profile = value; }
    }
    public int Client_Id
    {
        get { return _Client_Id; }
        set { _Client_Id = value; }
    }
    public int Total_Position
    {
        get { return _Total_Position; }
        set { _Total_Position = value; }
    }
    public int Request_By
    {
        get { return _Request_By; }
        set { _Request_By = value; }
    }
    public string Recieve_Date
    {
        get { return _Recieve_Date; }
        set { _Recieve_Date = value; }
    }
    public string Closer_Date
    {
        get { return _Closer_Date; }
        set { _Closer_Date = value; }
    }
    public int Criticality
    {
        get { return _Criticality; }
        set { _Criticality = value; }
    }
    public int RprtingMngrId
    {
        get { return _RprtingMngrId; }
        set { _RprtingMngrId = value; }
    }
    public string Designation
    {
        get { return _Designation; }
        set { _Designation = value; }
    }
    public int Location_Id
    {
        get { return _Location_Id; }
        set { _Location_Id = value; }
    }
    public double Min_Salary
    {
        get { return _Min_Salary; }
        set { _Min_Salary = value; }
    }
    public double Max_Salary
    {
        get { return _Max_Salary; }
        set { _Max_Salary = value; }
    }
    public double Min_Experience
    {
        get { return _Min_Experience; }
        set { _Min_Experience = value; }
    }
    public double Max_Experience
    {
        get { return _Max_Experience; }
        set { _Max_Experience = value; }
    }
    public string Min_Qualification
    {
        get { return _Min_Qualification; }
        set { _Min_Qualification = value; }
    }
    public string Preferred_Industry
    {
        get { return _Preferred_Industry; }
        set { _Preferred_Industry = value; }
    }
    public string RSkills
    {
        get { return _RSkills; }
        set { _RSkills = value; }
    }
    public string Request_Status
    {
        get { return _Request_Status; }
        set { _Request_Status = value; }
    }
    public string JobFile_Path
    {
        get { return _JobFile_Path; }
        set { _JobFile_Path = value; }
    }

    public int PositionType
    {
        get { return _PositionType; }
        set { _PositionType = value; }
    }
    public String JobDescription
    {
        get { return _JobDescription; }
        set { _JobDescription = value; }
    }
    private int _PublishStatus;
    public int PublishStatus
    {
        get { return _PublishStatus; }
        set { _PublishStatus = value; }
    }

    private String _FuntionalArea;
    public String FuntionalArea
    {
        get { return _FuntionalArea; }
        set { _FuntionalArea = value; }
    }

    private Double _ReferrerPts;
    public Double ReferrerPts
    {
        get { return _ReferrerPts; }
        set { _ReferrerPts = value; }
    }
    private int _FuntionalAreaId;
    public int FuntionalAreaId
    {
        get { return _FuntionalAreaId; }
        set { _FuntionalAreaId = value; }
    }
    private int _PIndustryId;
    public int PIndustryId
    {
        get { return _PIndustryId; }
        set { _PIndustryId = value; }
    }
    private int _IndustryId;
    public int IndustryId
    {
        get { return _IndustryId; }
        set { _IndustryId = value; }
    }

  
    //-------Methods--------------//

    public DataTable getRRNumberforDDL()
    {
        recruit = new RecruitmentRequestTableAdapter();
        try
        {
            return recruit.getRRNumberforDDL();
        }
        finally
        {
            recruit = null;
        }

    }

    public int UpdatePublishURL()
    {
        recruit = new RecruitmentRequestTableAdapter();
        try
        {
            return Convert.ToInt32(recruit.UpdatePublishURL(_PublishURL, _Request_Id));
        }
        finally
        {
            recruit = null;
        }
    }
    public int InsertUpdateRRRequest()
    {
        recruit = new RecruitmentRequestTableAdapter();
        try
        {
            return Convert.ToInt32(recruit.InsertUpdateRRRequest(_Request_Id, _RRNumber, _Job_Profile, _Client_Id, _Total_Position, _Request_By, _Recieve_Date, _Closer_Date, _RprtingMngrId, _Criticality, _Designation,
                  _Location_Id, _Min_Salary, _Max_Salary, _Min_Experience, _Max_Experience, _Min_Qualification, _RSkills, _Request_Status, _JobFile_Path, _PositionType, _JobDescription,
                  _PublishStatus, _ReferrerPts, _FuntionalAreaId, _PIndustryId, _IndustryId, _LoggedBy));
        }
        finally
        {
            recruit = null;
        }
    }
    public int InsertUpdateRRRequest1()
    {
        recruit = new RecruitmentRequestTableAdapter();
        try
        {
            return Convert.ToInt32(recruit.InsertUpdateRRRequest1(_Request_Id, _RRNumber, _Client_Id, _Total_Position, _Request_By, _Recieve_Date, _RprtingMngrId, _Designation,
                  _Location_Id, _Min_Salary, _Max_Salary, _Min_Experience, _Max_Experience, _RSkills,_Request_Status, _JobFile_Path,
                    _FuntionalAreaId, _LoggedBy));
        }
        finally
        {
            recruit = null;
        }
    }
    public DataTable GetRequestById()
    {
        recruit = new RecruitmentRequestTableAdapter();
        try
        {
            return recruit.GetRequestById(_Request_Id);
        }
        finally
        {
            recruit = null;
        }
    }
    public DataTable GetRequestByClientManager()
    {
        recruit = new RecruitmentRequestTableAdapter();
        try
        {
            return recruit.GetRequestByClientManager(_Client_Id);
        }
        finally
        {
            recruit = null;
        }
    }

    public DataTable GetRequestByClientContact()
    {
        recruit = new RecruitmentRequestTableAdapter();
        try
        {
            return recruit.GetRequestByClientContact(_Client_Id, _Email);
        }
        finally
        {
            recruit = null;
        }
    }

    public DataTable GetRequest()
    {
        recruit = new RecruitmentRequestTableAdapter();
        try
        {
            return recruit.GetRequest();
        }
        finally
        {
            recruit = null;
        }
    }

    public DataTable GetRequestByManager()
    {
        recruit = new RecruitmentRequestTableAdapter();
        try
        {
            return recruit.GetRequestByManager(_ConsultantId);
        }
        finally
        {
            recruit = null;
        }
    }

    public void ChangeRequestStatus()
    {
        recruit = new RecruitmentRequestTableAdapter();
        try
        {
            recruit.ChangeRequestStatus(_Status, _LoggedBy,_Request_Id);
        }
        finally
        {
            recruit = null;
        }
    }

    public int SelectRRNumber()
    {
        recruit = new RecruitmentRequestTableAdapter();
        try
        {
            return Convert.ToInt32(recruit.SelectRRNumber());
        }
        finally
        {
            recruit = null;
        }
    }

    public DataTable GetRequestForFollowUp()
    {
        recruit = new RecruitmentRequestTableAdapter();
        try
        {
            return recruit.GetRequestForFollowUp(_RRCandidate_Id);
        }
        finally
        {
            recruit = null;
        }
    }

    public DataTable GetRequestByConsultant()
    {
        recruit = new RecruitmentRequestTableAdapter();
        try
        {
            return recruit.GetRequestByConsultant(_ConsultantId);
        }
        finally
        {
            recruit = null;
        }
    }

    public DataTable GetRREmail()
    {
        recruit = new RecruitmentRequestTableAdapter();
        try
        {
            return recruit.GetRREmail(_Request_Id);
        }
        finally
        {
            recruit = null;
        }
    }


    public int UpdateRRJobs_RefPoint()
    {
        recruit = new RecruitmentRequestTableAdapter();
        try
        {
            return Convert.ToInt32(recruit.UpdateRRJobs_RefPoint(_Request_Id, ReferrerPts, _PublishStatus, _LoggedBy));
        }
        finally
        {
            recruit = null;
        }
    }

    public DataTable RRForPublishByReqId()
    {
        recruit = new RecruitmentRequestTableAdapter();
        try
        {
            return recruit.RRForPublishByReqId(_Request_Id);
        }
        finally
        {
            recruit = null;
        }
    }


  
    #endregion

    //-------Candidate-------//
    #region

    private int _CandidateId;
    private string _CandidateName;
    private string _ResumerId;
    private string _Address;
    private string _Telephone;
    private string _MobileNo;
    private string _Dob;
    private string _Email;
    private string _WorkExp;
    private string _Test;
    private string _ResumeTitle;
    private string _CurrentLocation;
    private string _PrefferedLocation;
    private string _CurrentEmployer;
    private string _CurrentDesignation;
    private string _AnnualSalary;
    private string _UgCourse;
    private string _PgCourse;
    private string _PostPgCourse;
    private string _LastActivationDate;
    private string _Resume_Path;

    private string _AltEmail;
    private string _CandidateSource;
    private string _PAN_Number;
    private string _Passport_Number;
    private string _Issue_Date;
    private string _Issue_Location;
    private string _AdharCard_Number;
    private string _Industry;


    private string _Functional_Area;
    private string _Specialization_Area;
    private string _Key_Skills;
    private string _Previous_Employer;
    private string _Emp_Level;
    private string _Specialization_Education1;
    private string _Specialization_Education2;
    private string _UG_Institute;
    private string _PG_Institute;
    private string _Gender;
    private string _Age;
    private string _Source;

    public int CandidateId
    {
        get { return _CandidateId; }
        set { _CandidateId = value; }
    }
    public string CandidateName
    {
        get { return _CandidateName; }
        set { _CandidateName = value; }
    }
    public string ResumerId
    {
        get { return _ResumerId; }
        set { _ResumerId = value; }
    }
    public string Address
    {
        get { return _Address; }
        set { _Address = value; }
    }
    public string Telephone
    {
        get { return _Telephone; }
        set { _Telephone = value; }
    }
    public string MobileNo
    {
        get { return _MobileNo; }
        set { _MobileNo = value; }
    }
    public string Dob
    {
        get { return _Dob; }
        set { _Dob = value; }
    }
    public string Email
    {
        get { return _Email; }
        set { _Email = value; }
    }
    public string WorkExp
    {
        get { return _WorkExp; }
        set { _WorkExp = value; }
    }
    public string Test
    {
        get { return _Test; }
        set { _Test = value; }
    }
    public string ResumeTitle
    {
        get { return _ResumeTitle; }
        set { _ResumeTitle = value; }
    }
    public string CurrentLocation
    {
        get { return _CurrentLocation; }
        set { _CurrentLocation = value; }
    }
    public string PrefferedLocation
    {
        get { return _PrefferedLocation; }
        set { _PrefferedLocation = value; }
    }
    public string CurrentEmployer
    {
        get { return _CurrentEmployer; }
        set { _CurrentEmployer = value; }
    }
    public string CurrentDesignation
    {
        get { return _CurrentDesignation; }
        set { _CurrentDesignation = value; }
    }
    public string AnnualSalary
    {
        get { return _AnnualSalary; }
        set { _AnnualSalary = value; }
    }
    public string UgCourse
    {
        get { return _UgCourse; }
        set { _UgCourse = value; }
    }
    public string PgCourse
    {
        get { return _PgCourse; }
        set { _PgCourse = value; }
    }
    public string PostPgCourse
    {
        get { return _PostPgCourse; }
        set { _PostPgCourse = value; }
    }
    public string LastActivationDate
    {
        get { return _LastActivationDate; }
        set { _LastActivationDate = value; }
    }
    public string Resume_Path
    {
        get { return _Resume_Path; }
        set { _Resume_Path = value; }
    }

    public string AltEmail
    {
        get { return _AltEmail; }
        set { _AltEmail = value; }
    }
    public string CandidateSource
    {
        get { return _CandidateSource; }
        set { _CandidateSource = value; }
    }
    public string PAN_Number
    {
        get { return _PAN_Number; }
        set { _PAN_Number = value; }
    }
    public string Passport_Number
    {
        get { return _Passport_Number; }
        set { _Passport_Number = value; }
    }
    public string Issue_Date
    {
        get { return _Issue_Date; }
        set { _Issue_Date = value; }
    }
    public string Issue_Location
    {
        get { return _Issue_Location; }
        set { _Issue_Location = value; }
    }
    public string AdharCard_Number
    {
        get { return _AdharCard_Number; }
        set { _AdharCard_Number = value; }
    }
    public string Industry
    {
        get { return _Industry; }
        set { _Industry = value; }
    }


    public string Functional_Area
    {
        get { return _Functional_Area; }
        set { _Functional_Area = value; }
    }
    public string Specialization_Area
    {
        get { return _Specialization_Area; }
        set { _Specialization_Area = value; }
    }
    public string Key_Skills
    {
        get { return _Key_Skills; }
        set { _Key_Skills = value; }
    }
    public string Previous_Employer
    {
        get { return _Previous_Employer; }
        set { _Previous_Employer = value; }
    }
    public string Emp_Level
    {
        get { return _Emp_Level; }
        set { _Emp_Level = value; }
    }
    public string Specialization_Education1
    {
        get { return _Specialization_Education1; }
        set { _Specialization_Education1 = value; }
    }
    public string Specialization_Education2
    {
        get { return _Specialization_Education2; }
        set { _Specialization_Education2 = value; }
    }
    public string UG_Institute
    {
        get { return _UG_Institute; }
        set { _UG_Institute = value; }
    }
    public string PG_Institute
    {
        get { return _PG_Institute; }
        set { _PG_Institute = value; }
    }
    public string Gender
    {
        get { return _Gender; }
        set { _Gender = value; }
    }
    public string Age
    {
        get { return _Age; }
        set { _Age = value; }
    }
    public string Source
    {
        get { return _Source; }
        set { _Source = value; }
    }

    private string _Passwrd;

    public string Passwrd
    {
        get { return _Passwrd; }
        set { _Passwrd = value; }
    }

    //-------Methods--------------//

    public string TotalExperience;
    public string RelevantExperience;


    public string CellNo;
    public string PrimarySkill;
    public string LastOrganisation;
    public string HighestEducation;
    public string InstituteName;
    public string LastDesignation;
    public string TeamSizeManaged;
    public string CurrentRMDesignation;

    public string CurrentFixed;
    public string CurrentVariable;
    public string CurrentOtherBenifits;
    public string ExpectedFixed;
    public string ExpectedCTC;
    public string ExpectedVariable;
    public string NoticePeriod;
    public string MinTimeToJoin;

    public string ReasonForLeaving;
    public string InterviewType;
    public string TentativeScheduleDate;
    public TimeSpan TentativeScheduleTime;

    public int UpdateCandidateforFollowups()
    {
        Candidate = new CandidateDetailTableAdapter();
        try
        {
            return Convert.ToInt32(Candidate.UpdateCandidateforFollowups(_CandidateName, _Address, _Telephone,
                _MobileNo, _Dob, _Email, _WorkExp, _Test, _CurrentLocation, _PrefferedLocation,
                _CurrentEmployer, _CurrentDesignation, _AnnualSalary, _UgCourse, _PgCourse,
                _PostPgCourse, _AltEmail, _CandidateSource, _PAN_Number, _Passport_Number, _Issue_Date,
                _Issue_Location, _AdharCard_Number, _Industry, _LoggedBy, _ResumeTitle,
                _LastActivationDate, _Resume_Path, _Functional_Area, _Specialization_Area, _Key_Skills,
                _Previous_Employer, _Emp_Level, _Specialization_Education1,
                _Specialization_Education2, _UG_Institute, _PG_Institute, _Gender, _Age, _Source, _TotalExp, RelevantExperience, CellNo, PrimarySkill, LastOrganisation, HighestEducation, InstituteName, LastDesignation, TeamSizeManaged, CurrentRMDesignation, CurrentFixed, CurrentVariable, CurrentOtherBenifits, ExpectedCTC, ExpectedFixed, ExpectedVariable, NoticePeriod, MinTimeToJoin, ReasonForLeaving, InterviewType, TentativeScheduleDate, Convert.ToString(TentativeScheduleTime), _CandidateId));
        }
        finally
        {
            Candidate = null;
        }
    }


    public int UploadCandidate()
    {
        Candidate = new CandidateDetailTableAdapter();
        try
        {
            return Convert.ToInt32(Candidate.UploadCandidate(_CandidateName, _ResumerId, _Address, _Telephone, _MobileNo, _Dob, _Email, _WorkExp, _Test, _ResumeTitle,
                _CurrentLocation, _PrefferedLocation, _CurrentEmployer, _CurrentDesignation, _AnnualSalary, _UgCourse, _PgCourse, _PostPgCourse, _LastActivationDate,
                _Resume_Path, _LoggedBy, _Request_Id, _ConsultantId, _Functional_Area, _Specialization_Area, _Key_Skills, _Previous_Employer, _Emp_Level, _Specialization_Education1,
                _Specialization_Education2, _UG_Institute, _PG_Institute, _Gender, _Age, _Source));

        }
        finally
        {
            Candidate = null;
        }
    }
    public DataTable TodayscandidateInserted()
    {
        Candidate = new CandidateDetailTableAdapter();
        try
        {
            return Candidate.TodayscandidateInserted();
        }
        finally
        {
            Candidate = null;
        }
    }

    public DataTable GetAllCandidates()
    {
        Candidate = new CandidateDetailTableAdapter();
        try
        {
            return Candidate.GetAllCandidate();
        }
        finally
        {
            Candidate = null;
        }
    }

    public DataTable GetAllCandidatesByConsltntID()
    {
        Candidate = new CandidateDetailTableAdapter();
        try
        {
            return Candidate.GetAllCandidatesByConsltntID(_ConsultantId);
        }
        finally
        {
            Candidate = null;
        }
    }

    public DataTable GetWorkListForConsultant()
    {
        Candidate = new CandidateDetailTableAdapter();
        try
        {
            return Candidate.GetWorkListForConsultant(_ConsultantId);
        }
        finally
        {
            Candidate = null;
        }
    }

    public DataTable GetWorkListForManager()
    {
        Candidate = new CandidateDetailTableAdapter();
        try
        {
            return Candidate.GetWorkListForManager(_ConsultantId);
        }
        finally
        {
            Candidate = null;
        }
    }

    public DataTable GetCandidateList()
    {
        Candidate = new CandidateDetailTableAdapter();
        try
        {
            return Candidate.GetCandidateList(_Request_Id);
        }
        finally
        {
            Candidate = null;
        }
    }
    public DataTable GetCandidateListForStatus()
    {
        Candidate = new CandidateDetailTableAdapter();
        try
        {
            return Candidate.GetCandidateListForStatus();
        }
        finally
        {
            Candidate = null;
        }
    }
    public DataTable getCandidatebyIdforFollowUp()
    {
        Candidate = new CandidateDetailTableAdapter();
        try
        {
            return Candidate.getCandidatebyIdforFollowUp(_CandidateId);
        }
        finally
        {
            Candidate = null;
        }
    }

    public DataTable GetCandidateDetailForLabel()
    {
        Candidate = new CandidateDetailTableAdapter();
        try
        {
            return Candidate.GetCandidateDetailForLabel(_RRCandidate_Id);
        }
        finally
        {
            Candidate = null;
        }
    }

    public DataTable GetCandidateById()
    {
        Candidate = new CandidateDetailTableAdapter();
        try
        {
            return Candidate.GetCandidateById(_CandidateId);
        }
        finally
        {
            Candidate = null;
        }
    }
    public DataTable GetCandidateForFollowUp()
    {
        Candidate = new CandidateDetailTableAdapter();
        try
        {
            return Candidate.GetCandidateForFollowUp(_RRCandidate_Id);
        }
        finally
        {
            Candidate = null;
        }
    }


    public DataTable GetCandidateListByConsultant()
    {
        Candidate = new CandidateDetailTableAdapter();
        try
        {
            return Candidate.GetCandidateListByConsultant(_Request_Id, _ConsultantId);
        }
        finally
        {
            Candidate = null;
        }
    }

    public void UpdateCandidateResume()
    {
        Candidate = new CandidateDetailTableAdapter();
        try
        {
            Candidate.UpdateCandidateResume(_Resume_Path, _LoggedBy,_CandidateId);
        }
        finally
        {
            Candidate = null;
        }
    }

    public void UpdateCandidateUrlNSorce()
    {
        Candidate = new CandidateDetailTableAdapter();
        try
        {
            Candidate.UpdateCandidateUrlNSorce(_CandidateId,_Resume_Path, _LoggedBy );
        }
        finally
        {
            Candidate = null;
        }
    }


    public int InsertRRCandidate()
    {
        Candidate = new CandidateDetailTableAdapter();
        try
        {
            return Convert.ToInt32(Candidate.InsertRRCandidate(_CandidateId, _LoggedBy, _Request_Id, _ConsultantId));

        }
        finally
        {
            Candidate = null;
        }
    }

    public int InsertCandidate()
    {
        Candidate = new CandidateDetailTableAdapter();
        try
        {
            return Convert.ToInt32(Candidate.InsertCandidate(_CandidateName, _Address, _Telephone, _MobileNo, _Dob, _Email, _WorkExp,
                _CurrentLocation, _PrefferedLocation, _CurrentEmployer, _CurrentDesignation, _AnnualSalary, _UgCourse, _PgCourse, _PostPgCourse, _Resume_Path,
                _AltEmail, _CandidateSource, _PAN_Number, _Passport_Number, _Issue_Date, _Issue_Location, _AdharCard_Number, _Industry, _Status, _Key_Skills, _Passwrd, _RPreviousCompany, _LinkedInProfile, _LoggedBy));

        }
        finally
        {
            Candidate = null;
        }
    }

    public int UpdateCandidate()
    {
        Candidate = new CandidateDetailTableAdapter();
        try
        {
            return Convert.ToInt32(Candidate.UpdateCandidate(_CandidateName, _Address, _Telephone,
                _MobileNo, _Dob, _Email, _WorkExp, _Test, _CurrentLocation, _PrefferedLocation,
                _CurrentEmployer, _CurrentDesignation, _AnnualSalary, _UgCourse, _PgCourse,
                _PostPgCourse, _AltEmail, _CandidateSource, _PAN_Number, _Passport_Number, _Issue_Date,
                _Issue_Location, _AdharCard_Number, _Industry, _LoggedBy,_ResumeTitle,
                _LastActivationDate, _Resume_Path, _Functional_Area, _Specialization_Area, _Key_Skills,
                _Previous_Employer, _Emp_Level, _Specialization_Education1,
                _Specialization_Education2, _UG_Institute, _PG_Institute, _Gender, _Age, _Source, _CandidateId));
        }
        finally
        {
            Candidate = null;
        }
    }

    public int GetMaxCandidate()
    {
        Candidate = new CandidateDetailTableAdapter();
        try
        {
            return Convert.ToInt32(Candidate.GetMaxCandidate());

        }
        finally
        {
            Candidate = null;
        }
    }

    public DataTable GetCandidateRRHistory()
    {
        Candidate = new CandidateDetailTableAdapter();
        try
        {
            return Candidate.GetCandidateRRHistory(_CandidateId);
        }
        finally
        {
            Candidate = null;
        }
    }


    public DataTable GetSourceforDDL()
    {
        Candidate = new CandidateDetailTableAdapter ();
        try
        {
            return Candidate.GetSourceforDDl();
        }
        finally
        {
            Candidate = null;
        }
    }
    #endregion



    #region   -----Referrer



    private int _RefrerrerId;
    public int RefrerrerId
    {
        get { return _RefrerrerId; }
        set { _RefrerrerId = value; }
    }

    private String _ReferrerName;
    public String ReferrerName
    {
        get { return _ReferrerName; }
        set { _ReferrerName = value; }
    }

    private String _REmailId;
    public String REmailId
    {
        get { return _REmailId; }
        set { _REmailId = value; }
    }
    private String _RMobile;
    public String RMobile
    {
        get { return _RMobile; }
        set { _RMobile = value; }
    }
    private String _RDesignation;
    public String RDesignation
    {
        get { return _RDesignation; }
        set { _RDesignation = value; }
    }
    private String _RLocation;
    public String RLocation
    {
        get { return _RLocation; }
        set { _RLocation = value; }

    }

    private String _RMaillingAdd;
    public String RMaillingAdd
    {
        get { return _RMaillingAdd; }
        set { _RMaillingAdd = value; }
    }

    private String _RCurrentCompany;
    public String RCurrentCompany
    {
        get { return _RCurrentCompany; }
        set { _RCurrentCompany = value; }
    }
    private String _RPreviousCompany;
    public String RPreviousCompany
    {
        get { return _RPreviousCompany; }
        set { _RPreviousCompany = value; }
    }
    private String _LinkedInProfile;
    public String LinkedInProfile
    {
        get { return _LinkedInProfile; }
        set { _LinkedInProfile = value; }
    }

    private String _TotalExp;
    public String TotalExp
    {
        get { return _TotalExp; }
        set { _TotalExp = value; }
    }


   public DataTable GetRRJobForIndiaHiring()
    {
        recruit = new RecruitmentRequestTableAdapter();
        try
        {
            return recruit.GetRRJobForIndiaHiring();
        }
        finally
        {
            recruit = null;
        }
    }

    public DataTable GetRRJobsbyRequestId()
    {
        recruit = new RecruitmentRequestTableAdapter();
        try
        {
            return recruit.GetRRJobsbyRequestId(_Request_Id);
        }
        finally
        {
            recruit = null;
        }
    }


    #endregion



    #region Referral Credit Points
    private int _RefCreditHdrId;
    private int _RefCreditDtlId;
    private Double _CreditedPoint;
    private Double _Credit;
    private Double _BalancePoint;

    public int RefCreditHdrId
    {
        get { return _RefCreditHdrId; }
        set { _RefCreditHdrId = value; }
    }
    public int RefCreditDtlId
    {
        get { return _RefCreditDtlId; }
        set { _RefCreditDtlId = value; }
    }
    public Double CreditedPoint
    {
        get { return _CreditedPoint; }
        set { _CreditedPoint = value; }
    }
    public Double BalancePoint
    {
        get { return _BalancePoint; }
        set { _BalancePoint = value; }
    }

    public Double Credit
    {
        get { return _Credit; }
        set { _Credit = value; }
    }
    public Double _TotalCreditPoint;
    public Double TotalCreditPoint
    {
        get { return _TotalCreditPoint; }
        set { _TotalCreditPoint = value; }
    }
    public string _Candidatestatus;
    public string Candidatestatus
    {
        get { return _Candidatestatus; }
        set { _Candidatestatus = value; }
    }
    

    RefCreditHdrTableAdapter crd;

    public int IU_RefCreditHdr()
    {
        crd = new RefCreditHdrTableAdapter();
        try
        {
            return Convert.ToInt32(crd.IU_RefCreditHdr(_CandidateId, _Request_Id, _RRCandidate_Id, _ReferrerPts, _LoggedBy));
        }
        finally
        {
            crd = null;
        }
    }


    public DataTable GetRefCreditHdrIdByRR()
    {
        crd = new RefCreditHdrTableAdapter();
        try
        {
            return crd.GetRefCreditHdrIdByRR(_CandidateId ,_RRCandidate_Id, _Request_Id, _LoggedBy);
        }
        finally
        {
            crd = null;
        }
    }

   


    RefCreditDtlTableAdapter rdl;

    public DataTable  IU_RefCreditDtl()
    {
        rdl = new RefCreditDtlTableAdapter();
        try
        {
            return rdl.IU_RefCreditDtl (_RefCreditHdrId,_RRCandidate_Id, _Credit,_Candidatestatus, _LoggedBy);
        }
        finally
        {
            rdl = null;
        }
    }


    public DataTable GetTotalCreditfrmDtl()
    {
        rdl = new RefCreditDtlTableAdapter();
        try
        {
            return rdl.GetTotalCreditfrmDtl(_RefCreditHdrId);
        }
        finally
        {
            rdl = null;
        }
    }

    public DataTable UpdateRefCreditHdr()
    {
        rdl = new RefCreditDtlTableAdapter();
        try
        {
            return rdl.UpdateRefCreditHdr(_RefCreditHdrId,_TotalCreditPoint, _LoggedBy);
        }
        finally
        {
            rdl = null;
        }
    }

    #endregion

    public DataTable GetVideoQuestion()
    {

        video = new VideoQuestionTableAdapter();
        dt = new DataTable();
        try
        {
            dt = video.GetVideoQuestion();
            return dt;
        }
        finally
        {
            dt = null;
        }
    }

}