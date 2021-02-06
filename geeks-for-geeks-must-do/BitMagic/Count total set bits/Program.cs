using System;

namespace Count_total_set_bits
{
    class Program
    {
        static void Main(string[] args)
        {
            var sol = new Solution();
            Console.WriteLine(sol.CountSetBits(4));
        }
    }

    class Solution
    {
        public int CountSetBits(int n)
        {
            int setBits = 0;

            while (n != 1)
            {
                setBits += n % 2;
                n /= 2;
            }
            return setBits + 1;
        }
    }
}
