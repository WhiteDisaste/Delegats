using System;
using System.Collections.Generic;
using Delegats.Services;

namespace Delegats
{
    class Program
    {
        private static WeaponService _weaponService = new WeaponService();
        private static CalculatorService _calculatorService = new CalculatorService();
        
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World! Можно использовать калькулятор, он умеет:");
            //служебная переменная
            var operationKey = string.Empty;

            _calculatorService.ShowAllOperations();
            
            
            operationKey = Console.ReadLine();
            var x = Convert.ToDouble(Console.ReadLine());
            var y = Convert.ToDouble(Console.ReadLine());
            
            _calculatorService.PerformOperation(operationKey, x, y);

            Console.WriteLine("Можно выбрать оружия, виды оружия есть:");
            _weaponService.ShowAllOperations();

            
            operationKey = Console.ReadLine();
            Console.WriteLine("Введите кол-во снарядов для стрельбы:");
            var a = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Введите кол-во проделанных выстрелов:");
            var b = Convert.ToInt32(Console.ReadLine());
            
             _weaponService.PerformOperation(operationKey, a, b);
            Console.ReadLine();
        }

        
       
        
    }
}