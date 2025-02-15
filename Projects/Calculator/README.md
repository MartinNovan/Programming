# Calculator Application

## Overview

This Calculator application allows users to perform various mathematical operations, including basic arithmetic, trigonometric functions, and exponentiation. It is built using HTML, CSS, and JavaScript, providing an interactive user interface.

## How It Works

### HTML Structure

The HTML file (`index.html`) contains the basic structure of the application:

- Two input fields: one for entering mathematical expressions and another for displaying the result.
- A series of buttons for different operations, including numbers, mathematical functions, and control buttons (clear, delete).

### JavaScript Functionality

The JavaScript file (`app.js`) contains the logic for handling user input and performing calculations:

1. **Input Handling**:
   - The `toInput` function is called when a button is pressed. It updates the input field based on the button pressed.
   - Special handling is provided for operations like clearing the input, deleting the last character, and handling mathematical functions (e.g., SIN, COS, TAN, square root).

2. **Calculating Results**:
   - When the "=" button is pressed, the `calculate` function is called.
   - This function processes the input string, replacing certain characters with their JavaScript equivalents (e.g., replacing "×" with "*").
   - The `eval` function is used to evaluate the mathematical expression, and the result is displayed in the output field.
   - If an error occurs during evaluation, "Error" is displayed in the output field, and the error is logged to the console.

### CSS Styling

The CSS file (`style.css`) styles the application, providing a clean and user-friendly interface:

- The body has a light gray background and rounded corners.
- Input fields and buttons are styled for better visibility and usability.
- Buttons change color on hover, providing visual feedback to the user.

## Conclusion

This Calculator application demonstrates basic web development concepts, including DOM manipulation, event handling, and styling. It serves as a practical example of how to create interactive web applications using HTML, CSS, and JavaScript. Users can easily perform calculations, making it a useful tool for mathematical tasks.