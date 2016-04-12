using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using MasterDALTableAdapters;
using System.Configuration;


public class MasterBAL
{


    private int _Client_Id;
    private int _LoggedBy;
    private int _AStatus;
    private String _Name;
    private String _Remarks;
    private int _FunctAreaId;
    private int _IndustryId;
    public int Client_Id
    {
        get { return _Client_Id; }
        set { _Client_Id = value; }
    }
    public int AStatus
    {
        get { return _AStatus; }
        set { _AStatus = value; }
    }
    public int LoggedBy
    {
        get { return _LoggedBy; }
        set { _LoggedBy = value; }
    }

    public String Name
    {
        get { return _Name; }
        set { _Name = value; }
    }

    public String Remarks
    {
        get { return _Remarks; }
        set { _Remarks = value; }
    }
    public int FunctAreaId
    {
        get { return _FunctAreaId; }
        set { _FunctAreaId = value; }
    }
    public int IndustryId
    {
        get { return _IndustryId; }
        set { _IndustryId = value; }
    }
    #region   Functional Area
    FunctionaAreaDetailTableAdapter fun;
    public void IU_FunctionaAreaDetail()
    {
        fun = new FunctionaAreaDetailTableAdapter();
        try
        {
            fun.IU_FunctionaAreaDetail(_FunctAreaId, _Name ,_Remarks , _LoggedBy);
        }
        finally
        {
            fun = null;
        }
    }
    public DataTable GetFunctionalArea()
    {
        fun = new FunctionaAreaDetailTableAdapter();
        try
        {
            return fun.GetFunctionalArea();
        }
        finally
        {
            fun = null;
        }
        
    }
    public void  ChangeFunAreaStatus()
    {
        fun = new FunctionaAreaDetailTableAdapter();
        try
        {
            fun.ChangeFunAreaStatus(_AStatus, _LoggedBy,FunctAreaId);
        }
        finally
        {
            fun = null;
        }

    }

    public DataTable FillFunctionalArea()
    {
        fun = new FunctionaAreaDetailTableAdapter();
        try
        {
            return fun.FillFunctionalArea();
        }
        finally
        {
            fun = null;
        }
        
    }

    public DataTable GetFunctinalAreaAll()
    {
        fun = new FunctionaAreaDetailTableAdapter();
        try
        {
            return fun.GetFunctinalAreaAll();
        }
        finally
        {
            fun = null;
        }

    }
    

    #endregion  

    #region Industry   

    IndustryMasterTableAdapter Ind;

    public DataTable GetIndustryDetailAll()
    {
        Ind = new IndustryMasterTableAdapter();
        try
        {
            return Ind.GetIndustryDetailAll();
        }
        finally
        {
            Ind = null;
        }

    }
    public void IU_IndustryMaster()
    {
        Ind = new IndustryMasterTableAdapter();
        try
        {
            Ind.IU_IndustryMaster(_IndustryId, _Name, _Remarks, _LoggedBy);
        }
        finally
        {
            fun = null;
        }
    }
    public DataTable GetIndustry()
    {
        Ind = new IndustryMasterTableAdapter();
        try
        {
            return Ind.GetIndustry();
        }
        finally
        {
            Ind = null;
        }

    }
    public void ChangeIndustryStatus()
    {
        Ind = new IndustryMasterTableAdapter();
        try
        {
            Ind.ChangeIndustryStatus(_AStatus, _LoggedBy,_IndustryId);
        }
        finally
        {
            Ind = null;
        }

    }
    public DataTable FillIndustry()
    {
        Ind = new IndustryMasterTableAdapter();
        try
        {
            return Ind.FillIndustry();
        }
        finally
        {
            Ind = null;
        }

    }
    #endregion 
    # region Billing Status
    BillingStatusTableAdapter billstatus;
    public DataTable GetBillingStatusforDDL()
    {
        billstatus = new BillingStatusTableAdapter();
        try
        {
            return billstatus.GetBillingStatusforDDL();
        }
        finally
        {
            billstatus = null;
        }
    }

    #endregion
    # region Payment Status
    PaymentStatusTableAdapter payment;
    public DataTable getPaymentStatusforDDL()
    {
        payment = new PaymentStatusTableAdapter();
        try
        {
            return payment.getPaymentStatusforDDL();
        }
        finally
        {
            payment = null;
        }
    }

    #endregion

}