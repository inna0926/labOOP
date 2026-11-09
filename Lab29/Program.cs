using System;
using System.IO;

namespace PracticalWork29
{
    class Program
    {
        static void Main(string[] args)
        {
            // Визначаємо шлях до папки за допомогою класу Path
            string targetDirectory = Path.Combine(Directory.GetCurrentDirectory(), "OOP_Practice");

            // ------------------------------------------
            // ВИКОНАННЯ ДОМАШНЬОГО ЗАВДАННЯ (ПЕРЕВІРКА ІСНУВАННЯ)
            // ------------------------------------------
            Console.WriteLine("=== ПЕРЕВІРКА ДИРЕКТОРІЇ (Домашнє завдання) ===");
            
            if (Directory.Exists(targetDirectory))
            {
                // Повідомлення, якщо папка вже є на диску (ДЗ)
                Console.WriteLine($"Інформаційне повідомлення: Папка за шляхом '{targetDirectory}' вже існує на диску. Повторне створення скасовано.\n");
            }
            else
            {
                // Якщо папки немає — створюємо її
                Directory.CreateDirectory(targetDirectory);
                Console.WriteLine($"[СИСТЕМА]: Створено нову папку: {targetDirectory}\n");
            }

            // ------------------------------------------
            // ВИКОНАННЯ ЗАГАЛЬНОГО ЗАВДАННЯ (ФАЙЛОВА СТРУКТУРА)
            // ------------------------------------------
            Console.WriteLine("=== ЗАГАЛЬНЕ ЗАВДАННЯ (Робота з File та Directory) ===");

            // Генеруємо шляхи для трьох порожніх файлів всередині папки
            string file1 = Path.Combine(targetDirectory, "test1.txt");
            string file2 = Path.Combine(targetDirectory, "test2.txt");
            string file3 = Path.Combine(targetDirectory, "test3.txt");

            // Створюємо порожні текстові файли за допомогою класу File
            // Використовуємо Close(), щоб файли не залишалися заблокованими в пам'яті
            File.Create(file1).Close();
            File.Create(file2).Close();
            File.Create(file3).Close();
            Console.WriteLine("[СИСТЕМА]: Успішно згенеровано 3 порожні текстові файли.\n");

            // Зчитуємо список усіх файлів у цій директорії
            string[] files = Directory.GetFiles(targetDirectory);

            Console.WriteLine($"Список файлів у директорії '{Path.GetFileName(targetDirectory)}':");
            foreach (string filePath in files)
            {
                // Отримуємо тільки ім'я файлу
                string fileName = Path.GetFileName(filePath);
                
                // Зчитуємо час створення файлу
                DateTime creationTime = Directory.GetCreationTime(filePath);

                // Виводимо назву та час створення в консоль
                Console.WriteLine($"-> Файл: {fileName,-12} | Час створення: {creationTime}");
            }
        }
    }
}
