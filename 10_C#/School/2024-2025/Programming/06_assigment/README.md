# Geometric Sequence Calculator

This Geometric Sequence Calculator allows users to input an initial value, a step, and the number of repetitions to generate a geometric sequence. The program calculates and displays the elements of the sequence, their sum, and the sum of the first and fifth elements if applicable.

## Features

1. **User Input**: The program prompts the user to enter:
   - The initial value of the sequence.
   - The step (common ratio) for the geometric sequence.
   - The number of repetitions (elements) in the sequence.
2. **Geometric Sequence Generation**: The program generates the geometric sequence based on the provided inputs.
3. **Output**: The program displays:
   - The elements of the geometric sequence.
   - The sum of all elements in the sequence.
   - The sum of the first and fifth elements if the number of repetitions is 5 or more.

## Code Explanation

### Main Method

- The `Main` method serves as the entry point of the program. It orchestrates the flow by:
  - Retrieving the initial value, step, and number of repetitions from the user.
  - Validating the step to ensure it is less than 1.
  - Generating the geometric sequence using the `GenerateGeometricSequence` method.
  - Displaying the sequence and calculating the sum using the `DisplaySequence` and `CalculateSum` methods.

### User Input Methods

- **GetInitialValue()**: Prompts the user to enter the initial value and returns it as a double.
  
- **GetStep()**: Prompts the user to enter the step (common ratio) and returns it as a double.

- **GetRepetitions()**: Prompts the user to enter the number of repetitions and returns it as an integer.

### Sequence Generation Method

- **GenerateGeometricSequence(double initialValue, double step, int repetitions)**: This method generates the geometric sequence based on the initial value, step, and number of repetitions. It returns an array of doubles representing the sequence.

### Output Method

- **DisplaySequence(double[] sequence)**: This method takes the generated sequence as input and prints each element to the console.

### Sum Calculation Method

- **CalculateSum(double[] sequence)**: This method calculates the sum of the elements in the sequence and returns the total.

## Conclusion

This Geometric Sequence Calculator serves as a practical example of basic programming concepts in C#. It demonstrates user input handling, array manipulation, and structured programming through the use of methods. The program is designed to be simple yet effective, making it a useful tool for learning and practicing C# programming.