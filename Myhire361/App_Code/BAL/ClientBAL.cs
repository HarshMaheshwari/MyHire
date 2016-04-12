using System;
using System.Collections.Generic;
using System.Web;
using System.Data;
using ClientDALTableAdapters;
using System.Configuration;

public class ClientBAL
{
    ClientDetailTableAdapter ClntMaster;
    ClientContactPersonTableAdapter CntctPrsn;
    Client_AddressTableAdapter Adress;
    Client_ContractTableAdapter Contract;
    DocumentMasterTableAdapter docmstr;
    ClientDocumentsTableAdapter CDocs;
    ClientDepartmentTableAdapter Cdept;
    DataTable dt;



    private int _LoggedBy;
    private int _Status;
    public int LoggedBy
    {
        get { return _LoggedBy; }
        set { _LoggedBy = value; }
    }
    public int Status
    {
        get { return _Status; }
        set { _Status = value; }
    }



    //---------Client------------//
    #region
    //-----------------------Variables-------------------//
    private int _ClientId;
    private string _Name;
    private string _Code;
    private int _CityId;
    private byte[] _Logo;  
    private string _Website;
    private int _SmsAlert;
    private int _EmailAlert;
    private int _UserId;
    private String _ClientSource;
    private string _ClientHdrImg;
    private string _IndiaHiringLogo;

    //-------------------------Properties-------------------//
    public int ClientId
    {
        get { return _ClientId; }
        set { _ClientId = value; }
    }
    public string Name
    {
        get { return _Name; }
        set { _Name = value; }
    }
    public string Code
    {
        get { return _Code; }
        set { _Code = value; }
    }
    public int CityId
    {
        get { return _CityId; }
        set { _CityId = value; }
    }
    public byte[] Logo
    {
        get { return _Logo; }
        set { _Logo = value; }
    } 
    public string Website
    {
        get { return _Website; }
        set { _Website = value; }
    }
    public int SmsAlert
    {
        get { return _SmsAlert; }
        set { _SmsAlert = value; }
    }
    public int EmailAlert
    {
        get { return _EmailAlert; }
        set { _EmailAlert = value; }
    }
    public int UserId
    {
        get { return _UserId; }
        set { _UserId = value; }
    }

  

    public String  ClientSource
    {
        get { return _ClientSource; }
        set { _ClientSource = value; }
    }
    public String ClientHdrImg
    {
        get { return _ClientHdrImg; }
        set { _ClientHdrImg = value; }
    }
    public String IndiaHiringLogo
    {
        get { return _IndiaHiringLogo; }
        set { _IndiaHiringLogo = value; }
    }
    
    
    //-----------------------------------Methods------------------------//

    public int InsertUpdateClient()
    {
        ClntMaster = new ClientDetailTableAdapter();
        try
        {
            return Convert.ToInt32(ClntMaster.InsertUpdateClient(_ClientId, _Name, _Code, _CityId, _Website, _SmsAlert, _EmailAlert, _UserId, _ClientSource, _LoggedBy));
        }
        finally
        {
            ClntMaster = null;
        }
    }

    public void Upd_ClientLogo()
    {
        ClntMaster = new ClientDetailTableAdapter();
        try
        {
            ClntMaster.Upd_ClientLogo(_ClientId, _ClientHdrImg,_IndiaHiringLogo, _LoggedBy);
        }
        finally
        {
            ClntMaster = null;
        }
    }

    public void UpdateClientLogo()
    {
        ClntMaster = new ClientDetailTableAdapter();
        try
        {
            ClntMaster.UpdateClientLogo(_Logo, _LoggedBy,_ClientId);
        }
        finally
        {
            ClntMaster = null;
        }
    }
  
    
    public int ImageCheck()
    {
        ClntMaster = new ClientDetailTableAdapter();
        try
        {
            return Convert.ToInt32(ClntMaster.ImageCheck(_ClientId));
        }
        catch
        {
            throw;
        }
        finally
        {
            ClntMaster = null;
        }
    }

