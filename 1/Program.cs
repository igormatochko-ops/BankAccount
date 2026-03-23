using System;

namespace BankAccount
{
    class Account
    {
        // Атрибуты (поля)
        private string name;      // наименование
        private int number;       // номер счета
        private double sum;       // сумма

        /// <summary>
        /// Конструктор по умолчанию.
        /// </summary>
        public Account()
        {
            name = "Неизвестно";
            number = 0;
            sum = 0.0;
        }

        /// <summary>
        /// Конструктор с параметрами.
        /// </summary>
        /// <param name="name">Наименование счета</param>
        /// <param name="number">Номер счета</param>
        /// <param name="sum">Сумма на счете</param>
        public Account(string name, int number, double sum)
        {
            this.name = name;
            this.number = number;
            this.sum = sum;
        }

        /// <summary>
        /// Конструктор копирования.
        /// </summary>
        /// <param name="other">Другой объект Account</param>
        public Account(Account other)
        {
            name = other.name;
            number = other.number;
            sum = other.sum;
        }

        /// <summary>
        /// Метод для вывода информации о счете.
        /// </summary>
        public void PrintInfo()
        {
            Console.WriteLine($"Наименование: {name}");
            Console.WriteLine($"Номер счета: {number}");
            Console.WriteLine($"Сумма: {sum} руб.");
        }

        /// <summary>
        /// Пополнение счета.
        /// </summary>
        /// <param name="amount">Сумма пополнения</param>
        public void Deposit(double amount)
        {
            if (amount > 0)
            {
                sum += amount;
                Console.WriteLine($"Счет пополнен на {amount} руб. Текущая сумма: {sum}");
            }
            else
            {
                Console.WriteLine("Сумма пополнения должна быть положительной.");
            }
        }

        /// <summary>
        /// Снятие средств со счета.
        /// </summary>
        /// <param name="amount">Сумма снятия</param>
        public void Withdraw(double amount)
        {
            if (amount > 0 && amount <= sum)
            {
                sum -= amount;
                Console.WriteLine($"Снято {amount} руб. Остаток: {sum}");
            }
            else
            {
                Console.WriteLine("Недостаточно средств или неверная сумма.");
            }
        }

        // Свойства для доступа к полям (опционально)
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public int Number
        {
            get { return number; }
            set { number = value; }
        }

        public double Sum
        {
            get { return sum; }
            set { sum = value; }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // 1. Конструктор по умолчанию
            Account acc1 = new Account();
            Console.WriteLine("=== Счет 1 (конструктор по умолчанию) ===");
            acc1.PrintInfo();

            // 2. Конструктор с параметрами
            Account acc2 = new Account("Зарплатный", 123456, 50000.50);
            Console.WriteLine("\n=== Счет 2 (конструктор с параметрами) ===");
            acc2.PrintInfo();

            // 3. Конструктор копирования
            Account acc3 = new Account(acc2);
            Console.WriteLine("\n=== Счет 3 (копия счета 2) ===");
            acc3.PrintInfo();

            // 4. Демонстрация методов
            Console.WriteLine("\n=== Операции со счетом 2 ===");
            acc2.Deposit(10000);
            acc2.Withdraw(20000);
            acc2.Withdraw(50000); // попытка снять больше, чем есть

            Console.WriteLine("\n=== Финальное состояние счета 2 ===");
            acc2.PrintInfo();

            Console.ReadLine();
        }
    }
}