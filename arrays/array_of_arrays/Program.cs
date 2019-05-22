using System;

namespace array_of_arrays
{
    class Program
    {
        static void Main(string[] args)
        {
            //   In C#, we can have arrays of arrays, which we call them jagged arrays
            // Jagged arrays are arrays of arrays, or arrays in which each row contains an array of its own, and that array can have length different than those in the other rows
            //The only difference in the declaration of the jagged arrays compared to the regular multidimensional array is that we do not have just one pair of brackets. With the jagged arrays we have a pair of brackers per dimension

            int[][] jaggedArray;
            jaggedArray = new int[2][];
            jaggedArray[0] = new int[5];
            jaggedArray[1] = new int[3];

            //we can declare, allocae and initialize an array of arrays

            int[][] myJaggedArray = {
                new int[] {5,7,2},
                new int[] {10,20,40},
                new int[] {3,25}
            };

            foreach (var item in myJaggedArray)
            {
                Console.WriteLine(item[0]);
            }
            //The figure below depicts how the now declared jagged array myJaggedArray is allocated in the memory. As we see the jagged arrays are an aggregation of references. A jagged array does not directly contain any arrays, but rather has elements pointing to them. The size is unknown and that is why CLR just keeps references to the internal arrays. After we allocate memory for one array-element of the jagged array, then the reference starts pointing to the newly created block in the dynamic memory. The variable myJaggedArray is stored in the execution stack of the program and points to a block in the dynamic memory, which contains a sequence of three references to other three blocks in memory; each of them contains an array of integer numbers – the elements of the jagged array:

            Console.WriteLine(myJaggedArray[2][1]);


            //The elements of the jagged array can be one-dimensional and multidimensional arrays
            int[][,] jaggedOfMulti = new int[2][,];
            jaggedOfMulti[0] = new int[,] { { 5, 15 }, { 125, 206 } };
            jaggedOfMulti[1] = new int[,] { { 3, 4, 5 }, { 7, 8, 9 } };
            pascalTriangle();
        }
        static void pascalTriangle()
        {
            const int HEIGHT = 12;


            //Allocate the array in atriangle form
            long[][] triangle = new long[HEIGHT + 1][];
            for (int row = 0; row < HEIGHT; row++)
            {
                triangle[row] = new long[row + 1];
            }
            // Calculate the Pascal's triangle
            triangle[0][0] = 1;
            for (int row = 0; row < HEIGHT - 1; row++)
            {
                for (int col = 0; col <= row; col++)
                {
                    triangle[row + 1][col] += triangle[row][col];
                    triangle[row + 1][col + 1] += triangle[row][col];
                }
            }
            // Print the Pascal's triangle
            for (int row = 0; row < HEIGHT; row++)
            {
                Console.Write("".PadLeft((HEIGHT - row) * 2));
                for (int col = 0; col <= row; col++)
                {
                    Console.Write("{0,3} ", triangle[row][col]);
                }
                Console.WriteLine();
            }
        }
    }
}
