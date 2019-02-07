using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructuresAndAlgorithms.Tree
{
    //https://courses.cs.washington.edu/courses/cse373/11wi/homework/5/BinaryHeap.java
    public class BinaryHeap<T> where T:IComparable<T>
    {
        private static readonly int DEFAULT_CAPACITY = 10;
        protected T[] array;
        protected int size;

        public BinaryHeap()
        {
            array = new T[DEFAULT_CAPACITY];
            size = 0;
        }

        public BinaryHeap(List<T> list)
        {
            array = new T[list.Count];
            size = 0;

            foreach(var item in list)
            {
                Add(item);
            }
        }
        public void Add(T value)
        {
            //grow array if needed
            if (size >= array.Length - 1)
            {
               this.Resize();
            }
            size++;
            int index = size;
            array[index] = value;
            BubbleUp();
        }

        private void BubbleUp()
        {
            //min
            int index = this.size;

            while (HasParent(index))
            {
                if (ParentValue(index).CompareTo(array[index]) > 0){
                    Swap(index, ParentIndex(index));
                 }
                index = ParentIndex(index);

            }


        }

        public bool IsEmpty()
        {
            return size == 0;
        }

        public T Peek()
        {
            if (this.IsEmpty())
            {
                throw new ArgumentOutOfRangeException();
            }
            return array[1];
        }

        public T Remove()
        {
            T result = Peek();

            
            Swap(1, size); //swap last element with root
            array[size] = default(T); //delete last element
            size--;

            BubbleDown();
            return result;

        }

        private void BubbleDown()
        {
            int index = 1;

            while (HasLeftChild(index))
            {
                int smallerChild = FindMinChild(index);

                if (array[index].CompareTo(array[smallerChild]) > 0){
                    Swap(index, smallerChild);
                }

                index = smallerChild;
            }
        }

        private int FindMinChild(int index)
        {
            if (HasRightChild(index))
            {
                if (array[LeftIndex(index)].CompareTo(array[RightIndex(index)]) > 0){
                    return RightIndex(index);
                }
                
            }

            return LeftIndex(index);
        }

        private bool HasLeftChild(int index)
        {
            return LeftIndex(index) <= size;
        }

        private bool HasRightChild(int index)
        {
            return RightIndex(index) <= size;
        }

        private int LeftIndex(int index)
        {
            return index * 2;
        }
        private int RightIndex(int index)
        {
            return (index * 2) + 1;
        }

        private void Swap(int source, int target)
        {
            T temp = array[source];
            array[source] = array[target];
            array[target] = temp;
        }

        private bool HasParent(int index)
        {
            int parent =  (int) index / 2;
            return parent > 0;
        }

        private int ParentIndex(int i)
        {
            return i / 2;
        }

        private T ParentValue(int i)
        {
            return array[ParentIndex(i)];
        }

        private void Resize()
        {
             Array.Resize(ref array, array.Length * 2);
            

        }


    }
}
