using System;

namespace _6_TapeEquilibrium
{
    class Program
    {
        static void Main(string[] args)
        {
            var sol = new Solution();
            Console.WriteLine(sol.solution(new int[] { 1, 6 }));
        }
    }
    /*
     * N is an integer within the range [2..100,000];
     * each element of array A is an integer within the range [−1,000..1,000]
     * 
     * Diff=|(A[0] + A[1] + ... + A[P − 1]) − (A[P] + A[P + 1] + ... + A[N − 1])|
     * for 0 < P < N
     * 
     * What i propose here is linear solution. Probably worst time complexity would work as well as N is 100 000.
     * I propose to use prefix sum to calculate difference.
     */

    class Solution
    {
        public int solution(int[] A)
        {
            var prefix = new int[A.Length];
            prefix[0] = A[0];

            for (int i = 1; i < A.Length; i++)
            {
                prefix[i] = prefix[i - 1] + A[i];
            }

            var minDiff = int.MaxValue;
            for (int p = 1; p < A.Length; ++p)
            {
                minDiff = Math.Min(Math.Abs(prefix[p - 1] - (prefix[A.Length-1] - prefix[p-1])), minDiff);
            }

            return minDiff;
        }
    }
}
