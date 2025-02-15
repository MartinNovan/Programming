# Bridge Game Simulation

## Task Overview

The objective of this task was to simulate a game inspired by the "Squid Game" bridge challenge. The game consists of 20 panels, each of which can either be safe or broken. The goal is to determine the average number of panels a player can cross before falling through a broken panel.

### Game Rules

1. The player starts on the first panel and attempts to cross to the next panel.
2. Each panel has a 50% chance of being safe or broken, determined randomly using the `random()` function.
3. The game continues until the player either:
   - Falls through a broken panel, or
   - Successfully crosses all 20 panels.

### Implementation

The script consists of the following functions:

1. **simulate_game()**: This function simulates a single game session. It rolls through the panels until the player either falls or successfully crosses all panels, returning the number of successfully crossed panels.

2. **main()**: This function runs the simulation for a specified number of trials (100,000 in this case) and calculates the average number of panels crossed by the player.

### Results

When the script is executed, it outputs the average number of panels crossed by the player. The results will show that the average number of panels crossed is approximately 1, reflecting the game's inherent randomness and the 50% chance of falling on each panel.

### Conclusion

This simulation illustrates how randomness can be modeled in programming. By running a large number of trials, we can observe patterns and averages that emerge from random processes. Understanding these concepts is essential in fields such as game design, statistics, and simulations.