using System;
using System.Collections.Generic;

namespace Delegats.Calculator
{
    public class CalculatorClass
    {
        public CalculatorClass()
        {
            _operationName = new Dictionary<string, string>()
            {
                { "+", "сложение" },
                { "//", "двойное деление (x / y / y)" },
                { "|/|", "возврат модуля от деления"},
                {"*", "умножение"},
                {"-","вычитание"},
                 {"%","остаток от деления"}
            };
            
            _operations = new Dictionary<string, OperationDelegate>()
            {
                { "+", Summa},
                {"//", DoubleDivision},
                {"|/|", ModuleDivision},
                {"-", Subtraction},
                {"*", Multiplication},
                {"%", RemainderOfTheDivision}
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
        
        public void PerformOperation(string op, double x, double y)
        {
            //проверить введенную операцию
            if (string.IsNullOrWhiteSpace(op))
            {
                throw new ArgumentException("не ввели символ");
            }

            if (!_operations.ContainsKey("op"))
            {
                throw new ArgumentException("нет такой операции");
            }
            
            //проверить x и y
            //
            
            //подсчет результата
            var result = _operations[op](x, y);
            
            //вывод результата
            Console.WriteLine($"result операции {_operationName[op]} равен {result}");
        }

        private double Summa(double x, double y)
        {
            return x + y;
        }
         private double Subtraction(double x, double y)
        {
            return x - y;
        }
         private double Multiplication(double x, double y)
        {
            return x * y;
        }
         private double RemainderOfTheDivision(double x, double y)
        {
            return x % y;
        }
        
        private double DoubleDivision(double x, double y)
        {
            var divisionResult = x / y;
            return divisionResult / y;
        }
        
        private double ModuleDivision(double x, double y)
        {
            var divisionResult = x / y;
            return Math.Abs(divisionResult);
        }


    }
}