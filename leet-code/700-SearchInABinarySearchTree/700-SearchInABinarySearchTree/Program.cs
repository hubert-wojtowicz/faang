// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

var solver = new Solution();
solver.SearchBST()



public class TreeNode
{
    public int val;
    public TreeNode left;
    public TreeNode right;
    public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
    {
        this.val = val;
        this.left = left;
        this.right = right;
    }
}

public class Solution
{
    public TreeNode SearchBST(TreeNode root, int val)
    {
        if (root != null)
        {
            if (root.val == val) return root;
            SearchBST(root.left, val);
            SearchBST(root.right, val);
        }

        return null;
    }
}