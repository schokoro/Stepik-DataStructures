using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MergeTables
{
    class Program
    {
        static void Main(string[] args)
        {
            var arg1 = GetArray(Console.ReadLine());
            var arg2 = GetArray(Console.ReadLine());
            if (arg2.Length!=arg1[0]) throw new InvalidOperationException("Size missmatch");
            var djset = new DisjointSet(arg2);
            for (int i = 0; i < arg1[1]; i++)
            {
                var merge = GetArray(Console.ReadLine());
                djset.Union(merge[0]-1, merge[1]-1);
                Console.WriteLine(djset.Max);
            }
            Console.ReadKey();
        }

        private static int[] GetArray(string v)
        {
            var numbers = v.Split(' ');
            var array = new int[numbers.Length];
            for (int i = 0; i < numbers.Length; i++)
                array[i] = int.Parse(numbers[i]);
            return array;
        }
    }
}
