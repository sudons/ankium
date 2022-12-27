//全局using指令
global using System.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//简化的命名空间声明
namespace NewSyntax;

internal class UsingStatement
{
    //通过using关键字来简化非托管资源的释放
    public static void CommonUsing(string conStr)
    {
        using (SqlConnection conn = new SqlConnection(conStr))
        {
            conn.Open();
            using (SqlCommand cmd = conn.CreateCommand())
            {
                cmd.CommandText = "select * from T_Articles";
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read()) { }
                }
            }
        }
    }
    //简化的using声明
    public static void SimplifiedUsing(string conStr)
    {
        using SqlConnection conn = new SqlConnection(conStr);
        conn.Open();
        using SqlCommand cmd = conn.CreateCommand();
        cmd.CommandText = "select * from T_Articles";
        using SqlDataReader reader = cmd.ExecuteReader();
        while (reader.Read()) { }
    }
    //读写文件操作
    public static void WriteAndReadText(string str)
    {
        {
            using FileStream outStream = File.OpenWrite("sub.txt");
            using StreamWriter writer = new StreamWriter(outStream);
            writer.WriteLine(str);
        }
        string s = File.ReadAllText("sub.txt");
        Console.WriteLine(s);
    }
}
