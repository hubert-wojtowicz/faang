using System;
using System.Collections.Generic;
using System.Linq;

namespace L4T2_MaxCounters
{
    class Program
    {
        static void Main(string[] args)
        {
            var sol = new Solution();
            var cases = new TestCase[]
            {
                new TestCase { N=5, A=new int[] { 1,2,3,1,5,5,5,6,1,1,6,2,2 } },
                new TestCase { N=5, A=new int[] { 3, 4, 4, 6, 1, 4, 4 } },
                new TestCase { N=5, A=new int[] { 6 } },
                new TestCase { N=5, A=new int[] { 1 } },
                new TestCase { N=1, A=new int[] { 1 } },
            };

            foreach (var @case in cases)
            {
                Console.WriteLine($"[{string.Join(", ", sol.solution(@case.N, @case.A).Select(x => x.ToString()))}]");
            }
        }
    }

    class TestCase
    {
        public int N { get; set; }
        public int[] A { get; set; }
    }

    /*
     * N - number of counters - all initially set to 0
     * M - non zero number of element in 
     * array A: a0, a1,..., a(M-1)
     * which representing operations:
     * if A[K] = X, such that 1 ≤ X ≤ N, then operation K is increase(X),
     * if A[K] = N + 1 then operation K is max counter.
     * 
     * increase(X) − counter X is increased by 1,
     * max counter − all counters are set to the maximum value of any counter.
     * 
     * A[counter] = operation:
     * if(1<=operation<=N) increase counter by 1
     * else max
     *
     * A[0] = 3
     * A[1] = 4
     * A[2] = 4
     * A[3] = 6
     * A[4] = 1
     * A[5] = 4
     * A[6] = 4
     * 
     * N,M withib [1..100,000]
     * 
     *  N=5
     *  1  2  3  4  5   MaxCounterIndex = -1
     * (0, 0, 1, 0, 0)  MaxCounterIndex = 3
     * (0, 0, 1, 1, 0)  MaxCounterIndex = 3
     * (0, 0, 1, 2, 0)  MaxCounterIndex = 4
     * (2, 2, 2, 2, 2)  MaxCounterIndex = 4
     * (3, 2, 2, 2, 2)  MaxCounterIndex = 1
     * (3, 2, 2, 3, 2)  MaxCounterIndex = 1
     * (3, 2, 2, 4, 2)  MaxCounterIndex = 4
     * 
     *  Observations:
     *  1) last max counter operations makes differences between counters
     *  2) each following values of max counter operations can be calculated based on repetitions 
     */

    class Solution
    {
        // O(N+M) finally :)
        public int[] solution(int N, int[] A)
        {
            int[] counters = new int[N];
            int maxCounter = 0;
            int lastEqualizationValue = 0;

            for (int i = 0; i < A.Length; i++)
            {
                if (A[i] > N) // maxCounter
                {
                    lastEqualizationValue = maxCounter;
                }
                else // increase
                {
                    counters[A[i] - 1] = counters[A[i] - 1] < lastEqualizationValue ? lastEqualizationValue + 1 : counters[A[i] - 1] + 1;
                    maxCounter = Math.Max(maxCounter, counters[A[i] - 1]);
                }
            }

            // normalize
            for (int i = 0; i < N; i++)
            {
                if (counters[i] < lastEqualizationValue)
                {
                    counters[i] = lastEqualizationValue;
                }
            }

            return counters;
        }

        // 100% O(N*M) solution but with trick checking weather last op was max counter
        public int[] solution3(int N, int[] A)
        {
            int[] counters = new int[N];
            int maxCounter = 0;
            int lastAligmentValue = 0;

            for (int i = 0; i < A.Length; i++)
            {
                if (A[i] > N) // maxCounter
                {
                    lastAligmentValue = maxCounter + lastAligmentValue;
                    maxCounter = 0;
                    if (i - 1 >= 0 && A[i - 1] > N) // prev operation is max counter
                    {
                    }
                    else
                    {
                        Array.Clear(counters, 0, N);
                    }
                }
                else // increase
                {
                    maxCounter = Math.Max(maxCounter, ++counters[A[i] - 1]);
                }
            }

            for (int i = 0; i < N; i++)
            {
                counters[i] += lastAligmentValue;
            }

            return counters;
        }

        // score 88% O(N*M) - fail only on extreme_large - all max_counter operations 
        // TIMEOUT ERROR - running time: 2.036 sec., time limit: 0.224 sec.
        public int[] solution2(int N, int[] A)
        {
            int[] counters = new int[N];
            int maxCounter = 0;
            int lastAligmentValue = 0;

            for (int i = 0; i < A.Length; i++)
            {
                if (A[i] > N) // maxCounter
                {
                    lastAligmentValue = maxCounter + lastAligmentValue;
                    maxCounter = 0;
                    Array.Clear(counters, 0, N);
                }
                else // increase
                {
                    maxCounter = Math.Max(maxCounter, ++counters[A[i] - 1]);
                }
            }

            for (int i = 0; i < N; i++)
            {
                counters[i] += lastAligmentValue;
            }

            return counters;
        }

        // Score 77% O(N*M) 
        public int[] solution1(int N, int[] A)
        {
            var counters = new Dictionary<int, int>(100000);
            int lastAligmentValue = 0;
            int maxCounter = 0;
            for (int i = 0; i < A.Length; i++)
            {
                if (A[i] > N)
                {
                    lastAligmentValue = maxCounter;
                    counters.Clear();
                }
                else // A[i] <= N
                {
                    int X;
                    if (counters.TryGetValue(A[i], out X))
                    {
                        counters[A[i]] = X + 1;
                        maxCounter = Math.Max(maxCounter, X + 1);
                    }
                    else
                    {
                        counters.Add(A[i], lastAligmentValue + 1);
                        maxCounter = Math.Max(maxCounter, lastAligmentValue + 1);
                    }
                }
            }

            var solution = new int[N];
            for (int i = 0; i < N; i++)
            {
                int val;
                if (counters.TryGetValue(i + 1, out val))
                {
                    solution[i] = val;
                }
                else
                {
                    solution[i] = lastAligmentValue;
                }
            }
            return solution;
        }
    }
}
