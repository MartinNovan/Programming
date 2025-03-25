# Digit Sum Calculator

This console application calculates the sum of the digits of a number entered by the user. It demonstrates basic string manipulation, user input handling, and arithmetic operations in C#.

## Features

1. **User Input**: The program prompts the user to enter a number for which the digit sum will be calculated.
2. **Input Validation**: It checks if the input contains only digits. If any invalid characters are found, the program informs the user and prompts them to re-enter the number.
3. **Digit Sum Calculation**: The program calculates the sum of the digits in the entered number and displays the result.
4. **Restart Option**: After displaying the result, the program asks the user if they want to re-enter a number. If the user chooses to do so, the program restarts.

## Code Explanation

### Main Method

- The `Main` method serves as the entry point of the program. It initializes the process by prompting the user for input and validating it.
- It uses a character array to store the input and checks each character to ensure they are all digits.

### Input Validation

- The program uses a loop to iterate through the character array and checks if each character is a digit using `char.IsDigit()`.
- If an invalid character is found, the program informs the user and allows them to re-enter the number.

### Digit Sum Calculation

- If the input is valid, the program calculates the sum of the digits by converting each character to an integer and adding it to the total sum.

### Restart Option

- After displaying the result, the program prompts the user to decide whether to re-enter a number. If the user chooses "Y", the program restarts; otherwise, it exits.

## Conclusion

This Digit Sum Calculator serves as a practical example of basic programming concepts in C#. It reinforces skills in string manipulation, user input handling, and arithmetic operations. The program is designed to be user-friendly and effective, making it a useful tool for learning and practicing C# programming.