using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DIDemo
{
    internal class UserDao : IUserDao
    {
        private readonly IDbConnection con;
        public UserDao(IDbConnection con)
        {
            this.con = con;
        }

        public User? GetByUserName(string userName)
        {
            using DataTable dataTable = SqlHelper.ExecuteQuery(con, $"select * from T_Users where UserName={userName}");
            if (dataTable.Rows.Count <= 0) return null;
            DataRow row = dataTable.Rows[0];
            int id = (int)row["Id"];
            string uname = (string)row["UserName"];
            string password = (string)row["Password"];
            return new User(id, uname, password);
        }
    }
}
