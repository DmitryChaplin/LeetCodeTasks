public class Solution
{
    public void SetZeroes(int[][] matrix)
    {
        bool wipeTheFirstCol = false;
        int rowsNum = matrix.Length;
        int colsNum = matrix[0].Length;
       
        // the whole idea here is to use first row and first col to flag if the row or col should be zero'd.

        // iterate through the second row..n and flag everything
        for (int row = 0; row < rowsNum ; row++)
        {
            // if we have any 0's in the first column of any row, we need to set the flag, to 0 the first col
            if (matrix[row][0] == 0)
                wipeTheFirstCol = true;

            for (int col = 1; col < colsNum; col++)
                // check if current cell value is 0
                if (matrix[row][col] == 0)
                {
                    matrix[row][0] = 0; // flag row for 0
                    matrix[0][col] = 0; // flag col for 0
                };            
        }

        // let's iterate again, checking the flags, but excluding the first row and the first column from our wrath, since we used them for flags
        for (int row = 1; row < rowsNum; row++)
            for (int col = 1; col < colsNum; col++)
                // check if row / col is flagged for 0
                if (matrix[row][0] == 0 || matrix[0][col] == 0)
                    matrix[row][col] = 0;

        // check if we need to 0 the first row, checking the first cell in the given matrix
        if (matrix[0][0] == 0)
            for (int cell = 0; cell < colsNum; cell++)
                matrix[0][cell] = 0;

        // check if we need to 0 the first column
        if (wipeTheFirstCol)
            for (int row = 0; row < rowsNum; row++)
                matrix[row][0] = 0;
    }
}