namespace EFCoreDemo
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            using(HelloDbContext db = new HelloDbContext())
            {

                /*
                 * 增加数据
                Book book1 = new Book() { Title = "数学之美", PubTime = new DateTime(2009,03,24), AuthorName = "冯杰", Price = 90 };
                Book book2 = new Book() { Title = "数据结构", PubTime = new DateTime(2011,06,05), AuthorName = "云文", Price = 123 };
                Book book3 = new Book() { Title = "构架设计", PubTime = new DateTime(2023,02,08), AuthorName = "杨大", Price = 54 };
                Book book4 = new Book() { Title = "无线通信", PubTime = new DateTime(2015,09,12), AuthorName = "云文", Price = 77 };
                Book book5 = new Book() { Title = "墨菲定律", PubTime = new DateTime(2017,03,08), AuthorName = "张伟", Price = 33 };
                db.Books.Add(book1);
                db.Books.Add(book2);
                db.Books.Add(book3);
                db.Books.Add(book4);
                db.Books.Add(book5);
                await db.SaveChangesAsync();
                */


                /*
                 * 查询数据
                IQueryable<Book> books = db.Books.Where(b => b.AuthorName == "云文").OrderBy(b => b.Price);
                foreach(Book book in books)
                {
                    Console.WriteLine($"名称:{book.Title},作者：{book.AuthorName},价格：{book.Price}");
                }
                */


                /*
                 * 修改数据
                Book book = db.Books.Single(b => b.Title == "数据结构");
                book.PubTime = new DateTime(2012, 06, 05);
                await db.SaveChangesAsync();
                */


                /*
                 * 删除数据
                Book book = db.Books.Single(b => b.Title == "墨菲定律");
                db.Books.Remove(book);
                await db.SaveChangesAsync();
                */

            }
            await Console.Out.WriteLineAsync("ASP.NET Core");
        }
    }
}