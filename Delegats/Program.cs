using System;
using System.Collections.Generic;
using System.Globalization;
using Delegats.Calculator;
using Delegats.Weapon;

namespace Delegats
{
    class Program
    {
        private static WeaponClass _weaponClass = new WeaponClass();

        private static CalculatorClass _calculatorClass = new CalculatorClass();
        
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World! Можно использовать калькулятор, он умеет:");
            
            _calculatorClass.ShowAllOperations();

            var operationKey = Console.ReadLine();
            var x = Convert.ToDouble(Console.ReadLine());
            var y = Convert.ToDouble(Console.ReadLine());

            _calculatorClass.PerformOperation(operationKey, x, y);

            Console.WriteLine("Можно выбрать оружия, виды оружия есть:");
            _weaponClass.ShowAllOperations();

            
            var operationKey = Console.ReadLine();
            var a = Convert.ToString(Console.ReadLine());
            var b = Convert.ToString(Console.ReadLine());
            
             _weaponClass.PerformOperation(operationKey, x, y);
            Console.ReadLine();
        }

        void ShowOperationInfo(string culture, string name)
        {
            var operationInfoRu = new Dictionary<string, string>()
            {
                { "сложение", "к 1му числу прибавить 2ое число" },
                { "двойное деление (x / y / y)", "...." },
                { "возврат модуля от деления", "поделить, потом взять модуль числа"}
            };
            var operationInfoUk = new Dictionary<string, string>()
            {
                { "сложение", "по-укр" },
                { "двойное деление (x / y / y)", "...." },
                { "возврат модуля от деления", "по-укр"}
            };

            if (culture == "Ru")
            {
                Console.WriteLine(operationInfoRu[name]);
            }
            else if (culture == "Uk")
            {
                Console.WriteLine(operationInfoUk[name]);
            }
            else if (culture == "En")
            {
                Console.WriteLine(operationInfoUk[name]);
            }
        }
    }
}