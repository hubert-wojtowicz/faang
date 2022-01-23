var s = new CustomStack(4);

s.Push(1);
s.Push(2);
s.Push(3);
s.Push(4);
s.Push(5);

Console.WriteLine($"Min value = {s.Min()}");

while (s.Size > 0)
{
    Console.Write($"{s.Pop()} ");
}

public interface ICustomStack
{
    void Push(int val);
    int Pop();
    int Peek();
    int Min();
    int Size { get; }
}

class CustomStack : ICustomStack
{
    private int[] values;
    private int capacity;
    private int min = int.MaxValue;
    public int Size { get; private set; }

    public CustomStack(int capacity = 32)
    {
        this.capacity = capacity;
        values = new int[this.capacity];
    }

    public int Min()
    {
        if (Size == 0)
            throw new InvalidOperationException("Stack does not contain elements");
        return min;
    }

    public int Peek()
    {
        if (Size == 0)
            throw new InvalidOperationException("Stack does not contain elements");
        return values[Size - 1];
    }

    public int Pop()
    {
        if (Size == 0)
            throw new InvalidOperationException("Stack does not contain elements");
        Size--;
        return values[Size];
    }

    public void Push(int val)
    {
        if (Size < capacity)
        {
            values[Size] = val;
        }
        else
        {
            capacity *= 2;
            var newValues = new int[capacity];
            values.CopyTo(newValues, 0);
            values = newValues;
            values[Size] = val;
        }

        min = Math.Min(val, min);
        Size++;
    }
}