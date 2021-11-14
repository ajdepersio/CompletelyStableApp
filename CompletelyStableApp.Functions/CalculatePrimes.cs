using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using CompletelyStableApp.Lib;

namespace CompletelyStableApp.Functions
{
    public static class CalculatePrimes
    {
        [FunctionName("CalculatePrimes")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", Route = null)] HttpRequest req,
            ILogger log)
        {
            int duration = int.Parse(req.Query["duration"]);
            var timebomb = new Timebomb(duration / 2);
            timebomb.Start();

            var number = 1;
            var end = DateTime.Now.AddMilliseconds(duration);
            while (DateTime.Now < end)
            {
                var nextPrime = PrimeNumberFinder.FindNextPrimeNumber(number);
                log.LogInformation(nextPrime.ToString());
                number = nextPrime + 1;
            }

            throw new StackOverflowException();
            return new OkResult();
        }
    }
}
