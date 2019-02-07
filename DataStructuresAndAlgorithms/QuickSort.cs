using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructuresAndAlgorithms
{
    public static class QuickSort
    {
        public static void Sort<T>(T[] array) where T : IComparable
        {
            Sort(array, 0, array.Length - 1);
        }

        private static T[]  Sort<T>(T[] array,int lower, int upper) where T : IComparable
        {
            if (lower < upper)
            {
                int p = Partition(array, lower, upper);
                Sort(array, lower, p);
                Sort(array, p + 1, upper);

            }
            return array;
        }

        private static int Partition<T>(T[] array, int lower, int upper) where T : IComparable
        {
            int leftmark = lower;
            int rightmark = upper;
            bool done = false;
            T pivot = array[lower];

            while (!done)
            {
                while ( leftmark <= rightmark &&  array[leftmark].CompareTo(pivot) < 0 )
                {
                    leftmark++;
                }

                while (rightmark >= leftmark && array[rightmark].CompareTo(pivot) > 0)
                {
                    rightmark--;
                }

                if (leftmark >= rightmark)
                {
                    done = true;
                }
                else
                {
                    Swap(array, leftmark, rightmark);
                }

            }

            //Swap(array, lower, rightmark);

            return rightmark;

            

        }

        private static void Swap<T>(T[] array, int i, int minIndex) where T : IComparable
        {
            T temp = array[i];
            array[i] = array[minIndex];
            array[minIndex] = temp;
        }
    }
}
