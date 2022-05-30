using System.Collections;

var sol = new Solution();

Console.WriteLine(sol.CountSubstrings("abc"));

public class Solution
{
    public int CountSubstrings(string s)
    {
        List<BitArray> dp = new List<BitArray>(new BitArray[s.Length]);
        int ans = 0;

        for (int i = 0; i < s.Length; i++, ans++)
        {
            dp[i] = new BitArray(s.Length);
            dp[i][i] = true;
        }
        for (int i = 0; i < s.Length - 1; i++)
        {
            dp[i][i + 1] = s[i] == s[i + 1];
            ans += (dp[i][i + 1] ? 1 : 0);
        }

        for (int len = 3; len <= s.Length; ++len)
            for (int i = 0, j = i + len - 1; j < s.Length; ++i, ++j)
            {
                dp[i][j] = dp[i + 1][j - 1] && (s[i] == s[j]);
                ans += (dp[i][j] ? 1 : 0);
            }
        return ans;
    }
}