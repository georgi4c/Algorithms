using System;
using System.Collections.Generic;
using System.Linq;

public class EdmondsKarp
{
    private static int[][] graph;
    private static int[] parents;

    public static int FindMaxFlow(int[][] targetGraph)
    {
        graph = targetGraph;
        parents = new int[graph.Length];

        //reset parents
        for (int i = 0; i < graph.Length; i++)
        {
            parents[i] = -1;
        }

        int maxFlow = 0;
        int start = 0;
        int end = graph.Length - 1;
        while (BFS(start, end))
        {
            int pathFlow = int.MaxValue;
            int currentNode = end;
            while (currentNode != start)
            {
                int previousNode = parents[currentNode];
                if (graph[previousNode][currentNode] < pathFlow)
                {
                    pathFlow = graph[previousNode][currentNode];
                }
                currentNode = previousNode;
            }

            maxFlow += pathFlow;
            currentNode = end;
            while (currentNode != start)
            {
                int previousNode = parents[currentNode];
                graph[previousNode][currentNode] -= pathFlow;
                graph[currentNode][previousNode] += pathFlow;
                currentNode = previousNode;
            }
        }
        return maxFlow;

    }

    private static bool BFS(int start, int end)
    {
        bool[] visited = new bool[graph.Length];
        var queue = new Queue<int>();
        queue.Enqueue(start);
        visited[start] = true;
        while (queue.Count > 0)
        {
            var currentNode = queue.Dequeue();
            for (int i = 0; i < graph.Length; i++)
            {
                // Possible mistake!!!
                if (graph[currentNode][i] != 0 && !visited[i])
                {
                    queue.Enqueue(i);
                    parents[i] = currentNode;
                    visited[i] = true;
                }
            }
        }


        return visited[end];
    }
}
