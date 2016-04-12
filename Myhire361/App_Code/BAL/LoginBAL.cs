using System;
using System.Collections.Generic;
using System.Web;
using System.Data;
using LoginDALTableAdapters;
using System.Configuration;

public class LoginBAL
{
    UserDetailTableAdapter UsrMaster;
    UserRoleTableAdapter RoleMaster;
    UserClientRelationTableAdapter relation;
    LoginHistoryTableAdapter logHistory;
    RRCandidateStatusReportTableAdapter CandStats;



    //-----------------------Variables-------------------//

    private int _ReportingMgrId;
    private int _Role_Id;
    private int _Usr_Id;
    private string _Name;
    private string _Email;
    private string _Pswrd;
    private string _CurrentPassword;
    private int _Status;  
    private int _LoggedBy;

    private string _RoleCode;
    private string _Role;

    private int _Request_Id;
    private int _Relation_Id;
    private string _Assign_Date;
    public string USR_Mobile;

    //-------------------------Properties-------------------//
    public int ReportingMgrId
    {
        get { return _ReportingMgrId; }
        set { _ReportingMgrId = value; }
    }
    public int Role_Id
    {
        get { return _Role_Id; }
        set { _Role_Id = value; }
    }
    public int Usr_Id  
    {
        get { return _Usr_Id; }
        set { _Usr_Id = value; }
    }
    public string Name
    {
        get { return _Name; }
        set { _Name = value; }
    }   
    public string Email
    {
        get { return _Email; }
        set { _Email = value; } 
    }
    public string Pswrd
    {
        get { return _Pswrd; }
        set { _Pswrd = value; }
    }
    public string CurrentPassword
    {
        get { return _CurrentPassword; }
        set { _CurrentPassword = value; }
    }
    public int Status
    {
        get { return _Status; }
        set { _Status = value; }
    }
    public int LoggedBy
    {
        get { return _LoggedBy; }
        set { _LoggedBy = value; }
    }

    public  string RoleCode
    {
        get { return _RoleCode; }
        set { _RoleCode = value; }
    }
    public string Role
    {
        get { return _Role; }
        set { _Role = value; }
    }


    public int Request_Id
    {
        get { return _Request_Id; }
        set { _Request_Id = value; }
    }
    public int Relation_Id
    {
        get { return _Relation_Id; }
        set { _Relation_Id = value; }
    }
    public string Assign_Date
    {
        get { return _Assign_Date; }
        set { _Assign_Date = value; }
    }

    private int _RRCandStatusReportId;
    private string _Candidate_Status;

    public string Candidate_Status
    {
        get { return _Candidate_Status; }
        set { _Candidate_Status = value; }
    }
    public int RRCandStatusReportId
    {
        get { return _RRCandStatusReportId; }
        set { _RRCandStatusReportId = value; }
    }
    
//------USer Master----//
    #region

    public DataTable ValidateLogin()
    {
        UsrMaster = new UserDetailTableAdapter();
        try
        {
            return UsrMaster.ValidateLogin(_Email, _Pswrd);
        }
        finally
        {
            UsrMaster = null;
        }
    }
    public DataTable ForgotPassword()
    {
        UsrMaster = new UserDetailTableAdapter();
        try
        {
            return UsrMaster.ForgotPassword(_Email);
        }
        finally
        {
            UsrMaster = null;
        }
    }
    public int ChangePassword()
    {
       
        UsrMaster = new UserDetailTableAdapter();
        try
        {
           return Convert.ToInt32(UsrMaster.ChangePassword(_Usr_Id,_CurrentPassword,_Pswrd));           
        }
        finally
        {
            UsrMaster = null;          
        }
    }
   
    public DataTable GetUserList()
    {
        UsrMaster = new UserDetailTableAdapter();
        try
        {
           return UsrMaster.GetUserList();
        }
        finally
        {
            UsrMaster = null;
        }

    }




    public DataTable getuserlistformail()
    {
        UsrMaster = new UserDetailTableAdapter();
        try
        {
            return UsrMaster.getuserlistformail();
                    }
        finally
        {
            UsrMaster = null;
        }

    }
    public DataTable GetUserDetailById()
    {
        UsrMaster = new UserDetailTableAdapter();
        try
        {
            return UsrMaster.GetUserDetailById(_Usr_Id);
        }
        finally
        {
            UsrMaster = null;
        }

    }
    public DataTable FillUser()
    {
        UsrMaster = new UserDetailTableAdapter();
        try
        {
            return UsrMaster.FillUser();
        }
        finally
        {
            UsrMaster = null;
        }
    }
   

    
    public DataTable FillUserByUserId()
    {
        UsrMaster = new UserDetailTableAdapter();
        try
        {
            return UsrMaster.FillUserByUserId(_Usr_Id);
        }
        finally
        {
            UsrMaster = null;
        }
    }

