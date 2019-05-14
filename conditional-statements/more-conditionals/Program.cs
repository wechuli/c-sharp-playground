using System;

namespace more_conditionals
{
    class Program
    {
        static void Main(string[] args)
        {
            //Logical operators || && ! ^
            //The logical operators && and logical || are only used on Boolean expressions(values of type bool)
            //&& is also called short-circuit logical operator || short circuit logical operator 'or'

            //Logical Operators & and |
            //The operators for comparison & and | are similar to && and ||, respectively.The difference lies in the fact that both operands are calculated , one after the other, although the final reusult is known in advance.That's why these comparison operators are also known as full-circuit logical operators and are used very rarely


            //We must not confuse the Boolean operators & and | with the bitwise operators & and |. Although they are written in the same way, they take different arguments (Boolean or integer expressions) and return different result (bool or integer) and their actions are not identical.

            //The ^ operator, also known as exclusive OR (XOR), belongs to the full-circuit operators, because both operands are calculated one after the other. The result of applying the operator is true if exactly one of the operands is true, but not both simultaneously. Otherwise the result is false
            Console.WriteLine("Exclusive OR: " + ((2 < 3) ^ (4 > 3)));  //false

            //The operator ! returns the reversed value of the Boolean expression to which it is attached
            bool value = !(7 == 5);  //True
            Console.WriteLine(value);

            //If-else clause
            //The expression in the brackets which follows the keyword if must return a Boolean value(true or false)

            Console.WriteLine("Enter two numbers: ");
            Console.Write("Enter the first numer: ");
            int firstNumber = Int32.Parse(Console.ReadLine());
            Console.Write("Enter the second number: ");
            int secondNumber = Int32.Parse(Console.ReadLine());
            int biggerNumber = firstNumber;
            if (secondNumber > firstNumber)
            {
                biggerNumber = secondNumber;
            }
            Console.WriteLine($"The bigger number is {biggerNumber}");

            //else
            int x = 2;
            if (x > 3)
            {
                Console.WriteLine("x is greater than 3");
            }
            else
            {
                Console.WriteLine("x is not greater than 3");
            }
            //nested if
            // every else clause corresponds to the closets previous if clause, it is not good practicen to exceed three nested levels

            int first = 5;
            int second = 3;

            if (first == second)
            {
                Console.WriteLine("These two numbers are equal");
            }
            else
            {
                if (first > second)
                {
                    Console.WriteLine("The first number is greater");
                }
                else
                {
                    Console.WriteLine("The second number is greater");
                }
            }
            // else if
            char ch = 'X';
            if (ch == 'A' || ch == 'a')
            {
                Console.WriteLine("Vowel [ei]");
            }
            else if (ch == 'E' || ch == 'e')
            {
                Console.WriteLine("Vowel [i:]");
            }
            else if (ch == 'I' || ch == 'i')
            {
                Console.WriteLine("Vowel [ai]");
            }
            else if (ch == 'O' || ch == 'o')
            {
                Console.WriteLine("Vowel [ou]");
            }
            else if (ch == 'U' || ch == 'u')
            {
                Console.WriteLine("Vowel [ju:]");
            }
            else
            {
                Console.WriteLine("Consonant");
            }
            //prefer switch-case structure to a series of if-else-if-else
        }
    }
}
