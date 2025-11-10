using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practic_15._2
{
    interface ISwitch
    {
        void On();
        void Off();
    }
    interface ILevel
    {
        void SetLevel(int level);
    }
    //Класс Лампа для двух интерфесов
    class Lamp : ISwitch, ILevel
    {
        private int level = 0; //неизменяемость уровня яркости
        bool isOn = false;

        public void On()
        {
            isOn = true;
            level = 100; //при включении 
            Console.WriteLine("Лампа включена. Уровень: 100");
        }
        public void Off()
        {
            isOn = false;
            level = 0; //при выключении
            Console.WriteLine("Лампа выключена. Уровень: 0");
        }
        public void SetLevel(int level)
        {
            if (level < 0) level = 0;
            if (level > 100) level = 100;
            this.level = level;
            Console.WriteLine($"Уровень лампы установлен на: {this.level}");
        }
        //Класс вентилятора
        class Fan : ISwitch
        {
            private bool isOn = false;
            public void On()
            {
                isOn = true;
                Console.WriteLine("Вентилятор включен");
            }

            public void Off()
            {
                isOn = false;
                Console.WriteLine("Вентилятор выключен");
            }
            internal class Program
            {
                static void Main(string[] args)
                {
                    //массив устройств
                    var devices = new object[]
                    {
                      new Lamp(),
                      new Fan()
                    };
                    foreach (var device in devices)
                    //var для объявления переменной с неявным типом, сам определяет тип переменной
                    {
                        //включение устройства
                        if (device is ISwitch switch1)
                        {
                            switch1.On();

                            //лампа - установка уровня
                            if (device is ILevel level)
                            {
                                level.SetLevel(30); //установка уровня 30
                            }
                            //выключение
                            switch1.Off();
                        }
                    }

                    Console.ReadLine();
                }
            }
        }
    }
}

