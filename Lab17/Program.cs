using System;

namespace PracticalWork17
{
    // ==========================================
    // === ЗАГАЛЬНЕ ЗАВДАННЯ ===
    // ==========================================

    // Оголошуємо клас Rectangle як sealed (закритий для успадкування)
    public sealed class Rectangle
    {
        public double Width { get; set; }
        public double Height { get; set; }

        public Rectangle(double width, double height)
        {
            Width = width;
            Height = height;
        }
    }

    // Спроба створити новий клас Square, який успадковує Rectangle.
    // ЦЕЙ КОД ЗАКОМЕНТОВАНО, ЩОБ ПРОГРАМА ЗМОГЛА СКОМПІЛЮВАТИСЯ ТА ЗАПУСТИТИСЯ.
    /*
    public class Square : Rectangle
    {
        public Square(double side) : base(side, side) { }
    }
    */

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== ЗАГАЛЬНЕ ЗАВДАННЯ ===");
            Console.WriteLine("Спроба створити 'class Square : Rectangle' викликає помилку:");
            
            // Фіксуємо текст помилки компілятора C# відповідно до завдання
            Console.WriteLine("-> Помилка компіляції: CS0509 'Square': cannot derive from sealed type 'Rectangle'");
        }
    }
}
