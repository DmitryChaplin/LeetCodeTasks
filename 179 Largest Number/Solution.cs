public class Solution
{
    public string LargestNumber(int[] nums)
    {
        var result = string.Empty;
        // first we need to create a collection of strings out of int values
        var stringNums = new string[nums.Length];
        for (int s = 0; s < nums.Length; s++)
            stringNums[s] = nums[s].ToString();

        // now we need to sort them with our custom comparer
        Array.Sort(stringNums, new CustomComparer());

        // build or string
        foreach (var s in stringNums)
            result += s;

        // and finally return it. edgeCase: a bunch of 0's in nums[] and nothing else, it will return "0000...0" string.
        return result[0] == '0' ? "0" : result;

    }

    private class CustomComparer : Comparer<string>
    {
        public override int Compare(string? s1, string? s2)
        {
            // here should be a line with null checks, but since this is a leetcode problem..
            
            // 101, 31
            // instead of comparing "101" with "31" we should compare "10131" with "31101"
            var s1s2 = s1 + s2;
            var s2s1 = s2 + s1;

            // "31101" > "10131"
            return s2s1.CompareTo(s1s2);
        }
    }
}