    public DataTable GetConsultantNameDDL()
    {
        UsrMaster = new UserDetailTableAdapter();
        try
        {
            return UsrMaster.GetConsultantNameDDL();
        }
        finally
        {
            UsrMaster = null;
        }
    }

    public DataTable GetUserForWorksheet()
    {
        UsrMaster = new UserDetailTableAdapter();
        try
        {
            return UsrMaster.GetUserForWorksheet();
        }
        finally
        {
            UsrMaster = null;
        }

    }
   
    public DataTable FillConsultentUser()
    {
        UsrMaster = new UserDetailTableAdapter();
        try
        {
            return UsrMaster.FillConsultentUser();
        }
        finally
        {
            UsrMaster = null;
        }

    }
    public void ChangeUserStatus()
    {      
        UsrMaster = new UserDetailTableAdapter();
        try
        {
            UsrMaster.ChangeUserStatus(_Status, _LoggedBy,_Usr_Id);           
        }
        finally
        {
            UsrMaster = null;            
        }
    }

    public int InsertUpdateUser()
    {
        UsrMaster = new UserDetailTableAdapter();
        try
        {
            return Convert.ToInt32(UsrMaster.InsertUpdateUser(_Usr_Id, _Name, _Role_Id, _Pswrd, _Email, _ReportingMgrId, _LoggedBy, USR_Mobile));
        }
        finally
        {
            UsrMaster = null;
        }
    }



  

    public DataTable GetDirectorForSendMail()
    {
        UsrMaster = new UserDetailTableAdapter();
        try
        {
            return UsrMaster.GetDirectorForSendMail();
        }
        finally
        {
            UsrMaster = null;
        }

    }

    public DataTable GetConsultantIdForUnActed()
    {
        UsrMaster = new UserDetailTableAdapter();
        try
        {
            return UsrMaster.GetConsultantIdForUnActed();
        }
        finally
        {
            UsrMaster = null;
        }

    }
    public DataTable GetConsultantInfoByConsId()
    {
        UsrMaster = new UserDetailTableAdapter();
        try
        {
            return UsrMaster.GetConsultantInfoByConsId(_Usr_Id);
        }
        finally
        {
            UsrMaster = null;
        }

    }
    public DataTable GetReferdCandsForUnActed()
    {
        UsrMaster = new UserDetailTableAdapter();
        try
        {
            return UsrMaster.GetReferdCandsForUnActed(_Usr_Id);
        }
        finally
        {
            UsrMaster = null;
        }

    }
    public DataTable GetApprMgrForUnActed()
    {
        UsrMaster = new UserDetailTableAdapter();
        try
        {
            return UsrMaster.GetApprMgrForUnActed(_Usr_Id);
        }
        finally
        {
            UsrMaster = null;
        }

    }
     public DataTable GetRepMgrForUnActed()
    {
        UsrMaster = new UserDetailTableAdapter();
        try
        {
            return UsrMaster.GetRepMgrForUnActed(_Usr_Id);
        }
        finally
        {
            UsrMaster = null;
        }

    }

    

    
    #endregion

    //------USer Login History----//
    #region
    public DataTable GetLoginUser()
    {
        logHistory = new LoginHistoryTableAdapter();
        try
        {
            return logHistory.GetLoginUser();
        }
        finally
        {
            logHistory = null;
        }
    }
    public void UpdateLogOutTime()
    {
        logHistory = new LoginHistoryTableAdapter();
        try
        {
            logHistory.UpdateLogOutTime(_Usr_Id);
        }
        finally
        {
            logHistory = null;
        }
    }

    #endregion

    //-----Role Master----//
    #region

    public DataTable FillRole()
    {
        RoleMaster = new UserRoleTableAdapter();
        try
        {
            return RoleMaster.FillRole();
        }
        finally
        {
            RoleMaster = null;
        }

    }

    public DataTable GetRole()
    {
        RoleMaster = new UserRoleTableAdapter();
        try
        {
            return RoleMaster.GetRole();
        }
        finally
        {
            RoleMaster = null;
        }

    }

