using System;
using System.Collections.Generic;
using System.Linq;

namespace Calculate_Minimum_Swaps
{
    class Program
    {
        static void Main(string[] args)
        {
            var sol = new Solution();
            Console.WriteLine(sol.MinSwaps(new int[] { 7, 3, 2, 1, 5 }.Distinct().ToArray()));
            Console.WriteLine(sol.MinSwaps(new int[] { 7, 3 }.Distinct().ToArray()));
            Console.WriteLine(sol.MinSwaps(new int[] { 7 }.Distinct().ToArray()));
        }
    }

    public class Solution
    {
        public int MinSwaps(int[] nums)
        {
            int swaps = 0;
            var desIndex = new Dictionary<int, int>();

            {
                var sorted = nums.OrderBy(x => x).ToArray();
                for (int i = 0; i < sorted.Length; i++)
                {
                    desIndex.Add(sorted[i], i);
                }
            }

            for (int i = 0; i < nums.Length; i++)
            {
                if (desIndex[nums[i]] != i)
                {
                    swaps++;
                    Swap(nums, desIndex[nums[i]], i);
                }
            }

            return swaps;
        }

        public static void Swap(int[] nums, int k, int j)
        {
            int temp = nums[k];
            nums[k] = nums[j];
            nums[j] = temp;
        }
    };
}
