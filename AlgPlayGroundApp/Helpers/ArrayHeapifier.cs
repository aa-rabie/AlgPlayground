using System;

namespace AlgPlayGroundApp.Helpers
{
    /// <summary>
    /// this class will define Heapify method
    /// Heapify method will transform an array to be like MaxHeap
    /// theory =>
    /// 1) we iterate on each element in array
    /// 2) check if this element's value > its left & right children
    /// 3) if element is NOT larger than its children then swap it with larger child (bubble it down)
    /// and repeat this operation recursively till the element become in correct location in array
    /// </summary>
    public static class ArrayHeapifier
    {
        public static void Heapify<T>(T[] array) where T : IComparable<T>
        {
            //In heap, only half of nodes are parent nodes
            // we need only to check the parent nodes - no need to heapify leaf nodes
            var lastParentIndex = (array.Length / 2) - 1;
            //we will iterate on parent nodes from right to left (optimization)
            // because this way we will have fewer recursion cycles during the act of "heapify single parent node"
            for (int index = lastParentIndex; index >= 0; index--)
            {
                Heapify(array,index);
            }
        }

        private static void Heapify<T>(T[] array, int parentNodeIndex) where T : IComparable<T>
        {
            // initially we assume that node-index is the index with largest value
            var largerIndex = parentNodeIndex;
            var leftChildIndex = (parentNodeIndex * 2) + 1;
            var rightChildIndex = (parentNodeIndex * 2) + 2;
            if (leftChildIndex < array.Length &&
                array[leftChildIndex].CompareTo(array[parentNodeIndex]) > 0)
            {
                largerIndex = leftChildIndex;
            }

            if (rightChildIndex < array.Length &&
                array[rightChildIndex].CompareTo(array[largerIndex]) > 0)
            {
                largerIndex = rightChildIndex;
            }

            if (parentNodeIndex == largerIndex)
                return;

            // here parent Node does not have the largest value so we need to swap
            Swap(array,parentNodeIndex,largerIndex);
            //update parentNodeIndex value after swap
            parentNodeIndex = largerIndex;
            // check again if parent node is in correct location in heap or we need to bubble it down again
            // this check can be done by calling Heapify again
            Heapify(array, parentNodeIndex);
        }

        private static void Swap<T>(T[] array, int first, int second) where T : IComparable<T>
        {
            var temp = array[first];
            array[first] = array[second];
            array[second] = temp;
        }
    }
}