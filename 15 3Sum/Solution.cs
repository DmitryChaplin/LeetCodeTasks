public class Solution
{
    public IList<IList<int>> ThreeSum(int[] nums)
    {
        // Let's declare the resulting collection
        var result = new List<IList<int>>();

        // edgecase check
        if (nums == null || nums.Length < 3)
        {
            return result;
        }
        // We need to find x+y+z=0. Let's do a 2-pointer, but first, we need to sort the array (asc). 
        Array.Sort(nums);

        for (int i = 0; i < nums.Length; i++)
        {
            // This if() to avoid the duplicates. After the first element of array, there's no need to check the sum again if the previousValue = currentValue,
            // because we already looked up all combinations for that value. 
            if (i > 0 && nums[i-1] == nums[i])
            {
                continue;
            }
            
            // at the beginning, it should look something like this:
            // [-1, -1, 0, 1, 2, 4]
            //  i   left        right
            // we will keep checking every possible combination, while shrinking the left...right range.
            var leftPointer = i+1;
            var rightPointer = nums.Length - 1;
            while (leftPointer < rightPointer)
            {
                var sum = nums[leftPointer] + nums[i] + nums[rightPointer];
                if (sum == 0)
                {
                    result.Add(new List<int>() { nums[i], nums[leftPointer], nums[rightPointer] });
                    // keep incrementing the leftPointer, shifting our range to the right, either until it reaches the rightPointer, or we get to a new number
                    while (leftPointer < rightPointer && nums[leftPointer] == nums[leftPointer + 1]) leftPointer++;
                    // keep decrementing the rightPointer, shifting our range to the left, either until it reaches the leftPointer, or we get to a new number
                    while (leftPointer < rightPointer && nums[rightPointer] == nums[rightPointer - 1]) rightPointer--;
                    // since we looked up the _next_ number for the range in the predicates above,
                    // we should to increment && decrement our 'pointers' one more time to get the new values for the loop.
                    leftPointer++;
                    rightPointer--;
                }
                else if (sum < 0)
                {
                    // our sum is below zero, let's try to find a bigger number
                    leftPointer++;
                }
                else
                {
                    // // our sum is above zero, let's try to find a smaller number
                    rightPointer--;
                }
            }
        }
        
        return result;
    }
}