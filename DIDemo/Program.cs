using Microsoft.Extensions.DependencyInjection;
using System.Data;
using System.Data.SqlClient;

namespace DIDemo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ServiceCollection services= new ServiceCollection();
            services.AddScoped<IDbConnection>(sp =>
            {
                string conStr = "Data Source=.;Initial Catalog=DI_DB;Integrated Security=true";
                var con = new SqlConnection(conStr);
                con.Open();
                return con;
            });
            services.AddScoped<IUserDao, UserDao>();
            services.AddScoped<IUserBiz, UserBiz>();
            using(ServiceProvider sp = services.BuildServiceProvider())
            {
                IUserBiz userBiz= sp.GetRequiredService<IUserBiz>();
                bool b = userBiz.CheckLogin("sun", "YUNWEN0305");
                Console.WriteLine(b);
            }
        }
    }
}