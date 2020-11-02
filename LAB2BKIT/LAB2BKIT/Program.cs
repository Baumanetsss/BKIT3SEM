using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2
{
    interface IPrint
    {
        void Print();
    }
    public abstract class Figure
    {
        public abstract double getSquare();
    }

    class Rectangle : Figure, IPrint
    {
        protected double length, width;

        public Rectangle(double length, double width)
        {
            this.length = length;
            this.width = width;
        }
        public override double getSquare()
        {
            return length * width;
        }
        public override string ToString()
        {
            return "\nПрямоугольник\nВысота: " + this.length + "\nШирина: " + this.width + "\nПлощадь: " + this.getSquare() + "\n";
        }
        public void Print()
        {
            Console.WriteLine(this.ToString());
        }
    }

    class Square : Rectangle
    {
        public Square(double length) : base(length, length) { }
        public override string ToString()
        {
            return "\nКвадрат\nСторона: " + this.length + "\nПлощадь: " + this.getSquare() + "\n";
        }
        public void Print()
        {
            Console.WriteLine(this.ToString());
        }
    }

    class Circle : Figure
    {
        private double r;

        public Circle(double r)
        {
            this.r = r;
        }
        public override double getSquare()
        {
            return Math.PI * r * r;
        }
        public override string ToString()
        {
            return "\nКруг\nРадиус: " + this.r + "\nПлощадь: " + this.getSquare() + "\n";
        }
        public void Print()
        {
            Console.WriteLine(this.ToString());
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Rectangle a = new Rectangle(2, 4);

            a.Print();

            Square b = new Square(5);

            b.Print();

            Circle c = new Circle(10);
            
            c.Print();
        }
    }
}