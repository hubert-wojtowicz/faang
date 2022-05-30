var solver = new Solution();

Console.WriteLine(solver.Tictactoe(new int[6][]
{
    new int[] { 0, 0 },//A
    new int[] { 1, 1 },
    new int[] { 0, 1 },//A
    new int[] { 0, 2 },
    new int[] { 1, 0 },//A
    new int[] { 2, 0 },
}));

Console.WriteLine(solver.Tictactoe(new int[5][]
{
    new int[] { 0, 0 },
    new int[] { 2, 0 },
    new int[] { 1, 1 },
    new int[] { 2, 1 },
    new int[] { 2, 2 },
}));

Console.WriteLine(solver.Tictactoe(new int[9][]
{
    new int[] { 0, 0 },
    new int[] { 1, 1 },
    new int[] { 2, 0 },
    new int[] { 1, 0 },
    new int[] { 1, 2 },
    new int[] { 2, 1 },
    new int[] { 0, 1 },
    new int[] { 0, 2 },
    new int[] { 2, 2 }
}));

public class Solution
{
    public string Tictactoe(int[][] moves)
    {
        char[,] board = new char[3, 3];
        for (int i = 1; i <= moves.Length; i++)
        {
            if (i % 2 == 1)
                board[moves[i - 1][0], moves[i - 1][1]] = 'A';
            else
                board[moves[i - 1][0], moves[i - 1][1]] = 'B';

            if (i < 5) continue;

            var (win, who) = DoWin(board);
            if (win)
                return who;
        }

        return (moves.Length >= 9) ? "Draw" : "Pending";
    }

    (bool, string) DoWin(char[,] b)
    {
        // col 
        for (int i = 0; i < b.GetLength(0); i++)
        {
            if (b[i, 0] == b[i, 1] && b[i, 1] == b[i, 2] && b[i, 0] != '\0')
                return (true, b[i, 0].ToString());
        }

        //row
        for (int i = 0; i < b.GetLength(0); i++)
        {
            if (b[0, i] == b[1, i] && b[1, i] == b[2, i] && b[0, i] != '\0')
                return (true, b[0, i].ToString());
        }

        //diag 
        if (b[0, 0] == b[1, 1] && b[1, 1] == b[2, 2] && b[0, 0] != '\0') return (true, b[0, 0].ToString());
        if (b[2, 0] == b[1, 1] && b[1, 1] == b[0, 2] && b[2, 0] != '\0') return (true, b[2, 0].ToString());

        return (false, "");
    }
}