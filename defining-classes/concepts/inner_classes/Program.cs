using System;

namespace inner_classes
{
    class Program
    {
        static void Main(string[] args)
        {
            OuterClass outerClass = new OuterClass("Outer");
            OuterClass.NestedClass innerClass = new OuterClass.NestedClass(outerClass, "nested");

            innerClass.PrintNames();
        }
    }

    public class OuterClass
    {
        private string name;
        public OuterClass(string name)
        {
            this.name = name;
        }

        public class NestedClass
        {
            private string name;
            private OuterClass parent;
            public NestedClass(OuterClass parent, string name)
            {
                this.parent = parent;
                this.name = name;
            }

            public void PrintNames()
            {
                Console.WriteLine("Nested name: " + this.name);
                Console.WriteLine("Outer name: " + this.parent.name);
            }
        }
    }
}
