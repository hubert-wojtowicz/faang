using System;

namespace L4T3_MissingInteger
{
    class Program
    {
        static void Main(string[] args)
        {
            var sol = new Solution();
            var cases = new TestCase[]
            {
                new TestCase { A=new int[] { 1, 3, 6, 4, 1, 2} }, // Ans = 5
                new TestCase { A=new int[] { 1, 2 ,3 } }, // Ans = 4
                new TestCase { A=new int[] { -1,-3 } }, // Ans = 1
            };

            foreach (var @case in cases)
            {
                Console.WriteLine(sol.solution(@case.A));
            }
        }
    }

    class TestCase
    {
        public int[] A { get; set; }
    }

    /*
     * N in [1..100 000]
     * each element [−1,000,000..1,000,000]
     * 
     * i should look for smallest positive integer grater than 0
     * that does not occur in A=a0,...a(n-1).
     * Assuming all values in arrary does not belong to [1..10 000] so the max answer is bounded by N 10 001.
     * Again I need to keep bool[N] and mark every value [1..10 000] as found (if exist) and then traverse this table looking for first false. 
     * First false index is answer for provided question or if all marked as true, ten N=10 001.
     * 
     * This algorithm time complexity will be O(N+N) where first N is regarding buildig counters and second regarging counters traversing.
     * To sum up complexity is O(N)
     */

    class Solution
    {
        public int solution(int[] A)
        {
            bool[] valueExists = new bool[100000];
            for (int i = 0; i < A.Length; i++)
            {
                if (A[i] > 0 && A[i] <= 100000)
                    valueExists[A[i] - 1] = true;
            }

            for (int i = 0; i < valueExists.Length; i++)
            {
                if (!valueExists[i])
                    return i + 1;
            }

            return 100001;
        }
    }
}
