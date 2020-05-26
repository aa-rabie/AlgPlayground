using System;
using System.Collections.Generic;
using System.Text;

namespace AlgPlayGroundApp.DataStructures
{
    /// <summary>
    /// implement queue using circular array
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class ArrayQueue<T>
    {
        /// <summary>
        /// // points to location from which element will be removed / dequeued
        /// </summary>
        private int _front;
        /// <summary>
        /// points to location at which next element will be inserted
        /// </summary>
        private int _rear; 
        private int _count;
        private const int DefaultCapacity = 10;
        private T[] _arr;

        public ArrayQueue(): this(DefaultCapacity)
        {
            
        }

        public ArrayQueue(int capacity)
        {
            if (capacity < 1)
            {
                throw new ArgumentException("capacity should be greater than zero", nameof(capacity));
            }
            _arr = new T[capacity];
        }

        public void Enqueue(T item)
        {
            if (_count == _arr.Length)
            {
                throw new InvalidOperationException("Queue is full");
            }

            _arr[_rear] = item;
            _rear = (_rear + 1) % _arr.Length;
            _count++;
        }
        
        public T Dequeue()
        {
            if (_count == 0)
            {
                throw new InvalidOperationException("Queue is empty");
            }

            var item = _arr[_front];
            _arr[_front] = default(T);
            _front = (_front + 1) % _arr.Length;
            _count--;
            return item;
        }

        public T Peek()
        {
            if (_count == 0)
            {
                throw new InvalidOperationException("Queue is empty");
            }

            return _arr[_front];
        }

        public bool IsEmpty => _count == 0;
        public bool IsFull => _count == _arr.Length;
        public int Count => _count;

        public override string ToString()
        {
            if (_count == 0)
                return string.Empty;

            var dataArr = new T[_count];
            int current = _front % _arr.Length;
            int counter = 0;
            var end = _rear == 0 ? 5 : (_rear-1) % _arr.Length;
            while (counter < _count)
            {
                dataArr[counter++] = _arr[current];
                current = (current + 1) % _arr.Length;
            }
            return string.Join(",", dataArr);
        }
    }
}
