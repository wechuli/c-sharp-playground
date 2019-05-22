using System;

namespace multidimensional
{
    class Program
    {
        static void Main(string[] args)
        {
            //Every valid type in C# can be used for a type of an array
            int[,] twoDimensionalArray;
            int[,,] threeDimensionalArray;

            int[,] intMatrix;
            float[,] floatMatrix;
            string[,,] strCube;

            //We allocate memory for multidimensional arrays by using the keword new
            intMatrix = new int[3, 4];
            floatMatrix = new float[8, 2];
            strCube = new string[5, 5, 5];

            //We initialize two-dimensional arrays in the same way as we initialize one dimensional arrays. We can list the elelments values straight after the declaration

            int[,] matrix = { { 1, 2, 3, 4 }, { 5, 6, 7, 8 } };

            foreach (var item in matrix)
            {
                Console.WriteLine(item);
            }

            //Matrices have two dimensions and respectively , we access each element using two indices: one for the rows and one for the columns.Multidimensional arrays have different indices for each dimension
            // matrix[row,col]

            Console.WriteLine(matrix[0, 3]);
            Console.WriteLine(matrix[1, 1]);

            //Each dimension of a multidimensional array has its own length, which can be accessed during the execution of the program
            Console.WriteLine($"The lenght of the whole Matrix is {matrix.Length}");
            Console.WriteLine($"The lenght of the row in the Matrix is {matrix.GetLength(0)}");
            Console.WriteLine($"The lenght of the column in the  Matrix is {matrix.GetLength(1)}");

            //Printing matrices


            //print the matrix on the console
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row, col]);
                }
                Console.WriteLine();

            }
            bestSum();

        }
        static void bestSum()
        {

            // Declare and initialize the matrix
            int[,] matrix = {
                { 0, 2, 4, 0, 9, 5 },
                { 7, 12, 3, 3, 2, 1 },
                { 1, 31, 9, 8, 5, 6 },
                { 4, 6, 7, 9, 1, 0 }
                };

            // Find the maximal sum platform of size 2 x 2
            long bestSum = long.MinValue;
            int bestRow = 0;
            int bestCol = 0;
            for (int row = 0; row < matrix.GetLength(0) - 1; row++)
            {
                for (int col = 0; col < matrix.GetLength(1) - 1; col++)
                {
                    long sum = matrix[row, col] + matrix[row, col + 1] +
                matrix[row + 1, col] + matrix[row + 1, col + 1];
                    if (sum > bestSum)
                    {
                        bestSum = sum;
                        bestRow = row;
                        bestCol = col;
                    }
                }
            }
            // Print the result
            Console.WriteLine("The best platform is:");
            Console.WriteLine(" {0} {1}",
            matrix[bestRow, bestCol],
            matrix[bestRow, bestCol + 1]);
            Console.WriteLine(" {0} {1}",
            matrix[bestRow + 1, bestCol],
            matrix[bestRow + 1, bestCol + 1]);
            Console.WriteLine("The maximal sum is: {0}", bestSum);
        }
    }
}
    

