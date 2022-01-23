using System.Text;


int negativeNumer = int.MinValue;
int negativeNumerRightShifted = negativeNumer >> 3;

Console.WriteLine(negativeNumer);
Console.WriteLine(BitConverter.GetBytes(negativeNumer).GroupBits());♦
Console.WriteLine(BitConverter.GetBytes(negativeNumerRightShifted).GroupBits());

// Play with other numbers
int a;
while(int.TryParse(Console.ReadLine(),out a))
{
    Console.WriteLine(BitConverter.GetBytes(a).GroupBits());
    a = a >> 2;
    Console.WriteLine(BitConverter.GetBytes(a).GroupBits());
}

public static class BitOperations
{
    public static int GetBit(int num) { return num; }
    public static int UpdateBit(int num, int pos) { return num; }
    public static int ClearBit(int num, int pos) { return num; }


    public static string GroupBits(this byte[] inp, string groupSeparator = " ")
    {
        StringBuilder sb = new();
        var ninp = inp.Reverse().ToArray();
        for (int i = 0; i < inp.Length; i++)
        {
            sb.Append(
                ninp[i]==0 
                    ? "00000000" 
                    : Convert.ToString(ninp[i], 2).FillPrefix()
            ).Append(groupSeparator);
        }
        return sb.ToString();
    }

    public static string FillPrefix(this string s)
    {
        return s.Length < 8 ? new string('0', 8 - s.Length) + s : s;
    }
}