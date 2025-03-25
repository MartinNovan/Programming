# README for Ascending Interval Application

## Overview

This Ascending Interval Application is a console-based program that allows users to input a sequence of numbers and calculates the smallest number, the largest number, and the length of the longest ascending interval within the sequence. The application handles user input and provides feedback for invalid entries.

## How It Works

### Main Functionality

1. **User Input**:
   - The program prompts the user to enter a sequence of numbers separated by commas. It reads this input from the console.

2. **Input Validation**:
   - The application attempts to parse the input into an array of integers. If the input format is invalid (e.g., non-numeric values), it catches a `FormatException` and prompts the user to enter the numbers again.

3. **Calculating Minimum and Maximum**:
   - Once valid input is received, the program calculates the smallest and largest numbers in the array using the `Min()` and `Max()` methods.

4. **Finding the Longest Ascending Interval**:
   - The program calls the `AscendingInterval` method, which iterates through the array to determine the length of the longest ascending sequence of numbers.

5. **Output**:
   - The results are displayed to the user, including the smallest number, the largest number, and the length of the longest ascending interval.

### Ascending Interval Calculation

- The `AscendingInterval` method works by iterating through the array and comparing each number to the previous one. If the current number is greater than the previous number, it increments the current length of the ascending interval. If not, it checks if the current length is greater than the maximum length recorded and resets the current length.

## Code Adjustments

- The program initializes the `numbers` array as an empty array (`int[] numbers = [];`) to ensure it is properly declared before use.
- The input reading logic includes a null check to prevent potential exceptions when parsing the input.

## Conclusion

This Ascending Interval Application serves as a practical example of how to process and analyze a sequence of numbers in a console application using C#. It demonstrates fundamental programming concepts such as user input handling, error handling, and array manipulation. Users can easily find key statistics about their number sequences, making it a useful tool for basic data analysis tasks.