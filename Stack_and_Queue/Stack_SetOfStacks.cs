using System;

namespace Stacks_SetOfStacks
{
    
    /* Implementation of SetOfStack with a popAt(int index) */
    public class Node
    {
        public Node above, below;
        public int value;

        public Node(int value)
        {
            this.value = value;
        }    
    }

    public class SetOfStacks
    {
        System.Collections.Generic.List<Stack> stacks = new System.Collections.Generic.List<Stack>();
        public int capacity;

        public SetOfStacks(int capacity)
        {
            this.capacity = capacity;
        }

        public Stack getLastStack()
        {
            if (stacks.Count == 0)
            {
                return null;
            }

            return stacks[stacks.Count - 1];
        }

        public void push(int v)
        {
            Stack last = getLastStack();
            if (last != null && !last.isFull())
            {
                // add to last stack
                last.push(v);
            }
            else
            {
                // must create new stack
                Stack stack = new Stack(capacity);
                stack.push(v);
                stacks.Add(stack);
            }
        }


        public int pop()
        {
            Stack last = getLastStack();
            if (last == null)
            {
                throw new Exception("Stack Empty Exception.");
            }
            int v = last.pop();
            if (last.size == 0)
            {
                stacks.RemoveAt(stacks.Count - 1);
            }

            return v;
        }

        public bool isEmpty()
        {
            Stack last = getLastStack();
            return last == null || last.isEmpty();
        }

        public int popAt(int index)
        {
            return leftShift(index, true);
        }

        public int leftShift(int index, bool removeTop)
        {
            Stack stack = stacks[index];
            int removed_item;
            if (removeTop)
            {
                removed_item = stack.pop();
            }
            else
            {
                removed_item = stack.removeBottom();
            }

            if (stack.isEmpty())
            {
                stacks.RemoveAt(index);
            }
            else if (stacks.Count > index + 1)
            {
                int v = leftShift(index + 1, false);
                stack.push(v);
            }

            return removed_item;
        }

        
    }

    public class Stack
    {
        private int capacity;
        public Node top, bottom;
        public int size = 0;

        public Stack(int capacity)
        {
            this.capacity = capacity;
        }

        public bool isFull()
        {
            return capacity == size;
        }

        public bool isEmpty()
        {
            return size == 0;
        }

        public void join(Node above, Node below)
        {
            if (below != null) below.above = above;
            if (above != null) above.below = above;
        }

        public bool push(int v)
        {
            if (size >= capacity)
            {
                return false;
            }
            size++;
            Node node = new Node(v);
            if (size == 1)
            {
                bottom = node;
            }

            join(node, top);
            top = node;
            return true;                
        }

        public int pop()
        {
            Node t = top;
            top = top.below;
            size--;
            return t.value;
        }

        public int removeBottom()
        {
            Node b = bottom;
            bottom = bottom.above;
            if (bottom != null)
            {
                bottom.below = null;
            }
            size--;
            return b.value;
        }
    }
}
