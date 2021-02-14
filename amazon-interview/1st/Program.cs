using System;
using System.Collections.Generic;

/*
TASK:
Check for Balanced Brackets in an expression
Given an expression string exp, write a program to examine whether the pairs and the orders of “{“, “}”, “(“, “)”, “[“, “]” are correct in exp.
Example:
Input: exp = “[()]{}{[()()] ()}” 
Output: Balanced
Input: exp = “[(])” 
Output: Not Balanced


Expression: {1 + [3 – (1 + 2)] *2}
*/
namespace interview
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Tests:");
            Console.WriteLine(SolutionOptimized.IsBracketsValid("{ 1 + [3 – (1 + 2)] *2}") == true);
            Console.WriteLine(SolutionOptimized.IsBracketsValid("{ 1 + [3 – (2 + ]1 + 2)) *2}") == false);
        }
    }

    public static class SolutionOptimized
    {
        // time O(n) as each character analyzed, additional memory space over input O(1)
        public static bool IsBracketsValid(string exp)
        {
            var bracketChars = new HashSet<char>() { '{', '}', '[', ']', '(', ')' };
            var eStack = new Stack<char>();
            for (int i = 0; i < exp.Length; i++)
            {
                if (!bracketChars.Contains(exp[i]))
                    continue;

                if (exp[i] == '{' || exp[i] == '[' || exp[i] == '(')
                {
                    eStack.Push(exp[i]);
                }
                else
                {
                    if ((eStack.Peek() != '{' && exp[i] == '}')
                     || (eStack.Peek() != '[' && exp[i] == ']')
                     || (eStack.Peek() != '(' && exp[i] == ')'))
                        return false;

                    eStack.Pop();
                }
            }

            return eStack.Count == 0;
        }
    }

    // this is what I did in interview
    public static class Solution
    {
        public static bool IsBracketsValid(string exp)
        {
            var eStack = new Stack<char>();
            var bracketChars = new HashSet<char>() { '{', '}', '[', ']', '(', ')' };
            for (int i = 0; i < exp.Length; i++)
            {
                if (bracketChars.Contains(exp[i]))
                {
                    if (exp[i] == '{' || exp[i] == '[' || exp[i] == '(')
                    {
                        eStack.Push(exp[i]);
                    }
                    else
                    {
                        var closing = exp[i];
                        if (closing == '}')
                        {
                            if (eStack.Peek() != '{')
                                return false;
                            else
                            {
                                eStack.Pop();
                                continue;
                            }
                        }
                        else if (closing == ']')
                        {
                            if (eStack.Peek() != '[')
                                return false;
                            else
                            {
                                eStack.Pop();
                                continue;
                            }
                        }
                        else
                        {
                            if (eStack.Peek() != '(')
                                return false;
                            else
                            {
                                eStack.Pop();
                                continue;
                            }
                        }

                    }
                }
            }

            // bug here
            return true;
        }
    }
}
