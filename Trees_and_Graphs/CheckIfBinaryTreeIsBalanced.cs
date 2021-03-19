using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace Stacks_Create_Three_Stacks.Trees_and_Graphs
{
    class CheckBinaryTree_IsBalanced
    {
        public int getHeight(TreeNode root)
        {
            if (root == null)
            {
                return -1;
            }

            return Math.Max(getHeight(root.Left), getHeight(root.Right));
        }

        public bool isBalanced(TreeNode root)
        {
            if (root == null)
            {
                // base case
                return true;
            }

            int heightDiff = getHeight(root.Left) - getHeight(root.Right);
            if (Math.Abs(heightDiff) > 1)
            {
                return false;
            }
            else
            {
                return isBalanced(root.Left) && isBalanced(root.Right);
            }
        }

        public int checkHeight(TreeNode root)
        {
            if (root == null)
            {
                return -1;
            }

            int leftHeight = checkHeight(root.Left);
            if (leftHeight == int.MinValue)
            {
                return int.MinValue;
                // Pass error up
            }

            int rightHeight = checkHeight(root.Right);
            if (rightHeight == int.MinValue)
            {
                return int.MinValue;
                // Pass error up
            }

            int heightDiff = leftHeight - rightHeight;
            if (Math.Abs(heightDiff) > 1)
            {
                return int.MinValue; // Found error -> pass it back
            }
            else 
            {
                return Math.Max(leftHeight, rightHeight) + 1;
            }
        }

        public bool isBalancedNotRecursively(TreeNode root)
        {
            return checkHeight(root) != int.MinValue;
        }
    }
}
