using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrackingCodeInterviewSample.BitManipulation
{
    /*
    Conversion:
    Write a function to determine the number of bits you would need to flip to 
    convert integer A to integer B.
     
    */
    class ConversionOfOneNumberIntoAnother
    {

        public int bitSwapRequired(int a, int b)
        {
            int count = 0;
            int c = a ^ b;

            while (c != 0)
            {
                count += c & 1; // Increment count if c ends with 1
                c >>= 1; // Shift right by 1
            }

            return count;
        }

        public int bitSwapRequiredSmarterWay(int a, int b)
        {
            int count = 0;
            int c = a ^ b;

            while (c != 0)
            {
                c = c & (c - 1);
                count++;
            }

            return count++;
        }
    }
}
