var array = Console.ReadLine().Split(' ').Select(x => int.Parse(x)).ToArray();
var bst = CreateBst(array);

Console.WriteLine(bst);

Node CreateMinBst(int[] array, int left, int right)
{
    if (left > right)
        return null;

    int mid = (left + right + 1) / 2;
    var node = new Node();
    node.Valiue = array[mid];
    node.Left = CreateMinBst(array, left, mid - 1);
    node.Right = CreateMinBst(array, mid + 1, right);

    return node;
}

Node CreateBst(int[] array)
{
    Array.Sort(array);
    return CreateMinBst(array, 0, array.Length - 1);
}

public class Node
{
    public int Valiue { get; set; }
    public Node Left { get; set; }
    public Node Right { get; set; }
}
