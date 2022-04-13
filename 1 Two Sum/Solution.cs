
public class Solution
{
    public int[] TwoSum(int[] nums, int target)
    {
        // Waste some memory on a dict, iterate through the array
        // look up the current_remainder in it, add the current value:index if there are none;
        var dict = new Dictionary<int, int>();
        for(int i = 0; i < nums.Length; i++)
        {
            int remainder = target - nums[i];
            if (dict.ContainsKey(remainder))
            {
                return new int[]{ dict[remainder], i};
            }
            dict.TryAdd(nums[i], i);
        }

        return null;
    } 
}
