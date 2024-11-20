# Node.js Introduction

This project provides a basic introduction to Node.js, demonstrating how to create and use modules, read files asynchronously, and work with classes in JavaScript.

## Project Structure

- **`app.js`**: The main application file that imports and utilizes the `Person` class from `person.js`.
- **`person.js`**: A module that defines a `Person` class and exports it for use in other files.

## Code Explanation

### `app.js`

- **Imports**:
  - Uses Node.js built-in modules `path` and `fs` for file path manipulation and file system operations, respectively.
  - Imports the `Person` class from `person.js`.

- **Person Instance**:
  - Creates an instance of the `Person` class with the name "Martin", last name "N", and ID 1.
  - Logs the `Person` object to the console.

- **File Reading**:
  - Asynchronously reads the contents of `person.js` using `fs.promises.readFile`.
  - Logs the file content to the console if successful, or logs an error if the operation fails.

### `person.js`

- **Person Class**:
  - Defines a `Person` class with a constructor that initializes `name`, `lastName`, and `id` properties.
  - Exports the `Person` class using `module.exports` for use in other files.

## Usage

- Ensure Node.js is installed on your system.
- Run the application by executing `node app.js` in the terminal.
- Observe the console output for the `Person` object and the contents of `person.js`.

## Notes

- This project demonstrates basic Node.js functionalities such as module creation, file reading, and class usage.
- The `Car` class is mentioned in the import statement but is not defined or used in the current code.
