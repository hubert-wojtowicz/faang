using System;

namespace _190_Reverse_words_in_a_given_string
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] inp = "Ala1 Ala2 Ala3 Ala4 Ala5".Split(' ');
            RevStr(ref inp);
            Console.WriteLine(string.Join(' ', inp));

            string[] inp2 = "Ala1 Ala2 Ala4 Ala5".Split(' ');
            RevStr(ref inp2);
            Console.WriteLine(string.Join(' ', inp2));

            string[] inp3 = "Ala1".Split(' ');
            RevStr(ref inp3);
            Console.WriteLine(string.Join(' ', inp3));

            string[] inp4 = null;
            RevStr(ref inp4);
            Console.WriteLine(inp4);
        }

        static void RevStr(ref string[] s)
        {
            if (s == null)
                return;
            int endIndex = s.Length - 1;
            for (int i = 0; i < s.Length/2; i++)
            {
                string temp = s[endIndex - i];
                s[endIndex - i] = s[i];
                s[i] = temp;
            }
        }
    }
}
