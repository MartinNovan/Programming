# Interactive Canvas Drawing

This project is a web-based application that uses the HTML5 `<canvas>` element to create an interactive drawing. The application allows users to move a circle around the canvas with their mouse.

## HTML Structure (`index.html`)

- The HTML file sets up a basic web page with a `<canvas>` element for drawing.

### Key Elements

- **Canvas**: `<canvas id="canvas" width="700" height="700"></canvas>` provides a drawing area for the application.

## JavaScript Functionality (`index.js`)

### Main Features

- **Mouse Interaction**: 
  - Listens for mouse movement over the canvas and updates the position of a circle based on the mouse coordinates.

- **Drawing Function**:
  - Clears the canvas and redraws a blue circle at the current mouse position.
  - Draws a static green square on the canvas.
  - Uses `requestAnimationFrame` to continuously update the drawing, creating a smooth animation effect.

## Usage

- Open `index.html` in a web browser.
- Move the mouse over the canvas to see the circle follow the cursor.

## Notes

- The application is designed to run in a web browser and requires user interaction to move the circle.
- The canvas size is set to 700x700 pixels, but this can be adjusted in the HTML file if needed.
- The script uses the `DOMContentLoaded` event to ensure the canvas is fully loaded before attempting to draw on it.
