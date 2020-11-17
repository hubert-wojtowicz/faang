using System;

namespace _5_PermMissingElem
{
    class Program
    {
        static void Main(string[] args)
        {
            var sol = new Solutin();
            Console.WriteLine(sol.solution(new int[] { 2,3 }));
        }
    }


    /*
      N=0, then array A=[] missing 1.
      N=1, then array A=[1] missing 2 or [2] missing 1.
      N=2, then array A=[1,3] missing 2 or [2,3] missing 1 or [1,2] missing 3.
      and so on...

      N = 100 000 so O(n^2) can be enough, but we can apply O(n) as below.
     */

    class Solutin
    {
        public int solution(int[] A)
        {
            bool[] occurances = new bool[A.Length + 1];

            for (int i = 0; i < A.Length; i++)
            {
                occurances[A[i] - 1] = true;
            }

            for (int i = 0; i < occurances.Length; i++)
            {
                if (occurances[i] == false)
                    return i + 1;
            }

            return -1;
        }
    }
}
