using System;

namespace OOP_Lab6
{
    // ==========================================================================
    // ЗАГАЛЬНЕ ЗАВДАННЯ: Клас Circle з інкапсуляцією та логікою перевірки
    // ==========================================================================
    public class Circle
    {
        // Переводимо поле в статус прихованого (private)
        private double _radius;

        // Властивість для безпечного зчитування та запису параметра
        public double Radius
        {
            get 
            { 
                return _radius; 
            }
            set
            {
                // Перевірка: якщо введене значення менше або дорівнює нулю
                if (value <= 0)
                {
                    Console.WriteLine("⚠️ Помилка: Радіус кола повинен бути більшим за 0! Значення залишено: " + _radius);
                }
                else
                {
                    _radius = value;
                }
            }
        }

        // Конструктор класу
        public Circle(double initialRadius)
        {
            // Використовуємо властивість, щоб перевірка спрацювала навіть при створенні об'єкта
            Radius = initialRadius;
        }

        // Метод для обчислення площі
        public double CalculateArea()
        {
            return Math.PI * _radius * _radius;
        }
    }

    // ==========================================================================
    // ДОМАШНЄ ЗАВДАННЯ: Клас Student з автоматичними властивостями та перевіркою віку
    // ==========================================================================
    public class Student
    {
        // Автоматичні властивості замість відкритих полів
        public string Name { get; set; }
        public string Group { get; set; }

        // Повноструктурна властивість із закритим полем захисту для віку
        private int _age;
        public int Age
        {
            get 
            { 
                return _age; 
            }
            set
            {
                // Перевірка віку: вік не може бути меншим або дорівнювати 0 (або занадто великим)
                if (value <= 0 || value > 120)
                {
                    Console.WriteLine("⚠️ Помилка: Вказано некоректний вік (" + value + ")! Значення залишено: " + _age);
                }
                else
                {
                    _age = value;
                }
            }
        }

        // Конструктор класу
        public Student(string name, string group, int age)
        {
            Name = name;
            Group = group;
            Age = age; // Викличе блок set з нашою перевіркою
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("==========================================================================");
            Console.WriteLine(" ОБ'ЄКТНО-ОРІЄНТОВАНЕ ПРОГРАМУВАННЯ // ПРАКТИЧНА РОБОТА №6: ІНКАПСУЛЯЦІЯ");
            Console.WriteLine("==========================================================================");

            // 1. Тестування загального завдання (Клас Circle)
            Console.WriteLine("\n🔵 --- Тестування класу Circle ---");
            Circle myCircle = new Circle(5.0);
            Console.WriteLine("Поточний радіус: " + myCircle.Radius);
            Console.WriteLine("Площа кола: " + myCircle.CalculateArea().ToString("F2"));

            Console.WriteLine("\nСпроба встановити некоректний радіус (-2.5):");
            myCircle.Radius = -2.5; // Має вивести помилку
            Console.WriteLine("Радіус після спроби зміни: " + myCircle.Radius);

            Console.WriteLine("\nСпроба встановити коректний радіус (10.0):");
            myCircle.Radius = 10.0;
            Console.WriteLine("Новий радіус: " + myCircle.Radius);


            // 2. Тестування домашнього завдання (Клас Student)
            Console.WriteLine("\n🧑‍🎓 --- Тестування класу Student ---");
            Student student = new Student("Олена Коваль", "КІ-23", 18);
            Console.WriteLine("Студент: " + student.Name + ", Група: " + student.Group + ", Вік: " + student.Age);

            Console.WriteLine("\nСпроба встановити некоректний вік (-5):");
            student.Age = -5; // Має вивести помилку
            Console.WriteLine("Вік студента після спроби: " + student.Age);

            Console.WriteLine("\nСпроба встановити коректний вік (19):");
            student.Age = 19;
            Console.WriteLine("Новий вік студента: " + student.Age);

            Console.WriteLine("\n==========================================================================");
        }
    }
}

