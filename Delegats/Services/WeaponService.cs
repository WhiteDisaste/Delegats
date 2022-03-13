using System;
using System.Collections.Generic;

namespace Danya.Delegats.Services
{
    public class WeaponService
    {
        /// <summary>
        /// Cписок названий операций
        /// </summary>
        public Dictionary<string, string> _operationName;
        /// <summary>
        /// Делегат одной операции
        /// </summary>
        public delegate string OperationDelegate();
        /// <summary>
        /// Список операций
        /// </summary>
        public Dictionary<string, OperationDelegate> _operationsSound;

        public delegate string SoundDelegate();
        /// <summary>
        /// Конструктор
        /// </summary>
        public WeaponService()
        {

            //string result;
            _operationName = new Dictionary<string, string>()
            {
                { "+", "выстрел из лука" },
                { "-", "выстрел из рогатки" },
                { "/", "выстрел из ружья"}
            };

            // _operationsSound = new Dictionary<string, string>()
            //{


            //{"+", GetOnionSound(result)},
            //{"-", GetSlingshotSound},
            //{"/", GetGunSound}
            //};
        }

        /// <summary>
        /// Вывод всех операций
        /// </summary>
        public void ShowAllOperations()
        {
            foreach (var operation in _operationName)
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
            return _operationName[op];
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

            if (a >= b)
            {
                throw new ArgumentException("Количество проделанных выстрелов не может превышать количество снарядов");
            }
            if (!_operationsSound.ContainsKey(op))
            {
                throw new ArgumentException("нет такого действия");
            }

            //подсчет результата
            var result = _operationsSound[op]();
            //вывод результата
            Console.WriteLine(
                $"Вы проделали {_operationName[op]} {b} раз и у вас осталось {a - b}. При выстрелах был звук {result}");

        }

        /// <summary>
        /// Звук выстрела из лука
        /// </summary>
        /// <returns>звук</returns>
        private void GetOnionSound(out string result)
        {

            result = "фью";

        }

        /// <summary>
        /// Звук выстрела из рогатки
        /// </summary>
        /// <returns>звук</returns>
        private void GetSlingshotSound(out string result)
        {
            result = "пиу";
        }

        /// <summary>
        /// Звук выстрела из ружья
        /// </summary>
        /// <returns>звук</returns>
        private void GetGunSound(out string result)
        {
            result = "бам";
        }
    }
}