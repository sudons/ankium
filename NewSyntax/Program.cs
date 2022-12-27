using NewSyntax;

UsingStatement.WriteAndReadText("顶级语句隐式位于全局命名空间中");

Student stu = GetData();
Console.WriteLine(stu.Name.ToLower());
Console.WriteLine(stu.PhoneNumber!.ToLower());
Student GetData()
{
    Student stu = new Student("Sun");
    stu.PhoneNumber = "12345";
    return stu;
}
Console.WriteLine("--------------------------------------");
Person p1 = new Person("云", "文");
Person p2 = new Person("云", "文");
Console.WriteLine(p1 == p2);
Console.WriteLine("--------------------------------------");
//调用record类型的默认构造函数
Teacher t1 = new Teacher("云", "admin@ankium.com", 25);
Teacher t2 = new Teacher("云", "admin@ankium.com", 25);
Teacher t3 = new Teacher("王", "admin@ankium.com", 26);
//Console.WriteLine(t1);
t1.SayHello("你好");
t2.SayHello("你好");
t3.SayHello("你好");
Console.WriteLine(t1 == t2);
Console.WriteLine(t1 == t3);
Console.WriteLine("--------------------------------------");
t1.LastName = "文";
t1.SayHello("你好");
Console.WriteLine(t1==t2);
Console.WriteLine("--------------------------------------");
//调用record类型的自定义构造方法
Teacher t4 = new Teacher("云", "admin@sudons.com",18, "杉");
t4.SayHello("你好");
Console.WriteLine("--------------------------------------");
//手动创建record对象的副本
Teacher t5 = new Teacher(t1.FirstName, "sudons@msn.cn", t1.Age,t1.LastName);
t1.SayHello("你好");
t5.SayHello("你好");
Console.WriteLine(object.ReferenceEquals(t1,t5));
Console.WriteLine("--------------------------------------");
//使用with关键字简化创建record对象的副本的代码
Teacher t6 = t4 with { Age = 12 };
t4.SayHello("你好");
t6.SayHello("你好");
Console.WriteLine(object.ReferenceEquals(t4,t6));