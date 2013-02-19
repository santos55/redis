using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Services;


namespace TestConsole
{
    class Program
    {
        static void Main(string[] args)
        {

            var queue = new QueueManager();

            queue.Set("key1", "value1");
            Console.WriteLine(queue.Get("key1").Result);

            Console.ReadKey();
        }
    }
}
