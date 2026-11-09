using System;
using System.Collections.Generic;

namespace PracticalWork27
{
    // Клас Product для представлення товарів
    public class Product
    {
        public string Name { get; set; }
        public double Price { get; set; }

        public Product(string name, double price)
        {
            Name = name;
            Price = price;
        }

        public override string ToString()
        {
            return $"Товар: {Name,-10} | Ціна: {Price:F2} грн.";
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Створюємо початковий список об'єктів класу Product
            List<Product> products = new List<Product>
            {
                new Product("Ноутбук", 25000.0),
                new Product("Мишка", 450.0),
                new Product("Клавіатура", 1200.0),
                new Product("Монітор", 6800.0),
                new Product("Навушники", 1500.0)
            };

            // ------------------------------------------
            // ВИКОНАННЯ ЗАГАЛЬНОГО ЗАВДАННЯ
            // ------------------------------------------
            Console.WriteLine("=== ЗАГАЛЬНЕ ЗАВДАННЯ (Фільтрація через FindAll та лямбда) ===");
            Console.WriteLine("Початковий список товарів:");
            PrintList(products);

            // Задаємо діапазон цін
            double minPrice = 1000.0;
            double maxPrice = 10000.0;
            Console.WriteLine($"\nВідбір товарів у діапазоні цін від {minPrice} до {maxPrice} грн:");

            // Використовуємо вбудований метод FindAll та лямбда-вираз для фільтрації
            List<Product> filteredProducts = products.FindAll(p => p.Price >= minPrice && p.Price <= maxPrice);
            PrintList(filteredProducts);


            // ------------------------------------------
            // ВИКОНАННЯ ДОМАШНЬОГО ЗАВДАННЯ
            // ------------------------------------------
            Console.WriteLine("\n=== ДОМАШНЄ ЗАВДАННЯ (Сортування за алфавітом через лямбда) ===");

            // Використовуємо метод Sort та лямбда-вираз для порівняння назв товарів за алфавітом
            products.Sort((p1, p2) => string.Compare(p1.Name, p2.Name, StringComparison.Ordinal));

            Console.WriteLine("Список усіх товарів після сортування ЗА НАЗВОЮ:");
            PrintList(products);
        }

        // Допоміжний метод для виведення списку в консоль
        static void PrintList(List<Product> list)
        {
            if (list.Count == 0)
            {
                Console.WriteLine("Товарів не знайдено.");
                return;
            }
            foreach (var item in list)
            {
                Console.WriteLine(item);
            }
        }
    }
}
