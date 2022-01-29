using System;

namespace _844_Backspace_String_Compare
{
    class Program
    {
        static void Main(string[] args)
        {
            var sol = new Solution();

            Console.WriteLine(sol.BackspaceCompare("bxj##tw", "bxo#j##tw") == true);
            Console.WriteLine(sol.BackspaceCompare("ab##", "c#d#") == true);
            Console.WriteLine(sol.BackspaceCompare("#", "#") == true);
            Console.WriteLine(sol.BackspaceCompare("#", "a") == false);
            Console.WriteLine(sol.BackspaceCompare("###", "#") == true);
            Console.WriteLine(sol.BackspaceCompare("a##b", "b") == true);
            Console.WriteLine(sol.BackspaceCompare("abab#aba#", "abaaba#") == true);
            Console.WriteLine(sol.BackspaceCompare("ala###", "#") == true);
        }
    }
    // solution: https://leetcode.com/submissions/detail/441500168/
    public class Solution
    {
        // O(|S|+|T|)
        public bool BackspaceCompare(string S, string T)
        {
            int s = S.Length - 1, t = T.Length - 1;
            while (s >= 0 || t >= 0)
            {
                if ((s >= 0 && S[s] == '#') || (t >= 0 && T[t] == '#'))
                {
                    if (s >= 0 && S[s] == '#')
                    {
                        int sbc = 2;
                        while (sbc > 0)
                        {
                            --sbc;
                            --s;
                            if (s >= 0 && S[s] == '#')
                            {
                                sbc += 2;
                            }
                        }
                    }
                    if (t >= 0 && T[t] == '#')
                    {
                        int tbc = 2;
                        while (tbc > 0)
                        {
                            --tbc;
                            --t;
                            if (t >= 0 && T[t] == '#')
                            {
                                tbc += 2;
                            }
                        }
                    }
                }
                else
                {
                    if (s>=0 && t>=0 && S[s] != T[t])
                        return false;
                    else if ((s >= 0 && t < 0) || (s < 0 && t >= 0))
                        return false;
                    else
                    {
                        --s;
                        --t;
                    }
                }
            }

            return true;
        }
    }
}
