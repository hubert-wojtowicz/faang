// https://leetcode.com/problems/linked-list-cycle-ii/submissions/914663353/

var solver = new Solution();

var l0 = new ListNode(3);
var l1 = new ListNode(2);
var l2 = new ListNode(0);
var l3 = new ListNode(-4);
l0.next = l1;
l1.next = l2;
l2.next = l3;
l3.next = l1;

var cycleStart = solver.DetectCycle(l0);
Console.WriteLine(cycleStart.val);


public class ListNode
{
    public int val;
    public ListNode next;
    public ListNode(int x)
    {
        val = x;
        next = null;
    }
}


public class Solution
{
    public ListNode DetectCycle(ListNode head)
    {
        ListNode tortise = MoveByOne(head);
        ListNode hare = MoveByTwo(head);

        while ((tortise != null || hare != null) && tortise != hare)
        {
            tortise = MoveByOne(tortise);
            hare = MoveByTwo(hare);
        }

        if (tortise != hare) return null;

        while (head != tortise)
        {
            tortise = MoveByOne(tortise);
            head = MoveByOne(head);
        }
        return head;
    }

    ListNode MoveByOne(ListNode p)
    {
        return p?.next;
    }

    ListNode MoveByTwo(ListNode p)
    {
        return p?.next?.next;
    }
}