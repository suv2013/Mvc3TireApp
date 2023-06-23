using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL
{
    public class BL_User
    {
        Users Obj_User = new Users();
        public IEnumerable<Users> UserList
        {
            get
            {
                DataTable dtUser = new DataTable();
                Obj_User.UserName = "";
                dtUser = Obj_User.GetUsers();
                List<Users> UserList = new List<Users>();
                UserList = (from DataRow dr in dtUser.Rows
                             select new Users()
                             {
                                 rowid = Convert.ToString(dr["rowid"]),
                                 //UserId = Convert.ToString(dr["UserId"]),
                                 UserName = dr["UserName"].ToString(),
                                 Name = dr["Name"].ToString(),
                                 Password = dr["Password"].ToString(),
                                 MailId = dr["MailId"].ToString()
                             }).ToList();
                return UserList;
            }
        }

        
    }
}
