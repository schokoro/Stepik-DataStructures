using System;
using System.Collections.Generic;

namespace StackBracket
{
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
            {
                throw new InvalidOperationException("The stack is empty");
            }

            T result = item.Last.Value;
                //
                //Tail.Value;

            item.RemoveLast();

            return result;
        }

        public T Peek()
        {
            if (item.Count == 0)
            {
                throw new InvalidOperationException("The stack is empty");
            }

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
}

