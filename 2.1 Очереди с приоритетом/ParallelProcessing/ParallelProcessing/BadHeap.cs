using System;
using System.Collections.Generic;

namespace ParallelProcessing
{
    public class Heap
    {        
        private  double[] heap;
        int size;
        public int Size
        {
            get
            {
                return size;
            }
        }
        public Heap(int size)
        {
            this.size = 0;
            heap = new double[size]; 

        }
        /*public Heap (double[] heap, int sz)
        {
            if (heap.Length == sz) this.size = sz;
            else throw new InvalidOperationException("Size missmatch");
            BuildHeap(this.heap);
        }

        private void BuildHeap(double[] heap)
        {
            for (int i = (int)(this.size*.5-1 ); i >= 0; i--)
                SiftDown(i);            
        }*/

        private int Parent(int point)
        {
            return (int)(0.5 * (point - 1));
        }
        private int LeftChild(int point)
        {
            return 2 * point + 1;
        }
        private int RightChild(int point)
        {
            return 2 * (point + 1);
        }       
        
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
            if (LeftChild(i) < this.size)
            {
                if (heap[i] < heap[LeftChild(i)]) iMin = i;
                else iMin = LeftChild(i);
            }
            if (RightChild(i) < this.size )
            {
                if (heap[RightChild(i)] < heap[iMin]  ) iMin = RightChild(i);
            }
            if (i != iMin)
            {
                Swap(i, iMin);
                SiftDown(iMin);
            }
        }
        public void Insert(double value)
        {
            if (this.size == heap.Length)
                throw new InvalidOperationException("Heap overflow");
            heap[this.size] = value;
            SiftUp(this.size);
            this.size++;
        }

        public double ExtractTop()
        {
            var result = heap[0];
            size--;
            heap[0] = heap[size];
            SiftDown(0);
            return result;
        }

        public double Peek()
        {
            return heap[0];
        }

        /*public void Remove(int i)
        {
            heap[i] = double.MinValue;
            SiftUp(i);
            ExtractTop();
        }*/

        public bool Full
        {
           get
            {
                if (heap.Length == this.size) return true;
                else return false;
            }
        }

        private void Swap (int index1, int index2)
        {
            double tmp = heap[index1];
            heap[index1] = heap[index2];
            heap[index2] = tmp;            
        }

    }
}