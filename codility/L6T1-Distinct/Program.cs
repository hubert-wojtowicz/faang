using System;
using System.Diagnostics;
using System.Linq;

namespace L6T1_Distinct
{
    class Program
    {
        static void Main(string[] args)
        {
            var sol = new Solution();
            var cases = new TestCase[]
            {
                new TestCase { A = new[] { 2, 1, 1, 2, 3, 1 }, Expected = 3},
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
            return A.Distinct().Count();
        }
    }
}
