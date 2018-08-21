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
    public class DisjointSet
    {
        public int Count { get; private set; }
        private int[] Parent;
        private int[] Rank;
        public int Max;
        public DisjointSet(int[] rank )
        {
            this.Rank = rank;
            this.Count = Rank.Length;
            this.Parent = new int[this.Count];
            this.Max = int.MinValue;
            for (int i = 0; i < this.Count; i++)
            {
                this.Parent[i] = i;
                this.Max = Math.Max(this.Max, Rank[i]);
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
        public void Union(int destination, int source)
        {
            int dRep = this.Find(destination),
                sRep = this.Find(source),
                dRank = Rank[dRep],
                sRank = Rank[sRep];
            if (dRep == sRep)
                return;           
            this.Parent[sRep] = dRep;
            Rank[dRep] = dRank + sRank;
            this.Max = Math.Max(this.Max, Rank[dRep]);
            Rank[sRep] = 0;
        }
    }
}
