using System;
using System.Collections.Generic;
using System.Linq;

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
        // O(nlgn)
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

        // O(nlgn), bit faster because of BinarySearch
        public int HIndexBinarySearch(int[] citations)
        {
            Array.Sort(citations, new DescComparer()); // nlgn
            // as citations.Length is limited we can use bucket or radix sort to makes it linear.
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

        // O(w*n) because of radix - w - key length (1000 - 3)
        public int HIndex(int[] citations)
        {
            radixsort(citations);
            Array.Reverse(citations);
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

        public static void radixsort(int[] Array)
        {
            int n = Array.Length;
            int max = Array[0];

            //find largest element in the Array
            for (int i = 1; i < n; i++)
            {
                if (max < Array[i])
                    max = Array[i];
            }

            //Counting sort is performed based on place. 
            //like ones place, tens place and so on.
            for (int place = 1; max / place > 0; place *= 10)
                countingsort(Array, place);
        }

        public static void countingsort(int[] Array, int place)
        {
            int n = Array.Length;
            int[] output = new int[n];

            //range of the number is 0-9 for each place considered.
            int[] freq = { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            //count number of occurrences in freq array
            for (int i = 0; i < n; i++)
                freq[(Array[i] / place) % 10]++;

            //Change count[i] so that count[i] now contains actual 
            //position of this digit in output[] 
            for (int i = 1; i < 10; i++)
                freq[i] += freq[i - 1];

            //Build the output array 
            for (int i = n - 1; i >= 0; i--)
            {
                output[freq[(Array[i] / place) % 10] - 1] = Array[i];
                freq[(Array[i] / place) % 10]--;
            }

            //Copy the output array to the input Array, Now the Array will 
            //contain sorted array based on digit at specified place
            for (int i = 0; i < n; i++)
                Array[i] = output[i];
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
