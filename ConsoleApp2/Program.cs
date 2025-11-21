using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введите число N: ");
            string input = Console.ReadLine();

            if (int.TryParse(input, out int N))
            {
                Console.WriteLine($"Нечетные числа от 1 до {N}:");
                for (int i = 1; i <= N; i += 2)
                {
                    Console.WriteLine(i);
                }
            }
            Console.WriteLine("Квадрат:");
            Console.WriteLine(GetKubX(N));

            // Запрашиваем у пользователя строку для проверки
            Console.Write("Введите строку для проверки: ");
            string userInput = Console.ReadLine();
            Console.WriteLine("Результат проверки:");
            Console.WriteLine(GetRepeatedLetters(userInput));
        }

        static string GetOddNumbers(int n)
        {
            string result = "";

            for (int i = 1; i <= n; i += 2)
            {
                result += i.ToString() + " ";
            }

            return result;
        }

        static string GetKubX(int n)
        {
            string result = "";

            for (int i = 1; i <= n; i++)
            {
                for (int j = 1; j <= n; j++)
                {
                    if (i == 1 || i == n || j == 1 || j == n)// Если это первая или последняя строка, либо первый или последний столбец - ставим X
                    {
                        result += "X ";
                    }
                    else
                    {
                        result += "  "; // Два пробела для выравнивания
                    }
                }
                result += "\n";
            }

            return result;
        }

        static string GetRepeatedLetters(string input)
        {
            string word = "hello";
            int Index = 0;

            for (int i = 0; i < input.Length; i++)
            {

                if (input[i] == word[Index])
                {
                    Index++; 

                    if (Index == word.Length)
                    {
                        return "YES";
                    }
                }
            }

            return "NO";
        }
    }
}