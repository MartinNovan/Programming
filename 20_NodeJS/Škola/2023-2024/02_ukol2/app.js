const mysql2 = require("mysql2");
const express = require("express");
const path = require("path");
const connection = mysql2.createConnection(
    {
        host: "127.0.0.1",
        user: "root",
        password: "",
        port: "3306",
        database: "moje_db"
    }
);

connection.connect((error) => {
    if(error){
        console.log(error);
    } else {
        console.log("Úspěšně připojeno.");
        const jmeno = "Martin";
        const prijimeni = "Novan";
        connection.query(
            `INSERT INTO uzivatele(jmeno, prijimeni) VALUES("${jmeno}", "${prijimeni}");`,
            (err, results) => {
                if (err) {
                    console.error(err);
                } else {
                    console.log("Data inserted successfully.");
                }
            });
        connection.query(
        `SELECT * FROM uzivatele;`, (error, data) => {
            if(error) console.log(error);
            else {
                console.log(data);
            }
        }
        )
    }
});

const app = express();
app.use(express.static(__dirname));
app.use(express.urlencoded({extended: true}));
app.use(express.json());


app.get("/", (req, res) => {
    res.sendFile(path.join(dirname, 'index.html'));
})

app.post("/uloz-uzivatele", (req, res) => {
    console.log(req.body);
    res.redirect("/");
});

app.get("/zobraz-vsechny-osoby", (req, res) => {
    connection.query("SELECT * FROM uzivatele", (err, data) => {
        if (err) {
            console.error(err);
        } else {
            res.json(data);
        }
    });
});


app.listen(5500);