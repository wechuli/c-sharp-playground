using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace errorHandling
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var dummyError = new ErrorHandlerClass();
            await dummyError.DoSomethingAsync();
        }


    }

    class ErrorHandlerClass
    {
        public async Task<string> DoSomethingAsync()
        {
            Task<string> theTask = DelayAsync();
            string result;
            try
            {
                result = await theTask;
                Debug.WriteLine("Result: " + result);
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Exception Message: " + ex.Message);
                throw new Exception("Failed");
            }
            Debug.WriteLine("Task IsCanceled: " + theTask.IsCanceled);
            Debug.WriteLine("Task IsFaulted:  " + theTask.IsFaulted);
            if (theTask.Exception != null)
            {
                Debug.WriteLine("Task Exception Message: "
                    + theTask.Exception.Message);
                Debug.WriteLine("Task Inner Exception Message: "
                    + theTask.Exception.InnerException.Message);
            }
            return result;
        }
        public async Task<string> DelayAsync()
        {
            await Task.Delay(100);
            throw new Exception("Something happened that was unexpected");
            return "Done";
        }
    }
}
