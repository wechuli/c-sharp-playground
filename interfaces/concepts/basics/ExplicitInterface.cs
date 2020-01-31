using System;

namespace basics
{


    interface IControl
    {
        void Paint();
    }
    interface ISurface
    {
        void Paint();
    }
    class SampleClass : IControl, ISurface
    {
        //Both ISurface.Paint and IControl.Paint call this method
        public void Paint()
        {
            Console.WriteLine("Paint method in SampleClass");

        }

        public void FakeMethod()
        {
            Console.WriteLine("I am a fake method");
        }
    }

}