// 2.1 remove duplicate from Linked List
using System.Collections.Generic;

var ll = Console.ReadLine()
    .Split(' ')
    .Select(x => new Node() { Value = int.Parse(x) })
    .ToArray();

if (ll != null && ll.Count() > 1)
{
    for (int i = 0; i < ll.Count() - 1; i++) ll[i].Next = ll[i + 1];
}
RemoceDuplicate(ll[0]);
PrintList(ll[0]);

Node RemoceDuplicate(Node head)
{
    if(head == null) return null;

    HashSet<int> hs = new HashSet<int>() { head.Value };
    Node current = head;
    while (current.Next != null)
    {
        if (hs.Contains(current.Next.Value))
        {
            current.Next = current.Next.Next;
        }
        else
        { 
            hs.Add(current.Next.Value);
            current = current.Next;
        }
    }
    return head;
}

void PrintList(Node head)
{
    Node current = head;
    while (current != null)
    {
        Console.Write($"{current.Value}->");
        current = current.Next;
    }
    Console.WriteLine();
}

public class Node
{
    public int Value { get; set; }
    public Node Next { get; set; }
}
