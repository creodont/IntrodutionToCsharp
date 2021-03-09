using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lesson5
{
    /// <summary>
    /// Класс описывающий задачу
    /// </summary>
    class ToDo
    {
        public string Title { get; set; }

        public bool IsDone { get; set; }

        public ToDo()
        {
        }

        public ToDo(string title, bool isDone)
        {
            this.Title = title;
            this.IsDone = isDone;
        }

        /// <summary>
        /// Метод для печати задачи
        /// </summary>
        /// <param name="taskNumb"></param>
        public void PrintTask(int taskNumb)
        {
            char ch = this.IsDone ? 'X' : ' ';
            Console.WriteLine(string.Format("#{0}. {1} [{2}]", (object)taskNumb, (object)this.Title, (object)ch));
        }
    }
}