    public DataTable GetClient()
    {
        ClntMaster = new ClientDetailTableAdapter();
        try
        {
            return ClntMaster.GetClient();
        }
        finally
        {
            ClntMaster = null;
        }

    }
    public DataTable GetClientByUserId()
    {
        ClntMaster = new ClientDetailTableAdapter();
        try
        {
            return ClntMaster.GetClientByUserId(_UserId);
        }
        finally
        {
            ClntMaster = null;
        }

    }
    public void ChangeClientStatus()
    {
        ClntMaster = new ClientDetailTableAdapter();
        try
        {
            ClntMaster.ChangeClientStatus(_Status, _ClientId);
        }
        finally
        {
            ClntMaster = null;
        }
    }

    public DataTable FillClient()
    {
        ClntMaster = new ClientDetailTableAdapter();
        try
        {
            return ClntMaster.FillClient();
        }
        finally
        {
            ClntMaster = null;
        }

    }
    public DataTable FillFromClient()
    {
        ClntMaster = new ClientDetailTableAdapter();
        try
        {
            return ClntMaster.FillFromClient();
        }
        finally
        {
            ClntMaster = null;
        }

    }
    public DataTable FillClientByUserId()
    {
        ClntMaster = new ClientDetailTableAdapter();
        try
        {
            return ClntMaster.FillClientByUserId(_UserId);
        }
        finally
        {
            ClntMaster = null;
        }

    }

    public int GetClientNo()
    {
        ClntMaster = new ClientDetailTableAdapter();
        try
        {
            return Convert.ToInt32(ClntMaster.GetClientNo());
        }
        finally
        {
            ClntMaster = null;
        }

    }
    public DataTable GetClientById()
    {
        ClntMaster = new ClientDetailTableAdapter();
        try
        {
           return ClntMaster.GetClientById(_ClientId);
        }
        finally
        {
            ClntMaster = null;
        }
    }
    public DataTable GetClientEmail()
    {
        ClntMaster = new ClientDetailTableAdapter();
        try
        {
            return ClntMaster.GetClientEmail(_ClientId);
        }
        finally
        {
            ClntMaster = null;
        }
    }
    #endregion
    
    //--------Contact Person------//
    #region

   private int _PersonId;
   private string _PersonName;
   private string _PersonContact;
   private string _PersonEmail;
   private string _PersonDob;
   private string _PersonAnnvrsry;
   private int _IsAdmin;
   //-------Properties------//

   public int PersonId
   {
       get { return _PersonId; }
       set { _PersonId = value; }
   }
   public string PersonName
   {
       get { return _PersonName; }
       set { _PersonName = value; }
   }
   public string PersonContact
   {
       get { return _PersonContact; }
       set { _PersonContact = value; }
   }
   public string PersonEmail
   {
       get { return _PersonEmail; }
       set { _PersonEmail = value; }
   }
   public string PersonDob
   {
       get { return _PersonDob; }
       set { _PersonDob = value; }
   }
   public string PersonAnnvrsry
   {
       get { return _PersonAnnvrsry; }
       set { _PersonAnnvrsry = value; }
   }
   public int IsAdmin
   {
       get { return _IsAdmin; }
       set { _IsAdmin = value; }
   }
//-------Methods-----//

