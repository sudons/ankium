using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewSyntax
{
    //记录类型：record类型提供了为所有只读属性赋值的默认构造方法，当然也可以手动指定可读写的属性和额外的构造方法
    public record Teacher(string FirstName,string? Email,int Age)
    {
        public string LastName { get; set; }//可读写的属性
        //自定义构造方法调用record类型提供的为所有只读属性赋值的默认构造方法
        public Teacher(string firstName,string? Email,int age, string lastName) :this(firstName, Email, age)
        {
            this.LastName= lastName;
        }
        public void SayHello(string message)
        {
            Console.WriteLine($"{message}我姓{FirstName}名{LastName}年龄{Age}邮箱{Email}");
        }
    }
}
