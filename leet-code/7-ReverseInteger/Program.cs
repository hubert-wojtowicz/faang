var sol = new Solution();
Console.WriteLine(sol.Reverse(Int32.MaxValue));
Console.WriteLine(sol.Reverse(Int32.MaxValue-1));
Console.WriteLine(sol.Reverse(-Int32.MaxValue));
Console.WriteLine(sol.Reverse(-Int32.MaxValue+2));
Console.WriteLine(sol.Reverse(123456));


public class Solution
{
    //-2^31 <= x <= 2^31 - 1
    // 2^31 = 2,147,483,648
    public int Reverse(int x)
    {
        bool isNegative = x < 0;
        var abs = isNegative ? -x : x;
        var rev = string.Concat(abs.ToString().Reverse());

        if (int.TryParse(isNegative ? $"-{rev}" : rev, out var val))
        {
            return val;
        }
        else
        {
            return 0;
        }
    }
}