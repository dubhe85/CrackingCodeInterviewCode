// Sample code of binary tree traversal.

namespace Stacks_Create_Three_Stacks.Trees_and_Graphs
{
    // sample of Tree Node
    class Node
    {
        public string Name;
        public Node[] children;
    }

    class Tree
    {
        public Node root;
    }

    // Binary Tree Traversal
    // Prior to your interview, you should be comfortable implementing in-order, post-order, and pre-order traversal.
    // The most common of these is in-order traversal.

    class TreeNode
    {
        public TreeNode left;
        public TreeNode right;
    }

    class BinaryTreeTraversal
    {

        public static void visit(TreeNode node)
        { }

        // In-Order traversal
        // In-order traversal means to "visit" (often, print) the left branch, then the current node, and finally, the right
        // branch.
        public static void InOrderTraversal(TreeNode node)
        {
            if (node != null)
            {
                InOrderTraversal(node.left);
                visit(node);
                InOrderTraversal(node.right);
            }
        }

        // Pre-Order traversal
        // Pre-order traversal visits the current node before its child node (hence the name "pre-order")
        public void PreOrderTraversal(TreeNode node)
        {
            if (node != null)
            {
                visit(node);
                PreOrderTraversal(node.left);
                PreOrderTraversal(node.right);
            }
        }

        // Post-Order Traversal
        // Post-Order traversal visits the current node after its child nodes (hence the name "post-order")
        public void PostOrderTraversal(TreeNode node)
        {
            if (node != null)
            {
                PostOrderTraversal(node.left);
                PostOrderTraversal(node.right);
                visit(node);            
            }
        }
    }
}

