# Casino Application

## Overview

This Casino Application is a console-based game that allows users to engage in various gambling games, specifically Roulette and a Random Number Guessing game. The application is designed to simulate a casino experience, where users can place bets, win or lose credits, and make decisions on their gameplay. It incorporates user input validation and provides a user-friendly interface for interaction.

## How It Works

### Main Functionality

1. **Entry Check**:
   - The application begins by checking if the user has money to play. This is done through the `CheckMoney` method, which prompts the user to confirm their financial status. If the user responds negatively or does not have money, they are denied entry into the casino.

2. **Setting a Credit Limit**:
   - If the user confirms they have money, they are prompted to set a credit limit using the `SetLimit` method. This limit determines how much they can bet during the games. The application ensures that the entered amount is a positive integer, prompting the user to re-enter if the input is invalid.

3. **Game Selection**:
   - Once the credit limit is set, users can choose between two games:
     - **Roulette**: A classic casino game where players can bet on specific numbers or colors.
     - **Guess a Random Number from 1 to 50**: A simpler game where players guess a number to win credits.
   - Users can also exit the application at any time by selecting the exit option.

### Game Logic

#### Roulette

- The user is prompted to place a bet and choose whether to bet on a number (0-36) or a color (red or black).
- The winning number is randomly generated using the `Random` class, and the application checks if the user's bet matches the winning number or color.
- If the user wins by betting on a number, they receive a payout of 35 times their bet. If they bet on a color and win, they receive double their bet.
- The application handles insufficient credits by prompting the user to check their money again if they attempt to bet more than they have.
- After each round, the user is informed of their current credit balance, and if they run out of credits, the game ends.

#### Random Number Guessing

- In this game, the user places a bet and guesses a number between 0 and 50.
- The winning number is randomly generated, and if the user's guess matches the winning number, they win 50 times their bet.
- The application checks for valid input, ensuring the guessed number is within the specified range.
- Similar to Roulette, if the user loses, their credits are deducted, and they are informed of their remaining balance.

### End Game Options

- After each game, users are presented with options to:
  - Play the same game again.
  - Choose a different game.
  - Exit the application.
- The `EndGame` method handles user input for these options, ensuring that invalid inputs are managed gracefully by prompting the user to enter a valid choice.

### User Input Validation

- Throughout the application, user inputs are validated to prevent errors and ensure a smooth gaming experience. For example:
  - The `CheckMoney` method ensures that the user inputs either "Y" or "N" (with "N" as the default).
  - The `SetLimit` method checks that the entered credit limit is a positive integer.
  - Game selections and betting amounts are validated to ensure they are within acceptable ranges.

## Conclusion

This Casino Application provides an engaging and interactive way to experience gambling games in a console environment. It demonstrates essential programming concepts such as user input handling, random number generation, and game logic implementation in C#. The application not only allows users to test their luck but also teaches them about managing credits and making strategic decisions in a gaming context. Overall, it serves as a practical example of how to create a simple yet effective console application in C#.