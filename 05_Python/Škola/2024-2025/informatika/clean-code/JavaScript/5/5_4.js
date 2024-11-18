function navigateMaze(maze) {
  for (let x = 0; x < maze.length; x++) {
      for (let y = 0; y < maze[x].length; y++) {
          for (let z = 0; z < maze[x][y].length; z++) {
              let cell = maze[x][y][z];
              if (cell.isWall) {
                  console.log("Encountered wall at (" + x + ", " + y + ", " + z + ").");
              } else if (cell.isExit) {
                  console.log("Exit found at (" + x + ", " + y + ", " + z + ").");
                  return;
              } else {
                  console.log("Moving through (" + x + ", " + y + ", " + z + ").");
              }
          }
      }
  }
  console.log("No exit found in the maze.");
}
