using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;


namespace AsyncCoinWebApi.Controllers
{
    [Route("api/[controller]")]
    public class AsyncCoinController : Controller
    {
        // GET api/asynccoin/5
        [HttpGet("{requestedAmount}")]
        public string Get(int requestedAmount)
        {
            return AcquireAsyncCoin(requestedAmount);
        }

        private string PretendToConnectToCoinService(int requestedAmount)
        {
            // Simulate a long-running network connection
            Thread.Sleep(requestedAmount * 1000);
            return $"You've got {requestedAmount} AsyncCoin!";
        }

        public string AcquireAsyncCoin(int requestedAmount)
        {
            var msg = string.Empty;
            msg += $"Your mining operation started at {DateTime.Now}" + Environment.NewLine;
            var result = PretendToConnectToCoinService(requestedAmount);
            msg += $"Your mining operation finished at {DateTime.Now}" + Environment.NewLine;
            msg += $"result: {result}";
            return msg;
        }
    }

}