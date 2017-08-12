using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RectangleIntersection
{
    class Program
    {
        static void Main(string[] args)
        {
            var matrix = new int[2001, 2001];
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                var inputRow = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
                var minX = inputRow[0] + 1000;
                var maxX = inputRow[1] + 1000;
                var minY = inputRow[2] + 1000;
                var maxY = inputRow[3] + 1000;
                for (int j = minX; j < maxX; j++)
                {
                    for (int k = minY; k < maxY; k++)
                    {
                        matrix[j, k]++;
                    }
                }
            }
            int counter = 0;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] > 1)
                    {
                        counter++;
                    }
                }
            }
            Console.WriteLine(counter);
        }
    }
}
