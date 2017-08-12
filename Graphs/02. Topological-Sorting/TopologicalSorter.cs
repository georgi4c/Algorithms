using System;
using System.Collections.Generic;
using System.Linq;

public class TopologicalSorter
{
    private Dictionary<string, List<string>> graph;
    private Dictionary<string, int> predecessorCount;
    private HashSet<string> visited;
    private HashSet<string> cycleNodes;

    public TopologicalSorter(Dictionary<string, List<string>> graph)
    {
        this.graph = graph;
    }

    public ICollection<string> TopSort()
    {
        LinkedList<string> sorted = new LinkedList<string>();
        visited = new HashSet<string>();
        cycleNodes = new HashSet<string>();
        foreach (var node in graph.Keys)
        {
            DFS(node, sorted);
        }
        
        return sorted;
    }

    private void DFS(string node, LinkedList<string> result)
    {
        if (cycleNodes.Contains(node))
        {
            throw new InvalidOperationException("Cycle detected.");
        }
        if (!visited.Contains(node))
        {
            visited.Add(node);
            cycleNodes.Add(node);
            
            foreach (var child in graph[node])
            {
                
                DFS(child, result);
                
            }
            
            cycleNodes.Remove(node);
            result.AddFirst(node);
        }
    }

    public ICollection<string> SourceRemovalTopSort()
    {
        predecessorCount = new Dictionary<string, int>();
        List<string> sorted = new List<string>();
        GetPredecessorCount();
        while (true)
        {
            string nodeToRemove = graph.Keys
                .FirstOrDefault(x => predecessorCount[x] == 0);
            if (nodeToRemove == null)
            {
                break;
            }
            foreach (var childNode in graph[nodeToRemove])
            {

                predecessorCount[childNode]--;

            }
            graph.Remove(nodeToRemove);
            sorted.Add(nodeToRemove);
        }
        if (graph.Count > 0)
        {
            throw new InvalidOperationException();
        }
        return sorted;
    }

    private void GetPredecessorCount()
    {

        foreach (var node in this.graph)
        {
            if (!predecessorCount.ContainsKey(node.Key))
            {
                predecessorCount[node.Key] = 0;
            }

            foreach (var child in node.Value)
            {
                if (!predecessorCount.ContainsKey(child))
                {
                    predecessorCount[child] = 0;
                }

                predecessorCount[child]++;
            }
        }
    }
}
