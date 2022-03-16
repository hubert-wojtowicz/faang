// See https://aka.ms/new-console-template for more information
var sol = new Solution();
var res = sol.GenerateParenthesis(8);

foreach (var item in res)
{
    Console.WriteLine(item);
}
public class Solution
{
    public IList<string> GenerateParenthesis(int n)
    {
        var prevLevel = new Queue<string>(new[] { "()" });
        var currentLevel = new HashSet<string>(prevLevel);
        for (int i = 1; i < n; i++) // O(n)
        {
            currentLevel = new HashSet<string>();
            while (prevLevel.Count > 0) //
            { 
                var considered = prevLevel.Dequeue(); 
                for (int j = 0; j < considered.Length; j++)
                {
                    currentLevel.Add(considered.Insert(j, "()"));
                }
            }

            prevLevel = new Queue<string>(currentLevel.ToList());
        }

        return currentLevel.ToList();
    }
}