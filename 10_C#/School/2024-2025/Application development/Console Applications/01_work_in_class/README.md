# Application Development - Console Application

This console application serves as a simple demonstration of string manipulation, user input handling, and basic arithmetic operations in C#. It allows users to input a series of numbers separated by commas and calculates their sum.

## Features

1. **String Manipulation**: The program demonstrates how to create and manipulate strings, including accessing individual characters.
2. **User Input**: The program prompts the user to enter values separated by commas.
3. **Input Validation**: It checks if the user input matches specific commands ("calculate" or "CALCULATE") before proceeding with calculations.
4. **Sum Calculation**: The program splits the input string into an array, converts each value to an integer, and calculates the sum of the numbers.

## Code Explanation

### Main Method

- The `Main` method serves as the entry point of the program. It initializes a string, prints the first character, and prompts the user for input.
- It checks if the input command is either "calculate" or "CALCULATE". If valid, it proceeds to calculate the sum of the numbers provided.

### Input Handling

- **Console.ReadLine()**: Reads the user input from the console.
- **String.Split()**: Splits the input string into an array based on commas.

### Sum Calculation

- A loop iterates through the array of values, attempting to parse each value as an integer. If successful, it adds the value to the sum.
- The final sum is printed to the console.

## Conclusion

This program is a repetition from the previous year in the Application Development course. It reinforces fundamental programming concepts such as string manipulation, user input handling, and basic arithmetic operations in C#. The program is designed to be simple yet effective, making it a useful tool for learning and practicing C# programming.