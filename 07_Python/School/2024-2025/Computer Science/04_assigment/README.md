# Game Analysis Using Random Number Generation (RNG)

## Task Overview

The objective of this task was to create a simple Python script that simulates a game called "Roll Exactly 10." The game involves rolling a six-sided die and keeping track of the total score based on specific rules. The goal is to determine the average number of rolls it takes to reach a score of exactly 10.

### Game Rules

1. A six-sided die is rolled.
2. The total score is calculated:
   - If the total score is less than 10, the rolled value is added to the score.
   - If the total score exceeds 10, the rolled value is subtracted from the score.
   - The game ends when the score equals 10.
3. The output should show how many rolls it takes to reach the score of 10.

### Implementation

The script consists of two main functions:

1. **simulate_game()**: This function simulates a single game session. It rolls the die until the score reaches 10 and counts the number of rolls taken.

2. **average_rolls()**: This function runs the `simulate_game()` function 100,000 times to calculate the average number of rolls required to reach a score of 10.

### Results

When the script is executed, it outputs the average number of rolls per game. The results show that the average number of rolls tends to be consistent across multiple runs, demonstrating that randomness in this context is not entirely unpredictable.

### Conclusion

This exercise illustrates how randomness can be analyzed and quantified in programming. By simulating a game and collecting data over many trials, we can observe patterns and averages that emerge from seemingly random processes. This understanding is crucial in fields such as statistics, game design, and simulations.