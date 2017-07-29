using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DividingPresents
{
    class DividingPresents
    {
        static void Main(string[] args)
        {
            //var arr = new int[] { 3, 2, 3, 2, 2, 77, 89, 23, 90, 11 };
            var arr = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            var allansNums = divider(arr);
            var allansPart = allansNums.Sum();
            var bobsPart = arr.Sum() - allansPart;
            Console.WriteLine($"Difference: {Math.Abs(allansPart - bobsPart)}");
            Console.WriteLine($"Alan:{allansPart} Bob:{bobsPart}");
            Console.WriteLine($"Alan takes: {string.Join(" ", allansNums)}");
            Console.WriteLine("Bob takes the rest.");
        }

        static int[] divider(int[] items)
        {
            int middle = items.Sum()/2;
            var maxPrice = new int[items.Length, middle + 1];
            var isItemTaken = new bool[items.Length, middle + 1];

            for (int i = 0; i <= middle; i++)
            {
                if (items[0] <= i)
                {
                    maxPrice[0, i] = items[0];
                    isItemTaken[0, i] = true;
                }
            }
            for (int item = 1; item < items.Length; item++)
            {
                for (int c = 0; c <= middle; c++)
                {
                    maxPrice[item, c] = maxPrice[item - 1, c];

                    var remainingCapacity = c - items[item];
                    if (remainingCapacity >= 0)
                    {
                        var sumWithCurrent = items[item] + maxPrice[item - 1, remainingCapacity];
                        if (sumWithCurrent >= maxPrice[item, c])
                        {
                            maxPrice[item, c] = sumWithCurrent;
                            isItemTaken[item, c] = true;
                        }
                    }
                }
            }

            var itemsTaken = new List<int>();
            int itemIndex = items.Length - 1;

            while (itemIndex >= 0)
            {
                var checker = isItemTaken[itemIndex, middle];
                if (checker)
                {
                    itemsTaken.Add(items[itemIndex]);
                    middle -= items[itemIndex];
                }
                itemIndex--;
            }

            return itemsTaken.ToArray();
        }
    }
}
