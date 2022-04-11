public class Solution
{
    public void SetZeroes(int[][] matrix)
    {
       // iterate through the second row..n and flag everything
       for(int y = 1; y < matrix.Length; y++)
       {
            for (int x = 0; x < matrix[y].Length; x++)
            {
                // check if current cell value is 0
                if (matrix[y][x] == 0)
                {
                    // flag row for 0
                    matrix[y][0] = 0;
                    // flag col for 0
                    matrix[0][x] = 0;
                }
            }
       }

        // let's iterate again, checking the flags, excluding the first row and the first column, since we used them for flags
        for (int y = 1; y < matrix.Length; y++)
        {
            for (int x = 1; x < matrix[y].Length; x++)
            {
                // check if row / col is flagged for 0
                if (matrix[y][0] == 0 || matrix[0][x] == 0)
                    matrix[y][x] = 0;
            }
        }

        // check if we need to 0 the first row / column
        if (matrix[0][0] == 0)
        {
            for (int i = 0; i < matrix[0].Length; i++)
                matrix[0][i] = 0;
            for (int i = 0; i < matrix.Length; i++)
                matrix[i][0] = 0;
        }

    }
}