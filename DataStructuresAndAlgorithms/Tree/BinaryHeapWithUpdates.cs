using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructuresAndAlgorithms.Tree
{
    //https://pastebin.com/kkZn123m
    //Limitations cannot take duplicates
    public class BinaryHeapWithUpdates<T> : BinaryHeap<T> where T : IComparable<T>
    {

        Dictionary<T, int> heapIndexes;
        public BinaryHeapWithUpdates()
        {
            heapIndexes = new Dictionary<T, int>();
        }

        public override void Add(T value)
        {


            heapIndexes.Add(value, base.size + 1);
            base.Add(value);
        }

        public override T Remove()
        {

            var min = base.Remove();

            heapIndexes.Remove(min);
            return min;
        }



        protected override void Swap(int source, int target)
        {

            T sourceValue = base.array[source];
            T targetValue = base.array[target];

            heapIndexes[sourceValue] = target;
            heapIndexes[targetValue] = source;
            base.Swap(source, target);
        }

        public void Update(T oldValue, T newValue)
        {
            int index;

            if (!heapIndexes.TryGetValue(oldValue, out index))
            {
                throw new ArgumentException("Value was not found");
            }

            array[index] = newValue;

            if (oldValue.CompareTo(newValue) > 0)
            {
                //decrease key
                base.BubbleUp();
            }
            else if (oldValue.CompareTo(newValue) < 0)
            {
                //increase key
                base.BubbleDown();
            }

        }

        public int Key(T value)
        {
            int index;
            if(!heapIndexes.TryGetValue(value,out index))
            {
                throw new NullReferenceException(); 
            }
            return index;
        }
    }
}
