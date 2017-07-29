namespace Kurskal
{
    using System;
    using System.Collections.Generic;

    public class KruskalAlgorithm
    {
        public static List<Edge> Kruskal(int numberOfVertices, List<Edge> edges)
        {
            var parent = new int[numberOfVertices];
            for (int i = 0; i < numberOfVertices; i++)
            {
                parent[i] = i;
            }
            edges.Sort();
            // Kruskal's algorithm
            var spanningTree = new List<Edge>();
            foreach (var edge in edges)
            {
                int rootStartNode = FindRoot(edge.StartNode, parent);
                int rootEndNode = FindRoot(edge.EndNode, parent);
                if (rootStartNode != rootEndNode) // No cycle
                {
                    spanningTree.Add(edge);
                    parent[rootStartNode] = rootEndNode;
                }
            }
            return spanningTree;
        }

        public static int FindRoot(int node, int[] parent)
        {
            // Find the root for the node
            int root = node;
            while (parent[root] != root)
            {
                root = parent[root];
            }

            return root;
        }
    }
}
