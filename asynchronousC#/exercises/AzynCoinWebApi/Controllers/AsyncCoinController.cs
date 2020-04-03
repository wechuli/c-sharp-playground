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
        public async Task<string> Get(int requestedAmount)
        {
            var result = await PretendToConnectToCoinServiceAsync(requestedAmount);
            return result;
        }
        private async Task<string> PretendToConnectToCoinServiceAsync(int requestedAmount)
        {
            // Simulate a long-running network connection
            await Task.Delay(requestedAmount * 1000);
            return $"You've got {requestedAmount} AsyncCoin!";
        }

        public async Task<string> AcquireAsyncCoinAsync(int requestedAmount)
        {
            var msg = string.Empty;
            msg += $"Your mining operation started at {DateTime.Now}" + Environment.NewLine;
            var result = await PretendToConnectToCoinServiceAsync(requestedAmount);
            msg += $"Your mining operation finished at {DateTime.Now}" + Environment.NewLine;
            msg += $"result: {result}";
            return msg;
        }

    }
}