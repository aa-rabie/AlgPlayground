using System;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Text;

namespace AlgPlayGroundApp.DataStructures
{
    /// <summary>
    /// assuming the higher value has higher priority
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class PriorityQueue<T> where T : IComparable<T>
    {
        private const int DefaultCapacity = 5;
        private T[] _arr;
        private int _count;

        private void Resize()
        {
            if (_arr == null || _count == 0)
                return;
            var newArr = new T[_count * 2];
            for (var i = 0; i < _count; i++)
            {
                newArr[i] = _arr[i];
            }
            _arr = newArr;
        }

        public PriorityQueue() : this(DefaultCapacity)
        {

        }

        public PriorityQueue(int capacity)
        {
            if (capacity < 1)
            {
                throw new ArgumentException("capacity should be greater than zero", nameof(capacity));
            }
            _arr = new T[capacity];
        }

        public bool IsEmpty => _count == 0;


        public void Add(T item)
        {
            /*
             *  if Arr contains [1,3,4,5]
             * assume that we need to insert 2
             * algorithm
             * 1 - we compare value '2' to each element in array starting from end-of-array to beginning
             *      for (index = _count - 1; index >= 0; index--)
             * 2 - if( array[index] > value '2') then we need to shift array[index] to right
             * 3 - else we need to insert value '2' at index + 1
             */



            if (_count == _arr.Length)
            {
                Resize();
            }
            //shifting items to right & search for location at which new item will be inserted
            int index;
            for (index = _count - 1; index >= 0; index--)
            {
                if (_arr[index].CompareTo(item) > 0)
                {
                    //shift to right
                    _arr[index + 1] = _arr[index];
                }
                else
                {
                    // the item should be inserted at location i+1
                    break;
                }
            }

            _arr[index + 1] = item;
            _count++;
        }

        public T Remove()
        {
            //we need to remove & return higher priority item first
            // we need a variable/pointer that refers to the location (within array) that we should remove from 
            // our array is sorted & we assume that elements with higher value have higher priority
            // then we can re-use _count as our pointer/variable
            if(IsEmpty)
                throw new InvalidOperationException("Queue is empty");

            return _arr[--_count];
        }

        public override string ToString()
        {
            if (_count == 0)
                return string.Empty;
            var builder = new StringBuilder("[");
            for (int i = 0; i < _count; i++)
            {
                builder.Append(_arr[i]);
                if (i < _count - 1)
                    builder.Append(",");
            }
            builder.Append("]");
            return builder.ToString();
        }
    }
}