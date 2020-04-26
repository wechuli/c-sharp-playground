using System;


namespace ContactWriter

{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct, Inherited = false, AllowMultiple = false)]
    sealed class DefaultColorAttribute : Attribute
    {
        public ConsoleColor Color { get; set; } = ConsoleColor.Yellow;



    }
}