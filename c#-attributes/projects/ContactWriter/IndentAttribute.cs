using System;


namespace ContactWriter
{
    [AttributeUsage(AttributeTargets.Property, Inherited = false, AllowMultiple = true)]
    sealed class IndentAttribute : Attribute
    {


    }
}