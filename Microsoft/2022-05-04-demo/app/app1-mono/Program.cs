using System.Collections.Generic;
using System.Linq;

namespace app1_mono
{
    internal class Program
    {
        static void Main(string[] args)
        {
        }
    }


    class Solution
    {
        public int solution(int[] A)
        {
            var positive = new HashSet<int>(A.Where(x => x > 0));
            int max = positive.Any() ? positive.Max() : 0;

            for (int i = 1; i <= max + 1; i++)
            {
                if (!positive.Contains(i))
                    return i;
            }

            return 1;
        }
    }
}
