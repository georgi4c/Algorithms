using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DistanceBetweenVertices
{
    class Program
    {
        static List<int>[] childNodes = new[] {
        new List<int> {},
        new List<int> {4},
        new List<int> {4},
        new List<int> {4, 5},
        new List<int> {6},
        new List<int> {3, 7, 8},
        new List<int> {},
        new List<int> {8},
        new List<int> {}
        };
        static int start = 5;
        static int end = 6;

        public static void TraverseBFS(int node)
        {
            var nodes = new Queue<int>();
            var visited = new int[childNodes.Length];
            for (int i = 0; i < visited.Length; i++)
            {
                visited[i] = -1;
            }
            int counter = 0;

            // Enqueue the start node to the queue
            visited[node] = 0;
            nodes.Enqueue(node);

            // Breadth-First Search (BFS)
            while (nodes.Count != 0)
            {
                int currentNode = nodes.Dequeue();

                if (currentNode == end)
                {
                    Console.WriteLine(visited[currentNode]);
                    return;
                }

                foreach (var childNode in childNodes[currentNode])
                {
                    if (visited[childNode] == -1)
                    {
                        nodes.Enqueue(childNode);
                        visited[childNode] = visited[currentNode]+1;
                    }

                }
            }
            Console.WriteLine("-1");
        }

        public static void Main()
        {
            // Start DFS from node 4 (Bourgas)
            TraverseBFS(start);
        }
    }
}
