using System;
using System.Collections.Generic;

namespace PracticalWork26
{
    class Program
    {
        // Метод фільтрації для Загального завдання
        public static List<int> FilterNumbers(List<int> numbers, Predicate<int> match)
        {
            List<int> result = new List<int>();
            foreach (int num in numbers)
            {
                if (match(num))
                {
                    result.Add(num);
                }
            }
            return result;
        }

        // Методи для Домашнього завдання
        public static double Multiply(double a, double b)
        {
            return a * b;
        }

        public static void ProcessArray(double[] array, Func<double, double, double> operation, double value)
        {
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = operation(array[i], value);
            }
        }

        static void Main(string[] args)
        {
            // === ЗАГАЛЬНЕ ЗАВДАННЯ ===
            Console.WriteLine("=== ЗАГАЛЬНЕ ЗАВДАННЯ (Делегат Predicate) ===");

            List<int> intList = new List<int> { -5, -2, 0, 3, 4, 7, 8, 12, -1 };
            Console.WriteLine("Початковий список чисел: " + string.Join(", ", intList));

            List<int> evenNumbers = FilterNumbers(intList, x => x % 2 == 0);
            Console.WriteLine("Відфільтровані парні числа: " + string.Join(", ", evenNumbers));

            List<int> positiveNumbers = FilterNumbers(intList, x => x > 0);
            Console.WriteLine("Відфільтровані додатні числа: " + string.Join(", ", positiveNumbers));

            // === ДОМАШНЄ ЗАВДАННЯ ===
            Console.WriteLine("\n=== ДОМАШНЄ ЗАВДАННЯ (Делегат Func) ===");

            double[] doubleArray = new double[] { 2.0, 4.0, 6.0, 8.0 };
            Console.WriteLine("Початковий масив чисел: " + string.Join(", ", doubleArray));

            Func<double, double, double> funcOperation = Multiply;
            ProcessArray(doubleArray, funcOperation, 3.0);

            Console.WriteLine("Масив після обробки через Func (кожне число помножено на 3):");
            Console.WriteLine(string.Join(", ", doubleArray));
        }
    }
}
