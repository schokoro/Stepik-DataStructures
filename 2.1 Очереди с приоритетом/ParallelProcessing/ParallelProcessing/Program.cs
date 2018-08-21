using System;
namespace ParallelProcessing
{
    class Program
    {
        static void Main(string[] args)
        {
            long time = 0;
            var inp1 = GetArray(Console.ReadLine());
            var size = inp1[1];
            var numCores = inp1[0];
            var tasks = GetArray(Console.ReadLine());
            if (size != tasks.Length) throw new InvalidOperationException("Size missmatch");
            var cores = new Heap(numCores);
            var processes = new Heap(numCores);
            for (int j = 0; j < numCores; j++)
                cores.Insert(new long[] { j });
            int i = 0;
            long core;
            while (i < tasks.Length)
            {
                if (processes.Full)
                {
                    time = GetFromHeap(ref processes, ref cores);
                }
                while (!processes.Full && i < tasks.Length)
                {
                    if (tasks[i] > 0)
                    {
                        core = cores.ExtractTop()[0];
                        processes.Insert(new long[] { tasks[i] + time, core });
                    }
                    else core = cores.Peek()[0];
                    Console.WriteLine("{0} {1}", core, time);
                    i++;
                }
            }
            //Console.ReadKey();            
        }

        private static long GetFromHeap(ref Heap processes, ref Heap cores)
        {
            long finishedTask = processes.Peek()[0];
            while (processes.Peek()[0] == finishedTask && processes.Size > 0)
            {
                var fromHeap = processes.ExtractTop();
                long finishedCore = fromHeap[1];
                cores.Insert(new long[] { finishedCore });
            }
            return finishedTask;
        }

        private static long[] GetArray(string v)
        {
            var numbers = v.Split(' ');
            var array = new long[numbers.Length];
            for (int i = 0; i < numbers.Length; i++)
                array[i] = long.Parse(numbers[i]);
            return array;
        }
    }
}
