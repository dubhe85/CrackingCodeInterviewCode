using System;
using System.Collections.Generic;

namespace Stacks_Create_Three_Stacks
{
    class Stack_SortStack_SmallestItems_On_Top
    {

        public void sort(Stack<int> stack)
        {
            Stack<int> r = new Stack<int>();

            while (stack.Count != 0)
            {
                /* Insert each element in stack in sorted order into r */
                int temp = stack.Pop();
                while (r.Count != 0 && r.Peek() > temp)
                {
                    int greaterItem = r.Pop();
                    stack.Push(greaterItem);
                }

                r.Push(temp);
            }

            /* Copy the elements from r back into stack.  */
            while (r.Count != 0)
            {
                stack.Push(r.Pop());
            }
        
        }
    }
}
