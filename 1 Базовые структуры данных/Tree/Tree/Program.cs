using System;
using System.Collections;
using System.Collections.Generic;

namespace Tree
{
    class Program
    {
        static void Main(string[] args)
        {
            //var n = Int32.Parse(Console.ReadLine());
            int[] tree = GetArray(Console.ReadLine());
            var root = GetRoot(tree);
            var children = new Dictionary<int, int>();
            for (int i = 0; i < tree.Length; i++)
            {
                children.Add(i+1,tree[i]);
            }
            int height = 1 + GetHeight(children, children[root]);
            Console.ReadLine();
        }

        private static int GetHeight(Dictionary<int, int> children, int v)
        {
            throw new NotImplementedException();
        }

        private static int[] GetArray(string v)
        {
            var numbers = v.Split(' ');
            var array = new int[numbers.Length];
            for (int i = 0; i < numbers.Length; i++)
                array[i] = Int32.Parse(numbers[i]);
            return array;
        }
        private static int GetRoot(int[] tree)
        {
            int root = 0;
            while (tree[root] != -1)
                root++;
            return root+1;

        }
    }
}
