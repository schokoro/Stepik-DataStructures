using System;

namespace RabinKarp
{
    class Program
    {
        static void Main(string[] args)
        {
            var pattern = Console.ReadLine();
            var text = Console.ReadLine();
            if (pattern.Length > text.Length || text.Length == 0)
            {
                Console.WriteLine("");
                return;
            }
            var sames = KarpRabin.FindSample(text, pattern);
            if (sames.Length != 0)
                foreach (var value in sames)
                    Console.Write("{0} ", value);
            //else Console.WriteLine("Empty");
            Console.ReadKey();
        }        
    }
}
