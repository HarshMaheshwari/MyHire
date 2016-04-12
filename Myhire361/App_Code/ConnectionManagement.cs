using System;
using System.Collections.Generic;
using System.Web;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;


public class ConnectionManagement
{
    private SqlConnection con;
    string conn;

    public void GetConnection()
    {
        // checking that the connection if made or not.... 
        if (con == null)
        {
            conn = ConfigurationManager.ConnectionStrings["AranyaProjectConnectionString"].ConnectionString;
            con = new SqlConnection(conn);
        }

    }
    public void OpenConnection()
    {
        try
        {

            GetConnection();
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
        }
        catch (Exception ex)
        {

        }
        finally
        {

        }

    }
    public void CloseConnection()
    {
        try
        {
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
        }
        catch (Exception ex)
        {

        }
        finally
        {

        }

    }
    public DataTable SearchRecord(String query)
    {
        //fetch record without error message
        DataSet ds = new DataSet();
        try
        {
            GetConnection();
            SqlDataAdapter Ada = new SqlDataAdapter(query, con);
            Ada.Fill(ds);

        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
        finally
        {
            CloseConnection();

        }
        return ds.Tables[0];

    }

}