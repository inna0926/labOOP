using System;

namespace PracticalWork28
{
    // --- ДОМАШНЄ ЗАВДАННЯ: Створення класу параметрів події на основі EventArgs ---
    // Передає інформацію про поточну суму залишку підписнику
    public class LowBalanceEventArgs : EventArgs
    {
        public double CurrentBalance { get; }

        public LowBalanceEventArgs(double currentBalance)
        {
            CurrentBalance = currentBalance;
        }
    }

    // --- ЗАГАЛЬНЕ ЗАВДАННЯ + ДОМАШНЄ ЗАВДАННЯ: Клас Банк (Видавець події) ---
    public class Bank
    {
        // Оголошення події з використанням стандартного шаблону EventHandler<T>
        public event EventHandler<LowBalanceEventArgs>? LowBalance;

        // Метод для безпечного виклику події
        protected virtual void OnLowBalance(LowBalanceEventArgs e)
        {
            // Використовуємо оператор ?. для безпечного виклику (перевірка на наявність підписників)
            LowBalance?.Invoke(this, e);
        }

        // Логіка перевірки балансу рахунку
        public void CheckAccountBalance(string accountName, double balance)
        {
            if (balance < 100)
            {
                // Якщо баланс менше 100, генеруємо подію та передаємо поточний залишок (ДЗ)
                OnLowBalance(new LowBalanceEventArgs(balance));
            }
        }
    }

    // --- ЗАГАЛЬНЕ ЗАВДАННЯ: Клас Рахунок ---
    public class Account
    {
        private double _balance;
        private readonly Bank _bank;

        public string AccountNumber { get; }
        
        public double Balance 
        { 
            get => _balance; 
            private set
            {
                _balance = value;
                // При кожній зміні балансу просимо банк перевірити стан рахунку
                _bank.CheckAccountBalance(AccountNumber, _balance);
            }
        }

        public Account(string accountNumber, double initialBalance, Bank bank)
        {
            AccountNumber = accountNumber;
            _bank = bank;
            _balance = initialBalance;
        }

        // Метод зняття грошей з рахунку
        public void Withdraw(double amount)
        {
            if (amount <= 0) return;
            
            Console.WriteLine($"[Рахунок {AccountNumber}]: Спроба зняття {amount} грн. Поточний баланс: {Balance} грн.");
            Balance -= amount;
        }
    }

    // --- ЗАГАЛЬНЕ ЗАВДАННЯ: Клас-Підписник (Служба сповіщень) ---
    public class NotificationService
    {
        // Метод-обробник події (реагує на низький баланс)
        public void OnLowBalanceDetected(object? sender, LowBalanceEventArgs e)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            // Виводимо сповіщення в консоль разом із сумою залишку, отриманою з EventArgs (ДЗ)
            Console.WriteLine($"[СПОДІЩЕННЯ]: Увага! На вашому рахунку критично низький баланс: {e.CurrentBalance:F2} грн! (Менше 100 одиниць)");
            Console.ResetColor();
        }
    }

    // ==========================================
    // ТОЧКА ВХОДУ (ГОЛОВНИЙ КЛАС ПРОГРАМИ)
    // ==========================================
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== ЗАГАЛЬНЕ + ДОМАШНЄ ЗАВДАННЯ (Події та EventArgs) ===\n");

            // Створюємо екземпляр Банку (Видавця) та Служби сповіщень (Підписника)
            Bank privatBank = new Bank();
            NotificationService smsService = new NotificationService();

            // Підписка на подію низького балансу
            privatBank.LowBalance += smsService.OnLowBalanceDetected;

            // Створюємо рахунок із початковим балансом 250 грн
            Account myAccount = new Account("UA12345", 250.0, privatBank);
            Console.WriteLine($"Рахунок {myAccount.AccountNumber} успішно створено з балансом {myAccount.Balance} грн.\n");

            // Перше зняття (залишок 170 грн - подія не має спрацювати)
            myAccount.Withdraw(80.0);
            Console.WriteLine($"Поточний баланс: {myAccount.Balance} грн.\n");

            // Друге зняття (залишок 80 грн - баланс менше 100, підписник має вивести сповіщення)
            myAccount.Withdraw(90.0);
            Console.WriteLine($"Поточний баланс: {myAccount.Balance} грн.");
        }
    }
}
