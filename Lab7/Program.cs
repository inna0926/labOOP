using System;

namespace OOP_Lab7
{
    // ==========================================================================
    // ЗАГАЛЬНЕ ЗАВДАННЯ: Модернізований клас Student зі статичним лічильником
    // ==========================================================================
    public class Student
    {
        // Приховане статичне поле-лічильник (належить самому класу, а не окремим студентам)
        private static int _studentCount = 0;

        // Звичайні властивості об'єкта
        public string Name { get; set; }
        public string Group { get; set; }

        // Конструктор класу
        public Student(string name, string group)
        {
            Name = name;
            Group = group;
            
            // Збільшуємо лічильник при створенні кожного нового об'єкта (інкремент)
            _studentCount++;
        }

        // Статичний метод для отримання поточного значення лічильника
        public static int GetStudentCount()
        {
            return _studentCount;
        }
    }

    // ==========================================================================
    // ДОМАШНЄ ЗАВДАННЯ: Утилітарний статичний клас MathUtils
    // ==========================================================================
    public static class MathUtils
    {
        // Статичний метод для обчислення факторіала числа
        public static long CalculateFactorial(int n)
        {
            if (n < 0)
            {
                Console.WriteLine("⚠️ Помилка: Факторіал не існує для від'ємних чисел!");
                return -1;
            }

            long factorial = 1;
            for (int i = 1; i <= n; i++)
            {
                factorial *= i;
            }
            return factorial;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("==========================================================================");
            Console.WriteLine(" ОБ'ЄКТНО-ОРІЄНТОВАНЕ ПРОГРАМУВАННЯ // ПРАКТИЧНА РОБОТА №7: STATIC");
            Console.WriteLine("==========================================================================");

            // 1. Тестування лічильника об'єктів (Клас Student)
            Console.WriteLine("\n🔵 --- Тестування статичного лічильника ---");
            Console.WriteLine("Початкова кількість студентів: " + Student.GetStudentCount());

            Console.WriteLine("Створюємо трьох студентів...");
            Student s1 = new Student("Іван Петренко", "КI-23-1");
            Student s2 = new Student("Марія Коваль", "КI-23-2");
            Student s3 = new Student("Олексій Шевченко", "КI-23-1");

            // Виводимо фінальне число у методі Main
            Console.WriteLine("📌 Фінальна кількість створених студентів: " + Student.GetStudentCount());


            // 2. Тестування утилітарного класу (Клас MathUtils)
            Console.WriteLine("\n📊 --- Тестування статичного класу MathUtils ---");
            int number = 5;
            long factResult = MathUtils.CalculateFactorial(number);
            Console.WriteLine("Факторіал числа " + number + "! дорівнює: " + factResult);

            int numberZero = 0;
            Console.WriteLine("Факторіал числа " + numberZero + "! дорівнює: " + MathUtils.CalculateFactorial(numberZero));

            Console.WriteLine("\n==========================================================================");
        }
    }
}
