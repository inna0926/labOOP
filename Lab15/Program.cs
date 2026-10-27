using System;

namespace OOP_Lab15
{
    // Абстрактний базовий клас Геометрична фігура
    public abstract class Shape
    {
        public string Name { get; set; }

        public Shape(string name)
        {
            Name = name;
        }

        public abstract double GetArea();
        public abstract double GetPerimeter();
    }

    // Похідний клас: Коло
    public class Circle : Shape
    {
        public double Radius { get; set; }

        public Circle(string name, double radius) : base(name)
        {
            Radius = radius;
        }

        public override double GetArea()
        {
            return Math.PI * Radius * Radius;
        }

        public override double GetPerimeter()
        {
            return 2 * Math.PI * Radius;
        }
    }

    // Похідний клас: Прямокутник
    public class Rectangle : Shape
    {
        public double Width { get; set; }
        public double Height { get; set; }

        public Rectangle(string name, double width, double height) : base(name)
        {
            Width = width;
            Height = height;
        }

        public override double GetArea()
        {
            return Width * Height;
        }

        public override double GetPerimeter()
        {
            return 2 * (Width + Height);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("==========================================================================");
            Console.WriteLine(" ОБ'ЄКТНО-ОРІЄНТОВАНЕ ПРОГРАМУВАННЯ // ПРАКТИЧНА РОБОТА №15: COLLECTIONS");
            Console.WriteLine("==========================================================================");

            // ЗАГАЛЬНЕ ЗАВДАННЯ: Створення поліморфного масиву (по два об'єкти Circle та Rectangle)
            Shape[] shapes = new Shape[4];
            shapes[0] = new Circle("Мале Коло", 3.0);
            shapes[1] = new Circle("Велике Коло", 5.0);
            shapes[2] = new Rectangle("Вузький Прямокутник", 2.0, 8.0);
            shapes[3] = new Rectangle("Квадратний Прямокутник", 4.0, 4.0);

            Console.WriteLine("\n📊 --- Обхід поліморфного масиву фігур ---");
            
            double totalArea = 0;      // Змінна для підрахунку сумарної площі
            double totalPerimeter = 0; // ДОМАШНЄ ЗАВДАННЯ: Змінна для суми периметрів

            // Загальний цикл для автоматичної обробки всіх об'єктів ієрархії
            for (int i = 0; i < shapes.Length; i++)
            {
                double currentArea = shapes[i].GetArea();
                double currentPerimeter = shapes[i].GetPerimeter();

                // Накопичуємо загальну суму
                totalArea += currentArea;
                totalPerimeter += currentPerimeter;

                Console.WriteLine("Фігура [" + i + "]: " + shapes[i].Name + 
                                  " -> Площа = " + currentArea.ToString("F2") + 
                                  ", Периметр = " + currentPerimeter.ToString("F2"));
            }

            // Виведення підсумкових результатів на екран
            Console.WriteLine("\n📈 --- ПІДСУМКОВІ РЕЗУЛЬТАТИ ОБЧИСЛЕНЬ ---");
            Console.WriteLine("🧮 Загальна сумарна площа всіх фігур: " + totalArea.ToString("F2"));
            Console.WriteLine("📏 Загальна сума периметрів усіх фігур: " + totalPerimeter.ToString("F2"));

            Console.WriteLine("\n==========================================================================");
        }
    }
}
