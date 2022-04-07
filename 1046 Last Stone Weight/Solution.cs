public class Solution
{
    public int LastStoneWeight(int[] stones)
    {
        if (stones.Length == 1)
            return stones[0];

        Array.Sort(stones);
        var s1 = stones.Length - 1;
        var s2 = stones.Length - 2;
        
        while (s1 >= 0)
        {
            if (stones[s1] == stones[s2])
            {
                stones[s1] = 0;
                stones[s2] = 0;
            }
            else
            {
                stones[s2] = stones[s1] - stones[s2];
                stones[s1] = 0;
            }
            Array.Sort(stones);

            if (stones[s2] == 0)
                break;
        }

        return stones[s1];
    }
}