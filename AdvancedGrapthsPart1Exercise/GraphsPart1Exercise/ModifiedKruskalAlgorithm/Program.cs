using System;
using System.Collections.Generic;
using System.Linq;

namespace ModifiedKruskalAlgorithm
{
    class ModifiedKruskalAlgorithm
    {
        static void Main()
        {
            int nodesCount = int.Parse(Console.ReadLine().Split(':').Select(x => x.Trim()).Skip(1).First());
            int edgesCount = int.Parse(Console.ReadLine().Split(':').Select(x => x.Trim()).Skip(1).First());

            var edges = new List<Edge>();
            for (int i = 0; i < edgesCount; i++)
            {
                string[] input = Console.ReadLine().Split(' ');
                Edge edge = new Edge(int.Parse(input[0]), int.Parse(input[1]), int.Parse(input[2]));
                edges.Add(edge);
            }

            List<Edge> minSpaningTree = Kruskal(nodesCount, edges);
            int weight = minSpaningTree.Sum(n => n.Weight);

            Console.WriteLine("Minimum spanning forest weight: {0}", weight);
            //Console.WriteLine(string.Join("\n", minSpaningTree));
        }

        private static List<Edge> Kruskal(int nodesCount, List<Edge> edges)
        {
            edges.Sort();
            var parrent = new int[nodesCount];
            for (int i = 0; i < nodesCount; i++)
            {
                parrent[i] = i;
            }

            var minSpaningTree = new List<Edge>();
            foreach (var edge in edges)
            {
                int rootStartNode = FindRoot(edge.StartNode, parrent);
                int rootEndNode = FindRoot(edge.EndNode, parrent);
                if (rootStartNode != rootEndNode)
                {
                    minSpaningTree.Add(edge);
                    parrent[rootEndNode] = rootStartNode;
                }
            }

            return minSpaningTree;
        }

        private static int FindRoot(int node, int[] parrent)
        {
            int root = node;
            while (parrent[root] != root)
            {
                root = parrent[root];
            }

            while (node != root)
            {
                int oldParrent = parrent[node];
                parrent[node] = root;
                node = oldParrent;
            }

            return root;
        }
    }
}