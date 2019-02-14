using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructuresAndAlgorithms.Tree.PriorityQueue
{
    //https://github.com/BlueRaja/High-Speed-Priority-Queue-for-C-Sharp/blob/master/Priority%20Queue/GenericPriorityQueue.cs

    public class PriorityQueue<TItem,TPriority> 
        where TItem:QueueNode<TPriority>
        where TPriority: IComparable<TPriority>
    {

        private int _numNodes;
        private TItem[] _nodes;
        private readonly Comparison<TPriority> _comparer;

        public PriorityQueue(int maxNodes, Comparison<TPriority> comparer)
        {
            _numNodes = 0;
            _nodes = new TItem[maxNodes + 1];
            _comparer = comparer;
        }

        public bool Contains(TItem node)
        {
            if(node == null)
            {
                throw new ArgumentNullException();
            }

            if(node.QueueIndex <0 ||node.QueueIndex >= _nodes.Length )
            {
                throw new InvalidOperationException("Node is invalid and out of bounds");
            }

            return _nodes[node.QueueIndex] == node;
        }

        public void Enqueue(TItem node,TPriority priority)
        {
            if (node == null)
            {
                throw new ArgumentNullException();
            }

            if(_numNodes >= _nodes.Length)
            {
                throw new InvalidOperationException("Queue is full - node cannot be added " + node);
            }

            if (Contains(node))
            {
                throw new InvalidOperationException("Node is already added");
            }

            node.Priority = priority;

            _numNodes++;
            _nodes[_numNodes] = node;
            node.QueueIndex = _numNodes;
            CascadeUp(node);

        }

        private void CascadeUp(TItem node)
        {
            int parentIndex;

            if(node.QueueIndex > 1)
            {
                parentIndex = node.QueueIndex >> 1;
                TItem parentNode = _nodes[parentIndex];

                if (HasHigherPriority(parentNode, node)) return;

                _nodes[node.QueueIndex] = parentNode;
                parentNode.QueueIndex = node.QueueIndex;
                node.QueueIndex = parentIndex;

            }
            else
            {
                return;
            }

            //we reach here only if there was a swap

            while(parentIndex > 1)
            {
                parentIndex >>= 1;
                TItem parentNode = _nodes[parentIndex];
                if (HasHigherPriority(parentNode, node))
                    break;

                _nodes[node.QueueIndex] = parentNode;
                parentNode.QueueIndex = node.QueueIndex;
                node.QueueIndex = parentIndex;

            }


            _nodes[node.QueueIndex] = node;

            

        }

        private bool HasHigherPriority( TItem higher, TItem lower)
        {
            var cmp = _comparer(higher.Priority, lower.Priority);

            return (cmp < 0 || (cmp == 0 && higher.InsertionIndex < lower.InsertionIndex));
        }


        private void CascadeDown(TItem node)
        {
            int finalQueueIndex = node.QueueIndex;
            int childLeftIndex = 2 * finalQueueIndex;

            //no leaf node
            if(childLeftIndex > _numNodes)
            {
                return;
            }

            int childRightIndex = childLeftIndex + 1;
            TItem childLeft = _nodes[childLeftIndex];

            if (HasHigherPriority(childLeft, node))
            {
                //check if there is right child
                if(childRightIndex > _numNodes)
                {
                    node.QueueIndex = childLeft.QueueIndex;
                    childLeft.QueueIndex = finalQueueIndex;
                    _nodes[finalQueueIndex] = childLeft;
                    _nodes[childLeftIndex] = node;
                    return;


                }
                //check if left child has a higher priority thatn  right child
                TItem childRight = _nodes[childRightIndex];

                if (HasHigherPriority(childLeft, childRight))
                {
                    //left is higher move it up and continue
                    childLeft.QueueIndex = finalQueueIndex;
                    _nodes[finalQueueIndex] = childLeft;
                    finalQueueIndex = childLeftIndex;
                }
                else
                {
                    childRight.QueueIndex = finalQueueIndex;
                    _nodes[finalQueueIndex] = childRight;
                    finalQueueIndex = childRightIndex;
                }

            }else if(childRightIndex > _numNodes)
                {
                    //no right child
                    return;
            }
            else
            {
                //check if right child has higher priority than node
                TItem childRight = _nodes[childRightIndex];
                if (HasHigherPriority(childRight, node))
                {
                    childRight.QueueIndex = finalQueueIndex;
                    _nodes[finalQueueIndex] = childRight;
                    finalQueueIndex = childRightIndex;
                }
                else
                {
                    return;
                }

            }


            while (true)
            {
                childLeftIndex = 2 * finalQueueIndex;


                //no leaf node
                if (childLeftIndex > _numNodes)
                {
                    node.QueueIndex = finalQueueIndex;
                    _nodes[finalQueueIndex] = node;
                    break;
                }

                 childRightIndex = childLeftIndex + 1;
                 childLeft = _nodes[childLeftIndex];

                if (HasHigherPriority(childLeft, node))
                {
                    //check if there is right child
                    if (childRightIndex > _numNodes)
                    {
                        node.QueueIndex = childLeft.QueueIndex;
                        childLeft.QueueIndex = finalQueueIndex;
                        _nodes[finalQueueIndex] = childLeft;
                        _nodes[childLeftIndex] = node;
                        break;


                    }
                    //check if left child has a higher priority thatn  right child
                    TItem childRight = _nodes[childRightIndex];

                    if (HasHigherPriority(childLeft, childRight))
                    {
                        //left is higher move it up and continue
                        childLeft.QueueIndex = finalQueueIndex;
                        _nodes[finalQueueIndex] = childLeft;
                        finalQueueIndex = childLeftIndex;
                    }
                    else
                    {
                        childRight.QueueIndex = finalQueueIndex;
                        _nodes[finalQueueIndex] = childRight;
                        finalQueueIndex = childRightIndex;
                    }

                }
                else if (childRightIndex > _numNodes)
                {
                    //no right child
                    node.QueueIndex = finalQueueIndex;
                    _nodes[finalQueueIndex] = node;
                    break;
                }
                else
                {
                    //check if right child has higher priority than node
                    TItem childRight = _nodes[childRightIndex];
                    if (HasHigherPriority(childRight, node))
                    {
                        childRight.QueueIndex = finalQueueIndex;
                        _nodes[finalQueueIndex] = childRight;
                        finalQueueIndex = childRightIndex;
                    }
                    else
                    {
                        node.QueueIndex = finalQueueIndex;
                        _nodes[finalQueueIndex] = node;
                        break;
                    }

                }

            }
            


        }

        public TItem Dequeue()
        {

            TItem returnMe = _nodes[1];

            if(_numNodes == 1)
            {
                _nodes[1] = null;
                _numNodes = 0;
                return returnMe;
            }

            TItem formerLastNode = _nodes[_numNodes];
            _nodes[1] = formerLastNode;
            formerLastNode.QueueIndex = 1;
            _nodes[_numNodes] = null;
            _numNodes--;

            CascadeDown(formerLastNode);
            return returnMe;

        }


        public void UpdatePriority(TItem node, TPriority priority)
        {
            if (node == null)
            {
                throw new ArgumentNullException("node");
            }

            if (!Contains(node))
            {
                throw new InvalidOperationException("Cannot call UpdatePriority() on a node which is not enqueued: " + node);
            }

            node.Priority = priority;
            OnNodeUpdated(node);
        }

        private void OnNodeUpdated(TItem node)
        {
            int parentIndex = node.QueueIndex >> 1;

            if(parentIndex > 0 && HasHigherPriority(node, _nodes[parentIndex]))
            {
                CascadeUp(node);
            }
            else
            {
                CascadeDown(node);
            }
        }
    }
    }
