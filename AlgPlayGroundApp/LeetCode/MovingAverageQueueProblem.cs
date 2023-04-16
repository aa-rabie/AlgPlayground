using System.Collections.Generic;
using System.Linq;

namespace AlgPlayGroundApp.LeetCode
{
    public class MovingAverageQueueProblem
    {
        private Queue<int> _nums;
        private int _capacity = 0;
        public MovingAverageQueueProblem(int size)
        {
            _nums = new Queue<int>(3);
            _capacity = size;
        }

        public double Next(int val)
        {
            if (_nums.Count == _capacity)
            {
                _nums.Dequeue();
            }
            _nums.Enqueue(val);

            return (double)_nums.Sum() / (double)_nums.Count;
        }
    }
}