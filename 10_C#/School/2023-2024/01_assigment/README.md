# README for Simple Calculator Application

## Overview

This Simple Calculator Application is a console-based program that allows users to perform basic arithmetic operations. Users can input two numbers and an operator to calculate the result. The application supports addition, subtraction, multiplication, division, and exponentiation.

## How It Works

### Main Functionality

1. **User Input**:
   - The program prompts the user to enter the first number, the operator, and the second number. It reads these inputs from the console.

2. **Operation Selection**:
   - The user can choose from the following operators:
     - `+` for addition
     - `-` for subtraction
     - `*` for multiplication
     - `/` for division
     - `^` for exponentiation

3. **Calculation**:
   - Based on the operator entered, the program performs the corresponding arithmetic operation using a `switch` statement:
     - **Addition**: Adds the two numbers.
     - **Subtraction**: Subtracts the second number from the first.
     - **Multiplication**: Multiplies the two numbers.
     - **Division**: Divides the first number by the second, with a check to prevent division by zero.
     - **Exponentiation**: Raises the first number to the power of the second.

4. **Output**:
   - The result of the calculation is displayed to the user. If an invalid operator is entered, an error message is shown.

### Error Handling

- The application includes basic error handling for invalid operators and division by zero. If the user attempts to divide by zero, a message is displayed, and the program terminates gracefully.

## Conclusion

This Simple Calculator Application serves as a practical example of how to implement basic arithmetic operations in a console application using C#. It demonstrates fundamental programming concepts such as user input handling, conditional statements, and mathematical operations. Users can easily perform calculations, making it a useful tool for quick arithmetic tasks.