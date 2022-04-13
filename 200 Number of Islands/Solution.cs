public class Solution
{    
    public int NumIslands(char[][] grid)
    {
        var numberOfIslands = 0;

        for (var row = 0; row < grid.Length; row++)
        {
            for (var col = 0; col < grid[0].Length; col++)
            {
                // found an 'earth' cell
                if (grid[row][col] == '1')
                {
                    // let's expand this island to all 4 directions recursively
                    ExploreIsland(grid, row, col);
                    numberOfIslands++;
                }
            }
        }

        return numberOfIslands;
    }

    void ExploreIsland(char[][] grid, int row, int col)
    {
        // check if we've found an unmarked 'land cell' and that we are still within bounds of the grid
        if (row < 0 || col < 0 || row >= grid.Length || col >= grid[0].Length || grid[row][col] != '1')
            return;

        // At this point we already know we've found earth, thus we can flag it as whatever. 'v' (visited) for example.
        grid[row][col] = 'v';

        // let's try expanding to the up/down/left/right
        ExploreIsland(grid, row + 1, col);
        ExploreIsland(grid, row - 1, col);
        ExploreIsland(grid, row, col + 1);
        ExploreIsland(grid, row, col - 1);
    }
}