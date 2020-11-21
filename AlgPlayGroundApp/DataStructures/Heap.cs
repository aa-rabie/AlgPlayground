using System;
using System.Runtime.CompilerServices;

[assembly:InternalsVisibleTo("AlgPlayground.Tests")]
namespace AlgPlayGroundApp.DataStructures
{
    /// <summary>
    /// heaps can be used in
    /// 1) heap sort
    /// 2) priority queue
    /// 3) find kth smallest/largest value
    /// 4) in GPS maps - find shortest path between two points
    /// ----------------------------------
    /// any heap should be
    /// 1) complete tree => all levels should not have any missing child nodes (except leaf nodes)
    /// 2) fill any node children from left-to-right
    /// ----------------------------------------
    /// This Heap is Max-Heap
    /// which means
    /// 1) root has largest value
    /// 2) any node-value should >= its children values
    /// 3) when we need to remove a node we always remove root node 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Heap<T> where T : IComparable<T>
    {
        private const int DefaultCapacity = 10;
        private T[] _arr;
        private int _size;
        public Heap() : this(DefaultCapacity)
        {

        }

        public Heap(int capacity)
        {
            if (capacity < 1)
            {
                throw new ArgumentException("capacity should be greater than zero", nameof(capacity));
            }
            _arr = new T[capacity];
        }

        private void IncreaseCapacity()
        {
            if (IsEmpty)
                return;
            var newArr = new T[_size * 2];
            for (var i = 0; i < _size; i++)
            {
                newArr[i] = _arr[i];
            }
            _arr = newArr;
        }

        public bool IsFull => _size == _arr.Length;
        public bool IsEmpty => _arr == null || _size == 0;

        public int Size => _size;

        internal T[] Array => _arr;

        public void Insert(T value)
        {
            if(IsFull)
            {
                IncreaseCapacity();
            }
            //initially insert newElement in first free location
            _arr[_size++] = value;
            //then if new element > its parent then bubble it up
            BubbleUp();
        }

        private void BubbleUp()
        {
            //start checking leaf nodes & going up to root
            var index = _size - 1;
            while (index > 0 && _arr[index].CompareTo(_arr[GetParentIndex(index)]) > 0)
            {
                //newElement value > Parent Value then swap
                //(basically newElement becomes parent to its old-parent - after the Swap)
                Swap(index, GetParentIndex(index));
                //update index value to point to newElement location
                index = GetParentIndex(index);
            }
        }

        private int GetParentIndex(int index)
        {
            return (index - 1) / 2;
        }

        private void Swap(int firstIndex, int secondIndex)
        {
            var tmp = _arr[firstIndex];
            _arr[firstIndex] = _arr[secondIndex];
            _arr[secondIndex] = tmp;
        }

        private int GetLeftChildIndex(int index)
        {
            return (index * 2) + 1;
        }

        private int GetRightChildIndex(int index)
        {
            return (index * 2) + 2;
        }

        private T GetLeftChild(int index)
        {
            return _arr[GetLeftChildIndex(index)];
        }

        private T GetRightChild(int index)
        {
            return _arr[GetRightChildIndex(index)];
        }

        private bool IsValidParent(int index)
        {
            //since we fill child-nodes from left to right
            // then if node does not have left child then this node is leaf
            if (!HasLeftChild(index))
                return true;

            var isValid = _arr[index].CompareTo(GetLeftChild(index)) >= 0;
            if (!HasRightChild(index))
            {
                //parent value should be larger than left child value
                return isValid;
            }
            //in case node has both left & right children then parent should be larger than both nodes
            isValid &= _arr[index].CompareTo(GetRightChild(index)) >= 0;
            return isValid;
        }

        private int GetLargerChildIndex(int index)
        {
            //since we fill child-nodes from left to right
            // then if node does not have left child then this node is leaf
            if (!HasLeftChild(index))
                return index; //return same node index
            if (!HasRightChild(index))
            {
                //return left child index
                return GetLeftChildIndex(index);
            }
            return GetLeftChild(index).CompareTo(GetRightChild(index)) > 0
                ? GetLeftChildIndex(index)
                : GetRightChildIndex(index);
        }

        public void Remove()
        {
            if (IsEmpty)
                return;

            //remove root item & but leaf node as a root
            _arr[0] = _arr[--_size];
            // bubble down new-root as long as it is not valid parent
            BubbleDown();
        }

        private void BubbleDown()
        {
            var index = 0;
            while (index <= _size && !IsValidParent(index))
            {
                //swap with largest child
                var largerChildIndex = GetLargerChildIndex(index);
                Swap(index, largerChildIndex);
                //update parent index to new-value after swap
                index = largerChildIndex;
            }
        }

        /// <summary>
        /// this function should be called only from Remove() (after decrementing size by 1)
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        private bool HasLeftChild(int index)
        {
            return GetLeftChildIndex(index) <= _size;
        }

        /// <summary>
        /// this function should be called only from Remove() (after decrementing size by 1)
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        private bool HasRightChild(int index)
        {
            return GetRightChildIndex(index) <= _size;
        }
    }

}