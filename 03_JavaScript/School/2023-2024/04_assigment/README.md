# JavaScript Array Average Calculation

This project consists of a JavaScript script that generates an array of random numbers and calculates their average. The script can be run in a web browser using the provided HTML file or executed locally in a JavaScript editor.

## JavaScript Script (`index.js`)

### Functionality

1. **Array Initialization**:
   - Creates an array `arr` with 300 elements.
   - Fills the array with random integers between 0 and 299 using `Math.random()` and `Math.floor()`.

2. **Average Calculation**:
   - Defines an arrow function `average` that calculates the average of the numbers in the array.
   - Iterates over the array to sum all elements and divides the sum by the array's length to find the average.
   - Logs the average to the console.

### Example Output

- The script logs the average of the 300 random numbers to the console.

## HTML File (`index.html`)

### Purpose

- The HTML file is used to run the JavaScript script in a web browser.
- It includes a `<script>` tag that links to `index.js`, allowing the script to execute when the HTML file is opened in a browser.

### Usage

- Open `index.html` in a web browser to run the script and view the output in the browser's developer console.
- Alternatively, the script can be run directly in a JavaScript editor or console for local testing.

## Notes

- The script uses modern JavaScript features such as arrow functions for concise code.
- The random number generation and average calculation are performed each time the script runs, resulting in different outputs.
- Ensure the `index.js` file is in the same directory as `index.html` for the script to load correctly in the browser.
