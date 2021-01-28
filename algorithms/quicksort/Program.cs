using System;
using System.Collections;
using System.Diagnostics.CodeAnalysis;

namespace quicksort
{
    class Program
    {
        static void Main(string[] args)
        {
            var sol = new Solution();
            var inp = new int[] { 2, 4, -2, 5, 10, 1, 3 };
            sol.Sort(inp);
            foreach (var item in inp)
            {
                Console.WriteLine(item);
            }
        }
    }

    class Solution
    {
        public void Sort(int[] A)
        {
            QuickSort(A, 0, A.Length - 1);
        }

        private void QuickSort(int[] A, int p, int r)
        {
            if (p < r && A != null)
            {
                int q = RandomizedPartition(A, p, r);
                QuickSort(A, p, q - 1);
                QuickSort(A, q + 1, r);
            }
        }

        private int RandomizedPartition(int[] A, int p, int r)
        {
            int i = new Random().Next(p, r);
            Swap(A, i, r);
            return Partition(A, p, r);
        }

        private int Partition(int[] A, int p, int r)
        {
            int x = A[r];
            int i = p - 1;
            for (int j = p; j < r; j++)
            {
                if (A[j] <= x)
                {
                    i++;
                    Swap(A, j, i);
                }
            }
            Swap(A, r, i + 1);
            return i + 1;
        }

        private void Swap(int[] A, int k, int j)
        {
            int t = A[k];
            A[k] = A[j];
            A[j] = t;
        }
    }
}
