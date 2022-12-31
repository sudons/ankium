using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLocatorDemo
{
    internal class TestServiceImp : ITestService,IDisposable
    {
        public string Name { get; set ; }
        public void SayHi()
        {
            Console.WriteLine($"Hi,I'm {Name}");
        }
        /// <summary>
        /// 被依赖注入窗口管理的类如果实现了IDisposable接口，则离开作用域之后容器会自动调用对象的Dispose方法,并及时释放非托管资源
        /// </summary>
        public void Dispose()
        {
            Console.WriteLine($"我实现了IDisposable接口");
        }
    }
}
