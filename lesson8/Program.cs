using System;
using System.Resources;
using System.Configuration;


namespace lesson8
{
    class Program
    {
        /// <summary>
        /// Метод для вывода настроек на консоль
        /// </summary>
        /// <returns></returns>
        static bool PrintSettings()
        {
            try
            {
                var appSettings = ConfigurationManager.AppSettings;

                if (appSettings.Count == 0)
                {
                    Console.WriteLine("Конфигурация не найдена");
                    var tuple = GetSettingsFromConsole();
                    SaveSettings("Name", tuple.Item1);
                    SaveSettings("Age", tuple.Item2);
                    SaveSettings("Profesion", tuple.Item3);
                    return false;
                }

                Console.WriteLine("Найдена следующая конфигурация");
                foreach (var key in appSettings.AllKeys)
                {
                    Console.WriteLine($"{key}: {appSettings[key]}");
                }

            }
            catch (ConfigurationErrorsException)
            {
                Console.WriteLine("Ошибка чтения конфигурации");
                return false;
            }
            return true;
        }

        /// <summary>
        /// Медод для обновления или сохранения полей в конфиг-файле
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        static void SaveSettings(string key, string value)
        {
            try
            {
                var configFile = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                var settings = configFile.AppSettings.Settings;
                if (settings[key] == null)
                {
                    settings.Add(key, value);
                }
                else
                {
                    settings[key].Value = value;
                }
                configFile.Save(ConfigurationSaveMode.Modified);
                ConfigurationManager.RefreshSection(configFile.AppSettings.SectionInformation.Name);
            }
            catch (ConfigurationErrorsException)
            {
                Console.WriteLine("Ошибка записи полей в файл");
            }

        }

        /// <summary>
        /// Метод для инициализации параметров конфигурации из консоли
        /// </summary>
        /// <returns></returns>
        static (string, string, string) GetSettingsFromConsole()
        {
            Console.Write("Ведите имя пользователя: ");
            string name = Console.ReadLine();

            Console.Write("Ведите возраст пользователя: ");
            string age = Console.ReadLine();

            Console.Write("Ведите род деятельности пользователя: ");
            string proffesion = Console.ReadLine();

            return (name, age, proffesion);
        }

        static void Main(string[] args)
        {
            Console.WriteLine(Properties.Resources.Greeteing);

            if (PrintSettings())
            {
                Console.Write("Хотите обновить текущую конфигурацию? Y/N ");
                while (true)
                {
                    ConsoleKey key = Console.ReadKey(true).Key;
                    if (key != ConsoleKey.Y && key != ConsoleKey.N) continue;
                    Console.WriteLine();
                    if (key == ConsoleKey.N) break;
                    var tuple = GetSettingsFromConsole();
                    SaveSettings("Name", tuple.Item1);
                    SaveSettings("Age", tuple.Item2);
                    SaveSettings("Profesion", tuple.Item3);
                    Console.WriteLine("Конфигурация обновлена");
                    break;
                }
            }

            Console.ReadLine();
        }
    }
}
