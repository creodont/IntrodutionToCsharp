using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace lesson1
{
    class Program
    {
        static void Main(string[] args)
        {
            // объявление переменной для имени пользователя
            string name = String.Empty;

            Console.Write("Введите имя пользователя: ");

            // получить имя пользователя
            name = Console.ReadLine();

            Console.WriteLine($"Привет, {name}, сегодня {DateTime.Now.ToString("D")}");

            Console.ReadLine();
        }
    }
}
