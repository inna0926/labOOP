using System;

namespace OOP_Lab13
{
    // ==========================================================================
    // БАЗОВИЙ КЛАС: Геометрична фігура (Shape)
    // ==========================================================================
    public class Shape
    {
        public string Name { get; set; }

        public Shape(string name)
        {
            Name = name;
        }

        // Віртуальний метод для обчислення площі (базова реалізація повертає 0)
        public virtual double GetArea()
        {
            return 0;
        }
    }

    // ==========================================================================
    // ПОХІДНИЙ КЛАС: Коло (Circle) - Загальне завдання
    // ==========================================================================
    public class Circle : Shape
    {
        public double Radius { get; set; }

        public Circle(string name, double radius) : base(name)
        {
            Radius = radius;
        }

        // Перевизначення (override) віртуального методу площі кола
        public override double GetArea()
        {
            return Math.PI * Radius * Radius;
        }
    }

    // ==========================================================================
    // ПОХІДНИЙ КЛАС: Прямокутник (Rectangle) - Загальне завдання
    // ==========================================================================
    public class Rectangle : Shape
    {
        public double Width { get; set; }
        public double Height { get; set; }

        public Rectangle(string name, double width, double height) : base(name)
        {
            Width = width;
            Height = height;
        }

        // Перевизначення (override) віртуального методу площі прямокутника
        public override double GetArea()
        {
            return Width * Height;
        }
    }

    // ==========================================================================
    // ПОХІДНИЙ КЛАС: Трикутник (Triangle) - Домашнє завдання
    // ==========================================================================
    public class Triangle : Shape
    {
        public double BaseLength { get; set; } // основа
        public double Height { get; set; }     // висота

        public Triangle(string name, double baseLength, double height) : base(name)
        {
            BaseLength = baseLength;
            Height = height;
        }

        // Перевизначення (override) віртуального методу площі трикутника
        public override double GetArea()
        {
            return 0.5 * BaseLength * Height;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("==========================================================================");
            Console.WriteLine(" ОБ'ЄКТНО-ОРІЄНТОВАНЕ ПРОГРАМУВАННЯ // ПРАКТИЧНА РОБОТА №13: POLYMORPHISM");
            Console.WriteLine("==========================================================================");

            // Створення масиву базового типу Shape, що містить різні фігури (демонстрація поліморфізму)
            Shape[] shapes = new Shape;
            shapes = new Circle("Червоне Коло", 5.0);
            shapes = new Rectangle("Синій Прямокутник", 4.0, 6.0);
            shapes = new Triangle("Зелений Трикутник", 5.0, 4.0); // Домашнє завдання

            Console.WriteLine("\n📊 --- Обчислення площі фігур через базове посилання ---");
            
            for (int i = 0; i < shapes.Length; i++)
            {
                // Завдяки override програма сама викликає потрібний метод для кожної фігури під час виконання
                Console.WriteLine("Фігура: " + shapes[i].Name + " -> Площа: " + shapes[i].GetArea().ToString("F2"));
            }

            Console.WriteLine("\n==========================================================================");
        }
    }
}
