using CompletelyStableApp.Lib;
using System;

namespace CompletelyStableApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Starting up!");

            var number = 1;
            while (true)
            {
                var primeNumberFinder = new PrimeNumberFinder();
                var nextPrime = primeNumberFinder.FindNextPrimeNumber(number);
                Console.WriteLine(nextPrime);
                number = nextPrime + 1;
            }
        }
    }
}