    public void ChangeRoleStatus()
    {
        RoleMaster = new UserRoleTableAdapter();
        try
        {
            RoleMaster.ChangeRoleStatus(_Status, _LoggedBy,_Role_Id);
        }
        finally
        {
            RoleMaster = null;
        }
    }

    public int InsertUpdateRole()
    {
        RoleMaster = new UserRoleTableAdapter();
        try
        {
           return Convert.ToInt32(RoleMaster.InsertUpdateRole(_Role_Id,_Role,_RoleCode,_LoggedBy));
        }
        finally
        {
            RoleMaster = null;
        }
    }

    #endregion

    //------User Client Relation----//
    #region

    public int InsertUpdateConsultantAssign()
    {
        relation = new UserClientRelationTableAdapter();
        try
        {
            return Convert.ToInt32(relation.InsertUpdateConsultantAssign(_Relation_Id,_Request_Id, _Usr_Id, _Assign_Date,_LoggedBy));
        }
        finally
        {
            relation = null;
        }
    }

    public void ChangeuserClientrelationStatus()
    {
        relation = new UserClientRelationTableAdapter();
        try
        {
            relation.ChangeuserClientrelationStatus(_Status, _LoggedBy,_Relation_Id);
        }
        finally
        {
            relation = null;
        }
    }

    public DataTable GetUserClientRelation()
    {
        relation = new UserClientRelationTableAdapter();
        try
        {
            return relation.GetUserClientRelation(_Request_Id);
        }
        finally
        {
            relation = null;
        }
    }
    public DataTable GetConsultantEmail()
    {
        relation = new UserClientRelationTableAdapter();
        try
        {
            return relation.GetConsultantEmail(_Request_Id);
        }
        finally
        {
            relation = null;
        }
    }



    #endregion

    public DataTable FillTeamLead()
    {
        UsrMaster = new UserDetailTableAdapter();
        try
        {
            return UsrMaster.FillTeamLead();
        }
        finally
        {
            UsrMaster = null;
        }
    }

    #region    Today Interview for cronjobs
    public DataTable GetTodayConstultant()
    {
        UsrMaster = new UserDetailTableAdapter();
        try
        {
            return UsrMaster.GetTodayConstultant();
        }
        finally
        {
            UsrMaster = null;
        }
    }
    public DataTable GetTodayCandByConsultant()
    {
        UsrMaster = new UserDetailTableAdapter();
        try
        {
            return UsrMaster.GetTodayCandByConsultant(_Usr_Id);
        }
        finally
        {
            UsrMaster = null;
        }
    }

    public DataTable GetTodayConsuntantDetail()
    {
        UsrMaster = new UserDetailTableAdapter();
        try
        {
            return UsrMaster.GetTodayConsuntantDetail(_Usr_Id);
        }
        finally
        {
            UsrMaster = null;
        }
    }

    #endregion    

    public int GetLoginCount()
    {
        logHistory = new LoginHistoryTableAdapter();
        try
        {
            return Convert.ToInt32(logHistory.GetLoginCount(_Usr_Id));
        }
        finally
        {
            logHistory = null;
        }
    }


    public DataTable CValidateLogin()
    {
        UsrMaster = new UserDetailTableAdapter();
        try
        {
            return UsrMaster.CValidateLogin(_Email, _Pswrd);
        }
        finally
        {
            UsrMaster = null;
        }
    }
    public DataTable CForgotPassword()
    {
        UsrMaster = new UserDetailTableAdapter();
        try
        {
            return UsrMaster.CForgotPassword(_Email);
        }
        finally
        {
            UsrMaster = null;
        }
    }



    public DataTable GetAttendanceDetails()
    {
        UsrMaster = new UserDetailTableAdapter();
        try
        {
            return UsrMaster.GetAttendanceDetails();
        }
        finally
        {
            UsrMaster = null;
        }

    }

    public DataTable GetCandidateStatusDDL()
    {
        CandStats = new RRCandidateStatusReportTableAdapter();
        try
        {
            return CandStats.GetCandidateStatusDDL();
        }
        finally
        {
            CandStats = null;
        }

    }
    public DataTable WS_ForgetPassword()
    {
        UsrMaster = new UserDetailTableAdapter();
        try
        {
            return UsrMaster.WS_ForgetPassword(_Email);
        }
        finally
        {
            UsrMaster = null;
        }
    }

}