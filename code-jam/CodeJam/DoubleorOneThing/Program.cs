using System;
using System.Text;

namespace DoubleorOneThing
{
    class Program
    {
        static void Main(string[] args)
        {
            int tt = int.Parse(Console.ReadLine());
            for (int t = 1; t <= tt; t++)
            {
                Console.WriteLine($"Case #{t}: {LexDoubleSolver(Console.ReadLine())}");
            }
        }

        static string LexDoubleSolver(string s)
        {
            var sb = new StringBuilder();
            for (int i = 0; i < s.Length;)
            {
                var currentCharCount = CountChar(s, i);
                sb.Append(s[i], currentCharCount);
                if (i + currentCharCount < s.Length && s[i] < s[i + currentCharCount])
                    sb.Append(s[i], currentCharCount);
                i += currentCharCount;
            }

            return sb.ToString();
        }

        // Returns number of char in position startingIndex and after
        static int CountChar(string s, int atIndex)
        {
            int counter = 1;
            char counted = s[atIndex];
            while (counter + atIndex < s.Length
                && counted == s[counter + atIndex])
            {
                ++counter;
            };
            return counter;
        }
    }
}