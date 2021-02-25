using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lesson3
{
    class Program
    {
        public enum Ships
        {
            battleship,
            cruiserN1,
            cruiserN2,
            destroyerN1,
            destroyerN2,
            destroyerN3,
            torpedoBoatN1,
            torpedoBoatN2,
            torpedoBoatN3,
            torpedoBoatN4
        }

        static bool PlaceShip(int direction, int startX, int startY, ref int[,] restrictX, ref int[,] restrictY, Ships ship, ref char[,] battlefield)
        {
            int index = 0;
            int count = 4;
            switch (ship)
            {
                case Ships.battleship:
                    index = 0;
                    count = 4;
                    break;
                case Ships.cruiserN1:
                    index = 1;
                    count = 3;
                    break;
                case Ships.cruiserN2:
                    index = 2;
                    count = 3;
                    break;
                case Ships.destroyerN1:
                    index = 3;
                    count = 2;
                    break;
                case Ships.destroyerN2:
                    index = 4;
                    count = 2;
                    break;
                case Ships.destroyerN3:
                    index = 5;
                    count = 2;
                    break;
                case Ships.torpedoBoatN1:
                    index = 6;
                    count = 1;
                    break;
                case Ships.torpedoBoatN2:
                    index = 7;
                    count = 1;
                    break;
                case Ships.torpedoBoatN3:
                    index = 8;
                    count = 1;
                    break;
                case Ships.torpedoBoatN4:
                    index = 9;
                    count = 1;
                    break;
            }

            if (direction == 0) return PlaceShipByY(index, count, startX, startY, ref restrictX, ref restrictY, ref battlefield);
            else return PlaceShipByX(index, count, startX, startY, ref restrictX, ref restrictY, ref battlefield);


        }
        static bool PlaceShipByX(int index, int count, int startX, int startY, ref int[,] restrictX, ref int[,] restrictY, ref char[,] battlefield)
        {
            char[,] sbattlefield = new char[battlefield.GetLength(0), battlefield.GetLength(1)];
            Array.Copy(battlefield, sbattlefield, sbattlefield.Length);

            // пытаемся построить горизонтально, сначало вправо относительно начальной точки, если не получилось, то влево
            if (startX < (battlefield.GetLength(0) - count))
            {
                for (int i = 0; i < count; i++)
                {
                    if (!CheckRestricted(index, startX + i, startY, ref restrictX, ref restrictY))
                    {
                        battlefield = sbattlefield;
                        return false;
                    }
                    battlefield[startX + i, startY] = 'X';
                }
                // формируем область запрета по X
                if (startX == 0) restrictX[index, 0] = startX;
                else restrictX[index, 0] = startX - 1;
                restrictX[index, 1] = startX + count;
            }
            else
            {
                for (int i = 0; i < count; i++)
                {
                    if (!CheckRestricted(index, startX - i, startY, ref restrictX, ref restrictY))
                    {
                        battlefield = sbattlefield;
                        return false;
                    }
                    battlefield[startX - i, startY] = 'X';
                }
                // формируем область запрета по X
                if (startX == 9) restrictX[index, 1] = startX;
                else restrictX[index, 1] = startX + 1;
                restrictX[index, 0] = startX - count;

            }
            // формируем область запрета по Y
            if (startY == 0 || startY == 9)
            {
                restrictY[index, 0] = startY;
                restrictY[index, 1] = (startY == 0) ? startY + 1 : startY - 1;
            }
            else
            {
                restrictY[index, 0] = startY - 1;
                restrictY[index, 1] = startY + 1;
            }

            return true;

        }
        static bool PlaceShipByY(int index, int count, int startX, int startY, ref int[,] restrictX, ref int[,] restrictY, ref char[,] battlefield)
        {
            char[,] sbattlefield = new char[battlefield.GetLength(0), battlefield.GetLength(1)];
            Array.Copy(battlefield, sbattlefield, sbattlefield.Length);

            // пытаемся построить вертикально, сначала вверх относительно начальной точки, если не получилось, то вниз
            if (startY < (battlefield.GetLength(0) - count))
            {
                for (int i = 0; i < count; i++)
                {
                    if (!CheckRestricted(index, startX, startY + i, ref restrictX, ref restrictY))
                    {
                        battlefield = sbattlefield;
                        return false;
                    }
                    battlefield[startX, startY + i] = 'X';
                }
                // формируем область запрета по Y
                if (startY == 0) restrictY[index, 0] = startY;
                else restrictY[index, 0] = startY - 1;
                restrictY[index, 1] = startY + count;

            }
            else
            {
                for (int i = 0; i < count; i++)
                {
                    if (!CheckRestricted(index, startX, startY - i, ref restrictX, ref restrictY))
                    {
                        battlefield = sbattlefield;
                        return false;
                    }
                    battlefield[startX, startY - i] = 'X';
                }
                // формируем область запрета по Y
                if (startY == 9) restrictY[index, 1] = startY;
                else restrictY[index, 1] = startY + 1;
                restrictY[index, 0] = startY - count;

            }
            // формируем область запрета по X
            if (startX == 0 || startX == 9)
            {
                restrictX[index, 0] = startX;
                restrictX[index, 1] = (startX == 0) ? startX + 1 : startX - 1;
            }
            else
            {
                restrictX[index, 0] = startX - 1;
                restrictX[index, 1] = startX + 1;
            }

            return true;
        }
        static void PrintBattleField(ref char[,] battlefield)
        {
            Console.WriteLine("    АБВГДЕЖЗИК\n");
            for (int j = 0; j < battlefield.GetLength(1); j++)
                for (int i = 0; i < battlefield.GetLength(0); i++)
                {
                    if (i == 0)
                    {
                        if (j < 9) Console.Write(" " + (j + 1).ToString() + "  " + battlefield[i, j]);
                        else Console.Write((j + 1).ToString() + "  " + battlefield[i, j]);
                    }
                    else
                    {
                        if (i < (battlefield.GetLength(0) - 1)) Console.Write(battlefield[i, j]);
                        else Console.WriteLine(battlefield[i, j]);
                    }

                }
            Console.WriteLine();
        }
        static bool CheckRestricted(int index, int X, int Y, ref int[,] restrictX, ref int[,] restrictY)
        {

            while (index != 0)
            {
                if (((X >= restrictX[index - 1, 0]) && (X <= restrictX[index - 1, 1]))
                    && ((Y >= restrictY[index - 1, 0]) && (Y <= restrictY[index - 1, 1]))) return false;

                index--;
            }

            return true;
        }
        static void Main(string[] args)
        {
            Random rnd = new Random();

            // 1.	Написать программу, выводящую элементы двухмерного массива по диагонали.
            #region case1

            int[,] arr = new int[7, 7];
            int[] diagArr = new int[7];

            Console.WriteLine("Исходный массив:\n");
            // инициализация двумерного массива
            for (int i = 0; i < arr.GetLength(0); i++)
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    arr[i, j] = rnd.Next(10);
                    if (j < (arr.GetLength(1) - 1)) Console.Write(arr[i, j].ToString() + '\t');
                    else Console.WriteLine(arr[i, j].ToString() + "\n\n\n");
                }
            // диагональ
            for (int i = 0; i < 7; i++)
            {
                diagArr[i] = arr[i, i];
            }
            Console.WriteLine($"Диагональ: {String.Join(",", diagArr)}");
            Console.ReadLine();



            #endregion

            // 2.	Написать программу — телефонный справочник — создать двумерный массив 5*2,
            //      хранящий список телефонных контактов: первый элемент хранит имя контакта, второй — номер телефона/e-mail.
            #region case 2

            string[,] phoneBook = new string[5, 2];
            // инициализация телефонной книги
            int n = 0;
            int number;
            int maxLength = 0;
            while (n < phoneBook.GetLength(0))
            {
                Console.Write("Введите имя контакта: ");
                phoneBook[n, 0] = Console.ReadLine();

                if (String.IsNullOrEmpty(phoneBook[n, 0]))
                {
                    Console.WriteLine("Ошибка ввода имени контакта");
                    continue;
                }

                Console.Write("Введите номер контакта: ");
                phoneBook[n, 1] = Console.ReadLine();

                bool flag = true;

                for (int k = 0; k < phoneBook[n, 1].Length; k++)
                {
                    flag = Char.IsNumber(phoneBook[n, 1][k]);
                    if (!flag) break;
                }

                if (!flag)
                {
                    Console.WriteLine("Ошибка ввода номера контакта (в номере должны быть только цифры)");
                    continue;
                }

                // сохранить длину самого длинного имени
                if (maxLength < phoneBook[n, 0].Length) maxLength = phoneBook[n, 0].Length;

                n++;
            }

            // вывод телефонной книги
            Console.WriteLine("\nТелефонная книга: ");
            for (int i = 0; i < phoneBook.GetLength(0); i++)
            {
                Console.WriteLine($"{phoneBook[i, 0]}" + new string('-', maxLength - phoneBook[i, 0].Length) + $"--------{phoneBook[i, 1]}");
            }
            Console.ReadLine();
            #endregion


            // 3.	Написать программу, выводящую введенную пользователем строку в обратном порядке (olleH вместо Hello)

            #region case 3
            string str = String.Empty;

            while (true)
            {
                Console.Write("Введите строку: ");
                str = Console.ReadLine();
                if (str.Length <= 1)
                {
                    Console.WriteLine("Введите больше одного символа");
                    continue;
                }
                break;
            }

            char[] chrArr = str.ToCharArray();
            Array.Reverse(chrArr);
            str = new string(chrArr);

            Console.WriteLine($"Зеркальная строка: {str}");
            Console.ReadLine();

            #endregion

            // 4.	* «Морской бой» — вывести на экран массив 10х10, состоящий из символов X и O,
            //      где Х — элементы кораблей, а О — свободные клетки
            #region case 4
            char[,] battlefield = new char[10, 10];
            int[,] restrictX = new int[10, 2];
            int[,] restrictY = new int[10, 2];

            // заполнить поле
            for (int i = 0; i < battlefield.GetLength(0); i++)
                for (int j = 0; j < battlefield.GetLength(1); j++)
                {
                    battlefield[i, j] = 'O';

                }
            Console.WriteLine("=Вывод игрового поля=");

            // формирование поля боя
            int direction = 0;
            Ships typeOfShip = Ships.battleship;
            bool isExitFlag = false;

            while (!isExitFlag)
            {
                // случайно генерим направление расположения
                direction = rnd.Next(2);
                int startX = rnd.Next(10);
                int startY = rnd.Next(10);

                if (!PlaceShip(direction, startX, startY, ref restrictX, ref restrictY, typeOfShip, ref battlefield)) continue;

                //PrintBattleField(ref battlefield);

                if (typeOfShip == Ships.torpedoBoatN4) isExitFlag = true;

                typeOfShip = (Ships)((int)typeOfShip + 1);



            }

            //вывод картинки
            PrintBattleField(ref battlefield);

            Console.ReadLine();

            #endregion
        }
    }
}
