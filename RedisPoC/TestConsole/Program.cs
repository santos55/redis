using System;
using Services;

namespace TestConsole
{
    public class Program
    {
        static void Main()
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
            Console.WriteLine("{0} head is: {1} with len: {2} ", listKey1, queue.GetListHeadAsync(listKey1).Result, queue.GetListLenghAsync(listKey1).Result);
            Console.WriteLine("{0} tails is: {1} with len: {2} ", listKey1, queue.GetListTailAsync(listKey1).Result, queue.GetListLenghAsync(listKey1).Result);
            foreach (var elem in queue.GetListAsync(listKey1).Result)
            {
                Console.WriteLine("elem: {0}",elem);
            }
            

            queue.AddListHead(listKey1, "value2");
            Console.WriteLine("{0} head is: {1} with len: {2} ", listKey1, queue.GetListHeadAsync(listKey1).Result, queue.GetListLenghAsync(listKey1).Result);
            Console.WriteLine("{0} tails is: {1} with len: {2} ", listKey1, queue.GetListTailAsync(listKey1).Result, queue.GetListLenghAsync(listKey1).Result);
            foreach (var elem in queue.GetListAsync(listKey1).Result)
            {
                Console.WriteLine("elem: {0}", elem);
            }

            queue.AddListHead(listKey1, "value3");
            Console.WriteLine("{0} head is: {1} with len: {2} ", listKey1, queue.GetListHeadAsync(listKey1).Result, queue.GetListLenghAsync(listKey1).Result);
            Console.WriteLine("{0} tails is: {1} with len: {2} ", listKey1, queue.GetListTailAsync(listKey1).Result, queue.GetListLenghAsync(listKey1).Result);
            foreach (var elem in queue.GetListAsync(listKey1).Result)
            {
                Console.WriteLine("elem: {0}", elem);
            }

            queue.AddListHead(listKey1, "value4");
            Console.WriteLine("{0} head is: {1} with len: {2} ", listKey1, queue.GetListHeadAsync(listKey1).Result, queue.GetListLenghAsync(listKey1).Result);
            Console.WriteLine("{0} tails is: {1} with len: {2} ", listKey1, queue.GetListTailAsync(listKey1).Result, queue.GetListLenghAsync(listKey1).Result);
            foreach (var elem in queue.GetListAsync(listKey1).Result)
            {
                Console.WriteLine("elem: {0}", elem);
            }
            
            queue.AddListTail(listKey1, "value0");
            Console.WriteLine("{0} head is: {1} with len: {2} ", listKey1, queue.GetListHeadAsync(listKey1).Result, queue.GetListLenghAsync(listKey1).Result);
            Console.WriteLine("{0} tails is: {1} with len: {2} ", listKey1, queue.GetListTailAsync(listKey1).Result, queue.GetListLenghAsync(listKey1).Result);
            foreach (var elem in queue.GetListAsync(listKey1).Result)
            {
                Console.WriteLine("elem: {0}", elem);
            }

            queue.FlushDb();

            Console.ReadKey();

        }
    }
}
