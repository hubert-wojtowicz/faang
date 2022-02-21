using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _15_3Sum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var sol = new Solution();
            Print(sol.ThreeSum(new[] { -1, 0, 1, 2, -1, -4 }));
        }

        static void Print(IList<IList<int>> list)
        {
            var sb = new StringBuilder("[");
            foreach (var item in list)
            {
                sb.Append($"$[{item[0]},{item[1]},{item[2]}],");
            }
            sb.Append("]");
            Console.WriteLine(sb.ToString());
        }
    }

    public class Solution
    {
        // O(n^2)
        public IList<IList<int>> ThreeSum(int[] nums) // O(n^2)
        {
            Array.Sort(nums);// O(n lg n)
            var res = new HashSet<Tuple<int, int, int>>();
            var valueIndexDict = new Dictionary<int, IList<int>>();

            for (var i = 0; i < nums.Length; i++) // O(n^2)
            {
                if (valueIndexDict.TryGetValue(nums[i], out var indexes)) // O(1)
                {
                    indexes.Add(i); // O(n)
                    continue;
                }
                valueIndexDict.Add(nums[i], new List<int>() { i });
            }

            for (var i = 0; i < nums.Length; i++) // O(n^2)
            {
                for (var j = i + 1; j < nums.Length; j++) // those 2 loops gives all unique pairs (i,j)
                {
                    var searchValue = -(nums[i] + nums[j]);
                    if (!valueIndexDict.TryGetValue(searchValue, out var indexes)) continue;
                    foreach (var idx in indexes.Where(idx => idx > j))
                    {
                        var triple = new Tuple<int, int, int>(nums[i], nums[j], nums[idx]);
                        if (res.Contains(triple)) continue; // O(1)
                        res.Add(triple);
                    }
                }
            }

            return res.Select(triple => new int[] { triple.Item1, triple.Item2, triple.Item3 }).ToArray();
        }
    }
}
