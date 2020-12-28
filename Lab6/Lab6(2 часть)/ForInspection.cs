using System;
using System.Collections.Generic;
using System.Net.Cache;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Lab6Part2
{   
    class DescriptionAttribute : Attribute
    {
        public string description { get; set; }
        public DescriptionAttribute() { }
        public DescriptionAttribute(string _description) { description = _description; }
    }

    class User : IComparable
    {
        public User() { }
        public User(string _name, int _age) { name = _name; age = _age; }
        public string name;
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public int age;
        [Description("Возраст")]
        public int Age
        {
            get {return age; }
            set { age = value; }
        }
        public void PrintInfo()
        {
            Console.WriteLine("Имя пользователя: " + name + "\nВозраст пользователя: " + age.ToString());
        }
        public int CompareTo(object obj)
        {
            if (obj.GetType().Name == "User")
            {
                Type t = obj.GetType();
                foreach (var field in t.GetFields())
                {
                    if (field.GetValue(obj) != field.GetValue(this))
                        return (1);
                }
                return (0);
            }
            return (1);
        }
    }
}
