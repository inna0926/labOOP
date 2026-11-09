using System;
using System.IO;

namespace PracticalWork25
{
    // Оголошуємо делегат типу void, який приймає рядок повідомлення (Загальне завдання)
    public delegate void Logger(string message);

    class Program
    {
        // --- МЕТОДИ ДЛЯ ЛОГУВАННЯ (ЗАГАЛЬНЕ ЗАВДАННЯ) ---

        // 1. Виведення повідомлення в консоль білим кольором
        public static void LogToConsoleWhite(string message)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine($"[КОНСОЛЬ БІЛИЙ]: {message}");
            Console.ResetColor();
        }

        // 2. Виведення повідомлення червоним кольором (як помилка)
        public static void LogToConsoleRed(string message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"[КОНСОЛЬ ЧЕРВОНИЙ | ПОМИЛКА]: {message}");
            Console.ResetColor();
        }

        // 3. Запис повідомлення у файл (та імітація для онлайн-компілятора)
        public static void LogToFile(string message)
        {
            try
            {
                string fileName = "log.txt";
                File.AppendAllText(fileName, $"[ФАЙЛ]: {message}" + Environment.NewLine);
                Console.WriteLine($"[СИСТЕМА]: Повідомлення успішно записано у файл '{fileName}'.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[СИСТЕМА ПОМИЛКА]: Не вдалося записати у файл ({ex.Message}).");
            }
        }

        // Головна точка входу з виправленими квадратними дужками
        static void Main(string[] args)
        {
            // ------------------------------------------
            // ВИКОНАННЯ ЗАГАЛЬНОГО ЗАВДАННЯ
            // ------------------------------------------
            Console.WriteLine("=== ЗАГАЛЬНЕ ЗАВДАННЯ (Багатоадресні делегати) ===");

            // Створюємо багатоадресний делегат, об'єднуючи методи за допомогою оператора '+'
            Logger myLogger = LogToConsoleWhite;
            myLogger += LogToConsoleRed;
            myLogger += LogToFile;

            Console.WriteLine("Виклик ланцюжка делегата з трьох методів:");
            myLogger("Систему успішно запущено.");

            // ------------------------------------------
            // ВИКОНАННЯ ДОМАШНЬОГО ЗАВДАННЯ
            // ------------------------------------------
            Console.WriteLine("\n=== ДОМАШНЄ ЗАВДАННЯ (Вилучення методу з ланцюжка) ===");

            Console.WriteLine("Вилучаємо метод червоного логування (LogToConsoleRed) за допомогою оператора '-'...");
            
            // Видаляємо один із методів із ланцюжка викликів безпечним способом
            myLogger -= LogToConsoleRed;

            // Перевіряємо, чи ланцюжок не порожній, перед викликом
            if (myLogger != null)
            {
                Console.WriteLine("Виклик оновленого ланцюжка делегата (має залишитися лише білий колір та файл):");
                myLogger("Нове тестове повідомлення після зміни ланцюжка.");
            }
        }
    }
}
