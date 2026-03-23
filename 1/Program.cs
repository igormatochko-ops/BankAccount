using System;

namespace BankAccount
{
    class Account
    {
        private string name;
        private int number;
        private double sum;

        public Account()
        {
            name = "Неизвестно";
            number = 0;
            sum = 0.0;
        }

        public Account(string name, int number, double sum)
        {
            this.name = name;
            this.number = number;
            this.sum = sum;
        }

        public Account(Account other)
        {
            name = other.name;
            number = other.number;
            sum = other.sum;
        }

        public void PrintInfo()
        {
            Console.WriteLine($"Наименование: {name}");
            Console.WriteLine($"Номер счета: {number}");
            Console.WriteLine($"Сумма: {sum} руб.");
        }

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
            Account acc1 = new Account();
            Console.WriteLine("=== Счет 1 (конструктор по умолчанию) ===");
            acc1.PrintInfo();

            Account acc2 = new Account("Зарплатный", 123456, 50000.50);
            Console.WriteLine("\n=== Счет 2 (конструктор с параметрами) ===");
            acc2.PrintInfo();

            Account acc3 = new Account(acc2);
            Console.WriteLine("\n=== Счет 3 (копия счета 2) ===");
            acc3.PrintInfo();

            Console.WriteLine("\n=== Операции со счетом 2 ===");
            acc2.Deposit(10000);
            acc2.Withdraw(20000);
            acc2.Withdraw(50000);

            Console.WriteLine("\n=== Финальное состояние счета 2 ===");
            acc2.PrintInfo();

            Console.ReadLine();
        }
    }
}// Account class
