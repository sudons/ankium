using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DIDemo
{
    internal interface IUserDao
    {
        //查询用户名为userName的用户信息
        public User GetByUserName(string userName);
    }
}
