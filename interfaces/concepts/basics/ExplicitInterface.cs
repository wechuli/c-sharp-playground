using System;

namespace basics
{


    interface ISalutations
    {
        string Greeting { get; set; }
    }

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

    public class AnotherSampleClass : IControl, ISurface, ISalutations
    {

        public string fakeField = "blah";

        public string Greeting { get; set; }

        public AnotherSampleClass()
        {
            this.Greeting = "Original greeting";
        }
        void IControl.Paint()
        {

            Console.WriteLine("IControl.Paint");
        }
        void ISurface.Paint()
        {
            Console.WriteLine("ISurface.Paint");
        }

    }

}