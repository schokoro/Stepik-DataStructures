using System;
namespace MergeTables
{

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
            //this.Parent[dRep] = sRep;
        }
    }
}
