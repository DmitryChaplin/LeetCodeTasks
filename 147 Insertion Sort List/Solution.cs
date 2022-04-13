using Common;
public class Solution
{
    public ListNode InsertionSortList(ListNode head)
    {
        var cur = head?.next;
        var prev = head;

        while (cur != null)
        {
            var temp = cur;
            cur = cur.next;
            if (temp.val < prev.val)
            {
                prev.next = cur;
                var newHead = Insert(head, temp);
                if (newHead != null)
                    head = newHead;
            }
            else
                prev = temp;
        }

        return head;
    }

    ListNode Insert(ListNode head, ListNode node)
    {
        // shift the node to the left, if the value is smaller
        if (node.val < head.val)
        {
            node.next = head;
            return node;
        }

        // 
        while (head.next != null && head.next.val < node.val)
        {
            head = head.next;
        }

        node.next = head.next;
        head.next = node;

        return null;
    }
}