# Moving Rectangle Console Application

This console application demonstrates a simple animation of a moving rectangle on a 20x20 canvas in the console. The rectangle moves within the boundaries of the canvas, bouncing off the edges.

## Features

1. **Canvas Creation**: The program creates a 20x20 character canvas where the rectangle will be drawn.
2. **Rectangle Movement**: The rectangle moves according to its speed in both the x and y directions. When it hits the edge of the canvas, it bounces back.
3. **Dynamic Drawing**: The rectangle is continuously redrawn on the canvas, creating an animation effect.

## Code Explanation

### Main Method

- The `Main` method initializes the canvas and creates a `Rectangle` object. It enters an infinite loop where it:
  - Clears the canvas.
  - Moves the rectangle.
  - Draws the rectangle on the canvas.
  - Updates the console display.

### Drawing and Clearing

- **Draw(char[][] canvas)**: This method constructs a string representation of the canvas and writes it to the console. It uses a `StringBuilder` to efficiently build the output.
- **Clear(char[][] canvas)**: This method clears the canvas by setting all characters to a space.

### Shape Class

- **Shape**: An abstract base class representing a generic shape. It contains properties for position and speed, and a method to move the shape.

### Rectangle Class

- **Rectangle**: A concrete class that inherits from `Shape`. It represents a rectangle on the canvas and includes methods to draw itself and handle movement.
  - **Draw()**: This method draws the rectangle on the canvas using the character '■'.
  - **Move()**: This method updates the rectangle's position and checks for collisions with the canvas edges, reversing direction if necessary.

## Conclusion

This Moving Rectangle Console Application serves as a practical example of basic programming concepts in C#. It demonstrates object-oriented programming principles, including inheritance and encapsulation, as well as basic animation techniques in a console application. The program is designed to be simple yet effective, making it a useful tool for learning and practicing C# programming.