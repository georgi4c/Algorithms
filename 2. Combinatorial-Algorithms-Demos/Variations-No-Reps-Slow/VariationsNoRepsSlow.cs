using System;
using System.Linq;

class VariationsNoRepsSlow
{
    private static int k;

    private static string[] elements; 
	//{
	//	"banana", "apple", "orange", "strawberry", "raspberry",
	//	"apricot", "cherry", "lemon", "grapes", "melon"
	//};
	static string[] arr;

    private static bool[] used;

	static void Main()
	{
        elements = Console.ReadLine().Split(' ').ToArray();
	    k = int.Parse(Console.ReadLine());
        arr = new string[k];
	    used = new bool[elements.Length];

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
			for (int i = 0; i < elements.Length; i++)
			{
				if (!used[i])
				{
					used[i] = true;
					arr[index] = elements[i];
					GenerateVariationsNoRepetitions(index + 1);
					used[i] = false;
				}
			}
		}
	}

    static void PrintVariations()
    {
        Console.WriteLine(string.Join(" ", arr));
    }
}
