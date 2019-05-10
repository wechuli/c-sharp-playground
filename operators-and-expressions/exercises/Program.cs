using System;


namespace exercises
{
    class Program
    {
        static void Main(string[] args)
        {

            //1. Write an expression that checks whether an integer is odd or even.
            int number = 35;
            string odd_even = (number % 2) == 0 ? "even" : "odd";
            Console.WriteLine(odd_even);

            //2. Write a Boolean expression that checks whether a given integer is divisible by both 5 and 7, without a remainder.
            bool div5_7 = (number % 5 == 0) && (number % 7 == 0);
            Console.WriteLine(div5_7);

            //3. Write an expression that looks for a given integer if its third digit (right to left) is 7.
            int longnumber = 857645;
            bool third7 = (longnumber / 100) % 10 == 7;
            Console.WriteLine(third7);

            //4. Write an expression that checks whether the third bit in a given integer is 1 or 0.
            int givenint = 15;
            bool checkint = (givenint & 8) != 0;
            Console.WriteLine((givenint & 8));
            Console.WriteLine(checkint);
            //5.Write an expression that calculates the area of a trapezoid by given sides a, b and height h.
            //A = (a+b)/2 *h
            float a = 3f;
            float b = 10f;
            float h = 10f;

            float Area = ((a + b) / 2) * h;
            Console.WriteLine(Area);

            //6.Write a program that prints on the console the perimeter and the area of a rectangle by given side and height entered by the user.
            double width, height;
            Console.WriteLine("Please enter the rectangle height: ");
            height = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Please enter the rectangle width: ");
            width = Convert.ToDouble(Console.ReadLine());
            double rectArea = width * height;
            double rectPer = 2 * (width + height);
            Console.WriteLine($"The area of the reactangle is: {rectArea} and the perimeter is: {rectPer}");

            //7.The gravitational field of the Moon is approximately 17% of that on the Earth. Write a program that calculates the weight of a man on the moon by a given weight on the Earth.

            double manWeight, moonWeight;
            Console.WriteLine("Please enter the weight in Kg: ");
            manWeight = Convert.ToDouble(Console.ReadLine());
            moonWeight = (manWeight / 100) * 17;
            Console.WriteLine($"You would weight {moonWeight} kg on the moon");

            //8.Write an expression that checks for a given point {x, y} if it is within the circle K({0, 0}, R=5). Explanation: the point {0, 0} is the center of the circle and 5 is the radius.

            int x = 1;
            int y = 4;
            bool confirmBound = (x > -5 && x < 5) && (y > -5 && y < 5);
            Console.WriteLine(confirmBound);

            //9.

            //10.10. Write a program that takes as input a four-digit number in format abcd (e.g. 2011) and performs the following actions:
            //- Calculates the sum of the digits (in our example 2+0+1+1 = 4).
            //- Prints on the console the number in reversed order: dcba (in our example 1102).
            //- Puts the last digit in the first position: dabc (in our example 1201).
            //- Exchange
            int mynumber, first, second, third, fourth;
            Console.WriteLine("Please enter your 4 digit number: ");
            mynumber = Convert.ToInt32(Console.ReadLine());
            fourth = (mynumber % 10);
            third = (mynumber / 10) % 10;
            second = (mynumber / 100) % 10;
            first = (mynumber / 1000) % 10;

            Console.WriteLine($"The sum of the numbers is {first + second + third + fourth}");
            Console.WriteLine($"The numbers in reverse order are {fourth}{third}{second}{first}");
            Console.WriteLine($"The last digit as first {fourth}{first}{second}{third}");
            Console.WriteLine($"Exchanging the second and third {first}{third}{second}{fourth}");

            //11. We are given a number n and a position p. Write a sequence of operations that prints the value of the bit on the position p in the number (0 or 1). Example: n=35, p=5 -> 1. Another example: n=35, p=6 -> 0.

            int digit = 64789;
            int position = 8;

            int value = (digit & (int)(Math.Pow(2, position))) > 0 ? 1 : 0;
            Console.WriteLine(value);
            //12. Write a Boolean expression that checks if the bit on position p in the integer v has the value 1. Example v=5, p=1 -> false.

            bool valueB = (digit & (int)(Math.Pow(2, position))) > 0;
            Console.WriteLine(valueB);

            //13.We are given the number n, the value v (v = 0 or 1) and the position p. write a sequence of operations that changes the value of n, so the bit on the position p has the value of v. Example: n=35, p=5, v=0 -> n=3. Another example: n=35, p=2, v=1 -> n=39.
            int cnumber = 35;
            int v = 1;
            int cposition = 2;

            cnumber = v == 1 ? (cnumber | (1 << cposition)) : (cnumber & ~(1 << cposition));
            Console.WriteLine(cnumber);

            //14.Write a program that checks if a given number n (1 < n < 100) is a prime number (i.e. it is divisible without remainder only to itself and 1).

            int pnumber = 81;
            bool prime = true;
            for (int i = 2; i < pnumber; i++)
            {
                if (pnumber % i == 0)
                {
                    prime = false;
                }
            }
            Console.WriteLine(prime);






        }
    }
}
