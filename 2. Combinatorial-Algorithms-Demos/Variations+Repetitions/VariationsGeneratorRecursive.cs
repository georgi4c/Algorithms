using System;
using System.Linq;

class VariationsGeneratorRecursive
{
    private static int k;

    private static string[] elements; 
	//{
	//	"banana", "apple", "orange", "strawberry", "raspberry",
	//	"apricot", "cherry", "lemon", "grapes", "melon"
	//};
	static string[] arr;

	static void Main()
	{
        elements = Console.ReadLine().Split(' ').ToArray();
	    k = int.Parse(Console.ReadLine());
        arr = new string[k];
        GenerateVariationsWithRepetitions(0);
	}

	static void GenerateVariationsWithRepetitions(int index)
	{
		if (index >= k)
		{
			PrintVariations();
		}
		else
		{
			for (int i = 0; i < elements.Length; i++)
			{
				arr[index] = elements[i];
				GenerateVariationsWithRepetitions(index + 1);
			}
		}
	}

	static void PrintVariations()
	{
		Console.WriteLine(string.Join(" ", arr));
	}
}
