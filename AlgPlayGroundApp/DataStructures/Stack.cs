using System;
using System.Collections;
using System.Collections.Generic;

namespace AlgPlayGroundApp.DataStructures
{
    public class Stack<T> : IEnumerable<T>
    {
        private T[] _arr;
        private int _count;
        private const int DefaultLength = 4;
        public Stack()
        {
            _arr = new T[DefaultLength];
        }

        public void Push(T val)
        {
            if (_count == _arr.Length)
            {
                var newArr = new T[_count * 2];
                for (var i = 0; i < _count; i++)
                {
                    newArr[i] = _arr[i];
                }
                _arr = newArr;
            }

            _arr[_count++] = val;

        }

        public T Pop()
        {
            if (_count == 0)
            {
                throw new InvalidOperationException("Stack is empty");
            }
            T val = _arr[_count - 1];
            _count--;
            return val;
        }

        public T Peek()
        {
            if (_count == 0)
            {
                throw new InvalidOperationException("Stack is empty");
            }

            T val = _arr[_count - 1];
            return val;
        }

        public bool IsEmpty => _count == 0;

        public int Count => _count;


        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < _count; i++)
            {
                yield return _arr[i];
            }

        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public override string ToString()
        {
            if (_count == 0)
                return string.Empty;

            var dataArr = new T[_count];
            Array.Copy(_arr,dataArr,_count);
            return string.Join(",", dataArr);
        }
    }
}