using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data;
using System.Collections;
using System.Data.SqlClient;

/// <summary>
/// Summary description for DBConn
/// </summary>
/// 

namespace DAL
{
    public class DBConn
    {
        string ConnString = ConfigurationManager.ConnectionStrings["MvcTestingDbConn"].ToString();

        #region GetDataTable
        public DataTable GetDataTable(string procedureName, ArrayList arrParams)
        {
            DataTable dt = new DataTable();
            try
            {
                SqlConnection con = new SqlConnection(ConnString);
                con.Open();
                SqlCommand com = new SqlCommand(procedureName, con);
                com.CommandType = CommandType.StoredProcedure;
                foreach (SqlParameter param in arrParams)
                {
                    if (param.Value == "")
                    {
                        param.Value = DBNull.Value;
                    }
                    com.Parameters.Add(param);
                }
                SqlDataAdapter da = new SqlDataAdapter(com);
                da.SelectCommand.CommandTimeout = 0;
                da.Fill(dt);
                con.Close();
                con.Dispose();

                return dt;
            }
            catch (Exception ex)
            {
                return dt;
            }
        }
        #endregion

        #region ExecuteNonQuery
        public bool ExecuteNonQuery(string procedureName, ArrayList arrParams)
        {
            try
            {
                SqlConnection con = new SqlConnection(ConnString);
                con.Open();
                SqlCommand com = new SqlCommand(procedureName, con);
                com.CommandType = CommandType.StoredProcedure;
                foreach (SqlParameter param in arrParams)
                {
                    if (param.Value == "")
                    {
                        param.Value = DBNull.Value;
                    }
                    com.Parameters.Add(param);
                }
                com.ExecuteNonQuery();
                con.Close();
                con.Dispose();

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        #endregion

        #region ExecuteScalarQuery
        public object ExecuteScalar(string procedureName, ArrayList arrParams)
        {
            SqlCommand com = new SqlCommand();
            object returnvalue = new object();
            try
            {
                SqlConnection con = new SqlConnection(ConnString);
                con.Open();
                com = new SqlCommand(procedureName, con);
                com.CommandType = CommandType.StoredProcedure;
                foreach (SqlParameter param in arrParams)
                {
                    if (param.Value == "")
                    {
                        param.Value = DBNull.Value;
                    }
                    com.Parameters.Add(param);
                }
                com.CommandTimeout = 0;
                returnvalue = com.ExecuteScalar();
                //String ReturnValue = com.ExecuteScalar().ToString();
                //returnvalue = ReturnValue;
                con.Close();
                con.Dispose();

                return returnvalue;
            }
            catch (Exception ex)
            {
                return returnvalue;
            }
        }
        #endregion

        #region GetDataSet
        public DataSet GetDataSet(string procedureName, ArrayList arrParams)
        {
            DataSet ds = new DataSet();
            try
            {
                SqlConnection con = new SqlConnection(ConnString);
                con.Open();
                SqlCommand com = new SqlCommand(procedureName, con);
                com.CommandType = CommandType.StoredProcedure;
                foreach (SqlParameter param in arrParams)
                {
                    if (param.Value == "")
                    {
                        param.Value = DBNull.Value;
                    }
                    com.Parameters.Add(param);
                }
                SqlDataAdapter da = new SqlDataAdapter(com);
                da.Fill(ds);
                con.Close();
                con.Dispose();

                return ds;
            }
            catch (Exception ex)
            {
                return ds;
            }
        }
        #endregion

        #region GetSqlDataReader
        public SqlDataReader GetSqlDataReader(string procedureName, ArrayList arrParams)
        {
            SqlDataReader dr = null;
            try
            {
                SqlConnection con = new SqlConnection(ConnString);
                con.Open();
                SqlCommand com = new SqlCommand(procedureName, con);
                com.CommandType = CommandType.StoredProcedure;
                foreach (SqlParameter param in arrParams)
                {
                    if (param.Value == "")
                    {
                        param.Value = DBNull.Value;
                    }
                    com.Parameters.Add(param);
                }
                dr = com.ExecuteReader();
                con.Close();
                con.Dispose();

                return dr;
            }
            catch (Exception ex)
            {
                return dr;
            }
        }
        #endregion

        #region GetDataTableForTran
        public DataTable GetDataTableForTran(string procedureName, ArrayList arrParams, SqlConnection con)
        {
            DataTable dt = new DataTable();
            try
            {
                if (con.State == ConnectionState.Closed)
                    con.Open();
                SqlCommand com = new SqlCommand(procedureName, con);
                com.CommandType = CommandType.StoredProcedure;
                foreach (SqlParameter param in arrParams)
                {
                    if (param.Value == "")
                    {
                        param.Value = DBNull.Value;
                    }
                    com.Parameters.Add(param);
                }
                SqlDataAdapter da = new SqlDataAdapter(com);
                da.Fill(dt);
                con.Close();
                con.Dispose();

                return dt;
            }
            catch (Exception ex)
            {
                return dt;
            }
        }
        #endregion

        #region ExecuteNonQueryForTran
        public bool ExecuteNonQueryForTran(string procedureName, ArrayList arrParams, SqlConnection con, SqlTransaction tran)
        {
            try
            {
                //if(con.State== ConnectionState.Closed)
                //con.Open();
                SqlCommand com = new SqlCommand(procedureName, con, tran);
                com.CommandType = CommandType.StoredProcedure;
                foreach (SqlParameter param in arrParams)
                {
                    if (param.Value == "")
                    {
                        param.Value = DBNull.Value;
                    }
                    com.Parameters.Add(param);
                }
                com.ExecuteNonQuery();
                //con.Close();
                //con.Dispose();

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        #endregion
    }

}