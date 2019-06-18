using System;
namespace myclasses
{
    public class Sequence
    {
        //static field, holding the current sequence value
        private static int currentValue = 0;

        //Intentionally deny instantiation of this class
        private Sequence()
        {
        }
        //static method for taking the next sequence value
        public static int NextValue()
        {
            currentValue++;
            return currentValue;
        }
    }
}