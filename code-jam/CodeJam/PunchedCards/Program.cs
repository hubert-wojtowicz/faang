using System;
using System.Text;

namespace PunchedCards
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int t;
            t = int.Parse(Console.ReadLine());
            for (int i = 0; i < t; i++)
            {
                var items = Console.ReadLine().Split(' ');
                int r = int.Parse(items[0]);
                int c = int.Parse(items[1]);

                Console.WriteLine($"Case #{i + 1}:");
                Solve(r, c);
            }
        }

        static void Solve(int r, int c)
        {
            int pr = 2 * r + 1;
            int pc = 2 * c + 1;
            for (int i = 1; i <= pr; i++)
            {
                if (i % 2 == 0)
                {
                    PrintDotPipe(i, pc);
                }
                else
                {
                    PrintEdgeLine(i, pc);
                }
            }
        }

        private static void PrintEdgeLine(int lineNumber, int c)
        {
            var line = new StringBuilder();
            int i = 1;
            if (lineNumber < 3)
            {
                line.Append("..");
                i = 3;
            }

            for (; i <= c; i++)
            {
                if (i % 2 == 0)
                {
                    line.Append('-');
                }
                else
                {
                    line.Append('+');
                }
            }
            Console.WriteLine(line);
        }

        static void PrintDotPipe(int lineNumber, int c)
        {
            var line = new StringBuilder();
            int i = 1;
            if (lineNumber < 3)
            {
                line.Append("..");
                i = 3;
            }

            for (; i <= c; i++)
            {
                if (i % 2 == 0)
                {
                    line.Append('.');
                }
                else
                {
                    line.Append('|');
                }
            }
            Console.WriteLine(line);
        }
    }
}
