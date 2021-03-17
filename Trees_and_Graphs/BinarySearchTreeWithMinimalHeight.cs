namespace Stacks_Create_Three_Stacks.Trees_and_Graphs
{
    /*
    BinarySearchTreeWithMinimalHeight BinarySearchTreeWithMinimalHeight = new BinarySearchTreeWithMinimalHeight();

    int[] arrayItems = new int[] { 1, 2, 3, 4, 5, 6 };
    BinarySearchTreeWithMinimalHeight.createMinimalBST(arrayItems); 
         
    */

    class TreeNode
    {
        public int Value;

        public TreeNode Left;
        public TreeNode Right;

        public TreeNode(int _value)
        {
            Value = _value;
        }
    }

    class BinarySearchTreeWithMinimalHeight
    {
        public TreeNode createMinimalBST(int[] array)
        {
            return createMinimalBST(array, 0, array.Length - 1);
        }

        private TreeNode createMinimalBST(int[] array, int start, int end)
        {

            if (end < start)
            {
                return null;
            }

            int mid = (start + end) / 2;
            TreeNode node = new TreeNode(array[mid]);
            node.Left = createMinimalBST(array, start, mid - 1);
            node.Right = createMinimalBST(array, mid + 1, end);

            return node;
        }
    }
}
