using System;
using System.Collections;

namespace _3_Longest_Substring_Without_Repeating_Characters
{
    class Program
    {
        static void Main(string[] args)
        {
            var sol = new Solution();
            Console.WriteLine(sol.LengthOfLongestSubstring("") == 0);
            Console.WriteLine(sol.LengthOfLongestSubstring("a") == 1);
            Console.WriteLine(sol.LengthOfLongestSubstring("au") == 2);
            Console.WriteLine(sol.LengthOfLongestSubstring("aabb") == 2);
            Console.WriteLine(sol.LengthOfLongestSubstring("abcbdaac") == 4);
            Console.WriteLine(sol.LengthOfLongestSubstring("aaaaaaa") == 1);
        }
    }

    public class Solution
    {
        // time O(n) space O(n)
        // sliding window technique
        public int LengthOfLongestSubstring(string s)
        {
            if (s.Length < 2)
                return s.Length;

            int max = 0, l = 0, r = 0;
            var hs = new Hashtable();
            while (r < s.Length)
            {
                if (!hs.ContainsKey(s[r]))
                {
                    hs[s[r]] = r;
                    max = Math.Max(max, r - l + 1);
                }
                else
                {
                    var newl = (int)hs[s[r]] + 1;
                    for (int i = l; i < newl; i++)
                    { hs.Remove(s[i]); }
                    hs[s[r]] = r;
                    l = newl;
                }
                r++;
            }

            return max;
        }
    }
}
