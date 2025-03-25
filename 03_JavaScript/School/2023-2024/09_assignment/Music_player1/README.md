# Music Player

This project is a simple web-based music player that allows users to play, pause, and stop an audio track. The player is built using HTML, CSS, and JavaScript.

## HTML Structure (`index.html`)

- The HTML file sets up a basic web page with an audio player and control buttons.

### Key Elements

- **Audio Player**: 
  - `<audio id="audioPlayer" controls>` provides the audio playback functionality.
  - Includes a source for the audio file: `Macklemore - Cant Hold Us.mp3`.

- **Control Buttons**: 
  - **Play**: `<button onclick="playAudio()">Play</button>` to start audio playback.
  - **Pause**: `<button onclick="pauseAudio()">Pause</button>` to pause audio playback.
  - **Stop**: `<button onclick="stopAudio()">Stop</button>` to stop audio playback and reset the track.

## JavaScript Functionality

- **`playAudio()`**: Plays the audio track.
- **`pauseAudio()`**: Pauses the audio track.
- **`stopAudio()`**: Stops the audio track and resets the playback position to the beginning.

## CSS Styling

- The CSS provides styling for the player interface, including layout, colors, and button styles.

### Key Styles

- **Player Container**: 
  - Centered on the page with a white background and shadow for a clean look.
- **Buttons**: 
  - Styled with a purple background, white text, and rounded corners.
  - Hover effect changes the button color for interactivity.

## Usage

- Open `index.html` in a web browser.
- Use the control buttons to play, pause, or stop the audio track.

## Notes

- The application is designed to run in a web browser and requires user interaction to control playback.
- Ensure the audio file `Macklemore - Cant Hold Us.mp3` is in the same directory as the HTML file for playback to work.
