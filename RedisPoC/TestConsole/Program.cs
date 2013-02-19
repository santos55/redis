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

            const string key1 = "key1";

            Console.WriteLine("{0} exists: {1}", key1, queue.Exists(key1).Result);
            queue.Set(key1, "value1");
            Console.WriteLine("{0} set", key1);
            Console.WriteLine("{0} exists: {1}", key1, queue.Exists(key1).Result);
            Console.WriteLine(queue.GetAsync(key1).Result);


            const string listKey1 = "listKey1";
            Console.WriteLine("{0} exists: {1}", listKey1, queue.Exists(listKey1).Result);

            queue.AddListHead(listKey1, "value1");
            Console.WriteLine("{0} head is: {1}", listKey1, queue.GetListHeadAsync(listKey1).Result);

            queue.AddListHead(listKey1, "value2");
            Console.WriteLine("{0} head is: {1}", listKey1, queue.GetListHeadAsync(listKey1).Result);

            queue.AddListHead(listKey1, "value3");
            Console.WriteLine("{0} head is: {1}", listKey1, queue.GetListHeadAsync(listKey1).Result);

            queue.AddListHead(listKey1, "value4");
            Console.WriteLine("{0} head is: {1}", listKey1, queue.GetListHeadAsync(listKey1).Result);
            
            queue.AddListTail(listKey1, "value0");
            Console.WriteLine("{0} head is: {1}", listKey1, queue.GetListHeadAsync(listKey1).Result);
            Console.WriteLine("{0} tails is: {1}", listKey1, queue.GetListTailAsync(listKey1).Result);

            Console.ReadKey();
        }
    }
}
