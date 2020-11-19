using System;

namespace L4T4_PermCheck
{
    class Program
    {
        static void Main(string[] args)
        {
            var sol = new Solution();
            var cases = new TestCase[]
            {
                new TestCase { A=new int[] { 4,1,3,2 } }, // Ans 1
                new TestCase { A=new int[] { 1 } }, // Ans 1
                new TestCase { A=new int[] { 1,2,3 } }, // Ans 1
                new TestCase { A=new int[] { 2,3,1 } }, // Ans 1
                new TestCase { A=new int[] { 2,3,4 } }, // Ans 0
                new TestCase { A=new int[] { 2 } }, // Ans 0
            };

            foreach (var @case in cases)
            {
                Console.WriteLine(sol.solution(@case.A));
            }
        }
    }

    class TestCase
    {
        public int[] A { get; set; }
    }

    /*
     * Simply i can introduce bool[N] for marking elements of permutation
     * if:
     * - any element of A array is bigger than N than we are sure this is not permutation (consecutive values missing)
     * - any element already marked id bool[N] array then duplication and no permutation
     * 
     * perform finall chceck bool[N]
     * 
     * This all can be acheived in O(n)
     */

    class Solution
    {
        public int solution(int[] A)
        {
            var permutationElementOccurance = new bool[A.Length];
            for (int i = 0; i < A.Length; i++)
            {
                if (A[i] > A.Length)
                    return 0;
                else if (permutationElementOccurance[A[i] - 1])
                    return 0;
                else
                    permutationElementOccurance[A[i] - 1] = true;
            }

            return 1;
        }
    }
}
