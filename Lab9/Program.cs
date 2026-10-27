using System;

namespace OOP_Lab9
{
    // ==========================================================================
    // ЗАГАЛЬНЕ ТА ДОМАШНЄ ЗАВДАННЯ: Клас Point з перевантаженням операторів
    // ==========================================================================
    public class Point
    {
        public int X { get; set; }
        public int Y { get; set; }

        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }

        // 1. ЗАГАЛЬНЕ ЗАВДАННЯ: Перевантаження бінарного оператора + (додавання координат двох точок)
        public static Point operator + (Point p1, Point p2)
        {
            return new Point(p1.X + p2.X, p1.Y + p2.Y);
        }

        // 2. ЗАГАЛЬНЕ ЗАВДАННЯ: Перевантаження оператора порівняння ==
        public static bool operator == (Point p1, Point p2)
        {
            // Перевірка на null, щоб уникнути помилок
            if (ReferenceEquals(p1, null))
            {
                return ReferenceEquals(p2, null);
            }
            if (ReferenceEquals(p2, null))
            {
                return false;
            }

            return p1.X == p2.X && p1.Y == p2.Y;
        }

        // 3. ЗАГАЛЬНЕ ЗАВДАННЯ: Перевантаження оператора порівняння != (Обов'язкова парність)
        public static bool operator != (Point p1, Point p2)
        {
            return !(p1 == p2);
        }

        // 4. ДОМАШНЄ ЗАВДАННЯ: Перевантаження оператора * (множення координат точки на скалярне число)
        public static Point operator * (Point p, int scalar)
        {
            return new Point(p.X * scalar, p.Y * scalar);
        }

        // Перевизначення Equals та GetHashCode для повної відповідності стандартам C#
        public override bool Equals(object obj)
        {
            Point p = obj as Point;
            if (p == null) return false;
            return this == p;
        }

        public override int GetHashCode()
        {
            return X.GetHashCode() ^ Y.GetHashCode();
        }

        // Зручний метод для виведення точки на екран
        public void Print(string label)
        {
            Console.WriteLine(label + " = (" + X + "; " + Y + ")");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("==========================================================================");
            Console.WriteLine(" ОБ'ЄКТНО-ОРІЄНТОВАНЕ ПРОГРАМУВАННЯ // ПРАКТИЧНА РОБОТА №9: OPERATOR OVERLOADING");
            Console.WriteLine("==========================================================================");

            // Створення тестових точок
            Point p1 = new Point(3, 5);
            Point p2 = new Point(2, 4);
            Point p3 = new Point(3, 5);

            Console.WriteLine("--- Початкові точки ---");
            p1.Print("Точка 1");
            p2.Print("Точка 2");
            p3.Print("Точка 3");

            // Тестування оператора +
            Console.WriteLine("\n🔵 --- Тестування оператора + (Додавання точок) ---");
            Point sumResult = p1 + p2;
            sumResult.Print("Результат (Точка 1 + Точка 2)");

            // Тестування операторів порівняння == та !=
            Console.WriteLine("\n📊 --- Тестування операторів порівняння (== та !=) ---");
            Console.WriteLine("Точка 1 == Точка 3? Відповідь: " + (p1 == p3));
            Console.WriteLine("Точка 1 == Точка 2? Відповідь: " + (p1 == p2));
            Console.WriteLine("Точка 1 != Точка 2? Відповідь: " + (p1 != p2));

            // Тестування оператора * (множення на скаляр)
            Console.WriteLine("\n✨ --- Тестування оператора * (Множення на скаляр 3) ---");
            Point multipliedResult = p1 * 3;
            multipliedResult.Print("Результат (Точка 1 * 3)");

            Console.WriteLine("\n==========================================================================");
        }
    }
}
