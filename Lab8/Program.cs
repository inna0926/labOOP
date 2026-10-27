using System;

namespace OOP_Lab8
{
    // ==========================================================================
    // ЗАГАЛЬНЕ ЗАВДАННЯ: Клас Rectangle та пошук максимальної площі
    // ==========================================================================
    public class Rectangle
    {
        public double Width { get; set; }
        public double Height { get; set; }

        public Rectangle(double width, double height)
        {
            Width = width;
            Height = height;
        }

        // Метод для обчислення площі
        public double CalculateArea()
        {
            return Width * Height;
        }
    }

    // ==========================================================================
    // ДОМАШНЄ ЗАВДАННЯ: Клас Student та сортування за середнім балом
    // ==========================================================================
    public class Student
    {
        public string Name { get; set; }
        public double AverageGrade { get; set; }

        public Student(string name, double averageGrade)
        {
            Name = name;
            AverageGrade = averageGrade;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("==========================================================================");
            Console.WriteLine(" ОБ'ЄКТНО-ОРІЄНТОВАНЕ ПРОГРАМУВАННЯ // ПРАКТИЧНА РОБОТА №8: МАСИВИ ОБ'ЄКТІВ");
            Console.WriteLine("==========================================================================");

            // ----------------------------------------------------------------------
            // 1. ТЕСТУВАННЯ ЗАГАЛЬНОГО ЗАВДАННЯ (Rectangle)
            // ----------------------------------------------------------------------
            Console.WriteLine("\n🔵 --- Загальне завдання: Масив Rectangle (5 об'єктів) ---");
            
            // Створення масиву з 5 прямокутників із заздалегідь визначеними параметрами
            Rectangle[] rectangles = new Rectangle[5];
            rectangles[0] = new Rectangle(3.0, 4.0);   // Площа: 12
            rectangles[1] = new Rectangle(5.0, 5.0);   // Площа: 25
            rectangles[2] = new Rectangle(2.0, 10.0);  // Площа: 20
            rectangles[3] = new Rectangle(6.0, 7.0);   // Площа: 42 (Найбільша)
            rectangles[4] = new Rectangle(4.5, 4.0);   // Площа: 18

            // Алгоритм пошуку прямокутника з найбільшою площою
            Rectangle maxRectangle = rectangles[0];
            for (int i = 1; i < rectangles.Length; i++)
            {
                if (rectangles[i].CalculateArea() > maxRectangle.CalculateArea())
                {
                    maxRectangle = rectangles[i];
                }
            }

            Console.WriteLine("📐 Прямокутник з найбільшою площею:");
            Console.WriteLine("Ширина: " + maxRectangle.Width + ", Висота: " + maxRectangle.Height);
            Console.WriteLine("📊 Максимальна площа: " + maxRectangle.CalculateArea());

            // ----------------------------------------------------------------------
            // 2. ТЕСТУВАННЯ ДОМАШНЬОГО ЗАВДАННЯ (Сортування студентів)
            // ----------------------------------------------------------------------
            Console.WriteLine("\n🧑‍🎓 --- Домашнє завдання: Сортування студентів за балом (спадання) ---");

            // Створення масиву студентів
            Student[] students = new Student[4];
            students[0] = new Student("Олена", 4.2);
            students[1] = new Student("Ігор", 4.9);
            students[2] = new Student("Анна", 3.8);
            students[3] = new Student("Дмитро", 4.5);

            Console.WriteLine("Початковий список:");
            for (int i = 0; i < students.Length; i++)
            {
                Console.WriteLine("- " + students[i].Name + ": " + students[i].AverageGrade);
            }

            // Просте сортування методом бульбашки за спаданням балу
            for (int i = 0; i < students.Length - 1; i++)
            {
                for (int j = 0; j < students.Length - i - 1; j++)
                {
                    if (students[j].AverageGrade < students[j + 1].AverageGrade)
                    {
                        // Обмін елементів місцями
                        Student temp = students[j];
                        students[j] = students[j + 1];
                        students[j + 1] = temp;
                    }
                }
            }

            Console.WriteLine("\n📋 Відсортований список (від найвищого балу до найнижчого):");
            for (int i = 0; i < students.Length; i++)
            {
                Console.WriteLine((i + 1) + ". " + students[i].Name + " — Середній бал: " + students[i].AverageGrade);
            }

            Console.WriteLine("\n==========================================================================");
        }
    }
}
