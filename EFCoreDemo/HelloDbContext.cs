using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCoreDemo
{
    internal class HelloDbContext:DbContext
    {
        
        private static ILoggerFactory loggerFactory = LoggerFactory.Create(builder => builder.AddConsole());
        //定义实体在数据库中的默认表名
        public DbSet<Book> Books { get; set; }
        public DbSet<Person> Persons { get; set; }
        public DbSet<Dog> Dogs { get; set; }
        //配置数据库连接字符串
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string conStr = "Server=.;DataBase=EFCoreDemo;Trusted_Connection=True;TrustServerCertificate=True";
            optionsBuilder.UseSqlServer(conStr);
            //通过标准日志的方式查看EFCore的SQL语句
            //optionsBuilder.UseLoggerFactory(loggerFactory);
            //通过简单日志的方式查看EFCore的SQL语句
            /*
            optionsBuilder.LogTo(msg=>
                {
                    if (!msg.Contains("CommandExecuting")) return;
                    Console.WriteLine(msg);
                }
            );
            */
        }
        //加载当前程序集中所有实现了IEntityTypeConfiguration接口的类
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(this.GetType().Assembly);
        }
    }
}
