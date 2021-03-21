namespace Stacks_Create_Three_Stacks.Trees_and_Graphs
{
    class FirstCommonAncestor_Solution3
    {
        TreeNode CommonAncestor(TreeNode root, TreeNode p, TreeNode q)
        {
            /* Error check - one node is not in the tree. */
            if (!Covers(root, p) || !Covers(root, q))
            {
                return null;
            }

            return AncestorHelper(root, p, q);
        }


        TreeNode AncestorHelper(TreeNode root, TreeNode p, TreeNode q)
        {
            if (root == null || root == p || root == q)
            {
                return root;
            }

            bool pIsOnLeft = Covers(root.Left, p);
            bool qIsOnLeft = Covers(root.Left, q);

            if (pIsOnLeft != qIsOnLeft)
            {
                // nodes are in different side
                return root;            
            }

            TreeNode childSide = pIsOnLeft ? root.Left : root.Right;
            return AncestorHelper(childSide, p, q);
        }

        bool Covers(TreeNode root, TreeNode p)
        {
            if (root == null) return false;
            if (root == p) return true;

            return Covers(root.Left, p) || Covers(root.Right, p);
        }
    }
}
