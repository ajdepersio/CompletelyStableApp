using CompletelyStableApp.Lib;
using System;

namespace CompletelyStableApp
{
    class Program
    {
        const string _startingMessage = "Starting up!";
        static string _endingMessage;

        static void Main(string[] args)
        {
            Console.WriteLine(_startingMessage);
            _endingMessage = "Somehow it finished...";

            var startTime = DateTime.UtcNow;
            var summaryMessage = "Start Time:";
            
            var number = 1;
            while (true)
            {
                var primeNumberFinder = new PrimeNumberFinder();
                var nextPrime = primeNumberFinder.FindNextPrimeNumber(number);
                Console.WriteLine(nextPrime);
                number = nextPrime + 1;
            }

            Console.WriteLine(_endingMessage);
            Console.WriteLine($"{summaryMessage} {startTime}");
        }
    }
}
