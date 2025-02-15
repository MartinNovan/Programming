# Node.js HTTP Server

This project demonstrates a simple HTTP server built using Node.js. The server serves HTML, CSS, and JavaScript files, providing a basic web page with styled content and a JavaScript alert.

## Project Structure

- **`app.js`**: The main server file that handles HTTP requests and serves static files.
- **`index.html`**: The HTML file that forms the main content of the web page.
- **`script.js`**: A JavaScript file that triggers an alert when the page is loaded.
- **`styles.css`**: A CSS file that styles the HTML content.

## Code Explanation

### `app.js`

- **Server Setup**:
  - Uses the `http` module to create a server that listens on port 5500.
  - Handles requests for HTML, CSS, and JavaScript files.

- **Request Handling**:
  - Serves `index.html` when the root URL (`/`) is requested.
  - Serves CSS files with the `text/css` content type.
  - Serves JavaScript files with the `text/js` content type.
  - Uses promises to read files asynchronously and handle errors.

### `index.html`

- **HTML Structure**:
  - Includes a link to `styles.css` for styling.
  - Includes a script tag to load `script.js`.
  - Displays a heading with the text "Hello".

### `script.js`

- **JavaScript Functionality**:
  - Displays an alert with the message "Hello" when the page is loaded.

### `styles.css`

- **CSS Styling**:
  - Styles the `<h1>` element with a blue color.

## Usage

- Ensure Node.js is installed on your system.
- Run the server by executing `node app.js` in the terminal.
- Open a web browser and navigate to `http://localhost:5500` to view the page.

## Notes

- This project demonstrates basic server-side file serving with Node.js.
- The server is configured to handle requests for HTML, CSS, and JavaScript files.
- The content type for JavaScript files should be corrected to `application/javascript` for proper MIME type handling.
