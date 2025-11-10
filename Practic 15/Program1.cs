using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practic_15._1
{
    interface IWork
    {
        void DoWork();
    }
    interface ICharge
    {
        void Recharge();
    }
    //Класс Робот реализует оба интерфейса
    class Robot : IWork, ICharge
    {
        public string Name { get; set; }
        public int Energy { get; set; }
        public Robot(string name, int energy)
        {
            Name = name;
            Energy = energy;
        }
        //Метод для выполнения работы
        public void DoWork()
        {
            Energy = Math.Max(Energy - 20, 0);
            Console.WriteLine($"{Name} работает. Текущая энергия: {Energy}");
        }
        //Метод для зарядки
        public void Recharge()
        {
            Energy = Math.Min(Energy + 50, 100);
            Console.WriteLine($"{Name} заряжается. Текущая энергия: {Energy}");
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            // массив роботов
            Robot[] robots = new Robot[]
            {
            new Robot("Робот - Штангенциркуль", 69),
            new Robot("Робот - Криминал", 40),
            new Robot("Робот - Ванван", 52)
            };

            //каждый робот
            foreach (var robot in robots)
            {
                //первый запуск
                robot.DoWork();

                //зарядка
                robot.Recharge();

                //работа еще раз
                robot.DoWork();

                Console.WriteLine($"Итог: {robot.Name} имеет {robot.Energy} энергии.\n");
            }

            Console.ReadLine();
        }
    }
}