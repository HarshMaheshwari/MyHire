using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using RecruiterDALTableAdapters;



public class RecruiterBAL
{
    RecruitmentRequestTableAdapter recruiter;
    RRCandidateRelationTableAdapter rrltn;
	public RecruiterBAL()
	{
		//
		// TODO: Add constructor logic here
		//
	}
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
    private string _Candidate_Status;

    public string Candidate_Status
    {
        get { return _Candidate_Status; }
        set { _Candidate_Status = value; }
    }
    private string _FollowUp_Remarks;

    public string FollowUp_Remarks
    {
        get { return _FollowUp_Remarks; }
        set { _FollowUp_Remarks = value; }
    }
    private string _FollowUp_Date;

    public string FollowUp_Date
    {
        get { return _FollowUp_Date; }
        set { _FollowUp_Date = value; }
    }
    private string _FollowUp_Type;

    public string FollowUp_Type
    {
        get { return _FollowUp_Type; }
        set { _FollowUp_Type = value; }
    }

    private int _CreatedBy;

    public int CreatedBy
    {
        get { return _CreatedBy; }
        set { _CreatedBy = value; }
    }

   


  
    public DataTable GetJDForRecruiter()
    {
        recruiter = new RecruitmentRequestTableAdapter();
        try
        {
            return recruiter.GetJDForRecruiter(_ConsultantId);
        }
        finally
        {
            recruiter = null;
        }
    }

    public DataTable GetRequestByRecruiter()
    {
        recruiter = new RecruitmentRequestTableAdapter();
        try
        {
            return recruiter.GetRequestByRecruiter(_Request_Id);
        }
        finally
        {
            recruiter = null;
        }
    }


    public DataTable BindCandidateRecruiter()
    {
        recruiter = new RecruitmentRequestTableAdapter();
        try
        {
            return recruiter.BindCandidateRecruiter(_Request_Id,_ConsultantId);
        }
        finally
        {
            recruiter = null;
        }
    }
    public DataTable GetCandidatesForJD()
    {
        recruiter = new RecruitmentRequestTableAdapter();
        try
        {
            return recruiter.GetCandidatesForJD(_ConsultantId, _Request_Id);
        }
        finally
        {
            recruiter = null;
        }
    }
    public DataTable GetCVSharedWithClientForJD()
    {
        recruiter = new RecruitmentRequestTableAdapter();
        try
        {
            return recruiter.GetCVSharedWithClientForJD(_ConsultantId, _Request_Id);
        }
        finally
        {
            recruiter = null;
        }
    }
    public DataTable GetFollowUpsForJD()
    {
        recruiter = new RecruitmentRequestTableAdapter();
        try
        {
            return recruiter.GetFollowUpsForJD(_ConsultantId, _Request_Id);
        }
        finally
        {
            recruiter = null;
        }
    }
    public DataTable GetInterviewPendingForJD()
    {
        recruiter = new RecruitmentRequestTableAdapter();
        try
        {
            return recruiter.GetInterviewPendingForJD(_ConsultantId, _Request_Id);
        }
        finally
        {
            recruiter = null;
        }
    }

    public DataTable GetInterviewForJD()
    {
        recruiter = new RecruitmentRequestTableAdapter();
        try
        {
            return recruiter.GetInterviewForJD(_ConsultantId, _Request_Id);
        }
        finally
        {
            recruiter = null;
        }
    }
    public DataTable GetOfferedForJD()
    {
        recruiter = new RecruitmentRequestTableAdapter();
        try
        {
            return recruiter.GetOfferedForJD(_ConsultantId, _Request_Id);
        }
        finally
        {
            recruiter = null;
        }
    }
    public DataTable GetInterviewSelectedForJD()
    {
        recruiter = new RecruitmentRequestTableAdapter();
        try
        {
            return recruiter.GetInterviewSelectedForJD(_ConsultantId, _Request_Id);
        }
        finally
        {
            recruiter = null;
        }
    }
    
    public DataTable AllForJD()
    {
        recruiter = new RecruitmentRequestTableAdapter();
        try
        {
            return recruiter.AllForJD(_ConsultantId, _Request_Id);
        }
        finally
        {
            recruiter = null;
        }
    }
    public int FollowUpHistoryForRecruiter()
    {
        recruiter = new RecruitmentRequestTableAdapter();
        try
        {
          return Convert.ToInt32(recruiter.FollowUpHistoryForRecruiter(_RRCandidate_Id, _Candidate_Status, _FollowUp_Remarks, _FollowUp_Date, _FollowUp_Type, _CreatedBy));
        }
        finally
        {
            recruiter = null;
        }
    }
    public DataTable GetFollowUpHistoryForRecruiter()
    {
        recruiter = new RecruitmentRequestTableAdapter();
        try
        {
            return recruiter.GetFollowUpHistoryForRecruiter(_RRCandidate_Id);
        }
        finally
        {
            recruiter = null;
        }
    }

    public DataTable GetCVSharedForJD()
    {
        recruiter = new RecruitmentRequestTableAdapter();
        try
        {
            return recruiter.GetCVSharedForJD(_ConsultantId, _Request_Id);
        }
        finally
        {
            recruiter = null;
        }
    }

    public DataTable GetRFollowUpsList()
    {
        rrltn = new RRCandidateRelationTableAdapter();
        try
        {
            return rrltn.GetRFollowUpsList(_ConsultantId);
        }
        finally
        {
            rrltn = null;
        }
    }
    public DataTable GetInterviewList()
    {
        rrltn = new RRCandidateRelationTableAdapter();
        try
        {
            return rrltn.GetInterviewList(_ConsultantId);
        }
        finally
        {
            rrltn = null;
        }
    }
    public DataTable GetAllSelectedForRecruiter()
    {
        rrltn = new RRCandidateRelationTableAdapter();
        try
        {
            return rrltn.GetAllSelectedForRecruiter(_ConsultantId);
        }
        finally
        {
            rrltn = null;
        }
    }
}
