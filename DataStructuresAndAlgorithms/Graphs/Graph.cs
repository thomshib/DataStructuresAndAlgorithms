using DataStructuresAndAlgorithms.Tree;
using System;
using System.Collections.Generic;
using System.Text;
using Priority_Queue;

namespace DataStructuresAndAlgorithms.Graphs
{
    public class Graph<T>
    {
        private bool _isDirected = false;
        private bool _isWeighted = false;

        public List<Node<T>> Nodes { get; set; } = new List<Node<T>>();

        public Graph(bool isDirected, bool isWeighted)
        {
            _isDirected = isDirected;
            _isWeighted = isWeighted;
        }


        public Edge<T> this[int from, int to]
        {
            get
            {
                Node<T> nodeFrom = Nodes[from];
                Node<T> nodeTo = Nodes[to];

                int i = nodeFrom.Neighbours.IndexOf(nodeTo);

                if (i >= 0)
                {
                    Edge<T> edge = new Edge<T>()
                    {
                        From = nodeFrom,
                        To = nodeTo,
                        Weight = i < nodeFrom.Weights.Count ? nodeFrom.Weights[i] : 0
                    };

                    return edge;
                }

                return null;

            }
        }

        public Node<T> AddNode(T value)
        {
            Node<T> node = new Node<T>() { Data = value };
            Nodes.Add(node);
            UpdateIndices();
            return node;
        }

        public void RemoveNode(Node<T> nodeToRemove)
        {
            Nodes.Remove(nodeToRemove);
            UpdateIndices();
            foreach (Node<T> node in Nodes)
            {
                RemoveEdge(node, nodeToRemove);
            }
        }

        public void AddEdge(Node<T> from, Node<T> to, int weight = 0)
        {
            from.Neighbours.Add(to);
            if (_isWeighted)
            {
                from.Weights.Add(weight);
            }

            if (!_isDirected)
            {
                to.Neighbours.Add(from);
                if (_isWeighted)
                {
                    to.Weights.Add(weight);
                }
            }
        }

        private void RemoveEdge(Node<T> from, Node<T> nodeToRemove)
        {
            int index = from.Neighbours.FindIndex(n => n == nodeToRemove);

            if (index >= 0)
            {
                from.Neighbours.RemoveAt(index);
                if (_isWeighted)
                {
                    from.Weights.RemoveAt(index);
                }
            }
        }

        public List<Edge<T>> GetEdges()
        {
            List<Edge<T>> edges = new List<Edge<T>>();

            foreach (Node<T> from in Nodes)
            {
                for (int i = 0; i < from.Neighbours.Count; i++)
                {
                    Edge<T> edge = new Edge<T>()
                    {
                        From = from,
                        To = from.Neighbours[i],
                        Weight = i < from.Neighbours.Count ? from.Weights[i] : 0
                    };

                    edges.Add(edge);
                }
            }
            return edges;

        }



        private void UpdateIndices()
        {
            int i = 0;
            Nodes.ForEach(n => n.Index = i++);
        }


        #region Traversal

        public List<Node<T>> DFS()
        {
            List<Node<T>> result = new List<Node<T>>();
            bool[] isVisited = new bool[Nodes.Count];

            DFS(isVisited, Nodes[0], result);
            return result;

        }

        private void DFS(bool[] isVisited, Node<T> node, List<Node<T>> result)
        {
            result.Add(node);
            isVisited[node.Index] = true;

            foreach (Node<T> neighbor in node.Neighbours)
            {
                if (!isVisited[neighbor.Index])
                {
                    DFS(isVisited, neighbor, result);
                }
            }
        }

        public List<Node<T>> BFS()
        {
            return BFS(Nodes[0]);
        }

        private List<Node<T>> BFS(Node<T> node)
        {
            bool[] isVisited = new bool[Nodes.Count];
            List<Node<T>> result = new List<Node<T>>();
            Queue<Node<T>> que = new Queue<Node<T>>();

            que.Enqueue(node);

            isVisited[node.Index] = true;
            while (que.Count > 0)
            {
                Node<T> next = que.Dequeue();

                result.Add(next);
                foreach (var neighbor in next.Neighbours)
                {
                    if (!isVisited[neighbor.Index])
                    {
                        isVisited[neighbor.Index] = true;
                        que.Enqueue(neighbor);
                    }
                }

            }



            return result;
        }

        #endregion

        #region Spanning Trees

