using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _15_3Sum
{

    //https://www.code-recipe.com/post/three-sum
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
        public IList<IList<int>> ThreeSum(int[] nums)
        {
            Array.Sort(nums);// O(n lg n)
            var map = new Dictionary<int, List<int>>(); //key: target value: indexes
            var seen = new HashSet<string>();
            var sol = new List<IList<int>>();

            for (int i = 0; i < nums.Length; i++)
            {
                if (map.ContainsKey(nums[i]))
                {
                    map[nums[i]].Add(i);
                }
                else
                {
                    map.Add(nums[i], new List<int>() { i });
                }
            }

            for (int i = 0; i < nums.Length; i++)
            {
                for (int j = i + 1; j < nums.Length; j++) // O(n^2)
                {
                    int target = -nums[i] - nums[j];
                    if (map.ContainsKey(target))
                    {
                        foreach (var k in map[target].Where(t => t != i && t != j))
                        {
                            var a = new int[] { nums[i], nums[j], nums[k] };
                            Array.Sort(a);
                            var id = $"{a[0]},{a[1]},{a[2]}";

                            if (!seen.Contains(id))
                            {
                                seen.Add(id);
                                sol.Add(new[] { nums[i], nums[j], nums[k] });
                            }
                        }
                    }
                }
            }

            return sol;
        }
    }
}
