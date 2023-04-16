using System;

namespace AlgPlayGroundApp.DataStructures
{
    // Problem : https://leetcode.com/explore/learn/card/queue-stack/228/first-in-first-out-data-structure/1337/
    // Solution : https://leetcode.com/problems/design-circular-queue/editorial/
    // implementation from LeetCode
    /*
     * Requirements
     *
     *  Implement the MyCircularQueue class:

            MyCircularQueue(k) Initializes the object with the size of the queue to be k.
            int Front() Gets the front item from the queue. If the queue is empty, return -1.
            int Rear() Gets the last item from the queue. If the queue is empty, return -1.
            bool enQueue(int value) Inserts an element into the circular queue. Return true if the operation is successful.
            bool deQueue() Deletes an element from the circular queue. Return true if the operation is successful.
            bool isEmpty() Checks whether the circular queue is empty or not.
            bool isFull() Checks whether the circular queue is full or not.
     */
    class MyCircularQueue
    {

        private int[] queue;
        private int headIndex;
        private int count;
        private int capacity;
        private readonly object queueLock = new object();

        /** Initialize your data structure here. Set the size of the queue to be k. */
        public MyCircularQueue(int k)
        {
            this.capacity = k;
            this.queue = new int[k];
            this.headIndex = 0;
            this.count = 0;
        }

        /** Insert an element into the circular queue. Return true if the operation is successful. */
        public bool EnQueue(int value)
        {
            lock (queueLock)
            {
                if (this.count == this.capacity)
                    return false;
                this.queue[(this.headIndex + this.count) % this.capacity] = value;
                this.count += 1;
                return true;
            }
        }

        /** Delete an element from the circular queue. Return true if the operation is successful. */
        public bool DeQueue()
        {
            lock (queueLock)
            {
                if (this.count == 0)
                    return false;

                this.headIndex = (this.headIndex + 1) % this.capacity;
                this.count -= 1;
                return true;
            }
        }

        /** Get the front item from the queue. */
        public int Front()
        {
            if (this.count == 0)
                return -1;
            return this.queue[this.headIndex];
        }

        /** Get the last item from the queue. */
        public int Rear()
        {
            if (this.count == 0)
                return -1;
            int tailIndex = (this.headIndex + this.count - 1) % this.capacity;
            return this.queue[tailIndex];
        }

        /** Checks whether the circular queue is empty or not. */
        public bool IsEmpty()
        {
            return (this.count == 0);
        }

        /** Checks whether the circular queue is full or not. */
        public bool IsFull()
        {
            return (this.count == this.capacity);
        }
    }
}