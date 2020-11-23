using System;
using System.Diagnostics;

namespace L5T3_MinAvgTwoSlice
{
    class Program
    {
        static void Main(string[] args)
        {
            var sol = new Solution();
            var cases = new TestCase[]
            {
                new TestCase { A = new[]{ 4, 2, 2, 5, 1, 5, 8 }, Expected = 1},
                new TestCase { A = new[]{ 1, 4, 2 }, Expected = 0},
                new TestCase { A = new[]{ 1, 4, 3 }, Expected = 0},
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
     * A - zero based array of N (within the range [2..100,000]) integers [−10,000..10,000]
     * A pair of integers (P, Q), such that 0 ≤ P < Q < N, is called a slice of array A
     * 
     * The goal is to find the starting position of a slice (at least 2 elements) whose average is minimal.
     * 
     * Minimal slices can be only 2, 3 elements. 
     * 3 element slice can be smaller than 2 element slice when:
     * (a+b)/2 > (a+b+c)/3
     * 3(a+b) > 2(a+b+c)
     * a+b > 2c
     * c < (a+b)/2
     * 
     * for example
     * 1 4 2
     * (1+4)/2 = 2.5
     * (4+2)/2 = 3
     * (1+4+2)/3= 2.3(3)
     * 
     * 
     * If they are longer they can be composed out of 2-elements or 3-elements subslices.
     * 
     * Assume we have longer slice than 3 element that is minimal. Call it MS.
     * In this case we can devide this slice into 2 or 3 element slices.
     * Lets call them SSk where k is number of subslices.
     * 
     * MS consists of SS1,..,SSk 
     * 
     * i=1,...k
     * (1)If any of SS_i < MS, then SS is minimal avg slice not MS, so SS_i >= MS.
     * (2)Whem SS_i > MS then there exist other subslice that SS_i2 < MS what is contradict with (1)
     *      for example MS = (x+y+z+u)/4 = SS1/2+SS2/2
     *      SS1 = (x+y)/2, SS2=(z+u)/2
     *      when SS1>MS then SS1 > SS1/2+SS2/2 -> SS1 > SS2, so SS2 is minimal AS not 4 element array
     *      
     * The same reasoning can be carried out for longer slices.
     * Conclusion is we need to find only 2 and 3 element slices.
     * 
     * Calculating slice 2,3 elements takes O(1) time, so walking through A will take O(N) what is acceptable for N=100 000.
     */

    class Solution
    {
        public int solution(int[] A)
        {
            float minAv = int.MaxValue;
            int minAvIdx = 0;

            for (int i = 0; i < A.Length - 1; i++)
            {
                float av = (A[i] + A[i + 1]) / 2.0f;
                av = Math.Min(av, (i < A.Length - 2) ? (A[i] + A[i + 1] + A[i + 2]) / 3.0f : av);

                if (av < minAv)
                {
                    minAv = av;
                    minAvIdx = i;
                }
            }

            return minAvIdx;
        }
    }
}
