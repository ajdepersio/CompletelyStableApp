using CompletelyStableApp.Lib;
using System;

namespace CompletelyStableApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Starting up!");
            var timebomb = new Timebomb(30000);
            timebomb.Start();
            
            var number = 1;
            while (true)
            {
                var nextPrime = PrimeNumberFinder.FindNextPrimeNumber(number);
                Console.WriteLine(nextPrime);
                number = nextPrime + 1;
            }
        }
    }
}
