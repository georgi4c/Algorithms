using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DistanceBetweenVerticesNew
{
    
    class Edge
    {
        public Edge(int parent, int child)
        {
            Parent = parent;
            Child = child;
        }
        public int Parent { get; set; }
        public int Child { get; set; }
    }

    class Program
    {
        
        private static List<Edge> edges;

        static void Main(string[] args)
        {
            var edgesCount = int.Parse(Console.ReadLine());
            var pairsCount = int.Parse(Console.ReadLine());
            edges = new List<Edge>();
            for (int i = 0; i < edgesCount; i++)
            {
                var input = Console.ReadLine().Split(':').ToArray();
                int parent = int.Parse(input[0]);
                var children = input[1]
                    .Split(new []{' '}, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();
                foreach (var child in children)
                {
                    edges.Add(new Edge(parent, child));
                }
            }
            for (int i = 0; i < pairsCount; i++)
            {
                var input = Console.ReadLine().Split('-').Select(int.Parse).ToArray();
                var start = input[0];
                var end = input[1];
                TraverseBFS(start, end);
            }
        }

        public static void TraverseBFS(int startNode, int endNode)
        {
            HashSet<int> used = new HashSet<int>();
            var nodes = new Queue<int>();
            int steps = 0;
            var parentDic = new Dictionary<int, int>();
            //if (currentNode == endNode)
            //{
            //    Console.WriteLine($"{{{startNode}, {endNode}}} -> {steps}");
            //}
            //var children = edges.Where(x => x.Parent == currentNode);
            //foreach (var element in children)
            //{
            //    int child = element.Child;
                
            //    if (!used.Contains(child))
            //    {
            //        used.Add(child);
            //        TraverseBFS(child, startNode, endNode, steps + 1);
            //        used.Remove(child);
            //    }
            //}
            nodes.Enqueue(startNode);
            
            while (nodes.Count > 0)
            {
                
                int currentNode = nodes.Dequeue();
                if (currentNode == endNode)
                {
                    int counter = 0;
                    int currentBack = endNode;
                    while (true)
                    {
                        if (!parentDic.ContainsKey(currentBack) || currentBack == startNode)
                        {
                            Console.WriteLine($"{{{startNode}, {endNode}}} -> {counter}");
                            return;
                        }
                        currentBack = parentDic[currentBack];
                        counter++;
                    }
                    
                }
                var children = edges.Where(x => x.Parent == currentNode);
                foreach (var child in children)
                {
                    if (!used.Contains(child.Child))
                    {
                        parentDic[child.Child] = currentNode;
                        used.Add(child.Child);
                        nodes.Enqueue(child.Child);
                    }
                }

                steps++;
            }
            Console.WriteLine($"{{{startNode}, {endNode}}} -> {-1}");
        }
    }
}
