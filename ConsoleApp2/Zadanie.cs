using System;
using System.Collections.Generic;
using System.IO;

namespace ZadanieNorbit
{
    /// <summary>
    /// Класс для выполнения дз 
    /// </summary>
    internal class Zadanie
    {
        /// <summary>
        /// Основная функция 
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            Console.Write("Введите число n: ");
            string input = Console.ReadLine();

            if (int.TryParse(input, out int n))
            {
                // GetOddNumbers(n);
            }

            //Console.WriteLine("Квадрат:");
            //Console.WriteLine(GetKubX(n));

            //Console.Write("Введите строку для проверки: ");

            //string userInput = Console.ReadLine();

            //Console.WriteLine("Результат проверки:");
            //Console.WriteLine(GetRepeatedLetters(userInput, "hello"));

            Console.WriteLine("\nРомб:");
            Console.WriteLine(GetDiamond(n, n / 2, ""));

            Console.WriteLine("\nТреугольник:");
            Console.WriteLine(GetTriangle(n, ""));

            Console.WriteLine("\nСтрелка:");
            Console.WriteLine(GetArrow(n, n / 2, ""));
        }

        /// <summary>
        /// Функция для вывода ромба с пустым центром
        /// </summary>
        /// <param name="n">Длина диагонали (положительное нечётное число)</param>
        /// <param name="result">Пустая строка для вывода результата</param>
        /// <param name="half">Значение середины ромба</param>
        /// <returns>Строка с ромбом</returns>
        static string GetDiamond(int n, int half, string result)
        {
            CheckValueGreaterThan(n, "Ожидается число > 0", nameof(n));
            if (n % 2 == 0)
                throw new ArgumentException("N должно быть нечётным числом", nameof(n));

            for (var i = 0; i < half; i++)
            {

                for (var j = 0; j < half - i; j++)
                    result += " ";

                result += "X";

                if (i > 0)
                {
                    for (var j = 0; j < 2 * i - 1; j++)
                        result += " ";
                    result += "X";
                }

                result += "\n";
            }

            result += "X";
            for (var j = 0; j < n - 2; j++)
                result += " ";
            result += "X\n";

            for (var i = half - 1; i >= 0; i--)
            {

                for (var j = 0; j < half - i; j++)
                    result += " ";

                result += "X";

                if (i > 0)
                {
                    for (var j = 0; j < 2 * i - 1; j++)
                        result += " ";
                    result += "X";
                }

                result += "\n";
            }

            return result;
        }

        /// <summary>
        /// Функция для вывода треугольника с пустым центром
        /// </summary>
        /// <param name="n">Высота треугольника</param>
        /// <param name="result">Пустая строка для вывода результата</param>
        /// <returns>Строка с треугольником</returns>
        static string GetTriangle(int n, string result)
        {
            CheckValueGreaterThan(n, "Ожидается число > 0", nameof(n));

            for (var i = 0; i < n; i++)
            {
                if (i == 0)
                {
                    result += "X\n";
                }
                else if (i == n - 1)
                {
                    for (var j = 0; j < n; j++)
                        result += "X";
                    result += "\n";
                }
                else
                {
                    result += "X";
                    for (var j = 0; j < i - 1; j++)
                        result += " ";
                    result += "X\n";
                }
            }

            return "";
        }

        /// <summary>
        /// Функция для вывода стрелки
        /// </summary>
        /// <param name="n">Высота стрелки (рекомендуется нечётное)</param>
        /// <param name="result">Пустая строка для вывода результата</param>
        /// <param name="half">Значение середины стрелки</param>
        /// <returns>Строка со стрелкой</returns>
        static string GetArrow(int n, int half, string result)
        {
            CheckValueGreaterThan(n, "Ожидается число > 0", nameof(n));
            if (n % 2 == 0)
                throw new ArgumentException("N должно быть нечётным числом", nameof(n));

            for (int i = 0; i <= half; i++)
            {
                if (i == 0)
                {
                    result += "X\n";
                }
                else
                {
                    result += "X";
                    for (int j = 0; j < 2 * i - 1; j++)
                        result += " ";
                    result += "X\n";
                }
            }

            for (int i = half - 1; i >= 0; i--)
            {
                if (i == 0)
                {
                    result += "X\n";
                }
                else
                {
                    result += "X";
                    for (int j = 0; j < 2 * i - 1; j++)
                        result += " ";
                    result += "X\n";
                }
            }

            return result;
        }

        /// <summary>
        /// Функция для получения нечетных чисел от 1 до n
        /// </summary>
        /// <param name="n"> Граница, до которой будут браться нечетные числа </param>
        /// <returns> Выводит нечетные числа от 1 до n </returns>
        static string GetOddNumbers(int n)
        {
            CheckValueGreaterThan(n, "Ожидается число > 0", nameof(n));

            var result = "";

            for (var i = 1; i <= n; i += 2)
            {
                result += i.ToString() + " ";
            }

            return result;
        }

        /// <summary>
        /// Функция для получения квадрата из X размером N x N
        /// </summary>
        /// <param name="n"> Сторона квадрата </param>
        /// <returns> Выводит квадрат из X размером N x N </returns>
        static string GetKubX(int n)
        {
            CheckValueGreaterThan(n, "Ожидается длина стороны > 0", nameof(n));

            var result = "";

            for (var i = 1; i <= n; i++)
            {
                for (var j = 1; j <= n; j++)
                {
                    if (i == 1 || i == n || j == 1 || j == n)
                    {
                        result += "X ";
                    }
                    else
                    {
                        result += "  ";
                    }
                }
                result += "\n";
            }

            return result;
        }

        /// <summary>
        /// Функция для проверки, содержит ли строка последовательность букв "hello"
        /// </summary>
        /// <param name="input"> Исходная строка </param>
        /// <returns> Выводит "YES" или "NO" в зависимости от того, содержит ли строка последовательность букв "hello" </returns>
        static bool GetRepeatedLetters(string input, string word)
        {
            var index = 0;

            for (var i = 0; i < input.Length; i++)
            {
                if (input[i] == word[index])
                {
                    index++;

                    if (index == word.Length)
                    {
                        return true;
                    }
                }
            }

            return false;
        }
        /// <summary>
		/// Проверяет, что <paramref name="value"/> >= 0.
		/// </summary>
		/// <param name="value">Проверяемое значение.</param>
		/// <param name="message">Сообщение для пользователя об ошибке.</param>
		/// <param name="paramName">Имя аргумента с ошибкой.</param>
		/// <param name="limit">Граница допустимых значений.</param>
		/// <exception cref="ArgumentException"></exception>
		public static void CheckValueGreaterThan(double value, string message,
            string paramName, double limit = 0)
        {
            if (value <= limit)
            {
                throw new ArgumentException(message, paramName);
            }
        }

        class File
        {
            public string name;
            public string path;
            public int size;

            public int GetSize()
            {
                return size;
            }

        }

        class Directory
        {
            public string name;
            public string path;

            public List<File> files;
            public List<Directory> durectories;

            public int GetSize()
            {
                int totalSize = 0;
                
                foreach (File file in files)
                {
                    totalSize += file.GetSize();
                }

                foreach (Directory durectory in durectories)
                {
                    totalSize += durectory.GetSize();
                }

                return totalSize;
            }

        }

    }
}