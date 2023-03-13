// See https://aka.ms/new-console-template for more information
var solver = new NumMatrix(new int[5][] {
    new[]{3, 0, 1, 4, 2 },
    new[]{5, 6, 3, 2, 1 },
    new[]{1, 2, 0, 1, 5 },
    new[]{4, 1, 0, 1, 7 },
    new[]{ 1, 0, 3, 0, 5 }
    });

Console.WriteLine(solver.SumRegion(2, 1, 4, 3));
Console.WriteLine(solver.SumRegion(1, 1, 2, 2));
Console.WriteLine(solver.SumRegion(1, 2, 2, 4));


var solver2 = new NumMatrix(new int[1][] {
    new[]{-4, -5 }
    });

Console.WriteLine(solver2.SumRegion(0, 0, 0, 0));
Console.WriteLine(solver2.SumRegion(0, 0, 0, 1));
Console.WriteLine(solver2.SumRegion(0, 1, 0, 1));


public class NumMatrix
{
    private int[][] _m;

    public NumMatrix(int[][] matrix)
    {
        int rn = matrix.Length;
        int cn = matrix[0].Length;

        _m = new int[rn][];

        for (int r = 0; r < rn; r++)
        {
            _m[r] = new int[cn];
            _m[r][0] = matrix[r][0] + (r - 1 >= 0 ? _m[r - 1][0] : 0);
        }
        for (int c = 0; c < cn; c++)
        {
            _m[0][c] = matrix[0][c] + (c - 1 >= 0 ? _m[0][c - 1] : 0);
        }

        for (int r = 1; r < rn; r++)
        {
            for (int c = 1; c < cn; c++)
            {
                _m[r][c] = matrix[r][c] + _m[r][c - 1] + _m[r - 1][c] - _m[r - 1][c - 1];
            }
        }

        gv = delegate (int row, int col) { return row < 0 || col < 0 ? 0 : _m[row][col]; }; // Delegate speed up execution time 1600mx-1300ms :)
    }

    public int SumRegion(int row1, int col1, int row2, int col2)
    {
        return gv(row2, col2) - gv(row1 - 1, col2) - gv(row2, col1 - 1) + gv(row1 - 1, col1 - 1);
    }

    private Func<int, int, int> gv;
}