// See https://aka.ms/new-console-template for more information
var solver = new Solution();
var gg = solver.Generate(5);
var b = 22;


public class Solution
{
    public IList<IList<int>> Generate(int numRows)
    {
        var ll = new List<int[]>() { new int[] { 1 } };
        if (numRows == 1) return ll.ToArray();
        else ll.Add(new int[2] { 1, 1 });
        if (numRows == 2) return ll.ToArray();

        for (int i = 2; i < numRows; i++)
        {
            var par = ll[i - 1];
            var cl = par.Length + 1;

            ll.Add(new int[cl]);
            ll[i][0] = 1;
            ll[i][cl - 1] = 1;

            for (int k = 1; k < cl - 1; k++)
            {
                ll[i][k] = par[k - 1] + par[k];
            }
        }

        return ll.ToArray();
    }
}