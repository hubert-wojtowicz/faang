var sol = new Solution();
sol.MaximumUnits(new int[4][]
{
    new int[] { 5, 10 },
    new int[] { 2, 5 },
    new int[] { 4, 7 },
    new int[] { 3, 9 }
}, 10);
Console.WriteLine("Hello, World!");


public class Solution
{
    public int MaximumUnits(int[][] boxTypes, int truckSize)
    {
        boxTypes = boxTypes.OrderBy(x => -x[1]).ToArray();
        var i = 0;
        var taken = 0;

        while (truckSize > 0 && i < boxTypes.Length)
        {
            var take = Math.Min(truckSize, boxTypes[i][0]);
            truckSize -= take;
            taken += (take * boxTypes[i][1]);
            i++;
        }

        return taken;
    }
}