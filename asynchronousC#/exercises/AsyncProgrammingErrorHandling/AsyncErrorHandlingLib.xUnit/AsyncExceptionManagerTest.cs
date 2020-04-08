using System;
using Xunit;
using AsyncErrorHandlingLib;
using System.Threading.Tasks;

namespace AsyncErrorHandlingLib.xUnit
{
    public class AsyncExceptionManagerTest
    {
        private AsyncExceptionManager _exceptionMgr;

        public AsyncExceptionManagerTest()
        {
            _exceptionMgr = new AsyncExceptionManager();
        }

        [Fact]
        public void ExceptionManagerCanMineCoins()
        {
            var result = _exceptionMgr.MineCoinFromForbiddenServer();
            Assert.True(result.Contains("Success"), "Failed to mine.");
        }

        [Fact]
        public async Task ExceptionManagerCanMineCoinsAsync()
        {
            var result = await _exceptionMgr.MineCoinFromForbiddenServerAsync();
            Assert.True(result.Contains("Success"), "Failed to mine.");
            return;
        }

        [Fact]
        public void ExceptionManagerCanMineCoinsTaskParallel()
        {
            var result = _exceptionMgr.MineOnSeveralServers();
            Assert.True(result.Contains("Success"), "Failed to mine.");
        }

        [Fact]
        public void ExceptionManagerCanMineCoinsParallelFor()
        {
            var result = _exceptionMgr.MineForCoinsWithParallelFor();
            Assert.True(result > 0, "Did not mine any coins");
        }
    }
}
