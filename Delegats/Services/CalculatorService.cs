using System;
using System.Collections.Generic;

namespace Delegats.Services
{
    public class CalculatorService
    {
        /// <summary>
        /// 
        /// </summary>
        public Dictionary<string, OperationDelegate> _operations;

        public delegate double OperationDelegate(double a, double b);

        /// <summary>
        /// Constructor
        /// </summary>
        public CalculatorService()
        {
            _operations = new Dictionary<string,OperationDelegate>()
            {
                { "+", (a, b) => a + b},
            };
        }


        /// <summary>
        /// 
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

            //лямбда выражение для сложения двух чисел
            
            //подсчет результата

            //вывод результата
            Console.WriteLine($"result операции равен {result}");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        private double Summa(double oper1, double oper2) => oper1 + oper2;
        
        private double Subtraction(double x, double y) => x - y;
        

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