//#define DEBUG

using System;
using System.Collections.Generic;

namespace HeapBuild
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            //var size = Int32.Parse(Console.ReadLine());
            var size = 6;
            //var heapData = GetArray(Console.ReadLine());
            var heapData = GetArray("7 6 5 4 3 2");
            var heap = new Heap(heapData, size );
            Console.WriteLine(heap.countOfPermutation);
            foreach (var x in heap.permutations)
                Console.WriteLine("{0} ", x);
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