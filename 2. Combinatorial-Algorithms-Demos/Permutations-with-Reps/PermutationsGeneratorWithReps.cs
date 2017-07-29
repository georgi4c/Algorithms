using System;
using System.Collections.Generic;
using System.Linq;

class PermutationsGeneratorWithReps
{
    private static string[] elements;
    static void Main()
    {
        elements = Console.ReadLine().Split(' ').ToArray();
        //var arr = new int[elements.Length];
        //string[] arr = { "apple", "banana", "orange" };
        GeneratePermutations(0);
    }

    static void GeneratePermutations(int index)
    {
        if (index >= elements.Length)
        {
            Print(elements);
        }
        else
        {
            GeneratePermutations(index + 1);
            var used = new HashSet<string>();
            used.Add(elements[index]);
            for (int i = index + 1; i < elements.Length; i++)
            {
                if (!used.Contains(elements[i]))
                {
                    used.Add(elements[i]);
                    Swap(ref elements[index], ref elements[i]);
                    GeneratePermutations(index + 1);
                    Swap(ref elements[index], ref elements[i]);
                }
            }
        }
    }

    static void Print<T>(T[] arr)
    {
        Console.WriteLine(string.Join(" ", arr));
    }

    static void Swap<T>(ref T first, ref T second)
    {
        T oldFirst = first;
        first = second;
        second = oldFirst;
    }
}
