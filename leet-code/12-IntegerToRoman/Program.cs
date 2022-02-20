
using System.Text;
var sol = new Solution();

Console.WriteLine(sol.IntToRoman(999));
Console.WriteLine(sol.IntToRoman(499));
Console.WriteLine(sol.IntToRoman(1922));


public class Solution
{
    public string IntToRoman(int num)
    {
        var res = new StringBuilder();
        var romIdx = 0;
        var romSys = new KeyValuePair<int, string>[]
        {
            new(1000, "M" ),
            new(900, "CM" ),
            new(500, "D" ),
            new(400, "CD" ),
            new(100, "C" ),
            new(90, "XC" ),
            new(50, "L" ),
            new(40, "XL" ),
            new(10, "X" ),
            new(9, "IX" ),
            new(5, "V" ),
            new(4, "IV" ),
            new(1, "I" )
        };

        while (num > 0)
        {
            if (num >= romSys[romIdx].Key)
            {
                num -= romSys[romIdx].Key;
                res.Append(romSys[romIdx].Value);
            }
            else
            {
                romIdx++;
            }
        }

        return res.ToString();
    }
}