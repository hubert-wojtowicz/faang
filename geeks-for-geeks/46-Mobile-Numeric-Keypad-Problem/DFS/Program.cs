using System;
using System.Collections.Generic;

namespace _46_Mobile_Numeric_Keypad_Problem
{
    class Program
    {
        static void Main(string[] args)
        {
            var key1 = new Vertex { Key = 1 };
            var key2 = new Vertex { Key = 2 };
            var key3 = new Vertex { Key = 3 };
            var key4 = new Vertex { Key = 4 };
            var key5 = new Vertex { Key = 5 };
            var key6 = new Vertex { Key = 6 };
            var key7 = new Vertex { Key = 7 };
            var key8 = new Vertex { Key = 8 };
            var key9 = new Vertex { Key = 9 };
            var key0 = new Vertex { Key = 0 };

            key1.Ways.AddRange(new[] { key1, key2, key4 });
            key2.Ways.AddRange(new[] { key1, key2, key3, key5 });
            key3.Ways.AddRange(new[] { key2, key3, key6 });
            key4.Ways.AddRange(new[] { key1, key4, key5, key7 });
            key5.Ways.AddRange(new[] { key2, key4, key5, key6, key8 });
            key6.Ways.AddRange(new[] { key3, key5, key6, key9 });
            key7.Ways.AddRange(new[] { key4, key8, key7 });
            key8.Ways.AddRange(new[] { key5, key7, key8, key9, key0 });
            key9.Ways.AddRange(new[] { key6, key8, key9 });
            key0.Ways.AddRange(new[] { key0, key8 });

            var graph = new List<Vertex>()
            {
               key1, key2, key3,
               key4, key5, key6,
               key7, key8, key9,
                     key0
            };

            int n = int.Parse(Console.ReadLine());

            Console.WriteLine(Count(graph, n));
        }

        private static int Count(List<Vertex> graph, int n)
        {
            int sum = 0;
            foreach (var item in graph)
            {
                sum += Count(item, n);
            }
            return sum;
        }
        private static int Count(Vertex v, int n)
        {
            if (n == 1)
                return n;
            else
            {
                int sum = 0;
                foreach (var vn in v.Ways)
                {
                    sum += Count(vn, n - 1);
                }
                return sum;
            }
        }
    }

    public class Vertex
    {        
        public byte Key { get; set; }
        public List<Vertex> Ways { get; set; } = new List<Vertex>();
    }
}
