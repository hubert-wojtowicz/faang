using System;
using System.Diagnostics;

namespace L6T2_MaxProductOfThree
{
    class Program
    {
        static void Main(string[] args)
        {
            var sol = new Solution();
            var cases = new TestCase[]
            {
                new TestCase { A = new[] { -3,1,2,-2,5,6 }, Expected = 60},
            };

            Stopwatch sw = new Stopwatch();

            foreach (var @case in cases)
            {
                sw.Restart();
                var res = sol.solution(@case.A);
                sw.Stop();
                Console.WriteLine($"{res} - {(res == @case.Expected ? "CORRECT" : "FAILED")} in {sw.ElapsedMilliseconds}ms.");
            }
        }
    }

    class TestCase
    {
        public int[] A { get; set; }

        public int Expected { get; set; }
    }

    /*
     *  Given an array A consisting of N integers, returns the number of distinct values in array A.
     */

    class Solution
    {
        public int solution(int[] A)
        {
            Array.Sort(A);

            var op1 = A[A.Length - 1] * A[A.Length - 2] * A[A.Length - 3];
            var op2 = A[0] * A[1] * A[A.Length - 1];

            return Math.Max(op1, op2);
        }
    }
}
