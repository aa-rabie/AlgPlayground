namespace AlgPlayGroundApp.Helpers
{
    public class ArrayHelper
    {
        public static void Reverse(int[] nums, int start, int end)
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