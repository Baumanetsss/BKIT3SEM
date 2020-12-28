using System;
using System.Collections.Generic;
using System.Net.Cache;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Reflection;

namespace Lab6
{
    delegate object PlusOrMinus(int x, double y, bool flag);
    class PartOne
    {
        static object Plus(int x, double y, bool flag)
        {
            if (flag == true)
                return ((int)(x + y));
            else
                return (x + y);
        }
        static object Minus(int x, double y, bool flag)
        {
            if (flag == true)
                return ((int)(x - y));
            else
                return (x - y);
        }
        static void PlusOrMinusUse1(string str, int x, double y, bool flag, Func<int, double, bool, object> PlusOrMinusParam)
        {
            object result = PlusOrMinusParam(x, y, flag);
            Console.WriteLine(str + " " + result.ToString());
        }

        static void Main(string[] args)
        {
            PlusOrMinus pm = new PlusOrMinus(Plus);
            PlusOrMinusUse1("Это целое число", 1, 1.5, true, Plus);
            PlusOrMinusUse1("Это целое число", 1, 1.5, true, (x, y, flag) =>
            {
                if (flag == true)
                    return ((int)(x - y));
                else
                    return (x - y);
            }
            );
        }

    }

    class DescriptionAttribute : Attribute
    {
        public string description { get; set; }
        public DescriptionAttribute() { }
        public DescriptionAttribute(string _description) { description = _description; }
    }

    [Description(description = "18")]
    class User
    {
        public User() { }
        public User(string _name, int _age) { name = _name; age = _age; }
        public string name { get; set; }
        private int age;
        [Description("Возраст")]
        public int Age
        {
            get
            {
                return age;
            }
            set 
            {
                age = value;
            }
        }
    }
}
