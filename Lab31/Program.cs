using System;
using System.Collections.Generic;
using System.IO;

namespace PracticalWork31
{
    // ==========================================
    // ТИПИ ТА ІНТЕРФЕЙСИ ДЛЯ ЗАГАЛЬНОГО ЗАВДАННЯ
    // ==========================================

    // Інтерфейс для обслуговування
    public interface IMaintainable
    {
        void PerformMaintenance();
    }

    // Абстрактний базовий клас Транспортний засіб
    public abstract class Vehicle : IMaintainable
    {
        public string Brand { get; set; }
        public string Model { get; set; }
        public double EngineCapacity { get; set; }

        protected Vehicle(string brand, string model, double engineCapacity)
        {
            // Валідація для базового контролю коректності даних
            if (engineCapacity <= 0)
                throw new ArgumentException("Об'єм двигуна повинен бути більшим за нуль!");

            Brand = brand;
            Model = model;
            EngineCapacity = engineCapacity;
        }

        // Абстрактний метод для виведення специфічної інформації
        public abstract string GetVehicleType();

        public override string ToString()
        {
            return $"[{GetVehicleType()}] {Brand} {Model} (Двигун: {EngineCapacity} л)";
        }

        // Реалізація методу інтерфейсу
        public virtual void PerformMaintenance()
        {
            Console.WriteLine($"[Обслуговування]: Пройдено базовий техогляд для {Brand} {Model}.");
        }
    }

    // Похідний клас Легковик
    public class Car : Vehicle
    {
        public string BodyType { get; set; }

        public Car(string brand, string model, double engineCapacity, string bodyType) 
            : base(brand, model, engineCapacity)
        {
            BodyType = bodyType;
        }

        public override string GetVehicleType() => "Легковик";

        public override string ToString()
        {
            return base.ToString() + $", Кузов: {BodyType}";
        }
    }

    // Похідний клас Вантажівка
    public class Truck : Vehicle
    {
        public double LoadCapacity { get; set; }

        public Truck(string brand, string model, double engineCapacity, double loadCapacity) 
            : base(brand, model, engineCapacity)
        {
            if (loadCapacity <= 0)
                throw new ArgumentException("Вантажопідйомність повинна бути більшою за нуль!");

            LoadCapacity = loadCapacity;
        }

        public override string GetVehicleType() => "Вантажівка";

        public override string ToString()
        {
            return base.ToString() + $", Вантажопідйомність: {LoadCapacity} т";
        }

        public override void PerformMaintenance()
        {
            Console.WriteLine($"[Обслуговування]: Пройдено посилений техогляд ходової частини вантажівки {Brand} {Model}.");
        }
    }

    // Менеджер управління автопарком
    public class FleetManager
    {
        private readonly List<Vehicle> _fleet = new List<Vehicle>();

        public void AddVehicle(Vehicle vehicle)
        {
            _fleet.Add(vehicle);
            Console.WriteLine($"Транспортний засіб {vehicle.Brand} успішно додано до автопарку.");
        }

        public void DisplayFleet()
        {
            Console.WriteLine("\n--- Повний список автопарку ---");
            if (_fleet.Count == 0) Console.WriteLine("Автопарк порожній.");
            foreach (var v in _fleet)
            {
                Console.WriteLine(v);
            }
        }

        // Фільтрація за об'ємом двигуна (повертає авто з двигуном від заданого значення)
        public void FilterByEngine(double minCapacity)
        {
            Console.WriteLine($"\n--- Фільтрація: транспорт з двигуном від {minCapacity} л ---");
            var filtered = _fleet.FindAll(v => v.EngineCapacity >= minCapacity);
            if (filtered.Count == 0) Console.WriteLine("Нічого не знайдено.");
            foreach (var v in filtered)
            {
                Console.WriteLine(v);
            }
        }

        // Збереження фінального звіту у текстовий файл
        public void SaveReport(string fileName)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(fileName, append: false))
                {
                    writer.WriteLine($"=== ЗВІТ ПРО СТАН АВТОПАРКУ НА {DateTime.Now} ===");
                    writer.WriteLine($"Загальна кількість машин: {_fleet.Count}\n");
                    foreach (var v in _fleet)
                    {
                        writer.WriteLine(v.ToString());
                    }
                }
                Console.WriteLine($"\n[УСПІХ]: Фінальний звіт успішно збережено у файл '{fileName}'.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\n[ПОМИЛКА]: Не вдалося зберегти звіт ({ex.Message}).");
            }
        }
    }

    // ==========================================
    // ТОЧКА ВХОДУ (ГОЛОВНИЙ КЛАС ПРОГРАМИ)
    // ==========================================
    class Program
    {
        static void Main(string[] args)
        {
            // ------------------------------------------
            // ВИКОНАННЯ ЗАГАЛЬНОГО ЗАВДАННЯ
            // ------------------------------------------
            Console.WriteLine("=== ЗАГАЛЬНЕ ЗАВДАННЯ (Система 'Управління автопарком') ===");

            FleetManager manager = new FleetManager();

            // Додавання об'єктів
            manager.AddVehicle(new Car("Audi", "A6", 2.5, "Седан"));
            manager.AddVehicle(new Truck("MAN", "TGX", 12.4, 18.0));
            manager.AddVehicle(new Car("VW", "Golf", 1.6, "Хетчбек"));
            manager.AddVehicle(new Truck("Volvo", "FH16", 16.0, 25.0));

            // Перегляд автопарку
            manager.DisplayFleet();

            // Фільтрація транспорту за параметром
            manager.FilterByEngine(3.0);

            // Збереження фінального текстового списку машин у звітний файл на диску
            manager.SaveReport("fleet_report.txt");


            // ------------------------------------------
            // ВИКОНАННЯ ДОМАШНЬОГО ЗАВДАННЯ
            // ------------------------------------------
            Console.WriteLine("\n=== ДОМАШНЄ ЗАВДАННЯ (Тестування на граничні / некоректні значення) ===");

            Console.WriteLine("Тест 1: Спроба створити автомобіль з від'ємним об'ємом двигуна (-1.5 л):");
            try
            {
                Car faultyCar = new Car("BMW", "X5", -1.5, "Позашляховик");
            }
            catch (ArgumentException ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"[ПЕРЕХВАТ ПОМИЛКИ]: {ex.Message}");
                Console.ResetColor();
            }

            Console.WriteLine("\nТест 2: Спроба створити вантажівку з нульовою вантажопідйомністю (0 т):");
            try
            {
                Truck faultyTruck = new Truck("Scania", "R500", 13.0, 0);
            }
            catch (ArgumentException ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"[ПЕРЕХВАТ ПОМИЛКИ]: {ex.Message}");
                Console.ResetColor();
            }
            
            Console.WriteLine("\n[ВИСНОВОК ДЗ]: Систему успішно протестовано на граничні значення. Архітектурні обмеження та блоки try-catch повністю захищають програму від некоректного введення даних.");
        }
    }
}
