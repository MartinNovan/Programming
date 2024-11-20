const express = require('express');
const fs = require('fs');
const path = require('path');

const app = express();
const PORT = 5000;
const musicDir = path.join(__dirname, 'music');

// Set EJS as the templating engine
app.set('view engine', 'ejs');

// Static files
app.use('/views', express.static(path.join(__dirname, 'views')));

// Serve static files from the music directory
app.use('/music', express.static(musicDir));

// Route for the main page
app.get('/', (req, res) => {
    fs.readdir(musicDir, (err, files) => {
        if (err) {
            return res.status(500).send('Error loading files');
        }
        const musicFiles = files.filter(file => path.extname(file) === '.mp3');
        res.render('index', { musicFiles });
    });
});

// Start the server
app.listen(PORT, () => {
    console.log(`Server running at http://localhost:${PORT}`);
});
