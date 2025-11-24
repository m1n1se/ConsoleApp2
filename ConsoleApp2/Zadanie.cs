using System;

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
                GetOddNumbers(n);
            }

            Console.WriteLine("Квадрат:");
            Console.WriteLine(GetKubX(n));

            Console.Write("Введите строку для проверки: ");
            
            string userInput = Console.ReadLine();

            Console.WriteLine("Результат проверки:");
            Console.WriteLine(GetRepeatedLetters(userInput, "hello"));
        }

        /// <summary>
        /// Функция для получения нечетных чисел от 1 до n
        /// </summary>
        /// <param name="n"> Граница, до которой будут браться нечетные числа </param>
        /// <returns> Выводит нечетные числа от 1 до n </returns>
        static string GetOddNumbers(int n)
        {
            CheckValueGreaterThan(n, "Ожидается число > 0", nameof(n));

            string result = "";

            for (int i = 1; i <= n; i += 2)
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

            string result = "";

            for (int i = 1; i <= n; i++)
            {
                for (int j = 1; j <= n; j++)
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
            int index = 0;

            for (int i = 0; i < input.Length; i++)
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
    }
}