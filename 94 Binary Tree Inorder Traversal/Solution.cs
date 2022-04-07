public class Solution
{
    // inorder: traverse left (recursively), visit current, traverse right (recursively)

    public IList<int> InorderTraversal(TreeNode root)
    {
        // declare the resulting list
        var result = new List<int>();
        // our recursive function
        TraverseAndAdd(root, result);
        return result;
    }

    private void TraverseAndAdd(TreeNode node, IList<int> list)
    {
        if (node != null)
        {
            TraverseAndAdd(node.left, list);
            list.Add(node.val);
            TraverseAndAdd(node.right, list);
        }
    }
}