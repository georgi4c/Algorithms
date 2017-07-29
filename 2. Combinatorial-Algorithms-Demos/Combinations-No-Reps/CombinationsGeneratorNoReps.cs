using System;
using System.Linq;

class CombinationsGeneratorNoReps
{
    private static int k;
    const int n = 5;

    private static string[] elements;
	//{
	//	"banana", "apple", "orange", "strawberry", "raspberry"
	//};
	static string[] arr;

	static void Main()
	{
	    elements = Console.ReadLine().Split(' ').ToArray();
	    k = int.Parse(Console.ReadLine());
        arr = new string[k];

        GenerateCombinationsNoRepetitions(0, 0);
	}

	static void GenerateCombinationsNoRepetitions(int index, int start)
	{
		if (index >= k)
		{
            PrintCombinations();
		}
		else
		{
			for (int i = start; i < elements.Length; i++)
			{
				arr[index] = elements[i];
				GenerateCombinationsNoRepetitions(index + 1, i + 1);
			}
		}
	}

    static void PrintCombinations()
    {
        Console.WriteLine(string.Join(" ", arr));
    }
}
