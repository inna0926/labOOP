using System;

namespace PracticalWork16
{
    // Базовий клас Shape (Фігура)
    public class Shape
    {
        public string Name { get; set; } = "Base Shape";
        
        public virtual void Draw()
        {
            Console.WriteLine("Малюємо базову фігуру.");
        }
    }

    // Похідний клас Circle (Коло)
    public class Circle : Shape
    {
        public double Radius { get; private set; } = 5.0;

        public Circle()
        {
            Name = "Circle";
        }

        // Специфічний метод для зміни радіуса
        public void ChangeRadius(double newRadius)
        {
            Radius = newRadius;
            Console.WriteLine($"[Circle] Радіус успішно змінено! Новий радіус: {Radius}");
        }

        public override void Draw()
        {
            Console.WriteLine($"Малюємо коло з радіусом {Radius}.");
        }
    }

    // Інший похідний клас для демонстрації (Квадрат)
    public class Square : Shape
    {
        public Square()
        {
            Name = "Square";
        }

        public override void Draw()
        {
            Console.WriteLine("Малюємо квадрат.");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== ЗАГАЛЬНЕ ЗАВДАННЯ ===");
            ExecuteGeneralTask();
        }

        /// <summary>
        /// Загальне завдання: Обійти масив Shape. Якщо поточний об'єкт є колом (Circle), 
        /// викликати його специфічний метод для зміни радіуса, використовуючи оператори is або as.
        /// </summary>
        static void ExecuteGeneralTask()
        {
            // Створюємо масив базового типу Shape, що містить різні об'єкти
            Shape[] shapes = new Shape[]
            {
                new Circle(),
                new Square(),
                new Circle(),
                new Shape()
            };

            Console.WriteLine($"Усього фігур у масиві: {shapes.Length}\n");

            for (int i = 0; i < shapes.Length; i++)
            {
                Console.WriteLine($"--- Елемент масиву [{i}] ({shapes[i].Name}) ---");

                // Безпечне приведення типу за допомогою сучасного оператора 'is'
                if (shapes[i] is Circle circleObj)
                {
                    Console.WriteLine("Знайдено коло за допомогою оператора 'is'!");
                    // Викликаємо специфічний метод для зміни радіуса
                    circleObj.ChangeRadius(10.5 + i); 
                }
                else
                {
                    Console.WriteLine("Цей об'єкт не є колом. Специфічний метод недоступний.");
                }
            }
        }
    }
}

