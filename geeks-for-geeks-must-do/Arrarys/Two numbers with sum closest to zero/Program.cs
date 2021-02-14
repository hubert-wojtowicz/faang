using System;

namespace Two_numbers_with_sum_closest_to_zero
{
    class Program
    {
        static void Main(string[] args)
        {
            var sol = new Solution();

            Console.WriteLine(sol.ClosestToZero(new int[] { -21, -67, -37, -18, 4, -65}));
            Console.WriteLine(sol.ClosestToZero(new int[] { -21, -67, -37, 0, -18, 4, -65, 22}));
            Console.WriteLine(sol.ClosestToZero(new int[] { -21, 21, 22}));
            Console.WriteLine(sol.ClosestToZero(new int[] { -5, -5, -8}));
            Console.WriteLine(sol.ClosestToZero(new int[] { -17, -1, -3, -20, 20, 1, 10, -13, -4, 15, 3, 14, -9, -19, 7, 16, 5, 4, -8, -16, 13, 8, 17, 2, 11, -7, 18, -15, -14, -6, -2, -5, 9, -10, -11, -18, 19, -12, 0, 6, 12 }));
            Console.WriteLine(sol.ClosestToZero(new int[] { 38, -46, -35, 44 }));
        }
    }

    class Solution
    {
        // 1) a is monotonic 
        // 2) loop invariant - in every iteration zeroClosestSum keeps lowest sum of 2 elements 
        // - one from left 0..p and 
        // - one from right q..n-1 indicies.
        // 
        public int ClosestToZero(int[] a)
        {
            Array.Sort(a);
            int p = 0, q = a.Length - 1;
            int zeroClosestSum = a[p] + a[q];
            while (p < q)
            {
                zeroClosestSum = Math.Abs(a[p] + a[q]) < Math.Abs(zeroClosestSum) ? a[p] + a[q] : zeroClosestSum;

                if (Math.Abs(a[p + 1] + a[q]) < Math.Abs(a[p] + a[q - 1]))
                {
                    p += 1;
                }
                else
                {
                    q -= 1;
                }
            }

            return zeroClosestSum;
        }
    }
}
