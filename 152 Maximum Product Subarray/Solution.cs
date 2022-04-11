public class Solution
{
    public int MaxProduct(int[] nums)
    {
        int lastRecordedMinVal = nums[0];
        var lastRecordedMaxVal = nums[0];
        var maxValSoFar = nums[0];

        // We start with the 2nd number in the array, since at the start current_min=current_max=max_overall
        for (int i = 1; i < nums.Length; i++)
        {
            int currentValue = nums[i];
            // Pick max value between currentValue, (currentValue * lastRecordedMaxVal) and currentValue * lastRecordedMinVal, picking the largest one
            var temp = Math.Max(Math.Max(currentValue, currentValue * lastRecordedMaxVal), currentValue * lastRecordedMinVal);

            // Set the lastRecordedMinVal either to currentValue, currentValue * max_value or currentValue * lastRecordedMinVal, picking the lowest one
            lastRecordedMinVal = Math.Min(Math.Min(currentValue, currentValue * lastRecordedMaxVal), currentValue * lastRecordedMinVal);

            // let's set lastRecordedMaxVal to the temp, which is current largest value
            lastRecordedMaxVal = temp;

            // maxValSoFar value would be either a  lastRecordedMaxVal or the previously recorded one
            maxValSoFar = Math.Max(lastRecordedMaxVal, maxValSoFar);
        }

        return maxValSoFar;
    }
}