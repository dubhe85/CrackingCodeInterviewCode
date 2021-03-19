using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stacks_Create_Three_Stacks.Trees_and_Graphs
{
    class CheckBinaryTreeIsBinarySearchTree
    {
        // Validate BST: Implement a function to check if a binary tree is a binary search tree.
        // Solution 1: In-Order traversal
        // Assuming the tree cannot have duplicate values

        // Seudo code:
        /*
            int index = 0;
            void copyBST(TreeNode root, int[] array)
            {
                if (root == null)
                {
                    return;
                }

                copyBST(root.left, array);
                array[index] = root.data;
                index++;

                copyBST(root.right, array)
        
            }

        bool checkBST(TreeNode root)
        {
            int[] array = new int[root.size];

            copyBST(root, array);
            for (int i = 1; i < array.lenght; i++)
            {
                if (array[i] <= array[i - 1])
                {
                    return false;
                }
            }
            return true;
        }
        */

        int? lastPrinted = null;
        bool checkBST(TreeNode node)
        {
            if (node == null) return true;

            // Check / recurse left
            if (!checkBST(node.Left)) return false;

            // Check current
            if (lastPrinted.HasValue && node.Value < lastPrinted)
            {
                return false;
            }

            lastPrinted = node.Value;

            // Check / recurse right
            if (!checkBST(node.Right)) return false;

            return true; //  all good.           
        }

        // Solution 2: The Min/Max solution
        public bool checkBST_Solution2(TreeNode node)
        {
            return checkBST_Solution2(node, null, null);
        }

        private bool checkBST_Solution2(TreeNode node, int? min, int? max)
        {

            if (node == null)
            {
                return true;
            }

            if ((min.HasValue && node.Value <= min.Value) || (max.HasValue && node.Value > max.Value))
            {
                return false;
            }

            if (!checkBST_Solution2(node.Left, min, node.Value) || !checkBST_Solution2(node.Right, node.Value, max))
            {
                return false;
            }

            return true;
        }
    }
}
