using System;

namespace _2_container_with_most_water
{
    class Program
    {
        static void Main(string[] args)
        {
			var sol = new Solution();

			Console.WriteLine(sol.MaxArea(new int[]{1,6,9,3,4,5,8}));
        }
	
    }

	public class Solution
	{
		public int MaxArea(int[] height)
		{
			int n = height.Length;
			int a = 0;
			int b = n > 0 ? n - 1 : 0;
			int maxArea = 0;

			while (a != b)
			{
				maxArea = Math.Max(maxArea, Math.Min(height[a], height[b]) * (b - a));

				if (height[a] > height[b])
				{
					--b;
				}
				else
				{
					++a;
				}
			}

			return maxArea;
		}
	}
}
