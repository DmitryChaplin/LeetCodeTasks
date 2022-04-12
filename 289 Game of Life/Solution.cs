public class Solution
{
    //  const int Dead = 0;
    //  const int Alive = 1;
    //  const int WasAlive(ShouldDie) = 6;
    //  const int WasDead(ShouldLive) = 7;

    public void GameOfLife(int[][] board)
    {
        var rowsNum = board.Length;
        var colsNum = board[0].Length;

        for (int row = 0; row < rowsNum; row++)
            for (int col = 0; col < colsNum; col++)
            {
                var livingNeighborsNum = GetNumberOfAliveNeighbors(board, row, col, rowsNum, colsNum);
                board[row][col] = board[row][col] == 0 // if current cell is dead
                    ? livingNeighborsNum == 3 // and has 3 neighbors
                        ? 7 // ressurect it
                        : 0 // otherwise do nothing
                    : livingNeighborsNum < 2 || livingNeighborsNum > 3 // for the living cell, does it have less than 2 or more than 3 living neighbors?
                        ? 6 // kill it
                        : 1; // otherwise do nothing
            }

        // let's swap 6's & 7's to their respective 0's and 1's
        for (int row = 0; row < rowsNum; row++)
            for (int col = 0; col < colsNum; col++)
                board[row][col] = board[row][col] == 6
                    ? 0
                    : board[row][col] == 7
                        ? 1
                        : board[row][col];
    }

    int GetNumberOfAliveNeighbors(int[][] board, int row, int col, int rowsNum, int colsNum)
    {
        var counter = 0;

        if (col - 1 >= 0 && (board[row][col - 1] == 1 || board[row][col - 1] == 6)) counter++;  // get the West neighbor, if it exists
        if (col + 1 < colsNum && (board[row][col + 1] == 6 || board[row][col + 1] == 1)) counter++; // get the East neighbor, if it exists

        // do we have a row above to check for neighbors?
        if (row - 1 >= 0)
        {
            if (board[row - 1][col] == 1 || board[row - 1][col] == 6) counter++; // get the North neighbor
            if (col - 1 >= 0 && (board[row - 1][col - 1] == 1 || board[row - 1][col - 1] == 6)) counter++; // get the NW neighbor
            if (col + 1 < colsNum && (board[row - 1][col + 1] == 1 || board[row - 1][col + 1] == 6)) counter++; // get the NE neighbor
        }

        // do we have a row below to check for neighbors?
        if (row + 1 < rowsNum)
        {
            if (board[row + 1][col] == 1 || board[row + 1][col] == 6) counter++; // get the South neighbor
            if (col - 1 >= 0 && (board[row + 1][col - 1] == 1 || board[row + 1][col - 1] == 6)) counter++; // get the SW neighbor
            if (col + 1 < colsNum && (board[row + 1][col + 1] == 1 || board[row + 1][col + 1] == 6)) counter++; // get the SE neighbor
        }

        return counter;
    }
}