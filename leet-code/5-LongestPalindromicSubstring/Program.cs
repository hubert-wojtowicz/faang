var sol = new Solution();

Console.WriteLine(sol.LongestPalindrome("fabad") == "aba");
Console.WriteLine(sol.LongestPalindrome("fabbad") == "abba");
Console.WriteLine(sol.LongestPalindrome("abad") == "aba");
Console.WriteLine(sol.LongestPalindrome("daba") == "aba");

public class Solution
{
    public string LongestPalindrome(string s)
    {
        if (string.IsNullOrWhiteSpace(s)) return "";

        var start = 0;
        var end = 0;

        for (var i = 0; i < s.Length; i++)
        {
            var l1 = GetMaxPalindromeLength(s, i, i);
            var l2 = GetMaxPalindromeLength(s, i, i + 1);
            var currentMaxLen = Math.Max(l1, l2);
            if (currentMaxLen <= end - start) continue;
            start = i - (currentMaxLen-1) / 2;
            end = i + currentMaxLen / 2;
        }

        return s.Substring(start, end - start + 1);
    }

    static int GetMaxPalindromeLength(string s, int l, int r)
    {
        if (string.IsNullOrWhiteSpace(s) || l > r)
            return 0;

        while (l >= 0 && r < s.Length && s[l] == s[r])
        {
            l--;
            r++;
        }

        return r - l - 1;
    }
}