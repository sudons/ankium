using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewSyntax
{
    public class Student
    {
        public string Name { get; set; }
        //属性可为空
        public string? PhoneNumber { get; set; }
        public Student(string name)
        {
            this.Name=name;
        }
    }
}
