using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using System.ComponentModel.DataAnnotations;

namespace BAL
{
    public class Users
    {
        #region Objects References

        DBConn db = new DBConn();

        #endregion

        #region Auto Implement Properties of Users      
        
        public String rowid { get; set; }
        //public String UserId { get; set; }
        [Required]
        public String UserName { get; set; }
        [Required]
        public String Password { get; set; }
        [Required]
        public String Name { get; set; }
        [Required]
        public String MailId { get; set; }
        #endregion

        #region Select Users
        public DataTable GetUsers()
        {
            DataTable dt = new DataTable();
            try
            {
                const String ProcName = "Select_Users";
                ArrayList ParamList = new ArrayList();
                SqlParameter ParamUserId = new SqlParameter("@UserName", UserName) { SqlDbType = SqlDbType.VarChar };
                ParamList.Add(ParamUserId);
                dt = db.GetDataTable(ProcName, ParamList);
                return dt;
            }
            catch (Exception ex)
            {
                return dt;
            }
        }        
        #endregion

        #region Add User
        public bool AddUsers()
        {
            try
            {
                const String ProcName = "Insert_Users";
                ArrayList ParamList = new ArrayList();
                SqlParameter ParamUserName = new SqlParameter("@UserName", UserName) { SqlDbType = SqlDbType.NVarChar };
                SqlParameter ParamPassword = new SqlParameter("@Password", Password) { SqlDbType = SqlDbType.NVarChar };
                SqlParameter ParamName = new SqlParameter("@Name", Name) { SqlDbType = SqlDbType.NVarChar };
                SqlParameter ParamMailId = new SqlParameter("@MailId", MailId) { SqlDbType = SqlDbType.NVarChar };
                ParamList.Add(ParamUserName);
                ParamList.Add(ParamPassword);
                ParamList.Add(ParamName);
                ParamList.Add(ParamMailId);
                String Stat = (String)db.ExecuteScalar(ProcName, ParamList);
                if (Stat == "Success")
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        #endregion

        #region Edit User
        public bool EditUsers()
        {
            try
            {
                const String ProcName = "Update_Users";
                ArrayList ParamList = new ArrayList();
                //SqlParameter ParamUserId = new SqlParameter("@UserId", UserId) { SqlDbType = SqlDbType.NVarChar };
                SqlParameter ParamUserName = new SqlParameter("@UserName", UserName) { SqlDbType = SqlDbType.NVarChar };
                SqlParameter ParamPassword = new SqlParameter("@Password", Password) { SqlDbType = SqlDbType.NVarChar };
                SqlParameter ParamName = new SqlParameter("@Name", Name) { SqlDbType = SqlDbType.NVarChar };
                SqlParameter ParamMailId = new SqlParameter("@MailId", MailId) { SqlDbType = SqlDbType.NVarChar };
                //ParamList.Add(ParamUserId);
                ParamList.Add(ParamUserName);
                ParamList.Add(ParamPassword);
                ParamList.Add(ParamName);
                ParamList.Add(ParamMailId);
                String Stat = (String)db.ExecuteScalar(ProcName, ParamList);
                if (Stat == "Success")
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        #endregion

        #region Delete Users
        public bool DeleteUsers()
        {
            try
            {
                const String ProcName = "Delete_Users";
                ArrayList ParamList = new ArrayList();
                SqlParameter ParamUserId = new SqlParameter("@UserName", UserName) { SqlDbType = SqlDbType.NVarChar };
                ParamList.Add(ParamUserId);
                String Stat = (String)db.ExecuteScalar(ProcName, ParamList);
                if (Stat == "Success")
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        #endregion

    }
}