   public int InsertUpdateContactPerson()
   {
       CntctPrsn = new ClientContactPersonTableAdapter();
       try
       {
           return Convert.ToInt32(CntctPrsn.InsertUpdateContactPerson(_PersonId, _ClientId, _PersonName, _PersonContact, _PersonEmail, _PersonDob, _PersonAnnvrsry,_IsAdmin,_LoggedBy));
       }
       finally
       {
           CntctPrsn = null;
       }
   }
   public DataTable GetCelebration()
   {
       CntctPrsn = new ClientContactPersonTableAdapter();
       try
       {
           return CntctPrsn.GetCelebration();
       }
       finally
       {
           CntctPrsn = null;
       }
   }
   public void Updatecelebration()
   {
       CntctPrsn = new ClientContactPersonTableAdapter();
       try
       {
          // CntctPrsn.Updatecelebration(Person_Dob,Person_Anniversary,Client_Id,Contact_PersonId);
       }
       catch
       {
           throw;
       }
       finally
       {
           CntctPrsn = null;
       }
   }
   public DataTable GetContactPersonByClient()
   {
       CntctPrsn = new ClientContactPersonTableAdapter();
       try
       {
           return CntctPrsn.GetContactPersonByClient(_ClientId);
       }
       finally
       {
           CntctPrsn = null;
       }
   }
   public DataTable GetClientContactByEmail()
   {
       CntctPrsn = new ClientContactPersonTableAdapter();
       try
       {
           return CntctPrsn.GetClientContactByEmail(_PersonEmail);
       }
       finally
       {
           CntctPrsn = null;
       }
   }
   public DataTable FillClientContactById()
   {
       CntctPrsn = new ClientContactPersonTableAdapter();
       try
       {
           return CntctPrsn.FillClientContactById(_ClientId);
       }
       finally
       {
           CntctPrsn = null;
       }
   }
   public DataTable GetClientContactforDDL()
   {
       CntctPrsn = new ClientContactPersonTableAdapter();
       try
       {
           return CntctPrsn.GetClientContactforDDL();
       }
       finally
       {
           CntctPrsn = null;
       }
   }
   public void ChangeContactPersonStatus()
   {
       CntctPrsn = new ClientContactPersonTableAdapter();
       try
       {
           CntctPrsn.ChangeContactPersonStatus(_Status, _LoggedBy,_ClientId, _PersonId);
       }
       finally
       {
           CntctPrsn = null;
       }
   }

  
    #endregion

    //--------Address--------//
    #region
    private int _AddressId;
    private string _AddressType;
    private string _Address;
    private int _CntryId;
    private int _StateId;
    private string _Pincode;

    public int AddressId
    {
        get { return _AddressId; }
        set { _AddressId = value; }
    }
    public string AddressType
    {
        get { return _AddressType; }
        set { _AddressType = value; }
    }
    public string Address
    {
        get { return _Address; }
        set { _Address = value; }
    }
    public int CntryId
    {
        get { return _CntryId; }
        set { _CntryId = value; }
    }
    public int StateId
    {
        get { return _StateId; }
        set { _StateId = value; }
    }
    public string Pincode
    {
        get { return _Pincode; }
        set { _Pincode = value; }
    }

    public void InsertClientAddress()
    {
        Adress = new Client_AddressTableAdapter();
        try
        {
            Adress.InsertClientAddress(_ClientId, _AddressType, _Address, _CntryId, _StateId, _CityId, _Pincode, _LoggedBy);
        }
        finally
        {
            Adress = null;
        }
    }

    public void UpdateClientAddress()
    {
        Adress = new Client_AddressTableAdapter();
        try
        {
            Adress.UpdateClientAddress(_Address, _AddressType, _CntryId, _StateId, _CityId, _Pincode, _LoggedBy,_AddressId, _ClientId);
        }
        finally
        {
            Adress = null;
        }
    }

    public DataTable GetAddressByClient()
    {
        Adress = new Client_AddressTableAdapter();
        try
        {
            return Adress.GetAddressByClient(_ClientId);
        }
        finally
        {
            CntctPrsn = null;
        }
    }

    public void ChangeAddressStatus()
    {
        Adress = new Client_AddressTableAdapter();
        try
        {
            Adress.ChangeAddressStatus(_Status, _LoggedBy,_AddressId, _ClientId);
        }
        finally
        {
            Adress = null;
        }
    }


   #endregion

    //------Contract--------//
    #region
    private int _ContractId;
    private string _ContractCode;
    private string _Description;
    private int _ClientType;
    private string _StartDate;
    private string _EndDate;
    private int _Renwal;
    private Double _RatePer;
    private int _BillDate;
    private int _PaymentTearms;
    private int _AlertBeforeDays;
 
  

