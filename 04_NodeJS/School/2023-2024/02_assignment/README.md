# Express Random Person Generator

This project is a simple Express.js application that serves a static HTML page and provides an API endpoint to generate random person data. The application demonstrates basic server setup, static file serving, and JSON response handling.

## Project Structure

- **`app.js`**: The main server file that sets up the Express application and defines routes.
- **`person.js`**: A module that defines a `Person` class.
- **`index.html`**: The HTML file served as the main page.
- **`styles.css`**: A CSS file for styling the HTML content.

## Code Explanation

### `app.js`

- **Express Setup**:
  - Creates an Express application and listens on port 7707.
  - Serves static files from the current directory.

- **Routes**:
  - **`/`**: Serves the `index.html` file.
  - **`/random-person`**: Returns a JSON object representing a randomly generated person.

- **Helper Functions**:
  - `getRandomName()`: Returns a random first name from a predefined list.
  - `getRandomLastName()`: Returns a random last name from a predefined list.
  - `getRandomId()`: Generates a random ID number.

### `person.js`

- **Person Class**:
  - Defines a `Person` class with a constructor that initializes `firstName`, `lastName`, and `id` properties.
  - Exports the `Person` class for use in other files.

### `index.html`

- **HTML Structure**:
  - Displays a heading with the text "John Doe".
  - Links to `styles.css` for styling.

### `styles.css`

- **CSS Styling**:
  - Styles the `<h1>` element with a blue color and a specific font.

## Installation and Usage

1. **Install Node.js**: Ensure Node.js is installed on your system.
2. **Install Express**: Run `npm install express` in the project directory to install the Express module.
3. **Run the Server**: Execute `node app.js` in the terminal to start the server.
4. **Access the Application**: Open a web browser and navigate to `http://localhost:7707` to view the page.
5. **View a random person**: Open a web browser and navigate to `http://localhost:7707/random-person` to view the generated .json object with random person.


## Notes

- This project demonstrates basic Express.js functionalities such as serving static files and handling JSON responses.
- The names used in the script are fictional and used for demonstration purposes.
