# Tic Tac Toe Game

This console application implements a simple version of the Tic Tac Toe game. Two players take turns to place their tokens (X and O) on a 3x3 grid, and the first player to align three tokens in a row, column, or diagonal wins the game.

## Features

1. **Game Board**: The program displays a 3x3 grid representing the game board.
2. **Player Turns**: Players alternate turns, and the program prompts the current player to enter their move.
3. **Input Validation**: The program checks if the selected cell is free before allowing a player to place their token.
4. **Win Condition**: The game checks for a win condition after each move and announces the winner.

## Code Explanation

### Main Method

- The `Main` method serves as the entry point of the program. It initializes the game board and manages the game loop, allowing players to take turns until a winner is determined.

### Board Class

- The `Board` class represents the game board and contains methods for printing the board, checking if a cell is free, and determining if a player has won.

### Game Logic

- The program uses methods to check for winning conditions in rows, columns, and diagonals.
- Players input their moves by specifying the coordinates of the cell they wish to occupy.

## Conclusion

This Tic Tac Toe Game serves as a practical example of basic programming concepts in C#. It reinforces skills in user input handling, control flow, and object-oriented programming. The program is designed to be engaging and interactive, making it a useful tool for learning and practicing C# programming.