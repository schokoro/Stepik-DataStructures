using System;

namespace SlipWindow
{
    class QueueMax<T> where T : IComparable<T>
    {        
        StackMax<T> leftStack = new StackMax<T>();
        StackMax<T> rightStack = new StackMax<T>();
        public void Enqueue(T value)
        {
            leftStack.Push(value);
        }
        public T Dequeue()
        {
            if (!rightStack.Empty)
                return rightStack.Pop();
            else if (!leftStack.Empty)
            {
                this.MoveToRight();
                return rightStack.Pop();
            }
            else
                throw new InvalidOperationException("The stack is empty");
        }
        private void MoveToRight() 
        {
            while (!leftStack.Empty)
                rightStack.Push(leftStack.Pop());
        }
        public T Peek() 
        {
            if (!rightStack.Empty)
                return rightStack.Peek();
            else if (!leftStack.Empty)
            {
                this.MoveToRight();
                return rightStack.Peek();
            }
            else
                throw new InvalidOperationException("The stack is empty");
        }
        public int Count
        {
            get
            {
                return leftStack.Count + rightStack.Count;
            }
        }
        public bool Empty
        {
            get
            {
                return leftStack.Empty||rightStack.Empty;
            }
        }
        public T Max 
        {
            get
            {
                if (!rightStack.Empty&& !leftStack.Empty)
                    return GetMax(leftStack.Max, rightStack.Max);
                else if (!leftStack.Empty)
                    return leftStack.Max;
                else if (!rightStack.Empty)
                    return rightStack.Max;
                else
                    return default(T);
            }            
        }
        private T GetMax(T max1, T max2)
        {
            if (max1.CompareTo(max2) > 0)
                return max1;
            else return max2;

        }
    }
}
