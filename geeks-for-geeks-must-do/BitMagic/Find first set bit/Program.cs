using System;

namespace Find_first_set_bit
{
    class Program
    {
        static void Main(string[] args)
        {
            var sol = new Solution();
            Console.WriteLine(sol.PosRightMostBit(18));
            Console.WriteLine(sol.PosRightMostBit(64));
            Console.WriteLine(sol.PosRightMostBit(117));
            Console.WriteLine(sol.PosRightMostBit(4));
        }
    }

    class Solution
    {
        // O(lg n)
        public int PosRightMostBit(uint n)
        {
            int pos = 1;
            while (n % 2 == 0)
            {
                n /= 2;
                pos++;
            }

            return pos;
        }
    }
}
