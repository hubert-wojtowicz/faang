using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Xml.Linq;

namespace _15_3Sum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var sol = new Solution();
            sol.ThreeSum(new[] { -1, 0, 1, 2, -1, -4 });
        }
    }
    public class Solution
    {
        public IList<IList<int>> ThreeSum(int[] nums)
        {
            var res = new List<int[]>();
            var hashtable = new Dictionary<int, IList<int>>();
            for (var i = 0; i < nums.Length; i++)
            {
                if (hashtable.TryGetValue(nums[i], out var indexes))
                {
                    indexes.Add(i);
                    continue;
                }
                hashtable.Add(nums[i], new List<int>() { i });
            }
            for (var i = 0; i < nums.Length; i++)
            {
                for (var j = i + 1; j < nums.Length; j++)
                {
                    if (!hashtable.TryGetValue(-(nums[i] + nums[j]), out var hashtableEntry)) continue;
                    var validIndexes = hashtableEntry.Where(idx => idx != i && idx != j);
                    foreach (var validIndex in validIndexes)
                    {
                        res.Add(new[] { i, j, validIndex });
                    }
                }
            }

            return res as IList<IList<int>>;
        }
    }
}
