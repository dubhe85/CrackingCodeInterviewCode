using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrackingCodeInterviewSample.BitManipulation
{
    // C# program to Binary real number to String.
    // Class Reperesentation of Binary real number to String

    class DoubleBetween0And1PrintBinaryRepresentation
    {

        public static string printBinary(double num)
        {
            if (num >= 1 || num <= 0)
            {
                return "ERROR";
            }

            StringBuilder binary = new StringBuilder();
            binary.Append(".");

            while (num > 0)
            {
                /* Setting a limit on length: 32 characters */
                if (binary.Length > 32)
                {
                    return "ERROR";
                }

                double r = num * 2;
                if (r >= 1)
                {
                    binary.Append(1);
                    num = r - 1;
                }
                else
                {
                    binary.Append(0);
                    num = r;
                }
            }

            return binary.ToString();
        }

    }
}
