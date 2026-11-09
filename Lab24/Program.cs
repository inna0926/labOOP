using System;

namespace PracticalWork24
{
    // Оголошуємо делегат (Загальне завдання)
    // Приймає два числа типу double і повертає double
    public delegate double MathOperation(double x, double y);

    class Program
    {
        // --- МЕТОДИ ДЛЯ ЗАГАЛЬНОГО ЗАВДАННЯ ---
        public static double Add(double a, double b) => a + b;
        public static double Subtract(double a, double b) => a - b;
        public static double Multiply(double a, double b) => a * b;
        public static double Divide(double a, double b)
        {
            if (b == 0)
            {
                Console.WriteLine("Помилка: Ділення на нуль!");
                return 0;
            }
            return a / b;
        }

        // --- МЕТОД ДЛЯ ДОМАШНЬОГО ЗАВДАННЯ ---
        // Приймає масив чисел та делегат, застосовуючи його логіку до елементів масиву
        public static void ProcessArray(double[] array, MathOperation operation, double value)
        {
            for (int i = 0; i < array.Length; i++)
            {
                // Застосовуємо логіку делегата до поточного елемента масиву та переданого значення
                array[i] = operation(array[i], value);
            }
        }

        // Головна точка входу
        static void Main(string[] args)
        {
            // ------------------------------------------
            // ВИКОНАННЯ ЗАГАЛЬНОГО ЗАВДАННЯ
            // ------------------------------------------
            Console.WriteLine("=== ЗАГАЛЬНЕ ЗАВДАННЯ ===");

            double num1 = 10.5;
            double num2 = 2.5;

            // Створюємо екземпляр делегата для кожної операції
            MathOperation opAdd = Add;
            MathOperation opSub = Subtract;
            MathOperation opMul = Multiply;
            MathOperation opDiv = Divide;

            // Демонструємо виклик методів через делегат
            Console.WriteLine($"Числа для обробки: {num1} та {num2}");
            Console.WriteLine($"Додавання через делегат: {opAdd(num1, num2)}");
            Console.WriteLine($"Віднімання через делегат: {opSub(num1, num2)}");
            Console.WriteLine($"Множення через делегат: {opMul(num1, num2)}");
            Console.WriteLine($"Ділення через делегат: {opDiv(num1, num2)}");

            // ------------------------------------------
            // ВИКОНАННЯ ДОМАШНЬОГО ЗАВДАННЯ
            // ------------------------------------------
            Console.WriteLine("\n=== ДОМАШНЄ ЗАВДАННЯ ===");

            double[] numbers = { 2.0, 4.0, 6.0, 8.0 };
            Console.WriteLine("Початковий масив чисел: " + string.Join(", ", numbers));

            // Передаємо масив, делегат множення (opMul) та коефіцієнт 3.0
            ProcessArray(numbers, opMul, 3.0);

            Console.WriteLine("Масив після застосування делегата (помножено кожен елемент на 3):");
            Console.WriteLine(string.Join(", ", numbers));
        }
    }
}
