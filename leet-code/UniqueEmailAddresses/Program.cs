using System;
using System.Collections.Generic;

namespace UniqueEmailAddresses
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var sol = new Solution();
            sol.NumUniqueEmails(new[]
            {
                "test.email+alex@leetcode.com", "test.e.mail+bob.cathy@leetcode.com", "testemail+david@lee.tcode.com"
            });
            Console.WriteLine("Hello World!");
        }
    }
    public class Solution
    {
        public int NumUniqueEmails(string[] emails)
        {
            var uniqueEmails = new HashSet<string>();
            for (int i = 0; i < emails.Length; ++i)
            {
                var decomposition = emails[i].Split("@");
                if (decomposition.Length != 2) continue;

                var domainName = decomposition[1].ToUpperInvariant();
                var localName = decomposition[0].ToUpperInvariant();

                if(localName.Length == 0) continue;
                if(!domainName.EndsWith(".COM")) continue;

                var ignoreIndex = localName.IndexOf("+", StringComparison.Ordinal);

                if (ignoreIndex != -1)
                {
                    localName = localName[..ignoreIndex];
                }

                localName = localName.Replace(".", "");
                var normalizedEmail = $"{localName}@{domainName}";

                if (!uniqueEmails.Contains(normalizedEmail))
                    uniqueEmails.Add(normalizedEmail);
            }

            return uniqueEmails.Count;
        }
    }
}
