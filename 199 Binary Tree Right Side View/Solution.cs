
public class Solution
{
    public IList<int> RightSideView(TreeNode root)
    {
        // haven't finished this task yet, new internal project came up
        // the idea is to traverse tree from the right side first, checking the current level/count, 
        // with endlist priority looking like this :
        // rightSubtree[rightNode], rightSubtree[leftNode], leftsubtree[rightNode], leftSubtree[leftNode]
        // if we already have an item in a list at a current level/index, skip
        var list = new List<int>();
        TraverseRight(root, list, 0);

        return list;
    }

    void TraverseRight(TreeNode node, List<int> list, int level)
    {
        if (node != null)
        {
            // we can only have 1 value selected at any given 'level, hence let's check if we already visited this 'level'
            if (level > list.Count())
            {

            }

            // if we have a right node in a current subtree
            if (node.right != null)
            {
                list.Add(node.val);
                TraverseRight(node.right, list, level);
            }
            
            if (node.left != null)
        }
    }
}