// See https://aka.ms/new-console-template for more information
using System.Numerics;
using System.Text.RegularExpressions;
//var solver = new Solution();
//Console.WriteLine(solver.MyAtoi("42"));
//Console.WriteLine(solver.MyAtoi("   -42"));
//Console.WriteLine(solver.MyAtoi("0042"));
//Console.WriteLine(solver.MyAtoi("-0042"));
//Console.WriteLine(solver.MyAtoi("+0042"));
//Console.WriteLine(solver.MyAtoi("-42"));
//Console.WriteLine(solver.MyAtoi("+42"));

//Console.WriteLine(solver.MyAtoi((((long)int.MaxValue)+1).ToString()));
//Console.WriteLine(int.MaxValue.ToString());

//Console.WriteLine(solver.MyAtoi((((long)int.MinValue) - 1).ToString()));
//Console.WriteLine(int.MinValue.ToString());

public class Solution
{
    public int MyAtoi(string s)
    {
        bool negative = false;

        s = s.TrimStart(' ');
        if (s[0] == '-')
        {
            negative = true;
            s = s.TrimStart('-');
        }
        s = s.TrimStart('+');
        s = s.TrimStart('0');
        s = negative ? "-" + s : s;

        int i = negative ? 1: 0;
        for (; i < s.Length; ++i)
        {
            if (!Char.IsDigit(s[i]))
                break;
        }
        s = i < 1 ? "0" : s.Substring(0, i);
        var bInt = BigInteger.Parse(s);
        if (bInt < int.MinValue) return int.MinValue;
        else if (bInt > int.MaxValue) return int.MaxValue;
        else return (int)bInt;
    }
}