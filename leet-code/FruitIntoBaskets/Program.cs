using System;
using System.Collections.Generic;
using System.Linq;

namespace FruitIntoBaskets
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var sol = new Solution();

            Console.WriteLine(sol.TotalFruit(new[] { 3, 3, 3, 3, 3, 3 }) == 6);
            Console.WriteLine(sol.TotalFruit(new[] { 3, 3, 3, 1, 2, 1, 1, 2, 3, 3, 4 }) == 5);
            Console.WriteLine(sol.TotalFruit(new[] { 0, 1, 2, 2 }) == 3);
            Console.WriteLine(sol.TotalFruit(new[] { 0 }) == 1);
            Console.WriteLine(sol.TotalFruit(new[] { 0, 0 }) == 2);
            Console.WriteLine(sol.TotalFruit(new[] { 0, 1 }) == 2);
            Console.WriteLine(sol.TotalFruit(new[] { 0, 1, 2 }) == 2);
            Console.WriteLine(sol.TotalFruit(new[] { 0, 1, 1, 1 }) == 4);
            Console.WriteLine(sol.TotalFruit(new[] { 1, 2, 1 }) == 3);
        }
    }

    public class Solution
    {
        // assume there is at least one tree
        // O(n)
        public int TotalFruit(int[] fruits)
        {
            var treesOfTypeNumbers = new List<(int, int)>();

            for (int i = 0; i < fruits.Length;) // O(n)
            {
                int currentTypeCount = 0;
                int currentType = fruits[i];
                while (i < fruits.Length && currentType == fruits[i])
                {
                    currentTypeCount++;
                    i++;
                }
                treesOfTypeNumbers.Add((currentType, currentTypeCount));
            }

            if (treesOfTypeNumbers.Count <= 2)
                return treesOfTypeNumbers.Sum(x => x.Item2);


            var max = int.MinValue;
            for (var i = 0; i + 1 < treesOfTypeNumbers.Count;) // O(n)
            {
                var type1 = treesOfTypeNumbers[i].Item1;
                var type1Count = treesOfTypeNumbers[i].Item2;
                var type2 = treesOfTypeNumbers[i + 1].Item1;
                var type2Count = treesOfTypeNumbers[i + 1].Item2;
                var collected = type1Count + type2Count;
                var j = i + 2;
                while (j < treesOfTypeNumbers.Count && (treesOfTypeNumbers[j].Item1 == type1 || treesOfTypeNumbers[j].Item1 == type2))
                {
                    collected += treesOfTypeNumbers[j].Item2;
                    j++;
                }

                max = Math.Max(max, collected);
                i = j - 1;
            }

            return max;
        }
    }
}
