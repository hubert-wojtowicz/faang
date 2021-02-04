using System;
using System.Collections.Generic;

namespace Zero_Sum_Subarrary
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(ZeroSumSubarraryContigousCount(new int[] { 6, -1, -3, 4, -2, 2, 4, 6, -12, -7 }) == 4);
            Console.WriteLine(ZeroSumSubarraryContigousCount(new int[] { 0 }) == 1);
            Console.WriteLine(ZeroSumSubarraryContigousCount(new int[] { 0, 0 }) == 3);
            Console.WriteLine(ZeroSumSubarraryContigousCount(new int[] { -1, 1, 0 }) == 3);
        }

        static int ZeroSumSubarraryContigousCount(int[] A)
        {
            int zeroSums = 0;
            int currentPrefix = 0;
            var sums = new Dictionary<int, int>()
            {
                { 0,1 }
                };

            for (int i = 0; i < A.Length; ++i)
            {
                currentPrefix += A[i];
                if (sums.TryGetValue(currentPrefix, out var count))
                {
                    zeroSums += count;
                    sums[currentPrefix]++;
                }
                else
                {
                    sums.Add(currentPrefix, 1);
                }
            }

            return zeroSums;
        }
    }
}
