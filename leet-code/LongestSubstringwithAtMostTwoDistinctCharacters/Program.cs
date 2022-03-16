// See https://aka.ms/new-console-template for more information
var sol = new Solution();

Console.WriteLine(sol.LengthOfLongestSubstringTwoDistinct("ababcbcbaaabbdef") == 6);
Console.WriteLine(sol.LengthOfLongestSubstringTwoDistinct("abccbbcccaaacaca") == 10);
Console.WriteLine(sol.LengthOfLongestSubstringTwoDistinct("ccaabbb") == 5);
Console.WriteLine(sol.LengthOfLongestSubstringTwoDistinct("eceba") == 3);
Console.WriteLine(sol.LengthOfLongestSubstringTwoDistinct("aa") == 2);
Console.WriteLine(sol.LengthOfLongestSubstringTwoDistinct("a") == 1);
public class Solution
{
    public int LengthOfLongestSubstringTwoDistinct(string s)
    {
        Dictionary<char, int> lastChangeTwoChars = new Dictionary<char, int>();
        int l = 0, r = 0;
        lastChangeTwoChars.Add(s[l], l);
        while (r < s.Length && lastChangeTwoChars.ContainsKey(s[r])) r++;
        if (r >= s.Length) return s.Length;
        lastChangeTwoChars.Add(s[r], r);
        int maxSeen = r - l + 1;
        r += 1;
        while (l < r && r < s.Length)
        {
            if (lastChangeTwoChars.ContainsKey(s[r]))
            {
                if (s[r - 1] != s[r])
                    lastChangeTwoChars[s[r]] = r;
                maxSeen = Math.Max(maxSeen, r - l + 1);
            }
            else
            {
                var newl = lastChangeTwoChars[s[r - 1]];
                var toRemove = lastChangeTwoChars.First(x => x.Key != s[r - 1]);
                lastChangeTwoChars.Remove(toRemove.Key);
                l = newl;
                lastChangeTwoChars.Add(s[r], r);
            }
            r++;
        }

        return maxSeen;
    }
}