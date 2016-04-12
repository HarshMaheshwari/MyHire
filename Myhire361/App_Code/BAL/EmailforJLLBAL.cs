using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EmailforJLLTableAdapters;

using System.Data;
using System.Configuration;
/// <summary>
/// Summary description for EmailforJLLBAL
/// </summary>
public class EmailforJLLBAL
{
    JJLEmailTableTableAdapter jll;
    public int sno;
    public int UpdateJLLEmail()
    {
        jll = new JJLEmailTableTableAdapter();
        try
        {
            return Convert.ToInt32(jll.UpdateJLLEmail(sno));
        }
        finally
        {
            jll = null;
        }
    }

    public int UpdateJLLEmailforDate4()
    {
        jll = new JJLEmailTableTableAdapter();
        try
        {
            return Convert.ToInt32(jll.UpdateJLLEmailforDate4(sno));
        }
        finally
        {
            jll = null;
        }
    }
    public int UpdateJLLEmailForDate3()
    {
        jll = new JJLEmailTableTableAdapter();
        try
        {
            return Convert.ToInt32(jll.UpdateJLLEmailForDate3(sno));
        }
        finally
        {
            jll = null;
        }
    }

    public DataTable JLLEmail()
    {
        jll = new JJLEmailTableTableAdapter();
        try
        {
            return jll.JLLEmail();
        }
        finally
        {
            jll = null;
        }
    }
    public DataTable JLLEmail3()
    {
        jll = new JJLEmailTableTableAdapter();
        try
        {
            return jll.JLLEmail3();
        }
        finally
        {
            jll = null;
        }
    }
    public DataTable JLLEmail4()
    {
        jll = new JJLEmailTableTableAdapter();
        try
        {
            return jll.JLLEmail4();
        }
        finally
        {
            jll = null;
        }
    }
}