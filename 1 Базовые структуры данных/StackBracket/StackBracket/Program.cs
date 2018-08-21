#define DEBUG
using System;
using System.Collections.Generic;


namespace StackBracket
{
    class Program
    {

        static void Main()
        {
#if DEBUG
            while (true) {
#endif
                var input = Console.ReadLine();
                if (input.Length == 0)
                {
                    Console.WriteLine("Success");
                    return ;
                }

                var brackets = input.ToCharArray();
                var closedBrackets = new Dictionary<char, char>() {{')', '('}, {']', '['}, {'}', '{'}};
                var countOfSymbols = 0;
                var stack = new Stack<Brackets>();
                foreach (var symbol in brackets)
                {
                    countOfSymbols++;
                    if (closedBrackets.ContainsValue(symbol))
                    {
                        stack.Push(new Brackets(symbol,countOfSymbols));
                    }
                    else if (closedBrackets.ContainsKey(symbol))
                    {
                        if (stack.Empty||stack.Pop().Bracket != closedBrackets[symbol])
                        {
                            stack.Push(new Brackets(symbol, countOfSymbols));
                            break;
                        }
                        //stack.Pop();
                    }
                }
                if (stack.Empty)
                    Console.WriteLine("Success");
                else
                    Console.WriteLine(stack.Peek().Count.ToString());
#if DEBUG
            }
#endif

            return ;
        }
    }

    public class Stack<T>
    {
        LinkedList<T> item = new LinkedList<T>();
        public void Push(T value)
        {
            item.AddLast(value);
        }
        public T Pop()
        {
            if (item.Count == 0)
                throw new InvalidOperationException("The stack is empty");
            T result = item.Last.Value;
            item.RemoveLast();
            return result;
        }
        public T Peek()
        {
            if (item.Count == 0)
                throw new InvalidOperationException("The stack is empty");
            return item.Last.Value;
        }
        public int Count
        {
            get
            {
                return item.Count;
            }
        }
        public bool Empty
        {
            get
            {
                return item.Count == 0;
            }
        }
    }

    public struct Brackets
    {
        private char bracket;
        private int count;

        public char Bracket
        {
            get { return bracket; }
            set { bracket = value; }
        }

        public int Count
        {
            get { return count; }
            set { count = value; }
        }
        public Brackets (char val1, int val2)
        {
            bracket = val1;
            count = val2;
        }
    }
}

