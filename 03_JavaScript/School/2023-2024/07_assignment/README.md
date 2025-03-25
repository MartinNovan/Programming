# Dynamic Table Generator

This project is a web-based application that allows users to dynamically create tables with a specified number of rows and columns. The application is built using HTML, CSS, and JavaScript.

## HTML Structure (`index.html`)

- The HTML file sets up a basic web page with input fields for specifying the number of rows and columns, and a button to generate the table.

### Key Elements

- **Button**: `<input class="button" type="button" onclick="createTable()" value="Create Table">` to initiate the creation of the table.
- **Input Fields**: 
  - `<input id="rows" type="number" value="1" max="50" min="1" required>` for specifying the number of rows.
  - `<input id="columns" type="number" value="1" max="50" min="1" required>` for specifying the number of columns.

## JavaScript Functionality (`index.js`)

### Main Function

- **`createTable()`**: 
  - Retrieves the number of rows and columns from the input fields.
  - Checks if a table already exists and removes it if necessary.
  - Creates a new table with the specified dimensions and populates it with sequential numbers.
  - Appends the table to the document body.

## CSS Styling (`styles.css`)

- The CSS file provides styling for the body, table, input fields, and other elements to enhance the visual appearance of the page.

### Key Styles

- **Body**: 
  - Background color: #333333
  - Text color: antiquewhite
  - Font size: 2em
- **Table**: 
  - Border: 0.5px solid #999999
  - Alternating row colors for better readability.

## Usage

- Open `index.html` in a web browser.
- Enter the desired number of rows and columns in the input fields.
- Click the "Create Table" button to generate the table.

## Notes

- The application is designed to run in a web browser and requires user interaction to generate the table.
- The table is dynamically updated based on the input values, allowing for flexible table creation.
