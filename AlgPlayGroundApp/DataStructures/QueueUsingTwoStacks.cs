using System;

namespace AlgPlayGroundApp.DataStructures
{
    public class QueueUsingTwoStacks<T>
    {
        private Stack<T> stack1 = new Stack<T>();
        private Stack<T> stack2 = new Stack<T>();

        public bool IsEmpty => stack1.IsEmpty && stack2.IsEmpty;

        public void Enqueue(T item)
        {
            stack1.Push(item);
        }

        public T Dequeue()
        {
            if (IsEmpty)
            {
                throw new InvalidOperationException("Queue is empty");
            }
            MoveStack1ToStack2IfEmpty();

            return stack2.Pop();
        }

        public T Peek()
        {
            if (IsEmpty)
            {
                throw new InvalidOperationException("Queue is empty");
            }
            MoveStack1ToStack2IfEmpty();

            return stack2.Peek();
        }

        private void MoveStack1ToStack2IfEmpty()
        {
            if (stack2.IsEmpty)
            {
                while (!stack1.IsEmpty)
                {
                    stack2.Push(stack1.Pop());
                }
            }
        }

    }
}