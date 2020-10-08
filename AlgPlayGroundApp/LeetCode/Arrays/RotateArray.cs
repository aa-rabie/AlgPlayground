namespace AlgPlayGroundApp.LeetCode.Arrays
{
    public class RotateArray
    {
        public void RotateUsingAdditionalArray(int[] nums, int k)
        {
            if (nums == null || nums.Length == 0)
                return;

            //speed up rotation
            k = k % nums.Length;
            var shiftedArray = new int[nums.Length];
            for (int i = 0; i < nums.Length; i++)
            {
                shiftedArray[(i + k) % nums.Length] = nums[i];
            }
            //update original array values
            for (int i = 0; i < nums.Length; i++)
            {
                nums[i] = shiftedArray[i];
            }
        }

        public void RotateInPlace(int[] nums, int k)
        {
            if (nums == null || nums.Length == 0)
                return;

            k = k % nums.Length;
            int count = 0;
            for (int start = 0; count < nums.Length; start++)
            {
                int current = start;
                int prev = nums[start];
                do
                {
                    int next = (current + k) % nums.Length;
                    int temp = nums[next];
                    nums[next] = prev;
                    prev = temp;
                    current = next;
                    count++;
                } while (start != current);
            }
        }

        public void RotateUsingReverse(int[] nums, int k)
        {
            if (nums == null || nums.Length == 0)
                return;

            k %= nums.Length;
            Reverse(nums, 0, nums.Length - 1);
            Reverse(nums, 0, k - 1);
            Reverse(nums, k, nums.Length - 1);
        }

        private void Reverse(int[] nums, int start, int end)
        {
            while (start < end)
            {
                int temp = nums[start];
                nums[start] = nums[end];
                nums[end] = temp;
                start++;
                end--;
            }
        }
    }
}