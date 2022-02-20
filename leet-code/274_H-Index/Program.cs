using System;
using System.Collections.Generic;

namespace _274_H_Index
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var sol = new Solution();
            Console.WriteLine(sol.HIndex(new[] { 0 }));
            Console.WriteLine(sol.HIndex(new[] { 0, 1 }));
            Console.WriteLine(sol.HIndex(new[] { 1, 3, 1 }));
            Console.WriteLine(sol.HIndex(new[] { 3, 0, 6, 1, 5 }));
            Console.WriteLine(sol.HIndex(new[] { 1 }));
            Console.WriteLine(sol.HIndex(new[] { 2 }));
            Console.WriteLine(sol.HIndex(new[] { 2, 2 }));
            Console.WriteLine(sol.HIndex(new[] { 2, 3 }));
            Console.WriteLine(sol.HIndex(new[] { 1, 2, 3 }));
            Console.WriteLine(sol.HIndex(new[] { 1, 1, 1, 1 }));
        }
    }

    public class Solution
    {
        public int HIndexLinearSearch(int[] citations)
        {
            Array.Sort(citations, new DescComparer());
            int h = 0;
            for (int i = 0; i < citations.Length; i++)
            {
                if(citations[i]<i+1) break;
                h = i + 1;
            }

            return h;
        }

        // BinarySearch
        public int HIndex(int[] citations)
        {
            Array.Sort(citations, new DescComparer());
            int left = 0, right = citations.Length;
            while (true)
            {
                var center = (left + right) / 2;
                var h = center + 1;
                bool leftIn = center - 1 >= 0 && citations[center - 1] >= h - 1;
                bool midIn = citations[center] >= h;
                bool rightIn = center + 1 < citations.Length && citations[center + 1] >= h + 1;

                if (rightIn)
                {
                    left = center + 1;
                }
                else if (midIn)
                {
                    return h;
                }
                else if (leftIn)
                {
                    right = center;
                }
                else
                {
                    if (center != 0)
                        right = center;
                    else
                        return 0;
                }
            }
        }
    }

    public class DescComparer : IComparer<int>
    {
        public int Compare(int x, int y)
        {
            if (x > y)
                return -1;
            if (x < y)
                return 1;
            return 0;
        }
    }
}
