using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrackingCodeInterviewSample.Math_LogicPuzzles
{
    class TheApocalypse
    {

        public double runNFamilies(int n)
        {
            int boys = 0;
            int girls = 0;

            for (int i = 0; i < n; i++)
            {
                int[] genders = runOneFamily();
                girls += genders[0];
                boys += genders[1];
            }

            return girls / (double)(boys + girls);
        }

        private int[] runOneFamily()
        {
            Random random = new Random();
            int boys = 0;
            int girls = 0;

            while (girls == 0) // until we get a girl
            {
                if (random.Next() % 2 == 0) // girl
                {
                    girls += 1;
                }
                else // boy 
                {
                    boys += 1;
                }
            }

            int[] genders = { girls, boys };
            return genders;
        }
    }
}
