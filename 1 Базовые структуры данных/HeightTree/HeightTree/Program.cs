using System;
using System.Collections.Generic;

namespace HeightTree
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = Convert.ToInt32(Console.ReadLine());
            var nodeArray = GetArray(Console.ReadLine());
            var node = new Node[n];
            int root = -1;
            for (int i = 0; i < n; i++)
            {
                int cn = nodeArray[i];
                if (cn == -1)
                    root = i;
                else if (node[cn] == null)
                    node[cn] = new Node(i);
                else node[cn].children.Add(i);
            }

            int size = node[root].GetHeight(node);
            Console.WriteLine(size);
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
    class Node
    {
        public List<int> children;
        public Node(int child)
        {
            children = new List<int>() { child };
        }

        internal int GetHeight(Node[] node)
        {
            int s = 0;
            foreach (var nods in children)
                if (node[nods] != null)
                    s = Math.Max(s, node[nods].GetHeight(node));
                else s = Math.Max(s, 1); ;
            return s + 1;
        }
    }
}
