using System;

namespace OOP_Lab10
{
    // ==========================================================================
    // БАЗОВИЙ КЛАС: Персона (загальні поля для всіх людей)
    // ==========================================================================
    public class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }

        public Person(string name, int age)
        {
            Name = name;
            Age = age;
        }

        public virtual void PrintInfo()
        {
            Console.WriteLine("Ім'я: " + Name + ", Вік: " + Age);
        }
    }

    // ==========================================================================
    // ЗАГАЛЬНЕ ЗАВДАННЯ: Похідний клас Студент (наслідує Person)
    // ==========================================================================
    public class Student : Person
    {
        public string Faculty { get; set; }
        public int Course { get; set; }

        // Конструктор викликає базовий конструктор за допомогою : base()
        public Student(string name, int age, string faculty, int course) : base(name, age)
        {
            Faculty = faculty;
            Course = course;
        }

        // Перевизначення методу виведення інформації
        public override void PrintInfo()
        {
            Console.WriteLine("🧑‍🎓 Студент -> Ім'я: " + Name + ", Вік: " + Age + 
                              ", Факультет: " + Faculty + ", Курс: " + Course);
        }
    }

    // ==========================================================================
    // ДОМАШНЄ ЗАВДАННЯ: Похідний клас Викладач (наслідує Person)
    // ==========================================================================
    public class Teacher : Person
    {
        public string Department { get; set; } // кафедра
        public double Salary { get; set; }     // заробітна плата

        // Конструктор викликає базовий конструктор за допомогою : base()
        public Teacher(string name, int age, string department, double salary) : base(name, age)
        {
            Department = department;
            Salary = salary;
        }

        // Перевизначення методу виведення інформації
        public override void PrintInfo()
        {
            Console.WriteLine("👨‍🏫 Викладач -> Ім'я: " + Name + ", Вік: " + Age + 
                              ", Кафедра: " + Department + ", Зарплата: " + Salary + " грн");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("==========================================================================");
            Console.WriteLine(" ОБ'ЄКТНО-ОРІЄНТОВАНЕ ПРОГРАМУВАННЯ // ПРАКТИЧНА РОБОТА №10: INHERITANCE");
            Console.WriteLine("==========================================================================");

            // 1. Створення об'єкта базового класу
            Console.WriteLine("\n🔴 --- Створення об'єкта базового класу Person ---");
            Person genericPerson = new Person("Андрій", 30);
            genericPerson.PrintInfo();

            // 2. Тестування загального завдання (Клас Student)
            Console.WriteLine("\n🔵 --- Загальне завдання: Об'єкт класу Student ---");
            Student student = new Student("Максим", 19, "Інформаційні технології", 2);
            student.PrintInfo();

            // 3. Тестування домашнього завдання (Клас Teacher)
            Console.WriteLine("\n✨ --- Домашнє завдання: Об'єкт класу Teacher ---");
            Teacher teacher = new Teacher("Дмитро Іванович", 45, "Кафедра комп'ютерних наук", 18500.50);
            teacher.PrintInfo();

            Console.WriteLine("\n==========================================================================");
        }
    }
}
