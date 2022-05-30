var solver = new Solution();
Console.WriteLine(solver.FindMaxForm(new[] { "10", "0001", "111001", "1", "0" }, 5, 3));
public class Solution
{
    private List<(int m, int n)> _set;
    public int FindMaxForm(string[] strs, int m, int n)
    {
        _set = strs.Select(x =>
        {
            int zeroCount = 0;
            int oneCount = 0;
            foreach (var c in x.AsSpan())
            {
                if (c == '0')
                    zeroCount++;
                if (c == '1')
                    oneCount++;
            }
            return (zeroCount, oneCount);
        }).ToList();

        return Helper(m, n, _set.Count() - 1);
    }

    int Helper(int m, int n, int i)
    {
        if (i < 0) return 0;

        var mLeft = m - _set[i].m;
        var nLeft = n - _set[i].n;

        var taken = -1;
        if (nLeft >= 0 && mLeft >= 0)
        {
            taken = 1 + Helper(mLeft, nLeft, i - 1);
        }

        var notTaken = Helper(m, n, i - 1);

        return Math.Max(taken, notTaken);
    }
}