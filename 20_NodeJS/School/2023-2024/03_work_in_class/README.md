# Express.js Session and EJS Example

This project demonstrates the use of Express.js with sessions and EJS templating. It tracks the number of times a page has been viewed and allows users to submit their first and last names, which are then displayed on the page.

## Project Structure

- **`app.js`**: The main server file that sets up the Express application, handles sessions, and defines routes.
- **`views/index.ejs`**: An EJS template file that renders the HTML content dynamically based on session data.

## Code Explanation

### `app.js`

- **Express Setup**:
  - Creates an Express application and listens on port 7700.
  - Uses middleware for serving static files, parsing JSON and URL-encoded data, and managing sessions.

- **Session Management**:
  - Uses `express-session` to track the number of page views and store the user's full name.

- **Routes**:
  - **`GET /`**: Increments the view count and renders `index.ejs` with the current view count and full name.
  - **`POST /`**: Updates the session with the user's full name and redirects to the home page.

### `views/index.ejs`

- **EJS Templating**:
  - Uses EJS syntax (`<% %>` and `<%= %>`) to embed JavaScript logic and variables within the HTML.
  - Displays the page view count and the user's full name if available.
  - Provides a form for users to submit their first and last names.

## Installation and Usage

1. **Install Node.js**: Ensure Node.js is installed on your system.
2. **Install Dependencies**: Run the following command in the project directory to install the required modules:
   ```bash
   npm install express express-session
   ```
3. **Run the Server**: Execute `node app.js` in the terminal to start the server.
4. **Access the Application**: Open a web browser and navigate to `http://localhost:7700` to view the page.

## What is an EJS File?

- **EJS (Embedded JavaScript Templates)**: EJS is a simple templating language that lets you generate HTML markup with plain JavaScript. It is used to create dynamic web pages by embedding JavaScript code within HTML. EJS files typically have the `.ejs` extension and are rendered on the server side to produce HTML that is sent to the client.

## Notes

- This project demonstrates basic session management and dynamic content rendering with EJS in an Express.js application.
- The application uses sessions to persist data across requests, allowing for features like view counting and user input storage.
