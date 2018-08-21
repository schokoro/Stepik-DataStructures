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
    public class Heap
    {
        private long[][] heap;
        int size;
        public int Size
        {
            get
            {
                return size;
            }
        }
        public Heap(long size)
        {
            this.size = 0;
            heap = new long[size][];
        }
        private int Parent(int point)
        {
            return (int)(0.5 * (point - 1));
        }
        private int LeftChild(int point)
        {
            return 2 * point + 1;
        }
        private int RightChild(int point)
        {
            return 2 * (point + 1);
        }

        public void SiftUp(int i)
        {
            if (i > 0 && heap[i][0] < heap[Parent(i)][0])
            {
                Swap(i, Parent(i));
                SiftUp(Parent(i));
            }
        }
        public void SiftDown(int i)
        {
            int iMin = i;
            if (LeftChild(i) < this.size)
            {
                if (heap[i][0] < heap[LeftChild(i)][0]) iMin = i;
                else iMin = LeftChild(i);
            }
            if (RightChild(i) < this.size)
            {
                if (heap[RightChild(i)][0] < heap[iMin][0]) iMin = RightChild(i);
            }
            if (i != iMin)
            {
                Swap(i, iMin);
                SiftDown(iMin);
            }
        }
        public void Insert(long[] value)
        {
            if (this.size == heap.Length)
                throw new InvalidOperationException("Heap overflow");
            heap[this.size] = value;
            SiftUp(this.size);
            this.size++;
        }

        public long[] ExtractTop()
        {
            var result = heap[0];
            size--;
            heap[0] = heap[size];
            SiftDown(0);
            return result;
        }

        public long[] Peek()
        {
            return heap[0];
        }
        public bool Full
        {
            get
            {
                if (heap.Length == this.size) return true;
                else return false;
            }
        }
        private void Swap(int index1, int index2)
        {
            long[] tmp = heap[index1];
            heap[index1] = heap[index2];
            heap[index2] = tmp;
        }
    }
}