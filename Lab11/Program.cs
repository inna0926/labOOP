using System;

namespace OOP_Lab11
{
    // ==========================================================================
    // БАЗОВИЙ КЛАС: Персона
    // ==========================================================================
    public class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }

        // Конструктор з параметрами у базовому класі
        public Person(string name, int age)
        {
            Name = name;
            Age = age;
        }

        // Віртуальний метод для виведення базової інформації
        public virtual void PrintInfo()
        {
            Console.Write("Ім'я: " + Name + ", Вік: " + Age);
        }
    }

    // ==========================================================================
    // ЗАГАЛЬНЕ ТА ДОМАШНЄ ЗАВДАННЯ: Похідний клас Студент
    // ==========================================================================
    public class Student : Person
    {
        public string Faculty { get; set; }
        public int Course { get; set; }

        // ЗАГАЛЬНЕ ЗАВДАННЯ: Передача імені та віку до конструктора Person через base
        public Student(string name, int age, string faculty, int course) : base(name, age)
        {
            Faculty = faculty;
            Course = course;
        }

        // ДОМАШНЄ ЗАВДАННЯ: Перевизначення методу з викликом базової версії через base
        public override void PrintInfo()
        {
            // Спочатку викликаємо базову версію методу, щоб вивести ім'я та вік
            base.PrintInfo(); 
            
            // Потім дописуємо специфічну інформацію студента
            Console.WriteLine(", Факультет: " + Faculty + ", Курс: " + Course);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("==========================================================================");
            Console.WriteLine(" ОБ'ЄКТНО-ОРІЄНТОВАНЕ ПРОГРАМУВАННЯ // ПРАКТИЧНА РОБОТА №11: KEYWORD BASE");
            Console.WriteLine("==========================================================================");

            Console.WriteLine("\n🔵 --- Створення та виведення об'єкта Student ---");
            
            // Створюємо студента, параметри "Іван" та 20 автоматично підуть у базовий клас Person
            Student student = new Student("Іван", 20, "Комп'ютерні науки", 3);
            
            // Виклик методу, який всередині використовує base.PrintInfo()
            student.PrintInfo();

            Console.WriteLine("\n==========================================================================");
        }
    }
}
