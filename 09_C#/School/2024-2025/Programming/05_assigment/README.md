# Calculation Application

This Calculation Application allows users to compute distance, acceleration, or time based on user input. It demonstrates basic mathematical calculations and user input handling in C#.

## Features

1. **User Input**: The program prompts the user to select which value they want to calculate: distance (s), acceleration (a), or time (t).
2. **Calculations**:
   - **Distance (S)**: Calculated using the formula:
     \[
     s = \frac{a \cdot t^2}{2}
     \]
   - **Acceleration (a)**: Calculated using the formula:
     \[
     a = \frac{2 \cdot S}{t^2}
     \]
   - **Time (t)**: Calculated using the formula:
     \[
     t = \sqrt{\frac{2 \cdot S}{a}}
     \]
3. **Input Validation**: The program checks for valid input values and prompts the user to re-enter values if necessary.

## Code Explanation

### Main Method

- The `Main` method serves as the entry point of the program. It prompts the user to select which calculation they want to perform and calls the appropriate method based on the user's choice.

### Calculation Methods

- **CalculateDistance()**: This method prompts the user to enter the values for acceleration and time, then calculates and returns the distance using the specified formula.

- **CalculateAcceleration()**: This method prompts the user to enter the values for distance and time, checks for valid input, and calculates the acceleration.

- **CalculateTime()**: This method prompts the user to enter the values for distance and acceleration, checks for valid input, and calculates the time.

### Restart Method

- **Restart()**: This method prompts the user to decide whether to repeat the calculations. If the user chooses to repeat, it clears the console and calls the `Main` method again. If not, it exits the application.

## Conclusion

This Calculation Application serves as a practical example of basic programming concepts in C#. It demonstrates user input handling, mathematical calculations, and structured programming through the use of methods. The program is designed to be simple yet effective, making it a useful tool for learning and practicing C# programming.