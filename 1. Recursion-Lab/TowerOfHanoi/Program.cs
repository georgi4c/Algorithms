using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class TowerOfHanoi
{
    private static int stepsTaken = 0;


    static void Main(string[] args)
    {
        int numberOfDisks = 3;
        Stack<int> source = new Stack<int>(Enumerable.Range(1, numberOfDisks).Reverse());
        Stack<int> destination = new Stack<int>();
        Stack<int> spare = new Stack<int>();
        PrintRods(source, destination, spare);
        MoveDisks(numberOfDisks, source, destination, spare);

    }
    private static void MoveDisks(int bottomDisk, Stack<int> source, Stack<int> destination, Stack<int> spare)
    {
        if (bottomDisk == 1)
        {
            stepsTaken++;
            destination.Push(source.Pop());
            Console.WriteLine("Steps taken : {0}, Moved disk {1}", stepsTaken, bottomDisk);
            PrintRods(source, destination, spare);
        }
        else
        {
            stepsTaken++;
            MoveDisks(bottomDisk - 1, source, spare, destination);
            destination.Push(source.Pop());
            Console.WriteLine("Steps taken : {0}, Moved disk {1}", stepsTaken, bottomDisk);
            PrintRods(source, destination, spare);
            MoveDisks(bottomDisk - 1, spare, destination, source);
            Console.WriteLine("Steps taken : {0}, Moved disk {1}", stepsTaken, bottomDisk);
            PrintRods(source, destination, spare);
        }
    }
    private static void PrintRods(Stack<int> source, Stack<int> destination, Stack<int> spare)
    {
        Console.WriteLine("Source: {0}", String.Join(", ", source.Reverse()));
        Console.WriteLine("Spare: {0}", String.Join(", ", spare.Reverse()));
        Console.WriteLine("Destination: {0}", String.Join(", ", destination.Reverse()));
        Console.WriteLine();
    }
}