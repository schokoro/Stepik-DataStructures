using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashChain
{
    class HashChain
    {
        List<string>[] table;
        public HashChain(int size, int p, int x)
        {
            this.size = size;
            this.p = p;
            this.x = x;
            table = new List<string>[size];
        }

        int p;
        int x;
        private int size;

        private  int HashFunction(string value)
        {
            long xi = 1;
            long Sum = 0;
            var schars = value.ToCharArray();
            foreach (long c in schars)
            {
                Sum = (Sum +c * xi) % p;
                xi =  (xi*x)%p;
            }
            return (int)(Sum%size);
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
