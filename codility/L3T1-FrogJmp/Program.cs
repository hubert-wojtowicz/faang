using System;

namespace _4_FrogJmp
{
    class Program
    {
        static void Main(string[] args)
        {
            var sol = new Solution();
            Console.WriteLine(sol.solution(5, 105, 3));
        }
    }

    class Solution
    {
        public int solution(int X, int Y, int D)
        {
            var distance = Math.Abs(Y - X);
            return distance % D > 0 ? distance / D + 1 : distance / D;
        }
    }
}
