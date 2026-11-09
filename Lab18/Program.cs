using System;

namespace PracticalWork18
{
    // ==========================================
    // === ЗАГАЛЬНЕ ЗАВДАННЯ ===
    // ==========================================

    // Створюємо інтерфейс IDrawable із методом Draw()
    public interface IDrawable
    {
        void Draw();
    }

    // Реалізуємо інтерфейс у класі Point (Точка)
    public class Point : IDrawable
    {
        public int X { get; set; }
        public int Y { get; set; }

        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }

        // Реалізація методу Draw() для точки
        public void Draw()
        {
            Console.WriteLine($"[Point] Малюємо точку з координатами ({X}, {Y}) у консолі.");
        }
    }

    // Реалізуємо інтерфейс у класі Circle (Коло)
    public class Circle : IDrawable
    {
        public double Radius { get; set; }

        public Circle(double radius)
        {
            Radius = radius;
        }

        // Реалізація методу Draw() для кола
        public void Draw()
        {
            Console.WriteLine($"[Circle] Малюємо коло з радіусом {Radius} у консолі.");
        }
    }

    class Program
    {
        // Квадратні дужки [] додано для коректної сигнатури точки входу
        static void Main(string[] args)
        {
            Console.WriteLine("=== ЗАГАЛЬНЕ ЗАВДАННЯ (Інтерфейси) ===\n");

            // Створюємо об'єкти класів Point та Circle
            IDrawable point = new Point(10, 20);
            IDrawable circle = new Circle(5.5);

            // Викликаємо метод Draw() для кожного об'єкта
            point.Draw();
            circle.Draw();
        }
    }
}
