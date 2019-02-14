using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructuresAndAlgorithms.Tree.PriorityQueue
{
    public class QueueNode<TPriority>
    {

        public TPriority Priority{ get; protected internal set; }
        public int QueueIndex { get; protected internal set; }

        public long InsertionIndex { get; protected internal set; }
    }
}
