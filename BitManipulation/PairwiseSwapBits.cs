using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrackingCodeInterviewSample.BitManipulation
{
    /*
        Description:
        Pairwise Swap: Write a program to swap odd and even bits in an integer with as few instructions as
        possible (e.g., bit 0 and bit 1 are swapped, bit 2 and bit 3 are swapped, and so on).
    */
    class PairwiseSwapBits
    {
        public int swapOddEvenBits(int x)
        {
            uint maskAllOddBits = 0xaaaaaaaa;
            int allOddBitsMaskedResult = (int)(x & maskAllOddBits);

            uint maskAllEvenBits = 0x55555555;
            int allEvenBitsMaskedResult = (int)(x & maskAllEvenBits);

            return ( (allOddBitsMaskedResult >> 1) | (allEvenBitsMaskedResult << 1) );
        }

    }
}
