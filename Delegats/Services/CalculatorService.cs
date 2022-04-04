using System;
using System.Collections.Generic;

namespace Delegats.Services
{
    public class CalculatorService
    {
        /// <summary>
        /// Cписок названий операций
        /// </summary>
        public Dictionary<string, string> _operationNames;
        /// <summary>
        /// Список операций
        /// </summary>
        public Dictionary<string, OperationDelegate> _operations;
        
        /// <summary>
        /// Объявление делегата
        /// </summary>
        public delegate double OperationDelegate(double a, double b);

        /// <summary>
        /// Constructor
        /// </summary>
        public CalculatorService()
        {
            _operations = new Dictionary<string,OperationDelegate>()
            {
                { "+", Summa},
                { "-", Subtraction},
                {"/",Division },
                { "//", DoubleDivision},
                { "*", Multiplication},
                { "%", RemainderOfTheDivision},
                { "|/|", ModuleDivision}               
            };
            _operationNames = new Dictionary<string, string>()
            {
                { "+", "Сумма"},
                { "-", "Вычитание"},
                { "//","Двойное деление" },
                { "/","Деление" },
                { "*", "Умножение"},
                { "%", "Остаток от деления"},
                { "|/|", "Деление по модулю"}
            };
        }

        /// <summary>
        /// Вывод всех операций
        /// </summary>
        public void ShowAllOperations()
        {
            foreach (var operation in _operationNames)
            {
                Console.WriteLine($"{operation.Key} - это {operation.Value}");
            }
        }
        /// <summary>
        /// проверка и вывод результата
        /// </summary>
        /// <param name="op">символ операции</param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <exception cref="ArgumentException"></exception>
        public void PerformOperation(string op, double x, double y)
        {
            //проверить введенную операцию
            if (string.IsNullOrWhiteSpace(op))
            {
                throw new ArgumentException("не ввели символ");
            }

            if (!_operations.ContainsKey(op))
            {
                throw new ArgumentException("нет такой операции");
            }
            double result = _operations[op](x, y);

            //вывод результата
            Console.WriteLine($"результат операции равен {result}");
        }

        /// <summary>
        /// метод суммы
        /// </summary>        
        private double Summa(double x, double y) => x + y;
        
        /// <summary>
        /// метод вычитания
        /// </summary>
        private double Subtraction(double x, double y) => x - y;
        
        /// <summary>
        /// метод умножения
        /// </summary>
        private double Multiplication(double x, double y)=>x*y;
        
        /// <summary>
        /// метод деления
        /// </summary>
        private double Division(double x, double y) => x / y;
        /// <summary>
        /// метод отсаток от деления
        /// </summary>
        private double RemainderOfTheDivision(double x, double y)=>x % y;     
         
        /// <summary>
        /// метод двойного деления
        /// </summary>
        private double DoubleDivision(double x, double y)=>x/y/y;
         
        /// <summary>
        /// метод деление по модулю
        /// </summary>
        private double ModuleDivision(double x, double y)=>Math.Abs(x/y);
    }
}