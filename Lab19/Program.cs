using System;

namespace PracticalWork19
{
    // ==========================================
    // 1. ІНТЕРФЕЙСИ ТА КЛАСИ ДЛЯ ЗАГАЛЬНОГО ЗАВДАННЯ
    // ==========================================

    // Інтерфейс для малювання
    public interface IDrawable
    {
        void Draw();
    }

    // Інтерфейс для масштабування
    public interface IScalable
    {
        void Scale(double factor);
    }

    // Клас Rectangle, який реалізує інтерфейси загального завдання
    public class Rectangle : IDrawable, IScalable
    {
        public double Width { get; protected set; }
        public double Height { get; protected set; }

        public Rectangle(double width, double height)
        {
            Width = width;
            Height = height;
        }

        public void Draw()
        {
            Console.WriteLine($"[Rectangle] Малюємо прямокутник розміром {Width} x {Height}.");
        }

        public void Scale(double factor)
        {
            Width *= factor;
            Height *= factor;
            Console.WriteLine($"[Rectangle] Масштабовано в {factor} раз(ів). Новий розмір: {Width} x {Height}.");
        }
    }

    // ==========================================
    // 2. ІНТЕРФЕЙС ТА КЛАС ДЛЯ ДОМАШНЬОГО ЗАВДАННЯ
    // ==========================================

    // Інтерфейс для збереження унікального текстового коду об'єкта
    public interface IIdentifiable
    {
        string Id { get; }
    }

    // Спеціальний клас для ДЗ, який реалізує новий інтерфейс
    public class IdentifiedRectangle : Rectangle, IIdentifiable
    {
        // Реалізація інтерфейсу з ДЗ
        public string Id { get; }

        public IdentifiedRectangle(string id, double width, double height) : base(width, height)
        {
            Id = id;
        }

        // Перевизначений метод Draw для відображення ID
        public new void Draw()
        {
            Console.WriteLine($"[IdentifiedRectangle | ID: {Id}] Малюємо ідентифікований прямокутник ({Width} x {Height}).");
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
            // ЧАСТИНА 1: ЗАГАЛЬНЕ ЗАВДАННЯ
            // ------------------------------------------
            Console.WriteLine("=== ЧАСТИНА 1: ЗАГАЛЬНЕ ЗАВДАННЯ ===");
            
            // Створюємо звичайний прямокутник
            Rectangle regularRect = new Rectangle(10.0, 5.0);
            
            // Демонструємо виклик методів обох інтерфейсів
            regularRect.Draw();
            regularRect.Scale(2.0);
            regularRect.Draw();


            // ------------------------------------------
            // ЧАСТИНА 2: ДОМАШНЄ ЗАВДАННЯ
            // ------------------------------------------
            Console.WriteLine("\n=== ЧАСТИНА 2: ДОМАШНЄ ЗАВДАННЯ ===");
            
            // Створюємо об'єкт з унікальним текстовим кодом (ID)
            IdentifiedRectangle idRect = new IdentifiedRectangle("RECT-999", 4.0, 4.0);
            
            // Перевіряємо роботу через інтерфейсне посилання
            IIdentifiable identifiableRef = idRect;
            
            Console.WriteLine($"Зчитано унікальний текстовий код об'єкта через інтерфейс: {identifiableRef.Id}");
            idRect.Draw();
        }
    }
}
