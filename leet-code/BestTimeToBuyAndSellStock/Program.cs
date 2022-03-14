using System;
using System.Linq;

namespace BestTimeToBuyAndSellStock
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }

    public class Solution
    {
        public int MaxProfit(int[] prices)
        {
            int maxProfit = 0;
            int minVal = prices[0];

            for (int i = 1; i < prices.Length; i++)
            {
                minVal = Math.Min(minVal, prices[i]);
                maxProfit = Math.Max(maxProfit, prices[i] - minVal);
            }

            return maxProfit;
        }
    }
}
