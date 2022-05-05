using System;
using System.Collections.Generic;

namespace _1260_Shift2DGrid
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var solver = new Solution();
            var arr = new int[3][]
            {
                new int[]{1, 2, 3},
                new int[]{4, 5, 6},
                new int[]{7, 8, 9} 
            };

            var res = solver.ShiftGrid(arr, 4);
        }
    }

    public class Solution
    {
        public IList<IList<int>> ShiftGrid(int[][] grid, int k)
        {
            int nLen = grid[0].Length;
            int mLen = grid.Length;
            for (int m = 0; m < mLen; ++m)
            {
                for (int n = 0; n < nLen; ++n)
                {
                    var target = GetNewCoordinate((n, m), k, (nLen, mLen));
                    var temp = grid[target.m][target.n];
                    grid[target.m][target.n] = grid[m][n];
                    grid[m][n] = temp;
                }
            }
            return grid;
        }

        (int m, int n) GetNewCoordinate((int m,int n) origin, int k, (int m, int n) len)
        {
            int linearTotalLen = len.n * len.m;
            int linearOrigin = origin.n + origin.m * len.n;
            int linearTarget = (linearOrigin + k) % linearTotalLen;

            return (linearTarget / len.m, linearTarget % (len.n-1));
        }
    }
}
