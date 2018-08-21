using System;

namespace CommonCheck
{
    class Program
    {
        static int min = Int32.MinValue;
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
            if (Inorder(tree, 0))
                Console.WriteLine("CORRECT");
            else
                Console.WriteLine("INCORRECT");

            Console.ReadKey();
        }

        static bool Inorder(int[][] tree, int index)
        {
            bool result = true;
            if (tree[index][1] != -1)
                result = Inorder(tree, tree[index][1]);
            if (tree[index][1] != -1&& tree[index][0] <= tree[tree[index][1]][0])
                result = false;
            else if ( tree[index][2] != -1 && tree[index][0] > tree[tree[index][2]][0])
                result = false;
            else if ( min > tree[index][0])
                result = false;
            min = tree[index][0];
            if (result && tree[index][2] != -1)
                result = Inorder(tree, tree[index][2]);
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
 