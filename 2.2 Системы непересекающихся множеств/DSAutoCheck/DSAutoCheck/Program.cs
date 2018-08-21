using System;


namespace DSAutoCheck
{
    class Program
    {
        static void Main(string[] args)
        {
            var inp1 = GetArray(Console.ReadLine());
            var djset = new DisjointSet(inp1[0]);
            var e = inp1[1];
            var d = inp1[2];
            var result = 1;
            for (int i = 0; i < e; i++)
            {
                var union = GetArray(Console.ReadLine());
                djset.Union(union[0]-1, union[1]-1);
            }
            for (int i = 0; i < d; i++)
            {
                var find = GetArray(Console.ReadLine());
                if (djset.Find(find[0]-1)== djset.Find(find[1]-1))
                {
                    result = 0;
                    break;
                }
            }
            Console.WriteLine(result);
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
