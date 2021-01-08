using System;

namespace _202_Stock_Buy_Sell_to_Maximize_Profit
{
    class Program
    {
        /*
         Assume at least two elements.
         Two algorithms based on assumptions.
         https://www.geeksforgeeks.org/stock-buy-sell/
         */
        static void Main(string[] args)
        {
            Console.WriteLine(MaxProfit2(new[] { 100, 180, 260, 310, 40, 535, 695 }).ToString());
        }

        static int MaxProfit(int[] A)
        {
            /* 
                look for:
                max(sum 0<=k<l<n-1 A[l]-A[k])
                to answer question.
                Assume only one byu possible at the day. You can buy more on second day before sell.
                Assume at least two day on stock.
                Easiest solution seems to be n^2 where I check for evert k element if there exist greater price in the future of maximal value.
                Other solution is to calculate array of smallest values i can find in subsequent elements. With such helper arrary which I can calculate O(n) I can walk this arraty and calculate max sum in O(n)
            */
            int n = A.Length;

            // no one will buy last day
            // for i element in this arrary we understand mimimal value in A starting from i+1 pos
            int[] maxsr = new int[n - 1];
            int maxr = A[n - 1];
            for (int i = n - 2; i >= 0; i--)
            {
                maxr = Math.Max(A[i + 1], maxr);
                maxsr[i] = maxr;
            }

            int maxSum = 0;
            for (int i = 0; i < n - 1; i++)
            {
                if (maxsr[i] > A[i])
                    maxSum += (maxsr[i] - A[i]);
            }

            return maxSum;
        }

        // time complexity O(n), memory for calculation O(1)
        static int MaxProfit2(int[] A)
        {
            /* 
                I would use general strategy: buy when local price minimum, sell when local maximum
            */
            int sum = 0;
            int buyAt = -1;
            for (int i = 0; i < A.Length; i++)
            {
                switch (WhatAction(A, i))
                {
                    case 1:
                        buyAt = A[i];
                        break;
                    case 2:
                        sum += (A[i] - buyAt);
                        break;
                    default:
                        break;
                }
            }

            return sum;
        }

        // 1-buy
        // 2-sell
        // 3-nothing
        static byte WhatAction(int[] A, int at)
        {
            int n = A.Length;
            if (at > 0 && at < n - 1)
            {
                // middle case
                if (A[at - 1] < A[at] && A[at] > A[at + 1])
                    return 2;
                else if (A[at - 1] > A[at] && A[at] < A[at + 1])
                    return 1;
            }
            else if (at == 0) // start
            {
                if (A[at] < A[at + 1])
                    return 1;
            }
            else // end
            {
                if (A[at - 1] < A[at])
                    return 2;
            }
            return 3;
        }
    }
}
