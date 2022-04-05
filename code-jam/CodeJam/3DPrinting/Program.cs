using System;
using System.Linq;

namespace _3DPrinting
{
    internal class Program
    {
        const string imp = "IMPOSSIBLE";

        static void Main(string[] args)
        {
            int t = int.Parse(Console.ReadLine());
            for (int i = 0; i < t; i++)
            {
                int c = int.MaxValue;
                int m = int.MaxValue;
                int y = int.MaxValue;
                int k = int.MaxValue;

                for (int j = 0; j < 3; j++)
                {
                    var items = Console.ReadLine().Split(' ').Select(x => int.Parse(x)).ToArray();
                    c = Math.Min(items[0], c);
                    m = Math.Min(items[1], m);
                    y = Math.Min(items[2], y);
                    k = Math.Min(items[3], k);
                }

                if (c + m + y + k < 1e6)
                    Console.WriteLine($"Case #{i + 1}: {imp}");
                else
                    Console.WriteLine($"Case #{i + 1}: {Pack(c, m, y, k, 1000000)}");
            }
        }

        private static string Pack(int c, int m, int y, int k, int target)
        {
            int ct = Math.Min(c,target);
            int mt = Math.Min(m, target-ct);
            int yt = Math.Min(y, target - ct - mt);
            int kt = Math.Min(k, target - ct - mt - yt);

            return $"{ct} {mt} {yt} {kt}";
        }
    }
}
