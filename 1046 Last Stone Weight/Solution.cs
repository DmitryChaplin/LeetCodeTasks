public class Solution
{
    public int LastStoneWeight(int[] stones)
    {
        // I know it's probably not the most efficient method, but we can shift 'destroyed'(0) stones to the beginning
        // of array and call .sort() every 'turn' to keep it something like this [0,0,0,12,13,26,29];
        // keep it up until we only have one val != 0;

        // edge case check
        if (stones.Length == 1)
            return stones[0];

        // sort the array first
        Array.Sort(stones);
        // start with the first 'heaviest stones'
        var s1 = stones.Length - 1;
        var s2 = stones.Length - 2;
        
        while (s1 >= 0)
        {
            // if the stones have the same weight, destroy both
            if (stones[s1] == stones[s2])
            {
                stones[s1] = 0;
                stones[s2] = 0;
            }
            // otherwise set the [-2] stone to (S1-S2) and 'destroy' the last one
            else
            {
                stones[s2] = stones[s1] - stones[s2];
                stones[s1] = 0;
            }
            // sort, so we always have a bunch of 'destroyed stones' at the beginning of array
            Array.Sort(stones);

            // if we have only one 'not destroyed' stone left, break the loop
            if (stones[s2] == 0)
                break;
        }

        return stones[s1];
    }
}