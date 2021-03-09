using System;
using System.IO;
using System.Text.Json;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lesson5
{
    class Program
    {
        /// <summary>
        /// Метод сохранения строки в файл
        /// </summary>
        /// <param name="path"></param>
        private static void SaveToFile(string path)
        {
            Console.Write($"Введите текст для сохранения в файле \"{path}\": ");
            File.WriteAllText(path, Console.ReadLine());
            Console.WriteLine($"Текст сохранён в файл \"{path}\"");
            Console.ReadLine();
        }

        /// <summary>
        /// Метод для добавления времени в файл
        /// </summary>
        /// <param name="path"></param>
        private static void AddTimeToFile(string path)
        {
            File.AppendAllText(path, DateTime.Now.ToString("[HH:mm:ss]\r\n"));
            Console.Write($"Текущее время добавлено в файл \"{path}\"");
            Console.ReadLine();
        }

        /// <summary>
        /// Метод записи байт в бинарный файл
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        private static bool SaveToBinFile(string path)
        {
            Console.Write("Введите числа от 0 до 255 через пробел: ");
            string str = Console.ReadLine();
            if (string.IsNullOrEmpty(str))
            {
                Console.WriteLine("Ошибка!!! Ввод пустой строки");
                return false;
            }
            string[] strArray = str.Split(' ');
            byte[] bytes = new byte[strArray.Length];
            for (int index = 0; index < strArray.Length; ++index)
            {
                if (!byte.TryParse(strArray[index], out bytes[index]))
                {
                    Console.WriteLine($"Ошибка!!! Введено недопустимое значение \"{strArray[index]}\"");
                    return false;
                }
            }
            File.WriteAllBytes(path, bytes);
            Console.WriteLine($"Перечень байт сохранен в файле \"{path}\"");
            return true;
        }

        /// <summary>
        /// Метод для вывода списка папок
        /// </summary>
        /// <param name="path"></param>
        /// <param name="isAllDir"></param>
        /// <param name="getDirs"></param>
        /// <returns></returns>
        private static bool TryGetDirectory(string path, bool isAllDir, out string getDirs)
        {
            getDirs = string.Empty;
            SearchOption searchOption = isAllDir ? SearchOption.AllDirectories : SearchOption.TopDirectoryOnly;
            if (!Directory.Exists(path))
            {
                Console.WriteLine($"Ошибка!!! Путь \"{path}\" не существует");
                return false;
            }
            foreach (string fileSystemEntry in Directory.GetFileSystemEntries(path, "*", searchOption))
            {
                if ((File.GetAttributes(fileSystemEntry) & FileAttributes.Directory) == FileAttributes.Directory)
                    getDirs = getDirs + fileSystemEntry + "\n";
            }
            return true;
        }

        /// <summary>
        /// Метод для вывода списка папок
        /// </summary>
        /// <param name="isRecursion"></param>
        private static void PrintDir(bool isRecursion)
        {
            Console.Write("Введите путь: ");
            string path = Console.ReadLine();
            Console.WriteLine(isRecursion ? "Вывод списка папок с рекурсией:" : "Вывод списка папок без рекурсии:");
            string getDirs;
            if (TryGetDirectory(path, isRecursion, out getDirs))
            {
                Console.WriteLine(getDirs);
            }
            else
            {
                Console.WriteLine("Попробуйте снова...\n");
                Console.ReadLine();
                PrintDir(isRecursion);
            }
        }

        static void Main(string[] args)
        {
            // 1.	Ввести с клавиатуры произвольный набор данных и сохранить его в текстовый файл.
            #region case1
            SaveToFile("new text file.txt");
            #endregion

            // 2.	Написать программу, которая при старте дописывает текущее время в файл «startup.txt».
            #region case2
            for (int index = 0; index < 3; ++index) AddTimeToFile("startup.txt");
            #endregion

            // 3.	Ввести с клавиатуры произвольный набор чисел (0...255) и записать их в бинарный файл.
            #region case3
            Console.WriteLine();
            while (!SaveToBinFile("new binary file.bin"))  Console.WriteLine("Попробуйте снова...\n");
            Console.ReadLine();
            #endregion

            // 4.	(*) Сохранить дерево каталогов и файлов по заданному пути в текстовый файл — с рекурсией и без.
            #region case4
            // вывод папок без рекурсии
            PrintDir(false);
            // вывод папок с рекурсией
            PrintDir(true);
            Console.ReadLine();
            #endregion

            // 5.	(*) Список задач (ToDo-list)
            #region case5
            string path = "tasks.json";
            bool flag = true;
            ToDo[] toDoArray;
            if (File.Exists(path))
            {
                Console.Write("Файл задач существует");
                string[] strArray = File.ReadAllLines(path);
                toDoArray = new ToDo[strArray.Length];
                for (int index = 0; index < toDoArray.Length; ++index)
                {
                    if (strArray[index] != string.Empty)
                    {
                        toDoArray[index] = JsonSerializer.Deserialize<ToDo>(strArray[index]);
                        flag = false;
                    }
                }
                Console.WriteLine(flag ? ", но пустой" : " и будет загружен список задач:");
            }
            else
            {
                Console.WriteLine("Файла задач не существует");
                toDoArray = new ToDo[0];
            }
            if (flag)
            {
                string[] strArray;
                while (true)
                {
                    Console.WriteLine("Введите задачи вручную через запятую: ");
                    strArray = Console.ReadLine().Split(new char[1]{','}, StringSplitOptions.RemoveEmptyEntries);
                    if (strArray.Length < 1)
                        Console.WriteLine("Список задач пуст...");
                    else
                        break;
                }
                toDoArray = new ToDo[strArray.Length];
                for (int index = 0; index < toDoArray.Length; ++index)
                    toDoArray[index] = new ToDo(strArray[index], false);
                Console.WriteLine("Получившийся список:");
            }
            for (int index = 0; index < toDoArray.Length; ++index)
                toDoArray[index].PrintTask(index + 1);
            int length = toDoArray.Length;
            while (length > 0)
            {
                Console.Write("Введите номер выполненой задачи или \"0\" для завершения: ");
                string s = Console.ReadLine();
                int result;
                if (!int.TryParse(s, out result) || result > toDoArray.Length)
                    Console.WriteLine($"Ошибка!!! Недопустимый символ \"{s}\"");
                else if (result != 0)
                {
                    toDoArray[result - 1].IsDone = true;
                    --length;
                }
                else
                    break;
            }
            Console.WriteLine("Результирующий список:");
            File.WriteAllText(path, "");
            for (int index = 0; index < toDoArray.Length; ++index)
            {
                if (!toDoArray[index].IsDone)
                {
                    string str = JsonSerializer.Serialize<ToDo>(toDoArray[index]);
                    File.AppendAllText(path, str + "\r\n");
                }
                toDoArray[index].PrintTask(index + 1);
            }
            Console.WriteLine($"Список актуальных задач сохранён в файл \"{path}\"");
            Console.ReadLine();
            #endregion
        }

    }
}
