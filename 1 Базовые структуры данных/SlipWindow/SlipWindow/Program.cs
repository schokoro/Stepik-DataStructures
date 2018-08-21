using System;
using System.Collections.Generic;

namespace SlipWindow
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = Int32.Parse(Console.ReadLine());
            int[] array = GetArray(Console.ReadLine());
            if (array.Length != n)
                throw new InvalidOperationException("Size missmatch");
            var m = Int32.Parse(Console.ReadLine());
            var maxims = new int[n - m + 1];
            var queue = new QueueMax<int>();
            for (int i = 0; i < m-1; i++)
                queue.Enqueue(array[i]);
            for (int i = m - 1; i < n; i++)
            {
                queue.Enqueue(array[i]);
                maxims[i-m+1] = queue.Max;
                queue.Dequeue();
            }
            foreach (var max in maxims)
                Console.Write( "{0} ", max);
            Console.ReadKey();
            

        }

        private static int[] GetArray(string v)
        {
            var numbers = v.Split(' ');
            var array = new int[numbers.Length];
            for (int i = 0; i < numbers.Length; i++)
                array[i] = Int32.Parse(numbers[i]);
            return array;
        }
    }
}
