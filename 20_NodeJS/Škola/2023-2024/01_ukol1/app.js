const express = require("express");
const Person = require("./person");

const app = express();
app.listen(7707);

app.use(express.static(__dirname));

app.get("/", (req, res) => {
  res.sendFile(__dirname + "/index.html");
});

app.get("/random-person", (req, res) => {
  const randomPerson = new Person(getRandomName(), getRandomLastName(), getRandomId());
  res.json(randomPerson);
});

function getRandomName() {
  const names = ["Fanda", "Šimon", "Zdenda", "Péťa"];
  return names[Math.floor(Math.random() * names.length)];
}

function getRandomLastName() {
    const names = ["Poupa", "Šupola", "Chudoba", "Januške"];
    return names[Math.floor(Math.random() * names.length)];
  }

function getRandomId() {
  return Math.floor(Math.random() * 1000);
}
