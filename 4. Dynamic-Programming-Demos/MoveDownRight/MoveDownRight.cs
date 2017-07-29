using System;
using System.Collections.Generic;
using System.Linq;

class MoveDownRight
{
    static void Main()
    {
        int rowsCount = int.Parse(Console.ReadLine());
        int colsCount = int.Parse(Console.ReadLine());
        var cells = new int[rowsCount, colsCount];
        for (int i = 0; i < rowsCount; i++)
        {
            var colNums = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            for (int j = 0; j < colNums.Length; j++)
            {
                cells[i, j] = colNums[j];
            }
        }

        //int[,] cells =
        //{
        //    {2, 6, 1, 8, 9, 4, 2},
        //    {1, 8, 0, 3, 5, 6, 7},
        //    {3, 4, 8, 7, 2, 1, 8},
        //    {0, 9, 2, 8, 1, 7, 9},
        //    {2, 7, 1, 9, 7, 8, 2},
        //    {4, 5, 6, 1, 2, 5, 6},
        //    {9, 3, 5, 2, 8, 1, 9},
        //    {2, 3, 4, 1, 7, 2, 8}
        //};
        //int rowsCount = cells.GetLength(0);
        //int colsCount = cells.GetLength(1);

        // Calculate sum[,] - the maximum sums 
        long[,] sum = new long[rowsCount, colsCount];
        for (int row = 0; row < rowsCount; row++)
        {
            for (int col = 0; col < colsCount; col++)
            {
                long maxPrevCell = long.MinValue;
                if (col > 0 && sum[row, col - 1] > maxPrevCell)
                {
                    maxPrevCell = sum[row, col - 1];
                }
                if (row > 0 && sum[row - 1, col] > maxPrevCell)
                {
                    maxPrevCell = sum[row - 1, col];
                }
                sum[row, col] = cells[row, col];
                if (maxPrevCell != long.MinValue)
                {
                    sum[row, col] += maxPrevCell;
                }
            }
        }

        // Mark the path from bottom-down corner to the top-left corner
        bool[,] cellOnPath = new bool[rowsCount, colsCount];
        int r = rowsCount - 1;
        int c = colsCount - 1;
        while (r >= 0 && c >= 0)
        {
            cellOnPath[r, c] = true;
            if (c > 0 && sum[r, c] == sum[r, c - 1] + cells[r, c])
            {
                c--;
            }
            else
            {
                r--;
            }
        }
        var result = new List<string>();
        for (int row = 0; row < rowsCount; row++)
        {
            for (int col = 0; col < colsCount; col++)
            {
                if (cellOnPath[row, col])
                {
                    result.Add($"[{row}, {col}]");
                }
                //if (cellOnPath[row, col])
                //{
                //    Console.ForegroundColor = ConsoleColor.Yellow;
                //}
                //else
                //{
                //    Console.ForegroundColor = ConsoleColor.Gray;
                //}
                //Console.Write("{0, 3}", cells[row, col]);
            }
            //Console.ForegroundColor = ConsoleColor.Gray;
            //Console.WriteLine();
        }
        Console.WriteLine(String.Join(" ", result));
        // Print the path in the matrix
        //for (int row = 0; row < rowsCount; row++)
        //{
        //    for (int col = 0; col < colsCount; col++)
        //    {
        //        if (cellOnPath[row, col])
        //        {
        //            Console.ForegroundColor = ConsoleColor.Yellow;
        //        }
        //        else
        //        {
        //            Console.ForegroundColor = ConsoleColor.Gray;
        //        }
        //        Console.Write("{0, 3}", cells[row, col]);
        //    }
        //    Console.ForegroundColor = ConsoleColor.Gray;
        //    Console.WriteLine();
        //}

        // Print the max sum in the matrix
        //Console.WriteLine();
        //Console.WriteLine("Max sum = {0}",
        //    sum[cells.GetLength(0) - 1, cells.GetLength(1) - 1]);
        //Console.WriteLine();
    }
}
