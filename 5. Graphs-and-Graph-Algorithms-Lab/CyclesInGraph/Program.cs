using System;
using System.Collections.Generic;
using System.Linq;

public class TopologicalSorter
{
    private Dictionary<string, List<string>> graph;
    private HashSet<string> visitedNodes;
    private HashSet<string> cycleNodes;
    private LinkedList<string> sortedNodes;

    public TopologicalSorter(Dictionary<string, List<string>> graph)
    {
        this.graph = graph;
    }

    public void TopSort()
    {
        //Find the predecessorsCount
       var predecessorsCount = new Dictionary<string, int>();
        foreach (var node in this.graph)
        {
            
            predecessorsCount[node.Key] = node.Value.Count;
        }

        var removedNodes = new List<string>();
        while (true)
        {
            string nodeToRemove = graph.Keys.FirstOrDefault(n => predecessorsCount[n] == 1);

            if (nodeToRemove == null)
            {
                break;
            }

            var childNode = graph[nodeToRemove][0];
            graph[childNode].Remove(nodeToRemove);
            predecessorsCount[nodeToRemove]--;
            predecessorsCount[childNode]--;
            
            graph.Remove(nodeToRemove);
            removedNodes.Add(nodeToRemove);
        }
        foreach (var item in graph)
        {
            Console.WriteLine($"{item.Key}    {string.Join(", ", item.Value)}");
        }
        if (graph.Count > 1)
        {
            Console.WriteLine("Acyclic: No");
        }
        else
        {
            Console.WriteLine("Acyclic: Yes");
        }
        


    }
    static void Main()
    {
        //var graph = new Dictionary<string, List<string>>()
        //{
        //    { "IDEs", new List<string>() { "variables", "loops" } },
        //    { "variables", new List<string>() { "conditionals", "loops", "bits" } },
        //    { "loops", new List<string>() { "bits" } },
        //    { "conditionals", new List<string>() { "loops" } },
        //};

        var graph = new Dictionary<string, List<string>>() {
            { "A", new List<string>() { "B", "C" } },
            { "B", new List<string>() { "D", "E", "A" } },
            { "C", new List<string>() { "A", "F" } },
            { "D", new List<string>() { "F", "B" } },
            { "E", new List<string>() { "B" } },
            { "F", new List<string>() { "D", "C"} },
        };

        var topSorter = new TopologicalSorter(graph);
        topSorter.TopSort();

        //Console.WriteLine("Topological sorting: {0}",
        //    string.Join(", ", sortedNodes));

        // Topological sorting: A, B, E, D, C, F
    }


}
