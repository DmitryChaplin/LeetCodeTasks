public class Solution
{
    public int[][] GenerateMatrix(int n)
    {
        int[][] result = new int[n][];
        for (int i = 0; i < n; i++)
            result[i] = new int[n];
        
        var colBegin = 0;
        var rowBegin = 0;
        var rowEnd = n - 1;
        var colEnd = n - 1;
        var number = 1;

        while (rowBegin <= rowEnd && colBegin <= colEnd)
        {
            // Traverse right
            for (int _ = colBegin; _ <= colEnd; _++)
            {;
                result[rowBegin][_] = number++;
            }
            rowBegin++;


            // traverse down
            for (int _ = rowBegin; _ <= rowEnd; _++)
            {
                result[_][colEnd] = number++;
            }
            colEnd--;

            // traverse left
            if (rowBegin <= rowEnd)
            {
                for (int _ = colEnd; _ >= colBegin; _--)
                {
                    result[rowEnd][_] = number++;
                }
                rowEnd--;
            }

            //traverse up
            if (colBegin <= colEnd)
            {
                for (int _ = rowEnd; _ >= rowBegin; _--)
                {
                    result[_][colBegin] = number++;
                }
                colBegin++;
            }

        }

        return result;
    }
}