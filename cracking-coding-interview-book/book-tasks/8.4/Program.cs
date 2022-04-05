using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace _8._4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var solver = new Solution();
            solver.Print(solver.GetSubsetsIterative(new List<int> { 1, 2, 3 }));
        }
    }

    public class Solution
    {
        public List<List<int>> GetSubsets(List<int> set)
        {
            return GetSubsets(set, 0);
        }

        public void Print(List<List<int>> sets)
        {
            Console.WriteLine("{");
            foreach (var set in sets)
            {
                Console.WriteLine($"\t{{ {string.Join(", ", set)} }}");
            }
            Console.WriteLine("}");
        }

        private List<List<int>> GetSubsets(List<int> set, int size)
        {
            List<List<int>> allSubsets = new List<List<int>>();

            if (set.Count == size)
            {
                allSubsets.Add(new List<int>());
            }
            else
            {
                allSubsets = GetSubsets(set, size + 1);

                List<List<int>> moreSubsets = new List<List<int>>();
                var item = set[size];
                foreach (var subSet in allSubsets)
                {
                    var newSubset = new List<int>(subSet) { item };
                    moreSubsets.Add(newSubset);
                }

                allSubsets.AddRange(moreSubsets);
            }

            return allSubsets;
        }

        public List<List<int>> GetSubsetsIterative(List<int> set)
        {
            var allSubsets = new List<List<int>>();
            allSubsets.Add(new List<int> { });

            for (int i = 0; i < set.Count; i++)
            {
                // new List<List<int>>(allSubsets); does not copy memory!
                List<List<int>> newSubsets = (List<List<int>>)DeepClone(allSubsets);

                foreach (var subset in newSubsets)
                {
                    subset.Add(set[i]);
                }
                allSubsets.AddRange(newSubsets);
            }

            return allSubsets;
        }

        private object DeepClone(object obj)
        {
            object objResult = null;

            using (var ms = new MemoryStream())
            {
                var bf = new BinaryFormatter();
                bf.Serialize(ms, obj);

                ms.Position = 0;
                objResult = bf.Deserialize(ms);
            }

            return objResult;
        }
    }
}
