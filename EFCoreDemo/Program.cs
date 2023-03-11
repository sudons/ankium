using Microsoft.EntityFrameworkCore;

namespace EFCoreDemo
{
    internal class Program
    {
        static async Task Main(string[] args)
        {

            //using HelloDbContext ctx = new HelloDbContext();
            //var b1 = new Book { AuthorName = "云文", Title = "零基础学编程", Price = 59.8, PubTime = new DateTime(2019, 3, 1) };
            //var b2 = new Book { AuthorName = "冯杰", Title = "图解算法进阶", Price = 99.5, PubTime = new DateTime(2012, 10, 17) };
            //var b3 = new Book { AuthorName = "云文", Title = "混音入门教程", Price = 69.0, PubTime = new DateTime(2020, 5, 28) };
            //var b4 = new Book { AuthorName = "冯杰", Title = "程序员的圣经", Price = 73.3, PubTime = new DateTime(2008, 9, 2) };
            //var b5 = new Book { AuthorName = "吴军", Title = "拜厄钢琴教程", Price = 81.8, PubTime = new DateTime(2019, 3, 8) };
            //ctx.Books.Add(b1);
            //ctx.Books.Add(b2);
            //ctx.Books.Add(b3);
            //ctx.Books.Add(b4);
            //ctx.Books.Add(b5);
            //await ctx.SaveChangesAsync();

            using HelloDbContext ctx = new HelloDbContext();

            /*
            Console.WriteLine("**************所有书****************");
            foreach (Book book in ctx.Books)
            {
                Console.WriteLine($"Id={book.Id},Title={book.Title},Price={book.Price},AuthorName={book.AuthorName}");
            }
            */

            Console.WriteLine("*********所有价格高于80元的书**********");
            IQueryable<Book> books1 = ctx.Books.Where(b => b.Price > 80);
            //通过ToQueryString的方式查看EFCore中查询操作的SQL语句
            Console.WriteLine(books1.ToQueryString());
            foreach (Book book in books1)
            {
                Console.WriteLine($"Id={book.Id},Title={book.Title},AuthorName={book.AuthorName},PubTime={book.PubTime},Price={book.Price}");
            }

            //Book bk1 = ctx.Books.Single(b => b.Title == "零基础学编程");
            //Console.WriteLine($"Id={bk1.Id},Title={bk1.Title},Price={bk1.Price},AuthorName={bk1.AuthorName}");

            /*
            Book? bk2 = ctx.Books.FirstOrDefault(b => b.Id == 9);
            if (bk2==null)
            {
                Console.WriteLine($"没有Id=9的数据");
            }
            else
            {
                Console.WriteLine($"Id={bk2.Id},Title={bk2.Title},Price={bk2.Price},AuthorName={bk2.AuthorName}");
            }

            IEnumerable<Book> books2 = ctx.Books.OrderByDescending(b=> b.Price);
            foreach (Book book in books2)
            {
                Console.WriteLine($"Id={book.Id},Title={book.Title},Price={book.Price}");
            }

            var groups = ctx.Books.GroupBy(b => b.AuthorName).Select(g => new { AuthorName = g.Key, BooksCount = g.Count(), MaxPrice = g.Max(b => b.Price) });
            foreach (var g in groups)
            {
                Console.WriteLine($"作者:{g.AuthorName},图书数量:{g.BooksCount},最高价格:{g.MaxPrice}");
            }
            */

            //更新数据
            //var books3 = ctx.Books.Where(b => b.Title == "拜厄钢琴教程");
            //foreach (Book b in books3)
            //{
            //    b.AuthorName = "小胡";
            //}
            //await ctx.SaveChangesAsync();

            //删除数据
            /*
            var books4 = ctx.Books.Where(b => b.Title == "拜厄钢琴教程");
            foreach (Book b in books4)
            {
                ctx.Remove(b);
            }
            */
            await ctx.SaveChangesAsync();
        }
    }
}