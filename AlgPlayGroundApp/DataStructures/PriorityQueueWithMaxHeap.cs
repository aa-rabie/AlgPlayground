using System;

namespace AlgPlayGroundApp.DataStructures
{

    // check this link & answers for priority queue implementations by community
    // https://stackoverflow.com/a/13776636
    /// <summary>
    /// assuming the higher value has higher priority
    /// </summary>
    public class PriorityQueueWithMaxHeap<T> where T : IComparable<T>
    {
        private readonly Heap<T> _heap;
        private const int DefaultCapacity = 5;
        public PriorityQueueWithMaxHeap() : this(DefaultCapacity)
        {
           
        }

        public PriorityQueueWithMaxHeap(int capacity)
        {
            if (capacity < 1)
            {
                throw new ArgumentException("capacity should be greater than zero", nameof(capacity));
            }
            _heap = new Heap<T>(capacity);
        }

        public void Enqueue(T item)
        {
            _heap.Insert(item);
        }

        public T Dequeue()
        {
           return _heap.Remove();
        }

        public bool IsEmpty => _heap.IsEmpty;
        public bool IsFull => _heap.IsFull;

    }
}