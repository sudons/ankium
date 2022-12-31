using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DIDemo
{
    internal interface IUserBiz
    {
        //检查用户名和密码是否匹配
        public bool CheckLogin(string userName, string password);
    }
}
