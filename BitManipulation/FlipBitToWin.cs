using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrackingCodeInterviewSample.BitManipulation
{
    // Description: 
    // Flip Bit to Win: You have an integer and you can flip exactly one bit from a 0 to 1.
    // Write code to find the length of the longest sequence of 1s you could create.
    class FlipBitToWin
    {
        const int BYTES = 4;
        public int longestSequence(int n)
        {
            if (n == -1) return BYTES;
            List<int> sequences = getAlternatingSequences(n);
            return findLongestSequence(sequences);
        }

        /* Return a list of the sizes of the sequences. The sequence starts off with the
         * number of 0s (which might be 0) and then alternates with the counts of each value.         
        */
        private List<int> getAlternatingSequences(int n)
        {
            List<int> sequences = new List<int>();

            int searchingFor = 0;
            int counter = 0;

            for (int i = 0; i < BYTES * 8; i++)
            {
                if ((n & 1) != searchingFor)
                {
                    sequences.Add(counter);
                    searchingFor = n & 1; // Flip 1 to 0 or 0 to 1
                    counter = 0;
                }

                counter++;
                n >>= 1;            
            }

            sequences.Add(counter);

            return sequences;
        }

        /* Given the lengths of alternating sequences of 0s and 1s, find the longest one 
         we can build. */
        int findLongestSequence(List<int> seq)
        {
            int maxSeq = 1;

            for (int i = 0; i < seq.Count; i += 2)
            {
                int zerosSeq = seq[i];
                int onesSeqPrev = i - 1 >= 0 ? seq[i - 1] : 0;
                int onesSeqNext = i + 1 < seq.Count ? seq[i + 1] : 0;

                int thisSeq = 0;
                if (zerosSeq == 1)
                {
                    // Can merge
                    thisSeq = onesSeqNext + 1 + onesSeqPrev;

                }
                else if (zerosSeq > 1)
                {
                    // Just add a one to either side
                    thisSeq = 1 + Math.Max(onesSeqPrev, onesSeqNext);

                }
                else if (zerosSeq == 0)
                {
                    //No zero, but take either side
                    thisSeq = Math.Max(onesSeqPrev, onesSeqNext);
                }
            }

            return maxSeq;        
        }


        public int flipBit(int a)
        {
            /* If all 1s, this is already the longest sequence. */
            if (~a == 0) return BYTES * 8;

            int currentLength = 0;
            int previousLength = 0;
            int maxLength = 1; // We can always have a sequence of at least one 1

            while (a != 0)
            {
                if ((a & 1) == 1)
                {
                    // Current bit is a 1
                    currentLength++;

                }
                else if ((a & 1) == 0)
                {
                    // Current bit is a 0
                    /* Update to 0 (if next bit is 0) or currentLength (if next bit is 1). */
                    previousLength = (a & 2) == 0 ? 0 : currentLength;
                    currentLength = 0;
                }

                maxLength = Math.Max(previousLength + currentLength + 1, maxLength);
                a >>= 1;
            }

            return maxLength;        
        }
    }


}
