using System.Text;

var solution = new Solution();

Console.WriteLine(solution.Convert("PAYPALISHIRING", 3));
public class Solution
{
    public string Convert(string s, int R)
    {
        if (R == 1) return s;
        var sb = new StringBuilder();
        int cycle = 2 * (R - 1);
        int tempIdx1, tempIdx2, kmax, k;
        for (int r = 0; r < R; r++)
        {
            k = 0;
            kmax = s.Length / cycle;
            while (k <= kmax)
            {
                tempIdx1 = r + cycle * k;
                if ((r == 0 || r == R - 1) && tempIdx1 < s.Length)
                {
                    sb.Append(s[tempIdx1]);
                }
                else
                {
                    tempIdx2 = cycle * (k + 1) - r;

                    if (tempIdx1 < s.Length)
                        sb.Append(s[tempIdx1]);
                    if (tempIdx2 < s.Length)
                        sb.Append(s[tempIdx2]);
                }

                k++;
            }
        }

        return sb.ToString();
    }
}