using System;
using System.Runtime.InteropServices;

namespace Stacks_Create_Three_Stacks.Trees_and_Graphs
{

    // Solution 1: With Links to Parents
    class FirstCommonAncestor_Solution1
    {
        public TreeNode CommonAncestor(TreeNode p, TreeNode q)
        {
            // get difference in depths
            int delta = Depth(p) - Depth(q);
            TreeNode first = delta > 0 ? q : p; //get shallower node
            TreeNode second = delta > 0 ? p : q; // get deeeper node
            second = GoUpBy(second, Math.Abs(delta)); // move deeper node up

            /* Find where paths intersect */
            while (first != second && first != null && second != null)
            {
                first = first.Parent;
                second = second.Parent;
            
            }

            return first == null || second == null ? null : first;
        }

        public TreeNode GoUpBy(TreeNode node, int delta)
        {
            while (delta > 0 && node != null)
            {
                node = node.Parent;
                delta--;
            }

            return node;
        }

        int depth(TreeNode node)
        {
            int depth = 0;
            while (node.Parent != null)
            {
                depth++;
                node = node.Parent;
            }

            return depth;
        }
    }
}
