using System;
using System.Collections.Generic;

namespace ParallelProcessing
{
    public class HeapTask
    {
        public  Task[] heap;
        public HeapTask(Task[] heap, int sz)
        {           
            if (heap.Length == sz) this.Size = sz;
            else throw new InvalidOperationException("Size missmatch");
            BuildHeap(this.heap);
        }

        private void BuildHeap(Task[] heap)
        {
            for (int i = (int)(this.heap.Length*.5-1 ); i >= 0; i--)
            {
                SiftDown(i);
            }            
        }

        public int Parent(int point)
        {
            return (int)(0.5 * (point - 1));
        }
        public int LeftChild(int point)
        {
            return 2 * point + 1;
        }
        public int RightChild(int point)
        {
            return 2 * (point + 1);
        }
        int size;
        int maxSize;

        public int Size { get => size; set => size = value; }
        public int MaxSize { get => maxSize; set => maxSize = value; }

        public void SiftUp(int i)
        {
            if (i > 0 && heap[i] < heap[Parent(i)])
            {
                Swap(i, Parent(i));
                SiftUp(Parent(i));
            }

        }

        public void SiftDown(int i)
        {
            int iMin = i;
            if (LeftChild(i) < heap.Length)
            {
                if (heap[i] < heap[LeftChild(i)]) iMin = i;
                else iMin = LeftChild(i);
            }
            if (RightChild(i) < heap.Length && heap[RightChild(i)] < heap[iMin])
                iMin = RightChild(i);
            
            if (i != iMin)
            {
                Swap(i, iMin);
                SiftDown(iMin);
            }
        }

        private void Swap (int index1, int index2)
        {
            Task tmp = heap[index1];
            heap[index1] = heap[index2];
            heap[index2] = tmp;
        }
    }
}