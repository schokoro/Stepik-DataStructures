using System;

namespace BinaryTreeBypassing
{
    class Program
    {
        static void Main(string[] args)
        {            
            var numNodes = Convert.ToInt32(Console.ReadLine());
            var tree = new int[numNodes][];
            for (int i = 0; i < numNodes; i++)
            {
                var nodeArray = GetArray(Console.ReadLine());
                tree[i] = nodeArray;
            }
            var result = new int[numNodes];
            int k = 0;
            Inorder(tree, 0, ref result, ref k);
            foreach (var key in result)
                Console.Write("{0} ", key);
            Console.WriteLine();
            k = 0;
            Preorder(tree, 0, ref result, ref k);
            foreach (var key in result)
                Console.Write("{0} ", key);
            Console.WriteLine();
            k = 0;
            Postorder(tree, 0, ref result, ref k);
            foreach (var key in result)
                Console.Write("{0} ", key);
            Console.WriteLine();
            Console.ReadKey();
        }

        static void Preorder(int[][] tree, int index, ref int[] result, ref int k)
        {
            result[k] = tree[index][0];
            k++;
            if (tree[index][1] != -1)
                Preorder(tree, tree[index][1], ref result, ref k);
            if (tree[index][2] != -1)
                Preorder(tree, tree[index][2], ref result, ref k);
            return;
        }

        static void Postorder(int[][] tree, int index, ref int[] result, ref int k)
        {
            if (tree[index][1] != -1)
                Postorder(tree, tree[index][1], ref result, ref k);
            if (tree[index][2] != -1)
                Postorder(tree, tree[index][2], ref result, ref k);
            result[k] = tree[index][0];
            k++;
            return;
        }

        static void Inorder(int[][] tree, int index,  ref int[] result, ref int k)
        {
            if (tree[index][1] != -1)
                Inorder(tree, tree[index][1], ref result, ref k);
            result[k] = tree[index][0];
            k++;
            if (tree[index][2] != -1)
                Inorder(tree, tree[index][2], ref result, ref k);
            return;
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
