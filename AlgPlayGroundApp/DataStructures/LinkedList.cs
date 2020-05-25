using System;
using System.Collections.Generic;

namespace AlgPlayGroundApp.DataStructures
{
    public class LinkedList<T>
    {
        public class Node
        {
            public Node(T value)
            {
                this.Value = value;
            }
            public T Value { get; set; }
            public Node Next { get; set; }
        }

        private Node First { get; set; }
        private Node Last { get; set; }
        private bool IsEmpty => First == null;

        private bool HasSingleElement => !IsEmpty && First == Last;

        public int Size { get; private set; } = 0;

        private Node GetPrevious(Node node)
        {
            var current = First;
            while (current != null)
            {
                if (current.Next == node)
                    return current;

                current = current.Next;
            }
            return null;
        }

        public void AddLast(T val)
        {
            var node = new Node(val);
            if (IsEmpty)
            {
                //list is empty
                First = Last = node;
            }
            else
            {
                Last.Next = node;
                Last = node;
            }

            Size += 1;
        }

        public void AddFirst(T val)
        {
            var node = new Node(val);
            if (IsEmpty)
            {
                //list is empty
                First = Last = node;
            }
            else
            {
                node.Next = First;
                First = node;
            }
            Size += 1;
        }

        public int IndexOf(T value)
        {
            var index = 0;
            var current = First;
            while (current != null)
            {
                if (EqualityComparer<T>.Default.Equals(current.Value, value))
                    return index;

                index++;
                current = current.Next;
            }

            return -1;
        }

        public bool Contains(T value) => IndexOf(value) != -1;

        public void RemoveFirst()
        {
            if(IsEmpty) 
                return;

            if (HasSingleElement)
            {
                First = Last = null;
            }
            else
            {
                var second = First.Next;
                First.Next = null;
                First = second;
            }

            Size -= 1;
        }

        public void RemoveLast()
        {
            if (IsEmpty)
                return;

            if (HasSingleElement)
            {
                First = Last = null;
            }
            else
            {
                var previous = GetPrevious(Last);
                Last = previous;
                previous.Next = null;
            }

            Size -= 1;
        }

        public T[] ToArray()
        {
            var array = new T[Size];
            if (IsEmpty)
                return array;

            int index = 0;
            var current = First;
            while (current != null)
            {
                array[index++] = current.Value;
                current = current.Next;
            }

            return array;
        }

        public void DraftReverse()
        {
            if (IsEmpty)
                return;

            var arr = new T[Size];
            int index = Size - 1;
            var current = First;
            while (current != null)
            {
                arr[index--] = current.Value;
                current = current.Next;
            }

            current = First;
            for (int i = 0; i < Size; i++)
            {
                current.Value = arr[i];
                current = current.Next;
            }
        }

        public void Reverse()
        {
            // 10 -> 20 -> 30
            //  prev.   current     next
            if (IsEmpty)
                return;

            var previous = First; // in first iteration => previous is first node & Next is next Node
            var current = First?.Next;
            while (current != null)
            {
                var next = current.Next; // Keep reference of next node because we will need it later
                current.Next = previous; // let current node's "Next" pointer refers to previous node
                //updating pointers
                previous = current;
                current = next;
            }

            //updating "Last" reference
            Last = First;
            Last.Next = null;
            //updating "First" reference - at this moment "previous" refers to last node in list
            First = previous;
        }

        public T GetKthFromTheEnd(int k)
        {
            if (IsEmpty)
            {
                throw new InvalidOperationException("list is empty");
            }

            var firstNode = First;
            var secondNode = First;
            for (int i = 0; i < k - 1; i++)
            {
                secondNode = secondNode.Next;
                //Handle the case when k > Size
                if (secondNode == null)
                {
                    throw new ArgumentOutOfRangeException(nameof(k), "value is larger than list size");
                }
            }

            while (secondNode != Last)
            {
                firstNode = firstNode.Next;
                secondNode = secondNode.Next;
            }

            return firstNode.Value;
        }

    }
}