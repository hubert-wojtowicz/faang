using System;
using System.Collections.Generic;
using System.Linq;

namespace _3_odd_occurrences_in_array
{
    class Program
    {
        static void Main(string[] args)
        {
            var sol = new Solution();
            Console.WriteLine(sol.solution(new int[] { 9, 3, 9, 3, 9, 7, 9 }));
        }
    }

    class Solution
    {
        public int solution(int[] A)
        {
            var occurances = new Dictionary<int, short>();
            foreach (var item in A)
            {
                if (occurances.ContainsKey(item))
                {
                    ++occurances[item];
                }
                else
                {
                    occurances.Add(item, 1);
                }
            }

            return occurances.First(x => x.Value % 2 == 1).Key;
        }

        public int solution2(int[] A)
        {
            Array.Sort(A);
            for (int i = 0; i < A.Length; ++i)
            {
                if (i == 0)
                {
                    if (A.Length > 1)
                    {
                        if (A[1] != A[0])
                            return A[0];
                    }
                    else
                    {
                        return A[0];
                    }
                }
                else if (i == A.Length - 1)
                {
                    if (A[i] != A[i - 1])
                        return A[i];
                }
                else
                {
                    var prev = A[i - 1];
                    var next = A[i + 1];
                    if (A[i] != prev && A[i] != next)
                        return A[i];
                }
            }

            return -1;
        }

        public int solution1(int[] A)
        {
            var maxEl = Max(A);
            var occurances = new short[maxEl];
            for (int i = 0; i < A.Length; ++i)
            {
                ++occurances[A[i] - 1];
            }

            for (int i = 0; i < maxEl; ++i)
            {
                if (occurances[i] == 1)
                    return i + 1;
            }
            return -1;
        }

        int Max(int[] A)
        {
            var max = int.MinValue;
            for (int i = 0; i < A.Length; ++i)
            {
                max = Math.Max(A[i], max);
            }
            return max;
        }
    }
}
