public class Solution
{
    public int FindKthLargest(int[] nums, int k)
    {
        // the most naive and silly solution. 
        // Array.Sort(nums);
        // return nums[nums.Length - k];

        // Quickselect it is
        return QuickSelect(nums, 0, nums.Length - 1, k);
    }

    int QuickSelect(int[] nums, int low, int high, int k)
    {
        //partition phase

        var pivot = low; // random index value should work better. in theory.
        for (int i = low; i < high; i++)
        {
            if (nums[i] <= nums[high])
            {
                Swap(nums, pivot++, i);
            }
        }

        Swap(nums, pivot, high);

        // checking for the kth largest 
        var count = high - pivot + 1;
        if (count == k) return nums[pivot];
        if (count > k) return QuickSelect(nums, pivot + 1, high, k);
        return QuickSelect(nums, low, pivot - 1, k - count); ;
    }

    private static void Swap(int[] array, int firstValueIndex, int secondValueIndex)
    {
        int temp = array[firstValueIndex];
        array[firstValueIndex] = array[secondValueIndex];
        array[secondValueIndex] = temp;
    }
}