using System;
using System.Collections.Generic;
using System.Linq;

namespace AlgPlayGroundApp.LeetCode.Easy
{
    /// <summary>
    /// Problem : https://leetcode.com/problems/min-stack/solution/
    /// </summary>
    public class MySolution
    {
        public class MinStack
        {
            private const int DefaultSize = 5;
            private int?[] _data;
            public int TopIndex { get; private set; }
            private int? _Min = null;

            public MinStack()
            {
                _data = new int?[DefaultSize];
                TopIndex = -1;
            }

            public void Push(int x)
            {
                if (TopIndex == _data.Length - 1)
                {
                    ExpandArray();
                }

                _data[++TopIndex] = x;
                CalculateMin(0, TopIndex + 1);
            }

            private void ExpandArray()
            {
                var newSize = _data.Length + DefaultSize;
                var newArray = new int?[newSize];
                Array.Copy(_data, 0, newArray, 0, _data.Length);
                _data = newArray;
            }

            private void CalculateMin(int startIndex, int length)
            {
                if (TopIndex < 0)
                {
                    _Min = null;
                    return;
                }

                var validRange = new ArraySegment<int?>(_data, startIndex, length);
                if (validRange.Count(i => i.HasValue) == 0)
                {
                    _Min = null;
                    return;
                }

                _Min = validRange.Where(i => i.HasValue).Min();
            }

            public void Pop()
            {
                if (TopIndex < 0)
                    return;

                TopIndex--;
                CalculateMin(0, TopIndex + 1);

            }

            public int Top()
            {
                return _data[TopIndex].GetValueOrDefault();
            }

            public int GetMin()
            {
                return _Min.GetValueOrDefault();
            }
        }
    }

    public class LeetCode
    {
        class MinStack
        {

            private Stack<int[]> _stack = new Stack<int[]>();

            public MinStack() { }


            public void Push(int x)
            {

                /* If the stack is empty, then the min value
                 * must just be the first value we add. */
                if (_stack.Count == 0)
                {
                    _stack.Push(new int[] { x, x });
                    return;
                }

                int currentMin = _stack.Peek()[1];
                _stack.Push(new int[] { x, Math.Min(x, currentMin) });
            }


            public void Pop()
            {
                _stack.Pop();
            }


            public int Top()
            {
                return _stack.Peek()[0];
            }


            public int GetMin()
            {
                return _stack.Peek()[1];
            }
        }
    }
}