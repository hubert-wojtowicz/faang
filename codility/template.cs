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
                new TestCase { A=new int[] { 1, 3, 1, 4, 2, 3, 5, 4 } }, // Ans = 1
                new TestCase { A=new int[] { 7 } }, // Ans = 7
                new TestCase { A=new int[] { 1 } }, // Ans = 1
            };

            foreach (var @case in cases)
            {
                Console.WriteLine(sol.solution(@case.X, @case.A));
            }
        }
    }

    class TestCase
    {
        public int[] A { get; set; }
    }

    /*
     * This is place for analisys
     */

    class Solution
    {
        public int solution(int[] A)
        {
            return A[0];
        }
    }
}
