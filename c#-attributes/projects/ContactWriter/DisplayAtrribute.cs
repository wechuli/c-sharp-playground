using System;
using static System.Console;



namespace ContactWriter

{
    [AttributeUsage(AttributeTargets.Property)]
    class DisplayAttribute : Attribute
    {
        public string Label { get; }
        public ConsoleColor Color { get; }


        public DisplayAttribute(string label, ConsoleColor color = ConsoleColor.White)
        {
            this.Label = label ?? throw new ArgumentNullException(nameof(label));
            this.Color = color;
        }

    }
}