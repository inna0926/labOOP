using System;
using System.IO;

namespace PracticalWork30
{
    class Program
    {
        static void Main(string[] args)
        {
            string fileName = "output.txt";

            // ------------------------------------------
            // ВИКОНАННЯ ЗАГАЛЬНОГО ЗАВДАННЯ
            // ------------------------------------------
            Console.WriteLine("=== ЗАГАЛЬНЕ ЗАВДАННЯ (Запис та читання через StreamWriter/StreamReader) ===");
            
            Console.WriteLine("Будь ласка, введіть 5 рядків тексту для запису у файл:");
            string[] linesToWrite = new string[5];
            for (int i = 0; i < 5; i++)
            {
                Console.Write($"Рядок {i + 1}: ");
                linesToWrite[i] = Console.ReadLine() ?? "";
            }

            // Запис рядків у файл за допомогою конструкції using та StreamWriter
            // За замовчуванням файл перезаписується
            using (StreamWriter writer = new StreamWriter(fileName, append: false))
            {
                foreach (string line in linesToWrite)
                {
                    writer.WriteLine(line);
                }
            }
            Console.WriteLine("\n[СИСТЕМА]: 5 рядків успішно записано у файл.");

            // Читання з файлу та виведення в консоль з нумерацією рядків
            Console.WriteLine("\nВміст файлу після виконання ЗАГАЛЬНОГО ЗАВДАННЯ:");
            using (StreamReader reader = new StreamReader(fileName))
            {
                int lineNumber = 1;
                string? line;
                // Цикл працює, поки властивість EndOfStream не стане true
                while (!reader.EndOfStream)
                {
                    line = reader.ReadLine();
                    Console.WriteLine($"{lineNumber}: {line}");
                    lineNumber++;
                }
            }

            // ------------------------------------------
            // ВИКОНАННЯ ДОМАШНЬОГО ЗАВДАННЯ (ДОДАВАННЯ В КІНЕЦЬ)
            // ------------------------------------------
            Console.WriteLine("\n=== ДОМАШНЄ ЗАВДАННЯ (Режим додавання в кінець файлу) ===");
            
            Console.WriteLine("Введіть ще один додатковий рядок, який додасться в кінець файлу:");
            Console.Write("Додатковий рядок: ");
            string additionalLine = Console.ReadLine() ?? "";

            // Налаштовуємо запис у файл так, щоб дані додавалися в кінець (параметр append: true)
            using (StreamWriter appendWriter = new StreamWriter(fileName, append: true))
            {
                appendWriter.WriteLine(additionalLine);
            }
            Console.WriteLine("[СИСТЕМА]: Нові дані успішно додано в кінець файлу без видалення старих.");

            // Повторне зчитування для демонстрації фінального результату
            Console.WriteLine("\nФінальний вміст файлу разом із ДОМАШНІМ ЗАВДАННЯМ:");
            using (StreamReader finalReader = new StreamReader(fileName))
            {
                int lineNumber = 1;
                while (!finalReader.EndOfStream)
                {
                    string? line = finalReader.ReadLine();
                    Console.WriteLine($"{lineNumber}: {line}");
                    lineNumber++;
                }
            }
        }
    }
}
