using System;

namespace AsyncMethodDemo
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            //async、await背后的原理揭秘
            /*
            using HttpClient httpClient = new HttpClient();
            string html = await httpClient.GetStringAsync("https://www.ptpress.com.cn");
            Console.WriteLine(html);
            string destFilePath = "sub.txt";
            string content = "hello async and await";
            await File.WriteAllTextAsync(destFilePath, content);
            string content2 = await File.ReadAllTextAsync(destFilePath);
            Console.WriteLine(content2);
            */

            //async背后的线程切换
            /*
            Console.WriteLine("1-ThreadID="+Thread.CurrentThread.ManagedThreadId);
            string str1 = new string('a', 10000000);
            string str2 = new string('b', 10000000);
            string str3 = new string('c', 10000000);
            await File.WriteAllTextAsync("1.txt", str1);
            Console.WriteLine("2-ThreadID="+Thread.CurrentThread.ManagedThreadId);
            await File.WriteAllTextAsync("2.txt", str2);
            Console.WriteLine("3-ThreadID="+Thread.CurrentThread.ManagedThreadId);
            File.WriteAllText("3.txt", str3);
            Console.WriteLine("4-ThreadID="+Thread.CurrentThread.ManagedThreadId);
            */

            //异步方法不等于多线程
            /*
            Console.WriteLine("1-Main-ThreadID="+Thread.CurrentThread.ManagedThreadId);
            Console.WriteLine(await CalcAsync(10000));
            Console.WriteLine("2-Main-ThreadID="+Thread.CurrentThread.ManagedThreadId);
            */

            //没有async的异步方法
            /*
            string str = await ReadFileAsync(2);
            Console.WriteLine(str);
            */

            //手动创建Task对象
            /*
            await WriteFileAsync(3, "hello");
            string str = await ReadFileAsync(5);
            Console.WriteLine(str);
            */

            //不建议的操作
            /*
            string str1 = File.ReadAllTextAsync("1.txt").Result;
            string str2 = File.ReadAllTextAsync("1.txt").GetAwaiter().GetResult();
            File.WriteAllTextAsync("1.txt", "www.ankium.com").Wait();
            Console.WriteLine(str1);
            Console.WriteLine(str2);
            */

            //异步暂停的方法
            /*
            using HttpClient httpClient= new HttpClient();
            string str1 = await httpClient.GetStringAsync("https://www.baidu.com");
            await Task.Delay(3000);
            string str2 = await httpClient.GetStringAsync("https://www.bing.com");
            */

            //同时等待多个Task的执行结束
            Task<string> t1 = File.ReadAllTextAsync("1.txt");
            Task<string> t2 = File.ReadAllTextAsync("2.txt");
            Task<string> t3 = File.ReadAllTextAsync("3.txt");
            string[] results = await Task.WhenAll(t1, t2, t3);
            Console.WriteLine(results[0]);
            Console.WriteLine(results[1]);
            Console.WriteLine(results[2]);

        }
        static Task WriteFileAsync(int num,string content)
        {
            switch (num)
            {

                case 1:
                    return File.WriteAllTextAsync("1.txt", content);
                    case 2:
                    return File.WriteAllTextAsync("2.txt", content);
                default:
                    Console.WriteLine("文件暂时不可用");
                    return Task.CompletedTask;
            }
        }
        static Task<string> ReadFileAsync(int num)
        {
            switch (num)
            {
                case 1:
                    return File.ReadAllTextAsync("1.txt");
                case 2:
                    return File.ReadAllTextAsync("2.txt");
                default:
                    return Task.FromResult("Love");
            }
        }

        async Task<decimal> CalcAsync(int n)
        {
            Console.WriteLine("CalcAsync-ThreadID=" + Thread.CurrentThread.ManagedThreadId);
            return await Task.Run<decimal>(() =>
            {
                Console.WriteLine("Task.Run-ThreadID=" + Thread.CurrentThread.ManagedThreadId);
                decimal result = 1;
                Random rand = new Random();
                for (int i = 0; i < n * n; i++)
                {
                    result += (decimal)rand.NextDouble();
                }
                return result;
            });
        }

        static async Task<int> DownloadAsync(string url,string destFilePath)
        {
            using HttpClient client = new HttpClient();
            string body = await client.GetStringAsync(url);
            await File.WriteAllTextAsync(destFilePath, body);
            return body.Length;
        }
    }
}