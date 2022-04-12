public class Solution
{
    public bool SearchMatrix(int[][] matrix, int target)
    {
        var targetFound = false;
        var row = 0;
        var col = matrix[0].Length - 1;

        while ((row < matrix.Length && col >= 0) || targetFound)
        {
            if (matrix[row][col] == target)
            {
                targetFound = true;
                break;
            }

            if (matrix[row][col] > target)
                col--;
            else
                row++;
        }

        return targetFound;
    }
}