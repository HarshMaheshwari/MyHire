using System;
using System.Collections.Generic;
using System.Web;
using System.Data;
using AddressDALTableAdapters;
using System.Configuration;


public class AddressBAL
{
    
    CountryDetailTableAdapter CntryMaster;
    StateDetailTableAdapter StateMaster;
    CityDetailTableAdapter CityMaster;



    private int _Client_id;
    private int _LoggedBy;
    private string _ACode;
    private int _AStatus;

    public int Client_id
    {
        get { return _Client_id; }
        set { _Client_id = value; }
    }
    public string ACode
    {
        get { return _ACode; }
        set { _ACode = value; }
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
    //-----------------Counrty-------------------------

    public int _Cntry_Id;
    public string _Cntry_Name;

    public int Cntry_Id
    {
        get { return _Cntry_Id; }
        set { _Cntry_Id = value; }
    }
    public string Cntry_Name
    {
        get { return _Cntry_Name; }
        set { _Cntry_Name = value; }
    }

    //-----------------State-------------------------

    public int _State_Id;
    public string _State_Name;

    public int State_Id
    {
        get { return _State_Id; }
        set { _State_Id = value; }
    }
    public string State_Name
    {
        get { return _State_Name; }
        set { _State_Name = value; }
    }
    //-----------------City-------------------------

    public int _City_Id;
    public string _City_Name;

    public int City_Id
    {
        get { return _City_Id; }
        set { _City_Id = value; }
    }
    public string City_Name
    {
        get { return _City_Name; }
        set { _City_Name = value; }
    }


    //Methods 

    //---Country---//
    public DataTable FillCountry()
    {
        CntryMaster = new CountryDetailTableAdapter(); ;
        try
        {
            return CntryMaster.FillCountry();
        }
        finally
        {
            CntryMaster = null;
        }
    }

    public DataTable GetCountry()
    {
        CntryMaster = new CountryDetailTableAdapter(); ;
        try
        {
            return CntryMaster.GetCountry();
        }
        finally
        {
            CntryMaster = null;
        }
    }

    public void InsertCountry()
    {
        CntryMaster = new CountryDetailTableAdapter();
        try
        {
            CntryMaster.InsertCountry(_ACode, _Cntry_Name, _LoggedBy);
        }
        finally
        {
            CntryMaster = null;
        }
    }

    public void UpdateCountry()
    {
        CntryMaster = new CountryDetailTableAdapter();
        try
        {
            CntryMaster.UpdateCountry(_Cntry_Name, _ACode, _LoggedBy,_Cntry_Id);
        }
        finally
        {
            CntryMaster = null;
        }
    }

    public void ChangeCountryStatus()
    {
        CntryMaster = new CountryDetailTableAdapter();
        try
        {
            CntryMaster.ChangeCountryStatus(_AStatus, _LoggedBy,Cntry_Id);           
        }
        finally
        {
            CntryMaster = null;            
        }
    }   


    //---State---//
    public DataTable FillState()
    {
        StateMaster = new StateDetailTableAdapter();
        try
        {
            return StateMaster.FillState();
        }
        finally
        {
            StateMaster = null;
        }
    }

    public DataTable GetStateDetailAll()
    {
         StateMaster = new StateDetailTableAdapter();
        try
        {
            return StateMaster.GetStateDetailAll();
        }
        finally
        {
            StateMaster = null;
        }

    }
    public DataTable GetState()
    {
        StateMaster = new StateDetailTableAdapter();
        try
        {
            return StateMaster.GetState();
        }
        finally
        {
            StateMaster = null;
        }
    }

    public DataTable GetStateById()
    {
        StateMaster = new StateDetailTableAdapter();
        try
        {
            return StateMaster.GetStateById(_Cntry_Id);
        }
        finally
        {
            StateMaster = null;
        }
    }

    public void InsertState()
    {
        StateMaster = new StateDetailTableAdapter();
        try
        {
            StateMaster.InsertState(_Cntry_Id, _ACode,_State_Name, _LoggedBy);
        }
        finally
        {
            StateMaster = null;
        }
    }

    public void UpdateState()
    {
        StateMaster = new StateDetailTableAdapter();
        try
        {
            StateMaster.UpdateState(_State_Name, _ACode, _Cntry_Id, _LoggedBy,_State_Id);
        }
        finally
        {
            StateMaster = null;
        }
    }

    public void ChangeStateStatus()
    {
        StateMaster = new StateDetailTableAdapter();
        try
        {
            StateMaster.ChangeStateStatus(_AStatus, _LoggedBy,_State_Id);
        }
        finally
        {
            StateMaster = null;
        }
    }

    //---City---//
    public DataTable FillCity()
    {
        CityMaster = new CityDetailTableAdapter();
        try
        {
            return CityMaster.FillCity();
        }
        finally
        {
            CityMaster = null;
        }
    }

    public DataTable GetCityDetailAll()
    {
        CityMaster = new CityDetailTableAdapter();
        try
        {
            return CityMaster.GetCityDetailAll();
        }
        finally
        {
            CityMaster = null;
        }

    }
    public DataTable GetCity()
    {
        CityMaster = new CityDetailTableAdapter();
        try
        {
            return CityMaster.GetCity();
        }
        finally
        {
            CityMaster = null;
        }
    }

    public DataTable GetCityById()
    {
        CityMaster = new CityDetailTableAdapter();
        try
        {
            return CityMaster.GetCityById(_State_Id);
        }
        finally
        {
            CityMaster = null;
        }
    }

    public void InsertCity()
    {
        CityMaster = new CityDetailTableAdapter();
        try
        {
            CityMaster.InsertCity(_State_Id,_ACode, _City_Name, _LoggedBy);
        }
        finally
        {
            CityMaster = null;
        }
    }

    public void UpdateCity()
    {
        CityMaster = new CityDetailTableAdapter();
        try
        {
            CityMaster.UpdateCity(_City_Name, _ACode, _State_Id, _LoggedBy,_City_Id);
        }
        finally
        {
            CityMaster = null;
        }
    }

    public void ChangeCityStatus()
    {
        CityMaster = new CityDetailTableAdapter();
        try
        {
            CityMaster.ChangeCityStatus(_AStatus, _LoggedBy,_City_Id);
        }
        finally
        {
            CityMaster = null;

        }
    }
}