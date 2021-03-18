class ListOfDepths_BinaryTree
    {

        public void createLevelLinkedList(TreeNode root, List<LinkedList<TreeNode>> lists, int level)
        {

            if (root == null) return; // base case

            LinkedList<TreeNode> list = null;
            if (lists.Count == level)
            {
                // Level not contained in list
                list = new LinkedList<TreeNode>();

                /* Levels are always traversed in order. So, if this is the first time we've
                    visited level i, we must have seen levels 0 through i - 1. We can
                    therefore safely add the level at the end.
                */
                lists.Add(list);
            }
            else 
            {
                list = lists.ElementAt(level);
            }

            list.AddLast(root);
            createLevelLinkedList(root.Left, lists, level + 1);
            createLevelLinkedList(root.Right, lists, level + 1);
        }

        public List<LinkedList<TreeNode>> createLevelLinkedList(TreeNode root)
        {
            List<LinkedList<TreeNode>> lists = new List<LinkedList<TreeNode>>();
            createLevelLinkedList(root, lists, 0);
            return lists;
        }
    }
