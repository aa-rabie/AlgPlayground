using System;

namespace AlgPlayground.Tests
{
    /// <summary>
    /// Time Complexity
    /// Best-Case:  O(n2)
    //  Average-Case:  O(n2)
    //  Worst-Case:  O(n2)

    //  Space Complexity: O(1)
    /// </summary>
    public class SelectionSort
    {
        /// <summary>
        /// src https://code-maze.com/csharp-selection-sort/
        /// </summary>
        class CodeMazeImplementation
        {
            public T[] SortArray<T>(T[] array) where T : IComparable<T>
            {
                var arrayLength = array.Length;
                for (int i = 0; i < arrayLength - 1; i++)
                {
                    var smallestVal = i;
                    for (int j = i + 1; j < arrayLength; j++)
                    {
                        if (array[j] .CompareTo(array[smallestVal]) < 0)
                        {
                            smallestVal = j;
                        }
                    }
                    var tempVar = array[smallestVal];
                    array[smallestVal] = array[i];
                    array[i] = tempVar;
                }
                return array;
            }
        }

    }
}