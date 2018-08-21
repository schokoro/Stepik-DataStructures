using System;
using MyStack;
namespace StackMax
{
    class Program
    {
        static void Main(string[] args)
        {
            var stack = new Stack<int>();
            for (int i = 0; i<6; i++)
            {
                Console.Write("Push to stack ({0}) : ", i);
                stack.Push(Convert.ToInt32(Console.ReadLine()));
                Console.WriteLine();
                Console.WriteLine("Max is {0}", stack.Max);


            }
        }

        
    }
}
