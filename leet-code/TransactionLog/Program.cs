using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text.RegularExpressions;
using System.Text;
using System;

class Result
{

    /*
     * Complete the 'processLogs' function below.
     *
     * The function is expected to return a STRING_ARRAY.
     * The function accepts following parameters:
     *  1. STRING_ARRAY logs
     *  2. INTEGER threshold
     */

    public static int GetItems(string s, int si, int ei)
    {
        int items = 0;

        while (si < s.Length && s[si++] != '|') ;
        while (ei > si && s[ei--] != '|') ;
        if (si == ei) return 0;
        while (si <= ei)
        {
            if (s[si++] == '*')
                items++;
        }

        return items;
    }
}

class Solution
{
    public static void Main(string[] args)
    {
        Console.WriteLine(Result.GetItems("******", 0, 5) == 0);
        Console.WriteLine(Result.GetItems("**|***", 0, 5) == 0);
        Console.WriteLine(Result.GetItems("*****|", 0, 5) == 0);
        Console.WriteLine(Result.GetItems("|*****", 0, 5) == 0);
        Console.WriteLine(Result.GetItems("*****|", 0, 5) == 0);
        Console.WriteLine(Result.GetItems("|****|", 0, 5) == 4);
        Console.WriteLine(Result.GetItems("|*|*|*", 0, 5) == 2);
        Console.WriteLine(Result.GetItems("*|*|*|", 0, 5) == 2);
        Console.WriteLine(Result.GetItems("|*|*|*|", 0, 6) == 3);
    }
}
