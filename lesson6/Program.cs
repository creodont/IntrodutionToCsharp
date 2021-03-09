using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace lesson6
{
    class Program
    {
        /// <summary>
        /// Метод завершения процесса по имени
        /// </summary>
        /// <param name="name"></param>
        static void killProcessByName(string name)
        {
            Process[] processes = Process.GetProcessesByName(name);
            if (processes.Length < 1)
            {
                Console.WriteLine($"Ошибка!!! Процесс с \"{name}\" не найден");
                return;
            }
            try
            {
                foreach(Process process in processes)
                    process.Kill();
            }
            catch (Exception e)
            {
                Console.WriteLine($"При завершении процесса произошла ошибка: {e.Message}");
            }

            if (processes.Length == 1) Console.WriteLine($"Процесс \"{ name}\" завершён");
            else Console.WriteLine($"Процессы \"{ name}\" завершены");

        }

        /// <summary>
        /// Метод завершения процесса по id
        /// </summary>
        /// <param name="id"></param>
        static void killProcessById(int id)
        {
            Process process = Process.GetProcessById(id);
            if (process == null)
            {
                Console.WriteLine($"Ошибка!!! Процесс с id={id.ToString()} не найден");
                return;
            }
            try
            {
                process.Kill();
            }
            catch(Exception e)
            {
                Console.WriteLine("При завершении процесса произошла ошибка: " + e.Message);
            }

            Console.WriteLine($"Процесс \"{process.ProcessName}\" завершён");
        }

        static void Main(string[] args)
        {

            while (true)
            {
                Console.WriteLine("\nСписок запущенных процессов:");

                Process[] processes = Process.GetProcesses();

                foreach(Process process in processes)
                {
                    Console.Write($"[name = {process.ProcessName}]" + new string('-', Console.WindowWidth - 18 - process.ProcessName.Length));
                    Console.SetCursorPosition(Console.WindowWidth - 18, Console.CursorTop);
                    Console.WriteLine($"[id = {process.Id}];");
                }

                Console.WriteLine("\nДля завершения процесса по имени введите: name= {processName}");
                Console.WriteLine("Для завершения процесса по идентификатору введите: id= {processId}");
                Console.WriteLine("Для выхода из приложения введите: exit");

                string[] strArr = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                int id;
                switch ((strArr.Length>0)?strArr[0].ToLower(): "error")
                {
                    case "exit": 
                        return;
                    case "name=":
                        if (strArr.Length > 1)
                            killProcessByName(strArr[1]);
                        else Console.WriteLine("Ошибка!!! Не задано имя процесса");
                        break;
                    case "id=":
                        if (strArr.Length > 1)
                        {
                            if (int.TryParse(strArr[1], out id)) killProcessById(id);
                            else Console.WriteLine($"Ошибка преобразования id, значение \"{strArr[1]}\" не допустимо");
                        }
                        else Console.WriteLine("Ошибка!!! Не указано id процесса");

                        break;
                    default:
                        Console.WriteLine("Ошибка!!! Введен недопустимый параметр, попробуйте снова");
                        Console.ReadLine();
                        continue;
                }
                Console.ReadLine();
            }



        }
    }
}
