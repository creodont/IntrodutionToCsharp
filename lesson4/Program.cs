using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lesson4
{
    class Program
    {
        public enum Season
        {
            Winter,
            Spring,
            Summer,
            Autumn

        }

        static string GetFullName(string firstName, string lastName, string patronymic)
        {
            return $"ФИО: {lastName} {firstName} {patronymic}";

        }


        static (int, bool) SumNumbers(string strNumb)
        {
            string[] numbers = strNumb.Split(' ');
            int sum = 0;
            int number;
            bool error = false;

            for (int i = 0; i < numbers.Length; i++)
            {
                if (!int.TryParse(numbers[i], out number))
                {
                    Console.WriteLine($"Ошибка преобразования: символ \"{numbers[i]}\" недопустим");
                    error = true;
                    break;
                }
                sum = sum + number;
            }
            return (sum, error);

        }


        static Season? GetSeason(int month, out bool error)
        {
            Season season;
            error = false;

            if (month > 12 || month < 1)
            {
                Console.WriteLine("Ошибка: введите число от 1 до 12");
                error = true;
                return null;
            }

            if ((month >= 1 && month < 3) || month == 12) season = Season.Winter;
            else if (month > 2 && month < 6) season = Season.Spring;
            else if (month > 5 && month < 9) season = Season.Summer;
            else season = Season.Autumn;

            return season;

        }

        static void PrintSeason(Season season)
        {
            Console.WriteLine("Время года: " + Enum.GetName(typeof(Season), season));
        }

        static int CalcFibonacci(int number)
        {
            if (number == 1) return 0;
            else if (number == 2) return 1;
            else return CalcFibonacci(number - 1) + CalcFibonacci(number - 2);
        }

        static void Main(string[] args)
        {

            // 1.	Написать метод GetFullName(string firstName, string lastName, string patronymic), 
            // принимающий на вход ФИО в разных аргументах и возвращающий объединённую строку с ФИО. 
            // Используя метод, написать программу, выводящую в консоль 3–4 разных ФИО.
            #region case 1
            for (int i = 0; i < 3; i++)
            {
                Console.Write("Введите фамилию:  ");
                string surname = Console.ReadLine();
                Console.Write("Введите имя:      ");
                string name = Console.ReadLine();
                Console.Write("Введите отчество: ");
                string patronymic = Console.ReadLine();
                Console.WriteLine(GetFullName(name, surname, patronymic)+'\n');

            }
            
            Console.ReadLine();
            #endregion

            // 2.	Написать программу, принимающую на вход строку — набор чисел, разделенных пробелом,
            // и возвращающую число — сумму всех чисел в строке. Ввести данные с клавиатуры и вывести результат на экран. 
            #region case 2
            while (true)
            {
                Console.Write("Введите набор чисел через пробел: ");
                (int sum, bool error) = SumNumbers(Console.ReadLine());
                if (!error)
                {
                    Console.WriteLine($"Сумма чисел из ряда: {sum}");
                    break;
                }
                Console.WriteLine("Произошла ошибка ввода, попробуйте снова!!!\n");

            }

            Console.ReadLine();
            #endregion

            // 3.	Написать метод по определению времени года. На вход подаётся число – порядковый номер месяца.
            // На выходе — значение из перечисления (enum) — Winter, Spring, Summer, Autumn.
            // Написать метод, принимающий на вход значение из этого перечисления и возвращающий название времени года (зима, весна, лето, осень).
            // Используя эти методы, ввести с клавиатуры номер месяца и вывести название времени года.
            // Если введено некорректное число, вывести в консоль текст «Ошибка: введите число от 1 до 12».
            #region case 3
            while (true)
            {
                Console.Write("Введите номер месяца: ");
                int monthNumber;
                bool error;
                if (!int.TryParse(Console.ReadLine(), out monthNumber))
                {
                    Console.WriteLine("Ошибка преобразования в число\n");
                    continue;
                }
                Season? season = GetSeason(monthNumber, out error);
                if (!error)
                {
                    PrintSeason((Season)season);
                    break;
                }
             }
            Console.ReadLine();
            #endregion

            // 4.	(*) Написать программу, вычисляющую число Фибоначчи для заданного значения рекурсивным способом.
            #region case 4
            while (true)
            {
                int fibNumber;
                Console.Write("Введите номер числа из ряда Фибоначчи: ");
                if (!int.TryParse(Console.ReadLine(), out fibNumber))
                {
                    Console.WriteLine("Ошибка преобразования в число\n");
                    continue;
                }
                if (fibNumber == 0)
                {
                    Console.WriteLine("Ошибка!!! Начало нумерации с 1\n");
                    continue;
                }

                Console.WriteLine($"Число Фибоначчи номер {fibNumber}: {CalcFibonacci(fibNumber)}");
                break;
            }
            Console.ReadLine();
            #endregion

        }
    }
}
