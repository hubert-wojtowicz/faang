var solver = new Solution();
Console.WriteLine(solver.solution(new[] { -1, 2, 3 }));
Console.WriteLine(solver.solution(new[] { -1, -2 }));
Console.WriteLine(solver.solution(new[] { -1, -2,0,1,2,3,6,7 }));

class Solution
{
    public int solution(int[] A)
    {
        var positive = new HashSet<int>(A.Where(x => x > 0));
        int max = positive.Any() ? positive.Max() : 0;

        for (int i = 1; i <= max + 1; i++)
        {
            if (!positive.Contains(i))
                return i;
        }

        return 1;
    }
}