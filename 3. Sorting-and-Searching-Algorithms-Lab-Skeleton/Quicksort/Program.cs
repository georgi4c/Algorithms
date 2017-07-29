using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quicksort
{
    class Program
    {
        static void Quicksort(List<int> array, int start, int end)
        {
            if (start >= end)
            {
                return;
            }
            var pivot = array[start];
            int storeIndex = start + 1;
            for (int i = start+1; i <= end; i++)
            {
                if (array[i].CompareTo(pivot) < 0)
                {
                    Swap(array, i, storeIndex);
                    storeIndex++;
                }
                
            }
            storeIndex--;
            Swap(array, start, storeIndex);

            Quicksort(array, start, storeIndex);
            Quicksort(array, storeIndex + 1, end);
        }

        static void Swap(List<int> array, int i, int storeIndex)
        {
            var temp = array[i];
            array[i] = array[storeIndex];
            array[storeIndex] = temp;
        }

        static void Main(string[] args)
        {
            var collection = new List<int> { 2, -1, 5, 0, -3 };
            Console.WriteLine(string.Join(" ", collection));
            Quicksort(collection, 0, collection.Count-1);
            Console.WriteLine(string.Join(" ", collection));
        }
    }
}
