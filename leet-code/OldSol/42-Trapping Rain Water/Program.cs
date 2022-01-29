using System;

namespace _3_trapping_rainwater
{
    class Program
    {
        static void Main(string[] args)
        {
            var sol = new Solution();
            Console.WriteLine(sol.Trap(new int[] { }) == 0);
            Console.WriteLine(sol.Trap(new int[] { 0 }) == 0);
            Console.WriteLine(sol.Trap(new int[] { 0, 0 }) == 0);
            Console.WriteLine(sol.Trap(new int[] { 0, 0, 0, 0 }) == 0);
            Console.WriteLine(sol.Trap(new int[] { 1 }) == 0);
            Console.WriteLine(sol.Trap(new int[] { 1, 1 }) == 0);
            Console.WriteLine(sol.Trap(new int[] { 1, 1, 1, 1 }) == 0);
            Console.WriteLine(sol.Trap(new int[] { 3, 2, 1 }) == 0);
            Console.WriteLine(sol.Trap(new int[] { 3, 4, 3 }) == 0);
            Console.WriteLine(sol.Trap(new int[] { 3, 4, 4 }) == 0);
            Console.WriteLine(sol.Trap(new int[] { 2, 1, 2 }) == 1);
            Console.WriteLine(sol.Trap(new int[] { 2, 1, 0, 2 }) == 3);
            Console.WriteLine(sol.Trap(new int[] { 4, 2, 0, 3, 0, 1, 0, 7 }) == 18);
            Console.WriteLine(sol.Trap(new int[] { 0, 1, 0, 2, 1, 0, 3, 1, 0, 1, 2 }) == 8);
        }
    }

    //Solution: https://leetcode.com/submissions/detail/440662623/
    // time complexity O(n) (beacuse every iteration move pointers), memory O(1) 
    public class Solution0
    {
        public int Trap(int[] height)
        {
            int n = height.Length;
            if (n < 3)
                return 0;

            int l = 0;
            int p = n - 1; // p = 3
            while (l < p && height[l] == 0) { ++l; } 
            while (l < p && height[p] == 0) { --p; }

            int trapped = 0;
            bool analizeLeft = height[l] < height[p];
            int lastBoundry = analizeLeft ? height[l] : height[p];
            if (analizeLeft)
            {
                ++l;
            }
            else
            {
                --p;
            }

            while (l < p) // every iteration move
            {
                if (analizeLeft)
                {
                    if (lastBoundry <= height[l]) // watter trapped finish
                    {
                        analizeLeft = height[l] < height[p];
                        lastBoundry = analizeLeft ? height[l] : height[p];
                        if (analizeLeft)
                        {
                            ++l;
                        }
                        else
                        {
                            --p;
                        }
                    }
                    else // continue trap watter
                    {
                        trapped += (lastBoundry - height[l]);
                        ++l;
                    }
                }
                else
                {
                    if (height[p] >= lastBoundry) // watter trapped finish
                    {
                        analizeLeft = height[l] < height[p]; 
                        lastBoundry = analizeLeft ? height[l] : height[p]; 
                        if (analizeLeft) 
                        {
                            ++l;
                        }
                        else
                        {
                            --p;
                        }
                    }
                    else // continue trap watter
                    {
                        trapped += (lastBoundry - height[p]);
                        --p;
                    }
                }
            }

            return trapped;
        }
    }
    //Solution: https://leetcode.com/submissions/detail/440675588/
    public class Solution
    {
        public int Trap(int[] height)
        {
            int n = height.Length;
            int l = 0, r = n - 1;
            int total = 0;
            int maxl = 0, maxr = 0;
            while (l < r)
            {
                if (height[l] < height[r])
                {
                    if (height[l] >= maxl)
                    {
                        maxl = height[l];
                    }
                    else
                    {
                        total += maxl - height[l];
                    }
                    l++;
                }
                else
                {
                    if (height[r] >= maxr)
                    {
                        maxr = height[r]; 
                    }
                    else
                    {
                        total += maxr - height[r];
                    }
                    r--;
                }
            }
            return total;
        }
    }
}
