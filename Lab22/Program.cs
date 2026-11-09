using System;

namespace PracticalWork22
{
    // ==========================================
    // ТИПИ ДЛЯ ЗАГАЛЬНОГО ЗАВДАННЯ
    // ==========================================

    // Структура (значущий тип)
    public struct StructPoint
    {
        public int X { get; set; }
        public int Y { get; set; }

        // Домашнє завдання: Реалізувати всередині структури конструктор з параметрами
        public StructPoint(int x, int y)
        {
            X = x;
            Y = y;
        }
    }

    // Клас (посилальний тип)
    public class Point
    {
        public int X { get; set; }
        public int Y { get; set; }

        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }
    }

    // ==========================================
    // ТОЧКА ВХОДУ (ГОЛОВНИЙ КЛАС ПРОГРАМИ)
    // ==========================================
    class Program
    {
        static void Main(string[] args)
        {
            // ------------------------------------------
            // ВИКОНАННЯ ЗАГАЛЬНОГО ЗАВДАННЯ
            // ------------------------------------------
            Console.WriteLine("=== ЗАГАЛЬНЕ ЗАВДАННЯ ===");

            // 1. Демонстрація копіювання для СТРУКТУРИ (значущий тип)
            StructPoint struct1 = new StructPoint(10, 20);
            StructPoint struct2 = struct1; // Відбувається повне КОРІЮВАННЯ значень

            struct2.X = 999; // Зміна другої структури не впливає на першу

            Console.WriteLine("Поведінка СТРУКТУРИ (StructPoint):");
            Console.WriteLine($"struct1.X: {struct1.X} (залишилося без змін)");
            Console.WriteLine($"struct2.X: {struct2.X} (змінено)");

            // 2. Демонстрація копіювання для КЛАСУ (посилальний тип)
            Point class1 = new Point(10, 20);
            Point class2 = class1; // Копіюється лише ПОСИЛАННЯ на один і той самий об'єкт

            class2.X = 999; // Зміна через другу змінну міняє дані в тому ж об'єкті

            Console.WriteLine("\nПоведінка КЛАСУ (Point):");
            Console.WriteLine($"class1.X: {class1.X} (ЗМІНИЛОСЯ, бо посилання однакові)");
            Console.WriteLine($"class2.X: {class2.X}");


            // ------------------------------------------
            // ВИКОНАННЯ ДОМАШНЬОГО ЗАВДАННЯ
            // ------------------------------------------
            Console.WriteLine("\n=== ДОМАШНЄ ЗАВДАННЯ ===");

            // Перевірка створеного конструктора з параметрами:
            StructPoint initialPoint = new StructPoint(5, 5);
            Console.WriteLine($"Успішно створено StructPoint через конструктор з параметрами: X={initialPoint.X}, Y={initialPoint.Y}");

            // Фіксація обмеження на конструктор без параметрів для старих версій мови C# (до C# 10)
            Console.WriteLine("\nАналіз обмежень старих версій мови C#:");
            Console.WriteLine("-> Помилка компіляції у старих версіях: CS0568 'Structs cannot contain explicit parameterless constructors'");
            Console.WriteLine("-> Пояснення: У старих версіях мови C# було суворо заборонено явно створювати конструктор без параметрів 'public StructPoint()'");
            Console.WriteLine("   всередині структур, оскільки структура завжди автоматично ініціалізувала поля нулями.");
        }
    }
}
