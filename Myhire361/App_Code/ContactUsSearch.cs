using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Globalization;
using System.Data;
using System.Data.SqlClient;


public class ContactUsSearch
{
    string query, subQry;
    DataAccessLayer srch;

    public DataTable SearchFeedback(string Date)
    {
        Date = Date.Replace("-", " ");
        subQry = "";
        try
        {
            srch = new DataAccessLayer();

            query = "  Select FeedbackMsg,Feedback_Id, CONVERT(VARCHAR(20), CreationDate, 100)  as CreationDate from Feedback ";

            if (Date.Trim() != "")
            {
                subQry = " Where Convert(varchar, (DATEADD(MINUTE,750,CreationDate)),113) like '%" + Date + "%' ";
            }

            query = query + subQry + " order by CreationDate ";
            
            return srch.SearchRecord(query);
        }
        finally
        {
            srch = null;
        }
    }

    public DataTable SearchContactus(String Email, String ContactNo, string Date)
    {
        try
        {
            Date = Date.Replace("-", " ");
            srch = new DataAccessLayer();
            subQry = "";
            query = "  Select ContactUs_Id, Name, EmailID,ContactNo, CONVERT(VARCHAR(20), CreationDate, 100)   as CreationDate,City,Msg   " +
            " from ContactUs ";
            
            

            if (Email != "")
            {
                if (subQry != "")
                {
                    subQry=subQry+" and ";
                }
                subQry = subQry+" EmailID like '%" + Email + "%' ";              
            }

            if (ContactNo != "")
            {
                if (subQry != "")
                {
                    subQry = subQry + " and ";
                }
                subQry = subQry + " ContactNo like '%" + ContactNo + "%' ";
            }

            if (Date != "")
            {
                if (subQry != "")
                {
                    subQry = subQry + " and ";
                }
                subQry = subQry + " Convert(varchar, (DATEADD(MINUTE,750,CreationDate)),113) like '%" + Date + "%' ";
            }

            if (subQry != "")
            {
                subQry = " Where "+subQry;
            }

            query = query + subQry + " Order by CreationDate desc ";

            
            return srch.SearchRecord(query);
        }
        finally
        {
            srch = null;
        }
    }
}