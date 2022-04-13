public class Solution
{
    // Alright, I ended up looking up algo for this problem
    // The whole idea here, is that preorder follows [root->left->right] order and inorder [left->root->right] paths.
    // Hence, we essentially can iterate through the preorder array, treating current value at the (current_preorder_index) as a root for a subtree
    // and the left subtree would be 0...index_of_root_value_elemnt_in_inOrder
    // while the right subtree will always be index_of_root_value_elemnt_in_inOrder...inorder.Length -1
    public TreeNode BuildTree(int[] preorder, int[] inorder)
    {
        // value : index, for faster lookup. only works if values in the tree are unique
        var inorderDict = new Dictionary<int, int>();
        for (int i = 0; i < inorder.Length; i++)
        {
            inorderDict.Add(inorder[i], i);
        }

        // since first element of preorder is the root, let's keep going until we reach the last node in preorder
        return ConstructTree(preorder, inorderDict, 0, preorder.Length - 1);
    }

    private int PreorderIndex = 0;

    TreeNode ConstructTree(int[] preorder, Dictionary<int, int> inorderDict, int left, int right)
    {
        // if we don't have any more elements to construct a tree
        if (left > right)
            return null;

        // find the root value and increment it
        int rootValue = preorder[PreorderIndex++];
        var root = new TreeNode(rootValue);

        // let's build the left/right subtrees, excluding the inOrder value, because it's the root
        root.left = ConstructTree(preorder, inorderDict, left, inorderDict[rootValue] - 1);
        root.right = ConstructTree(preorder, inorderDict, inorderDict[rootValue] + 1, right);
        return root;
    }
}