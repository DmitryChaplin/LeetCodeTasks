public class Solution
{
    public IList<int> SpiralOrder(int[][] matrix)
    {
        var result = new List<int>();
        var colBegin = 0;
        var rowBegin = 0;
        var rowEnd = matrix.Length - 1;
        var colEnd = matrix[0].Length - 1;

        // let's spiral, until we reach the endRow / endCol
        while (rowBegin <= rowEnd && colBegin <= colEnd)
        {
            // Traverse right
            for (int _ = colBegin; _ <= colEnd; _++)
            {
                result.Add(matrix[rowBegin][_]);
            }
            rowBegin++;

            // traverse down
            for (int _ = rowBegin; _ <= rowEnd; _++)
            {
                result.Add(matrix[_][colEnd]);
            }
            colEnd--;

            // traverse left
            if (rowBegin <= rowEnd)
            {
                for (int _ = colEnd; _ >= colBegin; _--)
                {
                    result.Add(matrix[rowEnd][_]);
                }
                rowEnd--;
            }

            //traverse up
            if (colBegin <= colEnd)
            {
                for (int _ = rowEnd; _ >= rowBegin; _--)
                {
                    result.Add(matrix[_][colBegin]);
                }
                colBegin++;
            }

        } 

        return result;
    }

}