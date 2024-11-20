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
  const names = ["Alex", "Sam", "Jordan", "Taylor"];
  return names[Math.floor(Math.random() * names.length)];
}

function getRandomLastName() {
    const names = ["Smith", "Johnson", "Brown", "Williams"];
    return names[Math.floor(Math.random() * names.length)];
  }

function getRandomId() {
  return Math.floor(Math.random() * 1000);
}
