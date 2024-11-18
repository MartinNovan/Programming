void NavigateMaze(Cell[,,] maze)
{
    for (int x = 0; x < maze.GetLength(0); x++)
    {
        for (int y = 0; y < maze.GetLength(1); y++)
        {
            for (int z = 0; z < maze.GetLength(2); z++)
            {
                Cell cell = maze[x, y, z];
                if (cell.IsWall)
                {
                    Console.WriteLine("Encountered wall at (" + x + ", " + y + ", " + z + ").");
                }
                else if (cell.IsExit)
                {
                    Console.WriteLine("Exit found at (" + x + ", " + y + ", " + z + ").");
                    return;
                }
                else
                {
                    Console.WriteLine("Moving through (" + x + ", " + y + ", " + z + ").");
                }
            }
        }
    }
    Console.WriteLine("No exit found in the maze.");
}
