using System;

namespace CompletelyStableApp.Lib
{
    public class PrimeNumberFinder
    {
        private const int _max = 10000000;
        private Random _random = new Random();

        public int FindNextPrimeNumber(int start)
        {
            while (!IsPrime(start))
            {
                start++;
            }
            return start;
        }

        private bool IsPrime(int number)
        {
            if (number == 1) return false;
            if (number == 2) return true;

            var limit = Math.Ceiling(Math.Sqrt(number));

            for (int i = 2; i <= limit; ++i)
            {
                this.PossiblyOverflowTheStack();
                if (number % i == 0)
                {
                    return false;
                }
            }
            return true;
        }

        private void PossiblyOverflowTheStack()
        {
            if (_random.Next(_max) == _max - 1)
            {
                this.AddToTheStack();
            }
        }

        private void AddToTheStack()
        {
            var x = _random.Next(_max);
            var y = _random.Next(_max);

            System.Diagnostics.Debug.WriteLine($"Y value: {y}");
            this.AddMoreToTheStack();
            System.Diagnostics.Debug.WriteLine($"X value: {x}");
        }

        private void AddMoreToTheStack()
        {
            var x = _random.Next(_max);
            var y = _random.Next(_max);

            System.Diagnostics.Debug.WriteLine($"X value: {x}");
            this.AddToTheStack();
            System.Diagnostics.Debug.WriteLine($"Y value: {y}");
        }
    }
}
