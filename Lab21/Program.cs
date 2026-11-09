using System;

namespace PracticalWork21
{
    // ==========================================
    // КЛАСИ ДЛЯ ЗАГАЛЬНОГО ЗАВДАННЯ
    // ==========================================
    
    // Клас Student, який реалізує стандартний інтерфейс IComparable
    public class Student : IComparable
    {
        public string Name { get; set; }
        public double AverageGrade { get; set; }

        public Student(string name, double averageGrade)
        {
            Name = name;
            AverageGrade = averageGrade;
        }

        // Реалізація порівняння за середнім балом (Загальне завдання)
        public int CompareTo(object? obj)
        {
            if (obj == null) return 1;

            if (obj is Student otherStudent)
            {
                return this.AverageGrade.CompareTo(otherStudent.AverageGrade);
            }
            else
            {
                throw new ArgumentException("Об'єкт не є екземпляром класу Student");
            }
        }

        public override string ToString()
        {
            return $"Студент: {Name,-10} | Середній бал: {AverageGrade:F1}";
        }
    }

    // ==========================================
    // КЛАСИ ДЛЯ ДОМАШНЬОГО ЗАВДАННЯ (ДЗ)
    // ==========================================
    
    // Спеціальний компаратор для зміни логіки порівняння на сортування за алфавітом імені
    public class StudentByNameComparer : System.Collections.IComparer
    {
        public int Compare(object? x, object? y)
        {
            if (x is Student s1 && y is Student s2)
            {
                return string.Compare(s1.Name, s2.Name, StringComparison.Ordinal);
            }
            throw new ArgumentException("Об'єкти повинні бути типу Student");
        }
    }

    // ==========================================
    // ТОЧКА ВХОДУ (ГОЛОВНИЙ КЛАС ПРОГРАМИ)
    // ==========================================
    class Program
    {
        // Квадратні дужки додано для коректної сигнатури точки входу
        static void Main(string[] args)
        {
            // Створюємо масив студентів для першої частини (Загальне завдання)
            Student[] studentsForGeneral = new Student[]
            {
                new Student("Іван", 4.5),
                new Student("Марія", 4.9),
                new Student("Олег", 3.8),
                new Student("Анна", 4.2)
            };

            // Створюємо окремий масив студентів для другої частини (ДЗ)
            Student[] studentsForHomework = new Student[]
            {
                new Student("Іван", 4.5),
                new Student("Марія", 4.9),
                new Student("Олег", 3.8),
                new Student("Анна", 4.2)
            };

            // ------------------------------------------
            // ВИКОНАННЯ ЗАГАЛЬНОГО ЗАВДАННЯ
            // ------------------------------------------
            Console.WriteLine("=== ЗАГАЛЬНЕ ЗАВДАННЯ ===");
            Console.WriteLine("Початковий список студентів:");
            PrintStudents(studentsForGeneral);

            // Автоматичне сортування за допомогою Array.Sort (використовує IComparable за середнім балом)
            Array.Sort(studentsForGeneral);

            Console.WriteLine("\nРезультат сортування за середнім балом:");
            PrintStudents(studentsForGeneral);

            // ------------------------------------------
            // ВИКОНАННЯ ДОМАШНЬОГО ЗАВДАННЯ
            // ------------------------------------------
            Console.WriteLine("\n=== ДОМАШНЄ ЗАВДАННЯ ===");
            Console.WriteLine("Початковий список студентів (до зміни логіки):");
            PrintStudents(studentsForHomework);

            // Сортування за новою логікою (за алфавітом імен) за допомогою компаратора
            Array.Sort(studentsForHomework, new StudentByNameComparer());

            Console.WriteLine("\nРезультат сортування за алфавітом імені студента:");
            PrintStudents(studentsForHomework);
        }

        static void PrintStudents(Student[] array)
        {
            foreach (var student in array)
            {
                Console.WriteLine(student);
            }
        }
    }
}

