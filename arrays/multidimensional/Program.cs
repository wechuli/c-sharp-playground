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

        }
    }
}
