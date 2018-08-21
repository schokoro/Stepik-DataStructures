using System;
namespace ParallelProcessing
{
    public class Heap
    {        
        private  long[][] heap;
        int size;
        public int Size
        {
            get
            {
                return size;
            }
        }
        public Heap(long size)
        {
            this.size = 0;
            heap = new long[size][]; 
        }
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
            if (i > 0 && heap[i][0] < heap[Parent(i)][0])
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
                if (heap[i][0] < heap[LeftChild(i)][0]) iMin = i;
                else iMin = LeftChild(i);
            }
            if (RightChild(i) < this.size )
            {
                if (heap[RightChild(i)][0] < heap[iMin][0]  ) iMin = RightChild(i);
            }
            if (i != iMin)
            {
                Swap(i, iMin);
                SiftDown(iMin);
            }
        }
        public void Insert(long[] value)
        {
            if (this.size == heap.Length)
                throw new InvalidOperationException("Heap overflow");
            heap[this.size] = value;
            SiftUp(this.size);
            this.size++;
        }

        public long[] ExtractTop()
        {
            var result = heap[0];
            size--;
            heap[0] = heap[size];
            SiftDown(0);
            return result;
        }

        public long[] Peek()
        {
            return heap[0];
        }        
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
            long[] tmp = heap[index1];
            heap[index1] = heap[index2];
            heap[index2] = tmp;            
        }
    }
}