using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lesson7
{

    class Program
    {
       static void Do()
        {
            int linqCounter = 0;
            var source = new List<byte> { 0, 0, 1, 1, 0};

            var bytes = source.Where(x =>
            {
                linqCounter++;
                return x > 0;
            });

            if (bytes.First() == bytes.Last())
            {

                Console.WriteLine(linqCounter--);
            }
            else
            {
                Console.WriteLine(linqCounter++);
            }
        }

        static void Main(string[] args)
        {
            Do();
            Console.ReadLine();
        }
    }
}
