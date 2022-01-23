// 1.1
using System.Collections;
using System.Diagnostics;

while (true)
{
    string s = Console.ReadLine();
    if (s == null || s == String.Empty) break;

    if (IsUniqueCanNotUseDataStucture(s)) Console.WriteLine("Is unique.");
    else Console.WriteLine("Is not unique.");

}

Debug.Assert(!IsUnique("aa"), "This string is not unique");
Debug.Assert(!IsUniqueCanNotUseDataStucture("aa"), "This string is not unique");

Debug.Assert(!IsUnique("abccde"), "This string is not unique");
Debug.Assert(!IsUniqueCanNotUseDataStucture("abccde"), "This string is not unique");

Debug.Assert(IsUnique("abcde"), "This string is unique");
Debug.Assert(IsUniqueCanNotUseDataStucture("abcde"), "This string is unique");

bool IsUnique(string s)
{
    BitArray alphabet = new BitArray((int)Math.Pow(2, sizeof(char)*8)); // hash map key character, value exist i s
    foreach (var character in s)
    {
        if (!alphabet[(int)character])
        {
            alphabet[(int)character] = true;
            continue;
        }
        else
        {
            return true;
        }
    }

    return true;
}


bool IsUniqueCanNotUseDataStucture(string s)
{
    if (s == null && s.Length < 1)
        return true;

    s = string.Concat(s.OrderBy(x => x)); // sort string O(n lg n)
    char prev = s[0];
    for (int i = 1; i < s.Length; i++)
    {
        if (prev == s[i])
            return false;

        prev = s[i];
    }
    return true;
}