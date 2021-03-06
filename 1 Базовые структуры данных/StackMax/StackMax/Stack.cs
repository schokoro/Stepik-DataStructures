﻿using System;
using System.Collections.Generic;

namespace MyStack
{
    public class Stack<T> where T : IComparable<T>
    {
        LinkedList<Contain<T>> item = new LinkedList<Contain<T>>();        
        
        public void Push(T value)
        {
            //Max = value;
            item.AddLast(new Contain<T>(value, Maximum(value)));
        }

        private T Maximum(T val)
        {
            if (!this.Empty&&val.CompareTo(item.Last.Value.Maximum) < 0)
                return item.Last.Value.Maximum;
            else 
                return val;
        }
       

        public T Pop()
        {
            if (this.Empty)
            {
                throw new InvalidOperationException("The stack is empty");
            }
            T result = item.Last.Value.Item;
            item.RemoveLast();
            return result;
        }

        public T Peek()
        {
            if (this.Empty)
            {
                throw new InvalidOperationException("The stack is empty");
            }
            return item.Last.Value.Item;
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

        private T max;// = UInt32.MinValue;
        public T Max 
        {
            get
            {
                if (item.Count != 0)
                    return item.Last.Value.Maximum;
                else
                    return default(T);
            }
            set
            {
                if (item.Count != 0 || max.CompareTo(value) == 0)
                    max = value;
            }
        }



        public struct Contain<T> where T : IComparable<T>
        {
            private T item;
            private T maximum;
            

            public T Item
            {
                get { return item; }
                set { item = value; }
            }

            public T Maximum
            {
                get { return maximum; }
                set { maximum = value; }
            }
            public Contain(T val1, T val2)
            {
                item = val1;
                maximum = val2;
            }

            
        }
    }
}

