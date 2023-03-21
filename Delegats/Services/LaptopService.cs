using System;
using System.Collections.Generic;
using System.Text;

namespace Delegats.Services
{
    public class LaptopService
    {
        /// <summary>
        /// Cписок названий операций
        /// </summary>
        public Dictionary<string, string> _operationNames;

        /// <summary>
        /// Делегат одной операции
        /// </summary>
        public delegate void GetLaptopDelegate(out string result);

        /// <summary>
        /// Список операций
        /// </summary>
        public Dictionary<string, GetLaptopDelegate> _getLaptopDelegates;


        /// <summary>
        /// Конструктор
        /// </summary>
        public LaptopService()
        {
            _operationNames = new Dictionary<string, string>()
            {
                { "+", "Apple" },
                { "-", "Lenovo" },
                { "/", "Acer" }
            };

            _getLaptopDelegates = new Dictionary<string, GetLaptopDelegate>()
            {
                { "+", GetApple },
                { "-", GetLenovo },
                { "/", GetAcer }
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
        /// Метод получения операций
        /// </summary>
        /// <param name="op"></param>
        /// <returns></returns>
        public string GetOperationName(string op)
        {
            return _operationNames[op];
        }

        /// <summary>
        /// Метод выполнения операции
        /// </summary>
        /// <param name="op">символ операции</param>
        /// <param name="a">количество снарядов</param>
        /// <param name="b">количество проделанных выстрелов</param>
        /// <exception cref="ArgumentException"></exception>
        public void PerformOperation(string op, int a, int b)
        {
            //проверить введенную операцию
            if (string.IsNullOrWhiteSpace(op))
            {
                throw new ArgumentException("не ввели символ");
            }

            if (a < b)
            {
                throw new ArgumentException("Количество проделанных выстрелов не может превышать количество снарядов");
            }

            if (!_getLaptopDelegates.ContainsKey(op))
            {
                throw new ArgumentException("нет такого действия");
            }

            _getLaptopDelegates[op](out string result);

            //вывод результата
            Console.WriteLine(
                $"Вы проделали {_operationNames[op]} {b} раз и у вас осталось {a - b}. При выстрелах был звук {result}");
        }


        /// <summary>
        /// Звук выстрела из лука
        /// </summary>
        /// <returns>звук</returns>
        private void GetApple(out string result)
        {
            result = "фью";
        }

        /// <summary>
        /// Звук выстрела из рогатки
        /// </summary>
        /// <returns>звук</returns>
        private void GetLenovo(out string result)
        {
            result = "пиу";
        }

        /// <summary>
        /// Звук выстрела из ружья
        /// </summary>
        /// <returns>звук</returns>
        private void GetAcer(out string result)
        {
            result = "бам";
        }
    }
}
