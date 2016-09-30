using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace simple_numbers
{
    public class CircularPrimes
    {
        private static SortedSet<int> _primes { get; set; }

        private static int CheckCircularPrimes(int prime)
        {
            int multiplier = 1;
            int number = prime;
            int count = 0;
            int d;

            //Count the digits and check for even numbers
            while (number > 0)
            {
                d = number % 10;
                if (d % 2 == 0 || d == 5)
                {
                    _primes.Remove(prime);
                    return 0;
                }
                number /= 10;
                multiplier *= 10;
                count++;
            }
            multiplier /= 10;

            //Rotate the number and check if they are prime
            number = prime;
            List<int> foundCircularPrimes = new List<int>();

            for (int i = 0; i < count; i++)
            {
                if (_primes.Contains(number))
                {
                    foundCircularPrimes.Add(number);
                    _primes.Remove(number);
                }
                else if (!foundCircularPrimes.Contains(number))
                {
                    return 0;
                }

                d = number % 10;
                number = d * multiplier + number / 10;
            }
            return foundCircularPrimes.Count;
        }

        public static int ESieve(int n)
        {
            var list = new List<int>();
            var res = new SortedSet<int>();
            for (int i = 0; i <= n; i++)
            {
                list.Add(i);
            }

            int k = 2;

            while (k <= n)
            {
                if (list[k] != 0)
                {
                    res.Add(list[k]);

                    for (int i = k; i <= n; i += k)
                    {
                        list[i] = 0;
                    }
                }
                k += 1;
            }

            _primes = res;

            //special cases
            int count = 0;
            if (n == 0 || n == 1) {count = 0;}
            if (n == 2 || n == 3 || n==4) {count = 1;}
            if (n == 5 || n == 6) {count = 3;}
            if (n > 6){count = 2;}
            //
            CheckCircularPrimes(_primes.Count);

            while (_primes.Count > 0)
            {
                count += CheckCircularPrimes(_primes.Min);
            }
            return count;
        }
    }
}
