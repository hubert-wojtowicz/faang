using System;
using System.Collections.Generic;

namespace BinaryGap
{
    class Program
    {
        static void Main(string[] args)
        {
            int N;
            N = int.Parse(Console.ReadLine());
            Console.WriteLine((new Solution()).solution(N));
        }
    }

    class Solution
    {
        public int solution(int N)
        {
            var bin = GetBinaryRep(N);
            int maxGap = 0, zerosLength = 0;
            while (bin.Count != 0)
            {
                var bit = bin.Pop();
                if (bit == true)
                {
                    if (zerosLength > 0)
                        maxGap = Math.Max(zerosLength, maxGap);

                    zerosLength = 0;
                }
                else
                {
                    ++zerosLength;
                }

            }

            return maxGap;
        }

        private Stack<bool> GetBinaryRep(int N)
        {
            var binaryRep = new Stack<bool>();
            while (N > 0)
            {
                if (N % 2 == 0)
                {
                    binaryRep.Push(false);
                }
                else
                {
                    binaryRep.Push(true);
                }
                N /= 2;
            }

            return binaryRep;
        }
    }
}
