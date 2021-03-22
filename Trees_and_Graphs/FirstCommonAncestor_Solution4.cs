using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stacks_Create_Three_Stacks.Trees_and_Graphs
{
    class Result
    {
        public TreeNode node;
        public bool isAncestor;

        public Result(TreeNode n, bool _isAncestor)
        {
            node = n;
            isAncestor = _isAncestor;
        }
    }

    class FirstCommonAncestor_Solution4
    {
        public TreeNode CommonAncestor(TreeNode root, TreeNode p, TreeNode q)
        {
            Result r = CommonAncestorHelper(root, p, q);

            if (r.isAncestor)
            {
                return r.node;
            }

            return null;
        }

        public Result CommonAncestorHelper(TreeNode root, TreeNode p, TreeNode q)
        {

            if (root == null) return new Result(null, false);

            if (root == p && root == q)
            {
                return new Result(root, true);
            }

            Result rx = CommonAncestorHelper(root.Left, p, q);
            if (rx.isAncestor)
            {
                // Found common ancestor
                return rx;
            }

            Result ry = CommonAncestorHelper(root.Right, p, q);
            if (ry.isAncestor)
            {
                // Found common ancestor
                return ry;
            }

            if (rx.node != null && ry.node != null)
            {
                return new Result(root, true); // This is the common ancestor
            }
            else if (root == p || root == q)
            {
                /* If we are  currently at p or q, and we also found one of those nodes in a 
                 * subtree, then this is truly an ancestor and the flag should be true.
                 * */
                bool isAncestor = rx.node != null || ry.node != null;
                return new Result(root, isAncestor);
            }
            else
            {
                return new Result(rx.node != null ? rx.node : ry.node, false);
            }
        }

    }
}
