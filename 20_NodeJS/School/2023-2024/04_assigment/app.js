const mysql2 = require("mysql2");
const express = require("express");
const path = require("path");
const connection = mysql2.createConnection(
    {
        host: "127.0.0.1",
        user: "root",
        password: "",
        port: "3306",
        database: "my_db"
    }
);

connection.connect((error) => {
    if(error){
        console.log(error);
    } else {
        console.log("Successfully connected.");
        const firstName = "John";
        const lastName = "Doe";
        connection.query(
            `INSERT INTO users(firstName, lastName) VALUES("${firstName}", "${lastName}");`,
            (err, results) => {
                if (err) {
                    console.error(err);
                } else {
                    console.log("Data inserted successfully.");
                }
            });
        connection.query(
        `SELECT * FROM users;`, (error, data) => {
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
    res.sendFile(path.join(__dirname, 'index.html'));
})

app.post("/save-user", (req, res) => {
    const { firstName, lastName } = req.body;
    connection.query(
        `INSERT INTO users(firstName, lastName) VALUES(?, ?)`,
        [firstName, lastName],
        (err, results) => {
            if (err) {
                console.error(err);
            } else {
                console.log("User data inserted successfully.");
            }
            res.redirect("/");
        }
    );
});

app.get("/show-all-users", (req, res) => {
    connection.query("SELECT * FROM users", (err, data) => {
        if (err) {
            console.error(err);
        } else {
            res.json(data);
        }
    });
});


app.listen(5500);
