using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrackingCodeInterviewSample.Trees_and_Graphs
{
    // Random Node:
    // You are implementing a binary search tree class from scratch, which, in addition to
    // insert, find, and delete, has a method getRandomNode() which return a random node from the tree.
    // All nodes should be equally likely to be chosen. Design and implement an algorithm  for getRandomNode()
    // and explain how would you implement the rest of the methods.

    class TreeNode1
    {
        private int data;
        public TreeNode1 left;
        public TreeNode1 right;
        private int size = 0;

        public TreeNode1(int d)
        {
            data = d;
            size = 1;
        }

        public int Size() { return size; }
        public int Data() { return data; }
        

        public TreeNode1 getRandomNode()
        {
            int leftSize = left == null ? 0 : left.Size();
            Random random = new Random();
            int index = random.Next();
            if (index < leftSize)
            {
                return left.getRandomNode();
            }
            else if (index == leftSize)
            {
                return this;
            }
            else
            {
                return right.getRandomNode();
            }
        }

        public void insertInOrder(int d)
        {
            if (d <= data)
            {
                if (left == null)
                {
                    left = new TreeNode1(d);
                }
                else
                {
                    left.insertInOrder(d);
                }
            }
            else 
            {
                if (right == null)
                {
                    right = new TreeNode1(d);
                }
                else
                {
                    right.insertInOrder(d);
                }
            }

            size++;        
        }

        public TreeNode1 find(int d)
        {
            if (d == data)
            {
                return this;
            }
            else if (d <= data)
            {
                return left != null ? left.find(d) : null;
            }
            else if (d > data)
            {
                return right != null ? right.find(d) : null;
            }

            return null;
        }


        

    }

    #region First Solution
    class FindRandomNode
    {
        
    }

    #endregion 
}
