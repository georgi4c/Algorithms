using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace ElectionFast
{
    class Program
    {
        static void Main(string[] args)
        {
            var controlBorder = int.Parse(Console.ReadLine());
            var numberOfParties = int.Parse(Console.ReadLine());
            var numbers = new int[numberOfParties];
            for (int i = 0; i < numberOfParties; i++)
            {
                numbers[i] = int.Parse(Console.ReadLine());
            }
            var sums = new BigInteger[numbers.Sum() + 1];
            
            sums[0] = 1;
            foreach (var number in numbers)
            {
                for (int i = sums.Length - 1; i >= 0; i--)
                {
                    if (sums[i] != 0)
                    {
                        sums[i + number] += sums[i];
                    }
                }
            }
            BigInteger count = 0;
            for (int i = controlBorder; i < sums.Length; i++)
            {
                count += sums[i];
            }
            Console.WriteLine(count);
        }
    }
}
