using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                                Console.Write("{0} ", word);
                        break;
                }
            }            
            Console.ReadKey();
        }
    }
}

