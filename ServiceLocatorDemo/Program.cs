using Microsoft.Extensions.DependencyInjection;
namespace ServiceLocatorDemo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ServiceCollection services = new ServiceCollection();
            services.AddTransient<TestServiceImp>();
            using(ServiceProvider sp=services.BuildServiceProvider())
            {
                TestServiceImp testService = sp.GetRequiredService<TestServiceImp>();
                testService.Name = "云文";
                testService.SayHi();
            }
        }
    }
}