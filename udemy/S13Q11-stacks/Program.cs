using System;

namespace S13Q11_stacks
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine($" \"\" - {CountBracketsToRemove("")}");
            Console.WriteLine($" \"()\" - {CountBracketsToRemove("()")}");
            Console.WriteLine($" \"(\" - {CountBracketsToRemove("(")}");
            Console.WriteLine($" \")\" - {CountBracketsToRemove(")")}");
            Console.WriteLine($" \"(()())()\" - {CountBracketsToRemove("(()())()")}");
            Console.WriteLine($" \"((\" - {CountBracketsToRemove("((")}");
            Console.WriteLine($" \"))\" - {CountBracketsToRemove("))")}");
            Console.WriteLine($" \"()(()))()())\" - {CountBracketsToRemove("()(()))()())")}");
        }

        static int CountBracketsToRemove(string s)
        {
            int opening = 0;
            int closingToRemove = 0;

            for(int i=0;i<s.Length;i++)
            {
                if(s[i]=='(')
                    opening++;

                if(s[i]==')')
                {
                    if(opening>0)
                        opening--;
                    else
                        closingToRemove++;
                }
            }
            return opening + closingToRemove;
        }
    }
}
