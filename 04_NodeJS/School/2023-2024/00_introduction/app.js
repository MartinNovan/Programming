const path = require("path");
const fs = require("fs");
const { Person, Car } = require("./person.js");

let person = new Person("Martin", "N", 1);
console.log(person);
fs.promises.readFile(path.join(__dirname, "person.js"), "utf-8")
    .then((data) => {
        console.log(data);
    })
    .catch((error) => {
        console.log(error);
    });
