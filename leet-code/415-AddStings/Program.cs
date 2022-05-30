using System.Text;

var solver = new Solution();
Console.WriteLine(solver.AddStrings("999", "99"));

public class Solution
{
    public string AddStrings(string num1, string num2)
    {
        StringBuilder sb = new();
        var n1 = num1.Reverse().Select(x => short.Parse(x.ToString())).ToArray();
        var n2 = num2.Reverse().Select(x => short.Parse(x.ToString())).ToArray();
        int leftOver = 0;

        for (int i = 0; i < n1.Length || i < n2.Length; i++)
        {
            var a = (i<n1.Length) ? n1[i] : 0;
            var b = (i<n2.Length) ? n2[i] : 0;

            sb.Append((a + b + leftOver) % 10);
            leftOver = (a + b + leftOver) / 10;
        }

        if (leftOver > 0)
        {
            sb.Append(leftOver);
        }

        return new string(sb.ToString().Reverse().ToArray());
    }
}