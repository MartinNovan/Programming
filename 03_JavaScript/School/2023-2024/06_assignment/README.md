# Simpsons Residents Display

This project is a web-based application that displays information about residents of Springfield, specifically characters from "The Simpsons". It uses JavaScript to create objects representing residents and displays their information in an HTML table.

## HTML Structure (`index.html`)

- The HTML file sets up a basic web page with a button and a table to display resident information.
- The button triggers the display of information when clicked.

### Key Elements

- **Button**: `<button onclick="displayInformation()">Display Information</button>` to initiate the display of resident information.
- **Table**: `<table id="obyvateleTable">` to show the list of residents with columns for first name, last name, age, residence, and middle name.

## JavaScript Functionality (`index.js`)

### Main Classes and Functions

- **`Resident` Class**: 
  - Represents a resident with properties for first name, last name, age, and residence.
  - Includes a method `displayInfo` to log resident information to the console.

- **`Simpson` Class**: 
  - Inherits from `Resident` and adds a middle name property.
  - Includes a method `displayFullName` to log the full name to the console.

- **`displayInTable` Method**:
  - Adds a resident's information to the HTML table.

- **`createResidents` Function**:
  - Initializes an array of residents, including both generic residents and Simpsons family members.

- **`displayInformation` Function**:
  - Clears the existing table rows and populates the table with current resident information.

## Usage

- Open `index.html` in a web browser.
- Click the "Display Information" button to populate the table with resident data.

## Notes

- The script uses JavaScript prototypes to define methods for the `Resident` and `Simpson` classes.
- The table is dynamically updated with resident information when the button is clicked.
- The application is designed to run in a web browser and requires user interaction to display data.
