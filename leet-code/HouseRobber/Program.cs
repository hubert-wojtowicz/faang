// See https://aka.ms/new-console-template for more information
var solver = new Solution();

Console.WriteLine(solver.Rob(new[] { 2, 7, 9, 3, 1 }) == 12);
Console.WriteLine(solver.Rob(new[] { 2, 1 }) == 2);
Console.WriteLine(solver.Rob(new[] { 1, 2 }) == 2);
Console.WriteLine(solver.Rob(new[] { 1, 2, 3, 1 }) == 4);
Console.WriteLine(solver.Rob(new[] { 2 }) == 2);

public class Solution
{
    public int Rob(int[] nums)
    {
        if (nums.Length < 2) return nums.First();
        var prev = nums[0];
        var next = nums[1];
        int maxSoFar = nums[0];

        for (int i = 2; i < nums.Length; i++)
        {
            maxSoFar = Math.Max(maxSoFar, prev);
            prev = next;
            next = nums[i] + maxSoFar;
        }

        return Math.Max(prev, next);
    }
}