using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lumber
{
    class Program
    {
        private static int count;
        static void Main(string[] args)
        {
            var input1 = Console.ReadLine().Split(' ').Select(int.Parse).ToList();
            var logsCount = input1[0];
            var queriesCount = input1[1];
            var logs = new List<Log>();
            var graph = new List<int>[logsCount + 1];
            for (int i = 1; i <= logsCount; i++)
            {
                var input2 = Console.ReadLine().Split(' ').Select(int.Parse).ToList();
                Log log = new Log(i, input2[0], input2[1], input2[2], input2[3]);

                graph[i] = new List<int>();
                foreach (var element in logs)
                {
                    if (element.Intersects(log))
                    {
                        graph[element.Id].Add(i);
                        graph[i].Add(element.Id);
                    }
                }
                logs.Add(log);
            }

            bool[] marked = new bool[logsCount + 1];
            int[] id = new int[logsCount + 1];
            count = 0;
            for (int v = 1; v <= logsCount; v++)
            {
                if (!marked[v])
                {
                    DFS(v, marked, id, graph);
                    count++;
                }
            }


            for (int i = 0; i < queriesCount; i++)
            {
                var input3 = Console.ReadLine().Split(' ').Select(int.Parse).ToList();
                int from = input3[0];
                int to = input3[1];

                Console.WriteLine(id[from] == id[to] ? "YES" : "NO");

            }
        }

        private static void DFS(int vertex, bool[] marked,int[] id, List<int>[] graph)
        {
            marked[vertex] = true;
            id[vertex] = count;
            foreach (var child in graph[vertex])
            {
                if (!marked[child])
                {
                    DFS(child, marked, id, graph);
                }
            }
        }
    }

    public class Log
    {
        public Log(int id, int x1, int y1, int x2, int y2)
        {
            Id = id;
            X1 = x1;
            Y1 = y1;
            X2 = x2;
            Y2 = y2;
        }

        public int Id { get; set; }
        public int X1 { get; set; }
        public int Y1 { get; set; }
        public int X2 { get; set; }
        public int Y2 { get; set; }

        public bool Intersects(Log other)
        {
            bool horizontalIntersect = this.X1 <= other.X2 && this.X2 >= other.X1;
            bool verticalIntersect = this.Y1 >= other.Y2 && this.Y2 <= other.Y1;

            return horizontalIntersect && verticalIntersect;
        }
    }
}
