using System;
using System.Collections.Generic;


namespace graph
{
    /// <summary>Represents a directed unweighted graph structure</summary>
    public class Graph
    {
        // Contains the child nodes for each vertex of the graph assuming the vertices are numbered 0 ... N-1
        private List<int>[] childNodes;

        /// <summary>Constructs an empty graph of given size</summary>
        /// <param name="size">number of vertices</param>

        public Graph(int size)
        {
            this.childNodes = new List<int>[size];
            for (int i = 0; i < size; i++)
            {
                //Assuming an empty list of adjacents for each vertex
                this.childNodes[i] = new List<int>();
            }
        }

        /// <summary>constructs a graph by a given list of child nodes(successors) for each vertex</summary>
        /// <param name="childNodes">children for each node</param>

        public Graph(List<int>[] childNodes)
        {
            this.childNodes = childNodes;
        }

        /// <summary>Returns the size of the graph (number of vertices)</summary>
        public int Size
        {
            get
            {
                return this.childNodes.Length;
            }
        }

        /// <summary>Adds new edge from u to v<summary>
        /// <param name="u">the starting vertex<param>
        /// <param name="v">the ending vertex</param>
        public void AddEdge(int u, int v)
        {
            childNodes[u].Add(v);
        }

        /// <summary>Removes the edge from u to v if such exists</summary>
        /// <param name="u">the starting vertex</param>
        /// <param name="v">the ending vertex</param>

        public void RemoveEdge(int u, int v)
        {
            childNodes[u].Remove(v);
        }

        /// <summary>Checks whether there is an edge between vertex u and v</summary>
        /// <param name="u">the starting vertex</param>
        /// <param name="v">the ending vertex</param>
        /// <returns> true is there is an edge between vertex u and vertex v </returns>

        public bool HasEdge(int u, int v)
        {
            bool hasEdge = childNodes[u].Contains(v);
            return hasEdge;
        }

        /// <summary>Returns the successors of a given vertex</summary>
        /// <param name="v">the vertex</param>
        /// <returns>list of all successors of vertex v</returns>
        public IList<int> GetSuccessors(int v)
        {
            return childNodes[v];
        }
    }
}