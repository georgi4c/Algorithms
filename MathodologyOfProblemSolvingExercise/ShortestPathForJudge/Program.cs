using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class Program
{
    static void Main(string[] args)
    {
        int rows = int.Parse(Console.ReadLine());
        int cols = int.Parse(Console.ReadLine());
        if (cols == 1 && rows == 1)
        {
            var n = int.Parse(Console.ReadLine());
            Console.WriteLine($"Length: {n}");
            Console.WriteLine($"Path: {n}");
        }
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
                    graph[currNode][otherNode] = points;
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
public static class DijkstraWithPriorityQueue
{
    public static List<int> DijkstraAlgorithm(Dictionary<Node, Dictionary<Node, int>> graph, Dictionary<int, Node> nodes, int sourceNode, int destinationNode)
    {
        int[] previous = new int[graph.Count];
        bool[] visited = new bool[graph.Count];
        PriorityQueue<Node> priorityQueue = new PriorityQueue<Node>();
        var startNode = nodes[sourceNode];
        startNode.DistanceFromStart = 0;

        for (int i = 0; i < previous.Length; i++)
        {
            previous[i] = -1;
        }

        priorityQueue.Enqueue(startNode);

        while (priorityQueue.Count > 0)
        {
            var currentNode = priorityQueue.ExtractMin();

            if (currentNode.Index == destinationNode)
            {
                break;
            }

            foreach (var edge in graph[currentNode])
            {
                if (!visited[edge.Key.Index])
                {
                    priorityQueue.Enqueue(edge.Key);
                    visited[edge.Key.Index] = true;
                }

                var distance = currentNode.DistanceFromStart + edge.Value;
                if (distance < edge.Key.DistanceFromStart)
                {
                    edge.Key.DistanceFromStart = distance;
                    previous[edge.Key.Index] = currentNode.Index;
                    priorityQueue.DecreaseKey(edge.Key);
                }
            }
        }

        if (previous[destinationNode] == -1)
        {
            return null;
        }

        List<int> path = new List<int>();
        int current = destinationNode;
        while (current != -1)
        {
            path.Add(current);
            current = previous[current];
        }

        path.Reverse();
        return path;
    }
}
public class Node : IComparable<Node>
{
    public Node(int index, int distance = int.MaxValue)
    {
        this.Index = index;
        this.DistanceFromStart = distance;
    }

    public int Index { get; set; }

    public int DistanceFromStart { get; set; }

    public int Points { get; set; }

    public int CompareTo(Node other)
    {
        int cmpDistance = this.DistanceFromStart.CompareTo(other.DistanceFromStart);
        if (cmpDistance == 0)
        {
            return this.Index.CompareTo(other.Index);
        }
        return cmpDistance;
    }

    public override string ToString()
    {
        return this.Index.ToString();
    }
}
public class PriorityQueue<T> where T : IComparable<T>
{
    private Dictionary<T, int> searchCollection;
    private List<T> heap;

    public PriorityQueue()
    {
        this.heap = new List<T>();
        this.searchCollection = new Dictionary<T, int>();
    }

    public int Count
    {
        get
        {
            return this.heap.Count;
        }
    }

    public T ExtractMin()
    {
        var min = this.heap[0];
        var last = this.heap[this.heap.Count - 1];
        this.searchCollection[last] = 0;
        this.heap[0] = last;
        this.heap.RemoveAt(this.heap.Count - 1);
        if (this.heap.Count > 0)
        {
            this.HeapifyDown(0);
        }

        this.searchCollection.Remove(min);

        return min;
    }

    public T PeekMin()
    {
        return this.heap[0];
    }

    public void Enqueue(T element)
    {
        this.searchCollection.Add(element, this.heap.Count);
        this.heap.Add(element);
        this.HeapifyUp(this.heap.Count - 1);
    }

    private void HeapifyDown(int i)
    {
        var left = (2 * i) + 1;
        var right = (2 * i) + 2;
        var smallest = i;

        if (left < this.heap.Count && this.heap[left].CompareTo(this.heap[smallest]) < 0)
        {
            smallest = left;
        }

        if (right < this.heap.Count && this.heap[right].CompareTo(this.heap[smallest]) < 0)
        {
            smallest = right;
        }

        if (smallest != i)
        {
            T old = this.heap[i];
            this.searchCollection[old] = smallest;
            this.searchCollection[this.heap[smallest]] = i;
            this.heap[i] = this.heap[smallest];
            this.heap[smallest] = old;
            this.HeapifyDown(smallest);
        }
    }

    private void HeapifyUp(int i)
    {
        var parent = (i - 1) / 2;
        while (i > 0 && this.heap[i].CompareTo(this.heap[parent]) < 0)
        {
            T old = this.heap[i];
            this.searchCollection[old] = parent;
            this.searchCollection[this.heap[parent]] = i;
            this.heap[i] = this.heap[parent];
            this.heap[parent] = old;

            i = parent;
            parent = (i - 1) / 2;
        }
    }

    public void DecreaseKey(T element)
    {
        int index = this.searchCollection[element];
        this.HeapifyUp(index);
    }
}


