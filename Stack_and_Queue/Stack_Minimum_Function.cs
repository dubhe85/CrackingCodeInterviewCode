using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stacks_With_Function_Min
{
    class NodeWithMin
    {
        public int value;
        public int min;

        public NodeWithMin(int v, int min)
        {
            value = v;
            this.min = min;
        }
    }
        

    class StackWithMin : Stack<NodeWithMin>
    {

        public void push(int value)
        {
            int newMin = Math.Min(value, min());
            this.Push(new NodeWithMin(value, newMin));
        
        }


        public int min()
        {
            if (this.Count == 0)
            {
                return int.MaxValue;
            }
            else
            {
                return Peek().min;
            }
        }
    }

    class StackWithMin2 : Stack<int>
    {

        Stack<int> minimunStack;

        public StackWithMin2()
        {
            minimunStack = new Stack<int>();
        }

        public void push(int value)
        {
            if (value <= min())
            {
                minimunStack.Push(value);
            }

            this.Push(value);
        }

        public int Pop()
        {
            int value = this.Pop();

            if (value == min())
            {
                minimunStack.Pop();
            }
            
            return value;
        }

        public int min()
        {
            if (this.Count == 0)
            {
                return int.MaxValue;
            }
            else
            {
                return minimunStack.Peek();
            }
        }
    }
}      
