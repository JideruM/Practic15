using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practic_15._5
{
    public interface IDeposit
    {
        void Deposit(decimal amount);
    }
    public interface IWithdraw
    {
        bool Withdraw(decimal amount);
    }
    public interface ITransfer
    {
        bool Transfer(decimal amount, BankAccount targetAccount);
    }
    //класс банка
    public class BankAccount : IDeposit, IWithdraw, ITransfer
    {
        public decimal Balance { get; private set; }

        public BankAccount(decimal initialBalance = 0)
        {
            Balance = initialBalance;
        }
        public void Deposit(decimal amount)
        {
            if (amount > 0)
            {
                Balance += amount;
            }
            else
            {
                Console.WriteLine("Сумма для внесения должна быть больше 0");
            }
        }
        //снятие денег
        public bool Withdraw(decimal amount)
        {
            if (amount <= 0)
            {
                Console.WriteLine("Сумма для снятия должна быть больше 0");
                return false;
            }
            if (Balance >= amount)
            {
                Balance -= amount;
                return true;
            }
            else
            {
                Console.WriteLine("Недостаточно средств");
                return false;
            }
        }
        //перевод с одного счета на другой
        public bool Transfer(decimal amount, BankAccount targetAccount)
        {
            if (amount <= 0)
            {
                Console.WriteLine("Сумма перевода должна быть больше 0");
                return false;
            }

            if (Withdraw(amount))
            {
                targetAccount.Deposit(amount);
                return true;
            }
            else
            {
                return false;
            }
        }
        internal class Program
        {

            static void Main(string[] args)
            {
                //массив
                BankAccount[] accounts = new BankAccount[2];

                //инициализация счетов
                accounts[0] = new BankAccount(5000);
                accounts[1] = new BankAccount();

                //вывод
                Console.WriteLine($"Баланс счёта 1: {accounts[0].Balance}");
                Console.WriteLine($"Баланс счёта 2: {accounts[1].Balance}");

                //перевод с первого на второй счет
                Console.WriteLine("Перевод 666 с счёта 1 на счёт 2...");
                accounts[0].Transfer(666, accounts[1]);

                //вывод балансов после перевода
                Console.WriteLine($"Баланс счёта 1: {accounts[0].Balance}");
                Console.WriteLine($"Баланс счёта 2: {accounts[1].Balance}");

                Console.ReadLine();
            }
        }
    }
}


