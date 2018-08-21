using System;
using System.Collections.Generic;

namespace HeapBuild
{
    public class Heap
    {
        public  int countOfPermutation = 0;
        public  int[] heap;
        public List<string> permutations = new List<string>();
        public Heap (int[] inputData, int sz)
        {           
            if (inputData.Length == sz) this.Size = sz;
            else throw new InvalidOperationException("Size missmatch");
            heap = inputData;
            BuildHeap(this.heap);
        }

        private void BuildHeap(int[] heap)
        {
            for (int i = (int)(this.heap.Length*.5-1 ); i >= 0; i--)
            {
#if DEBUG
                Console.WriteLine("HeapBuild i={0}", i);
#endif
                SiftDown(i);
            }
            //throw new NotImplementedException();
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
            if (RightChild(i) < heap.Length )
            {
                if (heap[RightChild(i)] < heap[iMin]  ) iMin = RightChild(i);
                //else iMin = RightChild(i);
            }
            if (i != iMin)
            {
                Swap(i, iMin);
                SiftDown(iMin);
            }
        }

        private void Swap (int index1, int index2)
        {
            int tmp = heap[index1];
            heap[index1] = heap[index2];
            heap[index2] = tmp;
            permutations.Add(index1.ToString() + " " + index2.ToString());
            this.countOfPermutation++;
#if DEBUG
            Console.WriteLine(countOfPermutation);
            Console.WriteLine("{0}  {1}", index1, index2);
#endif
        }
    }
}