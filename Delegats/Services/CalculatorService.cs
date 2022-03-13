using System;
using System.Collections.Generic;

namespace Delegats.Services
{
    public class CalculatorService
    {
        /// <summary>
        /// Список операций
        /// </summary>
        public Dictionary<string, OperationNameDelegate> _operationName;

        /// <summary>
        /// 
        /// </summary>
        public delegate double OperationDelegate(double x, double y);

        public delegate string OperationNameDelegate(string oper);


        //public Dictionary<string, OperationNameDelegate> _operationName;
        /// <summary>
        /// 
        /// </summary>
        public Dictionary<string, OperationDelegate> _operations;


        /// <summary>
        /// Constructor
        /// </summary>
        public CalculatorService()
        {
            _operationName = new Dictionary<string, OperationNameDelegate>()
            {
              { "+", OperationSumma},
               { "//", OperationDoubleDivision},
               { "|/|", OperationModuleDivision},
               {"*", OperationMultiplication},
              {"-",OperationSubtraction},
                 {"%",OperationRemainderOfTheDivision}
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


        /// <summary>
        /// 
        /// </summary>
        public void ShowAllOperations()
        {
            foreach (var operation in _operationName)
            {
                Console.WriteLine($"{operation.Key} - это {operation.Value}");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="op"></param>
        /// <returns></returns>
        // public string GetOperationName(string op)
        // {
        //return _operationName[op];
        // }

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

            //проверить x и y
            //

            //подсчет результата
            var result = _operations[op](x, y);

            //вывод результата
            Console.WriteLine($"result операции {_operationName[op]} равен {result}");

            x = 1;
            y = 2;
            var xxx = Summa(x, y);//4
                                  //x = 2

            var uuu = Multiplication(x, y); //2
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        private double Summa(double oper1, double oper2)
        {
            return oper1 + oper2;
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
        private string OperationSumma(string oper)
        {
            return oper = "сложение";

        }
        private string OperationSubtraction(string oper)
        {
            return oper = "вычитание";

        }
        private string OperationMultiplication(string oper)
        {
            return oper = "умножение";

        }
        private string OperationRemainderOfTheDivision(string oper)
        {
            return oper = "остаток от деления";

        }
        private string OperationDoubleDivision(string oper)
        {
            return oper = "двойное деление (x / y / y)";

        }

        private string OperationModuleDivision(string oper)
        {
            return oper = "возврат модуля от деления";

        }

    }
}