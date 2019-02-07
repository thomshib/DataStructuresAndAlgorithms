using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructuresAndAlgorithms
{
    public static class InsertionSort
    {
        public static void Sort<T>(T[] array) where T : IComparable
        {
            for (int i = 1; i < array.Length; i++)
            {
                int j = i;

                while (j > 0 && array[j].CompareTo(array[j - 1]) < 0)
                {
                    Swap(array, j, j - 1);
                    j--;
                }
            }
        }


            private static void Swap<T>(T[] array, int i, int minIndex) where T : IComparable
            {
                T temp = array[i];
                array[i] = array[minIndex];
                array[minIndex] = temp;
            }
        }
}
