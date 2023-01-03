using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;
using Microsoft.Extensions.DependencyInjection;

namespace ConfigDemo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ConfigurationBuilder configBuilder = new ConfigurationBuilder();
            //通过IConfigurationRoot从JSON文件读取配置server:127.0.0.1
            configBuilder.AddJsonFile("config.json", optional: false, reloadOnChange: true);
            //通过IConfigurationRoot从命令行读取配置server:localhost
            configBuilder.AddCommandLine(args);
            //通过IConfigurationRoot从环境变量读取配置server:www.ankium.com
            configBuilder.AddEnvironmentVariables("SUN_");

            IConfigurationRoot config = configBuilder.Build();
            string server = config["server"];
            Console.WriteLine($"server:{server}");
            string email = config["email"];
            Console.WriteLine($"email:{email}");
            string phone = config["phone"];
            Console.WriteLine($"phone:{phone}");
            string proxyAddress = config.GetSection("proxy:address").Value;
            Console.WriteLine($"Address:{proxyAddress}");

            ConfigOptions();

        }
        //使用选项方式读取配置
        static void ConfigOptions()
        {
            ConfigurationBuilder configBuilder = new ConfigurationBuilder();
            configBuilder.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
            IConfigurationRoot config = configBuilder.Build();
            ServiceCollection services = new ServiceCollection();
            services.AddOptions().Configure<DbSettings>(e => config.GetSection("DB").Bind(e))
                .Configure<SmtpSettings>(e => config.GetSection("Smtp").Bind(e));
            services.AddTransient<TestConfig>();//生命周期：瞬态
            using (ServiceProvider sp = services.BuildServiceProvider())
            {
                while (true)//通过循环模拟软件重启（下次连接并载入配置）
                {
                    using(IServiceScope scope = sp.CreateScope())//创建范围
                    {
                        IServiceProvider spScope = scope.ServiceProvider;
                        TestConfig tc = spScope.GetRequiredService<TestConfig>();
                        tc.Test();
                    }
                    Console.WriteLine("请修改配置文件并待软件重启或者按回车键盘后以呈现新的配置项");
                    Console.ReadKey();
                }
            }
        }
    }


}