public class Solution
{
    public int LastStoneWeight(int[] stones)
    {
        var current = new List<int>(stones);
        while (current.Count > 1)
        {
            current.Sort();
            var stone1Index = current.Count - 1;
            var stone2Index = current.Count - 2;
            var smashResult = current[stone1Index] - current[stone2Index];
            if (smashResult == 0)
            {
                current.RemoveRange(stone2Index, 2);
            }
            else
            {
                current.RemoveAt(stone1Index);
                current[stone2Index] = smashResult;
            }
        }

        return current.FirstOrDefault(0);
    }
}