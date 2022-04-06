public class Solution
{
    // Alright, i'll be honest, my first solution was a O(2n) with counters.
    // i looked up the Dutch national flag (3-way sort) algo on wiki 

    public void SortColors(int[] nums)
    {

        // at the start it should look like this
        // [........][.......][.....]
        //  0                       n
        //  ^                       ^
        // low                     high
        // mid
        int low = 0;
        int high = nums.Length - 1;
        int mid = 0;

        // let's keep going until mid 'pointer' exceeds high 'pointer'
        while (mid <= high)
        {
            // let's check the value of a current middle node
            switch (nums[mid])
            {
                case 0:
                    {
                        // Okay, let's swap values at current middle 'pointer' and low 'pointer' and push them both to the right
                        Swap(nums, mid, low);
                        mid++;
                        low++;
                        break;
                    }
                case 1:
                    // everything is alright, let's keep going
                    mid++;
                    break;
                case 2:
                    {
                        // Let's swap values at the high 'pointer' and middle 'pointer', and increment our 'high' range
                        Swap(nums, mid, high);
                        high--;
                        break;
                    }
            }
        }
    }

    private static void Swap(int[] array, int firstValueIndex, int secondValueIndex)
    {
        int temp = array[firstValueIndex];
        array[firstValueIndex] = array[secondValueIndex];
        array[secondValueIndex] = temp;
    }
    
}