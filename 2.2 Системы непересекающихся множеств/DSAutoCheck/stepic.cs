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
    public class DisjointSet
    {
        public int Count { get; private set; }
        private int[] Parent;
        private int[] Rank;
        public DisjointSet(int count)
        {
            this.Count = count;
            this.Parent = new int[this.Count];
            this.Rank = new int[this.Count];
            for (int i = 0; i < this.Count; i++)
            {
                this.Parent[i] = i;
                this.Rank[i] = 0;
            }
        }
        public int Find(int i)
        {
            if (Parent[i] == i) return i;
            else
            {
                int result = Find(Parent[i]);
                Parent[i] = result;
                return result;
            }
        }
        public void Union(int i, int j)
        {
            int irep = this.Find(i),
                jrep = this.Find(j),
                irank = Rank[irep],
                jrank = Rank[jrep];
            if (irep == jrep)
                return;
            if (irank < jrank) this.Parent[irep] = jrep;
            else if (jrank < irank) this.Parent[jrep] = irep;
            else
            {
                this.Parent[irep] = jrep;
                Rank[jrep]++;
            }
        }
    }
}
