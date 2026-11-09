using System;
using System.Collections.Generic;

namespace PracticalWork23
{
    // Клас співробітника для збереження інформації
    public class Employee
    {
        public string Name { get; set; }
        public string Position { get; set; }

        public Employee(string name, string position)
        {
            Name = name;
            Position = position;
        }

        public override string ToString()
        {
            return $"Ім'я: {Name,-12} | Посада: {Position}";
        }
    }

    class Program
    {
        // Квадратні дужки для масиву рядків додано коректно
        static void Main(string[] args)
        {
            // Створюємо узагальнений словник Dictionary<TKey, TValue>
            Dictionary<int, Employee> employeeDictionary = new Dictionary<int, Employee>();

            // Додаємо початкові елементи для зручності тестування
            employeeDictionary.Add(101, new Employee("Іван Петренко", "Розробник"));
            employeeDictionary.Add(102, new Employee("Марія Сидорчук", "Дизайнер"));

            bool isRunning = true;
            while (isRunning)
            {
                Console.WriteLine("\n=== МЕНЮ СЛОВНИКА СПІВРОБІТНИКІВ ===");
                Console.WriteLine("1. Додати нового співробітника (Загальне завдання)");
                Console.WriteLine("2. Пошук інформації за табельним номером (Загальне завдання)");
                Console.WriteLine("3. Видалити співробітника за номером (Домашнє завдання)");
                Console.WriteLine("4. Вивести повний список працівників (Домашнє завдання)");
                Console.WriteLine("0. Вихід з програми");
                Console.Write("Виберіть дію: ");
                
                string choice = Console.ReadLine() ?? "";
                switch (choice)
                {
                    case "1":
                        Console.Write("Введіть унікальний табельний номер (int): ");
                        if (int.TryParse(Console.ReadLine(), out int newId))
                        {
                            if (employeeDictionary.ContainsKey(newId))
                            {
                                Console.WriteLine("Помилка! Співробітник з таким номером вже існує.");
                            }
                            else
                            {
                                Console.Write("Введіть ім'я працівника: ");
                                string name = Console.ReadLine() ?? "Без імені";
                                Console.Write("Введіть посаду працівника: ");
                                string position = Console.ReadLine() ?? "Без посади";

                                employeeDictionary.Add(newId, new Employee(name, position));
                                Console.WriteLine("Співробітника успішно додано до словника!");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Некоректний формат номера!");
                        }
                        break;

                    case "2":
                        Console.Write("Введіть табельний номер для пошуку: ");
                        if (int.TryParse(Console.ReadLine(), out int searchId))
                        {
                            if (employeeDictionary.TryGetValue(searchId, out Employee emp))
                            {
                                Console.WriteLine($"Знайдено працівника: {emp}");
                            }
                            else
                            {
                                Console.WriteLine("Працівника з таким табельним номером не знайдено.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Некоректний формат номера!");
                        }
                        break;

                    case "3":
                        Console.Write("Введіть табельний номер для видалення: ");
                        if (int.TryParse(Console.ReadLine(), out int deleteId))
                        {
                            if (employeeDictionary.Remove(deleteId))
                            {
                                Console.WriteLine($"Співробітника з номером {deleteId} успішно видалено.");
                            }
                            else
                            {
                                Console.WriteLine("Працівника з таким номером не знайдено в словнику.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Некоректний формат номера!");
                        }
                        break;

                    case "4":
                        Console.WriteLine("\n=== ПОВНИЙ СПИСОК ПРАЦІВНИКІВ ===");
                        if (employeeDictionary.Count == 0)
                        {
                            Console.WriteLine("Словник порожній.");
                        }
                        else
                        {
                            foreach (KeyValuePair<int, Employee> kvp in employeeDictionary)
                            {
                                Console.WriteLine($"ID: {kvp.Key,-5} | {kvp.Value}");
                            }
                        }
                        break;

                    case "0":
                        isRunning = false;
                        Console.WriteLine("Програму завершено.");
                        break;

                    default:
                        Console.WriteLine("Невірний вибір, спробуйте ще раз.");
                        break;
                }
            }
        }
    }
}
