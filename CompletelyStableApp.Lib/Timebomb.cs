using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace CompletelyStableApp.Lib
{
    public class Timebomb
    {
        private readonly int _duration;

        public Timebomb(int duration)
        {
            _duration = duration;
        }

        public void Start()
        {
            var timer = new Timer(_duration);
            timer.Elapsed += Explode;

            timer.Enabled = true;
        }

        private static void Explode(Object source, ElapsedEventArgs e)
        {
            Console.WriteLine("BOOM!");
            throw new StackOverflowException();
        }
    }
}
