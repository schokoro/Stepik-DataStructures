/*
 using System;
using System.Collections;

namespace Tree
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = Int32.Parse(Console.ReadLine());
            int[] tree = GetArray(Console.ReadLine());
            var roots = GetRoot(tree, -1);
            int height = GetHeight(tree, roots);
            Console.WriteLine(height);
            Console.ReadLine();
        }

        private static int GetHeight(int[] tree, ArrayList roots)
        {
            var heights = new ArrayList();
            if (roots.Count == 0)
                return 0;
            foreach (var root in roots)
            {
                var deepRoots = GetRoot(tree, (int)root);
                heights.Add(GetHeight(tree, deepRoots));
            }
            heights.Sort();
            return  (int)heights[heights.Count - 1]+1;
        }

        private static ArrayList GetRoot(int[] tree, int rootValue)
        {
            var roots = new ArrayList();
            for (int i = 0; i < tree.Length; i++)
                if (tree[i] == rootValue)
                    roots.Add(i);
            return roots;

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

 */