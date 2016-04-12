using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using HRegisterDALTableAdapters;
public class HRegisterBAL
{
    CandidateDetailTableAdapter Candidate;
    ReferrerDetailTableAdapter Ref;

    private int _RRCandidate_Id;
    private int _LoggedBy;
    private int _ConsultantId;
    private int _Status;
	public HRegisterBAL()
	{
		//
		// TODO: Add constructor logic here
		//
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


    #region--------------Recruitment----------------


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

    #endregion

    #region --------------Candidate------------

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
    private string _PicPath;
    private string _Passwrd;
    private string _NewPasswrd;
    private string _SourceKey;
    private string _GmailKey;
    private string _FacebookKey;
    private string _LinkedInKey;
    private string _TwitterKey;


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



    public string PicPath
    {
        get { return _PicPath; }
        set { _PicPath = value; }
    }


    public string Passwrd
    {
        get { return _Passwrd; }
        set { _Passwrd = value; }
    }

    public string NewPasswrd
    {
        get { return _NewPasswrd; }
        set { _NewPasswrd = value; }
    }

    public string GmailKey
    {
        get { return _GmailKey; }
        set { _GmailKey = value; }
    }
    public string FacebookKey
    {
        get { return _FacebookKey; }
        set { _FacebookKey = value; }
    }
    public string LinkedInKey
    {
        get { return _LinkedInKey; }
        set { _LinkedInKey = value; }
    }
    public string TwitterKey
    {
        get { return _TwitterKey; }
        set { _TwitterKey = value; }
    }






    public string SourceKey
    {
        get { return _SourceKey; }
        set { _SourceKey = value; }
    }

    public int InsertCandidate()
    {
        Candidate = new CandidateDetailTableAdapter();
        try
        {
            return Convert.ToInt32(Candidate.InsertCandidateLogin(_CandidateName, _Address, _Telephone, _MobileNo, _Dob, _Email, _WorkExp,
                _CurrentLocation, _PrefferedLocation, _CurrentEmployer, _CurrentDesignation, _AnnualSalary, _UgCourse, _PgCourse, _PostPgCourse, _Resume_Path,
                _AltEmail, _CandidateSource, _PAN_Number, _Passport_Number, _Issue_Date, _Issue_Location, _AdharCard_Number, _Industry,
                _Key_Skills, _Passwrd, _RPreviousCompany, _LinkedInProfile, _GmailKey, _LinkedInKey, _FacebookKey, _TwitterKey, _LoggedBy));

        }
        finally
        {
            Candidate = null;
        }
    }

    public DataTable CheckStudentEmailExists()
    {
        Candidate = new CandidateDetailTableAdapter();
        try
        {
            return Candidate.CheckStudentEmailExists(_Email);
        }
        finally
        {
            Candidate = null;
        }
    }


    public int ChangeCandidatePassword()
    {
        Candidate = new CandidateDetailTableAdapter();
        try
        {
            return Convert.ToInt32(Candidate.ChangeCandidatePassword(_CandidateId, _Passwrd, _NewPasswrd));

        }
        finally
        {
            Candidate = null;
        }
    }

    public void LinkOtherProfiles()
    {
        Candidate = new CandidateDetailTableAdapter();
        try
        {
            Candidate.LinkOtherProfiles(_SourceKey, _Source, _Email);

        }
        finally
        {
            Candidate = null;
        }
    }

    public void UploadPhoto()
    {
        Candidate = new CandidateDetailTableAdapter();
        try
        {
           // Candidate.UploadPhoto(_PicPath, _CandidateId);

        }
        finally
        {
            Candidate = null;
        }
    }

    public DataTable GetProfilePic()
    {
        Candidate = new CandidateDetailTableAdapter();
        try
        {
            return Candidate.GetProfilePic(_CandidateId);
        }
        finally
        {
            Candidate = null;
        }
    }


    public DataTable GetCandidateBasicDetails()
    {
        Candidate = new CandidateDetailTableAdapter();
        try
        {
            return Candidate.GetCandidateBasicDetails(_CandidateId);
        }
        finally
        {
            Candidate = null;
        }
    }

    public void UpdateEmailAndMobileNo()
    {
        Candidate = new CandidateDetailTableAdapter();
        try
        {
            Candidate.UpdateEmailAndMobileNo(_Email, _MobileNo, _CandidateId);

        }
        finally
        {
            Candidate = null;
        }
    }


    #endregion

    #region ------------------Referrer----------------

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


    public int InsertReferrer()
    {
        Ref = new ReferrerDetailTableAdapter();
        try
        {
            return Convert.ToInt32(Ref.InsertReferrer(_RefrerrerId, _ReferrerName, REmailId, RMobile, RDesignation, RLocation, RMaillingAdd, RCurrentCompany, RPreviousCompany, LinkedInProfile, _TotalExp, _Status, _Passwrd, _LoggedBy));

        }
        finally
        {
            Candidate = null;
        }
    }

    #endregion
}