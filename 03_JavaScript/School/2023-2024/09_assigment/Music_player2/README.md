# Music Player 2

This project is a web-based music player that allows users to play, pause, and stop audio tracks. It features a playlist with a search function and is built using Node.js, Express, and EJS for server-side rendering.

## Server Setup (`server.js`)

- **Express Server**: 
  - Serves static files and renders the main page using EJS.
  - Reads the music directory to list available `.mp3` files.

- **Routes**:
  - **`/`**: Main route that renders the index page with a list of music files.

## HTML and EJS Template (`index.ejs`)

- **Audio Player**: 
  - `<audio id="audioPlayer" controls>` for audio playback.
  - Dynamic source loading based on user selection.

- **Playlist**: 
  - Displays available music files.
  - Includes a search box to filter songs.

## CSS Styling (`style.css`)

- **Layout**: 
  - Centered player with a sidebar playlist.
  - Responsive design with a modern look.

- **Buttons**: 
  - Styled with hover effects for interactivity.

## JavaScript Functionality

- **Audio Controls**: 
  - Functions to play, pause, and stop audio.
  - Load and play selected audio files from the playlist.

- **Playlist Management**: 
  - Toggle playlist visibility.
  - Search functionality to filter songs.

## Usage

- Run the server using Node.js.
- Open `http://localhost:5000` in a web browser.
- Use the player controls and playlist to manage audio playback.

## Notes

- Ensure the `music` directory contains `.mp3` files for playback.
- The application requires Node.js and Express to run.
