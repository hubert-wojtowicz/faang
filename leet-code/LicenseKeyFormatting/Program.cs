using System;
using System.Text;

namespace LicenseKeyFormatting
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var sol = new Solution();
            Console.WriteLine(sol.LicenseKeyFormatting("A5F3Z-2e-9-w", 4));
        }
    }

    public class Solution
    {
        public string LicenseKeyFormatting(string s, int k)
        {
            s = s.Replace("-", "").ToUpper();
            int grupingPoint = s.Length % k;
            var newStr = new StringBuilder(grupingPoint == 0 ? string.Empty : s.Substring(0, grupingPoint));
            while (grupingPoint < s.Length)
            {
                if (grupingPoint != 0) newStr.Append("-");
                newStr.Append(s.Substring(grupingPoint, k));
                grupingPoint += k;
            }

            return newStr.ToString();
        }
    }
}
