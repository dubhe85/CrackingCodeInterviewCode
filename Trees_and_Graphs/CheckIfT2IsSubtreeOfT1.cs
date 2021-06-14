using Stacks_Create_Three_Stacks.Trees_and_Graphs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrackingCodeInterviewSample.Trees_and_Graphs
{
     /*Problem: 
      * Check Subtree: 
      *  T1 and T2 are two very large binariy trees, with T1 much bigger than T2. Create an algorithm to determine
      *  if T2 is a subtree of T1.
     */
    class CheckIfT2IsSubtreeOfT1
    {
        #region First Solution

        /*
        // Solution takes O(n*m) where n and m are number of nodes in T1 and T2 */
        bool containsTree(TreeNode t1, TreeNode t2)
        {
            StringBuilder string1 = new StringBuilder();
            StringBuilder string2 = new StringBuilder();

            getOrderString(t1, string1);
            getOrderString(t2, string2);

            return string1.ToString().IndexOf(string2.ToString()) != -1;
        }

        void getOrderString(TreeNode node, StringBuilder sb)
        {
            if (node == null)
            {
                sb.Append("X");   // Add null indicator
                return;
            }

            sb.Append(node.Value + " "); // Add root
            getOrderString(node.left, sb); // Add left
            getOrderString(node.right, sb); // Add right

        }
        */
        #endregion


        #region Second solution -- most optimal

        bool containsTree(TreeNode t1, TreeNode t2)
        {
            if (t2 == null)
            {
                return true;
            }

            return subTree(t1, t2);        
        }

        private bool subTree(TreeNode r1, TreeNode r2)
        {
            if (r1 == null)
            {
                return false; // big tree empty & subtree still not found

            }
            else if (r1.Value == r2.Value && matchTree(r1, r2))
            {
                return true;
            }

            return subTree(r1.Left, r2) || subTree(r1.Right, r2);
        }

        private bool matchTree(TreeNode r1, TreeNode r2)
        {
            if (r1 == null && r2 == null)
            {
                return true; // nothing left in subtree
            }
            else if (r1 == null || r2 == null)
            {
                return false; // exactly one tree is empty, therefore trees don't match 
            }
            else if (r1.Value != r2.Value)
            {
                return false; // data doesn't match
            }
            else
                return matchTree(r1.Left, r2.Left) && matchTree(r1.Right, r2.Right);
        }


        #endregion


    }
}
