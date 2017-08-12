using System;

namespace ShortestPathInMatrix
{
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
            int cmpDistance =  this.DistanceFromStart.CompareTo(other.DistanceFromStart);
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
}
