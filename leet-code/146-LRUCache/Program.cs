var solver = new LRUCache(2);
Console.WriteLine(solver.Get(1));
solver.Put(2, 2);
solver.Put(3, 3);
Console.WriteLine(solver.Get(2));
Console.WriteLine(solver.Get(3));
solver.Put(4, 4);
Console.WriteLine(solver.Get(2));

public class Node
{
    public int Key;
    public int Value;
}

public class LRUCache
{
    private int _capacity;
    private LinkedList<Node> _story; // keeps sequence of access
    private Dictionary<int, LinkedListNode<Node>> _map; // Key - Node

    public LRUCache(int capacity)
    {
        _capacity = capacity;
        _story = new LinkedList<Node>();
        _map = new Dictionary<int, LinkedListNode<Node>>();
    }

    public int Get(int key)
    {
        if (!_map.ContainsKey(key))
        {
            return -1;
        }

        var entry = _map[key];
        _story.Remove(entry);
        _story.AddLast(entry);
        return entry.Value.Value;
    }

    public void Put(int key, int val)
    {
        var nnode = new LinkedListNode<Node> (new Node() { Key = key, Value = val });

        if (!_map.ContainsKey(key))
        {
            _story.AddLast(nnode);
            _map.Add(key, nnode);
        }
        else
        {
            var onode = _map[key];
            _story.Remove(onode);
            _map.Remove(key);

            _story.AddLast(nnode);
            _map.Add(key, nnode);
        }

        if (_story.Count() > _capacity)
        {
            var first = _story.First();
            _story.RemoveFirst();
            _map.Remove(first.Key);
        }
    }
}

/**
 * Your LRUCache object will be instantiated and called as such:
 * LRUCache obj = new LRUCache(capacity);
 * int param_1 = obj.Get(key);
 * obj.Put(key,value);
 */