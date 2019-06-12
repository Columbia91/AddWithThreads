using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AddWithThreads
{
    class AddParams
    {
        public int a, b;
        public AddParams(int numb1, int numb2)
        {
            a = numb1; b = numb2;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("*****Adding with Thread objects * ****");
            Console.WriteLine("ID of thread in Main(): {0}",
            Thread.CurrentThread.ManagedThreadId);

            // Создать объект AddParams для передачи вторичному потоку.
            AddParams ар = new AddParams(10, 10);
            Thread t = new Thread(new ParameterizedThreadStart(Add));
            t.Start(ар);
            
            // Подождать, пока другой поток завершится.
            Thread.Sleep(5);
            Console.ReadLine();
        }

        static void Add(object data)
        {
            Console.WriteLine("ID of thread in Add(): {0}",
            Thread.CurrentThread.ManagedThreadId);

            AddParams ар = (AddParams)data;

            Console.WriteLine("{0} + {1} is {2}",
            ар.a, ар.b, ар.a + ар.b);
        }
    }
}
