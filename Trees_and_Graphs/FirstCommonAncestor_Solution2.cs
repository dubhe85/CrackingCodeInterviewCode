// FirstCommonAncestor_Solution2
namespace Stacks_Create_Three_Stacks.Trees_and_Graphs
{
    class FirstCommonAncestor_Solution2
    {
        TreeNode CommonAncestor(TreeNode root, TreeNode p, TreeNode q)
        {
            /* Check if either node is not in the tree, or if one covers the other. */
            if (!Covers(root, p) || !Covers(root, q))
            {
                return null;
            }
            else if (Covers(p, q))
            {
                return p;
            }
            else if (Covers(q, p))
            {
                return q;
            }

            /* Traverse upwards until you find a node that covers q.*/
            TreeNode sibling = GetSibling(p);
            TreeNode parent = p.Parent;
            while (!Covers(sibling, q))
            {
                sibling = GetSibling(parent);
                parent = parent.Parent;
            
            }

            return parent;
        
        }


        bool Covers(TreeNode root, TreeNode p)
        {
            if (root == null) return false;
            if (root == p) return true;

            return Covers(root.Left, p) || Covers(root.Right, p);
        
        }

        TreeNode GetSibling(TreeNode node)
        {
            if (node == null || node.parent == null)
            {
                return null;
            }

            TreeNode parent = node.Parent;
            return parent.Left == node ? parent.Right :parent.Left;
        }
    }
}
