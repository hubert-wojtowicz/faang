

public interface IThreeStack
{
    void PushA(int val);
    int PopA();
    void PushB(int val);
    int PopB();
    void PushC(int val);
    int PopC();
}


public class ThreeStack : IThreeStack
{
    private int[] _arr;
    private int _startA, _startB, _startC;
    private int _lenA, _lenB, _lenC;

    public ThreeStack(int size)
    {
        _arr = new int[size];
        _startA = 0;
        _startB = size / 3;
        _startC = size * 2 / 3;
        _lenA = 0;
        _lenB = 0;
        _lenC = 0;
    }

    public void PushA(int val)
    {
        if (_startA + _lenA + 1 < _startB)
        { 
        
        }
    }

    public int PopA()
    {
        throw new NotImplementedException();
    }

    public void PushB(int val)
    {
        throw new NotImplementedException();
    }

    public int PopB()
    {
        throw new NotImplementedException();
    }

    public void PushC(int val)
    {
        throw new NotImplementedException();
    }

    public int PopC()
    {
        throw new NotImplementedException();
    }
}