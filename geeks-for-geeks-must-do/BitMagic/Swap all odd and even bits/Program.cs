using System;

namespace Swap_all_odd_and_even_bits
{
    class Program
    {
        static void Main(string[] args)
        {
            var sol = new Solution();
            Console.WriteLine(sol.SwapEvenAnOddBits(23));
            Console.WriteLine(sol.SwapEvenAnOddBits(2));
        }
    }

    class Solution
    {
        public uint SwapEvenAnOddBits(uint n)
        {
            uint odd = 0xAAAAAAAA;
            uint even = odd >> 1;

            return ((n & odd) >> 1) + ((n & even) << 1);
        }
    }
}
