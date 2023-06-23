using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

/// <summary>
/// Summary description for DbAccess
/// </summary>
/// 

public class DbAccess
{
    public static string Strconn = ConfigurationManager.ConnectionStrings["ElogitechsConnection"].ToString();
    public SqlConnection con = new SqlConnection(DbAccess.Strconn);
    public SqlCommand cmd1 = new SqlCommand();
    public DbAccess()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    public static bool SaveData(String Query)
    {
        DbAccess c1 = new DbAccess();
        SqlCommand cmd = new SqlCommand(Query, c1.con);
        try
        {
            c1.con.Open();
            cmd.ExecuteNonQuery();
            return true;
        }
        catch (Exception ex)
        {
            return false;
        }
        finally
        {
            c1.con.Close();

        }
    }

    public static DataSet FetchData(String Query)
    {
        DbAccess c1 = new DbAccess();
        SqlDataAdapter da = new SqlDataAdapter(Query, c1.con);
        DataSet ds = new DataSet();
        da.Fill(ds);
        return ds;

    }
    public static DataTable FetchDatatable(string query)
    {
        try
        {
            DbAccess c1 = new DbAccess();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(query, c1.con);            
            da.Fill(dt);
            return dt;
        }
        catch
        {
            return null;
        }
    }

    public static void SaveData1(string query)
    {
        try
        {
            DbAccess c1 = new DbAccess();
            c1.con.Open();
            c1.cmd1.CommandText = query;
            c1.cmd1.Connection = c1.con;
            c1.cmd1.ExecuteNonQuery();
            c1.con.Close();
        }
        catch (Exception ex)
        {

        }
    }

    public static SqlDataReader Getrow(string readerqry)
    {
        DbAccess c2 = new DbAccess();
        c2.con.Open();
        SqlDataReader dr;
        c2.cmd1 = new SqlCommand(readerqry, c2.con);
        dr = c2.cmd1.ExecuteReader();
        //c2.con.Close();
        return (dr);
    }

    public static DataTable GetTable(string Query)
    {
        DbAccess obj = new DbAccess();
        try
        {

            obj.con.Open();
            SqlDataReader dr;
            obj.cmd1 = new SqlCommand(Query, obj.con);
            dr = obj.cmd1.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            return (dt);
        }
        catch
        {
            //ClientScript.RegisterStartupScript(Type.GetType("System.String"), "messagebox", "<script type=\"text/javascript\">alert('" + es.Message + "');</script>");
            return null;
        }
        finally
        {
            obj.con.Close();
        }
    }
}