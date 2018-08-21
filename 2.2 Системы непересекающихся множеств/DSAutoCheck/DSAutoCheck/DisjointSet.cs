namespace DSAutoCheck
{

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
