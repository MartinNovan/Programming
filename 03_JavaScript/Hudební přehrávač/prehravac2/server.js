const express = require('express');
const fs = require('fs');
const path = require('path');

const app = express();
const PORT = 5000;
const musicDir = path.join(__dirname, 'music');

// Nastavení EJS jako šablonovacího motoru
app.set('view engine', 'ejs');

// Statické soubory
app.use('/views', express.static(path.join(__dirname, 'views')));

// Obsluha statických souborů z adresáře music
app.use('/music', express.static(musicDir));

// Route pro hlavní stránku
app.get('/', (req, res) => {
    fs.readdir(musicDir, (err, files) => {
        if (err) {
            return res.status(500).send('Chyba při načítání souborů');
        }
        const musicFiles = files.filter(file => path.extname(file) === '.mp3');
        res.render('index', { musicFiles });
    });
});

// Spuštění serveru
app.listen(PORT, () => {
    console.log(`Server běží na http://localhost:${PORT}`);
});
