using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConfigDemo
{
    //配置模型类
    internal class SmtpSettings
    {
        public string Server { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
