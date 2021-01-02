using System;
using System.Linq;

namespace _199_Sort_linked_list_sorted_on_absolute_values
{
    class Program
    {
        static void Main(string[] args)
        {
            // assume at least one element
            string line = Console.ReadLine();
            var vals = line.Split("->").Select(x => int.Parse(x.Trim()));
            Node ll = new Node { Key = vals.FirstOrDefault() };
            Node prev = ll;
            foreach (var item in vals.Skip(1))
            {
                prev.Next = new Node { Key = item };
                prev = prev.Next;
            }

            Node p = Sort(ll);
            while (p != null)
            {
                Console.Write(p.Key+" -> ");
                p = p.Next;
            }
        }

        public static Node Sort(Node r)
        {
            Node negativeHead=null;
            Node negativeTail=null;
            Node positiveHead=null;
            Node positiveTail=null;

            Node p = r;
            while (p != null)
            {
                if (p.Key < 0)
                {
                    if (negativeHead == null)
                    {
                        negativeHead = new Node { Key = p.Key };
                        negativeTail = negativeHead;
                    }
                    else
                    {
                        var ni = new Node { Key = p.Key, Next = negativeHead };
                        negativeHead = ni;
                    }
                }
                else
                {
                    if (positiveTail == null)
                    {
                        positiveTail = new Node { Key = p.Key };
                        positiveHead = positiveTail;
                    }
                    else
                    {
                        positiveTail.Next = new Node { Key = p.Key };
                        positiveTail = positiveTail.Next;
                    }
                }
                p = p.Next;
            }
            negativeTail.Next = positiveHead;

            return negativeHead;
        }
    }
    public class Node
    {
        public Node Next;
        public int Key;
    }
}
