using System;

namespace OddEvenJump
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var sol = new Solution();

            Console.WriteLine(sol.OddEvenJumps(new[] { 10, 13, 12, 14, 15 }) == 2);
            Console.WriteLine(sol.OddEvenJumps(new[] { 2, 3, 1, 1, 4 }) == 3);
            Console.WriteLine(sol.OddEvenJumps(new[] { 5, 1, 3, 4, 2 }) == 3);
        }
    }

    public class Solution
    {
        public int OddEvenJumps(int[] arr)
        {
            var sol = 0;
            for (var i = 0; i < arr.Length - 1; i++)
            {
                if (IgGoodIndex(arr, i))
                    sol++;
            }
            return sol;
        }

        private bool IgGoodIndex(int[] arr, int nowIdx = 0)
        {
            if (nowIdx >= arr.Length) return false;
            if (nowIdx == arr.Length - 1) return true;

            var oddJumpLength = 0;
            var evenJumpLength = 0;

            for (var i = 1; i + nowIdx < arr.Length; i += 2)
            {
                if (arr[nowIdx] > arr[nowIdx + i]) continue;
                oddJumpLength = i;
                break;
            }

            for (var i = 2; i + nowIdx < arr.Length; i += 2)
            {
                if (arr[nowIdx] < arr[nowIdx + i]) continue;
                evenJumpLength = i;
                break;
            }

            return (oddJumpLength != 0 && IgGoodIndex(arr, nowIdx + oddJumpLength)) || (evenJumpLength != 0 && IgGoodIndex(arr, nowIdx + evenJumpLength));
        }
    }
}
