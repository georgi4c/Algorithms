
    using System;
    using System.Collections.Generic;

    public class KruskalAlgorithm
    {
        public static List<Edge> Kruskal(int numberOfVertices, List<Edge> edges)
        {
            edges.Sort();
            // Initialize parents
            var parent = new int[numberOfVertices];
            for (int i = 0; i < numberOfVertices; i++)
            {
                parent[i] = i;
            }

            // Kruskal's algorithm
            var spanningTree = new List<Edge>();
            foreach (var edge in edges)
            {
                int rootStartNode = FindRoot(edge.StartNode, parent);
                int rootEndNode = FindRoot(edge.EndNode, parent);
                if (rootStartNode != rootEndNode)
                {
                    spanningTree.Add(edge);
                    parent[rootEndNode] = rootStartNode;
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

