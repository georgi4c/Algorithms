namespace Zigzag_Matrix
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class ZigzagMatrix
    {
        public static void Main(string[] args)
        {
            int numberOfRows = int.Parse(Console.ReadLine());
            int numberOfColumns = int.Parse(Console.ReadLine());

            int[,] maxValues = new int[numberOfRows, numberOfColumns];
            int[,] paths = new int[numberOfRows, numberOfColumns];
            int[][] matrix = new int[numberOfRows][];
            ReadMatrix(numberOfRows, matrix);

            for (int row = 0; row < numberOfRows; row++)
            {
                maxValues[row, 0] = matrix[row][0];
            }


            for (int col = 1; col < numberOfColumns; col++)
            {
                for (int row = 0; row < numberOfRows; row++)
                {
                    int previousMax = 0;
                    if (col % 2 == 0)
                    {
                        for (int i = 0; i < row; i++)
                        {
                            if (maxValues[i, col - 1] + matrix[row][col] > previousMax)
                            {
                                previousMax = maxValues[i, col - 1] + matrix[row][col];
                                paths[row, col] = i;
                            }
                        }
                    }
                    else
                    {
                        for (int i = row + 1; i < numberOfRows; i++)
                        {
                            if (maxValues[i, col - 1] + matrix[row][col] > previousMax)
                            {
                                previousMax = maxValues[i, col - 1] + matrix[row][col];
                                paths[row, col] = i;
                            }
                        }
                    }
                    maxValues[row, col] = previousMax + matrix[row][col];
                }
            }

            int lastRowIndex = GetLastRowIndexOfPath(maxValues, numberOfColumns);
            List<int> result = RecoverMaxPath(numberOfColumns, matrix, lastRowIndex, paths);
            Console.WriteLine("{0} = {1}", result.Sum(), string.Join(" + ", result));

        }

        private static void ReadMatrix(int numberOfRows, int[][] matrix)
        {
            for (int i = 0; i < numberOfRows; i++)
            {
                matrix[i] = Console.ReadLine()
                    .Split(',')
                    .Select(int.Parse)
                    .ToArray();
            }
        }

        private static int GetLastRowIndexOfPath(int[,] maxPaths, int numberOfColumns)
        {
            int max = 0;
            int row = 0;
            for (int i = 0; i < maxPaths.GetLength(0); i++)
            {
                if (maxPaths[i, numberOfColumns - 1] > max)
                {
                    max = maxPaths[i, numberOfColumns - 1];
                    row = i;
                }
            }
            return row;
        }

        private static List<int> RecoverMaxPath(
            int numberOfColumns,
            int[][] matrix,
            int rowIndex,
            int[,] previousRowIndex)
        {
            List<int> path = new List<int>();

            for (int i = numberOfColumns - 1; i >= 0; i--)
            {
                path.Add(matrix[rowIndex][i]);
                rowIndex = previousRowIndex[rowIndex, i];
            }
            path.Reverse();
            return path;
        }
    }
}