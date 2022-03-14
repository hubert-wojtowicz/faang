using System;
using System.Collections;
using System.Collections.Generic;

namespace CoinChange
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var sol = new Solution();

            Console.WriteLine(sol.CoinChange(new[] { 2, 3, 5 }, 11));
        }
    }

    public class Solution
    {
        public int CoinChange(int[] coins, int amount)
        {
            return Denominate(coins, amount, new int[amount]);
        }

        private int Denominate(int[] coins, int remain, int[] count)
        {
            if (remain < 0) return -1;
            if (remain == 0) return 0;
            if (count[remain - 1] != 0) return count[remain - 1];

            int min = int.MaxValue;
            foreach (var coin in coins)
            {
                var currentCount = Denominate(coins, remain - coin, count);
                if (currentCount >= 0 && currentCount < min)
                    min = currentCount + 1;
            }
            count[remain - 1] = (min == int.MaxValue) ? -1 : min;
            return count[remain - 1];
        }
    }
}
