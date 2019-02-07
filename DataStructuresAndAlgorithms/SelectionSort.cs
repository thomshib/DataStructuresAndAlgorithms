using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructuresAndAlgorithms
{
    public static class SelectionSort
    {
        public static void Sort<T>(T[] array) where T: IComparable
        {
            for(int i = 0; i < array.Length - 1; i++)
            {
                int minIndex = i;
                T minValue = array[i];

                for(int j = i + 1; j < array.Length ; j++)
                {
                    if (array[j].CompareTo(minValue) < 0)
                    {
                        minIndex = j;
                        minValue = array[j];
                    }
                }
                Swap(array, i, minIndex);
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
