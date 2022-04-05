// See https://aka.ms/new-console-template for more information

var solver = new Solution();
Console.WriteLine(solver.DeleteAndEarn(new[] { 2, 2, 3, 3, 3, 4 }) == 9);
Console.WriteLine(solver.DeleteAndEarn(new[] { 3, 4, 2 }) == 6);

public class Solution
{
    private Dictionary<int, int> _vals;
    private Dictionary<int, int> _cache;
    public int DeleteAndEarn(int[] nums)
    {
        _vals = nums.GroupBy(x => x).ToDictionary(x => x.Key, x => x.Sum()); // O(nlgn) or (O(n)) this is defining overal complexity
        _cache = new Dictionary<int, int>()
        {
            {0, 0},
            {1, (_vals.ContainsKey(1) ? _vals[1] : 0)}
        };
        return MaxPoints(_vals.Max(x => x.Key));
    }

    public int MaxPoints(int x)
    {
        if (_cache.ContainsKey(x)) return _cache[x];
        _cache.Add(x, Math.Max(MaxPoints(x - 2) + (_vals.ContainsKey(x) ? _vals[x] : 0), MaxPoints(x - 1)));
        return _cache[x];
    }
}