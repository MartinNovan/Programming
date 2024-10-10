function Obyvatel(jmeno, prijmeni, vek) {
    this.jmeno = jmeno;
    this.prijmeni = prijmeni;
    this.vek = vek;
    this.bydliste = "Springfield";
}

Obyvatel.prototype.vypisInfo = function() {
    console.log(`Jméno: ${this.jmeno} ${this.prijmeni}, Věk: ${this.vek}, Bydliště: ${this.bydliste}`);
};

var sasaKrusty = new Obyvatel("Šáša", "Krusty", 59);
var rodFlanders = new Obyvatel("Rod", "Flanders", 10);
var ralphWiggum = new Obyvatel("Ralph", "Wiggum", 8);

sasaKrusty.vypisInfo();
rodFlanders.vypisInfo();
ralphWiggum.vypisInfo();

function Simpsonovi(jmeno, prijmeni, vek, prostredniJmeno) {
    Obyvatel.call(this, jmeno, prijmeni, vek);
    this.prostredniJmeno = prostredniJmeno;
}

Simpsonovi.prototype = Object.create(Obyvatel.prototype);

Simpsonovi.prototype.vypisCeleJmeno = function() {
    console.log(`Celé jméno: ${this.jmeno} ${this.prostredniJmeno} ${this.prijmeni}`);
};

var homer = new Simpsonovi("Homer", "Simpson", 42, "Jay");
var marge = new Simpsonovi("Marge", "Simpson", 34, "Jaqueline");
var bart = new Simpsonovi("Bart", "Simpson", 10, "JoJo");

homer.vypisInfo();
homer.vypisCeleJmeno();

marge.vypisInfo();
marge.vypisCeleJmeno();

bart.vypisInfo();
bart.vypisCeleJmeno();


Obyvatel.prototype.vypisDoTabulky = function(table) {
    var row = table.insertRow();
    row.insertCell().textContent = this.jmeno;
    row.insertCell().textContent = this.prijmeni;
    row.insertCell().textContent = this.vek;
    row.insertCell().textContent = this.bydliste;
    if (this.prostredniJmeno) {
        row.insertCell().textContent = this.prostredniJmeno;
    } else {
        row.insertCell().textContent = "-";
    }
};

var obyvatele = [];

function vytvorObyvatele() {
    obyvatele.push(new Obyvatel("Šáša", "Krusty", 59));
    obyvatele.push(new Obyvatel("Rod", "Flanders", 10));
    obyvatele.push(new Obyvatel("Ralph", "Wiggum", 8));
    obyvatele.push(new Simpsonovi("Homer", "Simpson", 42, "Jay"));
    obyvatele.push(new Simpsonovi("Marge", "Simpson", 34, "Jaqueline"));
    obyvatele.push(new Simpsonovi("Bart", "Simpson", 10, "JoJo"));
    obyvatele.push(new Simpsonovi("Líza", "Simpson", 8, "Marie"));
    obyvatele.push(new Simpsonovi("Maggie", "Simpson", 2, "Lenny"));
}

function vypisInformace() {
    var table = document.getElementById("obyvateleTable");
    while (table.rows.length > 1) {
        table.deleteRow(1);
    }

    obyvatele.forEach(function(obyvatel) {
        obyvatel.vypisDoTabulky(table);
    });
}

function Simpsonovi(jmeno, prijmeni, vek, prostredniJmeno) {
    Obyvatel.call(this, jmeno, prijmeni, vek);
    this.prostredniJmeno = prostredniJmeno;
}

Simpsonovi.prototype = Object.create(Obyvatel.prototype);

vytvorObyvatele();