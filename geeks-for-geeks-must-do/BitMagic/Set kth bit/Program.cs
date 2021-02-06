using System;

namespace Set_kth_bit
{
    class Program
    {
        static void Main(string[] args)
        {
            var sol = new Solution();
            Console.WriteLine(sol.SetKthBit(10, 2));
            Console.WriteLine(sol.SetKthBit(15, 3));
        }
    }
    class Solution
    {
        // K counted from zero
        public int SetKthBit(int N, int K) => (int)Math.Pow(2, K) | N;
    }
}
