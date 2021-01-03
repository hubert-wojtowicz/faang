using System;
using System.Collections.Generic;
using System.Linq;
/*
 O(n2) complexity - consider each point and for every remaining calc slope.
 Keep slopes in dict. If next same slope found increase number of slope found.
 Answer is max number of the same slopes of max number of same slope for particular point.
 */
namespace _80_Count_maximum_points_on_same_line
{
    class Program
    {
        static void Main(string[] args)
        {
            var tcs = new List<(List<(int, int)>, int)>()
            {
                { (new List<(int, int)>{ (-1,1),(0,0),(1,1),(2,2),(3,3),(3,4) },4) },
                { (new List<(int, int)>{ (0,0),(0,0),(0,0),(0,0) },4) },
            };

            var sol = new Solution();
            int tcn = 1;
            foreach (var tc in tcs)
            {
                var ans=sol.solution(tc.Item1.ToArray());
                if (ans != tc.Item2)
                    Console.WriteLine($"Test case failed! Expected {tc.Item2}, got {ans}.");
            }
        }
    }

    class Solution
    {
        public int solution((int, int)[] A)
        {
            int max = 0;
            //for every point
            for (int i = 0; i < A.Length; i++)
            {
                int same = 0;
                var slopes = new Dictionary<double, int>();
                for (int j = 0; j < A.Length; j++)
                {
                    if (i == j)
                        continue;

                    int xd = A[i].Item1 - A[j].Item1;
                    int yd = A[i].Item2 - A[j].Item2;

                    if (xd == 0 && yd == 0)
                    {
                        same++;
                        continue;
                    }

                    double a = xd == 0 ? double.MaxValue : ((double)yd) / xd;

                    if (slopes.ContainsKey(a))
                        slopes[a]++;
                    else
                        slopes.Add(a, 1);
                }
                max = Math.Max(max, (slopes.Count > 0 ? slopes.Values.Max() : 0) + same);
            }
            return max + 1;
        }
    }
}
