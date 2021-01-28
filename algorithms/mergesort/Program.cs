using System;

namespace mergesort
{
    class Program
    {
        static void Main(string[] args)
        {
            var solver = new Solution();
            int[] tbl = { -2, 3, 1, -4, 11, 7, 1 };
            solver.Sort(tbl);
            Console.WriteLine(string.Join(", ", tbl));

            int[] tbl2 = { -2};
            solver.Sort(tbl2);
            Console.WriteLine(string.Join(", ", tbl2));
        }
    }

    class Solution
    {
        public void Sort(int[] A)
        {
            if (A == null)
                return;

            MergeSort(A, 0, A.Length - 1);
        }

        private void MergeSort(int[] A, int p, int r)
        {
            if (p < r)
            {
                int q = (p + r) / 2;
                MergeSort(A, p, q);
                MergeSort(A, q + 1, r);
                Merge(A, p, q, r);
            }
        }

        private void Merge(int[] A, int p, int q, int r)
        {
            int n1 = q - p + 1, n2 = r - q, i = p, k = 0, j = 0;
            int[] L = new int[n1], P = new int[n2];

            Array.Copy(A, p, L, k, n1);
            Array.Copy(A, q + 1, P, j, n2);

            while (i <= r && k < n1 && j < n2)
                A[i++] = L[k] <= P[j] ? L[k++] : P[j++];

            while (i <= r && k < n1)
                A[i++] = L[k++];

            while (i <= r && j < n2)
                A[i++] = P[j++];
        }
    }
}
