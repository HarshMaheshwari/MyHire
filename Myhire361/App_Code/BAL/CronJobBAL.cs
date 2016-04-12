using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using CronJobTableAdapters;
using System.Configuration;

public class CronJobBAL
{
    RRCandidateStatusReportTableAdapter rrcand;
    public int InsertRRCandidateStatusReport()
    {
        rrcand = new RRCandidateStatusReportTableAdapter();
        try
        {
            return Convert.ToInt32(rrcand.InsertRRCandidateStatusReport());
        }
        finally
        {
            rrcand = null;

        }
    }
}