using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrackingCodeInterviewSample.Math_LogicPuzzles
{
    class PrimeNumbersImplementation
    {

        public bool primeNaive(int n)
        {
            if (n < 2)
            {
                return false;
            }

            for (int i = 0; i < n; i++)
            {
                if (n % i == 0)
                {
                    return false;
                }
            }

            return true;
        }

        public bool primeSlightlyBetter(int n)
        {
            if (n < 2)
            {
                return false;
            }

            int sqrt = (int)Math.Sqrt(n);
            for (int i = 0; i < sqrt; i++)
            {
                if (n % i == 0)
                {
                    return false;
                }
            }

            return true;
        }

        // Sieve of Eratosthenes
        bool[] sieveOfEratosthenes(int max)
        {

            bool[] flags = new bool[max + 1];
            
            init(flags); // Set all flags to true other than 0 and 1
            int prime = 2;

            while (prime <= Math.Sqrt(max))
            {
                /* Cross off remaining multiples of prime */
                crossOff(flags, prime);

                /* Find next value which is true */
                prime = getNextPrime(flags, prime);
            }

            return flags;
        }

        private int getNextPrime(bool[] flags, int prime)
        {
            int next = prime + 1;
            while (next < flags.Length && !flags[next])
            {
                next++;
            }

            return next;
        }

        private void crossOff(bool[] flags, int prime)
        {
            /*
                Cross off remaining multiples of prime. We can start with (prime*prime),
                because if we have a k * prime, where k < prime, this value would have
                already been crossed off in a prior iteration.
            */
            for (int i = prime; i < flags.Length; i += prime)
            {
                flags[i] = false;            
            }
        }

        private void init(bool[] flags)
        {
            throw new NotImplementedException();
        }
    }
}
