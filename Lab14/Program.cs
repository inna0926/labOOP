using System;

namespace OOP_Lab14
{
    // ==========================================================================
    // ЗАГАЛЬНЕ ТА ДОМАШНЄ ЗАВДАННЯ: Абстрактний базовий клас Геометрична фігура
    // ==========================================================================
    public abstract class Shape
    {
        public string Name { get; set; }

        public Shape(string name)
        {
            Name = name;
        }

        // Загальне завдання: Абстрактний метод для обчислення площі (без тіла)
        public abstract double GetArea();

        // Домашнє завдання: Абстрактний метод для обчислення периметра (без тіла)
        public abstract double GetPerimeter();
    }

    // ==========================================================================
    // ПОХІДНИЙ КЛАС: Коло (Circle)
    // ==========================================================================
    public class Circle : Shape
    {
        public double Radius { get; set; }

        public Circle(string name, double radius) : base(name)
        {
            Radius = radius;
        }

        // Обов'язкова реалізація площі кола
        public override double GetArea()
        {
            return Math.PI * Radius * Radius;
        }

        // Обов'язкова реалізація периметра (довжини кола)
        public override double GetPerimeter()
        {
            return 2 * Math.PI * Radius;
        }
    }

    // ==========================================================================
    // ПОХІДНИЙ КЛАС: Прямокутник (Rectangle)
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

        // Обов'язкова реалізація площі прямокутника
        public override double GetArea()
        {
            return Width * Height;
        }

        // Обов'язкова реалізація периметра прямокутника
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
            Console.WriteLine(" ОБ'ЄКТНО-ОРІЄНТОВАНЕ ПРОГРАМУВАННЯ // ПРАКТИЧНА РОБОТА №14: ABSTRACT");
            Console.WriteLine("==========================================================================");

            // ПЕРЕВІРКА ЗАВДАННЯ: Якщо спробувати розкоментувати рядок нижче, 
            // компілятор видасть помилку: "Cannot create an instance of the abstract class or interface 'Shape'"
            // Shape testAbstract = new Shape("Абстрактна фігура");

            // Створення масиву конкретних фігур
            Shape[] shapes = new Shape[2];
            shapes[0] = new Circle("Зелене Коло", 4.0);
            shapes[1] = new Rectangle("Жовтий Прямокутник", 5.0, 3.0);

            Console.WriteLine("\n📊 --- Обчислення параметрів конкретних фігур через абстрактний клас ---");
            
            for (int i = 0; i < shapes.Length; i++)
            {
                Console.WriteLine("\nФігура: " + shapes[i].Name);
                Console.WriteLine("-> Площа: " + shapes[i].GetArea().ToString("F2"));
                Console.WriteLine("-> Периметр: " + shapes[i].GetPerimeter().ToString("F2"));
            }

            Console.WriteLine("\n==========================================================================");
        }
    }
}
