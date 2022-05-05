var solver = new Solution();

var arr = new int[3][]
{
    new int[]{ 1, 2, 3 },
    new int[]{ 4, 5, 6 },
    new int[]{ 7, 8, 9 },
};
solver.Rotate(arr);
var t=arr[0][0];

public class Solution
{
    public void Rotate(int[][] matrix)
    {
        var n = matrix.Length;
        for (int i = 0; i < (n + 1) / 2; i++)
        {
            for (int j = 0; j < n / 2; j++)
            {
                int temp = matrix[n - 1 - j][i];
                matrix[n - 1 - j][i] = matrix[n - 1 - i][n - j - 1];
                matrix[n - 1 - i][n - j - 1] = matrix[j][n - 1 - i];
                matrix[j][n - 1 - i] = matrix[i][j];
                matrix[i][j] = temp;
            }
        }
    }
}