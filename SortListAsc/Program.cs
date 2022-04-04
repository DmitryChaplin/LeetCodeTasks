using SortListAsc;
Action<ListNode, string> writeOutput = (h, s) =>
{
    Console.Write(s);
    while (h != null)
    {
        Console.Write(h.val);
        h = h.next;
    }
    Console.WriteLine();
};
var head = new ListNode(-1, new ListNode(5, new ListNode(3, new ListNode(4, new ListNode(0)))));
writeOutput(head, "Original list: ");
writeOutput(new Solution().SortList(head), "SortedList: ");
Console.ReadKey();