    public int ContractId
    {
        get { return _ContractId; }
        set { _ContractId = value; }
    }
    public string ContractCode
    {
        get { return _ContractCode; }
        set { _ContractCode = value; }
    }
    public string Description
    {
        get { return _Description; }
        set { _Description = value; }
    }
    public int ClientType
    {
        get { return _ClientType; }
        set { _ClientType = value; }
    }
    public string StartDate
    {
        get { return StartDate; }
        set { _StartDate = value; }
    }
    public string EndDate
    {
        get { return _EndDate; }
        set { _EndDate = value; }
    }
    public int Renwal
    {
        get { return _Renwal; }
        set { _Renwal = value; }
    }

    public Double RatePer
    {
        get { return _RatePer; }
        set { _RatePer = value; }
    }
    public int BillDate
    {
        get { return _BillDate; }
        set { _BillDate = value; }
    }
    public int PaymentTearms
    {
        get { return _PaymentTearms; }
        set { _PaymentTearms = value; }
    }
    public int AlertBeforeDays
    {
        get { return _AlertBeforeDays; }
        set { _AlertBeforeDays = value; }
    }
 
   public void InsertClientContract()
   {
       Contract = new Client_ContractTableAdapter();
       try
       {
           Contract.InsertClientContract(_ClientId, _ContractCode, _Description, _ClientType, _StartDate, _EndDate, _Renwal, _RatePer, _BillDate, _PaymentTearms, _AlertBeforeDays, _LoggedBy);
       }
       finally
       {
           Contract = null;
       }
   }

   public DataTable GetContractByClient()
   {
       Contract = new Client_ContractTableAdapter();
       try
       {
           return Contract.GetContractByClient(_ClientId);
       }
       finally
       {
           Contract = null;
       }
   }

   public void ChangeContractStatus()
   {
       Contract = new Client_ContractTableAdapter();
       try
       {
           Contract.ChangeContractStatus(_Status, _LoggedBy,_ClientId, _ContractId);
       }
       finally
       {
           Contract = null;
       }
   }

   public void UpdateContract()
   {
       Contract = new Client_ContractTableAdapter();
       try
       {
           Contract.UpdateContract(_ContractCode, _Description, _ClientType, _StartDate, _EndDate, _Renwal, _RatePer, _BillDate, _PaymentTearms, _AlertBeforeDays, _LoggedBy, _ContractId, _ClientId);
       }
       finally
       {
           Contract = null;
       }
   }
    #endregion


   //------Policy------//
    #region
    //---------Policy-----//
    private int _Doc_Id;
    private string _Document_Title;
    private string _File_Path;
    
    //----Policy-----//
    public int Doc_Id
    {
        get { return _Doc_Id; }
        set { _Doc_Id = value; }
    }
    public string Document_Title
    {
        get { return _Document_Title; }
        set { _Document_Title = value; }
    }
    public string File_Path
    {
        get { return _File_Path; }
        set { _File_Path = value; }
    }


  


    //-----Polocy----//
    public int InsertPolicy()
    {
        docmstr = new DocumentMasterTableAdapter();
        try
        {
            return docmstr.InsertPolicy(_ClientId, _Document_Title, _File_Path, _LoggedBy);
        }
        finally
        {
            docmstr = null;
        }
    }
    public DataTable GetPolicyById()
    {
        docmstr = new DocumentMasterTableAdapter();
        try
        {
            return docmstr.GetPolicyById(_ClientId);
        }
        finally
        {
            docmstr = null;
        }
    }
    public void UpdatePolicy()
    {
        docmstr = new DocumentMasterTableAdapter();
        try
        {
            docmstr.UpdatePolicy(_Document_Title, _File_Path, _LoggedBy,_Doc_Id);
        }
        finally
        {
            docmstr = null;
        }
    }
    public void UpdatePolicyWithoutFile()
    {
        docmstr = new DocumentMasterTableAdapter();
        try
        {
            docmstr.UpdatePolicyWithoutPath(_Document_Title, _LoggedBy,_Doc_Id);
        }
        finally
        {
            docmstr = null;
        }
    }
    public void DeletePolicy()
    {
        docmstr = new DocumentMasterTableAdapter();
        try
        {
            docmstr.DeletePolicy(_Doc_Id);
        }
        finally
        {
            docmstr = null;
        }
    }

