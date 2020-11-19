using System;

namespace LXTY_NameOfTask
{
    class Program
    {
        static void Main(string[] args)
        {
            var sol = new Solution();
            var cases = new TestCase[]
            {
                new TestCase { A = 1, Expected = 1},
            };

            Stopwatch sw = new Stopwatch();

            foreach (var @case in cases)
            {
                sw.Restart();
                var res = sol.solution(@case.A, @case.B, @case.K);
                sw.Stop();
                Console.WriteLine($"{res} - {(res == @case.Expected ? "CORRECT" : "FAILED")} in {sw.ElapsedMilliseconds}ms.");
            }
        }
    }

    class TestCase
    {
        public int A { get; set; }

        public int Expected { get; set; }
    }

    /*
     * 
     */

    class Solution
    {
        public int solution(int A)
        {
            return A;
        }
    }
}
