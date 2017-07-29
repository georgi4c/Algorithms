using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecursiveArraySum
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            var sum = Sum(input, 0);
            Console.WriteLine(sum);
        }

        private static int Sum(int[] array, int index)
        {
            if (index >= array.Length - 1)
            {
                return array[index];
            }
            return array[index] + Sum(array, index + 1);
        }
    }
}
