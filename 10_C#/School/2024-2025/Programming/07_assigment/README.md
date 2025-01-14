# Block Management Program

This Block Management Program allows users to input the dimensions of a block (width, height, and depth) and stores the information for multiple blocks. The program calculates and displays various properties of each block, including whether it is a cube, its volume, and its surface area.

## Features

1. **User Input**: The program prompts the user to enter:
   - The width of the block.
   - The height of the block.
   - The depth of the block.
2. **Validation**: The program checks if the entered dimensions are valid (greater than zero) before creating a block.
3. **Block Storage**: Valid blocks are stored in a collection for later retrieval and display.
4. **Output**: The program displays:
   - The properties of each block, including width, height, depth, whether it is a cube, its volume, and surface area.

## Code Explanation

### Main Method

- The `Main` method serves as the entry point of the program. It orchestrates the flow by:
  - Continuously prompting the user for block dimensions until the program is terminated.
  - Calling the `Input` method to gather user input.
  - Calling the `Print` method to display the properties of all stored blocks.

### Input Method

- **Input()**: This method prompts the user to enter the dimensions of a block (width, height, and depth). It performs the following:
  - Reads the dimensions from the console.
  - Validates the dimensions using the `CheckValues` method.
  - If valid, creates a new `Block` object and adds it to the `Blocks` collection. If invalid, it displays an error message.

### Print Method

- **Print()**: This method iterates through the collection of blocks and displays their properties. It prints:
  - The index of each block.
  - The dimensions (width, height, depth).
  - Whether the block is a cube.
  - The volume and surface area of the block.

### Validation Method

- **CheckValues(double width, double height, double depth)**: This method checks if the provided dimensions are greater than zero. It returns a boolean indicating whether the values are valid.

### Block Class

- **Block**: This class represents a block with properties for width, height, and depth. It includes:
  - Properties for calculating volume and surface area.
  - A property to determine if the block is a cube.
  - An `Add` method to combine the dimensions of another block into the current block.

### Block Collection

- **Blocks**: This is a static collection that stores all the created blocks. It is initialized as an empty list and is used to keep track of all blocks entered by the user.

## Conclusion

This Block Management Program serves as a practical example of object-oriented programming concepts in C#. It demonstrates user input handling, validation, and the use of collections to manage multiple objects. The program is designed to be user-friendly and effective, making it a useful tool for learning and practicing C# programming.
