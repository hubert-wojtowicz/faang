var solver = new Solution();

Console.WriteLine("solver.MyPow(2, 0)=" + solver.MyPow(2, 0));
Console.WriteLine("solver.MyPow(2, 1)=" + solver.MyPow(2, 1));
Console.WriteLine("solver.MyPow(2, 10)=" + solver.MyPow(2, 10));
Console.WriteLine("solver.MyPow(2, 11)=" + solver.MyPow(2, 11));


class Solution
{
    private double x;

    public double MyPow(double x, int n)
    {
        if (x == 0) return 0;
        if (n < 0)
        {
            this.x = 1 / x;
            n = -n;
        }
        else
        {
            this.x = x;
        }

        return myPowHelper(x, n);
    }

    double myPowHelper(double acc, int n)
    {
        if (n == 0) return 1;
        else if (n == 1) return acc;
        else
        {
            return myPowHelper((n % 2 == 0) ? acc * acc : acc * acc * x, n / 2);
        }
    }
};