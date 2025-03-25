# Cone Calculation Program

This program calculates the surface area and volume of a cone based on user input for the height and radius of the cone. It demonstrates basic mathematical calculations and user input handling in C#.

## Features

1. **User Input**: The program prompts the user to enter the height and radius of the cone.
2. **Calculations**:
   - **Surface Area**: The program calculates the surface area of the cone using the formula:
     \[
     \text{Surface Area} = \frac{\pi \cdot r^2 \cdot h}{3}
     \]
   - **Volume**: The program calculates the volume of the cone using the formula:
     \[
     \text{Volume} = \pi \cdot r \cdot (r + \sqrt{h^2 + r^2})
     \]
3. **Output**: The results for both the surface area and volume are displayed to the user.

## Code Explanation

### Main Method

- The `Main` method serves as the entry point of the program. It orchestrates the flow of the program by:
  - Calling `GetHeight()` to retrieve the height of the cone from the user.
  - Calling `GetRadius()` to retrieve the radius of the cone from the user.
  - Calculating the surface area and volume by calling `CalculateSurfaceArea(radius, height)` and `CalculateVolume(radius, height)`.
  - Finally, it displays the results by calling `DisplayResults(surfaceArea, volume)`.

### User Input Methods

- **GetHeight()**: This method prompts the user to enter the height of the cone. It reads the input from the console and converts it to an integer. If the input is null, it throws an `InvalidOperationException`.
  
- **GetRadius()**: Similar to `GetHeight()`, this method prompts the user to enter the radius of the cone and returns it as an integer.

### Calculation Methods

- **CalculateSurfaceArea(int radius, int height)**: This method calculates the surface area of the cone using the formula provided. It takes the radius and height as parameters and returns the calculated surface area as a double.

- **CalculateVolume(int radius, int height)**: This method calculates the volume of the cone using the specified formula. It also takes the radius and height as parameters and returns the calculated volume as a double.

### Output Method

- **DisplayResults(double surfaceArea, double volume)**: This method takes the calculated surface area and volume as parameters and prints them to the console in a user-friendly format.

## Conclusion

This Cone Calculation Program serves as a practical example of basic programming concepts in C#. It demonstrates user input handling, mathematical calculations, and structured programming through the use of methods. The program is designed to be simple yet effective, making it a useful tool for learning and practicing C# programming.