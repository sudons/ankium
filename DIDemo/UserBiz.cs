using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DIDemo
{
    internal class UserBiz : IUserBiz
    {
        private readonly IUserDao userDao;
        public UserBiz(IUserDao userDao)
        {
            this.userDao = userDao;
        }

        public bool CheckLogin(string userName, string password)
        {
            User user = userDao.GetByUserName(userName);
            if (user == null) return false;
            else return user.Password == password;
        }
    }
}
