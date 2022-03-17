// See https://aka.ms/new-console-template for more information

var solver = new Solution();
Console.WriteLine(solver.MaxPathSum(TreeNode.CreateTree(new int?[] { -10, 9, 20, null, null, 15, 7 })));
Console.WriteLine(solver.MaxPathSum(TreeNode.CreateTree(new int?[] { -1, -1, 100, -1, -1, -1, -1 })));
Console.WriteLine(solver.MaxPathSum(TreeNode.CreateTree(new int?[] { -3 })));

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

    public static TreeNode CreateTree(int?[] vals, int rootArrayPosition = 1)
    {
        if (rootArrayPosition > vals.Length || !vals[rootArrayPosition - 1].HasValue) return null;

        return new TreeNode(vals[rootArrayPosition - 1].Value, CreateTree(vals, rootArrayPosition * 2), CreateTree(vals, rootArrayPosition * 2 + 1));
    }
}

public class Solution
{
    public int MaxGainGlobal { get; set; }

    public int MaxPathSum(TreeNode root)
    {
        MaxGainGlobal = int.MinValue;
        MaxGain(root);
        return MaxGainGlobal;
    }
    private int MaxGain(TreeNode root)
    {
        if (root == null) return 0;

        // 0 below means we ignore this path
        // we need to guarantee on node will be taken if all have negative value
        var leftSubthree = Math.Max(MaxGain(root.left), 0); 
        var rightSubthree = Math.Max(MaxGain(root.right), 0);

        // both subthrees creates path with "peak" in current root
        MaxGainGlobal = Math.Max(MaxGainGlobal, root.val + leftSubthree + rightSubthree);

        // here we guarante we will tak at least one if all have negative values
        // continue path
        return root.val + Math.Max(leftSubthree, rightSubthree);
    }
}