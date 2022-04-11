namespace _628_Maximum_Product_of_Three_Numbers
{
    public class Solution
    {
        public int MaximumProduct(int[] nums)
        {
            if (nums.Length < 3)
            {
                return 0;
            }

            var min1 = int.MaxValue;
            var min2 = int.MaxValue;

            var max1 = int.MinValue;
            var max2 = int.MinValue;
            var max3 = int.MinValue;

            foreach (int i in nums)
            {
                if (i <= min1)
                {
                    min2 = min1;
                    min1 = i;
                }
                else if (i <= min2)
                {
                    min2 = i;
                }

                if (i >= max1)
                {

                    max3 = max2;
                    max2 = max1;
                    max1 = i;
                }
                else if (i >= max2)
                {
                    max3 = max2;
                    max2 = i;
                }
                else if (i >= max3)
                {
                    max3 = i;
                }
            }

            return Math.Max(min1 * min2 * max1, max1 * max2 * max3);
        }
    }
}
