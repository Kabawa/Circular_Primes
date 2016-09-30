using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace simple_numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            var resParse = false;
            int range = 0;
            while (!resParse || range < 0)
            {
                Console.WriteLine("Enter a range of numbers:");

                resParse = Int32.TryParse(Console.ReadLine(), out range);
                if (!resParse || range < 0)
                { Console.WriteLine("Error, Try again"); }
            }
            
            int count = CircularPrimes.ESieve(range);

            Console.WriteLine("Number of circular primes is " + count);
            Console.ReadLine();
        }
    }
}
