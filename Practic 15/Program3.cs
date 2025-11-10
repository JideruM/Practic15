using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practic_15._3
{
    interface IPrise
    {
        decimal GetPrice();
    }
    interface IGaranty
    {
        int GetGaranty();
    }
    //Класс Телефон
    public class Phone : IPrise, IGaranty
    {
        public decimal Price { get; set; }
        public int Garanty { get; set; }
        public Phone(decimal price, int garanty)
        {
            Price = price;
            Garanty = garanty;
        }
        public decimal GetPrice()
        {
            return Price;
        }
        public int GetGaranty()
        {
            return Garanty;
        }
    }
    //Класс Ноутбук
    class Laptop : IPrise
    {
        public decimal Price { get; set; }

        public Laptop(decimal price)
        {
            Price = price;
        }

        public decimal GetPrice()
        {
            return Price;
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            //массив продуктов
            var products = new IPrise[]
            {
            new Phone(66666, 24),
            new Laptop(900000),
            new Phone(23000, 3)
            };

            decimal totalPrice = 0;

            foreach (var product in products)
            {
                totalPrice += product.GetPrice();

                //проверка наличия гарантии
                if (product is IGaranty garanty)
                {
                    Console.WriteLine($"Гарантия: {garanty.GetGaranty()} месяцев");
                }
            }

            Console.WriteLine($"Общая цена: {totalPrice}");
            Console.ReadLine();
        }
    }
}

