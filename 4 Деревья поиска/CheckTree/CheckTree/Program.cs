using System;

namespace CheckTree
{
    class Program
    {
        static void Main(string[] args)
        {
            var numNodes = Convert.ToInt32(Console.ReadLine());
            if (numNodes == 0)
            {
                Console.WriteLine("CORRECT");
                Console.ReadKey();
                return;
            }
            var tree = new int[numNodes][];
            for (int i = 0; i < numNodes; i++)
            {
                var nodeArray = GetArray(Console.ReadLine());
                tree[i] = nodeArray;
            }

            int min = Int32.MinValue;
            int next = Int32.MinValue;
            if (Inorder(tree, 0, ref min, ref next))
                Console.WriteLine("CORRECT");
            else
                Console.WriteLine("INCORRECT");

            Console.ReadKey();
        }
        
        static bool Inorder(int[][] tree, int index, ref int min, ref int next)
        {
            bool result = true;
            if (tree[index][1] != -1)
                result = Inorder(tree, tree[index][1], ref min, ref next);
            next = tree[index][0];
            if (min > next)
                return false;
            min = next;
            if (result&&tree[index][2] != -1)
                result = Inorder(tree, tree[index][2], ref min, ref next);
            return result;
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
