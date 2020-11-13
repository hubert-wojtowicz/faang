using System;

namespace _2_rotating_arrary
{
    class Program
    {
        static void Main(string[] args)
        {
            var s = new Solution();
            var tab = new int[] { 1 };
            Console.WriteLine(string.Join(',', s.solution(tab, 3)));

            Console.ReadKey();
        }
    }

    class Solution
    {
        public int[] solution(int[] A, int K)
        {
            if (A == null || A.Length == 0)
                return A;
            // write your code in C# 6.0 with .NET 4.5 (Mono)
            var newArr = new int[A.Length];
            var startWith = A.Length - K % A.Length;
            int index = 0;
            for (int i = startWith; i < A.Length; ++i)
            {
                newArr[index] = A[i];
                ++index;
            }
            for (int i = 0; i < startWith; ++i)
            {
                newArr[index] = A[i];
                ++index;
            }
            return newArr;
        }
    }
}
