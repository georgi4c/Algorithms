using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CableNetwork
{
    class Program
    {
        private static bool[,] oldConnection;
        private static HashSet<int> usedNodes = new HashSet<int>();
        private static int budget;
        private static int nodes;
        private static int edges;
        private static Dictionary<int, List<Edge>> graph;
        private static int budgetUsed = 0;

        static void Main()
        {
            budget = int.Parse(Console.ReadLine().Split(':').Select(x => x.Trim()).Skip(1).First());
            nodes = int.Parse(Console.ReadLine().Split(':').Select(x => x.Trim()).Skip(1).First());
            edges = int.Parse(Console.ReadLine().Split(':').Select(x => x.Trim()).Skip(1).First());
            oldConnection = new bool[nodes, nodes];
            BuildGraph();
            
            Prim();
            
        }

        private static void Prim()
        {

            var priorityQueue = new PriorityQueue<Edge>();
            var usedEdges = new HashSet<Edge>();
            
            for (int rowIndex = 0; rowIndex < oldConnection.GetLength(0); rowIndex++)
            {
                for (int colIndex = 0; colIndex < oldConnection.GetLength(1); colIndex++)
                {
                    if (oldConnection[rowIndex, colIndex])
                    {
                        foreach (var edge in graph[rowIndex])
                        {
                            if (!oldConnection[edge.StartNode, edge.EndNode])
                            {
                                usedEdges.Add(edge);

                            }
                        }
                    }
                }
            }
            foreach (var usedEdge in usedEdges)
            {
                priorityQueue.Enqueue(usedEdge);
            }

            while (priorityQueue.Count > 0)
            {
                var smallestEdge = priorityQueue.ExtractMin();
                if (usedNodes.Contains(smallestEdge.StartNode) && usedNodes.Contains(smallestEdge.EndNode))
                {
                    continue;
                }
                usedNodes.Add(smallestEdge.StartNode);
                usedNodes.Add(smallestEdge.EndNode);
                var newBudget = budget - smallestEdge.Weight;

                if (newBudget < 0)
                {
                    break;
                }
                budgetUsed += smallestEdge.Weight;
                budget = newBudget;

                foreach (var edge in graph[smallestEdge.StartNode])
                {
                    if (!oldConnection[edge.StartNode, edge.EndNode] && !usedEdges.Contains(edge))
                    {
                        priorityQueue.Enqueue(edge);
                        usedEdges.Add(edge);

                    }
                }
                foreach (var edge in graph[smallestEdge.EndNode])
                {
                    if (!oldConnection[edge.StartNode, edge.EndNode] && !usedEdges.Contains(edge))
                    {
                        priorityQueue.Enqueue(edge);
                        usedEdges.Add(edge);

                    }
                }

            }
            Console.WriteLine($"Budget used: {budgetUsed}");
        }

        static void BuildGraph()
        {
            graph = new Dictionary<int, List<Edge>>();

            for (int i = 0; i < edges; i++)
            {
                var line = Console.ReadLine().Split(' ').ToList();
                int startNode = int.Parse(line[0]);
                int endNode = int.Parse(line[1]);
                int cost = int.Parse(line[2]);
                if (line.Count > 3)
                {
                    usedNodes.Add(startNode);
                    usedNodes.Add(endNode);
                    oldConnection[startNode, endNode] = true;
                    oldConnection[endNode, startNode] = true;
                }
                var edge = new Edge(startNode, endNode, cost);
                if (!graph.ContainsKey(edge.StartNode))
                {
                    graph.Add(edge.StartNode, new List<Edge>());
                }
                graph[edge.StartNode].Add(edge);
                if (!graph.ContainsKey(edge.EndNode))
                {
                    graph.Add(edge.EndNode, new List<Edge>());
                }
                graph[edge.EndNode].Add(edge);
            }
            
        }
    }
}
