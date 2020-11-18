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
     * Path to walk 0,1,...,X,X+1,  
     * 1,...,X positions inside of river
     * A:a0,...,a(N-1) 
     * ai - falling leaves position in i time 
     * 
     * 1) this task is question if leaves exists at every position 1,2,...X, and what is the earliest time to get on the other side
     * 2) there can be no solution
     * 3) what we can do is to count leaves at every position from 1,...,X but once (bit array 0,1 where 0 no leaves, and 1 at least one leaves)
     * 4) accumulate continously sum of bits
     * 5) state frog can pass river as bit sum exqual toriver witdth
     * All of those can beacheived at O(N) time
     * N is max 100 000 so:
     * - int array size is 400 000byte = 390KB
     * - bool array size is 100 000 byte = 93KB
     */

    class Solution
    {
        public int solution(int[] A)
        {
            return A[0];
        }
    }
}
