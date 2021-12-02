using System;
using System.Collections.Generic;
using System.Net;
using CompletelyStableApp.Lib;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;

namespace CompletelyStableApp.Functions
{
    public static class CalculatePrimeNumbers
    {
        [Function("CalculatePrimeNumbers")]
        public static HttpResponseData Run([HttpTrigger(AuthorizationLevel.Function, "get", "post")] HttpRequestData req,
            FunctionContext executionContext, int duration)
        {
            var logger = executionContext.GetLogger("CalculatePrimeNumbers");

            var number = 1;
            var end = DateTime.Now.AddMilliseconds(duration);
            var primeNumberFinder = new PrimeNumberFinder();

            while (DateTime.Now < end)
            {
                var nextPrime = primeNumberFinder.FindNextPrimeNumber(number);
                logger.LogInformation(nextPrime.ToString());
                number = nextPrime + 1;
            }

            var response = req.CreateResponse(HttpStatusCode.OK);
            return response;
        }
    }
}
