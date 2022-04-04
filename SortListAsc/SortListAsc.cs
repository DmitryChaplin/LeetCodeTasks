namespace SortListAsc
{
    public class ListNode {
          public int val;
          public ListNode next;
          public ListNode(int val=0, ListNode next=null) 
          {
              this.val = val;
              this.next = next;
          }
      }
     

    // Split this list into halves list until there is only 1 node left
    // then sort them. should be O(nlogn)
    public class Solution
    {
        public ListNode SortList(ListNode head)
        {
            /* Splitting phase */

            // Point where we need to stop splitting the list in halves. 
            if (head == null || head.next == null)
            {
                return head;
            }

            // get the middle of the current list
            var middleNode = GetMiddleNode(head);

            // Let's keep the splitting the list into sublists until we get a bunch of single nodes
            var left = SortList(head);
            var right = SortList(middleNode);

            /* Sorting / merging phase */
            return Merge(left, right);
        }

        ListNode GetMiddleNode(ListNode node)
        {
            // Let's declare the node before the actual middle of the list
            ListNode exMidNode = null;

            // keep going through the list until we either skip into or over the last node.
            while (node != null && node.next != null)
            {
                exMidNode = exMidNode == null ? node : exMidNode.next;
                node = node.next.next;
            }

            // To get the actual middle of the list we take the next node and to ensure we actually split the list we set the reference of the (Mid-1).next node to null.
            var middleNode = exMidNode.next;
            exMidNode.next = null;

            return middleNode;
        }

        ListNode Merge(ListNode l1, ListNode l2)
        {
            // Let's declare fake head node to start 
            ListNode fakeHead = new ListNode();

            // and the current node
            ListNode current = fakeHead;

            // we need to keep going until we reach the end of the list 
            while (l1 != null && l2 != null)
            {
                // asc sorting
                if (l1.val < l2.val)
                {
                    current.next = l1;
                    l1 = l1.next;
                    current = current.next;
                }
                else
                {
                    current.next = l2;
                    l2 = l2.next;
                    current = current.next;
                }
            }


            current.next = l1 ?? l2;

            return fakeHead.next;
        }
    }
}
