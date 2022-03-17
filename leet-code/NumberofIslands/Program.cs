// See https://aka.ms/new-console-template for more information
var solver = new Solution();

var in1 = new List<char[]>() {
  new[] { '1', '1', '1', '1', '0' },
  new[] { '1', '1', '0', '1', '0' },
  new[] { '1', '1', '0', '0', '0' },
  new[] { '0', '0', '0', '0', '0' }
}.ToArray();
Console.WriteLine(solver.NumIslands(in1));

var in2 = new List<char[]>()
{
    new[] { '1', '1', '0', '0', '0' },
    new[] { '1', '1', '0', '0', '0' },
    new[] { '0', '0', '1', '0', '0' },
    new[] { '0', '0', '0', '1', '1' }
}.ToArray();
Console.WriteLine(solver.NumIslands(in2));

var in3 = new List<char[]>()
{
    new[] { '1', '1', '1' },
    new[] { '0', '1', '0' },
    new[] {'1', '1', '1' }
}.ToArray();
Console.WriteLine(solver.NumIslands(in3));

public class Solution
{
    public int NumIslands(char[][] grid)
    {
        int ans = 0;
        for (int i = 0; i < grid.Length; i++)
        {
            for (int j = 0; j < grid[i].Length; j++)
            {
                if (grid[i][j] == 'v') continue;
                if (grid[i][j] == '0') continue;
                if (grid[i][j] == '1')
                {
                    ans++;
                    Visit(grid, i, j);
                }
            }
        }
        return ans;
    }

    private void Visit(char[][] grid, int i, int j)
    {
        if (0 <= i && 0 <= j && i < grid.Length && j < grid[i].Length)
        {
            if (grid[i][j] == 'v') return;
            if (grid[i][j] == '0') return;
            if (grid[i][j] == '1')
            {
                grid[i][j] = 'v';

                Visit(grid, i - 1, j);
                Visit(grid, i, j - 1);
                Visit(grid, i + 1, j);
                Visit(grid, i, j + 1);
            }
        }
    }
}