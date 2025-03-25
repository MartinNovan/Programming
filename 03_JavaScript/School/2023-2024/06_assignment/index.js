function Resident(firstName, lastName, age) {
    this.firstName = firstName;
    this.lastName = lastName;
    this.age = age;
    this.residence = "Springfield";
}

Resident.prototype.displayInfo = function() {
    console.log(`Name: ${this.firstName} ${this.lastName}, Age: ${this.age}, Residence: ${this.residence}`);
};

var krustyTheClown = new Resident("Krusty", "The Clown", 59);
var rodFlanders = new Resident("Rod", "Flanders", 10);
var ralphWiggum = new Resident("Ralph", "Wiggum", 8);

krustyTheClown.displayInfo();
rodFlanders.displayInfo();
ralphWiggum.displayInfo();

function Simpson(firstName, lastName, age, middleName) {
    Resident.call(this, firstName, lastName, age);
    this.middleName = middleName;
}

Simpson.prototype = Object.create(Resident.prototype);

Simpson.prototype.displayFullName = function() {
    console.log(`Full Name: ${this.firstName} ${this.middleName} ${this.lastName}`);
};

var homer = new Simpson("Homer", "Simpson", 42, "Jay");
var marge = new Simpson("Marge", "Simpson", 34, "Jaqueline");
var bart = new Simpson("Bart", "Simpson", 10, "JoJo");

homer.displayInfo();
homer.displayFullName();

marge.displayInfo();
marge.displayFullName();

bart.displayInfo();
bart.displayFullName();

Resident.prototype.displayInTable = function(table) {
    var row = table.insertRow();
    row.insertCell().textContent = this.firstName;
    row.insertCell().textContent = this.lastName;
    row.insertCell().textContent = this.age;
    row.insertCell().textContent = this.residence;
    if (this.middleName) {
        row.insertCell().textContent = this.middleName;
    } else {
        row.insertCell().textContent = "-";
    }
};

var residents = [];

function createResidents() {
    residents.push(new Resident("Krusty", "The Clown", 59));
    residents.push(new Resident("Rod", "Flanders", 10));
    residents.push(new Resident("Ralph", "Wiggum", 8));
    residents.push(new Simpson("Homer", "Simpson", 42, "Jay"));
    residents.push(new Simpson("Marge", "Simpson", 34, "Jaqueline"));
    residents.push(new Simpson("Bart", "Simpson", 10, "JoJo"));
    residents.push(new Simpson("Lisa", "Simpson", 8, "Marie"));
    residents.push(new Simpson("Maggie", "Simpson", 2, "Lenny"));
}

function displayInformation() {
    var table = document.getElementById("obyvateleTable");
    while (table.rows.length > 1) {
        table.deleteRow(1);
    }

    residents.forEach(function(resident) {
        resident.displayInTable(table);
    });
}

createResidents();