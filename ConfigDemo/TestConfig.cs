using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConfigDemo
{
    //读取配置
    internal class TestConfig
    {
        private readonly IOptionsSnapshot<DbSettings> optDbSettings;//IOptionsSnapshot<T>生命周期：范围
        private readonly IOptionsSnapshot<SmtpSettings> smtpSettings;//IOptionsSnapshot<T>生命周期：范围
        public TestConfig(IOptionsSnapshot<DbSettings> optDbSettings, IOptionsSnapshot<SmtpSettings> smtpSettings)
        {
            this.optDbSettings = optDbSettings;
            this.smtpSettings = smtpSettings;
        }
        public void Test()
        {
            DbSettings db = optDbSettings.Value;
            Console.WriteLine($"数据库类型为:{db.DbType},数据库连接字符串为:{db.ConnectionString}");
            SmtpSettings smtp = smtpSettings.Value;
            Console.WriteLine($"SMTP:{smtp.Server},{smtp.UserName},{smtp.Password}");
        }
    }
}
