using System;

namespace Party_of_Couples
{
    class Program
    {
        static void Main(string[] args)
        {
            var sol = new Solution();
            
            Console.WriteLine(sol.NoCouples(new uint[] { 1, 2, 3, 2, 1 }));
            Console.WriteLine(sol.NoCouples(new uint[] { 1, 2, 3, 5, 3, 2, 1, 4, 5, 6, 6 }));
            Console.WriteLine(sol.NoCouples(new uint[] { 1, 1, 7 }));
        }
    }

    public class Solution
    {
        public uint NoCouples(uint[] A)
        {
            uint denoteCoupes = 0;
            for (int i = 0; i < A.Length; i++)
            {
                denoteCoupes ^= A[i];
            }

            return denoteCoupes;
        }
    }
}
