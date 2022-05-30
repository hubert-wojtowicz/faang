using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace app1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int t = int.Parse(Console.ReadLine());
            for (int i = 0; i < t; i++)
            {
                int n = int.Parse(Console.ReadLine());
                string oldPass = Console.ReadLine();
                Console.WriteLine($"Case #{i + 1}: {GetNewPassword(oldPass)}");
            }
        }

        static string GetNewPassword(string old)
        {
            StringBuilder sb = new StringBuilder(old);

            bool HasAtLeastOneUpperCase = false;
            bool HasAtLeastOneLowerCase = false;
            bool HasDigit = false;
            bool HasSpecialChar = false;

            for (int i = 0; i < old.Length; i++)
            {
                int c = (int)old[i];
                if (c >= 65 && c <= 90) { HasAtLeastOneUpperCase = true; continue; }
                if (c >= 97 && c <= 122) { HasAtLeastOneLowerCase = true; continue; }
                if (c >= 48 && c <= 57) { HasDigit = true; continue; };
                if (c == 38 || c == 42 || c == 64 || c == 35) { HasSpecialChar = true; continue; }
            }

            if (!HasAtLeastOneLowerCase) sb.Append('a');
            if (!HasAtLeastOneUpperCase) sb.Append('A');
            if (!HasDigit) sb.Append('1');
            if (!HasSpecialChar) sb.Append('#');

            while (sb.Length < 7) sb.Append('a');

            return sb.ToString();
        }
    }
}
