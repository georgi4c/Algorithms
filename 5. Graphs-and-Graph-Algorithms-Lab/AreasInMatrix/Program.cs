using System;
using System.Collections.Generic;
using System.Linq;

public class GraphConnectedComponents
{
    static bool[,] visited;

    static char[,] numbers = new char[6, 8] { { 'a', 'a', 'c', 'c', 'c', 'a', 'a', 'c' },
{'b', 'a', 'a', 'a', 'a', 'c', 'c', 'c' }, { 'b', 'a', 'a', 'b', 'a', 'c', 'c', 'c' }, { 'b', 'b', 'd', 'a', 'a', 'c', 'c', 'c' }, { 'c', 'c', 'd', 'c', 'c', 'c', 'c', 'c' }, { 'c', 'c', 'd', 'c', 'c', 'c', 'c', 'c' }};

    static void DFS(int row, int col, char currentChar)
    {
        if (!visited[row, col])
        {
            visited[row, col] = true;
            int up = row - 1;
            int down = row + 1;
            int left = col - 1;
            int right = col + 1;
            if (up >= 0 && numbers[up, col] == currentChar)
            {
                DFS(up, col, currentChar);
            }
            if (down < numbers.GetLength(0) && numbers[down, col] == currentChar)
            {
                DFS(down, col, currentChar);
            }
            if (left >= 0 && numbers[row, left] == currentChar)
            {
                DFS(row, left, currentChar);
            }
            if (right < numbers.GetLength(1) && numbers[row, right] == currentChar)
            {
                DFS(row, right, currentChar);
            }

        }
    }


    public static void Main()
    {
        int areas = 0;
        var counter = new SortedDictionary<char, int>();
        visited = new bool[6, 8];

        for (int row = 0; row < numbers.GetLength(0); row++)
        {
            for (int col = 0; col < numbers.GetLength(1); col++)
            {
                if (!visited[row, col])
                {
                    if(!counter.ContainsKey(numbers[row, col]))
                    {
                        counter[numbers[row, col]] = 0;
                    }
                    areas++;
                    counter[numbers[row, col]]++;
                    DFS(row, col, numbers[row, col]);
                }
            }
        }
        Console.WriteLine($"Areas: {areas}");
        foreach (var item in counter)
        {
            Console.WriteLine($"Letter '{item.Key}' -> {item.Value}");
        }

    }


    
}
