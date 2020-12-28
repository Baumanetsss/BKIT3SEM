using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Lab6Part2
{
    class Program
    {
        /// <summary>
        /// Проверка, что у свойства есть атрибут заданного типа
        /// </summary>
        /// <returns>Значение атрибута</returns>
        public static bool GetPropertyAttribute(PropertyInfo checkType, Type attributeType, out object attribute)
        {
            bool Result = false;
            attribute = null;

            //Поиск атрибутов с заданным типом
            var isAttribute = checkType.GetCustomAttributes(attributeType, false);
            if (isAttribute.Length > 0)
            {
                Result = true;
                attribute = isAttribute[0];
            }

            return Result;
        }
        /// <summary>
        /// Получение информации о текущей сборке
        /// </summary>
        static void AssemblyInfo()
        {
            Console.WriteLine("Вывод информации о сборке:");
            Assembly i = Assembly.GetExecutingAssembly();
            Console.WriteLine("Полное имя:" + i.FullName);
            Console.WriteLine("Исполняемый файл:" + i.Location);
        }
        /// <summary>
        /// Получение информации о типе
        /// </summary>
        static void TypeInfo()
        {
            Type t = typeof(User);

            Console.WriteLine("\nИнформация о типе:");
            Console.WriteLine("Тип " + t.FullName + " унаследован от " + t.BaseType.FullName);
            Console.WriteLine("Пространство имен " + t.Namespace);
            Console.WriteLine("Находится в сборке " + t.AssemblyQualifiedName);

            Console.WriteLine("\nКонструкторы:");
            foreach (var x in t.GetConstructors())
            {
                Console.WriteLine(x);
            }

            Console.WriteLine("\nМетоды:");
            foreach (var x in t.GetMethods())
            {
                Console.WriteLine(x);
            }

            Console.WriteLine("\nСвойства:");
            foreach (var x in t.GetProperties())
            {
                Console.WriteLine(x);
            }

            Console.WriteLine("\nПоля данных (public):");
            foreach (var x in t.GetFields())
            {
                Console.WriteLine(x);
            }

            Console.WriteLine("\nForInspection реализует IComparable -> " +
            t.GetInterfaces().Contains(typeof(IComparable))
            );
        }

        /// <summary>
        /// Использования метода InvokeMember
        /// </summary>
        static void InvokeMemberInfo()
        {
            Type t = typeof(User);
            Console.WriteLine("\nВызов метода:");

            //Создание объекта
            User fi = new User("Pavel", 18);
            //User fi = (User)t.InvokeMember(null, BindingFlags.CreateInstance, null, null, new object[] { });

            //Вызов метода
            t.InvokeMember("PrintInfo", BindingFlags.InvokeMethod, null, fi, new object[] { });
        }

        /// <summary>
        /// Работа с атрибутами
        /// </summary>
        static void AttributeInfo()
        {
            Type t = typeof(User);
            Console.WriteLine("\nСвойства, помеченные атрибутом:");
            foreach (var x in t.GetProperties())
            {
                object attrObj;
                if (GetPropertyAttribute(x, typeof(DescriptionAttribute), out attrObj))
                {
                    DescriptionAttribute attr = attrObj as DescriptionAttribute;
                    Console.WriteLine(x.Name + " - " + attr.description);
                }
            }
        }
        static void Main(string[] args)
        {
            AssemblyInfo();
            TypeInfo();
            InvokeMemberInfo();
            AttributeInfo();
        }
    }
}
