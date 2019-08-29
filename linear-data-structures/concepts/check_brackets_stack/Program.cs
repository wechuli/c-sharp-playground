using System;
using System.Collections.Generic;

namespace check_brackets_stack
{
    class Program
    {
        static void Main(string[] args)
        {
            string expression = "1 + (3 (+ 2 - (2+())3)*4 - ((3+1)*)(4-2)))";
            bool checkBrackets = CheckBracketCorrectness(expression);
            Console.WriteLine("Are the brackets correct? " + checkBrackets);
        }

        static public bool CheckBracketCorrectness(string expression)
        {
            bool correctBrackets = true;
            Stack<int> bracketStack = new Stack<int>();

            for (int index = 0; index < expression.Length; index++)
            {
                char ch = expression[index];

                if (ch == '(')
                {
                    bracketStack.Push(index);
                }
                else if (ch == ')')
                {
                    if (bracketStack.Count == 0)
                    {
                        correctBrackets = false;
                        break;
                    }
                    bracketStack.Pop();
                }
            }
            if (bracketStack.Count != 0)
            {
                correctBrackets = false;
            }
            return correctBrackets;

        }
    }
}
