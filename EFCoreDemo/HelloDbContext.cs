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
        //定义实体在数据库中的默认表名
        public DbSet<Book> Books { get; set; }
        public DbSet<Person> Persons { get; set; }
        public DbSet<Dog> Dogs { get; set; }
        //配置数据库连接字符串
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string conStr = @"Server=(localdb)\MSSQLLocalDB;DataBase=EFCoreDemo;Trusted_Connection=True;TrustServerCertificate=True";
            optionsBuilder.UseSqlServer(conStr);
        }
        //加载当前程序集中所有实现了IEntityTypeConfiguration接口的类
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(this.GetType().Assembly);
            modelBuilder.Entity<Book>().ToView("BooksView");
            modelBuilder.Entity<Book>().Ignore(b => b.PubTime);
            modelBuilder.Entity<Book>().Property(b => b.Title).HasColumnName("BookTitle");
            modelBuilder.Entity<Book>().Property(b=>b.AuthorName).HasColumnType("varchar(200)");
            modelBuilder.Entity<Dog>().HasKey(b => b.Name);
            modelBuilder.Entity<Person>().HasIndex(P => P.Name).IsUnique();
        }
    }
}
