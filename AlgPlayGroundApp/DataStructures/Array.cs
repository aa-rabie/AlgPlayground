﻿using System;
using System.Collections;
using System.Collections.Generic;

namespace AlgPlayGroundApp.DataStructures
{
    public class Array<T> : IEnumerable<T>
    {
        private T[]_arr;
        private int _count;
        public Array(int length)
        {
            if (length < 0)
            {
                throw new ArgumentException("length should be >= zero",nameof(length));
            }
            _arr = new T[length];
        }

        public void Add(T val)
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

        public void RemoveAt(int index)
        {
            if (index < 0 || index >= _count)
            {
                throw new IndexOutOfRangeException();
            }
            //Shift
            for (int i = index; i < _count; i++)
            {
                _arr[i] = _arr[i + 1];
            }
            //decrement count
            _count--;

        }

        public int IndexOf(T item)
        {
            for (int i = 0; i < _count; i++)
            {
                if (EqualityComparer<T>.Default.Equals(_arr[i],item))
                    return i;
            }

            return -1;
        }

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
    }
}