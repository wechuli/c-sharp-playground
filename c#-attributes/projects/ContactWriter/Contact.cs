using System;
using System.Diagnostics;
using static System.Console;

namespace ContactWriter
{
    [DebuggerDisplay("First Name={FirstName} and Age In Year={AgeInYears}")]
    [DefaultColor(Color = ConsoleColor.Magenta)]
    public struct Contact
    {

        [Display("First Name:", ConsoleColor.Cyan)]
        [Indent]
        [Indent]
        [Indent]
        public string FirstName { get; set; }

        // [DebuggerBrowsable(DebuggerBrowsableState.Never)]

        public int AgeInYears { get; set; }


    }

}