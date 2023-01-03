using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConfigDemo
{
    //配置模型类
    internal class DbSettings
    {
        public string DbType { get; set; }
        public string ConnectionString { get; set; }
    }
}
