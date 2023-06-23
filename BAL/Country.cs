using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BAL
{
     
    public class Country
    {
        #region Objects References
        DBConn db = new DBConn();
        #endregion

        #region Properties
        public Int32 RowId { get; set; }
        public Int32 CountryID { get; set; }
        public String ISO { get; set; }
        public String CountryName { get; set; }

        #endregion

        #region Get Countries
        public IEnumerable<Country> GetCountries()
        {
            DataTable dt = new DataTable();
            //try
            //{
                const String ProcName = "Select_Country";
                ArrayList ParamList = new ArrayList();
                SqlParameter ParamUserId = new SqlParameter("@CountryID", CountryID) { SqlDbType = SqlDbType.VarChar };
                ParamList.Add(ParamUserId);
                dt = db.GetDataTable(ProcName, ParamList);
                List<Country> CountryList = new List<Country>();
                CountryList = (from DataRow dr in dt.Rows
                               select new Country()
                               {
                                   CountryID = Convert.ToInt32(dr["CountryID"]),
                                   ISO = Convert.ToString(dr["ISO"]),
                                   CountryName = Convert.ToString(dr["CountryName"]),
                               }).ToList();

                return CountryList;
            //}
            //catch (Exception ex)
            //{
            //    return dt;
            //}
        }
        #endregion
    }
}
