# Hangman Game

This console application implements a simple version of the Hangman game. The player has to guess a randomly selected word by suggesting letters within a certain number of guesses. The game displays a hangman graphic that progresses with each incorrect guess.

## Features

1. **Word Selection**: The program randomly selects a word from a predefined list of words.
2. **Hangman Graphics**: The program displays a hangman graphic that updates with each incorrect guess.
3. **Input Handling**: The player can input letters to guess the word. The program checks if the guessed letter is in the word.
4. **Win/Loss Conditions**: The game ends when the player either guesses the word correctly or exhausts the allowed number of incorrect guesses.

## Code Explanation

### Main Method

- The `Main` method serves as the entry point of the program. It initializes the game by selecting a random word and setting up the game state.
- It uses a loop to allow the player to guess letters until they either win or lose.

### Hangman Graphics

- The program uses an array of strings to represent the hangman graphics for each stage of the game.

### Input Handling

- The program collects user input for guessed letters and checks if they are valid.
- It maintains a record of guessed letters and displays them to the player.

### Game Logic

- The program checks if the guessed letter is in the selected word and updates the display accordingly.
- If the player makes too many incorrect guesses, the game ends, and the player is informed of their loss.

## Conclusion

This Hangman Game serves as a practical example of basic programming concepts in C#. It reinforces skills in string manipulation, user input handling, and control flow. The program is designed to be engaging and interactive, making it a useful tool for learning and practicing C# programming.