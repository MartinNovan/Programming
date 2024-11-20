# Old code with complex logic
# def navigate_maze(maze):
#     for x in range(len(maze)):
#         for y in range(len(maze[x])):
#             for z in range(len(maze[x][y])):
#                 cell = maze[x][y][z]
#                 if cell.is_wall:
#                     print(f"Encountered wall at ({x}, {y}, {z}).")
#                 elif cell.is_exit:
#                     print(f"Exit found at ({x}, {y}, {z}).")
#                     return
#                 else:
#                     print(f"Moving through ({x}, {y}, {z}).")
#     print("No exit found in the maze.")

# New code with simplified logic
def navigate_maze(maze):
    for x, row in enumerate(maze):
        for y, column in enumerate(row):
            for z, cell in enumerate(column):
                if process_cell(cell, x, y, z):
                    return
    print("No exit found in the maze.")

def process_cell(cell, x, y, z):
    if cell.is_wall:
        print(f"Encountered wall at ({x}, {y}, {z}).")
    elif cell.is_exit:
        print(f"Exit found at ({x}, {y}, {z}).")
        return True
    else:
        print(f"Moving through ({x}, {y}, {z}).")
    return False