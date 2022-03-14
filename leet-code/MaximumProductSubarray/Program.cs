using System;

namespace MaximumProductSubarray
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var sol = new Solution();

            Console.WriteLine(sol.MaxProduct(new []{-4, -3, -2}));
        }
    }
    public class Solution
    {
        public int MaxProduct(int[] nums)
        {
            int maxSoFar = nums[0];
            int minSoFar = nums[0];
            int res = nums[0];

            for (int i = 1; i < nums.Length; ++i)
            {
                var maxSoFarTemp = Math.Max(nums[i], Math.Max(maxSoFar * nums[i], minSoFar * nums[i]));
                minSoFar = Math.Min(nums[i], Math.Min(maxSoFar * nums[i], minSoFar * nums[i]));
                maxSoFar = maxSoFarTemp;
                res = Math.Max(res, maxSoFar);
            }
            return res;
        }
    }
}
