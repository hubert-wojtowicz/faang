// See https://aka.ms/new-console-template for more information
var solver = new Solution();
 var head = solver.ReverseList(new ListNode(1, new ListNode(2, new ListNode(3))));
Console.WriteLine("Hello, World!");

public class ListNode
{
    public int val;
    public ListNode next;
    public ListNode(int val = 0, ListNode next = null)
    {
        this.val = val;
        this.next = next;
    }
}


public class Solution
{
    public ListNode ReverseList(ListNode head)
    {
        if (head?.next == null) return head;

        // erase to avoid cycle
        var temp = head.next;
        head.next = null;

        return ReverseListHelper(head, temp);
    }

    private ListNode ReverseListHelper(ListNode lastReversed, ListNode head)
    {
        if (head.next == null)
        {
            head.next = lastReversed;
            return head;
        }
        var nHead = head.next;
        head.next = lastReversed;

        return ReverseListHelper(head, nHead);
    }
}