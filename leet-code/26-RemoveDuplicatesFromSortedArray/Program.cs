using System;

namespace _26_RemoveDuplicatesFromSortedArray
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var solver = new Solution();
            Console.WriteLine(solver.RemoveDuplicates(new int[] { 0 }));
            Console.WriteLine(solver.RemoveDuplicates(new int[] { 0, 0, 1, 1, 1, 2, 2, 3, 3, 4 }));
        }
    }

    public class Solution
    {
        public int RemoveDuplicates(int[] nums)
        {
            int n = nums.Length;
            int i = 0;
            for (; i < n; i++)
            {
                if (nums[i] == int.MinValue) break;
                int repeated = 1;
                while (i + repeated < n && nums[i] == nums[i + repeated]) { repeated++; }
                if (repeated > 1)
                {
                    Array.Copy(nums, i + repeated, nums, i + 1, n - (i + repeated));
                    Array.Fill(nums, int.MinValue, startIndex: n - (repeated - 1), repeated - 1);
                }
            }
            (int n, int m) a= (0,0);
            return i;
        }
    }
}
