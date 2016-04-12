using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using BusinessPlanDALTableAdapters;


public class BusinessPlanBAL
{
    BussinessPlanTableAdapter Bus;
 
    #region Properties
    private int _LoggedBy;
        private int _Status;
        private int _BusinessPlanId;
        private int _ClientId;

        private string _BMonth;
        private string _BYear; 
        private double _ConsultantNo;
        private int _OffersNo;
        private int _OfferValue;
        private int _JoiningNo;
        private int _Billing;
        private string _MonthYear;
  
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
        public int ClientId
        {
        get { return _ClientId; }
        set { _ClientId = value; }
        }
        public int BusinessPlanId
        {
            get { return _BusinessPlanId; }
            set { _BusinessPlanId = value; }
        }

    

        public string BMonth
        {
        get { return _BMonth; }
        set { _BMonth = value; }
        }
        public string BYear
        {
        get { return _BYear; }
        set { _BYear = value; }
        }
        public double ConsultantNo
        {
        get { return _ConsultantNo; }
        set { _ConsultantNo = value; }
        }
        public int OffersNo
        {
        get { return _OffersNo; }
        set { _OffersNo = value; }
        }

        public int OfferValue
        {
        get { return _OfferValue; }
        set { _OfferValue = value; }
        }
        public int JoiningNo
        {
        get { return _JoiningNo; }
        set { _JoiningNo = value; }
        }
        public int Billing
        {
        get { return _Billing; }
        set { _Billing = value; }
        }
        public string MonthYear
        {
            get { return _MonthYear; }
            set { _MonthYear = value; }
        }

    #endregion Properties

    #region  BusinessPlan
        public int IU_BussinessPlan()
        {
            Bus = new BussinessPlanTableAdapter();
            try
            {
                return Convert.ToInt32(Bus.IU_BussinessPlan(_BusinessPlanId,_ClientId, _BMonth, _BYear, _ConsultantNo, _OffersNo, _OfferValue, _JoiningNo, _Billing, _LoggedBy));
                
            }
            finally
            {
                Bus = null;
            }
        }

        public DataTable GetPlanAchievement()
        {
            Bus = new BussinessPlanTableAdapter();
            try
            {
                return Bus.GetPlanAchievement(_MonthYear);
            }
            finally
            {
                Bus = null;

            }
        }

        public DataTable GetPlanAchievementByClient()
        {
            Bus = new BussinessPlanTableAdapter();
            try
            {
                return Bus.GetPlanAchievementByClient(_MonthYear);
            }
            finally
            {
                Bus = null;

            }
        }

        public DataTable GetPlanAchievementByConsultant()
        {
            Bus = new BussinessPlanTableAdapter();
            try
            {
                return Bus.GetPlanAchievementByConsultant(_MonthYear);
            }
            finally
            {
                Bus = null;

            }
        }
    #endregion  
}