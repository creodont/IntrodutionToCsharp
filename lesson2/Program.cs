using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lesson2
{
    class Program
    {
        [Flags]
        public enum DaysOfWeek
        {
            Mon = 0b_000_0001,
            Tue = 0b_000_0010,
            Wed = 0b_000_0100,
            Thu = 0b_000_1000,
            Fri = 0b_001_0000,
            Sat = 0b_010_0000,
            Sun = 0b_100_0000
        }
        static void Main(string[] args)
        {
            double minTemp, maxTemp, midTemp;
            bool flag;
            int monthNumber;
            
            //1.	Запросить у пользователя минимальную и максимальную температуру за сутки и вывести среднесуточную температуру.
            #region case1


            Console.Write("Введите минимальную температуру: ");

            flag = double.TryParse(Console.ReadLine(), out minTemp);

            if (!flag)
            {
                Console.WriteLine("Не удалось преобразовать строку в число");
                Console.ReadLine();
                return;
            }

            Console.Write("Введите максимальную температуру: ");

            flag = double.TryParse(Console.ReadLine(), out maxTemp);

            if (!flag)
            {
                Console.WriteLine("Не удалось преобразовать строку в число");
                Console.ReadLine();
                return;
            }

            midTemp = Math.Round((minTemp + maxTemp) / 2, 1);

            Console.WriteLine($"Средняя температура: {midTemp}");
            Console.ReadLine();

            #endregion

            //2.	Запросить у пользователя порядковый номер текущего месяца и вывести его название.
            //5.  (*) Если пользователь указал месяц из зимнего периода, а средняя температура > 0, вывести сообщение «Дождливая зима».
            #region case2

            Console.Write("Введите номер месяца: ");
            flag = int.TryParse(Console.ReadLine(), out monthNumber);

            if (!flag)
            {
                Console.WriteLine("Не удалось преобразовать строку в число");
                Console.ReadLine();
                return;
            }
            
            if (monthNumber > 12 || monthNumber < 1)
            {
                Console.WriteLine("Месяца с таким номером не существует, в году 12 месяцев!!!");
                Console.ReadLine();
                return;
            }
            
            DateTime date = new DateTime(2021, monthNumber, 1);
            Console.WriteLine($"Выбран месяц: {date.ToString("MMMM")}");
            
            if ((monthNumber == 12 || monthNumber < 3) && (midTemp > 0)) Console.WriteLine("Дождливая зима");
            Console.ReadLine();

            #endregion

            //3.	Определить, является ли введённое пользователем число чётным.
            #region case3
            Console.Write("Введите число: ");

            int Number;
            flag = int.TryParse(Console.ReadLine(), out Number);

            if (!flag)
            {
                Console.WriteLine("Не удалось преобразовать строку в число");
                Console.ReadLine();
                return;
            }
            if (Number % 2 == 0) Console.WriteLine("Введенное число чётное");
            else Console.WriteLine("Введенное число нечетное");
            Console.ReadLine();

            #endregion
            
            //4.	Для полного закрепления понимания простых типов найдите любой чек,
            //либо фотографию этого чека в интернете и схематично нарисуйте его в консоли, 
            //только за место динамических, по вашему мнению, данных (это может быть дата, название магазина, сумма покупок)
            //подставляйте переменные, которые были заранее заготовлены до вывода на консоль.
            #region case4

            Console.WriteLine("Для печати чека заполните следующие поля");
            Console.Write("Укажите название магазина: ");
            string storeName = Console.ReadLine();
            Console.Write("Введите номер кассира: ");
            string casNumb = Console.ReadLine();
            Console.Write("Введите номер продажи: ");
            string selNumb = Console.ReadLine();
            Console.Write("Введите сумму покупки: ");
            double total = Math.Round(Convert.ToDouble(Console.ReadLine()), 2);
            double tax = Math.Round(total * 18 / 118, 2);
            Console.Write("Введите способ оплаты: ");
            string payment = Console.ReadLine();
            Console.WriteLine();
            Console.WriteLine("КАССОВЫЙ ЧЕК:");
            //вывод чека
            Console.WriteLine($"\tООО \"{storeName}\"" +
                $"\nККМ 00645455 ИНН 0078002174043 #2743" +
                $"\n{DateTime.Now}\tКассир {casNumb}" +
                $"\nПродажа №{selNumb}" +
                $"\n01\t={total}" +
                $"\nВКЛЮЧАЯ НАЛОГИ\nНДС\t={tax}" +
                $"\n\nИТОГ\t={total}" +
                $"\n{payment}\t={total}" +
                $"\n===========ФП==========="
                );
            Console.ReadLine();
            #endregion
           
            //6.	(*) Для полного закрепления битовых масок, попытайтесь создать универсальную структуру расписания недели, к примеру,
            //чтобы описать работу какого либо офиса. Явный пример - офис номер 1 работает со вторника до пятницы, 
            //офис номер 2 работает с понедельника до воскресенья и выведите его на экран консоли.
            #region case6
            byte office1, office2, office3;
            Console.WriteLine("Введите почередно код в расписании для каждого офиса в пределах 0-127");
            Console.Write("Офис №1: ");
            office1 = Convert.ToByte(Console.ReadLine());
            Console.Write("Офис №2: ");
            office2 = Convert.ToByte(Console.ReadLine());
            Console.Write("Офис №3: ");
            office3 = Convert.ToByte(Console.ReadLine());
            Console.WriteLine();
            //печать расписания
            Console.WriteLine("Расписание работы офисов");
            string buff;
            // понедельник
            buff = String.Empty;
            buff = ((office1 & (byte)DaysOfWeek.Mon) == (byte)DaysOfWeek.Mon) ? "офис №1|" : "";
            buff = ((office2 & (byte)DaysOfWeek.Mon) == (byte)DaysOfWeek.Mon) ? buff + "офис №2|" : buff + "";
            buff = ((office3 & (byte)DaysOfWeek.Mon) == (byte)DaysOfWeek.Mon) ? buff + "офис №3|" : buff + "";
            if (buff == "") buff = "никто не работает";
            Console.WriteLine($"Понедельник:\t{buff}");

            // Вторник
            buff = String.Empty;
            buff = ((office1 & (byte)DaysOfWeek.Tue) == (byte)DaysOfWeek.Tue) ? "офис №1|" : "";
            buff = ((office2 & (byte)DaysOfWeek.Tue) == (byte)DaysOfWeek.Tue) ? buff + "офис №2|" : buff + "";
            buff = ((office3 & (byte)DaysOfWeek.Tue) == (byte)DaysOfWeek.Tue) ? buff + "офис №3|" : buff + "";
            if (buff == "") buff = "никто не работает";
            Console.WriteLine($"Вторник:\t{buff}");

            // Среда
            buff = String.Empty;
            buff = ((office1 & (byte)DaysOfWeek.Wed) == (byte)DaysOfWeek.Wed) ? "офис №1|" : "";
            buff = ((office2 & (byte)DaysOfWeek.Wed) == (byte)DaysOfWeek.Wed) ? buff + "офис №2|" : buff + "";
            buff = ((office3 & (byte)DaysOfWeek.Wed) == (byte)DaysOfWeek.Wed) ? buff + "офис №3|" : buff + "";
            if (buff == "") buff = "никто не работает";
            Console.WriteLine($"Среда:\t\t{buff}");

            // Четверг
            buff = String.Empty;
            buff = ((office1 & (byte)DaysOfWeek.Thu) == (byte)DaysOfWeek.Thu) ? "офис №1|" : "";
            buff = ((office2 & (byte)DaysOfWeek.Thu) == (byte)DaysOfWeek.Thu) ? buff + "офис №2|" : buff + "";
            buff = ((office3 & (byte)DaysOfWeek.Thu) == (byte)DaysOfWeek.Thu) ? buff + "офис №3|" : buff + "";
            if (buff == "") buff = "никто не работает";
            Console.WriteLine($"Четверг:\t{buff}");

            // пятница
            buff = String.Empty;
            buff = ((office1 & (byte)DaysOfWeek.Fri) == (byte)DaysOfWeek.Fri) ? "офис №1|" : "";
            buff = ((office2 & (byte)DaysOfWeek.Fri) == (byte)DaysOfWeek.Fri) ? buff + "офис №2|" : buff + "";
            buff = ((office3 & (byte)DaysOfWeek.Fri) == (byte)DaysOfWeek.Fri) ? buff + "офис №3|" : buff + "";
            if (buff == "") buff = "никто не работает";
            Console.WriteLine($"Пятница:\t{buff}");

            // Суббота
            buff = String.Empty;
            buff = ((office1 & (byte)DaysOfWeek.Sat) == (byte)DaysOfWeek.Sat) ? "офис №1|" : "";
            buff = ((office2 & (byte)DaysOfWeek.Sat) == (byte)DaysOfWeek.Sat) ? buff + "офис №2|" : buff + "";
            buff = ((office3 & (byte)DaysOfWeek.Sat) == (byte)DaysOfWeek.Sat) ? buff + "офис №3|" : buff + "";
            if (buff == "") buff = "никто не работает";
            Console.WriteLine($"Суббота:\t{buff}");

            // Воскресенье
            buff = String.Empty;
            buff = ((office1 & (byte)DaysOfWeek.Sun) == (byte)DaysOfWeek.Sun) ? "офис №1|" : "";
            buff = ((office2 & (byte)DaysOfWeek.Sun) == (byte)DaysOfWeek.Sun) ? buff + "офис №2|" : buff + "";
            buff = ((office3 & (byte)DaysOfWeek.Sun) == (byte)DaysOfWeek.Sun) ? buff + "офис №3|" : buff + "";
            if (buff == "") buff = "никто не работает";
            Console.WriteLine($"Воскресенье:\t{buff}");

            Console.ReadLine();


            #endregion
        }
    }
}
