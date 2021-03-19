namespace Stacks_Create_Three_Stacks.Trees_and_Graphs
{
    public class TreeNodeWithParent
    {
        public TreeNodeWithParent(int _value, TreeNodeWithParent parent)
        {
            Value = _value;
            Parent = parent;
        }

        public int Value;

        public TreeNodeWithParent Left;
        public TreeNodeWithParent Right;

        
        public TreeNodeWithParent Parent { get; set; }
    }

    class FindNextNode_InOrderSuccessor
    {

        public TreeNodeWithParent leftMostChild(TreeNodeWithParent node)
        {

            if (node == null)
            {
                return null;
            }

            while (node.Left != null)
            {
                node = node.Left;
            }

            return node;
        }

        public TreeNodeWithParent inOrderSuccesor(TreeNodeWithParent node)
        {
            if (node == null)
            {
                return null;
            }

            /* Found right children -> return leftmost node of right subtree */
            if (node.Right != null)
            {
                return leftMostChild(node.Right);
            }
            else
            {
                TreeNodeWithParent q = node;
                TreeNodeWithParent x = q.Parent;

                // Go up until we're on left instead of right
                while (x != null && x.Left != q)
                {
                    q = x;
                    x = x.Parent;
                }

                return x;
            }
        
        }
    }
}
