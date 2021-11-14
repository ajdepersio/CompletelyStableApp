using System;

namespace CompletelyStableApp.Lib
{
    public static class PrimeNumberFinder
    {
        public static int FindNextPrimeNumber(int start)
        {
            while (!IsPrime(start))
            {
                start++;
            }
            return start;
        }

        private static bool IsPrime(int number)
        {
            if (number == 1) return false;
            if (number == 2) return true;

            var limit = Math.Ceiling(Math.Sqrt(number)); //hoisting the loop limit

            for (int i = 2; i <= limit; ++i)
                if (number % i == 0)
                    return false;
            return true;
        }
    }
}
