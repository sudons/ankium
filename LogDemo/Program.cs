using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System.Runtime.CompilerServices;

namespace LogDemo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ServiceCollection services = new ServiceCollection();
            services.AddLogging(logBuilder => { logBuilder.AddConsole(); });
            using(ServiceProvider sp = services.BuildServiceProvider())
            {
                ILogger logger= sp.GetRequiredService<ILogger<Program>>();
                logger.LogWarning("这是一条警告消息");
                logger.LogError("这是一条错误消息");
                string age = "abc";
                logger.LogInformation($"用户输入的年龄：{age}");
                try
                {
                    int i = int.Parse(age);
                }
                catch (Exception ex)
                {

                    logger.LogError(ex, "解析字符串为int失败");
                }
            }
        }
    }
}