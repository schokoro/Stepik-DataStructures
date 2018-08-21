using System;
using System.Collections.Generic;

namespace HashChain
{
    class Program
    {
        static void Main(string[] args)
        {
            int p = 1000000007;
            int x = 263;
            int tableSize =  Int32.Parse(Console.ReadLine());
            int numOfQuery =  Int32.Parse(Console.ReadLine());
            var hashchain = new HashChain(tableSize, p, x);
            for (int i = 0; i< numOfQuery; i++)
            {
                var query = Console.ReadLine().Split(' ');
                switch (query[0])
                {
                    case "add":
                        hashchain.Add(query[1]);
                        break;
                    case "del":
                        hashchain.Remove(query[1]);
                        break;
                    case "find":
                        string msg = hashchain.Find(query[1]) ? "yes": "no";
                        Console.WriteLine(msg);
                        break;
                    case "check":
                        var list = hashchain.Check(Int32.Parse(query[1]));
                        if (list == null || list.Count == 0) Console.WriteLine("");
                        else
                            foreach (var word in list)
                                Console.WriteLine("{0} ", word);
                        break;
                }
            }
        }
    }
    class HashChain
    {
        List<string>[] table;
        public HashChain(int size, int p, int x)
        {
            this.size = size;
            table = new List<string>[Size];
            this.p = p;
            this.x = x;
        }

        int p;
        int x;
        private int size;
        public int Size { get {return size;} }
        public int P { get { return p; } }
        public int X { get { return x; } }

        private  int HashFunction(string value)
        {
            long xi = 1;
            long S = 0;
            var schars = value.ToCharArray();
            foreach (long c in schars)
            {
                S += c * xi % P;
                xi =  (xi*X)%P;
            }
            return (int)(S%Size);
        }


        public void Add(string value)
        {
            var m = HashFunction(value);
            if (table[m] == null) table[m] = new List<string>() { value };
            else if (!table[m].Contains(value))
                table[m].Insert(0, value);            
        }

        public void Remove(string value)
        {
            var m = HashFunction(value);
            if (table[m] != null&&table[m].Contains(value))
                table[m].Remove(value);
        }

        public bool Find(string value)
        {
            var m = HashFunction(value);
            if (table[m] != null && table[m].Contains(value))
                return true;
            else
                return false;
        }

        public List<string> Check(int i)
        {
            if (table[i] != null) return table[i];
            else return new List<string>();
        }
    }
}

