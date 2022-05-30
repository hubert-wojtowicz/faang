using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace app1_mono
{
    internal class Program
    {
        static int Main(string[] args)
        {
            var solver3 = new Solution3();
            Console.WriteLine(solver3.solution("...xxx..x....xxx.", 7));
            Console.WriteLine(solver3.solution("x", 10));
            Console.WriteLine(solver3.solution(".", 10));
            Console.WriteLine(solver3.solution("", 10));


            // task 2:
            //var solver2 = new Solution2();
            //Console.WriteLine(solver2.solution("a") == 1);
            //Console.WriteLine(solver2.solution("ab") == 1);
            //Console.WriteLine(solver2.solution("aab") == 2);
            //Console.WriteLine(solver2.solution("cycle") == 2);
            //Console.WriteLine(solver2.solution("aaaa") == 4);

            // task 1:
            //var solver = new Solution();
            //Console.WriteLine(solver.solution("BAONXXOLL") == 1);
            //Console.WriteLine(solver.solution("BALON") == 0);
            //Console.WriteLine(solver.solution("BALLOON") == 1);
            //Console.WriteLine(solver.solution("B") == 0);
            //Console.WriteLine(solver.solution("BAOOLLNNOLOLGBAX") == 2);
            return 0;
        }
    }

    class Solution3
    {
        private const char pathole = 'x';
        private List<int> costs;

        public int solution(string S, int B)
        {
            this.costs = GetCosts(S);
            return GetMaxPatholesFix(0, B);
        }

        /// <summary>
        /// Gets Max Patholes Fix.
        /// </summary>
        /// <param name="i">considered index</param>
        /// <param name="cb">current budget</param>
        /// <returns></returns>
        private int GetMaxPatholesFix(int i, int cb)
        {
            if (i == costs.Count) return 0;
            var take = (cb - costs[i] >= 0) ? GetMaxPatholesFix(i + 1, cb - costs[i]) + costs[i] - 1 : 0;
            var notTake = GetMaxPatholesFix(i + 1, cb);
            return Math.Max(take, notTake);
        }

        private List<int> GetCosts(string S)
        {
            var costs = new List<int>();
            bool consecutive = false;
            int consecutiveNumber = 0;
            for (int i = 0; i < S.Length; i++)
            {
                if (S[i] == pathole)
                {
                    consecutive = true;
                    consecutiveNumber++;
                }
                else
                {
                    if (consecutive)
                        costs.Add(consecutiveNumber + 1);

                    consecutive = false;
                    consecutiveNumber = 0;
                }
            }

            if (consecutive) costs.Add(consecutiveNumber + 1);

            return costs;
        }
    }

    class Solution2
    {
        /*
          
        Get minimal number of split for unique subsets
        
            C#
            Correctness
            42%
            Performance
            28%
            Task score
            35
         */
        public int solution(string S)
        {
            var letters = new Dictionary<char, int>();
            foreach (char c in S)
            {
                if (letters.ContainsKey(c))
                    letters[c]++;
                else
                {
                    letters.Add(c, 1);
                }
            }

            return letters.Values.Max();
        }
    }


    class Solution1
    {
        /*
         How many times letters of BALLOON can be removed from initial string
         */
        public int solution(string S)
        {
            int result = 0;

            int B = 0;
            int A = 0;
            int N = 0;

            int L = 0;
            int O = 0;

            for (int i = 0; i < S.Length; i++)
            {
                if (S[i] == 'B') B++;
                if (S[i] == 'A') A++;
                if (S[i] == 'L') L++;
                if (S[i] == 'O') O++;
                if (S[i] == 'N') N++;
            }

            L /= 2;
            O /= 2;

            int[] res = new[] { B, A, L, O, N };

            return res.Min();
        }
    }
}
