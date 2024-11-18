using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HandsOn
{
    class Program
    {
        static int counter = 0;
        static readonly object lockObject = new object();

        static void Main(string[] args)
        {
            Thread thread1 = new Thread(IncrementCounter);
            Thread thread2 = new Thread(IncrementCounter);
            thread1.Start();
            thread2.Start();
            thread1.Join();
            thread2.Join();
            Console.WriteLine("Final Counter Value: " + counter);
            Console.Read();
        }

        static void IncrementCounter()
        {
            Console.WriteLine("Thread executed");
            for (int i = 0; i < 5000; i++)
            {
                lock (lockObject)
                {
                    counter++;
                }
            }
        }
    }
}
