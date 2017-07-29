using System;
using System.Linq;

class VariationsNoRepetitionsFast
{
    private static int k;
    static string[] arr;
    static string[] elements;

    static void Main()
    {
        elements = Console.ReadLine().Split(' ').ToArray();
        k = int.Parse(Console.ReadLine());
        arr = new string[k];
        GenerateVariationsNoRepetitions(0);
    }

    static void GenerateVariationsNoRepetitions(int index)
    {
        if (index >= k)
        {
            PrintVariations();
        }
        else
        {
            for (int i = index; i < elements.Length; i++)
            {
                arr[index] = elements[i];
                Swap(ref elements[i], ref elements[index]);
                GenerateVariationsNoRepetitions(index + 1);
                Swap(ref elements[i], ref elements[index]);
            }
        }
    }

    private static void Swap(ref string v1, ref string v2)
    {
        string old = v1;
        v1 = v2;
        v2 = old;
    }

    static void PrintVariations()
    {
        Console.WriteLine(string.Join(" ", arr));
    }
}
