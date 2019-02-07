using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructuresAndAlgorithms.Graphs
{
    public class Node<T>:IComparable<Node<T>>
    {
        public int Index { get; set; }
        public T Data { get; set; }
        public int Key { get; set; }
       

        public List<Node<T>> Neighbours { get; set; } = new List<Node<T>>();
        public List<int> Weights { get; set; } = new List<int>();

        public int CompareTo(Node<T> other)
        {
            return this.Key - other.Key;
        }

        public List<Edge<T>> GetEdges()
        {
            List<Edge<T>> edges = new List<Edge<T>>();
            for (int i = 0; i < this.Neighbours.Count; i++)
            {
                Edge<T> edge = new Edge<T>()
                {
                    From = this,
                    To = this.Neighbours[i],
                    Weight = i < this.Neighbours.Count ? this.Weights[i] : 0
                };

                edges.Add(edge);
            }

            return edges;
        }

        public override string ToString()
        {
            return $"Node with index {Index} : {Data}, neighbors: {Neighbours.Count}";
        }

       
    }
}
