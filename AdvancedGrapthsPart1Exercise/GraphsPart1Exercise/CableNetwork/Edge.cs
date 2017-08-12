﻿using System;

public class Edge : IComparable<Edge>
{
    public int StartNode { get; set; }
    public int EndNode { get; set; }
    public int Weight { get; set; }

    public Edge(int startNode, int endNode, int weight)
    {
        this.StartNode = startNode;
        this.EndNode = endNode;
        this.Weight = weight;
    }

    public int CompareTo(Edge other)
    {
        int weightCompared = this.Weight.CompareTo(other.Weight);
        if (weightCompared == 0)
        {
            var startNodesComp = this.StartNode.CompareTo(other.StartNode);
            if (startNodesComp == 0)
            {
                return this.EndNode.CompareTo(other.EndNode);
            }
            return startNodesComp;
        }
        return weightCompared;
    }

    public override string ToString()
    {
        return string.Format("({0} {1}) -> {2}", 
            this.StartNode, this.EndNode, this.Weight);
    }
}
