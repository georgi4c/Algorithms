using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShortestPathInMatrix
{
    class Program
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());
            int cols = int.Parse(Console.ReadLine());
            var nodes = new Dictionary<int, Node>();

            for (int i = 0; i < rows * cols; i++)
            {
                nodes.Add(i, new Node(i));
            }
            var graph = new Dictionary<Node, Dictionary<Node, int>>();
            for (int i = 0; i < rows * cols; i++)
            {
                graph[nodes[i]] = new Dictionary<Node, int>();
            }

            for (int i = 0; i < rows; i++)
            {
                var inputRowElements = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
                for (int j = 0; j < cols; j++)
                {
                    int currentNum = j + cols * i;
                    var currNode = nodes[currentNum];
                    currNode.Points = inputRowElements[j];
                    if (i > 0)
                    {
                        var otherNode = nodes[currentNum - cols];

                        int points = otherNode.Points + currNode.Points;
                        graph[currNode][otherNode] =  points;
                        graph[otherNode][currNode] = points;
                    }
                    if (i < rows - 1)
                    {
                        var otherNode = nodes[currentNum + cols];

                        int points = otherNode.Points + currNode.Points;
                        graph[currNode][otherNode] = points;
                        graph[otherNode][currNode] = points;
                    }
                    if (j > 0)
                    {
                        var otherNode = nodes[currentNum - 1];

                        int points = otherNode.Points + currNode.Points;
                        graph[currNode][otherNode] = points;
                        graph[otherNode][currNode] = points;
                    }
                    if (j < cols - 1)
                    {
                        var otherNode = nodes[currentNum + 1];

                        int points = otherNode.Points + currNode.Points;
                        graph[currNode][otherNode] = points;
                        graph[otherNode][currNode] = points;
                    }
                }
            }

            var path = DijkstraWithPriorityQueue
                .DijkstraAlgorithm(graph, nodes, 0, rows * cols - 1)
                .Select(x => nodes[x].Points).ToArray();

            Console.WriteLine($"Length: {path.Sum()}");
            Console.WriteLine($"Path: {string.Join(" ", path)}");
        }
    }
}
