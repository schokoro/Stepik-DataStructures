using System;
using System.Collections.Generic;

namespace Phonebook
{
    class Program
    {
        static void Main(string[] args)
        {
            var phonebook = new Dictionary<string, string>();
            var n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                var input = Console.ReadLine().Split(' ');
                switch (input[0])
                {
                    case "add":
                        if (phonebook.ContainsKey(input[1]))
                            phonebook[input[1]] = input[2];
                        else
                            phonebook.Add(input[1], input[2]);
                        break;
                    case "del":
                        if (phonebook.ContainsKey(input[1]))
                            phonebook.Remove(input[1]);
                        break;
                    case "find":
                        if (phonebook.ContainsKey(input[1]))
                            Console.WriteLine(phonebook[input[1]]);
                        else
                            Console.WriteLine("not found");
                        break;
                }
            }
            Console.ReadKey();
        }
    }
}
