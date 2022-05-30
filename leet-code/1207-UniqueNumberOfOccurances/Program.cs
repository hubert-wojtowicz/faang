// See https://aka.ms/new-console-template for more information
var solver = new Solution();

Console.WriteLine(solver.UniqueOccurrences(new[] { 1, 2, 2, 1, 1, 3 }));

public class Solution
{
    public bool UniqueOccurrences(int[] arr)
    {
        var g = arr
            .GroupBy(x => x)
            .Select(x => x.Count())
            .OrderBy(x => x)
            .ToList();

        for (int i = 1; i < g.Count; i++)
        {
            if (g[i - 1] == g[i])
                return false;
        }
        return true;
    }
}