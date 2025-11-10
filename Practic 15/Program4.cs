using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practic_15._4
{
    interface IAttack
    {
        void Attack();
    }
    interface IHeal
    {
        void Heal();
    }
    //Класс воин
    class Warrior : IAttack
    {
        public void Attack()
        {
            Console.WriteLine("Воин атакует!");
        }
    }
    //Класс маг
    class Mage : IAttack, IHeal
    {
        public void Attack()
        {
            Console.WriteLine("Маг атакует!");
        }

        public void Heal()
        {
            Console.WriteLine("Маг лечит!");
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            //массив объектов с персонажами
            object[] characters = new object[]
            {
                   new Warrior(),
                   new Mage()
            };

            Console.WriteLine("Все, кто умеет атаковать:");
            foreach (var character in characters)
            {
                if (character is IAttack attacker)
                {
                    attacker.Attack();
                }
            }

            Console.WriteLine("\nВсе, кто умеет лечить:");
            foreach (var character in characters)
            {
                if (character is IHeal healer)
                {
                    healer.Heal();
                }
            }
            Console.ReadLine();
        }

    }
}
    


