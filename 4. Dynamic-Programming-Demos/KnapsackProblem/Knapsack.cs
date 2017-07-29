using System;
using System.Collections.Generic;
using System.Linq;

public class Item
{
    public string Name { get; set; }
    public int Weight { get; set; }
    public int Price { get; set; }
}

public class Knapsack
{
    static void Main()
    {
        var knapsackCapacity = int.Parse(Console.ReadLine());
        var items = new List<Item>();
        while (true)
        {
            var command = Console.ReadLine();
            if (command == "end")
            {
                break;
            }
            var parts = command.Split(' ').ToList();
            var item = new Item()
            {
                Weight = int.Parse(parts[1]),
                Price = int.Parse(parts[2]),
                Name = parts[0]
            };
            items.Add(item);
        }

        var itemsTaken = FillKnapsack(items, knapsackCapacity);
        Console.WriteLine("Total Weight: {0}", itemsTaken.Sum(i => i.Weight));
        Console.WriteLine("Total Value: {0}", itemsTaken.Sum(i => i.Price));
        foreach (var item in itemsTaken)
        {
            Console.WriteLine(item.Name);
        }
       
    }

    public static List<Item> FillKnapsack(List<Item> items, int capacity)
    {
        var maxPrice = new int[items.Count, capacity + 1];
        var isItemTaken = new bool[items.Count, capacity + 1];

        // Calculate maxPrice[0, 0...capacity]
        for (int c = 0; c <= capacity; c++)
        {
            if (items[0].Weight <= c)
            {
                maxPrice[0, c] = items[0].Price;
                isItemTaken[0, c] = true;
            }
        }

        // Calculate maxPrice[1...len(items), 0...capacity]
        for (int i = 1; i < items.Count; i++)
        {
            for (int c = 0; c <= capacity; c++)
            {
                // Don't take item i
                maxPrice[i, c] = maxPrice[i - 1, c];

                // Try to take item i (if it gives better price)
                var remainingCapacity = c - items[i].Weight;
                if (remainingCapacity >= 0 &&
                    maxPrice[i - 1, remainingCapacity] + items[i].Price > maxPrice[i - 1, c])
                {
                    maxPrice[i, c] = maxPrice[i - 1, remainingCapacity] + items[i].Price;
                    isItemTaken[i, c] = true;
                }
            }
        }

        // Print the takenItems
        var itemsTaken = new List<Item>();
        int itemIndex = items.Count - 1;
        while (itemIndex >= 0)
        {
            if (isItemTaken[itemIndex, capacity])
            {
                itemsTaken.Add(items[itemIndex]);
                capacity -= items[itemIndex].Weight;
            }
            itemIndex--;
        }
        itemsTaken.Reverse();

        return itemsTaken.ToList();
    }
}
