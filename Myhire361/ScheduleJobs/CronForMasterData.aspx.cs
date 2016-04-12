using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;


public partial class ScheduleJobs_CronForMasterData : System.Web.UI.Page
{
    WS_References WSR;
    MasterBAL MstrBal;
    AddressBAL addBAL;
    DataTable dt;
    int UserId;
    protected void Page_Load(object sender, EventArgs e)
    {
        UserId = 16;
        if (!IsPostBack)
        {
            Cron_InserUpdateIndustryMaster();
            Cron_InserUpdateFunctinalArea();
            Cron_InserUpdateCity();
          //  Cron_InserUpdateIndustryMaster();
            Cron_InserUpdateState();
        }

    }

    public void Cron_InserUpdateFunctinalArea()
    {
        WSR = new WS_References();
        MstrBal = new MasterBAL();
        dt=new DataTable();
        try
        {
           dt=MstrBal.GetFunctinalAreaAll();
           for (int idx = 0; idx <= dt.Rows.Count; idx++)
           {
               string FunctAreaName = dt.Rows[idx]["FunctAreaName"].ToString();
               string Remarks = dt.Rows[idx]["Remarks"].ToString();
               int FunctAreaId =Convert.ToInt32(dt.Rows[idx]["FunctAreaId"].ToString());
               WSR.WS_IU_FunctionaAreaDetail(FunctAreaId, FunctAreaName, Remarks, UserId);
           
           }
        }
        catch (Exception ex) { }
        finally { MstrBal = null;  }
    
    
    
    }


    public void Cron_InserUpdateCity()
    {
        WSR = new WS_References();
        addBAL = new AddressBAL();
        dt = new DataTable();
        try
        {
            dt = addBAL.GetCityDetailAll();
            for (int idx = 0; idx <= dt.Rows.Count; idx++)
            {
                string City_Code = dt.Rows[idx]["City_Code"].ToString();
                string City_Name = dt.Rows[idx]["City_Name"].ToString();
                int City_Id = Convert.ToInt32(dt.Rows[idx]["City_Id"].ToString());
                int State_Id = Convert.ToInt32(dt.Rows[idx]["State_Id"].ToString());
                WSR.WS_UpdateCity(City_Name, City_Code, State_Id, UserId, City_Id);
                WSR.WS_InsertCity(State_Id, City_Code, City_Name, UserId);
              
            }
        }
        catch (Exception ex) 
        {
        }
        finally 
        {
            addBAL = null; 
        }
    }

    public void Cron_InserUpdateState()
    {
        WSR = new WS_References();
        addBAL = new AddressBAL();
        dt = new DataTable();
        try
        {
            dt = addBAL.GetStateDetailAll();
            for (int idx = 0; idx <= dt.Rows.Count; idx++)
            {
                string State_Name = dt.Rows[idx]["State_Name"].ToString();
                string State_Code = dt.Rows[idx]["State_Code"].ToString();
                int Cntry_Id = Convert.ToInt32(dt.Rows[idx]["Cntry_Id"].ToString());
                int State_Id = Convert.ToInt32(dt.Rows[idx]["State_Id"].ToString());
                WSR.WS_InsertState(Cntry_Id, State_Code, State_Name, UserId);
                WSR.WS_UpdateState(State_Name, State_Code, addBAL.Cntry_Id, UserId, State_Id);
            }
        }
        catch (Exception ex)
        {
        }
        finally
        {
            addBAL = null;
        }
    }


    public void Cron_InserUpdateIndustryMaster()
    {
        WSR = new WS_References();
        MstrBal = new MasterBAL();
        dt = new DataTable();
        try
        {
            dt = MstrBal.GetIndustryDetailAll();
            for (int idx = 0; idx <= dt.Rows.Count; idx++)
            {
                string IndustryName = dt.Rows[idx]["IndustryName"].ToString();
                string Remarks = dt.Rows[idx]["Remarks"].ToString();
                int IndustryId = Convert.ToInt32(dt.Rows[idx]["IndustryId"].ToString());

                WSR.WS_IU_IndustryMaster(IndustryId , IndustryName, Remarks, UserId);

            }
        }
        catch (Exception ex) { }
        finally { MstrBal = null; }



    }

}