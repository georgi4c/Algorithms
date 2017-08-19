using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Guitar
{
    class Program
    {

        static void Main(string[] args)
        {
            var newValues = Console.ReadLine()
                .Split(new []{' ', ','}, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int startNum = int.Parse(Console.ReadLine());
            int allowableValue = int.Parse(Console.ReadLine());

            var matrix = new bool[newValues.Length + 1, allowableValue + 1];
            matrix[0, startNum] = true;
            for (int i = 1; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i - 1, j])
                    {
                        if (j - newValues[i - 1] >= 0 && j - newValues[i - 1] <= allowableValue)
                        {
                            matrix[i, j - newValues[i - 1]] = true;
                        }
                        if (j + newValues[i - 1] >= 0 && j + newValues[i - 1] <= allowableValue)
                        {
                            matrix[i, j + newValues[i - 1]] = true;
                        }
                    }
                }
            }
            for (int i = allowableValue; i >= 0; i--)
            {
                if (matrix[matrix.GetLength(0) - 1, i])
                {
                    Console.WriteLine(i);
                    return;
                }
            }
            Console.WriteLine("-1");
        }
    }
    
}
