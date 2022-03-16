// See https://aka.ms/new-console-template for more information
using System.Collections;

var sol = new Solution();
Console.WriteLine(sol.CanJump(new[] { 3, 2, 1, 0, 4 }));
Console.WriteLine(sol.CanJump(new[] { 2, 3, 1, 1, 4 }));


public class Solution
{
    public bool CanJump(int[] nums)
    {
        BitArray goodIdxs = new BitArray(nums.Length);
        goodIdxs[nums.Length - 1] = true;

        for (int i = nums.Length - 2; i >= 0; i--)
        {
            var jumpRangeWithinArray = nums.Length - (i + 1);
            var jump = Math.Min(nums[i], jumpRangeWithinArray);
            while (jump > 0)
            {
                if (goodIdxs[i + jump])
                {
                    goodIdxs[i] = true;
                    break;
                }
                jump--;
            }
        }

        return goodIdxs[0];
    }
}