using Microsoft.EntityFrameworkCore;

namespace GuidAuthorDemo
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            using HelloDbContext context = new HelloDbContext();
            Console.WriteLine("****1****");
            Author a1 = new Author() { Name="米线"};
            Console.WriteLine($"添加前,Id={a1.Id}");
            context.Authors.Add( a1 );
            Console.WriteLine($"添加后，保存前,Id={a1.Id}");
            await context.SaveChangesAsync();
            Console.WriteLine($"保存后,Id={a1.Id}");
            
            Console.WriteLine("****2****");
            Author a2 = new Author() { Name = "茅台" };
            a2.Id = Guid.NewGuid();
            Console.WriteLine($"保存前,Id={a2.Id}");
            context.Authors.Add(a2);
            await context.SaveChangesAsync();
            Console.WriteLine($"保存后,Id={a2.Id}");
        }
    }
}