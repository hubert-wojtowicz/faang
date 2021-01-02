using System;

namespace Position_of_rightmost_set_bit
{
    class Program
    {
        static int Main(string[] args)
        {
            //https://pl.wikipedia.org/wiki/Kod_uzupe%C5%82nie%C5%84_do_dw%C3%B3ch
            //https://en.wikipedia.org/wiki/Two%27s_complement

            // Complement to two - negate bits and plus 1

            Console.WriteLine(GFG.getFirstSetBitPos(7));

            //Console.WriteLine(unchecked((int)0b1_1111111_11111111_11111111_11111111));
            //Console.WriteLine(unchecked((int)0b1_0000000_00000000_00000000_00000000));
            //Console.WriteLine(unchecked((int)0b0_0000000_00000000_00000000_00000000));


            //Console.WriteLine(unchecked((int)0b0_0000000_00000000_00000000_00001100));
            //Console.WriteLine(unchecked((int)0b1_1111111_11111111_11111111_11110100));

            //Console.WriteLine(unchecked((int)0b0_0000000_00000000_00000000_00001100) & unchecked((int)0b1_1111111_11111111_11111111_11110100));

            return 0;
        }
    }

    class GFG 
	{
		public static int getFirstSetBitPos(int n)
		{
			return (int)(Math.Log10(n & -n)/Math.Log10(2)) + 1;
		}
	}
}
