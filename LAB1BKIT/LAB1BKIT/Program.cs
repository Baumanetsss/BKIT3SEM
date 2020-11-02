using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lab1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Стрихар Павел Андреевич ИУ5-31Б\n");

            double[] coef = new double[3];

            bool flag;

            if (args.Length != 0)
            {
                for (int i = 0; i < args.Length; i++)
                {
                    flag = double.TryParse(args[i], out coef[i]);

                    if (!flag)
                    {
                        Console.Write("Неверный формат коэффициента в аргументе консоли!\n");
                        
                        ReadCoef(coef);

                        break;
                    }
                }
            }
            else
            {
                ReadCoef(coef);
            }

            GetDisc(coef);
        }

        static void ReadCoef(double[] coef)
        {
            double a = ToDouble("Введите коэффициент А: ");

            coef[0] = a;

            double b = ToDouble("Введите коэффициент B: ");

            coef[1] = b;

            double c = ToDouble("Введите коэффициент C: ");

            coef[2] = c;
        }

        static double ToDouble(string message)
        {
            string resultString;

            double resultDouble;

            bool flag;

            do
            {
                Console.Write(message);

                resultString = Console.ReadLine();

                flag = double.TryParse(resultString, out resultDouble);

                if (!flag)
                {
                    Console.WriteLine("Ошибка! Необходимо ввести вещественное число!");
                }
            } while (!flag);

            return resultDouble;
        }

        static void GetDisc(double[] coef)
        {
            double root1, root2;

            double disc = coef[1] * coef[1] - 4 * coef[0] * coef[2];

            if (disc < 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;

                Console.WriteLine("Решений нет =(");

                Console.ForegroundColor = ConsoleColor.Black;
            }
            else
            {
                if (disc == 0)
                {
                    root1 = Math.Sqrt(-1 * coef[1] / 2 * coef[0]);

                    if (root1 == 0)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;

                        Console.WriteLine("Уравнение имеет единственный корень: " + root1);

                        Console.ForegroundColor = ConsoleColor.Black;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Green;

                        Console.WriteLine("Первый корень: " + root1);

                        Console.WriteLine("Второй корень: " + (-1 * root1));

                        Console.ForegroundColor = ConsoleColor.Black;
                    }
                }
                else
                {
                    root1 = Math.Sqrt((-1 * coef[1] + Math.Sqrt(disc)) / 2 * coef[0]);

                    root2 = Math.Sqrt((-1 * coef[1] - Math.Sqrt(disc)) / 2 * coef[0]);

                    Console.ForegroundColor = ConsoleColor.Green;

                    Console.WriteLine("Первый корень: " + root1);

                    Console.WriteLine("Второй корень: " + (-1 * root1));

                    Console.WriteLine("Третий корень: " + root2);

                    Console.WriteLine("Четвертый корень: " + (-1 * root2));

                    Console.ForegroundColor = ConsoleColor.Black;
                }
            }
        }
    }
}