def navigate_maze(maze):
    for x in range(len(maze)):
        for y in range(len(maze[x])):
            for z in range(len(maze[x][y])):
                cell = maze[x][y][z]
                if cell.is_wall:
                    print(f"Encountered wall at ({x}, {y}, {z}).")
                elif cell.is_exit:
                    print(f"Exit found at ({x}, {y}, {z}).")
                    return
                else:
                    print(f"Moving through ({x}, {y}, {z}).")
    print("No exit found in the maze.")
