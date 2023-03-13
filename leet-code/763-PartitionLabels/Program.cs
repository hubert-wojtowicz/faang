// See https://aka.ms/new-console-template for more information
var solver = new Solution();
Console.WriteLine(solver.PartitionLabels("ababcbacadefegdehijhklij"));

public class Solution
{
    public IList<int> PartitionLabels(string s)
    {
        var str = s.Select(x => (int)x - (int)'a').ToArray();
        int[] lastIndexes = new int[(int)'z' - (int)'a' + 1]; // hash table for all letters in strin

        for (int i = 0; i < s.Length; i++)
        {
            lastIndexes[str[i]] = i;
        }

        List<int> sol = new();
        int start = 0;
        int end = 0;
        for (int i = 0; i < s.Length; i++)
        {
            end = Math.Max(end, lastIndexes[str[i]]);
            if (i == end)
            {
                sol.Add(end - start + 1);
                start = i + 1;
            }
        }

        return sol;
    }
}