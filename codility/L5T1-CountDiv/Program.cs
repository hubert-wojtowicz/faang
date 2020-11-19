using System;
using System.Diagnostics;

namespace L5T1_CountDiv
{
    class Program
    {
        static void Main(string[] args)
        {
            var sol = new Solution();
            var cases = new TestCase[]
            {
                new TestCase { A = 5, B = 10, K = 11, Expected = 0},
                new TestCase { A = 0, B = 0, K = 11, Expected = 1},
                new TestCase { A = 0, B = 1, K = 11, Expected = 1},
                new TestCase { A = 0, B = 11, K = 11, Expected = 2},

                new TestCase { A = 0, B = 0, K = 1, Expected = 1},
                new TestCase { A = 1, B = 1, K = 1, Expected = 1},

                new TestCase { A = 6, B = 11, K = 2, Expected = 3},
                new TestCase { A = 6, B = 11, K = 3, Expected = 2},
                new TestCase { A = 6, B = 11, K = 6, Expected = 1},

                new TestCase { A = 1, B = 100, K = 1, Expected = 100},
                new TestCase { A = 0, B = 2000000000, K = 2, Expected = 1000000001},
                new TestCase { A = 0, B = 2000000000, K = 1, Expected = 2000000001},
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
        public int B { get; set; }
        public int K { get; set; }

        public int Expected { get; set; }
    }

    /*
     * solution: COUNT-OF = |{ i : A ≤ i ≤ B, i mod K = 0 }|
     * - A and B are integers within the range [0..2,000,000,000]
     * - K is an integer within the range [1..2,000,000,000]
     * - A ≤ B
     *  
     *  We can state in constant time number of remaining divisable:
     *  b = ⌊B/K⌋*K - last divisable number
     *  a = ⌈A/K⌉*K - first divisable number
     *  
     *  a + K + ... + K = b
     *  a + K*s = b
     *  s = (b - a)/K
     *  
     *  the number of items is s+1
     */

    class Solution
    {
        public int solution(int A, int B, int K)
        {
            int a = (int)Math.Ceiling((decimal)A / K) * K; // a >= A and a mod K == 0
            int b = (int)Math.Floor((decimal)B / K) * K; // b <= B and b mod K == 0


            if (a > B || b < A)
                return 0;
            else if (a == b)
                return 1;
            else
                return (b - a) / K + 1;
        }
    }
}
