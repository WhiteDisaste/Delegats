using System;
using System.Collections.Generic;

namespace Delegats.Calculator
{
    public class WeaponClass
    {
        public WeaponClass
    {
            _operationName = new Dictionary<string, string>()
            {
                { "+", "выстрел из лука" },
                { "-", "выстрел из рогатки" },
                { "/", "выстрел из ружья"}
            };
            
            _operations = new Dictionary<string, OperationDelegate>()
            {
                { "+", Onion},
                {"//", Slingshot},
                {"|/|", Gun}
            };
        }


        public Dictionary<string, string> _operationName;
        
        public delegate double OperationDelegate(double x, double y);
        public Dictionary<string, OperationDelegate> _operations;


        public void ShowAllOperations()
        {
            foreach (var operation in _operationName)
            {
                Console.WriteLine($"{operation.Key} - это {operation.Value}");
            }
        }
        
        public string GetOperationName(string op)
        {
            return _operationName[op];
        }
        
        public void PerformOperation(string op, string a, string b)
        {
            //проверить введенную операцию
            if (string.IsNullOrWhiteSpace(op))
            {
                throw new ArgumentException("не ввели символ");
            }

            if (!_operations.ContainsKey("op"))
            {
                throw new ArgumentException("нет такого действия");
            }
            
            //проверить x и y
            //
            
            //подсчет результата
            var result = _operations[op](a, b);
            
            //вывод результата
            Console.WriteLine($"звук из {_operationName[op]} равен {result}");
        }

        private double Onion(string a, string b)
        {
           a = "фью";
           b = "осталось 4 стрелы";
    
           return a + b;
        }
        
        private double Slingshot(string a, string b)
        {
           a = "пиу";
           b = "осталось 3 камушка";
             return a + b;
}
        
        private double Gun(string a, string b)
        {
           a = "бам";
           b = "осталось 5 патронов";
           return a + b;
        }
    }
}