   #endregion


    //Documents
    #region
    private int _DocId;
    private int _DocTypeId;
    private string _DocumentNm;
    private string _DocFile;

    //----Policy-----//
    public int DocId
    {
        get { return _DocId; }
        set { _DocId = value; }
    }
   
    public int DocTypeId
    {
        get { return _DocTypeId; }
        set { _DocTypeId = value; }
    }
    public string DocumentNm
    {
        get { return _DocumentNm; }
        set { _DocumentNm = value; }
    }
    public string DocFile
    {
        get { return _DocFile; }
        set { _DocFile = value; }
    }

    public DataTable GetDocType()
    {
        CDocs = new ClientDocumentsTableAdapter();
        try
        {
            return CDocs.GetDocType();
        }
        finally
        {
            CDocs = null;
        }
    }

    public int IU_ClientDocuments()
    {
        CDocs = new ClientDocumentsTableAdapter();
        try
        {
            return Convert.ToInt32(CDocs.IU_ClientDocuments(_DocId,_ClientId, _DocumentNm,_DocTypeId, _DocFile,_LoggedBy));
        }
        finally
        {
            CDocs = null;
        }
    }

    public DataTable GetClientDocuments()
    {
        CDocs = new ClientDocumentsTableAdapter();
        try
        {
            return CDocs.GetClientDocuments(_ClientId);
        }
        finally
        {
            CDocs = null;
        }
    }

    public int Change_ClientDocumentsStatus()
    {
        CDocs = new ClientDocumentsTableAdapter();
        try
        {
            return Convert.ToInt32(CDocs.Change_ClientDocumentsStatus(_DocId, _ClientId,_Status, _LoggedBy));
        }
        finally
        {
            CDocs = null;
        }
    }
    
    #endregion


    #region   Client Department
    private int _DepId;
    private string _DepartmentName;
    private string _DepartmentCode;
    private int _ContactId;
     private int _PortfolioMgrId;
     private int _TeamLeadMgrId;

   
    public int DepId
    {
        get { return _DepId; }
        set { _DepId = value; }
    }
    public string  DepartmentName
    {
        get { return _DepartmentName; }
        set { _DepartmentName = value; }
    }

    public string DepartmentCode
    {
        get { return _DepartmentCode; }
        set { _DepartmentCode = value; }
    }

    
    public int ContactId
    {
        get { return _ContactId; }
        set { _ContactId = value; }
    }

    public int PortfolioMgrId
    {
        get { return _PortfolioMgrId; }
        set { _PortfolioMgrId = value; }
    }
    public int TeamLeadMgrId
    {
        get { return _TeamLeadMgrId; }
        set { _TeamLeadMgrId = value; }
    }

    public DataTable GetClientContactForDDL()
    {
        Cdept = new ClientDepartmentTableAdapter();
        try
        {
            return Cdept.GetClientContactForDDL(_ClientId);
        }
        finally
        {
            Cdept = null;
        }
    }
    public int IU_ClientDepartment()
    {
        Cdept = new ClientDepartmentTableAdapter();
        try
        {
            return Convert.ToInt32(Cdept.IU_ClientDepartment(_DepId, _ClientId, _DepartmentName, _DepartmentCode, _ContactId, _PortfolioMgrId, _TeamLeadMgrId, _LoggedBy));
        }
        finally
        {
            Cdept = null;
        }
    }

    public DataTable GetClientDepartment()
    {
        Cdept = new ClientDepartmentTableAdapter();
        try
        {
            return Cdept.GetClientDepartment(_ClientId);
        }
        finally
        {
            Cdept = null;
        }
    }

    public int Change_ClientDepartmentStatus()
    {
        Cdept = new ClientDepartmentTableAdapter();
        try
        {
            return Convert.ToInt32(Cdept.Change_ClientDepartmentStatus(_DepId, _ClientId, _Status, _LoggedBy));
        }
        finally
        {
            Cdept = null;
        }
    }
    #endregion
}