using System;
using System.Collections.Generic;
using System.Linq;

namespace heap
{
    public static class Program
    {
        static void Main(string[] args)
        {
            int[] A = new int[] { 16, 4, 10, 14, 7, 9, 3, 2, 8, 1 };
            var h = new MaxHeap(A);
            h.Heapsort();

            Console.WriteLine(string.Join(", ", h.A));
        }
    }

    public class MaxHeap
    {
        public List<int> A { get; }
        private int _heapSize;

        public MaxHeap(IEnumerable<int> A)
        {
            this.A = A.ToList();
        }

        private int Parent(int i) => i / 2;

        private int Left(int i) => 2 * i + 1;

        private int Right(int i) => 2 * i + 2;

        private void Swap(int i, int j)
        {
            int temp = A[i];
            A[i] = A[j];
            A[j] = temp;
        }

        public void MaxHeapify(int i)
        {
            int l = Left(i), r = Right(i);
            int largest = i;
            if (l < _heapSize && A[l] > A[i])
            {
                largest = l;
            }

            if (r < _heapSize && A[r] > A[largest])
            {
                largest = r;
            }

            if (largest != i)
            {
                Swap(i, largest);
                MaxHeapify(largest);
            }
        }

        public void BuildMaxHeap()
        {
            _heapSize = A.Count;
            for (int i = A.Count / 2; i >= 0; i--)
            {
                MaxHeapify(i);
            }
        }

        public void Heapsort()
        {
            BuildMaxHeap();
            for (int i = A.Count - 1; i >= 1; i--)
            {
                Swap(0, i);
                _heapSize--;
                MaxHeapify(0);
            }
        }

        public int Maximum() => A[0];

        public void Insert(int key)
        {
            _heapSize++;
            A[_heapSize] = int.MinValue;
            IncreaseKey(_heapSize, key);
        }

        public void IncreaseKey(int i, int key)
        {
            if (key < A[i])
                throw new InvalidOperationException("Key is smaller than current valu");

            A[i] = key;
            while (i >= 0 && A[Parent(i)] < A[i])
            {
                Swap(Parent(i), i);
                i = Parent(i);
            }
        }

        public int ExtractMax()
        {
            if (_heapSize < 1)
                throw new InvalidOperationException("Heap is empty");

            int max = Maximum();
            A[0] = A[_heapSize--];
            MaxHeapify(0);
            return max;
        }
    }
}