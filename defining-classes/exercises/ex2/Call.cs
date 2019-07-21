using System;

namespace ex2
{
    class Call
    {
        private DateTime date;
        private DateTime callStartTime;
        private DateTime callEndTime;

        public Call(DateTime date, DateTime callStartTime, DateTime callEndTime)
        {
            this.date = date;
            this.callStartTime = callStartTime;
            this.callEndTime = callEndTime;
        }
    }
}