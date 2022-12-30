namespace LinqDemo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Employee> employeeList = new List<Employee>()
            {
                new Employee() { Id = 1, Department="政秘科", Name = "ankium", Age = 33, Gender = true, Salary =3000},
                new Employee() { Id = 2, Department="农社科", Name = "sudons", Age = 16, Gender = false,Salary = 8500 },
                new Employee() { Id = 3, Department="外专科", Name = "jerroy", Age = 28, Gender = true, Salary = 7600 },
                new Employee() { Id = 4, Department="成果科", Name = "aspnet", Age = 33, Gender = true,Salary = 5967 },
                new Employee() { Id = 5, Department="资配科", Name = "google", Age = 28, Gender = false, Salary = 6535 },
                new Employee() { Id = 6, Department="政秘科", Name = "samsun", Age = 43, Gender = true, Salary = 4356 },
                new Employee() { Id = 7, Department="外专科", Name = "illste", Age = 16, Gender = false, Salary = 2534 },
                new Employee() { Id = 8, Department="农社科", Name = "manguo", Age = 33, Gender = false, Salary = 4520 },
                new Employee() { Id = 9, Department="农社科", Name = "mindon", Age = 45, Gender = true, Salary = 6681 },
            };
            //（1）Where数据过滤
            IEnumerable<Employee> empList = employeeList.Where(emp => emp.Salary > 2500 && emp.Age < 35);
            foreach (Employee emp in empList)
            {
                Console.WriteLine(emp);
            }
            //（2）Count获取数据条数
            int count1 = employeeList.Count(e=>e.Salary>5000||e.Age<30);
            int count2 = employeeList.Where(e=>e.Salary>5000||e.Age<30).Count();
            Console.WriteLine(count1);
            Console.WriteLine(count2);
            //（3）Any判断是否至少有壹条满足条件的数据
            bool b1 = employeeList.Any(e => e.Salary > 5000);
            bool b2 = employeeList.Where(e=>e.Salary>5000).Any();
            Console.WriteLine(b1);
            Console.WriteLine(b2);
            //（4）Single/SingleOrDefault/First/FirstOrDefault获取一条数据
            Employee e1 = employeeList.Single(e => e.Id == 1);
            Console.WriteLine(e1);
            Employee? e2 = employeeList.SingleOrDefault(e => e.Id == 10);
            if (e2==null)
            {
                Console.WriteLine("没有ID==10的数据");
            }
            else
            {
                Console.WriteLine(e2);
            }
            Employee e3 = employeeList.First(e => e.Age > 30);
            Console.WriteLine(e3);
            Employee? e4 = employeeList.FirstOrDefault(e => e.Age > 30);
            if (e4==null)
            {
                Console.WriteLine("没有大于30岁的数据");
            }
            else
            {
                Console.WriteLine(e4); 
            }
            //Employee e5 = employeeList.First(e => e.Salary > 9999);
            //（5）OrderBy排序
            IEnumerable<Employee> orderedItems1 = employeeList.OrderBy(e => e.Age);
            foreach (Employee item in orderedItems1)
            {
                Console.WriteLine(item);
            }
            IEnumerable<Employee> orderedItems2 = employeeList.OrderByDescending(e => e.Age);
            foreach (Employee item in orderedItems2)
            {
                Console.WriteLine(item);
            }
            //（6）Skip/Take限制结果集
            IEnumerable<Employee> takeItems = employeeList.Skip(2).Take(3);
            foreach (Employee item in takeItems)
            {
                Console.WriteLine(item);
            }
            //（7）Max/Min/Sum/Average/Count聚合函数
            Console.WriteLine($"最大年龄:{employeeList.Max(e=>e.Age)}," +
                $"最小ID:{employeeList.Min(e=>e.Id)}," +
                $"平均工资:{employeeList.Average(e=>e.Salary)}," +
                $"工资总和:{employeeList.Sum(e=>e.Salary)}，" +
                $"总人数:{employeeList.Count()}," +
                $"大于30岁职工的最低工资:{employeeList.Where(e=>e.Age>30).Min(e=>e.Salary)}");
            //(8)GroupBy分组
            IEnumerable<IGrouping<string, Employee>> items = employeeList.GroupBy(emp => emp.Department);
            foreach (IGrouping<string, Employee> item in items)
            {
                string department = item.Key;
                int count = item.Count();
                int maxSalary = item.Max(emp => emp.Salary);
                double avgSalary = item.Average(emp => emp.Salary);
                int minAge = item.Min(emp => emp.Age);
                Console.WriteLine($"部门{department},人数{count},最高工资{maxSalary},平均工资{avgSalary},最小年龄{minAge}");
            }
            //（9）Select投影
            IEnumerable<int> ages = employeeList.Select(emp => emp.Age);
            Console.WriteLine(string.Join(",",ages));
            IEnumerable<string> names = employeeList.Select(e => e.Gender ? "男" : "女");
            Console.WriteLine(string.Join(",", names));
            //（10）ToArray/ToList集合转换
            Employee[] empItems = employeeList.Where(e=>e.Age>30).ToArray();
            foreach (var item in empItems)
            {
                Console.WriteLine(item);
            }
            List<Employee> eList = employeeList.Where(e => e.Salary > 5000).ToList();
            foreach (var item in eList)
            {
                Console.WriteLine(item);
            }
            //（11）综合案例
            var newItems = employeeList.Where(e => e.Id > 2)
                .GroupBy(e => e.Age).OrderBy(g => g.Key)
                .Take(3)
                .Select(g => new { Age = g.Key, Count = g.Count(), AvgSalary = g.Average(e => e.Salary) });
            foreach (var item in newItems)
            {
                Console.WriteLine($"年龄{item.Age},人数{item.Count},平均工资{item.AvgSalary}");
            }
            //（12）查询语法
            var items3 = employeeList.Where(e => e.Salary > 3000).OrderBy(e => e.Age).Select(e => new { e.Age, Gender = e.Gender ? "男" : "女" });
            var items4 = from e in employeeList
                         where e.Salary > 3000
                         orderby e.Age
                         select new { e.Age, Gender = e.Gender ? "男" : "女" };
        }
    }
}