        public List<Edge<T>> MinimunSpanningTreeKruskal()
        {
            /*
                1.Sort all the edges in non - decreasing order of their weight.
                2.Pick the smallest edge.Check if it forms a cycle with the spanning tree formed so far. 
                If cycle is not formed, include this edge.Else, discard it.
                3.Repeat step#2 until there are (V-1) edges in the spanning tree.
            */
            List<Edge<T>> result = new List<Edge<T>>();

            List<Edge<T>> edges = GetEdges();
            edges.Sort((a, b) => a.Weight.CompareTo(b.Weight));
            Queue<Edge<T>> queue = new Queue<Edge<T>>(edges);

            Subset<T>[] subsets = new Subset<T>[Nodes.Count];
            //initialize

            for (int i = 0; i < Nodes.Count; i++)
            {
                subsets[i] = new Subset<T>() { Parent = Nodes[i] };
            }

            while (result.Count < Nodes.Count - 1)
            {
                Edge<T> edge = queue.Dequeue();
                Node<T> from = GetRoot(subsets, edge.From);
                Node<T> to = GetRoot(subsets, edge.To);
                if (from != to)
                {
                    result.Add(edge);
                    Union(subsets, from, to);
                }

            }


            return result;
        }

        private void Union(Subset<T>[] subsets, Node<T> from, Node<T> to)
        {
            if (subsets[from.Index].Rank > subsets[to.Index].Rank)
            {
                subsets[to.Index].Parent = from;

            }
            else if (subsets[from.Index].Rank < subsets[to.Index].Rank)
            {
                subsets[from.Index].Parent = to;
            }
            else
            {
                subsets[to.Index].Parent = from;
                subsets[from.Index].Rank++;
            }
        }

        private Node<T> GetRoot(Subset<T>[] subsets, Node<T> node)
        {
            if (subsets[node.Index].Parent != node)
            {
                subsets[node.Index].Parent = GetRoot(subsets, subsets[node.Index].Parent);
            }
            return subsets[node.Index].Parent;
        }


        public List<Edge<T>> MinimunSpanningTreePrim()
        {
            //https://github.com/BlueRaja/High-Speed-Priority-Queue-for-C-Sharp/wiki/Getting-Started
            //using priority queue from above
            //create a isInMST list
            //update the node weights to infinity
            //create a priority queue
            //initialize the root node weight to zero
            //for the neighbour nodes of the root
            //update the weights if the node is not in isInMST and egde weight from u->v is less than v's weight
            //add parent node as u

            List<Edge<T>> result = new List<Edge<T>>();
            int[] parent = new int[Nodes.Count];
            bool[] isInMST = new bool[Nodes.Count];
            Fill(isInMST, false);

            //Fill Nodes.Key with Max Value

            this.Nodes.ForEach(n => n.Key = int.MaxValue);

            this.Nodes[0].Key = 0;
            parent[this.Nodes[0].Index] = -1;

            //BinaryHeap<Node<T>> priorityQueue = new BinaryHeap<Node<T>>(this.Nodes);
            SimplePriorityQueue<Node<T>> priorityQueue = new SimplePriorityQueue<Node<T>>();

            this.Nodes.ForEach(n => priorityQueue.Enqueue(n, n.Key));
           
            

            while (priorityQueue.Count != 0)
            {
                //Extract the node with min key value
                Node<T> minNode = priorityQueue.Dequeue();
                isInMST[minNode.Index] = true;

                //iterate through all the adjacent vertices of the minNode
                //for the current vertex
                    // if current vertex dest Node is not in MST
                        //if dest Node.key > current vertex.Weight
                            //remove dest Node from queue
                            //update the dest Node.Key to current Vertex.Weight
                 foreach(Edge<T> edge in minNode.GetEdges())
                  {
                        Node<T> to = edge.To;
                        int edgeWeight = edge.Weight;

                    if (!isInMST[to.Index] && edgeWeight < to.Key)
                    {
                        to.Key = edgeWeight;
                        //update the queue with the new weight
                        priorityQueue.UpdatePriority(to, edgeWeight);
                        parent[to.Index] = minNode.Index;
                                              
                        
                    }
                }       

            }

            
            for(int i=0; i < parent.Length; i++)
            {
                if (parent[i] != -1)
                {
                    Edge<T> edge = this[parent[i], i];
                    result.Add(edge);
                }
                  
            }

            return result;
        }

        private void Fill<Q>(Q[] array, Q value)
        {
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = value;

            }
        }

        #endregion
    }
}
