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
    }
}
