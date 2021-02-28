using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Markup;

namespace Stacks_Create_Three_Stacks
{
    /// <summary>
    ///  Problem 3.1:
    ///  Three in one: Describe how you could use a single array to implement three stacks.
    /// </summary>

    public class MultiStack
    {
        /* StackInfo is a simple class that holds a set of data about each stack. It does not hold the 
           actual items in the stack. We could have done this with just a bunch of individual variables,
           but that's messy and doesn't gain us much.*/
        private class StackInfo
        {
            public int start, size, capacity;
            public MultiStack outerMultiStackInfo;
            public StackInfo(int start, int capacity, MultiStack outerMultiStackInfo)
            {
                this.start = start;
                this.capacity = capacity;
                this.outerMultiStackInfo = outerMultiStackInfo;
            }



            /* Check if an index of the full array is within the stack boundaries.The stack can wrap around
            to the start of the array.*/
            public bool isWithinStackCapacity(int index)
            {

                /* If outside of bounds of array, return false. */
                if (index < 0 || index > outerMultiStackInfo.values.Length)
                {
                    return false;
                }

                /* If index wraps around, adjust it. */
                int contiguousIndex = index < start ? index + outerMultiStackInfo.values.Length : index;
                int end = start + capacity;
                return start <= contiguousIndex && contiguousIndex <= end;
            }

            public int lastCapacityIndex()
            {
                return outerMultiStackInfo.adjustIndex(start + capacity - 1);
            }

            public int lastElementIndex()
            {
                return outerMultiStackInfo.adjustIndex(start + size - 1);
            }

            public bool isFull()
            {
                return size == capacity;
            }

            public bool isEmpty()
            {
                return size == 0;
            }
        }

        private StackInfo[] info;
        internal int[] values;

        public MultiStack(int numberOfStacks, int defaultSize)
        {
            /* Create metada for all the stacks. */
            info = new StackInfo[numberOfStacks];
            for (int i = 0; i < numberOfStacks; i++)
            {
                info[i] = new StackInfo(defaultSize * i, defaultSize, this);
            }

            values = new int[numberOfStacks * defaultSize];

        }

        /* Push value onto stack num, shifting/expanding stacks as necessary. 
           Throws exception if all stacks are full.
        */
        public void push(int stackNum, int value)
        {
            if (allStacksAreFull())
            {
                throw new Exception("Ful Stack Exception");
            }

            /* If this stack is full, expand it. */
            StackInfo stackInfo = info[stackNum];

            if (stackInfo.isFull())
            {
                expand(stackNum);
            }

        }


        /* Expand stack by shifting  over other stacks */
        public void expand(int stackNum)
        {
            shift((stackNum + 1) % info.Length);
            info[stackNum].capacity++;
        }

        public bool allStacksAreFull()
        {
            return numberOfElements() == values.Length;
        }

        public int numberOfElements()
        {
            int _numberOfElements = 0;

            for (int i = 0; i < info.Length; i++)
            {
                _numberOfElements += info[i].size;
            }

            return _numberOfElements;
        }

        /* Shift items in stack over by one element. If we have available capacity, then we'll end up 
           shrinking the stack the stack by one element. If we don't have available capacity, then we'll need
           to shift  the next stack over too.*/
        private void shift(int stackNum)
        {
            Console.WriteLine("/// Shifting " + stackNum);
            StackInfo stackInfo = info[stackNum];

            /* If this stack is at its full capacity, then you need to move the next stack over
               by one element. This stack can now claim the free index.    */
            if (stackInfo.size >= stackInfo.capacity)
            {
                int nextStack = (stackNum + 1) % info.Length;
                shift(nextStack);
                stackInfo.capacity++;
            }

            /* Shift all elements in stack over by one. */
            int index = stackInfo.lastCapacityIndex();
            while (stackInfo.isWithinStackCapacity(index))
            {
                values[index] = values[previousIndex(index)];
                index = previousIndex(index);
            }

            /* Adjust stack data. */
            values[stackInfo.start] = 0; // Clear item
            stackInfo.start = nextIndex(stackInfo.start); // move start
            stackInfo.capacity--; // Shrink capacity
        }


        /* Adjust index to be within the range of 0 -> length -1. */
        public int adjustIndex(int index)
        {
            int max = values.Length;
            return ((index % max) + max) % max;
        }

        /*  Get index after this index, adjusted for wrap around. */
        private int nextIndex(int index)
        {
            return adjustIndex(index + 1);
        }

        /* Get index before this index, adujsted for wrap around. */
        public int previousIndex(int index)
        {
            return adjustIndex(index - 1);
        }
    }
}
