using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Task_4
{
    class Program
    {
        static int counter = 0;
        static object block = new object();

        static void Function()
        {
            lock (block)
            {
                for (int i = 0; i < 10; ++i)
                {
                    Console.WriteLine(++counter);
                }

                Console.WriteLine(new String('-', 50));
            }
        }

        static void Main()
        {
            Thread[] threads = { new Thread(Function), new Thread(Function), new Thread(Function) };

            foreach (Thread thread in threads)
                thread.Start();

            // Delay
            Console.ReadKey();
        }
    }
}
