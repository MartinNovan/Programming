# Palindrome Checker

This project is a simple web-based palindrome checker. It allows users to input a string and checks whether the string is a palindrome, ignoring special characters and case sensitivity.

## HTML Structure (`index.html`)

- The HTML file sets up a basic web page with a text input, a button, and a display area for the result.
- The button triggers the palindrome check when clicked.

### Key Elements

- **Input Field**: `<input type="text" id="input">` for user input.
- **Button**: `<button id="button" onclick="palindrome()">Check</button>` to initiate the palindrome check.
- **Output Display**: `<div><a id="output">is it a palindrome: N/A</a></div>` to show the result.

## JavaScript Functionality (`script.js`)

### Main Function

- **`palindrome()`**: 
  - Retrieves the input value from the text field.
  - Calls `containsSpecialCharacters()` to check for special characters and determine if the input is a palindrome.

### Helper Function

- **`containsSpecialCharacters(input)`**:
  - Uses a regular expression to check for special Czech characters.
  - Alerts the user if special characters are found and sets the output to "N/A".
  - Cleans the input by removing non-alphanumeric characters and converting it to lowercase.
  - Reverses the cleaned string and compares it to the original cleaned string.
  - Updates the output to indicate whether the input is a palindrome.

## Usage

- Open `index.html` in a web browser.
- Enter a string in the input field and click "Check".
- The result will be displayed below the button, indicating whether the input is a palindrome.

## Notes

- The script is designed to run in a web browser and requires user interaction.
- Special characters specific to the Czech language are checked and will trigger a warning if present.
- The palindrome check ignores spaces, punctuation, and case differences.
